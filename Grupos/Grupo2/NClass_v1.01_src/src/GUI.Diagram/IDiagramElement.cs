using System;
using System.Xml;
using System.Drawing;

namespace NClass.GUI.Diagram
{
	//TODO: ez kell?
	public interface IDiagramElement
	{
		event EventHandler SelectionChanged;
		event EventHandler ContentsChanged;
		event EventHandler Delete;

		bool IsSelected { get; set; }

		void TrySelect(Rectangle selectionRectangle);
		void Draw(Graphics g, Point position, float zoom);

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
