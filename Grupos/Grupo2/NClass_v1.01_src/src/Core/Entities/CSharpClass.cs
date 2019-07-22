using System;
using System.Collections.Generic;

namespace NClass.Core
{
	internal sealed class CSharpClass : ClassType,
		IPropertyAllower, IEventAllower, IDestructorAllower
	{
		/// <exception cref="BadSyntaxException">
		/// The <paramref name="name"/> does not fit to the syntax.
		/// </exception>
		internal CSharpClass(String name) : base(name)
		{
		}

		public bool CanAddDestructor
		{
			get { return Modifier != InheritanceModifier.Static; }
		}

		public override string Signature
		{
			get
			{
				string accessString = SyntaxHelper.GetAccessModifier(
					Access, Language.CSharp, false);

				if (Modifier == InheritanceModifier.None)
					return string.Format("{0} Class", accessString);
				else
					return string.Format("{0} {1} Class", accessString, Modifier);
			}
		}

		public override Language Language
		{
			get { return Language.CSharp; }
		}

		/// <exception cref="ArgumentException">
		/// The language of <paramref name="interfaceType"/> does not equal.-or-
		/// <paramref name="interfaceType"/> is earlier implemented interface.
		/// </exception>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="interfaceType"/> is null.
		/// </exception>
		internal override void AddInterface(InterfaceType interfaceType)
		{
			if (!(interfaceType is CSharpInterface)) {
				throw new ArgumentException("interfaceType");
			}

			base.AddInterface(interfaceType);
		}

		/// <exception cref="BadSyntaxException">
		/// The <paramref name="name"/> does not fit to the syntax.
		/// </exception>
		public override Field AddField(string name)
		{
			Field field = new CSharpField(name, this);

			FieldList.Add(field);
			return field;
		}

		public override Method AddConstructor()
		{
			Constructor constructor = new CSharpConstructor(this);

			if (Modifier == InheritanceModifier.Abstract)
				constructor.AccessModifier = AccessModifier.Protected;
			else if (Modifier != InheritanceModifier.Static)
				constructor.AccessModifier = AccessModifier.Public;
			OperationList.Add(constructor);
			return constructor;
		}

		public Method AddDestructor()
		{
			Destructor destructor = new Destructor(this);

			OperationList.Add(destructor);
			return destructor;
		}

		/// <exception cref="BadSyntaxException">
		/// The <paramref name="name"/> does not fit to the syntax.
		/// </exception>
		public override Method AddMethod(string name)
		{
			Method method = new CSharpMethod(name, this);

			method.AccessModifier = AccessModifier.Public;
			OperationList.Add(method);
			return method;
		}

		/// <exception cref="BadSyntaxException">
		/// The <paramref name="name"/> does not fit to the syntax.
		/// </exception>
		public Property AddProperty(string name)
		{
			Property property = new Property(name, this);

			property.AccessModifier = AccessModifier.Public;
			OperationList.Add(property);
			return property;
		}

		/// <exception cref="BadSyntaxException">
		/// The <paramref name="name"/> does not fit to the syntax.
		/// </exception>
		public Event AddEvent(string name)
		{
			Event newEvent = new Event(name, this);

			newEvent.AccessModifier = AccessModifier.Public;
			OperationList.Add(newEvent);
			return newEvent;
		}

		/// <exception cref="ArgumentException">
		/// <paramref name="operation"/> cannot be overridden.
		/// </exception>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="operation"/> is null.
		/// </exception>
		public override Operation Override(Operation operation)
		{
			if (operation == null)
				throw new ArgumentNullException("operation");

			if (operation.Modifier == OperationModifier.None ||
				operation.Modifier == OperationModifier.Sealed)
			{
				throw new ArgumentException( "error_cannot_override");
			}

			if (operation.Language != Language.CSharp)
				throw new ArgumentException("error_languages_do_not_equal");

			Operation newOperation = (Operation) operation.Clone();

			newOperation.Parent = this;
			newOperation.Modifier = OperationModifier.Override;
			OperationList.Add(newOperation);

			return newOperation;
		}
	}
}
