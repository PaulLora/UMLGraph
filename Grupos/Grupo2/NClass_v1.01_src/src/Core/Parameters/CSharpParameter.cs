
namespace NClass.Core
{
	internal sealed class CSharpParameter : Parameter
	{
		const string ParameterPattern =
			@"\s*(?<modifier>out|ref|params)?(?(modifier)\s+|)" +
			@"(?<type>" + SyntaxHelper.GenericTypePattern2 + @")\s+" +
			@"(?<name>" + SyntaxHelper.NamePattern + @")\s*(,|$)";

		/// <exception cref="BadSyntaxException">
		/// The <paramref name="name"/> or <paramref name="type"/> 
		/// does not fit to the syntax.
		/// </exception>
		internal CSharpParameter(string name, string type, ParameterModifier modifier)
			: base(name, type, modifier)
		{
		}

		public override Language Language
		{
			get { return Language.CSharp; }
		}
	}
}
