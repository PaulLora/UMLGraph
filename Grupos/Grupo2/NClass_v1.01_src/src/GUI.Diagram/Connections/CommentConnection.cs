using System;
using NClass.Core;

namespace NClass.GUI.Diagram
{
	internal sealed class CommentConnection : Connection
	{
		CommentRelation commentRelation;

		/// <exception cref="ArgumentNullException">
		/// <paramref name="startNode"/>is null.-or-
		/// <paramref name="endNode"/> is null.-or-
		/// <paramref name="commentRelation"/> is null.
		/// </exception>
		internal CommentConnection(TerminalNode startNode, TerminalNode endNode,
			CommentRelation commentRelation) : base(startNode, endNode)
		{
			if (commentRelation == null)
				throw new ArgumentNullException("commentRelation");

			this.commentRelation = commentRelation;
		}

		public override Relation Relation
		{
			get { return commentRelation; }
		}

		public override string ToString()
		{
			return commentRelation.ToString();
		}
	}
}
