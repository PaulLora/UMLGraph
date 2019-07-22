using System;

namespace NClass.Core
{
	public interface IEventAllower : IOperationAllower
	{
		/// <exception cref="BadSyntaxException">
		/// The <paramref name="name"/> does not fit to the syntax.
		/// </exception>
		Event AddEvent(string name);
	}
}
