using System;

namespace NClass.Core
{
	public enum OperationModifier
	{
		None,

		/// <summary>
		/// Abstract members must be implemented by classes
		/// that derive from the abstract class.
		/// </summary>
		Abstract,

		/// <summary>
		/// Provides a new implementation of a virtual member
		/// inherited from a base class.
		/// </summary>
		Override,

		/// <summary>
		/// Declares a method whose implementation can be changed by an 
		/// overriding member in a derived class.
		/// </summary>
		Virtual,

		/// <summary>
		/// A sealed method overrides a method in a base class,
		/// but itself cannot be overridden further in any derived class.
		/// </summary>
		Sealed
	}
}
