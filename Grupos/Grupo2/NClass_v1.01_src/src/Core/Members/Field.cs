using System;
using System.Xml;
using System.Text;
using System.Text.RegularExpressions;

namespace NClass.Core
{
	public abstract class Field : Member
	{
		bool isReadonly;
		string initialValue;

		const string NamePattern =
			@"^\s*" + "(?<name>" + SyntaxHelper.NamePattern + @")\s*$";

		static Regex nameRegex = new Regex(NamePattern, RegexOptions.ExplicitCapture);
		static Regex typeRegex = new Regex(TypePattern, RegexOptions.ExplicitCapture);

		/// <exception cref="BadSyntaxException">
		/// The <paramref name="name"/> does not fit to the syntax.
		/// </exception>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="parent"/> is null.
		/// </exception>
		protected Field(string name, OperationContainer parent) : base(name, parent)
		{
			IsReadonly = false;
			InitialValue = null;
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
				if (value == "void")
					throw new BadSyntaxException("error_type");

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
				return "int";
			}
		}

		public virtual bool IsReadonly
		{
			get { return isReadonly; }
			set { isReadonly = value; }
		}


		public string InitialValue
		{
			get { return initialValue; }
			set { initialValue = value; }
		}

		public bool HasInitialValue
		{
			get
			{
				return !string.IsNullOrEmpty(InitialValue);
			}
		}

		public override string GetCaption(bool getType, bool getParameters,
			bool getParameterNames, bool getInitValue)
		{
			StringBuilder builder = new StringBuilder(50);

			builder.Append(Name);
			if (getType)
				builder.AppendFormat(": {0}", Type);
			if (getInitValue && HasInitialValue)
				builder.AppendFormat(" = {0}", InitialValue);

			return builder.ToString();
		}
	}
}
