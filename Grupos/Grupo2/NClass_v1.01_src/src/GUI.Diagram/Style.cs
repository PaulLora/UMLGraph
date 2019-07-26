using System;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace NClass.GUI.Diagram
{
	[Serializable]
	[DefaultProperty("AttributeColor")]
	public class Style : ICloneable, IDisposable
	{
		static Style currentStyle;
		static string stylePath = Path.Combine(Application.StartupPath, "style.dst");

		#region Fields

		string name = null;
		string author = null;
		Color diagramBackColor = Color.White;

		// Type fields
		int headerHeight = 0;
		int marginSize = 10;
		bool showSignature = false;
		bool showStereotypes = true;
		bool useIcons = false;
		Color identifierColor = Color.Black;
		Color nameColor = Color.Black;
		Color attributeColor = Color.Black;
		Color operationColor = Color.Black;
		ContentAlignment headerAlignment = ContentAlignment.MiddleCenter;
		Font nameFont = new Font("Tahoma", 8.25F);
		Font identifierFont = new Font("Tahoma", 6.75F);
		Font memberFont = new Font("Tahoma", 8.25F);
		[NonSerialized] Font abstractNameFont;
		[NonSerialized] Font staticMemberFont;
		[NonSerialized] Font abstractMemberFont;

		// Class fields
		int classBorderWidth = 1;
		int classRoundingSize = 0;
		int classSelectedBorderWidth = 2;
		bool classUseGradientHeader = false;
		bool isClassBorderDashed = false;
		bool isClassSelectedBorderDashed = false;
		Color classBackgroundColor = Color.White;
		Color classBorderColor = Color.Black;
		Color classHeaderColor = Color.White;
		Color classSelectedBorderColor = Color.Black;

		// Modified class fields
		int abstractClassBorderWidth = 1;
		int abstractClassSelectedBorderWidth = 2;
		bool isAbstractClassBorderDashed = false;
		bool isAbstractClassSelectedBorderDashed = false;

		int sealedClassBorderWidth = 1;
		int sealedClassSelectedBorderWidth = 2;
		bool isSealedClassBorderDashed = false;
		bool isSealedClassSelectedBorderDashed = false;

		int staticClassBorderWidth = 1;
		int staticClassSelectedBorderWidth = 2;
		bool isStaticClassBorderDashed = false;
		bool isStaticClassSelectedBorderDashed = false;

		// Struct fields
		int structBorderWidth = 1;
		int structRoundingSize = 0;
		int structSelectedBorderWidth = 2;
		bool structUseGradientHeader = false;
		bool isStructBorderDashed = false;
		bool isStructSelectedBorderDashed = false;
		Color structBackgroundColor = Color.White;
		Color structBorderColor = Color.Black;
		Color structHeaderColor = Color.White;
		Color structSelectedBorderColor = Color.Black;

		// Interface fields
		int interfaceBorderWidth = 1;
		int interfaceRoundingSize = 0;
		int interfaceSelectedBorderWidth = 2;
		bool interfaceUseGradientHeader = false;
		bool isInterfaceBorderDashed = false;
		bool isInterfaceSelectedBorderDashed = false;
		Color interfaceBackgroundColor = Color.White;
		Color interfaceBorderColor = Color.Black;
		Color interfaceHeaderColor = Color.White;
		Color interfaceSelectedBorderColor = Color.Black;

		// Enum fields
		int enumBorderWidth = 1;
		int enumRoundingSize = 0;
		int enumSelectedBorderWidth = 2;
		bool enumUseGradientHeader = false;
		bool isEnumBorderDashed = false;
		bool isEnumSelectedBorderDashed = false;
		Color enumBackgroundColor = Color.White;
		Color enumBorderColor = Color.Black;
		Color enumHeaderColor = Color.White;
		Color enumItemColor = Color.Black;
		Color enumSelectedBorderColor = Color.Black;

		// Delegate fields
		int delegateBorderWidth = 1;
		int delegateRoundingSize = 0;
		int delegateSelectedBorderWidth = 2;
		bool delegateUseGradientHeader = false;
		bool isDelegateBorderDashed = false;
		bool isDelegateSelectedBorderDashed = false;
		Color delegateBackgroundColor = Color.White;
		Color delegateBorderColor = Color.Black;
		Color delegateHeaderColor = Color.White;
		Color delegateParameterColor = Color.Black;
		Color delegateSelectedBorderColor = Color.Black;

		// Comment fields
		int commentBorderWidth = 1;
		int commentMarginSize = 10;
		int commentSelectedBorderWidth = 2;
		bool isCommentBorderDashed = false;
		bool isCommentSelectedBorderDashed = false;
		Color commentBackColor = Color.White;
		Color commentBorderColor = Color.Black;
		Color commentSelectedBorderColor = Color.Black;
		Color textColor = Color.Black;
		Font commentFont = new Font("Tahoma", 8);

		// Relation fields
		int relationDashSize = 5;
		int relationWidth = 1;
		int relationSelectedWidth = 2;
		Color relationForeColor = Color.Black;
		Color relationSelectedForeColor = Color.Black;
		Color relationBackgroundColor = Color.White;

		#endregion

		static Style()
		{
			if (!LoadCurrentStyle()){
				CurrentStyle = new Style();
				SaveCurrentStyle();
			}
		}

		private Style()
		{
			abstractNameFont = new Font(nameFont, FontStyle.Italic);
			staticMemberFont = new Font(memberFont, memberFont.Style | FontStyle.Underline);
			abstractMemberFont = new Font(memberFont, memberFont.Style | FontStyle.Italic);
		}

		public static Style CurrentStyle
		{
			get
			{
				return currentStyle;
			}
			set
			{
				if (value != null) {
					if (currentStyle != null)
						currentStyle.Dispose();
					currentStyle = value;
					SaveCurrentStyle();
				}
			}
		}

		#region Style Information

		[DisplayName("Style Name"), Category("(Style Information)")]
		[Description("The name of the current style.")]
		public string Name
		{
			get
			{
				if (string.IsNullOrEmpty(name))
					return "untitled";
				else
					return name;
			}
			set
			{
				if (value == "untitled")
					name = null;
				else
					name = value;
			}
		}

		[DisplayName("Author"), Category("(Style Information)")]
		[Description("The author of the current style.")]
		public string Author
		{
			get
			{
				if (string.IsNullOrEmpty(author))
					return "unknown";
				else
					return author;
			}
			set
			{
				if (value == "unknown")
					author = null;
				else
					author = value;
			}
		}

		#endregion

		#region Background properties

		[DisplayName("Background Color"), Category("(Background)")]
		[Description("The background color for the diagram.")]
		[DefaultValue(typeof(Color), "White")]
		public Color DiagramBackColor
		{
			get { return diagramBackColor; }
			set { diagramBackColor = value; }
		}

		#endregion

		#region All Types properties

		[DisplayName("Attribute Color"), Category("(All Types)")]
		[Description("The text color of a type's attributes.")]
		[DefaultValue(typeof(Color), "Black")]
		public Color AttributeColor
		{
			get { return attributeColor; }
			set { attributeColor = value; }
		}

		[DisplayName("Background Color"), Category("(All Types)")]
		[Description("The background color for all types.")]
		[DefaultValue(typeof(Color), "White")]
		public Color BackgroundColor
		{
			get
			{
				Color color = classBackgroundColor;

				if (structBackgroundColor == color &&
					interfaceBackgroundColor == color &&
					enumBackgroundColor == color &&
					delegateBackgroundColor == color)
				{
					return color;
				}
				else {
					return Color.Empty;
				}
			}
			set
			{
				if (value != Color.Empty) {
					classBackgroundColor = value;
					structBackgroundColor = value;
					interfaceBackgroundColor = value;
					enumBackgroundColor = value;
					delegateBackgroundColor = value;
				}
			}
		}

		[DisplayName("Border Color"), Category("(All Types)")]
		[Description("The border color for all types when it is not selected.")]
		[DefaultValue(typeof(Color), "Black")]
		public Color BorderColor
		{
			get
			{
				Color color = classBorderColor;

				if (structBorderColor == color &&
					interfaceBorderColor == color &&
					enumBorderColor == color &&
					delegateBorderColor == color) {
					return color;
				}
				else {
					return Color.Empty;
				}
			}
			set
			{
				if (value != Color.Empty) {
					classBorderColor = value;
					structBorderColor = value;
					interfaceBorderColor = value;
					enumBorderColor = value;
					delegateBorderColor = value;
				}
			}
		}

		[DisplayName("Border Width"), Category("(All Types)")]
		[Description("The border width for all types when it is not selected.")]
		[DefaultValue(1)]
		public int? BorderWidth
		{
			get
			{
				int width = classBorderWidth;

				if (structBorderWidth == width &&
					interfaceBorderWidth == width &&
					enumBorderWidth == width &&
					delegateBorderWidth == width &&
					abstractClassBorderWidth == width &&
					sealedClassBorderWidth == width &&
					staticClassBorderWidth == width)
				{
					return width;
				}
				else {
					return null;
				}
			}
			set
			{
				if (value.HasValue) {
					int width = (value.Value < 1) ? 1 : value.Value;

					classBorderWidth = width;
					structBorderWidth = width;
					interfaceBorderWidth = width;
					enumBorderWidth = width;
					delegateBorderWidth = width;
					abstractClassBorderWidth = width;
					sealedClassBorderWidth = width;
					staticClassBorderWidth = width;
				}
			}
		}

		[DisplayName("Dashed Border"), Category("(All Types)")]
		[Description("Whether the border for all types will be dashed " +
			"when it is not selected.")]
		[DefaultValue(false)]
		public bool? IsBorderDashed
		{
			get
			{
				bool dashed = isClassBorderDashed;

				if (isStructBorderDashed == dashed &&
					isInterfaceBorderDashed == dashed &&
					isEnumBorderDashed == dashed &&
					isDelegateBorderDashed == dashed &&
					isAbstractClassBorderDashed == dashed &&
					isSealedClassBorderDashed == dashed &&
					isStaticClassBorderDashed == dashed)
				{
					return dashed;
				}
				else {
					return null;
				}
			}
			set
			{
				if (value.HasValue) {
					isClassBorderDashed = value.Value;
					isStructBorderDashed = value.Value;
					isInterfaceBorderDashed = value.Value;
					isEnumBorderDashed = value.Value;
					isDelegateBorderDashed = value.Value;
					isAbstractClassBorderDashed = value.Value;
					isSealedClassBorderDashed = value.Value;
					isStaticClassBorderDashed = value.Value;
				}
			}
		}

		[DisplayName("Dashed Selected Border"), Category("(All Types)")]
		[Description("Whether the border for all types will be dashed " +
			"when it is selected.")]
		[DefaultValue(false)]
		public bool? IsSelectedBorderDashed
		{
			get
			{
				bool dashed = isClassSelectedBorderDashed;

				if (isStructSelectedBorderDashed == dashed &&
					isInterfaceSelectedBorderDashed == dashed &&
					isEnumSelectedBorderDashed == dashed &&
					isDelegateSelectedBorderDashed == dashed &&
					isAbstractClassSelectedBorderDashed == dashed &&
					isSealedClassSelectedBorderDashed == dashed &&
					isStaticClassSelectedBorderDashed == dashed)
				{
					return dashed;
				}
				else {
					return null;
				}
			}
			set
			{
				if (value.HasValue) {
					isClassSelectedBorderDashed = value.Value;
					isStructSelectedBorderDashed = value.Value;
					isInterfaceSelectedBorderDashed = value.Value;
					isEnumSelectedBorderDashed = value.Value;
					isDelegateSelectedBorderDashed = value.Value;
					isAbstractClassSelectedBorderDashed = value.Value;
					isSealedClassSelectedBorderDashed = value.Value;
					isStaticClassSelectedBorderDashed = value.Value;
				}
			}
		}

		[DisplayName("Header Alignment"), Category("(All Types)")]
		[Description("Specifies text alignment within the header compartment.")]
		[DefaultValue(ContentAlignment.MiddleCenter)]
		public ContentAlignment HeaderAlignment
		{
			get { return headerAlignment; }
			set { headerAlignment = value; }
		}

		[DisplayName("Header Color"), Category("(All Types)")]
		[Description("The background color of the header compartment for all types.")]
		[DefaultValue(typeof(Color), "White")]
		public Color HeaderColor
		{
			get
			{
				Color color = classHeaderColor;

				if (structHeaderColor == color &&
					interfaceHeaderColor == color &&
					enumHeaderColor == color &&
					delegateHeaderColor == color)
				{
					return color;
				}
				else {
					return Color.Empty;
				}
			}
			set
			{
				if (value != Color.Empty) {
					classHeaderColor = value;
					structHeaderColor = value;
					interfaceHeaderColor = value;
					enumHeaderColor = value;
					delegateHeaderColor = value;
				}
			}
		}

		[DisplayName("Header Height"), Category("(All Types)")]
		[Description("The height of the header compartment. Set it to 0 for auto height.")]
		[DefaultValue(0)]
		public int HeaderHeight
		{
			get
			{
				return headerHeight;
			}
			set
			{
				if (value < 10 && value != 0)
					headerHeight = 10;
				else
					headerHeight = value;
			}
		}

		[DisplayName("Identifier Color"), Category("(All Types)")]
		[Description("The text color of the secondary text beside the type's name.")]
		[DefaultValue(typeof(Color), "Black")]
		public Color IdentifierColor
		{
			get { return identifierColor; }
			set { identifierColor = value; }
		}

		[DisplayName("Identifier Font"), Category("(All Types)")]
		[Description("The font of the secondary text beside the type's name.")]
		public Font IdentifierFont
		{
			get
			{
				return identifierFont;
			}
			set
			{
				if (value != null) {
					identifierFont.Dispose();
					identifierFont = value;
				}
			}
		}

		[DisplayName("Margin Size"), Category("(All Types)")]
		[Description("The distance between the type's edges and its text.")]
		[DefaultValue(10)]
		public int MarginSize
		{
			get
			{
				return marginSize;
			}
			set
			{
				if (value < 0)
					marginSize = 0;
				else
					marginSize = value;
			}
		}

		[DisplayName("Member Font"), Category("(All Types)")]
		[Description("The font of the type's members.")]
		public Font MemberFont
		{
			get
			{
				return memberFont;
			}
			set
			{
				if (value != null) {
					memberFont.Dispose();
					memberFont = value;

					if (staticMemberFont != null)
						staticMemberFont.Dispose();
					if (abstractMemberFont != null)
						abstractMemberFont.Dispose();

					staticMemberFont = new Font(memberFont,
						memberFont.Style | FontStyle.Underline);
					abstractMemberFont = new Font(memberFont,
						memberFont.Style | FontStyle.Italic);
				}
			}
		}

		[Browsable(false)]
		public Font StaticMemberFont
		{
			get
			{
				if (staticMemberFont == null) {
					staticMemberFont = new Font(memberFont,
						memberFont.Style | FontStyle.Underline);
				}

				return staticMemberFont;
			}
		}

		[Browsable(false)]
		public Font AbstractMemberFont
		{
			get
			{
				if (abstractMemberFont == null) {
					abstractMemberFont = new Font(memberFont,
						memberFont.Style | FontStyle.Italic);
				}

				return abstractMemberFont;
			}
		}

		[DisplayName("Name Color"), Category("(All Types)")]
		[Description("The text color of the type's name.")]
		[DefaultValue(typeof(Color), "Black")]
		public Color NameColor
		{
			get { return nameColor; }
			set { nameColor = value; }
		}

		[DisplayName("Name Font"), Category("(All Types)")]
		[Description("The font of the type's name.")]
		public Font NameFont
		{
			get
			{
				return nameFont;
			}
			set
			{
				if (value != null) {
					nameFont.Dispose();
					nameFont = value;

					if (abstractNameFont != null)
						abstractNameFont.Dispose();
					abstractNameFont = new Font(nameFont, nameFont.Style | FontStyle.Italic);
				}
			}
		}

		[Browsable(false)]
		public Font AbstractNameFont
		{
			get
			{
				if (abstractNameFont == null)
					abstractNameFont = new Font(nameFont, nameFont.Style | FontStyle.Italic);

				return abstractNameFont;
			}
		}

		[DisplayName("Operation Color"), Category("(All Types)")]
		[Description("The text color of a type's operations.")]
		[DefaultValue(typeof(Color), "Black")]
		public Color OperationColor
		{
			get { return operationColor; }
			set { operationColor = value; }
		}

		[DisplayName("Rounding Size"), Category("(All Types)")]
		[Description("The rounding size of the corners for all types.")]
		[DefaultValue(0)]
		public int? RoundingSize
		{
			get
			{
				int size = classRoundingSize;

				if (structRoundingSize == size &&
					interfaceRoundingSize == size &&
					enumRoundingSize == size &&
					delegateRoundingSize == size)
				{
					return size;
				}
				else {
					return null;
				}
			}
			set
			{
				if (value.HasValue) {
					int size = (value.Value < 0) ? 0 : value.Value;

					classRoundingSize = size;
					structRoundingSize = size;
					interfaceRoundingSize = size;
					enumRoundingSize = size;
					delegateRoundingSize = size;
				}
			}
		}

		[DisplayName("Selected Border Color"), Category("(All Types)")]
		[Description("The border color for all types when it is selected.")]
		[DefaultValue(typeof(Color), "Black")]
		public Color SelectedBorderColor
		{
			get
			{
				Color color = classSelectedBorderColor;

				if (classSelectedBorderColor == color &&
					structSelectedBorderColor == color &&
					interfaceSelectedBorderColor == color &&
					enumSelectedBorderColor == color &&
					delegateSelectedBorderColor == color)
				{
					return color;
				}
				else {
					return Color.Empty;
				}
			}
			set
			{
				if (value != Color.Empty) {
					classSelectedBorderColor = value;
					structSelectedBorderColor = value;
					interfaceSelectedBorderColor = value;
					enumSelectedBorderColor = value;
					delegateSelectedBorderColor = value;
				}
			}
		}

		[DisplayName("Selected Border Width"), Category("(All Types)")]
		[Description("The border width for all types when it is selected.")]
		[DefaultValue(2)]
		public int? SelectedBorderWidth
		{
			get
			{
				int width = classSelectedBorderWidth;

				if (structSelectedBorderWidth == width &&
					interfaceSelectedBorderWidth == width &&
					enumSelectedBorderWidth == width &&
					delegateSelectedBorderWidth == width &&
					abstractClassSelectedBorderWidth == width &&
					sealedClassSelectedBorderWidth == width &&
					staticClassSelectedBorderWidth == width)
				{
					return width;
				}
				else {
					return null;
				}
			}
			set
			{
				if (value.HasValue) {
					int width = (value.Value < 1) ? 1 : value.Value;

					classSelectedBorderWidth = width;
					structSelectedBorderWidth = width;
					interfaceSelectedBorderWidth = width;
					enumSelectedBorderWidth = width;
					delegateSelectedBorderWidth = width;
					abstractClassSelectedBorderWidth = width;
					sealedClassSelectedBorderWidth = width;
					staticClassSelectedBorderWidth = width;
				}
			}
		}

		[DisplayName("Show Signature"), Category("(All Types)")]
		[Description("Whether to show detailed type description " +
			"within the header compartment.")]
		[DefaultValue(false)]
		public bool ShowSignature
		{
			get
			{
				return showSignature;
			}
			set
			{
				if (value && ShowStereotype)
					ShowStereotype = false;
				showSignature = value;
			}
		}

		[DisplayName("Show Stereotype"), Category("(All Types)")]
		[Description("Whether to show stereotype within the header compartment.")]
		[DefaultValue(true)]
		public bool ShowStereotype
		{
			get
			{
				return showStereotypes;
			}
			set
			{
				if (value && ShowSignature)
					ShowSignature = false;
				showStereotypes = value;
			}
		}

		[DisplayName("Use Gradient Header"), Category("(All Types)")]
		[Description("Whether use gradient background colors in the " +
			"header compartment for all types.")]
		[DefaultValue(false)]
		public bool? UseGradientHeader
		{
			get
			{
				bool value = classUseGradientHeader;

				if (structUseGradientHeader == value &&
					interfaceUseGradientHeader == value &&
					enumUseGradientHeader == value &&
					delegateUseGradientHeader == value)
				{
					return value;
				}
				else {
					return null;
				}
			}
			set
			{
				if (value.HasValue) {
					classUseGradientHeader = value.Value;
					structUseGradientHeader = value.Value;
					interfaceUseGradientHeader = value.Value;
					enumUseGradientHeader = value.Value;
					delegateUseGradientHeader = value.Value;
				}
			}
		}

		[DisplayName("Use Icons"), Category("(All Types)")]
		[Description("Whether to use member type icons in the " +
			"attributes and operations compartments.")]
		[DefaultValue(false)]
		public bool UseIcons
		{
			get { return useIcons; }
			set { useIcons = value; }
		}

		#endregion

		#region Class properties

		[DisplayName("Background Color"), Category("Class")]
		[Description("The background color for the class type.")]
		[DefaultValue(typeof(Color), "White")]
		public Color ClassBackgroundColor
		{
			get { return classBackgroundColor; }
			set { classBackgroundColor = value; }
		}

		[DisplayName("Border Color"), Category("Class")]
		[Description("The border color for the class type when it is not selected.")]
		[DefaultValue(typeof(Color), "Black")]
		public Color ClassBorderColor
		{
			get { return classBorderColor; }
			set { classBorderColor = value; }
		}

		[DisplayName("Border Width"), Category("Class")]
		[Description("The border width for the class type when it is not selected.")]
		[DefaultValue(1)]
		public int ClassBorderWidth
		{
			get
			{
				return classBorderWidth;
			}
			set
			{
				if (value < 1)
					classBorderWidth = 1;
				else
					classBorderWidth = value;
			}
		}

		[DisplayName("Dashed Border"), Category("Class")]
		[Description("Whether the border for the class type will be dashed " +
			"when it is not selected.")]
		[DefaultValue(false)]
		public bool IsClassBorderDashed
		{
			get { return isClassBorderDashed; }
			set { isClassBorderDashed = value; }
		}

		[DisplayName("Dashed Selected Border"), Category("Class")]
		[Description("Whether the border for the class type will be dashed " +
			"when it is selected.")]
		[DefaultValue(false)]
		public bool IsClassSelectedBorderDashed
		{
			get { return isClassSelectedBorderDashed; }
			set { isClassSelectedBorderDashed = value; }
		}

		[DisplayName("Header Color"), Category("Class")]
		[Description("The background color of the header compartment for the class type.")]
		[DefaultValue(typeof(Color), "White")]
		public Color ClassHeaderColor
		{
			get { return classHeaderColor; }
			set { classHeaderColor = value; }
		}

		[DisplayName("Rounding Size"), Category("Class")]
		[Description("The rounding size of the corners for the class type.")]
		[DefaultValue(0)]
		public int ClassRoundingSize
		{
			get
			{
				return classRoundingSize;
			}
			set
			{
				if (value < 0)
					classRoundingSize = 0;
				else
					classRoundingSize = value;
			}
		}

		[DisplayName("Selected Border Color"), Category("Class")]
		[Description("The border color for the class type when it is selected.")]
		[DefaultValue(typeof(Color), "Black")]
		public Color ClassSelectedBorderColor
		{
			get { return classSelectedBorderColor; }
			set { classSelectedBorderColor = value; }
		}

		[DisplayName("Selected Border Width"), Category("Class")]
		[Description("The border width for the class type when it is selected.")]
		[DefaultValue(2)]
		public int ClassSelectedBorderWidth
		{
			get
			{
				return classSelectedBorderWidth;
			}
			set
			{
				if (value < 1)
					classSelectedBorderWidth = 1;
				else
					classSelectedBorderWidth = value;
			}
		}

		[DisplayName("Use Gradient Header"), Category("Class")]
		[Description("Whether use gradient background colors in the " +
			"header compartment for the class type.")]
		[DefaultValue(false)]
		public bool ClassUseGradientHeader
		{
			get { return classUseGradientHeader; }
			set { classUseGradientHeader = value; }
		}

		#endregion

		#region Modified class properties

		[DisplayName("Border Width"), Category("Abstract Class")]
		[Description("The border width for abstract classes when it is not selected.")]
		[DefaultValue(1)]
		public int AbstractClassBorderWidth
		{
			get
			{
				return abstractClassBorderWidth;
			}
			set
			{
				if (value < 1)
					abstractClassBorderWidth = 1;
				else
					abstractClassBorderWidth = value;
			}
		}

		[DisplayName("Selected Border Width"), Category("Abstract Class")]
		[Description("The border width for abstract classes when it is selected.")]
		[DefaultValue(2)]
		public int AbstractClassSelectedBorderWidth
		{
			get
			{
				return abstractClassSelectedBorderWidth;
			}
			set
			{
				if (value < 1)
					abstractClassSelectedBorderWidth = 1;
				else
					abstractClassSelectedBorderWidth = value;
			}
		}

		[DisplayName("Dashed Border"), Category("Abstract Class")]
		[Description("Whether the border for abstract classes will be dashed " +
			"when it is not selected.")]
		[DefaultValue(false)]
		public bool IsAbstractClassBorderDashed
		{
			get { return isAbstractClassBorderDashed; }
			set { isAbstractClassBorderDashed = value; }
		}

		[DisplayName("Dashed Selected Border"), Category("Abstract Class")]
		[Description("Whether the border for abstract classes will be dashed " +
			"when it is selected.")]
		[DefaultValue(false)]
		public bool IsAbstractClassSelectedBorderDashed
		{
			get { return isAbstractClassSelectedBorderDashed; }
			set { isAbstractClassSelectedBorderDashed = value; }
		}

		[DisplayName("Border Width"), Category("Sealed Class")]
		[Description("The border width for sealed classes when it is not selected.")]
		[DefaultValue(1)]
		public int SealedClassBorderWidth
		{
			get
			{
				return sealedClassBorderWidth;
			}
			set
			{
				if (value < 1)
					sealedClassBorderWidth = 1;
				else
					sealedClassBorderWidth = value;
			}
		}

		[DisplayName("Selected Border Width"), Category("Sealed Class")]
		[Description("The border width for sealed classes when it is selected.")]
		[DefaultValue(2)]
		public int SealedClassSelectedBorderWidth
		{
			get
			{
				return sealedClassSelectedBorderWidth;
			}
			set
			{
				if (value < 1)
					sealedClassSelectedBorderWidth = 1;
				else
					sealedClassSelectedBorderWidth = value;
			}
		}

		[DisplayName("Dashed Border"), Category("Sealed Class")]
		[Description("Whether the border for sealed classes will be dashed " +
			"when it is not selected.")]
		[DefaultValue(false)]
		public bool IsSealedClassBorderDashed
		{
			get { return isSealedClassBorderDashed; }
			set { isSealedClassBorderDashed = value; }
		}

		[DisplayName("Dashed Selected Border"), Category("Sealed Class")]
		[Description("Whether the border for sealed classes will be dashed " +
			"when it is selected.")]
		[DefaultValue(false)]
		public bool IsSealedClassSelectedBorderDashed
		{
			get { return isSealedClassSelectedBorderDashed; }
			set { isSealedClassSelectedBorderDashed = value; }
		}

		[DisplayName("Border Width"), Category("Static Class")]
		[Description("The border width for static classes when it is not selected.")]
		[DefaultValue(1)]
		public int StaticClassBorderWidth
		{
			get
			{
				return staticClassBorderWidth;
			}
			set
			{
				if (value < 1)
					staticClassBorderWidth = 1;
				else
					staticClassBorderWidth = value;
			}
		}

		[DisplayName("Selected Border Width"), Category("Static Class")]
		[Description("The border width for static classes when it is selected.")]
		[DefaultValue(2)]
		public int StaticClassSelectedBorderWidth
		{
			get
			{
				return staticClassSelectedBorderWidth;
			}
			set
			{
				if (value < 1)
					staticClassSelectedBorderWidth = 1;
				else
					staticClassSelectedBorderWidth = value;
			}
		}

		[DisplayName("Dashed Border"), Category("Static Class")]
		[Description("Whether the border for static classes will be dashed " +
			"when it is not selected.")]
		[DefaultValue(false)]
		public bool IsStaticClassBorderDashed
		{
			get { return isStaticClassBorderDashed; }
			set { isStaticClassBorderDashed = value; }
		}

		[DisplayName("Dashed Selected Border"), Category("Static Class")]
		[Description("Whether the border for static classes will be dashed " +
			"when it is selected.")]
		[DefaultValue(false)]
		public bool IsStaticClassSelectedBorderDashed
		{
			get { return isStaticClassSelectedBorderDashed; }
			set { isStaticClassSelectedBorderDashed = value; }
		}

		#endregion

		#region Struct properties

		[DisplayName("Background Color"), Category("Struct")]
		[Description("The background color for the struct type.")]
		[DefaultValue(typeof(Color), "White")]
		public Color StructBackgroundColor
		{
			get { return structBackgroundColor; }
			set { structBackgroundColor = value; }
		}

		[DisplayName("Border Color"), Category("Struct")]
		[Description("The border color for the struct type when it is not selected.")]
		[DefaultValue(typeof(Color), "Black")]
		public Color StructBorderColor
		{
			get { return structBorderColor; }
			set { structBorderColor = value; }
		}

		[DisplayName("Border Width"), Category("Struct")]
		[Description("The border width for the struct type when it is not selected.")]
		[DefaultValue(1)]
		public int StructBorderWidth
		{
			get
			{
				return structBorderWidth;
			}
			set
			{
				if (value < 1)
					structBorderWidth = 1;
				else
					structBorderWidth = value;
			}
		}

		[DisplayName("Dashed Border"), Category("Struct")]
		[Description("Whether the border for the struct type will be dashed " +
			"when it is not selected.")]
		[DefaultValue(false)]
		public bool IsStructBorderDashed
		{
			get { return isStructBorderDashed; }
			set { isStructBorderDashed = value; }
		}

		[DisplayName("Dashed Selected Border"), Category("Struct")]
		[Description("Whether the border for the struct type will be dashed " +
			"when it is selected.")]
		[DefaultValue(false)]
		public bool IsStructSelectedBorderDashed
		{
			get { return isStructSelectedBorderDashed; }
			set { isStructSelectedBorderDashed = value; }
		}

		[DisplayName("Header Color"), Category("Struct")]
		[Description("The background color of the header compartment for the struct type.")]
		[DefaultValue(typeof(Color), "White")]
		public Color StructHeaderColor
		{
			get { return structHeaderColor; }
			set { structHeaderColor = value; }
		}

		[DisplayName("Rounding Size"), Category("Struct")]
		[Description("The rounding size of the corners for the struct type.")]
		[DefaultValue(0)]
		public int StructRoundingSize
		{
			get
			{
				return structRoundingSize;
			}
			set
			{
				if (value < 0)
					structRoundingSize = 0;
				else
					structRoundingSize = value;
			}
		}

		[DisplayName("Selected Border Color"), Category("Struct")]
		[Description("The border color for the struct type when it is selected.")]
		[DefaultValue(typeof(Color), "Black")]
		public Color StructSelectedBorderColor
		{
			get { return structSelectedBorderColor; }
			set { structSelectedBorderColor = value; }
		}

		[DisplayName("Selected Border Width"), Category("Struct")]
		[Description("The border width for the struct type when it is selected.")]
		[DefaultValue(2)]
		public int StructSelectedBorderWidth
		{
			get
			{
				return structSelectedBorderWidth;
			}
			set
			{
				if (value < 1)
					structSelectedBorderWidth = 1;
				else
					structSelectedBorderWidth = value;
			}
		}

		[DisplayName("Use Gradient Header"), Category("Struct")]
		[Description("Whether use gradient background colors in the " +
			"header compartment for the struct type.")]
		[DefaultValue(false)]
		public bool StructUseGradientHeader
		{
			get { return structUseGradientHeader; }
			set { structUseGradientHeader = value; }
		}

		#endregion

		#region Interface properties

		[DisplayName("Background Color"), Category("Interface")]
		[Description("The background color for the interface type.")]
		[DefaultValue(typeof(Color), "White")]
		public Color InterfaceBackgroundColor
		{
			get { return interfaceBackgroundColor; }
			set { interfaceBackgroundColor = value; }
		}

		[DisplayName("Border Color"), Category("Interface")]
		[Description("The border color for the interface type when it is not selected.")]
		[DefaultValue(typeof(Color), "Black")]
		public Color InterfaceBorderColor
		{
			get { return interfaceBorderColor; }
			set { interfaceBorderColor = value; }
		}

		[DisplayName("Border Width"), Category("Interface")]
		[Description("The border width for the interface type when it is not selected.")]
		[DefaultValue(1)]
		public int InterfaceBorderWidth
		{
			get
			{
				return interfaceBorderWidth;
			}
			set
			{
				if (value < 1)
					interfaceBorderWidth = 1;
				else
					interfaceBorderWidth = value;
			}
		}

		[DisplayName("Dashed Border"), Category("Interface")]
		[Description("Whether the border for the interface type will be dashed " +
			"when it is not selected.")]
		[DefaultValue(false)]
		public bool IsInterfaceBorderDashed
		{
			get { return isInterfaceBorderDashed; }
			set { isInterfaceBorderDashed = value; }
		}

		[DisplayName("Dashed Selected Border"), Category("Interface")]
		[Description("Whether the border for the interface type will be dashed " +
			"when it is selected.")]
		[DefaultValue(false)]
		public bool IsInterfaceSelectedBorderDashed
		{
			get { return isInterfaceSelectedBorderDashed; }
			set { isInterfaceSelectedBorderDashed = value; }
		}

		[DisplayName("Header Color"), Category("Interface")]
		[Description("The background color of the header compartment for the interface type.")]
		[DefaultValue(typeof(Color), "White")]
		public Color InterfaceHeaderColor
		{
			get { return interfaceHeaderColor; }
			set { interfaceHeaderColor = value; }
		}

		[DisplayName("Rounding Size"), Category("Interface")]
		[Description("The rounding size of the corners for the interface type.")]
		[DefaultValue(0)]
		public int InterfaceRoundingSize
		{
			get
			{
				return interfaceRoundingSize;
			}
			set
			{
				if (value < 0)
					interfaceRoundingSize = 0;
				else
					interfaceRoundingSize = value;
			}
		}

		[DisplayName("Selected Border Color"), Category("Interface")]
		[Description("The border color for the interface type when it is selected.")]
		[DefaultValue(typeof(Color), "Black")]
		public Color InterfaceSelectedBorderColor
		{
			get { return interfaceSelectedBorderColor; }
			set { interfaceSelectedBorderColor = value; }
		}

		[DisplayName("Selected Border Width"), Category("Interface")]
		[Description("The border width for the interface type when it is selected.")]
		[DefaultValue(2)]
		public int InterfaceSelectedBorderWidth
		{
			get
			{
				return interfaceSelectedBorderWidth;
			}
			set
			{
				if (value < 1)
					interfaceSelectedBorderWidth = 1;
				else
					interfaceSelectedBorderWidth = value;
			}
		}

		[DisplayName("Use Gradient Header"), Category("Interface")]
		[Description("Whether use gradient background colors in the " +
			"header compartment for the interface type.")]
		[DefaultValue(false)]
		public bool InterfaceUseGradientHeader
		{
			get { return interfaceUseGradientHeader; }
			set { interfaceUseGradientHeader = value; }
		}

		#endregion

		#region Enum properties

		[DisplayName("Background Color"), Category("Enum")]
		[Description("The background color for the enum type.")]
		[DefaultValue(typeof(Color), "White")]
		public Color EnumBackgroundColor
		{
			get { return enumBackgroundColor; }
			set { enumBackgroundColor = value; }
		}

		[DisplayName("Border Color"), Category("Enum")]
		[Description("The border color for the enum type when it is not selected.")]
		[DefaultValue(typeof(Color), "Black")]
		public Color EnumBorderColor
		{
			get { return enumBorderColor; }
			set { enumBorderColor = value; }
		}

		[DisplayName("Border Width"), Category("Enum")]
		[Description("The border width for the enum type when it is not selected.")]
		[DefaultValue(1)]
		public int EnumBorderWidth
		{
			get
			{
				return enumBorderWidth;
			}
			set
			{
				if (value < 1)
					enumBorderWidth = 1;
				else
					enumBorderWidth = value;
			}
		}

		[DisplayName("Dashed Border"), Category("Enum")]
		[Description("Whether the border for the enum type will be dashed " +
			"when it is not selected.")]
		[DefaultValue(false)]
		public bool IsEnumBorderDashed
		{
			get { return isEnumBorderDashed; }
			set { isEnumBorderDashed = value; }
		}

		[DisplayName("Dashed Selected Border"), Category("Enum")]
		[Description("Whether the border for the enum type will be dashed " +
			"when it is selected.")]
		[DefaultValue(false)]
		public bool IsEnumSelectedBorderDashed
		{
			get { return isEnumSelectedBorderDashed; }
			set { isEnumSelectedBorderDashed = value; }
		}

		[DisplayName("Header Color"), Category("Enum")]
		[Description("The background color of the header compartment for the enum type.")]
		[DefaultValue(typeof(Color), "White")]
		public Color EnumHeaderColor
		{
			get { return enumHeaderColor; }
			set { enumHeaderColor = value; }
		}

		[DisplayName("Item Color"), Category("Enum")]
		[Description("The text color of an enumerator item.")]
		[DefaultValue(typeof(Color), "Black")]
		public Color EnumItemColor
		{
			get { return enumItemColor; }
			set { enumItemColor = value; }
		}

		[DisplayName("Rounding Size"), Category("Enum")]
		[Description("The rounding size of the corners for the enum type.")]
		[DefaultValue(0)]
		public int EnumRoundingSize
		{
			get
			{
				return enumRoundingSize;
			}
			set
			{
				if (value < 0)
					enumRoundingSize = 0;
				else
					enumRoundingSize = value;
			}
		}

		[DisplayName("Selected Border Color"), Category("Enum")]
		[Description("The border color for the enum type when it is selected.")]
		[DefaultValue(typeof(Color), "Black")]
		public Color EnumSelectedBorderColor
		{
			get { return enumSelectedBorderColor; }
			set { enumSelectedBorderColor = value; }
		}

		[DisplayName("Selected Border Width"), Category("Enum")]
		[Description("The border width for the enum type when it is selected.")]
		[DefaultValue(2)]
		public int EnumSelectedBorderWidth
		{
			get
			{
				return enumSelectedBorderWidth;
			}
			set
			{
				if (value < 1)
					enumSelectedBorderWidth = 1;
				else
					enumSelectedBorderWidth = value;
			}
		}

		[DisplayName("Use Gradient Header"), Category("Enum")]
		[Description("Whether use gradient background colors in the " +
			"header compartment for the enum type.")]
		[DefaultValue(false)]
		public bool EnumUseGradientHeader
		{
			get { return enumUseGradientHeader; }
			set { enumUseGradientHeader = value; }
		}

		#endregion

		#region Delegate properties

		[DisplayName("Background Color"), Category("Delegate")]
		[Description("The background color for the delegate type.")]
		[DefaultValue(typeof(Color), "White")]
		public Color DelegateBackgroundColor
		{
			get { return delegateBackgroundColor; }
			set { delegateBackgroundColor = value; }
		}

		[DisplayName("Border Color"), Category("Delegate")]
		[Description("The border color for the delegate type when it is not selected.")]
		[DefaultValue(typeof(Color), "Black")]
		public Color DelegateBorderColor
		{
			get { return delegateBorderColor; }
			set { delegateBorderColor = value; }
		}

		[DisplayName("Border Width"), Category("Delegate")]
		[Description("The border width for the delegate type when it is not selected.")]
		[DefaultValue(1)]
		public int DelegateBorderWidth
		{
			get
			{
				return delegateBorderWidth;
			}
			set
			{
				if (value < 1)
					delegateBorderWidth = 1;
				else
					delegateBorderWidth = value;
			}
		}

		[DisplayName("Dashed Border"), Category("Delegate")]
		[Description("Whether the border for the delegate type will be dashed " +
			"when it is not selected.")]
		[DefaultValue(false)]
		public bool IsDelegateBorderDashed
		{
			get { return isDelegateBorderDashed; }
			set { isDelegateBorderDashed = value; }
		}

		[DisplayName("Dashed Selected Border"), Category("Delegate")]
		[Description("Whether the border for the delegate type will be dashed " +
			"when it is selected.")]
		[DefaultValue(false)]
		public bool IsDelegateSelectedBorderDashed
		{
			get { return isDelegateSelectedBorderDashed; }
			set { isDelegateSelectedBorderDashed = value; }
		}

		[DisplayName("Header Color"), Category("Delegate")]
		[Description("The background color of the header compartment for the delegate type.")]
		[DefaultValue(typeof(Color), "White")]
		public Color DelegateHeaderColor
		{
			get { return delegateHeaderColor; }
			set { delegateHeaderColor = value; }
		}

		[DisplayName("Parameter Color"), Category("Delegate")]
		[Description("The text color of a delegate's parameters.")]
		[DefaultValue(typeof(Color), "Black")]
		public Color DelegateParameterColor
		{
			get { return delegateParameterColor; }
			set { delegateParameterColor = value; }
		}

		[DisplayName("Rounding Size"), Category("Delegate")]
		[Description("The rounding size of the corners for the delegate type.")]
		[DefaultValue(0)]
		public int DelegateRoundingSize
		{
			get
			{
				return delegateRoundingSize;
			}
			set
			{
				if (value < 0)
					delegateRoundingSize = 0;
				else
					delegateRoundingSize = value;
			}
		}

		[DisplayName("Selected Border Color"), Category("Delegate")]
		[Description("The border color for the delegate type when it is selected.")]
		[DefaultValue(typeof(Color), "Black")]
		public Color DelegateSelectedBorderColor
		{
			get { return delegateSelectedBorderColor; }
			set { delegateSelectedBorderColor = value; }
		}

		[DisplayName("Selected Border Width"), Category("Delegate")]
		[Description("The border width for the delegate type when it is selected.")]
		[DefaultValue(2)]
		public int DelegateSelectedBorderWidth
		{
			get
			{
				return delegateSelectedBorderWidth;
			}
			set
			{
				if (value < 1)
					delegateSelectedBorderWidth = 1;
				else
					delegateSelectedBorderWidth = value;
			}
		}

		[DisplayName("Use Gradient Header"), Category("Delegate")]
		[Description("Whether use gradient background colors in the " +
			"header compartment for the delegate type.")]
		[DefaultValue(false)]
		public bool DelegateUseGradientHeader
		{
			get { return delegateUseGradientHeader; }
			set { delegateUseGradientHeader = value; }
		}

		#endregion

		#region Comment properties

		[DisplayName("Background Color"), Category("Comment")]
		[Description("The background color for the comment.")]
		[DefaultValue(typeof(Color), "White")]
		public Color CommentBackColor
		{
			get { return commentBackColor; }
			set { commentBackColor = value; }
		}

		[DisplayName("Border Color"), Category("Comment")]
		[Description("The border color for the comment when it is not selected.")]
		[DefaultValue(typeof(Color), "Black")]
		public Color CommentBorderColor
		{
			get { return commentBorderColor; }
			set { commentBorderColor = value; }
		}

		[DisplayName("Border Width"), Category("Comment")]
		[Description("The border width for the comment when it is not selected.")]
		[DefaultValue(1)]
		public int CommentBorderWidth
		{
			get
			{
				return commentBorderWidth;
			}
			set
			{
				if (value < 1)
					commentBorderWidth = 1;
				else
					commentBorderWidth = value;
			}
		}

		[DisplayName("Dashed Border"), Category("Comment")]
		[Description("Whether the border for the comment will be dashed " +
			"when it is not selected.")]
		[DefaultValue(false)]
		public bool IsCommentBorderDashed
		{
			get { return isCommentBorderDashed; }
			set { isCommentBorderDashed = value; }
		}

		[DisplayName("Dashed Selected Border"), Category("Comment")]
		[Description("Whether the border for the comment will be dashed " +
			"when it is selected.")]
		[DefaultValue(false)]
		public bool IsCommentSelectedBorderDashed
		{
			get { return isCommentSelectedBorderDashed; }
			set { isCommentSelectedBorderDashed = value; }
		}

		[DisplayName("Font"), Category("Comment")]
		[Description("The font of the displayed text for the comment.")]
		public Font CommentFont
		{
			get
			{
				return commentFont;
			}
			set
			{
				if (value != null) {
					commentFont.Dispose();
					commentFont = value;
				}
			}
		}

		[DisplayName("Margin Size"), Category("Comment")]
		[Description("The distance between the comment's edges and its text.")]
		[DefaultValue(10)]
		public int CommentMarginSize
		{
			get
			{
				return commentMarginSize;
			}
			set
			{
				if (value < 0)
					commentMarginSize = 0;
				else
					commentMarginSize = value;
			}
		}

		[DisplayName("Selected Border Color"), Category("Comment")]
		[Description("The border color for the comment when it is selected.")]
		[DefaultValue(typeof(Color), "Black")]
		public Color CommentSelectedBorderPenColor
		{
			get { return commentSelectedBorderColor; }
			set { commentSelectedBorderColor = value; }
		}

		[DisplayName("Selected Border Width"), Category("Comment")]
		[Description("The border width for the comment when it is selected.")]
		[DefaultValue(2)]
		public int CommentSelectedBorderWidth
		{
			get
			{
				return commentSelectedBorderWidth;
			}
			set
			{
				if (value < 1)
					commentSelectedBorderWidth = 1;
				else
					commentSelectedBorderWidth = value;
			}
		}

		[DisplayName("Text Color"), Category("Comment")]
		[Description("The text color for the comment.")]
		[DefaultValue(typeof(Color), "Black")]
		public Color CommentTextColor
		{
			get { return textColor; }
			set { textColor = value; }
		}

		#endregion

		#region Relation properties

		[DisplayName("Background Color"), Category("(Relation)")]
		[Description("The background color for the relation.")]
		[DefaultValue(typeof(Color), "White")]
		public Color RelationBackgroundColor
		{
			get { return relationBackgroundColor; }
			set { relationBackgroundColor = value; }
		}

		[DisplayName("Dash Size"), Category("(Relation)")]
		[Description("The lengths of alternating dashes and spaces in dashed lines.")]
		[DefaultValue(5)]
		public int RelationDashSize
		{
			get
			{
				return relationDashSize;
			}
			set
			{
				if (value < 1)
					relationDashSize = 1;
				else
					relationDashSize = value;
			}
		}

		[DisplayName("Fore Color"), Category("(Relation)")]
		[Description("The line color for the relation.")]
		[DefaultValue(typeof(Color), "Black")]
		public Color RelationForeColor
		{
			get { return relationForeColor; }
			set { relationForeColor = value; }
		}

		[DisplayName("Selected Fore Color"), Category("(Relation)")]
		[Description("The line color for the selected relation.")]
		[DefaultValue(typeof(Color), "Black")]
		public Color RelationSelectedForeColor
		{
			get { return relationSelectedForeColor; }
			set { relationSelectedForeColor = value; }
		}

		[DisplayName("Selected Width"), Category("(Relation)")]
		[Description("The width of the selected relation line.")]
		[DefaultValue(2)]
		public int RelationSelectedWidth
		{
			get
			{
				return relationSelectedWidth;
			}
			set
			{
				if (value < 1)
					relationSelectedWidth = 1;
				else
					relationSelectedWidth = value;
			}
		}

		[DisplayName("Width"), Category("(Relation)")]
		[Description("The width of the relation line.")]
		[DefaultValue(1)]
		public int RelationWidth
		{
			get
			{
				return relationWidth;
			}
			set
			{
				if (value < 1)
					relationWidth = 1;
				else
					relationWidth = value;
			}
		}

		#endregion

		public object Clone()
		{
			Style newStyle = (Style) this.MemberwiseClone();

			newStyle.nameFont = (Font) NameFont.Clone();
			newStyle.abstractNameFont = (Font) AbstractNameFont.Clone();
			newStyle.identifierFont = (Font) IdentifierFont.Clone();
			newStyle.memberFont = (Font) MemberFont.Clone();
			newStyle.staticMemberFont = (Font) StaticMemberFont.Clone();
			newStyle.abstractMemberFont = (Font) AbstractMemberFont.Clone();
			newStyle.commentFont = (Font) CommentFont.Clone();

			return newStyle;
		}

		public void Dispose()
		{
			if (nameFont != null)
				nameFont.Dispose();

			if (abstractNameFont != null)
				abstractNameFont.Dispose();

			if (identifierFont != null)
				identifierFont.Dispose();

			if (memberFont != null)
				memberFont.Dispose();

			if (staticMemberFont != null)
				staticMemberFont.Dispose();

			if (abstractMemberFont != null)
				abstractMemberFont.Dispose();

			if (commentFont != null)
				commentFont.Dispose();
		}

		private static bool LoadCurrentStyle()
		{
			return ((CurrentStyle = Load(stylePath)) != null);
		}

		private static bool SaveCurrentStyle()
		{
			return CurrentStyle.Save(stylePath);
		}

		public static Style Load(string path)
		{
			try {
				using (Stream stream = new FileStream(path, FileMode.Open)) {
					BinaryFormatter formatter = new BinaryFormatter();
					Style result = (Style) formatter.Deserialize(stream);

					// If succeded
					return result;
				}
			}
			catch {
				return null;
			}
		}

		public bool Save(string path)
		{
			try {
				using (Stream stream = new FileStream(path, FileMode.Create)) {
					BinaryFormatter formatter = new BinaryFormatter();
					formatter.Serialize(stream, this);
				}
				return true;
			}
			catch {
				return false;
			}
		}
	}
}
