using System;

namespace NClass.Core
{
	public interface IConstructorAllower : IOperationAllower
	{
		bool CanAddConstructor
		{
			get;
		}

		Method AddConstructor();
	}
}
