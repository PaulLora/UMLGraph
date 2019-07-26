using System;

namespace NClass.Core
{
	public interface IMethodAllower : IOperationAllower
	{
		/// <exception cref="BadSyntaxException">
		/// The <paramref name="name"/> does not fit to the syntax.
		/// </exception>
		Method AddMethod(string name);
	}
}
