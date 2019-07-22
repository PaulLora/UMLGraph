using System;
using System.Collections.Generic;

namespace NClass.Core
{
	public interface IInterfaceImplementer : IOperationAllower
	{
		IEnumerable<InterfaceType> Interfaces
		{
			get;
		}

		bool ImplementsInterface
		{
			get;
		}

		/// <exception cref="ArgumentException">
		/// The language of <paramref name="operation"/> does not equal.
		/// </exception>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="operation"/> is null.
		/// </exception>
		Operation Implement(Operation operation);

		/// <exception cref="ArgumentException">
		/// The language of <paramref name="interfaceType"/> does not equal.-or-
		/// <paramref name="interfaceType"/> is earlier implemented interface.
		/// </exception>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="interfaceType"/> is null.
		/// </exception>
		void AddInterface(InterfaceType interfaceType);

		void RemoveInterface(InterfaceType interfaceType);
	}
}
