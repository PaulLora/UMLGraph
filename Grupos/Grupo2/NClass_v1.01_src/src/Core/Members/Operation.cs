
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace NClass.Core
{
	public abstract class Operation : Member
	{
		// Interface.Method
		private  const string CSharpOperationNamePattern =
			"(" + SyntaxHelper.GenericTypePattern + @"\.)?" + SyntaxHelper.NamePattern;
		// Interface.Method<T>
		internal const string CSharpGenericOperationNamePattern =
			CSharpOperationNamePattern + @"(\s*" + SyntaxHelper.GenericNamePattern + ")?";

		// [abstract | virtual | override | sealed override | overide sealed]
		protected const string CSharpModifierPattern =
			@"(?(static)|(?<modifier>abstract|virtual|override|" +
			@"sealed\s+override|override\s+sealed)?(?(modifier)\s+|))";

		// [abstract | final]
		protected const string JavaModifierPattern =
			@"(?(static)|(?<modifier>abstract|final)?(?(modifier)\s+|))";

		OperationModifier modifier;
		ParameterCollection parameterList;

		/// <exception cref="BadSyntaxException">
		/// The <paramref name="name"/> does not fit to the syntax.
		/// </exception>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="parent"/> is null.
		/// </exception>
		protected Operation(string name, OperationContainer parent) : base(name, parent)
		{
			parameterList = ParameterCollection.GetCollection(Language);
			Modifier = OperationModifier.None;
		}

		public bool HasParameter
		{
			get
			{
				return (ParameterList != null && ParameterList.Count > 0);
			}
		}

		protected ParameterCollection ParameterList
		{
			get { return parameterList; }
		}

		/// <exception cref="BadSyntaxException">
		/// Cannot set modifier.
		/// </exception>
		public virtual OperationModifier Modifier
		{
			get
			{
				return modifier;
			}
			set
			{
				if (value != OperationModifier.None && !(Parent is IOverridableType))
					throw new BadSyntaxException("error_cannot_set_modifier");

				if (value == OperationModifier.Abstract)
					((IOverridableType) Parent).Modifier = InheritanceModifier.Abstract;

				modifier = value;
			}
		}

		public virtual bool CanSetModifier
		{
			get { return (Parent is ClassType && CanSetStatic); }
		}

		/// <exception cref="BadSyntaxException">
		/// Cannot set static modifier.
		/// </exception>
		public override bool IsStatic
		{
			get
			{
				return base.IsStatic;
			}
			set
			{
				if (value && Parent is InterfaceType) {
					throw new BadSyntaxException("error_static_interface_member");
				}

				if (value)
					Modifier = OperationModifier.None;
				base.IsStatic = value;
			}
		}

		public override bool CanSetStatic
		{
			get
			{
				return (base.CanSetStatic && !(Parent is InterfaceType));
			}
		}

		public virtual bool Overridable
		{
			get
			{
				if (Language == Language.CSharp) {
					return (
						Access != AccessModifier.Private &&
						Modifier != OperationModifier.None &&
						Modifier != OperationModifier.Sealed
					);
				}
				else {
					return (
						Access != AccessModifier.Private &&
						Modifier != OperationModifier.Sealed
					);
				}
			}
		}

		public override object Clone()
		{
			Operation clone = (Operation) base.Clone();

			clone.parameterList = (ParameterCollection) ParameterList.Clone();
			return clone;
		}
	}
}
