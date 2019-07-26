using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using NClass.Core;

namespace NClass.GUI.Diagram
{
	public sealed class ClassShape : OperationContainerShape
	{
		ClassType _class;

		/// <exception cref="ArgumentNullException">
		/// <paramref name="classType"/> is null.
		/// </exception>
		internal ClassShape(ClassType classType)
		{
			if (classType == null)
				throw new ArgumentNullException("classType");

			_class = classType;
		}

		public override Entity Entity
		{
			get { return _class; }
		}

		protected override Color BackgroundColor
		{
			get { return Style.CurrentStyle.ClassBackgroundColor; }
		}

		protected override Color BorderColor
		{
			get { return Style.CurrentStyle.ClassBorderColor; }
		}

		protected override int BorderWidth
		{
			get
			{
				switch (_class.Modifier) {
					case InheritanceModifier.Abstract:
						return Style.CurrentStyle.AbstractClassBorderWidth;

					case InheritanceModifier.Sealed:
						return Style.CurrentStyle.SealedClassBorderWidth;

					case InheritanceModifier.Static:
						return Style.CurrentStyle.StaticClassBorderWidth;

					case InheritanceModifier.None:
					default:
						return Style.CurrentStyle.ClassBorderWidth;
				}
			}
		}

		protected override bool IsBorderDashed
		{
			get
			{
				switch (_class.Modifier) {
					case InheritanceModifier.Abstract:
						return Style.CurrentStyle.IsAbstractClassBorderDashed;

					case InheritanceModifier.Sealed:
						return Style.CurrentStyle.IsSealedClassBorderDashed;

					case InheritanceModifier.Static:
						return Style.CurrentStyle.IsStaticClassBorderDashed;

					case InheritanceModifier.None:
					default:
						return Style.CurrentStyle.IsClassBorderDashed;
				}
			}
		}

		protected override bool IsSelectedBorderDashed
		{
			get
			{
				switch (_class.Modifier) {
					case InheritanceModifier.Abstract:
						return Style.CurrentStyle.IsAbstractClassSelectedBorderDashed;

					case InheritanceModifier.Sealed:
						return Style.CurrentStyle.IsSealedClassSelectedBorderDashed;

					case InheritanceModifier.Static:
						return Style.CurrentStyle.IsStaticClassSelectedBorderDashed;

					case InheritanceModifier.None:
					default:
						return Style.CurrentStyle.IsClassSelectedBorderDashed;
				}
			}
		}

		protected override Color HeaderColor
		{
			get { return Style.CurrentStyle.ClassHeaderColor; }
		}

		protected override Font NameFont
		{
			get
			{
				if (_class.Modifier == InheritanceModifier.Abstract)
					return Style.CurrentStyle.AbstractNameFont;
				else
					return base.NameFont;
			}
		}

		protected override int RoundingSize
		{
			get { return Style.CurrentStyle.ClassRoundingSize; }
		}

		protected override Color SelectedBorderColor
		{
			get { return Style.CurrentStyle.ClassSelectedBorderColor; }
		}

		protected override int SelectedBorderWidth
		{
			get
			{
				switch (_class.Modifier) {
					case InheritanceModifier.Abstract:
						return Style.CurrentStyle.AbstractClassSelectedBorderWidth;

					case InheritanceModifier.Sealed:
						return Style.CurrentStyle.SealedClassSelectedBorderWidth;

					case InheritanceModifier.Static:
						return Style.CurrentStyle.StaticClassSelectedBorderWidth;

					case InheritanceModifier.None:
					default:
						return Style.CurrentStyle.ClassSelectedBorderWidth;
				}
			}
		}

		protected override bool UseGradientHeader
		{
			get { return Style.CurrentStyle.ClassUseGradientHeader; }
		}
	}
}
