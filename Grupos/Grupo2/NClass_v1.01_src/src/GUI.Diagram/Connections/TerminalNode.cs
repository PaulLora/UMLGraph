using System;
using System.Xml;
using System.Drawing;
using NClass.Core;

namespace NClass.GUI.Diagram
{
	internal class TerminalNode
	{
		EntityShape shape;
		int location = 0;
		bool isHorizontal = false;
		bool isDirty = false;

		internal TerminalNode()
		{
			shape = null;
		}

		/// <exception cref="ArgumentNullException">
		/// <paramref name="shape"/> is null.
		/// </exception>
		internal TerminalNode(EntityShape shape)
		{
			if (shape == null)
				throw new ArgumentNullException("shape");
			
			this.shape = shape;
			AddThisToShape(shape);
		}

		/// <exception cref="ArgumentNullException">
		/// <paramref name="shape"/> is null.
		/// </exception>
		internal TerminalNode(EntityShape shape, Point mouseLocation) : this(shape)
		{
			SetPosition(mouseLocation);
		}

		public EntityShape Shape
		{
			get
			{
				return shape;
			}
			set
			{
				if (value != shape) {
					RemoveThisFromShape(shape);
					AddThisToShape(value);
					shape = value;
					location = 0;
				}
			}
		}

		public int RelativeLocation
		{
			get
			{
				return location;
			}
			set
			{
				if (value >= 0) {
					location = value;
					IsDirty = true;
				}
			}
		}

		public int AbsoluteLocation
		{
			get
			{
				if (Shape != null) {
					if (IsVertical)
						return RelativeLocation + Shape.Left;
					else
						return RelativeLocation + Shape.Top;
				}
				else {
					return 0;
				}
			}
		}

		public bool IsHorizontal
		{
			get { return isHorizontal; }
		}

		public bool IsVertical
		{
			get { return !isHorizontal; }
		}

		public bool IsDirty
		{
			get { return isDirty; }
			set { isDirty = value; }
		}

		private void AddThisToShape(EntityShape shape)
		{
			if (shape != null && !shape.TerminalNodes.Contains(this))
				shape.TerminalNodes.Add(this);
			IsDirty = true;
		}

		private void RemoveThisFromShape(EntityShape shape)
		{
			if (shape != null && shape.TerminalNodes.Contains(this))
				shape.TerminalNodes.Remove(this);
		}

		public bool SetPosition(Point mouseLocation)
		{
			if (Shape == null)
				return false;

			bool column = (mouseLocation.X >= Shape.Left && mouseLocation.X < Shape.Right);
			bool row = (mouseLocation.Y >= Shape.Top && mouseLocation.Y < Shape.Bottom);
			int oldLocation = location;

			if (column && row) {
				if (IsVertical)
					location = mouseLocation.X - Shape.Left;
				else
					location = mouseLocation.Y - Shape.Top;
			}
			else if (column) {
				isHorizontal = false;
				location = mouseLocation.X - Shape.Left;
			}
			else if (row) {
				isHorizontal = true;
				location = mouseLocation.Y - Shape.Top;
			}
			else {
				if (IsVertical) {
					if (mouseLocation.X < Shape.Left)
						location = 0;
					else
						location = Shape.Width - 1;
				}
				// IsHorizontal
				else {
					if (mouseLocation.Y < Shape.Top)
						location = 0;
					else
						location = Shape.Height - 1;
				}
			}

			if (location != oldLocation)
				IsDirty = true;

			return (location != oldLocation);
		}

		/// <exception cref="ArgumentNullException">
		/// <paramref name="node"/> is null.
		/// </exception>
		public void Deserialize(XmlElement node)
		{
			if (node == null)
				throw new ArgumentNullException("node");

			bool.TryParse(node.GetAttribute("isHorizontal"), out isHorizontal);
			int.TryParse(node.GetAttribute("location"), out location);
			IsDirty = true;
		}

		/// <exception cref="ArgumentNullException">
		/// <paramref name="node"/> is null.
		/// </exception>
		public void Serialize(XmlElement node)
		{
			if (node == null)
				throw new ArgumentNullException("node");

			node.SetAttribute("isHorizontal", isHorizontal.ToString());
			node.SetAttribute("location", location.ToString());
		}
	}
}
