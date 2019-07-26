using System;
using NClass.Core;

namespace NClass.GUI.Diagram
{
	public delegate void RelationRemovedEventHandler(object sender, RelationRemovedEventArgs e);

	public class RelationRemovedEventArgs : EventArgs
	{
		Relation relation;

		public Relation Relation
		{
			get { return relation; }
		}

		public RelationRemovedEventArgs(Relation relation)
		{
			this.relation = relation;
		}
	}
}
