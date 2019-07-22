using System;
using System.Xml;

namespace NClass.Core
{
	public abstract class Entity
	{
		/// <exception cref="ArgumentNullException">
		/// <paramref name="node"/> is null.
		/// </exception>
		internal abstract void Serialize(XmlNode node);

		/// <exception cref="BadSyntaxException">
		/// An error occured in building the class.
		/// </exception>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="node"/> is null.
		/// </exception>
		internal abstract void Deserialize(XmlNode node);
	}
}
