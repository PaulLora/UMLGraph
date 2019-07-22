using System;
using System.Text;
using System.Text.RegularExpressions;

namespace NClass.Core
{
	public sealed class Event : Operation
	{
		// [<access>] [<modifier>] [static] event <type> <name>
		const string EventPattern =
			@"^\s*" + CSharpAccessPattern + CSharpModifierPattern + StaticPattern + @"event\s+" +
			@"(?<type>" + SyntaxHelper.GenericTypePattern2 + @")\s+" +
			@"(?<name>" + CSharpGenericOperationNamePattern + ")" +
			SyntaxHelper.DeclarationEnding;

		const string NamePattern =
			@"^\s*(?<name>" + CSharpGenericOperationNamePattern + @")\s*$";

		static Regex eventRegex = new Regex(EventPattern, RegexOptions.ExplicitCapture);
		static Regex nameRegex = new Regex(NamePattern, RegexOptions.ExplicitCapture);
		static Regex typeRegex = new Regex(TypePattern, RegexOptions.ExplicitCapture);

		/// <exception cref="BadSyntaxException">
		/// The <paramref name="name"/> does not fit to the syntax.
		/// </exception>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="parent"/> is null.
		/// </exception>
		internal Event(string name, OperationContainer parent) : base(name, parent)
		{
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
				Match match = nameRegex.Match(value);

				if (match.Success)
					base.Name = match.Groups["name"].Value;
				else
					throw new BadSyntaxException("error_invalid_name");
			}
		}

		/// <exception cref="BadSyntaxException">
		/// The <paramref name="value"/> does not fit to the syntax.
		/// </exception>
		public override string Type
		{
			get
			{
				return base.Type;
			}
			set
			{
				Match match = typeRegex.Match(value);

				if (match.Success)
					base.Type = match.Groups["type"].Value;
				else
					throw new BadSyntaxException("error_invalid_type_name");
			}
		}

		protected override string DefaultType
		{
			get
			{
				return "EventHandler";
			}
		}

		public override Language Language
		{
			get { return Language.CSharp; }
		}

		/// <exception cref="BadSyntaxException">
		/// The <paramref name="declaration"/> does not fit to the syntax.
		/// </exception>
		public override void InitFromString(string declaration)
		{
			Match match = eventRegex.Match(declaration);

			if (match.Success) {
				try {
					Group nameGroup     = match.Groups["name"];
					Group typeGroup     = match.Groups["type"];
					Group accessGroup   = match.Groups["access"];
					Group modifierGroup = match.Groups["modifier"];
					Group staticGroup   = match.Groups["static"];

					Name = nameGroup.Value;
					Type = typeGroup.Value;
					AccessModifier = SyntaxHelper.ParseAccessModifier(accessGroup.Value);
					Modifier = SyntaxHelper.ParseOperationModifier(modifierGroup.Value);
					IsStatic = staticGroup.Success;
				}
				catch (BadSyntaxException ex) {
					throw new BadSyntaxException("error_invalid_declaration" + ex.Message);
				}
			}
			else {
				throw new BadSyntaxException("error_invalid_declaration");
			}
		}

		public override string GetCaption(bool getType, bool getParameters,
			bool getParameterNames, bool getInitValue)
		{
			if (getType)
				return Name + " : " + Type;
			else
				return Name;
		}

		public override string ToString()
		{
			StringBuilder builder = new StringBuilder(50);

			if (AccessModifier != AccessModifier.Default) {
				builder.Append(SyntaxHelper.GetAccessModifier(AccessModifier, Language.CSharp));
				builder.Append(" ");
			}
			if (Modifier != OperationModifier.None) {
				builder.Append(SyntaxHelper.GetOperationModifier(Modifier, Language.CSharp));
				builder.Append(" ");
			}
			if (IsStatic) {
				builder.Append("static");
				builder.Append(" ");
			}

			builder.AppendFormat("event {0} {1}", Type, Name);
			return builder.ToString();
		}
	}
}
