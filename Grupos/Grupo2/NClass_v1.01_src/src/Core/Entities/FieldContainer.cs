using System;
using System.Collections.Generic;
using System.Xml;

namespace NClass.Core
{
	public abstract class FieldContainer : OperationContainer,
		IInterfaceImplementer, IConstructorAllower, IFieldAllower
	{
		List<Field> fieldList;
		List<InterfaceType> interfaceList;

		/// <exception cref="BadSyntaxException">
		/// The <paramref name="name"/> does not fit to the syntax.
		/// </exception>
		protected FieldContainer(string name) : base(name)
		{
			fieldList = new List<Field>();
			interfaceList = new List<InterfaceType>();
		}

		/// <exception cref="BadSyntaxException">
		/// The <paramref name="value"/> does not fit to the syntax.
		/// </exception>
		public override string Name
		{
			get
			{
				return base.Name;
			}
			set
			{
				base.Name = value;

				if (OperationList != null) {
					for (int i = 0; i < OperationList.Count; i++) {
						if (OperationList[i] is Constructor)
							((Constructor) OperationList[i]).RefreshName();
						else if (OperationList[i] is Destructor)
							((Destructor) OperationList[i]).RefreshName();
					}
				}
			}
		}

		public IEnumerable<Field> Fields
		{
			get
			{
				for (int i = 0; i < FieldList.Count; i++)
					yield return FieldList[i];
			}
		}

		protected List<Field> FieldList
		{
			get { return fieldList; }
		}

		public int FieldCount
		{
			get { return FieldList.Count; }
		}

		public IEnumerable<InterfaceType> Interfaces
		{
			get
			{
				for (int i = 0; i < InterfaceList.Count; i++)
					yield return InterfaceList[i];
			}
		}

		protected List<InterfaceType> InterfaceList
		{
			get { return interfaceList; }
		}

		public bool ImplementsInterface
		{
			get
			{
				return (InterfaceList.Count > 0);
			}
		}

		public virtual bool CanAddConstructor
		{
			get { return true; }
		}

		/// <exception cref="ArgumentException">
		/// The language of <paramref name="interfaceType"/> does not equal.-or-
		/// <paramref name="interfaceType"/> is earlier implemented interface.
		/// </exception>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="interfaceType"/> is null.
		/// </exception>
		internal virtual void AddInterface(InterfaceType interfaceType)
		{
			if (interfaceType == null)
				throw new ArgumentNullException("interfaceType");

			for (int i = 0; i < InterfaceList.Count; i++) {
				if (InterfaceList[i] == interfaceType) {
					throw new ArgumentException("error_cannot_add_same_interface");
				}
			}
			
			InterfaceList.Add(interfaceType);
		}

		/// <exception cref="ArgumentException">
		/// The language of <paramref name="interfaceType"/> does not equal.-or-
		/// <paramref name="interfaceType"/> is earlier implemented interface.
		/// </exception>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="interfaceType"/> is null.
		/// </exception>
		void IInterfaceImplementer.AddInterface(InterfaceType interfaceType)
		{
			AddInterface(interfaceType);
		}

		internal void RemoveInterface(InterfaceType interfaceType)
		{
			InterfaceList.Remove(interfaceType);
		}

		void IInterfaceImplementer.RemoveInterface(InterfaceType interfaceType)
		{
			RemoveInterface(interfaceType);
		}

		/// <exception cref="ArgumentException">
		/// The language of <paramref name="operation"/> does not equal.
		/// </exception>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="operation"/> is null.
		/// </exception>
		public Operation Implement(Operation operation)
		{
			if (operation == null)
				throw new ArgumentNullException("operation");

			if (operation.Language != Language)
				throw new ArgumentException("error_languages_do_not_equal");

			Operation newOperation = (Operation) operation.Clone();

			newOperation.Parent = this;
			newOperation.AccessModifier = AccessModifier.Public;
			newOperation.Modifier = OperationModifier.None;
			newOperation.IsStatic = false;
			OperationList.Add(newOperation);

			return newOperation;
		}

		public override void RemoveMember(Member member)
		{
			if (member is Field) {
				FieldList.Remove((Field) member);
			}
			else {
				base.RemoveMember(member);
			}
		}

		/// <exception cref="ArgumentNullException">
		/// <paramref name="node"/> is null.
		/// </exception>
		internal override void Serialize(XmlNode node)
		{
			base.Serialize(node);
			TypeHelper.SaveMembers(FieldList, "Field", node);
		}

		/// <exception cref="BadSyntaxException">
		/// An error occured in building the class.
		/// </exception>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="node"/> is null.
		/// </exception>
		internal override void Deserialize(XmlNode node)
		{
			base.Deserialize(node);
			TypeHelper.LoadMembers(FieldList, "Field", node, this);
		}

		public override void MoveUpItem(object item)
		{
			if (item is Field)
				TypeHelper.MoveUpItem(FieldList, (Field) item);
			else
				base.MoveUpItem(item);
		}

		public override void MoveDownItem(object item)
		{
			if (item is Field)
				TypeHelper.MoveDownItem(FieldList, (Field) item);
			else
				base.MoveDownItem(item);
		}

		public abstract Method AddConstructor();

		/// <exception cref="BadSyntaxException">
		/// The <paramref name="name"/> does not fit to the syntax.
		/// </exception>
		public abstract Field AddField(string name);
	}
}
