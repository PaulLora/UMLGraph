using System;

namespace NClass.Core
{
	public sealed class CommentRelation : Relation
	{
		/// <exception cref="ArgumentNullException">
		/// <paramref name="comment"/> is null.-or-
		/// <paramref name="entity"/> is null.
		/// </exception>
		internal CommentRelation(Comment comment, Entity entity) : base(comment, entity)
		{
		}

		/// <exception cref="ArgumentNullException">
		/// <paramref name="entity"/> is null.-or-
		/// <paramref name="comment"/> is null.
		/// </exception>
		internal CommentRelation(Entity entity, Comment comment) : base(entity, comment)
		{
		}

		public override string ToString()
		{
			return string.Format("{0}: {1} --- {2}",
				"comment", First, Second);
		}
	}
}
