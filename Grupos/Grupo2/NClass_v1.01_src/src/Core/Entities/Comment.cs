using System;
using System.Xml;

namespace NClass.Core
{
	public sealed class Comment : Entity
	{
		string text;

		internal Comment() : base()
		{
		}
	
		public String Text
		{
			get { return text; }
			set { text = value; }
		}

		/// <exception cref="ArgumentNullException">
		/// <paramref name="node"/> is null.
		/// </exception>
		internal override void Serialize(XmlNode node)
		{
			if (node == null)
				throw new ArgumentNullException("node");

			node.RemoveAll();
			XmlElement child = node.OwnerDocument.CreateElement("Text");
			child.InnerText = Text;
			node.AppendChild(child);
		}

		/// <exception cref="BadSyntaxException">
		/// An error occured in building the class.
		/// </exception>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="node"/> is null.
		/// </exception>
		internal override void Deserialize(XmlNode node)
		{
			if (node == null)
				throw new ArgumentNullException("node");

			XmlElement textNode = node["Text"];

			if (textNode != null)
				Text = textNode.InnerText;
			else
				Text = null;
		}

		public override string ToString()
		{
			const int MaxLength = 50;

			if (Text.Length > MaxLength)
				return '"' + Text.Substring(0, MaxLength) + "...\"";
			else
				return '"' + Text + '"';
		}
	}
}
