using System;
using System.Text.RegularExpressions;
namespace NClass.Core
{
	internal class CSharpParameterCollection : ParameterCollection
	{
		// [modifier] <type> <name> [,]
		const string CSharpParameterPattern =
			@"\s*(?<modifier>out|ref|params)?(?(modifier)\s+|)" +
			@"(?<type>" + SyntaxHelper.GenericTypePattern2 + @")\s+" +
			@"(?<name>" + SyntaxHelper.NamePattern + @")\s*(,|$)";
		const string ParameterStringPattern = @"^\s*(" + CSharpParameterPattern + ")*$";

		static Regex parameterRegex =
			new Regex(CSharpParameterPattern, RegexOptions.ExplicitCapture);
		static Regex singleParamterRegex =
			new Regex("^" + CSharpParameterPattern + "$", RegexOptions.ExplicitCapture);
		static Regex parameterStringRegex =
			new Regex(ParameterStringPattern, RegexOptions.ExplicitCapture);

		internal CSharpParameterCollection()
		{
		}

		/// <exception cref="ArgumentNullException">
		/// <paramref name="collection"/> is null.
		/// </exception>
		private CSharpParameterCollection(CSharpParameterCollection collection)
			: base(collection)
		{
		}

		/// <exception cref="BadSyntaxException">
		/// The <paramref name="declaration"/> does not fit to the syntax.
		/// </exception>
		/// <exception cref="ReservedNameException">
		/// The parameter name is already exists.
		/// </exception>
		public override Parameter Add(string declaration)
		{
			Match match = singleParamterRegex.Match(declaration);

			if (match.Success) {
				Group nameGroup = match.Groups["name"];
				Group typeGroup = match.Groups["type"];
				Group modifierGroup = match.Groups["modifier"];

				if (ReservedName(nameGroup.Value))
					throw new ReservedNameException(nameGroup.Value);

				Parameter parameter = new CSharpParameter(nameGroup.Value, typeGroup.Value,
					SyntaxHelper.ParseParameterModifier(modifierGroup.Value));
				InnerList.Add(parameter);

				return parameter;
			}
			else {
				throw new BadSyntaxException("error_invalid_parameter_declaration");
			}
		}

		/// <exception cref="BadSyntaxException">
		/// The <paramref name="declaration"/> does not fit to the syntax.
		/// </exception>
		/// <exception cref="ReservedNameException">
		/// The parameter name is already exists.
		/// </exception>
		public override Parameter ModifyParameter(Parameter parameter, string declaration)
		{
			Match match = singleParamterRegex.Match(declaration);
			int index = InnerList.IndexOf(parameter);

			if (index < 0)
				return parameter;

			if (match.Success) {
				Group nameGroup = match.Groups["name"];
				Group typeGroup = match.Groups["type"];
				Group modifierGroup = match.Groups["modifier"];

				if (ReservedName(nameGroup.Value, index))
					throw new ReservedNameException(nameGroup.Value);

				Parameter newParameter = new CSharpParameter(nameGroup.Value, typeGroup.Value,
					SyntaxHelper.ParseParameterModifier(modifierGroup.Value));
				InnerList[index] = newParameter;
				return newParameter;
			}
			else {
				throw new BadSyntaxException("error_invalid_parameter_declaration");
			}
		}

		public override object Clone()
		{
			return new CSharpParameterCollection(this);
		}

		/// <exception cref="BadSyntaxException">
		/// The <paramref name="declaration"/> does not fit to the syntax.
		/// </exception>
		public override void InitFromString(string declaration)
		{
			if (parameterStringRegex.IsMatch(declaration)) {
				Clear();
				foreach (Match match in parameterRegex.Matches(declaration)) {
					Group nameGroup = match.Groups["name"];
					Group typeGroup = match.Groups["type"];
					Group modifierGroup = match.Groups["modifier"];

					InnerList.Add(new CSharpParameter(nameGroup.Value, typeGroup.Value,
						SyntaxHelper.ParseParameterModifier(modifierGroup.Value)));
				}
			}
			else {
				throw new BadSyntaxException("error_invalid_parameter_declaration");
			}
		}
	}
}
