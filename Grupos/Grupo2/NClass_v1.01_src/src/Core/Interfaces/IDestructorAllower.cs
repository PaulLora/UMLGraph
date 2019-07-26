using System;

namespace NClass.Core
{
	public interface IDestructorAllower : IOperationAllower
	{
		bool CanAddDestructor
		{
			get;
		}

		Method AddDestructor();
	}
}
