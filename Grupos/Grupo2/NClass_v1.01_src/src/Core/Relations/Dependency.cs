using System;
using System.Xml;

namespace NClass.Core
{
	public sealed class Dependency : Relation
	{
		/// <exception cref="ArgumentNullException">
		/// <paramref name="first"/> is null.-or-
		/// <paramref name="second"/> is null.
		/// </exception>
		internal Dependency(TypeBase first, TypeBase second) : base(first, second)
		{
		}

		public override string ToString()
		{
			return string.Format("{0}: {1} --> {3}",
				"dependency", First, Second);
		}
	}
}
