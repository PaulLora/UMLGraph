using System;
using System.Drawing;
using NClass.Core;

namespace NClass.GUI.Diagram
{
	internal sealed class AssociationConnection : Connection
	{
		const int ArrowWidth = 12;
		const int ArrowHeight = 17;
		const int DiamondWidth = 10;
		const int DiamondHeight = 18;

		static Point[] diamondPoints =  {
			new Point(0, 0),
			new Point(DiamondWidth / 2, DiamondHeight / 2),
			new Point(0, DiamondHeight),
			new Point(-DiamondWidth / 2, DiamondHeight / 2)
		};

		Association association;

		/// <exception cref="ArgumentNullException">
		/// <paramref name="startNode"/>is null.-or-
		/// <paramref name="endNode"/> is null.-or-
		/// <paramref name="association"/> is null.
		/// </exception>
		internal AssociationConnection(TerminalNode startNode, TerminalNode endNode,
			Association association) : base(startNode, endNode)
		{
			if (association == null)
				throw new ArgumentNullException("association");

			this.association = association;
		}

		public override Relation Relation
		{
			get { return association; }
		}

		protected override void DrawRelativeStartSign(Graphics g)
		{
			base.DrawRelativeStartSign(g);

			if (association.IsAggregation) {
				g.FillPolygon(LightBrush, diamondPoints);
				g.DrawPolygon(SolidPen, diamondPoints);
			}
			else if (association.IsComposition) {
				g.FillPolygon(DarkBrush, diamondPoints);
			}
			else if (association.Direction == Direction.DestinationSource) {
				g.DrawLine(SolidPen,  ArrowWidth / 2, ArrowHeight, 0, 0);
				g.DrawLine(SolidPen, -ArrowWidth / 2, ArrowHeight, 0, 0);
			}
		}

		protected override void DrawRelativeEndSign(Graphics g)
		{
			base.DrawRelativeEndSign(g);

			if (association.Direction == Direction.SourceDestination) {
				g.DrawLine(SolidPen,  ArrowWidth / 2, ArrowHeight, 0, 0);
				g.DrawLine(SolidPen, -ArrowWidth / 2, ArrowHeight, 0, 0);
			}
		}

		public override string ToString()
		{
			return association.ToString();
		}
	}
}
