using System;
using System.Drawing;
using NClass.Core;

namespace NClass.GUI.Diagram
{
	internal class PreviewConnection : Connection
	{
		const int TriangleSize = 10;

		static Point[] trianglePoints = {
			new Point(-TriangleSize - 1, -1),
			new Point(0, TriangleSize),
			new Point(TriangleSize + 1, -1)
		};

		bool startChosen = false;
		bool endChosen = false;

		/// <exception cref="ArgumentNullException">
		/// <paramref name="startNode"/>is null.-or-
		/// <paramref name="endNode"/> is null.
		/// </exception>
		internal PreviewConnection(TerminalNode startNode, TerminalNode endNode)
			: base(startNode, endNode)
		{
		}

		public bool StartChosen
		{
			get { return startChosen; }
			set { startChosen = value; }
		}

		public bool EndChosen
		{
			get { return endChosen; }
			set { endChosen = value; }
		}

		public override Relation Relation
		{
			get { return null; }
		}

		protected override bool Dashed
		{
			get
			{
				return true;
			}
		}

		protected override void DrawRelativeStartSign(Graphics g)
		{
			g.FillPolygon(LightBrush, trianglePoints);
			g.DrawPolygon(SolidPen, trianglePoints);
		}

		protected override void DrawRelativeEndSign(Graphics g)
		{
			g.FillPolygon(LightBrush, trianglePoints);
			g.DrawPolygon(SolidPen, trianglePoints);
		}

		public void DrawOnlyStartSign(Graphics g, Point mouseLocation)
		{
			EntityShape shape = StartNode.Shape;

			if (shape != null) {
				Point position;
				int angle;

				UpdateStyles(true);

				if (StartNode.IsHorizontal) {
					if (mouseLocation.X < shape.Left + shape.Width / 2) {
						position = new Point(shape.Left - 1, StartNode.AbsoluteLocation);
						angle = 90;
					}
					else {
						position = new Point(shape.Right, StartNode.AbsoluteLocation);
						angle = 270;
					}
				}
				else {
					if (mouseLocation.Y < shape.Top + shape.Height / 2) {
						position = new Point(StartNode.AbsoluteLocation, shape.Top - 1);
						angle = 180;
					}
					else {
						position = new Point(StartNode.AbsoluteLocation, shape.Bottom);
						angle = 0;
					}
				}

				g.TranslateTransform(position.X, position.Y);
				g.RotateTransform(angle);
				DrawRelativeStartSign(g);
				g.RotateTransform(-angle);
				g.TranslateTransform(-position.X, -position.Y);
			}
		}
	}
}
