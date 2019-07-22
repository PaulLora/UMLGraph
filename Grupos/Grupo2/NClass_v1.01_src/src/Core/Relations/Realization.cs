using System;

namespace NClass.Core
{
	public sealed class Realization : Relation
	{
		/// <exception cref="ArgumentException">
		/// Cannot create <see cref="Realization"/> between 
		/// <paramref name="derived"/> and <paramref name="baseClass"/>.
		/// </exception>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="first"/> is null.-or-
		/// <paramref name="second"/> is null.
		/// </exception>
		internal Realization(TypeBase derived, InterfaceType baseClass)
			: base(derived, baseClass)
		{
			if (!(derived is IInterfaceImplementer))
				throw new ArgumentException("Derived class cannot implement the interface.");
		}

		public override string ToString()
		{
			return string.Format("{0}: {1} --> {2}",
				"realization", First, Second);
		}
	}
}
