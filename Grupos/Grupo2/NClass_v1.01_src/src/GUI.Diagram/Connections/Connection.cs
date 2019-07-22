using System;
using System.Xml;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections.Generic;
using NClass.Core;

namespace NClass.GUI.Diagram
{
	internal abstract class Connection : IDiagramElement
	{
		public const int MarginSize = 22;
		const int MaxNodeCount = 5;
		const int PrecisionSize = 2;

		static Pen linePen = new Pen(Color.Black);
		static Pen solidPen = new Pen(Color.Black);
		static SolidBrush lightBrush = new SolidBrush(Color.White);
		static SolidBrush darkBrush = new SolidBrush(Color.Black);
		static float[] dashPattern = { 5, 5 };

		TerminalNode startNode;
		TerminalNode endNode;
		bool isSelected = false;
		Point[] nodes = new Point[MaxNodeCount];
		int nodeCount;
		
		public event EventHandler ContentsChanged;
		public event EventHandler SelectionChanged;
		public event EventHandler Delete; 

		/// <exception cref="ArgumentNullException">
		/// <paramref name="startNode"/>is null.-or-
		/// <paramref name="endNode"/> is null.
		/// </exception>
		protected Connection(TerminalNode startNode, TerminalNode endNode)
		{
			if (startNode == null)
				throw new ArgumentNullException("startNode");
			if (endNode == null)
				throw new ArgumentNullException("endNode");

			this.startNode = startNode;
			this.endNode = endNode;
		}

		public TerminalNode StartNode
		{
			get { return startNode; }
		}

		public TerminalNode EndNode
		{
			get { return endNode; }
		}

		public bool IsSelected
		{
			get
			{
				return isSelected;
			}
			set
			{
				if (value != isSelected) {
					isSelected = value;
					OnSelectionChanged(EventArgs.Empty);
				}
				else {
					isSelected = value;
				}
			}
		}

		protected static Pen LinePen
		{
			get { return linePen; }
		}

		protected static Pen SolidPen
		{
			get { return solidPen; }
		}

		protected static SolidBrush LightBrush
		{
			get { return lightBrush; }
		}

		protected static SolidBrush DarkBrush
		{
			get { return darkBrush; }
		}

		protected virtual bool Dashed
		{
			get { return false; }
		}

		public abstract Relation Relation { get; }

		private void CalculateNodes()
		{
			if (StartNode.Shape != null && EndNode.Shape != null &&
				(StartNode.IsDirty || EndNode.IsDirty))
			{
				if (StartNode.IsHorizontal == EndNode.IsHorizontal)
					ParallelCalculation();
				else
					PerpendicularCalculation();

				StartNode.IsDirty = false;
				EndNode.IsDirty = false;
			}
		}

