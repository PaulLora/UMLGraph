using System;

namespace NClass.Core
{
	public interface IPropertyAllower : IOperationAllower
	{
		/// <exception cref="BadSyntaxException">
		/// The <paramref name="name"/> does not fit to the syntax.
		/// </exception>
		Property AddProperty(string name);
	}
}
