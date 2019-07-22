using System;
using System.Text;
using System.Text.RegularExpressions;

namespace NClass.Core
{
	public sealed class Property : Operation
	{
		const string AccessorAccessPattern =
			@"(protected\s+internal\s+|internal\s+|protected\s+|private\s+)";

		// [<access>] [<modifier> | static] <type> <name>["["<args>"]"] ["{"]
		// [[<getaccess>] get[;]] [[<setaccess>] set[;]] ["}"]
		const string PropertyPattern =
			@"^\s*" + CSharpAccessPattern + CSharpModifierPattern + StaticPattern +
			@"(?<type>" + SyntaxHelper.GenericTypePattern2 + @")\s+" +
			@"((?<name>" + CSharpGenericOperationNamePattern +
			@")|(?<name>this)\s*\[(?<args>.+)\])" +
			@"\s*{?\s*(?<get>(?<getaccess>" + AccessorAccessPattern + @")?get(\s*;|\s|$))?" +
			@"\s*(?<set>(?<setaccess>" + AccessorAccessPattern + @")?set(\s*;)?)?\s*}?" +
			SyntaxHelper.DeclarationEnding;

		const string NamePattern =
			@"^\s*(?<name>" + CSharpGenericOperationNamePattern + @")\s*$";

		static Regex propertyRegex = new Regex(PropertyPattern);
		static Regex nameRegex = new Regex(NamePattern, RegexOptions.ExplicitCapture);
		static Regex typeRegex = new Regex(TypePattern, RegexOptions.ExplicitCapture);

		bool isReadonly;
		bool isWriteonly;
		AccessModifier readAccess;
		AccessModifier writeAccess;

		/// <exception cref="BadSyntaxException">
		/// The <paramref name="name"/> does not fit to the syntax.
		/// </exception>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="parent"/> is null.
		/// </exception>
		internal Property(string name, OperationContainer parent) : base(name, parent)
		{
			IsReadonly = false;
			IsWriteonly = false;
			ReadAccess = AccessModifier.Default;
			WriteAccess = AccessModifier.Default;
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

		public bool IsReadonly
		{
			get
			{
				return isReadonly;
			}
			private set
			{
				if (value)
					IsWriteonly = false;
				isReadonly = value;
			}
		}

		public bool IsWriteonly
		{
			get
			{
				return isWriteonly;
			}
			private set
			{
				if (value)
					IsReadonly = false;
				isWriteonly = value;
			}
		}

		/// <exception cref="BadSyntaxException">
		/// Cannot set accessor modifier.
		/// </exception>
		public AccessModifier ReadAccess
		{
			get
			{
				return readAccess;
			}
			private set
			{
				if ((value != Access && WriteAccess == AccessModifier.Default && !IsReadonly) ||
					value == AccessModifier.Default)
				{
					readAccess = value;
				}
				else {
					throw new BadSyntaxException("error_accessor_modifier");
				}
			}
		}

		/// <exception cref="BadSyntaxException">
		/// Cannot set accessor modifier.
		/// </exception>
		public AccessModifier WriteAccess
		{
			get
			{
				return writeAccess;
			}
			private set
			{
				if ((value != Access && ReadAccess == AccessModifier.Default && !IsWriteonly) ||
					value == AccessModifier.Default)
				{
					writeAccess = value;
				}
				else if (value != AccessModifier.Default) {
					throw new BadSyntaxException("error_accessor_modifier");
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
			Match match = propertyRegex.Match(declaration);

			if (match.Success) {
				try {
					ReadAccess = AccessModifier.Default;
					WriteAccess = AccessModifier.Default;

					Group nameGroup      = match.Groups["name"];
					Group typeGroup      = match.Groups["type"];
					Group accessGroup    = match.Groups["access"];
					Group modifierGroup  = match.Groups["modifier"];
					Group staticGroup    = match.Groups["static"];
					Group argsGroup      = match.Groups["args"];
					Group getGroup       = match.Groups["get"];
					Group setGroup       = match.Groups["set"];
					Group getAccessGroup = match.Groups["getaccess"];
					Group setAccessGroup = match.Groups["setaccess"];

					Name = nameGroup.Value;
					Type = typeGroup.Value;
					AccessModifier = SyntaxHelper.ParseAccessModifier(accessGroup.Value);
					Modifier = SyntaxHelper.ParseOperationModifier(modifierGroup.Value);
					IsStatic = staticGroup.Success;
					ParameterList.InitFromString(argsGroup.Value);
					IsReadonly = getGroup.Success && !setGroup.Success;
					IsWriteonly = !getGroup.Success && setGroup.Success;
					ReadAccess = SyntaxHelper.ParseAccessModifier(getAccessGroup.Value);
					WriteAccess = SyntaxHelper.ParseAccessModifier(setAccessGroup.Value);
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
			StringBuilder builder = new StringBuilder(50);

			builder.AppendFormat(Name);
			if (getParameters) {
				if (ParameterList.Count > 0) {
					builder.Append("[");
					for (int i = 0; i < ParameterList.Count; i++) {
						builder.Append(ParameterList[i]);
						if (i < ParameterList.Count - 1)
							builder.Append(", ");
					}
					builder.Append("]");
				}

				if (IsReadonly)
					builder.Append(" { get; }");
				else if (IsWriteonly)
					builder.Append(" { set; }");
				else
					builder.Append(" { get; set; }");
			}
			if (getType)
				builder.AppendFormat(" : {0}", Type);

			return builder.ToString();
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

			builder.AppendFormat("{0} {1}", Type, Name);

			if (ParameterList.Count > 0) {
				builder.Append("[");
				for (int i = 0; i < ParameterList.Count; i++) {
					builder.Append(ParameterList[i]);
					if (i < ParameterList.Count - 1)
						builder.Append(", ");
				}
				builder.Append("]");
			}

			builder.Append(" { ");
			if (!IsWriteonly) {
				if (ReadAccess != AccessModifier.Default) {
					builder.Append(SyntaxHelper.GetAccessModifier(
						ReadAccess, Language.CSharp));
					builder.Append(" get; ");
				}
				else {
					builder.Append("get; ");
				}
			}
			if (!IsReadonly) {
				if (WriteAccess != AccessModifier.Default) {
					builder.Append(SyntaxHelper.GetAccessModifier(
						WriteAccess, Language.CSharp));
					builder.Append(" set; ");
				}
				else {
					builder.Append("set; ");
				}
			}
			builder.Append("}");

			return builder.ToString();
		}
	}
}