		private void ParallelCalculation()
		{
			if (startNode.Shape == null || endNode.Shape == null)
				return;

			EntityShape startShape = StartNode.Shape;
			EntityShape endShape = EndNode.Shape;

			nodeCount = 4;

			if (StartNode.IsVertical) {
				nodes[0].X = nodes[1].X = StartNode.AbsoluteLocation;
				nodes[2].X = nodes[3].X = EndNode.AbsoluteLocation;

				if (endShape.Top - startShape.Bottom >= 2 * MarginSize ||
					startShape.Top - endShape.Bottom >= 2 * MarginSize)
				{
					if (startShape.Top < endShape.Top) {
						int semiLength = (endShape.Top - startShape.Bottom) / 2;

						nodes[0].Y = startShape.Bottom;
						nodes[1].Y = startShape.Bottom + semiLength;
						nodes[2].Y = startShape.Bottom + semiLength;
						nodes[3].Y = endShape.Top - 1;
					}
					else {
						int semiLength = (startShape.Top - endShape.Bottom) / 2;

						nodes[0].Y = startShape.Top - 1;
						nodes[1].Y = endShape.Bottom + semiLength;
						nodes[2].Y = endShape.Bottom + semiLength;
						nodes[3].Y = endShape.Bottom;
					}
				}
				else {
					EntityShape bottomShape = (startShape.Top < endShape.Top) ?
						endShape : startShape;

					nodes[0].Y = startShape.Bottom;
					nodes[1].Y = bottomShape.Bottom + MarginSize;
					nodes[2].Y = bottomShape.Bottom + MarginSize;
					nodes[3].Y = endShape.Bottom;
				}
			}
			else { // Horizontal
				nodes[0].Y = nodes[1].Y = StartNode.AbsoluteLocation;
				nodes[2].Y = nodes[3].Y = EndNode.AbsoluteLocation;

				if (endShape.Left - startShape.Right >= 2 * MarginSize ||
					startShape.Left - endShape.Right >= 2 * MarginSize)
				{
					if (startShape.Left < endShape.Left) {
						int semiLength = (endShape.Left - startShape.Right) / 2;

						nodes[0].X = startShape.Right;
						nodes[1].X = startShape.Right + semiLength;
						nodes[2].X = startShape.Right + semiLength;
						nodes[3].X = endShape.Left - 1;
					}
					else {
						int semiLength = (startShape.Left - endShape.Right) / 2;

						nodes[0].X = startShape.Left - 1;
						nodes[1].X = endShape.Right + semiLength;
						nodes[2].X = endShape.Right + semiLength;
						nodes[3].X = endShape.Right;
					}
				}
				else {
					EntityShape rightShape = (startShape.Left < endShape.Left) ?
						endShape : startShape;

					nodes[0].X = startShape.Right;
					nodes[1].X = rightShape.Right + MarginSize;
					nodes[2].X = rightShape.Right + MarginSize;
					nodes[3].X = endShape.Right;
				}
			}
		}

