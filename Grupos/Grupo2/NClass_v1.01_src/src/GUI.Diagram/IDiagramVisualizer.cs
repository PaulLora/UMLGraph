using System;
using System.Xml;
using System.Drawing;
using NClass.Core;

namespace NClass.GUI.Diagram
{
	public interface IDiagramVisualizer
	{
		event EventHandler ContentsChanged;
		event EntityRemovedEventHandler EntityRemoved;
		event RelationRemovedEventHandler RelationRemoved;
		event ConnectionCreatedEventHandler ConnectionCreated;

		void Clear();

		/// <exception cref="ArgumentException">
		/// There is no type of <paramref name="entity"/>.
		/// </exception>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="entity"/> is null.
		/// </exception>
		void AddEntity(Entity entity);

		/// <exception cref="ArgumentException">
		/// There is no type of <paramref name="relation"/>.
		/// </exception>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="relation"/> is null.
		/// </exception>
		void AddRelation(Relation relation, bool fromScreen);

		void LoadingFinished();

		/// <exception cref="ArgumentNullException">
		/// <paramref name="node"/> is null.
		/// </exception>
		void Serialize(XmlNode node);

		/// <exception cref="ArgumentNullException">
		/// <paramref name="node"/> is null.
		/// </exception>
		void Deserialize(XmlNode node);
	}
}
