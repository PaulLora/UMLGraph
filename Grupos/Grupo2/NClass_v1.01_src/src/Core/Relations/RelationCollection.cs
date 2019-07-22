using System;
using System.Xml;
using System.Collections;

namespace NClass.Core
{
	public sealed class RelationCollection : CollectionBase
	{
		internal RelationCollection()
		{
		}

		public Relation this[int index]
		{
			get { return (Relation) InnerList[index]; }
		}

		/// <exception cref="ArgumentNullException">
		/// <paramref name="first"/> is null.-or-
		/// <paramref name="second"/> is null.
		/// </exception>
		private static Relation AddAssociation(TypeBase first, TypeBase second, RelationType type)
		{
			Association association = new Association(first, second);

			if (type == RelationType.Composition)
				association.IsComposition = true;
			if (type == RelationType.Aggregation)
				association.IsAggregation = true;

			return association;
		}

		/// <exception cref="ArgumentException">
		/// Cannot create <see cref="Generalization"/> between 
		/// <paramref name="first"/> and <paramref name="second"/>.
		/// </exception>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="first"/> is null.-or-
		/// <paramref name="second"/> is null.
		/// </exception>
		private static Relation AddGeneralization(TypeBase first, TypeBase second)
		{
			Generalization generalization = new Generalization(first, second);

			if (first is IOverridableType && second is IOverridableType)
				((IOverridableType) first).Base = (IOverridableType) second;
			else if (first is InterfaceType && second is InterfaceType)
				((InterfaceType) first).AddBase((InterfaceType) second);

			return generalization;
		}

		/// <exception cref="ArgumentException">
		/// Cannot create <see cref="Realization"/> between 
		/// <paramref name="first"/> and <paramref name="second"/>.
		/// </exception>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="first"/> is null.-or-
		/// <paramref name="second"/> is null.
		/// </exception>
		private static Relation AddRealization(TypeBase first, InterfaceType second)
		{
			Realization realization = new Realization(first, second);

			if (first is IInterfaceImplementer && second is InterfaceType)
				((IInterfaceImplementer) first).AddInterface((InterfaceType) second);

			return realization;
		}

		/// <exception cref="ArgumentException">
		/// Cannot create <see cref="Nesting"/> between 
		/// <paramref name="first"/> and <paramref name="second"/>.
		/// </exception>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="first"/> is null.-or-
		/// <paramref name="second"/> is null.
		/// </exception>
		private static Relation AddNesting(FieldContainer first, TypeBase second)
		{
			Nesting nesting = new Nesting(first, second);

			second.Parent = first;
			return nesting;
		}

		/// <exception cref="ArgumentException">
		/// Cannot create relationship between <paramref name="first"/> 
		/// and <paramref name="second"/>.
		/// </exception>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="first"/> is null.-or-
		/// <paramref name="second"/> is null.
		/// </exception>
		public Relation Add(Entity first, Entity second, RelationType type)
		{
			if (first == null)
				throw new ArgumentNullException("first");
			if (second == null)
				throw new ArgumentNullException("second");
			if (first is TypeBase && second is TypeBase &&
				((TypeBase) first).Language != ((TypeBase) second).Language)
			{
				throw new ArgumentException("error_cannot_create_relation");
			}

			Relation relation = null;

			try {
				switch (type) {
					case RelationType.Association:
					case RelationType.Composition:
					case RelationType.Aggregation:
						if (first is TypeBase && second is TypeBase)
							relation = AddAssociation((TypeBase) first, (TypeBase) second, type);
						break;

					case RelationType.Generalization:
						if (first is TypeBase && second is TypeBase)
							relation = AddGeneralization((TypeBase) first, (TypeBase) second);
						break;

					case RelationType.Realization:
						if (first is TypeBase && second is InterfaceType)
							relation = AddRealization((TypeBase) first, (InterfaceType) second);
						break;

					case RelationType.Dependency:
						if (first is TypeBase && second is TypeBase)
							relation = new Dependency((TypeBase) first, (TypeBase) second);
						break;

					case RelationType.Nesting:
						if (first is FieldContainer && second is TypeBase)
							relation = AddNesting((FieldContainer) first, (TypeBase) second);
						break;

					case RelationType.CommentRelation:
						if (first is Comment)
							relation = new CommentRelation((Comment) first, second);
						else
							relation = new CommentRelation(first, (Comment) second);
						break;
				}
			}
			catch (ArgumentException ex) {
				throw new ArgumentException("error_cannot_create_relation" + ex.Message);
			}

			if (relation == null)
				throw new ArgumentException("error_cannot_create_relation");
			else
				InnerList.Add(relation);

			return relation;
		}

		private void RemoveBase(Relation relation)
		{
			if (relation is Generalization) {
				if (relation.First is IOverridableType && relation.Second is IOverridableType &&
					((IOverridableType) relation.First).Base == relation.Second)
				{
					((IOverridableType) relation.First).Base = null;
				}
				else if (relation.First is InterfaceType && relation.Second is InterfaceType)
				{
					((InterfaceType) relation.First).RemoveBase(
						(InterfaceType) relation.Second);
				}
			}
			if (relation is Realization && relation.First is IInterfaceImplementer &&
				relation.Second is InterfaceType)
			{
				((IInterfaceImplementer) relation.First).RemoveInterface(
					(InterfaceType) relation.Second);
			}
		}

		private void RemoveNestedParent(Relation relation)
		{
			if (relation is Nesting)
				((TypeBase) relation.Second).Parent = null;
		}

		internal void Remove(Relation relation)
		{
			if (InnerList.Contains(relation)) {
				InnerList.Remove(relation);
				RemoveBase(relation);
				RemoveNestedParent(relation);
			}
		}

		public void Remove(Entity entity)
		{
			if (entity == null)
				return;

			for (int i = 0; i < InnerList.Count; i++) {
				if (((Relation) InnerList[i]).First == entity ||
					((Relation) InnerList[i]).Second == entity)
				{
					RemoveBase((Relation) InnerList[i]);
					RemoveNestedParent((Relation) InnerList[i]);
					InnerList.RemoveAt(i);
					i--;
				}
			}
		}
	}
}
