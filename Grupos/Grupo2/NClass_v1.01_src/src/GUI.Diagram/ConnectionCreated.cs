using System;
using NClass.Core;

namespace NClass.GUI.Diagram
{
	public delegate void ConnectionCreatedEventHandler(object sender,
		ConnectionCreatedEventArgs e);

	public class ConnectionCreatedEventArgs : EventArgs
	{
		Entity first;
		Entity second;
		RelationType relationType;

		public Entity First
		{
			get { return first; }
		}

		public Entity Second
		{
			get { return second; }
		}

		public RelationType RelationType
		{
			get { return relationType; }
		}

		public ConnectionCreatedEventArgs(Entity first, Entity second, RelationType relationType)
		{
			this.first = first;
			this.second = second;
			this.relationType = relationType;
		}
	}
}
