using System;
using System.Text;
using System.Text.RegularExpressions;

namespace NClass.Core
{
	internal sealed class CSharpField : Field, IConst
	{
		const string ReadonlyPattern = @"(?(const)|(?<readonly>readonly\s+)?)";
		const string ConstPattern = @"(?(static)|(?(readonly)|(?<const>const\s+)?))";
		const string FieldModifiersPattern = StaticPattern + ReadonlyPattern + ConstPattern;

		// [<access>] [[static] [readonly] | const] <type> <name> [= <initvalue>]
		const string FieldPattern =
			@"^\s*" + CSharpAccessPattern + FieldModifiersPattern +
			@"(?<type>" + SyntaxHelper.GenericTypePattern2 + @")\s+" +
			@"(?<name>" + SyntaxHelper.NamePattern + @")" +
			@"(\s*=\s*(?<initvalue>[^\s;](.*[^\s;])?))?" + SyntaxHelper.DeclarationEnding;

		static Regex fieldRegex = new Regex(FieldPattern, RegexOptions.ExplicitCapture);

		bool isConst;

		/// <exception cref="BadSyntaxException">
		/// The <paramref name="name"/> does not fit to the syntax.
		/// </exception>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="parent"/> is null.
		/// </exception>
		internal CSharpField(string name, OperationContainer parent) : base(name, parent)
		{
			IsConst = false;
		}

		/// <exception cref="BadSyntaxException">
		/// <see cref="IsConst"/> is set to true while 
		/// <see cref="Field.InitialValue"/> is empty.
		/// </exception>
		public bool IsConst
		{
			get
			{
				return isConst;
			}
			set
			{
				if (value) {
					if (!HasInitialValue) {
						throw new BadSyntaxException("error_const_lack_of_initialization");
					}
					isConst = true;
					if (!IsReadonly)
						IsReadonly = true;
					if (!IsStatic)
						IsStatic = true;
				}
				else {
					isConst = false;
				}
			}
		}

		public override bool IsReadonly
		{
			get
			{
				return base.IsReadonly;
			}
			set
			{
				if (!value && IsConst)
					IsConst = false;
				base.IsReadonly = value;
			}
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
				if (!value && IsConst)
					IsConst = false;
				base.IsStatic = value;
			}
		}

		bool IConst.CanSetConst
		{
			get { return HasInitialValue; }
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
			Match match = fieldRegex.Match(declaration);

			if (match.Success) {
				try {
					Group nameGroup     = match.Groups["name"];
					Group typeGroup     = match.Groups["type"];
					Group accessGroup   = match.Groups["access"];
					Group staticGroup   = match.Groups["static"];
					Group readonlyGroup = match.Groups["readonly"];
					Group constGroup    = match.Groups["const"];
					Group initGroup     = match.Groups["initvalue"];

					Name = nameGroup.Value;
					Type = typeGroup.Value;
					AccessModifier = SyntaxHelper.ParseAccessModifier(accessGroup.Value);
					IsStatic = staticGroup.Success;
					IsReadonly = readonlyGroup.Success;
					InitialValue = (initGroup.Success) ? initGroup.Value : "";
					IsConst = constGroup.Success;
				}
				catch (BadSyntaxException ex) {
					throw new BadSyntaxException("error_invalid_declaration" + ex.Message);
				}
			}
			else {
				throw new BadSyntaxException("error_invalid_declaration");
			}
		}

		public override string ToString()
		{
			StringBuilder builder = new StringBuilder(50);

			if (AccessModifier != AccessModifier.Default) {
				builder.Append(SyntaxHelper.GetAccessModifier(AccessModifier, Language.CSharp));
				builder.Append(" ");
			}

			if (IsConst) {
				builder.Append("const ");
			}
			else {
				if (IsStatic)
					builder.Append("static ");
				if (IsReadonly)
					builder.Append("readonly ");
			}

			builder.AppendFormat("{0} {1}", Type, Name);
			if (HasInitialValue)
				builder.AppendFormat(" = {0}", InitialValue);

			return builder.ToString();
		}
	}
}
