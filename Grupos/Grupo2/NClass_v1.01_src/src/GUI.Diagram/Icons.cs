using System;
using System.Drawing;
using System.Windows.Forms;
using NClass.Core;

namespace NClass.GUI.Diagram
{
	public static class Icons
	{
		public const int InterfaceImageIndex = 46;
		public const int EnumItemImageIndex  = 47;
		public const int ParameterImageIndex = 48;

		static ImageList imageList;

		static Icons()
		{
			LoadImages();
		}

		public static ImageList IconList
		{
			get
			{
				return imageList;
			}
		}

		public static Size IconSize
		{
			get { return imageList.ImageSize; }
		}

		private static void LoadImages()
		{
			imageList = new ImageList();
			imageList.ColorDepth = ColorDepth.Depth32Bit;
			imageList.Images.AddRange(new Image[] {
				Properties.Resources.PublicConst,
				Properties.Resources.ProtintConst,
				Properties.Resources.InternalConst,
				Properties.Resources.ProtectedConst,
				Properties.Resources.PrivateConst,

				Properties.Resources.PublicField,
				Properties.Resources.ProtintField,
				Properties.Resources.InternalField,
				Properties.Resources.ProtectedField,
				Properties.Resources.PrivateField,

				Properties.Resources.PublicConstructor,
				Properties.Resources.ProtintConstructor,
				Properties.Resources.InternalConstructor,
				Properties.Resources.ProtectedConstructor,
				Properties.Resources.PrivateConstructor,

				Properties.Resources.PublicOperator,
				Properties.Resources.ProtintOperator,
				Properties.Resources.InternalOperator,
				Properties.Resources.ProtectedOperator,
				Properties.Resources.PrivateOperator,

				Properties.Resources.PublicMethod,
				Properties.Resources.ProtintMethod,
				Properties.Resources.InternalMethod,
				Properties.Resources.ProtectedMethod,
				Properties.Resources.PrivateMethod,

				Properties.Resources.PublicReadonly,
				Properties.Resources.ProtintReadonly,
				Properties.Resources.InternalReadonly,
				Properties.Resources.ProtectedReadonly,
				Properties.Resources.PrivateReadonly,

				Properties.Resources.PublicWriteonly,
				Properties.Resources.ProtintWriteonly,
				Properties.Resources.InternalWriteoly,
				Properties.Resources.ProtectedWriteonly,
				Properties.Resources.PrivateWriteonly,

				Properties.Resources.PublicProperty,
				Properties.Resources.ProtintProperty,
				Properties.Resources.InternalProperty,
				Properties.Resources.ProtectedProperty,
				Properties.Resources.PrivateProperty,

				Properties.Resources.PublicEvent,
				Properties.Resources.ProtintEvent,
				Properties.Resources.InternalEvent,
				Properties.Resources.ProtectedEvent,
				Properties.Resources.PrivateEvent,
			
				Properties.Resources.PrivateDestructor, // 45.
				Properties.Resources.Interface24,       // 46.
				Properties.Resources.EnumItem,          // 47.
				Properties.Resources.Parameter }        // 48.
			);
		}

		/// <exception cref="ArgumentNullException">
		/// A <paramref name="member"/> nem lehet null.
		/// </exception>
		public static int GetImageIndex(Member member)
		{
			if (member == null)
				throw new ArgumentNullException("member");

			int group = 0;

			if (member is Destructor)
				return 45;

			if (member is IConst && ((IConst) member).IsConst) {
				group = 0;
			}
			else if (member is Field) {
				group = 1;
			}
			else if (member is Constructor) {
				group = 2;
			}
			else if (member is IOperator && ((IOperator) member).IsOperator) {
				group = 3;
			}
			else if (member is Method) {
				group = 4;
			}
			else if (member is Property) {
				if (((Property) member).IsReadonly)
					group = 5;
				else if (((Property) member).IsWriteonly)
					group = 6;
				else
					group = 7;
			}
			else if (member is Event) {
				group = 8;
			}

			return group * 5 + (int) member.Access - 1;
		}

		/// <exception cref="ArgumentNullException">
		/// <paramref name="member"/> is null.
		/// </exception>
		public static Image GetImage(Member member)
		{
			return imageList.Images[GetImageIndex(member)];
		}
	}
}
