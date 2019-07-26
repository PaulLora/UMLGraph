using System;
using System.Drawing;
using NClass.Core;

namespace NClass.GUI.Diagram
{
	internal sealed class GeneralizationConnection : Connection
	{
		const int TriangleWidth = 12;
		const int TriangleHeight = 17;

		static Point[] trianglePoints = {
			new Point(-TriangleWidth / 2, TriangleHeight),
			new Point(0, 0),
			new Point(TriangleWidth / 2, TriangleHeight)
		};

		Generalization generalization;

		/// <exception cref="ArgumentNullException">
		/// <paramref name="startNode"/>is null.-or-
		/// <paramref name="endNode"/> is null.-or-
		/// <paramref name="generalization"/> is null.
		/// </exception>
		internal GeneralizationConnection(TerminalNode startNode, TerminalNode endNode,
			Generalization generalization) : base(startNode, endNode)
		{
			if (generalization == null)
				throw new ArgumentNullException("generalization");

			this.generalization = generalization;
		}

		public override Relation Relation
		{
			get { return generalization; }
		}

		protected override void DrawRelativeEndSign(Graphics g)
		{
			base.DrawRelativeEndSign(g);

			g.FillPolygon(LightBrush, trianglePoints);
			g.DrawPolygon(SolidPen, trianglePoints);
		}

		public override string ToString()
		{
			return generalization.ToString();
		}
	}
}
