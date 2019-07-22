using System;

namespace NClass.Core
{
	public abstract class Constructor : Method
	{
		string parentName;

		/// <exception cref="ArgumentNullException">
		/// <paramref name="parent"/> is null.
		/// </exception>
		protected Constructor(OperationContainer parent) : base(null, parent)
		{
			parentName = Parent.Name;
		}

		/// <exception cref="BadSyntaxException">
		/// The <paramref name="value"/> does not fit to the syntax.
		/// </exception>
		public override string Name
		{
			get
			{
				return ParentName;
			}
			set
			{
				if (value != ParentName)
					throw new BadSyntaxException("error_constructor_name");
			}
		}

		public override bool IsNameReadonly
		{
			get { return true; }
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
					IsStatic = false;
				base.AccessModifier = value;
			}
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

		public override bool CanSetModifier
		{
			get { return false; }
		}

		/// <exception cref="BadSyntaxException">
		/// Cannot set static modifier.
		/// </exception>
		public override bool IsStatic
		{
			get
			{
				return base.IsStatic;
			}
			set
			{
				if (value && HasParameter)
					throw new BadSyntaxException("error_static_constructor");

				if (value)
					AccessModifier = AccessModifier.Default;
				base.IsStatic = value;
			}
		}

		public override bool CanSetStatic
		{
			get
			{
				return (base.CanSetStatic && !HasParameter);
			}
		}

		protected string ParentName
		{
			get { return parentName; }
		}

		public override bool Overridable
		{
			get
			{
				return false;
			}
		}
	
		internal void RefreshName()
		{
			Name = Parent.Name;
		}
	}
}
