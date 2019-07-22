using System;

namespace NClass.Core
{
	public static class SyntaxHelper
	{
		#region Regex patterns

		/// <example></example>
		internal const string InitialChar = @"[\p{Ll}\p{Lu}\p{Lt}\p{Lo}\p{Pc}\p{Lm}]";
		internal const string DeclarationEnding = @"\s*(;\s*)?$";

		// System.String
		private  const string TypeNamePattern = InitialChar + @"(\w|\." + InitialChar + @")*";
		// System.String[]
		internal const string BaseTypePattern = TypeNamePattern + @"(\s*\[\s*\])?";
		// <System.String[], System.String[]>
		private  const string GenericPattern =
			@"<\s*" + BaseTypePattern + @"(\s*,\s*" + BaseTypePattern + @")*\s*>";
		// System.Collections.Generic.List<System.String[], System.String[]>[]
		internal const string GenericTypePattern =
			TypeNamePattern + @"(\s*" + GenericPattern + @")?(\s*\[\s*\])?";
		// <List<int>[], List<string>>
		private  const string GenericPattern2 =
			@"<\s*" + GenericTypePattern + @"(\s*,\s*" + GenericTypePattern + @")*\s*>";
		// System.Collections.Generic.List<List<int>[]>[]
		internal const string GenericTypePattern2 =
			TypeNamePattern + @"(\s*" + GenericPattern2 + @")?(\s*\[\s*\])?";

		// Method
		internal const string NamePattern = InitialChar + @"\w*";
		// <T, K>
		private  const string BaseGenericPattern =
			@"<\s*" + NamePattern + @"(\s*,\s*" + NamePattern + @")*\s*>";
		// Method<T>
		internal const string GenericNamePattern =
			NamePattern + @"(\s*" + BaseGenericPattern + ")?";

		#endregion

		#region Reserved names

		static readonly string[] ReservedCSharpNames = {
			"abstract", "as", "base", "break", "case", "catch", "checked", "class", 
			"const", "continue", "default", "delegate", "do", "else", "enum", "event", 
			"explicit", "extern", "false", "finally", "fixed", "for", "foreach", "goto", 
			"if", "implicit", "in", "interface", "internal", "is", "lock", "long", 
			"namespace", "new", "null", "operator", "out", "override", "params", 
			"private", "protected", "public", "readonly", "ref", "return", "sealed", 
			"sizeof", "stackalloc", "static", "struct", "switch", "this", "throw", 
			"true", "try", "typeof", "unchecked", "unsafe", "using", "virtual", 
			"volatile", "while"			
		};

		static readonly string[] CSharpTypeKeywords = {
			"bool", "byte", "char", "decimal", "double", "float", "int", "object", 
			"sbyte", "short", "string", "uint", "ulong", "ushort", "void"
		};

		static readonly string[] ReservedJavaNames = {
			"abstract", "assert", "break","case", "catch", "class", "const", "continue", 
			"default", "do", "else", "enum", "extends", "false", "final", "finally", 
			"for", "goto", "if", "implements", "import", "instanceof", "interface", 
			"native", "new", "null", "package", "private", "protected", "public", 
			"return", "static", "strictfp", "super", "switch", "synchronized", "this", 
			"throw", "throws", "transient", "true", "try", "volatile", "while"
		};

		static readonly string[] JavaTypeKeywords = {
			"boolean", "byte", "char", "double", "float", "int", "long", "short", "void"
		};

		#endregion

		private static bool Contains(string[] values, string value)
		{
			if (values == null)
				return false;

			for (int i = 0; i < values.Length; i++)
				if (values[i] == value)
					return true;

			return false;
		}

		/// <exception cref="BadSyntaxException">
		/// The <paramref name="name"/> does not fit to the syntax.
		/// </exception>
		internal static bool IsForbiddenName(string name, Language language)
		{
			if (language == Language.CSharp) {
				if (Contains(ReservedCSharpNames, name) || Contains(CSharpTypeKeywords, name))
					return true;
			}
			else {
				if (Contains(ReservedJavaNames, name) || Contains(JavaTypeKeywords, name))
					return true;
			}
			return false;
		}

		/// <exception cref="BadSyntaxException">
		/// The <paramref name="name"/> does not fit to the syntax.
		/// </exception>
		internal static bool IsForbiddenTypeName(string name, Language language)
		{
			if (language == Language.CSharp) {
				if (Contains(ReservedCSharpNames, name))
					return true;
			}
			else {
				if (Contains(ReservedJavaNames, name))
					return true;
			}
			return false;
		}

		internal static AccessModifier ParseAccessModifier(string value)
		{
			try {
				if (string.IsNullOrEmpty(value))
					return AccessModifier.Default;
				else if (value == "package")
					return AccessModifier.Internal;
				else if (value.Contains("protected") && value.Contains("internal"))
					return AccessModifier.ProtectedInternal;
				else
					return (AccessModifier) Enum.Parse(typeof(AccessModifier), value, true);
			}
			catch {
				return AccessModifier.Default;
			}
		}

		internal static string GetAccessModifier(AccessModifier access, Language language)
		{
			return GetAccessModifier(access, language, true);
		}

		public static string GetAccessModifier(AccessModifier access,
			Language language, bool forCode)
		{
			if (language == Language.CSharp) {
				switch (access) {
					case AccessModifier.ProtectedInternal:
						if (forCode)
							return "protected internal";
						else
							return "Protected Internal";

					case AccessModifier.Default:
						if (forCode)
							return "";
						else
							return "Default";

					default:
						if (forCode)
							return access.ToString().ToLower();
						else
							return access.ToString();
				}
			}
			else {
				switch (access) {
					case AccessModifier.Default:
						if (forCode)
							return "";
						else
							return "Default";

					default:
						if (forCode)
							return access.ToString().ToLower();
						else
							return access.ToString();
				}
			}
		}

		internal static OperationModifier ParseOperationModifier(string value)
		{
			try {
				if (string.IsNullOrEmpty(value)) {
					return OperationModifier.None;
				}
				else if (value == "final" || value.Contains("sealed")) {
					return OperationModifier.Sealed;
				}
				else {
					return (OperationModifier) Enum.Parse(
						typeof(OperationModifier), value, true);
				}
			}
			catch {
				return OperationModifier.None;
			}
		}

		internal static string GetOperationModifier(OperationModifier modifier, Language language)
		{
			return GetOperationModifier(modifier, language, true);
		}
		
		public static string GetOperationModifier(OperationModifier modifier,
			Language language, bool forCode)
		{
			if (modifier == OperationModifier.None) {
				if (forCode)
					return "";
				else
					return "None";
			}

			if (language == Language.Java && modifier == OperationModifier.Sealed) {
				if (forCode)
					return "final";
				else
					return "Final";
			}
			else if (language == Language.CSharp && modifier == OperationModifier.Sealed) {
				if (forCode)
					return "sealed override";
				else
					return "Sealed";
			}

			if (forCode)
				return modifier.ToString().ToLower();
			else
				return modifier.ToString();
		}

		internal static InheritanceModifier ParseClassModifier(string value)
		{
			try {
				return (InheritanceModifier) Enum.Parse(
					typeof(InheritanceModifier), value, true);
			}
			catch {
				return InheritanceModifier.None;
			}
		}

		internal static ParameterModifier ParseParameterModifier(string value)
		{
			try {
				return (ParameterModifier) Enum.Parse(typeof(ParameterModifier), value, true);
			}
			catch {
				return ParameterModifier.None;
			}
		}
	}
}
