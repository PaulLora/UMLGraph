using System;
using System.Xml;
using System.Text.RegularExpressions;

namespace NClass.Core
{
	public abstract class TypeBase : Entity
	{
		const string NamePattern = @"^\s*(?<name>" +
			SyntaxHelper.GenericNamePattern + @")\s*$";

		static Regex nameRegex = new Regex(NamePattern, RegexOptions.ExplicitCapture);

		string name;
		AccessModifier access;
		TypeBase parent;

		/// <exception cref="BadSyntaxException">
		/// The <paramref name="name"/> does not fit to the syntax.
		/// </exception>
		protected TypeBase(string name)
		{
			Name = name;
			AccessModifier = AccessModifier.Public;
			Parent = null;
		}

		/// <exception cref="BadSyntaxException">
		/// The <paramref name="value"/> does not fit to the syntax.
		/// </exception>
		public virtual string Name
		{
			get
			{
				return name;
			}
			set
			{
				if (SyntaxHelper.IsForbiddenName(value, Language))
					throw new BadSyntaxException("error_forbidden_name");

				Match match = nameRegex.Match(value);

				if (match.Success)
					name = match.Groups["name"].Value;
				else
					throw new BadSyntaxException("error_invalid_name");
			}
		}

		public virtual AccessModifier AccessModifier
		{
			get
			{
				return access;
			}
			set
			{
				if (Language == Language.Java) {
					if (value == AccessModifier.ProtectedInternal)
						access = AccessModifier.Protected;
					else if (value == AccessModifier.Internal)
						access = AccessModifier.Default;
					else
						access = value;
				}
				else {
					access = value;
				}
			}
		}

		public virtual AccessModifier DefaultAccess
		{
			get { return AccessModifier.Internal; }
		}

		public AccessModifier Access
		{
			get
			{
				if (AccessModifier == AccessModifier.Default)
					return DefaultAccess;
				else
					return AccessModifier;
			}
		}

		/// <exception cref="ArgumentException">
		/// The <paramref name="value"/> is already a child member of the type.
		/// </exception>
		public TypeBase Parent
		{
			get
			{
				return parent;
			}
			set
			{
				if (value != null && value.IsNestedParent(this)) {
					throw new ArgumentException("error_cyclic_nesting");
				}
				//TODO: ez is kellhet:
				/*if (parent == null && Access != AccessModifier.Public)
					AccessModifier = AccessModifier.Internal;*/

				parent = value;
			}
		}

		public bool IsNested
		{
			get { return Parent != null; }
		}

		public abstract string Stereotype { get; }

		private bool IsNestedParent(TypeBase type)
		{
			if (type == null)
				return false;

			if (Parent != null && Parent.IsNestedParent(type))
				return true;
			else
				return type == this;
		}

		/// <exception cref="ArgumentNullException">
		/// <paramref name="node"/> is null.
		/// </exception>
		internal override void Serialize(XmlNode node)
		{
			if (node == null)
				throw new ArgumentNullException("node");

			node.RemoveAll();
			XmlElement child = node.OwnerDocument.CreateElement("Access");
			child.InnerText = AccessModifier.ToString();
			node.AppendChild(child);
		}

		/// <exception cref="BadSyntaxException">
		/// An error occured in building the class.
		/// </exception>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="node"/> is null.
		/// </exception>
		internal override void Deserialize(XmlNode node)
		{
			if (node == null)
				throw new ArgumentNullException("node");
		
			XmlElement child = node["Access"];
			if (child != null)
				access = SyntaxHelper.ParseAccessModifier(child.InnerText);
		}

		public abstract string Signature
		{
			get;
		}

		public abstract Language Language
		{
			get;
		}

		public abstract void MoveUpItem(object item);

		public abstract void MoveDownItem(object item);

		public override string ToString()
		{
			return Name + ": " + Signature;
		}
	}
}
