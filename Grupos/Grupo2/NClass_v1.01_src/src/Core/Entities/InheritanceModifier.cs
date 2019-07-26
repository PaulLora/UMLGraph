using System;

namespace NClass.Core
{
	public enum InheritanceModifier
	{
		None,

		/// <summary>
		/// Indicates that a class is intended only to be a base class of other classes.
		/// </summary>
		Abstract,

		/// <summary>
		/// Specifies that a class cannot be inherited.
		/// </summary>
		Sealed,

		/// <summary>
		/// Indicates that a class contains only static members.
		/// </summary>
		Static
	}
}
