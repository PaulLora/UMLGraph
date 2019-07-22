using System;
using System.Drawing;
using NClass.Core;

namespace NClass.GUI.Diagram
{
	internal sealed class NestingConnection : Connection
	{
		const int Radius = 9;
		const int CrossSize = 8;

		Nesting nesting;

		/// <exception cref="ArgumentNullException">
		/// <paramref name="startNode"/>is null.-or-
		/// <paramref name="endNode"/> is null.-or-
		/// <paramref name="nesting"/> is null.
		/// </exception>
		internal NestingConnection(TerminalNode startNode, TerminalNode endNode,
			Nesting nesting) : base(startNode, endNode)
		{
			if (nesting == null)
				throw new ArgumentNullException("nesting");

			this.nesting = nesting;
		}

		public override Relation Relation
		{
			get { return nesting; }
		}

		protected override void DrawRelativeStartSign(Graphics g)
		{
			base.DrawRelativeStartSign(g);

			g.FillEllipse(LightBrush, -Radius, 0, Radius * 2, Radius * 2);
			g.DrawEllipse(SolidPen, -Radius, 0, Radius * 2, Radius * 2);
			g.DrawLine(SolidPen, 0, Radius - CrossSize / 2, 0, Radius + CrossSize / 2);
			g.DrawLine(SolidPen, -CrossSize / 2, Radius, CrossSize / 2, Radius);
		}

		public override string ToString()
		{
			return nesting.ToString();
		}
	}
}