		private void PerpendicularCalculation()
		{
			if (startNode.Shape == null || endNode.Shape == null)
				return;

			EntityShape startShape = StartNode.Shape;
			EntityShape endShape = EndNode.Shape;

			if (StartNode.IsVertical) {
				nodes[0].X = StartNode.AbsoluteLocation;

				if ((StartNode.AbsoluteLocation < endShape.Left - MarginSize ||
					StartNode.AbsoluteLocation >= endShape.Right + MarginSize) &&
					(EndNode.AbsoluteLocation < startShape.Top - MarginSize ||
					EndNode.AbsoluteLocation >= startShape.Bottom + MarginSize))
				{
					nodeCount = 3;

					if (startShape.Top < endShape.Top)
						nodes[0].Y = startShape.Bottom;
					else
						nodes[0].Y = startShape.Top - 1;

					if (startShape.Left < endShape.Left)
						nodes[2].X = endShape.Left - 1;
					else
						nodes[2].X = endShape.Right;

					nodes[1] = new Point(StartNode.AbsoluteLocation, EndNode.AbsoluteLocation);
					nodes[2].Y = EndNode.AbsoluteLocation;
				}
				else {
					Point connector = new Point();
					bool vertical = StartNode.AbsoluteLocation >= endShape.Left - MarginSize &&
						StartNode.AbsoluteLocation < endShape.Right + MarginSize;
	 
					nodeCount = 5;

					if (StartNode.AbsoluteLocation < (endShape.Left + endShape.Right) / 2 &&
						vertical || (!vertical && endShape.Left > startShape.Left))
					{
						connector.X = endShape.Left - MarginSize - 1;
						nodes[4].X = endShape.Left - 1;
					}
					else {
						connector.X = endShape.Right + MarginSize;
						nodes[4].X = endShape.Right;
					}

					if (EndNode.AbsoluteLocation < (startShape.Top + startShape.Bottom) / 2 &&
						!vertical || (vertical && startShape.Top >= endShape.Top))
					{
						connector.Y = startShape.Top - MarginSize - 1;
						nodes[0].Y = startShape.Top - 1;
					}
					else {
						connector.Y = startShape.Bottom + MarginSize;
						nodes[0].Y = startShape.Bottom;
					}

					nodes[1] = new Point(StartNode.AbsoluteLocation, connector.Y);
					nodes[2] = connector;
					nodes[3] = new Point(connector.X, EndNode.AbsoluteLocation);
					nodes[4].Y = EndNode.AbsoluteLocation;
				}
			}
			else { // startNode.IsHorizontal
				nodes[0].Y = StartNode.AbsoluteLocation;

				if ((StartNode.AbsoluteLocation < endShape.Top - MarginSize ||
					StartNode.AbsoluteLocation >= endShape.Bottom + MarginSize) &&
					(EndNode.AbsoluteLocation < startShape.Left - MarginSize ||
					EndNode.AbsoluteLocation >= startShape.Right + MarginSize))
				{
					nodeCount = 3;

					if (startShape.Left < endShape.Left)
						nodes[0].X = startShape.Right;
					else
						nodes[0].X = startShape.Left - 1;

					if (startShape.Top < endShape.Top)
						nodes[2].Y = endShape.Top - 1;
					else
						nodes[2].Y = endShape.Bottom;

					nodes[1] = new Point(EndNode.AbsoluteLocation, StartNode.AbsoluteLocation);
					nodes[2].X = EndNode.AbsoluteLocation;
				}
				else {
					Point connector = new Point();
					bool horizontal = StartNode.AbsoluteLocation >= endShape.Top - MarginSize &&
						StartNode.AbsoluteLocation < endShape.Bottom + MarginSize;
	 
					nodeCount = 5;

					if (StartNode.AbsoluteLocation < (endShape.Top + endShape.Bottom) / 2 &&
						horizontal || (!horizontal && endShape.Top > startShape.Top))
					{
						connector.Y = endShape.Top - MarginSize - 1;
						nodes[4].Y = endShape.Top - 1;
					}
					else {
						connector.Y = endShape.Bottom + MarginSize;
						nodes[4].Y = endShape.Bottom;
					}

					if (EndNode.AbsoluteLocation < (startShape.Left + startShape.Right) / 2 &&
						!horizontal || (horizontal && startShape.Left >= endShape.Left))
					{
							connector.X = startShape.Left - MarginSize - 1;
							nodes[0].X = startShape.Left - 1;
					}
					else {
							connector.X = startShape.Right + MarginSize;
							nodes[0].X = startShape.Right;
					}

					nodes[1] = new Point(connector.X, StartNode.AbsoluteLocation);
					nodes[2] = connector;
					nodes[3] = new Point(EndNode.AbsoluteLocation, connector.Y);
					nodes[4].X = EndNode.AbsoluteLocation;
				}
			}
		}

		public bool CanSelect(Rectangle selectionRectangle)
		{
			if (StartNode.Shape == null || EndNode.Shape == null)
				return false;

			for (int i = 0; i < nodeCount - 1; i++) {
				if (Intersects(selectionRectangle, nodes[i], nodes[i + 1]))
					return true;
			}
			return false;
		}

		public bool CanSelect(Point mouseLocation)
		{
			if (StartNode.Shape == null || EndNode.Shape == null)
				return false;

			for (int i = 0; i < nodeCount - 1; i++) {
				if (Intersects(mouseLocation, nodes[i], nodes[i + 1]))
					return true;
			}
			return false;
		}

		public TerminalNode GetTerminalNode(Point mouseLocation)
		{
			if (!CanSelect(mouseLocation))
				return null;

			if (StartNode.IsHorizontal && 
				Math.Abs(nodes[0].X - mouseLocation.X) <= MarginSize
				||
				StartNode.IsVertical &&
				Math.Abs(nodes[0].Y - mouseLocation.Y) <= MarginSize)
			{
				return StartNode;
			}

			if (EndNode.IsHorizontal && 
				Math.Abs(nodes[nodeCount - 1].X - mouseLocation.X) <= MarginSize
				||
				EndNode.IsVertical &&
				Math.Abs(nodes[nodeCount - 1].Y - mouseLocation.Y) <= MarginSize)
			{
				return EndNode;
			}

			return null;
		}

