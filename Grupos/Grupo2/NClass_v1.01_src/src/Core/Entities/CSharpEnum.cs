using System;

namespace NClass.Core
{
	internal sealed class CSharpEnum : EnumType
	{
		/// <exception cref="BadSyntaxException">
		/// The <paramref name="name"/> does not fit to the syntax.
		/// </exception>
		internal CSharpEnum(string name) : base(name)
		{
		}

		public override string Signature
		{
			get
			{
				return SyntaxHelper.GetAccessModifier(
					Access, Language.CSharp, false) + " Enum";
			}
		}

		public override Language Language
		{
			get { return Language.CSharp; }
		}
	}
}
