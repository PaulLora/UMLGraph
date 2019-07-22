using System;

namespace NClass.Core
{
	public sealed class Generalization : Relation
	{
		/// <exception cref="ArgumentException">
		/// Cannot create <see cref="Generalization"/> between 
		/// <paramref name="derivedClass"/> and <paramref name="baseClass"/>.
		/// </exception>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="first"/> is null.-or-
		/// <paramref name="second"/> is null.
		/// </exception>
		internal Generalization(TypeBase derivedClass, TypeBase baseClass)
			: base(derivedClass, baseClass)
		{
			if (!(derivedClass is IInheritable) || !((IInheritable) derivedClass).IsAllowedChild)
				throw new ArgumentException("Cannot be child class.", "derivedClass");
			if (!(baseClass is IInheritable) || !((IInheritable) baseClass).IsAllowedParent)
				throw new ArgumentException("Cannot be base class.", "baseClass");
			if (derivedClass.GetType() != baseClass.GetType())
				throw new ArgumentException("Classes are not the same type.");
			if (derivedClass == baseClass)
				throw new ArgumentException("Cannot inherit from the same class.");
			if (derivedClass is ClassType && ((ClassType) derivedClass).HasBase)
				throw new ArgumentException("Cannot have multiple bases.");
			if (baseClass.Parent == derivedClass) //TODO: nem Parent, Ancestor()
				throw new ArgumentException("Nested class cannot be base class.");
			if (baseClass.Language == Language.CSharp && derivedClass.Parent == baseClass)
				throw new ArgumentException("Nested class cannot be child class.");
		}

		public override string ToString()
		{
			return string.Format("{0}: {1} --> {2}",
				"generalization", First, Second);
		}
	}
}