		public void TrySelect(Rectangle selectionRectangle)
		{
			if (CanSelect(selectionRectangle))
				IsSelected = true;
		}

		public void TrySelect(Point mouseLocation)
		{
			if (CanSelect(mouseLocation))
				IsSelected = true;
		}

		private static bool Intersects(Point point, Point startPoint, Point endPoint)
		{
			Rectangle line = CreateLineRectangle(startPoint, endPoint);
			return line.Contains(point);
		}

		private static bool Intersects(Rectangle rectangle, Point startPoint, Point endPoint)
		{
			Rectangle line = CreateLineRectangle(startPoint, endPoint);
			return line.IntersectsWith(rectangle);
		}

		private static Rectangle CreateLineRectangle(Point startPoint, Point endPoint)
		{
			if (startPoint.X == endPoint.X) { // Vertical line
				if (startPoint.Y < endPoint.Y) {
					return Rectangle.FromLTRB(startPoint.X - PrecisionSize, startPoint.Y,
						startPoint.X + PrecisionSize + 1, endPoint.Y);
				}
				else {
					return Rectangle.FromLTRB(startPoint.X - PrecisionSize, endPoint.Y,
						startPoint.X + PrecisionSize + 1, startPoint.Y);
				}
			}
			else if (startPoint.Y == endPoint.Y) { // Horizontal line
				if (startPoint.X < endPoint.X) {
					return Rectangle.FromLTRB(startPoint.X, startPoint.Y - PrecisionSize,
						endPoint.X, startPoint.Y + PrecisionSize + 1);
				}
				else {
					return Rectangle.FromLTRB(endPoint.X, startPoint.Y - PrecisionSize,
						startPoint.X, startPoint.Y + PrecisionSize + 1);
				}
			}
			else {
				return Rectangle.Empty;
			}
		}

		protected void UpdateStyles(bool onScreen)
		{
			LightBrush.Color = Style.CurrentStyle.RelationBackgroundColor;
			dashPattern[0] = dashPattern[1] = Style.CurrentStyle.RelationDashSize;

			if (onScreen && IsSelected) {
				LinePen.Width = Style.CurrentStyle.RelationSelectedWidth;
				SolidPen.Width = Style.CurrentStyle.RelationSelectedWidth;
				LinePen.Color = SolidPen.Color = DarkBrush.Color =
					Style.CurrentStyle.RelationSelectedForeColor;
				LinePen.DashStyle = DashStyle.Dash;
			}
			else {
				LinePen.Width = Style.CurrentStyle.RelationWidth;
				SolidPen.Width = Style.CurrentStyle.RelationWidth;
				LinePen.Color = SolidPen.Color = DarkBrush.Color =
					Style.CurrentStyle.RelationForeColor;
				if (Dashed)
					LinePen.DashPattern = dashPattern;
				else
					LinePen.DashStyle = DashStyle.Solid;
			}
		}

		private void ReverseNodes()
		{
			int length = nodes.Length;

			for (int i = 0; i < length / 2; i++) {
				Point temp = nodes[i];
				nodes[i] = nodes[length - i - 1];
				nodes[length - i - 1] = temp;
			}
		}

		private void DrawLines(Graphics g)
		{
			if (nodeCount >= 2) {
				for (int i = nodeCount; i < nodes.Length; i++)
					nodes[i] = nodes[i - 1];
				ReverseNodes();
				g.DrawLines(linePen, nodes);
				ReverseNodes();
			}
		}

		private int GetStartSignRotationAngle()
		{
			if (nodeCount >= 2) {
				if (nodes[0].X == nodes[1].X) { // Vertical
					if (nodes[0].Y < nodes[1].Y)
						return 0;
					else
						return 180;
				}
				else { // Horizontal
					if (nodes[0].X < nodes[1].X)
						return 270;
					else
						return 90;
				}
			}

			return 0;
		}

