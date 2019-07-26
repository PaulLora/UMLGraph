using System;

namespace NClass.Core
{
	public sealed class Destructor : Method
	{
		string parentName;

		/// <exception cref="ArgumentNullException">
		/// <paramref name="parent"/> is null.
		/// </exception>
		internal Destructor(OperationContainer parent) : base(null, parent)
		{
			parentName = Parent.Name;
			AccessModifier = AccessModifier.Default;
		}

		/// <exception cref="BadSyntaxException">
		/// The <paramref name="value"/> does not fit to the syntax.
		/// </exception>
		public override string Name
		{
			get
			{
				return (parentName == null) ? null : "~" + parentName;
			}
			set
			{
				if (parentName != null && value != "~" + parentName)
					throw new BadSyntaxException("error_destructor_name");
			}
		}

		public override bool IsNameReadonly
		{
			get { return true; }
		}

		public override bool Overridable
		{
			get
			{
				return false;
			}
		}

		/// <exception cref="BadSyntaxException">
		/// The <paramref name="value"/> does not fit to the syntax.
		/// </exception>
		public override string Type
		{
			get
			{
				return base.Type;
			}
			set
			{
				if (!string.IsNullOrEmpty(value))
					throw new BadSyntaxException("error_cannot_set_type");
			}
		}

		public override bool IsTypeReadonly
		{
			get { return true; }
		}

		protected override string DefaultType
		{
			get
			{
				return null;
			}
		}

		/// <exception cref="BadSyntaxException">
		/// Cannot set access visibility.
		/// </exception>
		public override AccessModifier AccessModifier
		{
			get
			{
				return base.AccessModifier;
			}
			set
			{
				if (value != AccessModifier.Default)
					throw new BadSyntaxException("error_cannot_set_access");
			}
		}

		public override AccessModifier DefaultAccess
		{
			get
			{
				return AccessModifier.Private;
			}
		}

		public override bool CanSetAccess
		{
			get { return false; }
		}

		/// <exception cref="BadSyntaxException">
		/// Cannot set modifier.
		/// </exception>
		public override OperationModifier Modifier
		{
			get
			{
				return base.Modifier;
			}
			set
			{
				if (value != OperationModifier.None)
					throw new BadSyntaxException("error_cannot_set_modifier");
			}
		}

		/// <exception cref="BadSyntaxException">
		/// Cannot set static modifier.
		/// </exception>
		public override bool IsStatic
		{
			get
			{
				return false;
			}
			set
			{
				if (value)
					throw new BadSyntaxException("error_cannot_set_static");
			}
		}

		public override Language Language
		{
			get { return Language.CSharp; }
		}

		internal void RefreshName()
		{
			Name = "~" + Parent.Name;
		}
	
		public override void InitFromString(string declaration)
		{
			Name = "~" + Parent.Name;
		}

		public override string GetCaption(bool getType, bool getParameters,
			bool getParameterNames, bool getInitValue)
		{
			return Name + "()";
		}

		public override string ToString()
		{
			return Name + "()";
		}
	}
}
