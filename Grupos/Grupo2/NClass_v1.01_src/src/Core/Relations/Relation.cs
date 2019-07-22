using System;
using System.Xml;

namespace NClass.Core
{
	public abstract class Relation
	{
		Entity first;
		Entity second;

		/// <exception cref="ArgumentNullException">
		/// <paramref name="first"/> is null.-or-
		/// <paramref name="second"/> is null.
		/// </exception>
		protected Relation(Entity first, Entity second)
		{
			if (first == null)
				throw new ArgumentNullException("first");
			if (second == null)
				throw new ArgumentNullException("second");

			this.first = first;
			this.second = second;
		}

		public Entity First
		{
			get { return first; }
		}

		public Entity Second
		{
			get { return second; }
		}

		/// <exception cref="ArgumentNullException">
		/// <paramref name="node"/> is null.
		/// </exception>
		internal virtual void Serialize(XmlNode node)
		{
			if (node == null)
				throw new ArgumentNullException("node");
		}

		/// <exception cref="ArgumentNullException">
		/// <paramref name="node"/> is null.
		/// </exception>
		internal virtual void Deserialize(XmlNode node)
		{
			if (node == null)
				throw new ArgumentNullException("node");
		}
	}
}
