using System;

namespace NClass.Core
{
	public abstract class Member : ICloneable
	{
		protected const string TypePattern =
			@"^\s*(?<type>" + SyntaxHelper.GenericTypePattern2 + @")\s*$";
		protected const string CSharpAccessPattern =
			@"(?<access>public|protected\s+internal|internal|protected|private)?(?(access)\s+|)";
		protected const string JavaAccessPattern =
			@"(?<access>public|protected|private)?(?(access)\s+|)";
		protected const string StaticPattern = @"(?(modifier)|(?<static>static\s+)?)";

		string name;
		string type;
		bool isStatic;
		AccessModifier access;
		OperationContainer parent;

		/// <exception cref="BadSyntaxException">
		/// The <paramref name="name"/> does not fit to the syntax.
		/// </exception>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="parent"/> is null.
		/// </exception>
		protected Member(string name, OperationContainer parent)
		{
			if (parent == null)
				throw new ArgumentNullException("parent");

			Name = name;
			Parent = parent;
			Type = DefaultType;
			AccessModifier = AccessModifier.Default;
			IsStatic = (parent is IOverridableType &&
				((IOverridableType) parent).Modifier == InheritanceModifier.Static);
		}

		/// <exception cref="ArgumentNullException">
		/// <paramref name="value"/> is null.
		/// </exception>
		public OperationContainer Parent
		{
			get
			{
				return parent;
			}
			internal set
			{
				if (value == null)
					throw new ArgumentNullException("value");

				parent = value;
			}
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
				name = value;
			}
		}

		public virtual bool IsNameReadonly
		{
			get { return false; }
		}

		/// <exception cref="BadSyntaxException">
		/// The <paramref name="value"/> does not fit to the syntax.
		/// </exception>
		public virtual string Type
		{
			get
			{
				return type;
			}
			set
			{
				if (SyntaxHelper.IsForbiddenTypeName(value, Language))
					throw new BadSyntaxException("error_forbidden_type_name");
				type = value;
			}
		}

		public virtual bool IsTypeReadonly
		{
			get { return false; }
		}

		protected virtual string DefaultType
		{
			get { return "void"; }
		}

		/// <exception cref="BadSyntaxException">
		/// Cannot set access visibility.
		/// </exception>
		public virtual AccessModifier AccessModifier
		{
			get
			{
				return access;
			}
			set {
				if (value != AccessModifier.Default && Parent is InterfaceType) {
					throw new BadSyntaxException("error_interface_member_access");
				}

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
			get { return Parent.DefaultMemberAccess; }
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

		public virtual bool CanSetAccess
		{
			get { return !(Parent is InterfaceType); }
		}

		/// <exception cref="BadSyntaxException">
		/// Cannot set static modifier.
		/// </exception>
		public virtual bool IsStatic
		{
			get { return isStatic; }
			set { isStatic = value; }
		}

		public virtual bool CanSetStatic
		{
			get { return true; }
		}

		public virtual object Clone()
		{
			return this.MemberwiseClone();
		}

		public abstract Language Language
		{
			get;
		}

		public string GetCaption()
		{
			return GetCaption(true, true, true, true);
		}

		public string GetCaption(bool getType)
		{
			return GetCaption(getType, false, false, getType);
		}

		public string GetCaption(bool getType, bool getParameters)
		{
			return GetCaption(getType, getParameters, true, getType);
		}

		public string GetCaption(bool getType, bool getParameters, bool getParameterNames)
		{
			return GetCaption(getType, getParameters, getParameterNames, getType);
		}

		public abstract string GetCaption(bool getType, bool getParameters,
			bool getParameterNames, bool getInitValue);

		/// <exception cref="BadSyntaxException">
		/// The <paramref name="declaration"/> does not fit to the syntax.
		/// </exception>
		public abstract void InitFromString(string declaration);
	}
}
