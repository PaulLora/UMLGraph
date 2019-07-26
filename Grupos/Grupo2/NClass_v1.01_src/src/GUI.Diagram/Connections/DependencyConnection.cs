using System;
using System.Drawing;
using NClass.Core;

namespace NClass.GUI.Diagram
{
	internal sealed class DependencyConnection : Connection
	{
		const int ArrowWidth = 12;
		const int ArrowHeight = 17;

		Dependency dependency;

		/// <exception cref="ArgumentNullException">
		/// <paramref name="startNode"/>is null.-or-
		/// <paramref name="endNode"/> is null.-or-
		/// <paramref name="dependency"/> is null.
		/// </exception>
		internal DependencyConnection(TerminalNode startNode, TerminalNode endNode,
			Dependency dependency) : base(startNode, endNode)
		{
			if (dependency == null)
				throw new ArgumentNullException("dependency");

			this.dependency = dependency;
		}

		public override Relation Relation
		{
			get { return dependency; }
		}

		protected override bool Dashed
		{
			get
			{
				return true;
			}
		}

		protected override void DrawRelativeEndSign(Graphics g)
		{
			base.DrawRelativeEndSign(g);

			g.DrawLine(SolidPen,  ArrowWidth / 2, ArrowHeight, 0, 0);
			g.DrawLine(SolidPen, -ArrowWidth / 2, ArrowHeight, 0, 0);
		}

		public override string ToString()
		{
			return dependency.ToString();
		}
	}
}
