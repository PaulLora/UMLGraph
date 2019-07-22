using System;

namespace NClass.Core
{
	public interface IInheritable
	{
		bool IsAllowedParent
		{
			get;
		}

		bool IsAllowedChild
		{
			get;
		}

		bool HasBase
		{
			get;
		}
	}
}
