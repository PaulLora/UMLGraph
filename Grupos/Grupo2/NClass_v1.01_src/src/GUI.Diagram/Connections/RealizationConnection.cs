using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using NClass.Core;

namespace NClass.GUI.Diagram
{
	internal sealed class RealizationConnection : Connection
	{
		const int TriangleWidth = 12;
		const int TriangleHeight = 17;

		static Point[] trianglePoints = {
			new Point(-TriangleWidth / 2, TriangleHeight),
			new Point(0, 0),
			new Point(TriangleWidth / 2, TriangleHeight)
		};

		Realization realization;

		/// <exception cref="ArgumentNullException">
		/// <paramref name="startNode"/>is null.-or-
		/// <paramref name="endNode"/> is null.-or-
		/// <paramref name="realization"/> is null.
		/// </exception>
		internal RealizationConnection(TerminalNode startNode, TerminalNode endNode,
			Realization realization) : base(startNode, endNode)
		{
			if (realization == null)
				throw new ArgumentNullException("realization");

			this.realization = realization;
		}

		public override Relation Relation
		{
			get { return realization; }
		}

		protected override bool Dashed
		{
			get { return true; }
		}

		protected override void DrawRelativeEndSign(Graphics g)
		{
			base.DrawRelativeEndSign(g);

			g.FillPolygon(LightBrush, trianglePoints);
			g.DrawPolygon(SolidPen, trianglePoints);
		}

		public override string ToString()
		{
			return realization.ToString();
		}
	}
}
