using System;

namespace NClass.Core
{
	public sealed class Nesting : Relation
	{
		/// <exception cref="ArgumentException">
		/// Cannot create <see cref="Nesting"/> between 
		/// <paramref name="parentClass"/> and <paramref name="nestedType"/>.
		/// </exception>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="first"/> is null.-or-
		/// <paramref name="second"/> is null.
		/// </exception>
		internal Nesting(FieldContainer parentClass, TypeBase nestedType)
			: base(parentClass, nestedType)
		{
			if (parentClass == nestedType)
				throw new ArgumentException("The class cannot contain itself.");
			if (parentClass is ClassType && ((ClassType) parentClass).Base == nestedType)
				throw new ArgumentException("Nested class cannot be base class.");
			if (parentClass.Language == Language.CSharp && nestedType is ClassType &&
				((ClassType) nestedType).Base == parentClass)
			{
				throw new ArgumentException("Nested class cannot be child class.");
			}
			if (nestedType.IsNested) {
				throw new ArgumentException(
					"Nested types cannot have multiple parents.", "nestedType");
			}
		}

		public override string ToString()
		{
			return string.Format("{0}: {1} (+)--> {2}",
				"nesting", First, Second);
		}
	}
}
