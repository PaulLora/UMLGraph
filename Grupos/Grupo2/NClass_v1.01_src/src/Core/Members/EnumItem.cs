using System;
using System.Text.RegularExpressions;

namespace NClass.Core
{
	public class EnumItem
	{
		// <name> [= value]
		const string EnumNamePattern = "(?<name>" + SyntaxHelper.NamePattern + ")";
		const string EnumItemPattern = @"^\s*" + EnumNamePattern +
			@"(\s*=\s*(?<value>\d+))?\s*$";
		const int EmptyValue = 0;

		static Regex enumNameRegex = new Regex(EnumNamePattern, RegexOptions.ExplicitCapture);
		static Regex enumItemRegex = new Regex(EnumItemPattern, RegexOptions.ExplicitCapture);

		string name;
		int initValue;

		private EnumItem()
		{
		}

		public string Name
		{
			get { return name; }
		}

		public int InitValue
		{
			get { return initValue; }
		}

		/// <exception cref="BadSyntaxException">
		/// The <paramref name="declaration"/> does not fit to the syntax.
		/// </exception>
		public void InitFromString(string declaration)
		{
			Match match = enumItemRegex.Match(declaration);

			if (match.Success) {
				Group nameGroup = match.Groups["name"];
				Group valueGroup = match.Groups["value"];

				name = nameGroup.Value;
				if (valueGroup.Success)
					int.TryParse(valueGroup.Value, out initValue);
				else
					initValue = EmptyValue;
			}
			else {
				throw new BadSyntaxException("error_invalid_declaration");
			}
		}

		/// <exception cref="BadSyntaxException">
		/// The <paramref name="declaration"/> does not fit to the syntax.
		/// </exception>
		internal static EnumItem LoadFromString(string declaration)
		{
			EnumItem value = new EnumItem();

			value.InitFromString(declaration);
			return value;
		}

		public override string ToString()
		{
			if (InitValue == EmptyValue)
				return Name.ToString();
			else
				return Name + " = " + InitValue;
		}
	}
}