		private int GetEndSignRotationAngle()
		{
			if (nodeCount >= 2) {
				if (nodes[nodeCount - 1].X == nodes[nodeCount - 2].X) { // Vertical
					if (nodes[nodeCount - 1].Y < nodes[nodeCount - 2].Y)
						return 0;
					else
						return 180;
				}
				else { // Horizontal
					if (nodes[nodeCount - 1].X < nodes[nodeCount - 2].X)
						return 270;
					else
						return 90;
				}
			}

			return 0;
		}

		protected virtual void DrawRelativeStartSign(Graphics g)
		{
		}

		protected virtual void DrawRelativeEndSign(Graphics g)
		{
		}

		private void DrawStartSign(Graphics g)
		{
			if (nodeCount >= 2) {
				int angle = GetStartSignRotationAngle();

				g.TranslateTransform(nodes[0].X, nodes[0].Y);
				g.RotateTransform(angle);
				DrawRelativeStartSign(g);
				g.RotateTransform(-angle);
				g.TranslateTransform(-nodes[0].X, -nodes[0].Y);
			}
		}

		private void DrawEndSign(Graphics g)
		{
			if (nodeCount >= 2) {
				int angle = GetEndSignRotationAngle();

				g.TranslateTransform(nodes[nodeCount - 1].X, nodes[nodeCount - 1].Y);
				g.RotateTransform(angle);
				DrawRelativeEndSign(g);
				g.RotateTransform(-angle);
				g.TranslateTransform(-nodes[nodeCount - 1].X, -nodes[nodeCount - 1].Y);
			}
		}

		public void DrawOnScreen(Graphics g, Point position)
		{
			Draw(g, position, 1.0F, true);
		}

		public void DrawOnScreen(Graphics g, Point position, float zoom)
		{
			Draw(g, position, zoom, true);
		}

		public void Draw(Graphics g, Point position)
		{
			Draw(g, position, 1.0F, false);
		}

		public void Draw(Graphics g, Point position, float zoom)
		{
			Draw(g, position, zoom, false);
		}

		private void Draw(Graphics g, Point position, float zoom, bool onScreen)
		{
			if (StartNode.Shape != null && EndNode.Shape != null) {
				if (zoom == 1)
					g.SmoothingMode = SmoothingMode.AntiAlias;
				g.ScaleTransform(zoom, zoom);
				g.TranslateTransform(position.X, position.Y);

				UpdateStyles(onScreen);
				CalculateNodes();
				DrawLines(g);
				DrawStartSign(g);
				DrawEndSign(g);

				g.ResetTransform();
			}
		}

		/// <exception cref="ArgumentNullException">
		/// <paramref name="node"/> is null.
		/// </exception>
		public void Serialize(XmlNode node)
		{
			if (node == null)
				throw new ArgumentNullException("node");

			XmlElement child;

			child = node.OwnerDocument.CreateElement("StartNode");
			startNode.Serialize(child);
			node.AppendChild(child);

			child = node.OwnerDocument.CreateElement("EndNode");
			endNode.Serialize(child);
			node.AppendChild(child);
		}

		/// <exception cref="ArgumentNullException">
		/// <paramref name="node"/> is null.
		/// </exception>
		public void Deserialize(XmlNode node)
		{
			if (node == null)
				throw new ArgumentNullException("node");

			XmlElement child;

			child = node["StartNode"];
			if (child != null)
				startNode.Deserialize(child);

			child = node["EndNode"];
			if (child != null)
				endNode.Deserialize(child);
		}

		protected virtual void OnContentsChanged(EventArgs e)
		{
			if (ContentsChanged != null)
				ContentsChanged(this, e);
		}

		protected virtual void OnSelectionChanged(EventArgs e)
		{
			if (SelectionChanged != null)
				SelectionChanged(this, e);
		}

		public override string ToString()
		{
			return string.Format("{0} --- {1}", StartNode.Shape, EndNode.Shape);
		}
	}
}
