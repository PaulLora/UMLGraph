using System;
using System.Text.RegularExpressions;
namespace NClass.Core
{
	internal sealed class CSharpConstructor : Constructor
	{
		// [<access>] [static] <name>([<args>])
		const string ConstructorPattern =
			@"^\s*" + CSharpAccessPattern + StaticPattern +
			@"(?<name>" + SyntaxHelper.NamePattern + ")" +
			@"\((?(static)|(?<args>.*))\)" + SyntaxHelper.DeclarationEnding;

		static Regex constructorRegex =
			new Regex(ConstructorPattern, RegexOptions.ExplicitCapture);

		/// <exception cref="ArgumentNullException">
		/// <paramref name="parent"/> is null.
		/// </exception>
		internal CSharpConstructor(OperationContainer parent) : base(parent)
		{
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
			Match match = constructorRegex.Match(declaration);

			if (match.Success) {
				try {
					Group nameGroup   = match.Groups["name"];
					Group accessGroup = match.Groups["access"];
					Group staticGroup = match.Groups["static"];
					Group argsGroup   = match.Groups["args"];

					Name = nameGroup.Value;
					AccessModifier = SyntaxHelper.ParseAccessModifier(accessGroup.Value);
					ParameterList.InitFromString(argsGroup.Value);
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
	}
}
