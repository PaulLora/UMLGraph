using System;
using System.Text.RegularExpressions;

namespace NClass.Core
{
	public abstract class Parameter
	{
		string type;
		string name;
		ParameterModifier modifier;

		/// <exception cref="BadSyntaxException">
		/// The <paramref name="name"/> or <paramref name="type"/> 
		/// does not fit to the syntax.
		/// </exception>
		protected Parameter(string name, string type, ParameterModifier modifier)
		{
			Name = name;
			Type = type;
			Modifier = modifier;
		}

		/// <exception cref="BadSyntaxException">
		/// The <paramref name="value"/> does not fit to the syntax.
		/// </exception>
		public string Name
		{
			get
			{
				return name;
			}
			private set
			{
				if (SyntaxHelper.IsForbiddenName(value, Language)) {
					throw new BadSyntaxException("error_invalid_parameter_declaration");
				}
				name = value;
			}
		}

		/// <exception cref="BadSyntaxException">
		/// The <paramref name="value"/> does not fit to the syntax.
		/// </exception>
		public string Type
		{
			get
			{
				return type;
			}
			private set
			{
				if (SyntaxHelper.IsForbiddenTypeName(value, Language) || value == "void") {
					throw new BadSyntaxException("error_invalid_parameter_declaration");
				}
				type = value;
			}
		}

		public ParameterModifier Modifier
		{
			get
			{
				return modifier;
			}
			private set
			{
				modifier = value;
			}
		}

		public abstract Language Language
		{
			get;
		}

		public string GetCaption(bool getName)
		{
			string typeAndModifier;

			if (Modifier == ParameterModifier.None)
				typeAndModifier = Type;
			else
				typeAndModifier = Modifier.ToString().ToLower() + " " + Type;

			if (getName)
				return Name + ": " + typeAndModifier;
			else
				return typeAndModifier;
		}

		public override string ToString()
		{
			if (Modifier == ParameterModifier.None) {
				return Type + " " + Name;
			}
			else {
				return string.Format("{0} {1} {2}",
					Modifier.ToString().ToLower(), Type, Name);
			}

		}
	}
}
