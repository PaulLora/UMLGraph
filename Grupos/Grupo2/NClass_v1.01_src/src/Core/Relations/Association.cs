using System;
using System.Text;
using System.Xml;

namespace NClass.Core
{
	public sealed class Association : Relation
	{
		bool isAggregation;
		bool isComposition;
		Direction direction;

		/// <exception cref="ArgumentNullException">
		/// <paramref name="first"/> is null.-or-
		/// <paramref name="second"/> is null.
		/// </exception>
		internal Association(TypeBase first, TypeBase second) : base(first, second)
		{
			IsAggregation = false;
			IsComposition = false;
			Direction = Direction.None;
		}

		public Direction Direction
		{
			get
			{
				return direction;
			}
			set
			{
				if (value == Direction.DestinationSource) {
					IsAggregation = false;
					IsComposition = false;
				}
				direction = value;
			}
		}

		public bool IsAggregation
		{
			get
			{
				return isAggregation;
			}
			set
			{
				if (value) {
					if (Direction == Direction.DestinationSource)
						Direction = Direction.None;
					IsComposition = false;
				}
				isAggregation = value;
			}
		}

		public bool IsComposition
		{
			get
			{
				return isComposition;
			}
			set
			{
				if (value) {
					if (Direction == Direction.DestinationSource)
						Direction = Direction.None;
					IsAggregation = false;
				}
				isComposition = value;
			}
		}

		/// <exception cref="ArgumentNullException">
		/// <paramref name="node"/> is null.
		/// </exception>
		internal override void Serialize(XmlNode node)
		{
			base.Serialize(node);

			XmlElement child;
			node.RemoveAll();

			child = node.OwnerDocument.CreateElement("Direction");
			child.InnerText = Direction.ToString();
			node.AppendChild(child);
			
			child = node.OwnerDocument.CreateElement("IsAggregation");
			child.InnerText = IsAggregation.ToString();
			node.AppendChild(child);

			child = node.OwnerDocument.CreateElement("IsComposition");
			child.InnerText = IsComposition.ToString();
			node.AppendChild(child);
		}

		/// <exception cref="ArgumentNullException">
		/// <paramref name="node"/> is null.
		/// </exception>
		internal override void Deserialize(XmlNode node)
		{
			base.Deserialize(node);

			XmlElement child = node["Direction"];

			if (child != null) {
				try {
					Direction = (Direction) Enum.Parse(
						typeof(Direction), child.InnerText, true);
				}
				catch (ArgumentException) {
					// Wrong format
				}
			}

			try {
				child = node["IsAggregation"];
				if (child != null)
					IsAggregation = bool.Parse(child.InnerText);

				child = node["IsComposition"];
				if (child != null)
					IsComposition = bool.Parse(child.InnerText);
			}
			catch (ArgumentException) {
				// Wrong format
			}
		}

		public override string ToString()
		{
			StringBuilder builder = new StringBuilder(50);

			if (IsAggregation)
				builder.Append("aggregation");
			else if (IsComposition)
				builder.Append("composition");
			else
				builder.Append("association");
			builder.Append(": ");
			builder.Append(First);

			switch (Direction) {
				case Direction.None:
					if (IsAggregation)
						builder.Append(" <>-- ");
					else if (IsComposition)
						builder.Append(" #-- ");
					else
						builder.Append(" --- ");
					break;
				case Direction.SourceDestination:
					if (IsAggregation)
						builder.Append(" <>-> ");
					else if (IsComposition)
						builder.Append(" #-> ");
					else
						builder.Append(" --> ");
					break;
				case Direction.DestinationSource:
					builder.Append(" <-- ");
					break;
				default:
					builder.Append(", ");
					break;
			}
			builder.Append(Second);

			return builder.ToString();
		}
	}
}
