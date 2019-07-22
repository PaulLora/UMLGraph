using System;
using System.Collections.Generic;

namespace NClass.Core
{
	public interface IOverridableType : IInheritable
	{
		InheritanceModifier Modifier
		{
			get;
			set;
		}

		/// <exception cref="ArgumentException">
		/// The language of <paramref name="value"/> does not equal.-or-
		/// The <paramref name="value"/> is descendant of the type.
		/// </exception>
		IOverridableType Base
		{
			get;
			set;
		}

		IEnumerable<Operation> OverridableOperations
		{
			get;
		}

		/// <exception cref="ArgumentException">
		/// <paramref name="operation"/> cannot be overridden.
		/// </exception>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="operation"/> is null.
		/// </exception>
		Operation Override(Operation operation);
	}
}
