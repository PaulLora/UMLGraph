using System;
using System.Collections.Generic;
using System.Xml;

namespace NClass.Core
{
	public abstract class OperationContainer : TypeBase, IMethodAllower
	{
		List<Operation> operationList;

		/// <exception cref="BadSyntaxException">
		/// The <paramref name="name"/> does not fit to the syntax.
		/// </exception>
		protected OperationContainer(string name) : base(name)
		{
			operationList = new List<Operation>();
		}

		public IEnumerable<Operation> Operations
		{
			get
			{
				for (int i = 0; i < OperationList.Count; i++)
					yield return OperationList[i];
			}
		}

		protected List<Operation> OperationList
		{
			get { return operationList; }
		}

		public int OperationCount
		{
			get { return OperationList.Count; }
		}

		public virtual AccessModifier DefaultMemberAccess
		{
			get { return AccessModifier.Private; }
		}

		public virtual void RemoveMember(Member member)
		{
			if (member is Operation)
				OperationList.Remove((Operation) member);
		}

		public override void MoveUpItem(object item)
		{
			if (item is Operation)
				TypeHelper.MoveUpItem(OperationList, (Operation) item);
		}

		public override void MoveDownItem(object item)
		{
			if (item is Operation)
				TypeHelper.MoveDownItem(OperationList, (Operation) item);
		}

		/// <exception cref="ArgumentNullException">
		/// <paramref name="node"/> is null.
		/// </exception>
		internal override void Serialize(XmlNode node)
		{
			base.Serialize(node);
			TypeHelper.SaveMembers(OperationList, "Operation", node);
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
			TypeHelper.LoadMembers(OperationList, "Operation", node, this);
		}

		/// <exception cref="BadSyntaxException">
		/// The <paramref name="name"/> does not fit to the syntax.
		/// </exception>
		public abstract Method AddMethod(string name);
	}
}
