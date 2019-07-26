using System;
using NClass.Core;

namespace NClass.GUI.Diagram
{
	public delegate void EntityRemovedEventHandler(object sender, EntityRemovedEventArgs e);

	public class EntityRemovedEventArgs : EventArgs
	{
		Entity entity;

		public Entity Entity
		{
			get { return entity; }
		}

		public EntityRemovedEventArgs(Entity entity)
		{
			this.entity = entity;
		}
	}
}
