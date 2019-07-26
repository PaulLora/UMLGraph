using System;
using System.Collections.Generic;

namespace NClass.Core
{
	public interface IOperationAllower : IMemberAllower
	{
		IEnumerable<Operation> Operations
		{
			get;
		}

		int OperationCount
		{
			get;
		}
	}
}
