using System;
using System.Collections.Generic;

namespace NClass.Core
{
	public interface IFieldAllower : IMemberAllower
	{
		IEnumerable<Field> Fields
		{
			get;
		}

		int FieldCount
		{
			get;
		}

		/// <exception cref="BadSyntaxException">
		/// The <paramref name="name"/> does not fit to the syntax.
		/// </exception>
		Field AddField(string name);
	}
}
