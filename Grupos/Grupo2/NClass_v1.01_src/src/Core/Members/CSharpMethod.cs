using System;
using System.Text;
using System.Text.RegularExpressions;
namespace NClass.Core
{
	internal sealed class CSharpMethod : Method, IOperator
	{
		const string OperatorsPattern =
			@"(\+|-|\*|/|%|&|\||\^|!|~|\+\+|--|<<|>>|==|!=|>|<|>=|<=)";

		// operator <operator>
		const string OperatorPattern =
			@"(?(static)operator\s*(?<operator>" + OperatorsPattern + ")|)";

		// {implicit | explicit} operator <operator>
		const string ConvOperatorPattern = @"(?(static)(?<convop>implicit|explicit)" +
			@"\s+operator\s+(?<operator>" + SyntaxHelper.GenericTypePattern2 + ")|)";

		// [public static {explicit | implicit | <type>} operator <operator>(<args>) |
		// [<access>] [<modifier> | static] <type> <name>(<args>)]
		const string MethodPattern =
			@"^\s*" + CSharpAccessPattern + CSharpModifierPattern + StaticPattern +
			@"((?<name>" + ConvOperatorPattern + ")|" +
			@"(?<type>" + SyntaxHelper.GenericTypePattern2 + @")\s+" +
			@"(?<name>" + OperatorPattern + "|" + CSharpGenericOperationNamePattern + "))" +
			@"\((?<args>.*)\)" + SyntaxHelper.DeclarationEnding;

		// [explicit | implicit] operator <operator> | <name>
		const string NamePattern =
			@"^\s*(?<name>((?<convop>implicit\s+|explicit\s+)?operator" + 
			@"(?<operator>(?(convop)\s+" + SyntaxHelper.GenericTypePattern2 + @"|\s*" + 
			OperatorsPattern + @"))|" + CSharpGenericOperationNamePattern + @"))\s*$";

		static Regex methodRegex = new Regex(MethodPattern, RegexOptions.ExplicitCapture);
		static Regex nameRegex = new Regex(NamePattern, RegexOptions.ExplicitCapture);
		static Regex typeRegex = new Regex(TypePattern, RegexOptions.ExplicitCapture);

		bool isOperator;
		bool isConversionOperator;

		/// <exception cref="BadSyntaxException">
		/// The <paramref name="name"/> does not fit to the syntax.
		/// </exception>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="parent"/> is null.
		/// </exception>
		internal CSharpMethod(string name, OperationContainer parent) : base(name, parent)
		{
			IsOperator = false;
			IsConversionOperator = false;
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

				if (match.Success) {
					base.Name = match.Groups["name"].Value;
					IsOperator = match.Groups["operator"].Success;
					IsConversionOperator = match.Groups["convop"].Success;
				}
				else {
					throw new BadSyntaxException("error_invalid_name");
				}
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
				if (string.IsNullOrEmpty(value) && IsConversionOperator) {
					base.Type = null;
					return;
				}

				Match match = typeRegex.Match(value);

				if (match.Success)
					base.Type = match.Groups["type"].Value;
				else
					throw new BadSyntaxException("error_invalid_type_name");
			}
		}

		/// <exception cref="BadSyntaxException">
		/// Cannot set access visibility.
		/// </exception>
		public override AccessModifier AccessModifier
		{
			get
			{
				return base.AccessModifier;
			}
			set
			{
				if (value != AccessModifier.Public && IsOperator) {
					throw new BadSyntaxException("error_operator_must_be_public");
				}
				base.AccessModifier = value;
			}
		}

		public override bool CanSetAccess
		{
			get
			{
				return (base.CanSetAccess && !IsOperator);
			}
		}

		/// <exception cref="BadSyntaxException">
		/// Cannot set modifier.
		/// </exception>
		public override OperationModifier Modifier
		{
			get
			{
				return base.Modifier;
			}
			set
			{
				if (value != OperationModifier.None)
					IsStatic = false;

				base.Modifier = value;
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
				if (!value && IsOperator) {
					throw new BadSyntaxException("error_operator_must_be_static");
				}
				base.IsStatic = value;
			}
		}

		public override bool CanSetStatic
		{
			get
			{
				return (base.CanSetStatic && !IsOperator);
			}
		}

		public bool IsOperator
		{
			get
			{
				return isOperator;
			}
			private set
			{
				if (value) {
					IsStatic = true;
					AccessModifier = AccessModifier.Public;
				}
				else {
					IsConversionOperator = false;
				}

				isOperator = value;
			}
		}

		public bool IsConversionOperator
		{
			get
			{
				return isConversionOperator;
			}
			private set
			{
				if (value) {
					IsOperator = true;
					isConversionOperator = value;
					Type = null;
				}
				else if (isConversionOperator) {
					isConversionOperator = value;
					Type = DefaultType;
				}
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
			Match match = methodRegex.Match(declaration);

			if (match.Success) {
				try {
					Group nameGroup     = match.Groups["name"];
					Group typeGroup     = match.Groups["type"];
					Group accessGroup   = match.Groups["access"];
					Group modifierGroup = match.Groups["modifier"];
					Group staticGroup   = match.Groups["static"];
					Group operatorGroup = match.Groups["operator"];
					Group convopGroup   = match.Groups["convop"];
					Group argsGroup     = match.Groups["args"];

					base.Name = nameGroup.Value;
					base.Type = typeGroup.Value;
					IsOperator = operatorGroup.Success;
					IsConversionOperator = convopGroup.Success;
					AccessModifier = SyntaxHelper.ParseAccessModifier(accessGroup.Value);
					Modifier = SyntaxHelper.ParseOperationModifier(modifierGroup.Value);
					IsStatic = staticGroup.Success;
					ParameterList.InitFromString(argsGroup.Value);
				}
				catch (BadSyntaxException ex) {
					throw new BadSyntaxException("error_invalid_declaration" + ex.Message);
				}
			}
			else {
				throw new BadSyntaxException("error_invalid_declaration");
			}
		}
	}
}
