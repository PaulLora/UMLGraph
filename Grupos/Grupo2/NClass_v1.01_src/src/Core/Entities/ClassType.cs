using System;
using System.Collections.Generic;
using System.Xml;

namespace NClass.Core
{
	public abstract class ClassType : FieldContainer, IOverridableType
	{
		InheritanceModifier modifier;
		ClassType baseClass;

		/// <exception cref="BadSyntaxException">
		/// The <paramref name="name"/> does not fit to the syntax.
		/// </exception>
		protected ClassType(String name) : base(name)
		{
			Modifier = InheritanceModifier.None;
			Base = null;
		}
	
		public InheritanceModifier Modifier
		{
			get { return modifier; }
			set { modifier = value; }
		}

		public bool IsAllowedParent
		{
			get
			{
				return Modifier != InheritanceModifier.Sealed &&
				       Modifier != InheritanceModifier.Static;
			}
		}

		public bool IsAllowedChild
		{
			get
			{
				return Modifier != InheritanceModifier.Static;
			}
		}

		public override string Stereotype
		{
			get { return null; }
		}

		public bool HasBase
		{
			get { return Base != null; }
		}

		/// <exception cref="ArgumentException">
		/// The language of <paramref name="value"/> does not equal.-or-
		/// <paramref name="value"/> is static or sealed class.-or-
		/// The <paramref name="value"/> is descendant of the class.
		/// </exception>
		public ClassType Base
		{
			get
			{
				return baseClass;
			}
			set
			{
				if (value == null) {
					baseClass = null;
					return;
				}

				if (value.Modifier == InheritanceModifier.Sealed ||
					value.Modifier == InheritanceModifier.Static)
				{
					throw new ArgumentException("error_cannot_inherit");
				}
				if (value.IsAncestor(this)) {
					throw new ArgumentException("error_cyclic_base");
				}
				if (value.Language != this.Language)
					throw new ArgumentException("error_languages_do_not_equal");

				baseClass = value;
			}
		}

		/// <exception cref="ArgumentException">
		/// The language of <paramref name="value"/> does not equal.-or-
		/// The <paramref name="value"/> is descendant of the type.
		/// </exception>
		IOverridableType IOverridableType.Base
		{
			get { return Base; }
			set { Base = value as ClassType; }
		}

		public virtual IEnumerable<Operation> OverridableOperations
		{
			get
			{
				for (int i = 0; i < OperationList.Count; i++) {
					if (OperationList[i].Overridable)
						yield return OperationList[i];
				}
			}
		}

		private bool IsAncestor(ClassType classType)
		{
			if (Base != null && Base.IsAncestor(classType))
				return true;
			else
				return (classType == this);
		}

		///// <exception cref="ArgumentNullException">
		///// <paramref name="node"/> is null.
		///// </exception>
		//internal override void Serialize(XmlNode node)
		//{
		//	base.Serialize(node);

		//	XmlElement child = node.OwnerDocument.CreateElement("Modifier");
		//	child.InnerText = Modifier.ToString();
		//	node.AppendChild(child);
		//}

		///// <exception cref="BadSyntaxException">
		///// An error occured in building the class.
		///// </exception>
		///// <exception cref="ArgumentNullException">
		///// <paramref name="node"/> is null.
		///// </exception>
		//internal override void Deserialize(XmlNode node)
		//{
		//	base.Deserialize(node);

		//	XmlElement child = node["Modifier"];
		//	if (child != null)
		//		modifier = SyntaxHelper.ParseClassModifier(child.InnerText);
		//}

		/// <exception cref="ArgumentException">
		/// <paramref name="operation"/> cannot be overridden.
		/// </exception>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="operation"/> is null.
		/// </exception>
		public abstract Operation Override(Operation operation);
	}
}
