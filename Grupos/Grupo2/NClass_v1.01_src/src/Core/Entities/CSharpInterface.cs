using System;
using System.Collections.Generic;

namespace NClass.Core
{
	internal sealed class CSharpInterface : InterfaceType, IPropertyAllower, IEventAllower
	{
		/// <exception cref="BadSyntaxException">
		/// The <paramref name="name"/> does not fit to the syntax.
		/// </exception>
		public CSharpInterface(string name) : base(name)
		{
		}

		public override string Signature
		{
			get
			{
				return SyntaxHelper.GetAccessModifier(
					Access, Language.CSharp, false) + " Interface";
			}
		}

		public override AccessModifier DefaultMemberAccess
		{
			get { return AccessModifier.Public; }
		}

		public override Language Language
		{
			get { return Language.CSharp; }
		}

		/// <exception cref="BadSyntaxException">
		/// The <paramref name="name"/> does not fit to the syntax.
		/// </exception>
		public override Method AddMethod(string name)
		{
			Method method = new CSharpMethod(name, this);

			OperationList.Add(method);
			return method;
		}

		/// <exception cref="BadSyntaxException">
		/// The <paramref name="name"/> does not fit to the syntax.
		/// </exception>
		public Property AddProperty(string name)
		{
			Property property = new Property(name, this);

			OperationList.Add(property);
			return property;
		}

		/// <exception cref="BadSyntaxException">
		/// The <paramref name="name"/> does not fit to the syntax.
		/// </exception>
		public Event AddEvent(string name)
		{
			Event newEvent = new Event(name, this);

			OperationList.Add(newEvent);
			return newEvent;
		}
	}
}
