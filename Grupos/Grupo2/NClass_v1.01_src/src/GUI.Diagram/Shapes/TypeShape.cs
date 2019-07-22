using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using NClass.Core;

namespace NClass.GUI.Diagram
{
	public abstract class TypeShape : EntityShape
	{
		protected const int IconSpacing = 3;

		static SolidBrush backgroundBrush = new SolidBrush(Color.White);
		static Pen borderPen = new Pen(Color.Black);
		static SolidBrush nameBrush = new SolidBrush(Color.Black);
		static SolidBrush identifierBrush = new SolidBrush(Color.Black);
		static StringFormat stringFormat = new StringFormat(StringFormat.GenericTypographic);

		ToolStripMenuItem mnuEdit;

		protected abstract Color BackgroundColor { get; }

		protected abstract Color HeaderColor { get; }

		protected abstract bool UseGradientHeader { get; }

		protected abstract Color BorderColor { get; }

		protected abstract int BorderWidth { get; }

		protected abstract bool IsBorderDashed { get; }

		protected abstract bool IsSelectedBorderDashed { get; }

		protected abstract Color SelectedBorderColor { get; }

		protected abstract int SelectedBorderWidth { get; }

		protected abstract int RoundingSize { get; }

		protected virtual Font NameFont
		{
			get { return Style.CurrentStyle.NameFont; }
		}

		private Font IdentifierFont
		{
			get { return Style.CurrentStyle.IdentifierFont; }
		}

		protected override Size DefaultSize
		{
			get
			{
				return new Size(162, 216);
			}
		}

		public override Font Font
		{
			get
			{
				return Style.CurrentStyle.MemberFont;
			}
			set
			{
				base.Font = value;
			}
		}

		private int MarginSize
		{
			get { return Style.CurrentStyle.MarginSize; }
		}

		private RectangleF MarginBounds
		{
			get
			{
				return new RectangleF(MarginSize, MarginSize,
					Width - 2 * MarginSize, Height - 2 * MarginSize);
			}
		}

		protected int HeaderHeight
		{
			get
			{
				float nameHeight = NameFont.GetHeight();
				float identifierHeight = IdentifierFont.GetHeight();

				if (Style.CurrentStyle.HeaderHeight == 0) {
					if (HasIdentifier)
						return (int) (nameHeight + identifierHeight) + MarginSize * 2;
					else
						return (int) (nameHeight) + MarginSize * 2;
				}
				else {
					return Style.CurrentStyle.HeaderHeight;
				}
			}
		}

		private bool HasIdentifier
		{
			get
			{
				return (Style.CurrentStyle.ShowSignature ||
					(Style.CurrentStyle.ShowStereotype && Entity is TypeBase &&
					((TypeBase) Entity).Stereotype != null));
			}
		}

		protected abstract void EditItems();

		private void mnuEditMembers_Click(object sender, EventArgs e)
		{
			EditItems();
		}

		protected override void OnDoubleClick(EventArgs e)
		{
			EditItems();
		}

		protected override void InitContextMenu()
		{
			base.InitContextMenu();

			mnuEdit = new ToolStripMenuItem("menu_edit_members",
				Properties.Resources.EditMembers, new EventHandler(mnuEditMembers_Click));

			ContextMenuStrip.Items.Add("-");
			ContextMenuStrip.Items.Add(mnuEdit);
		}

		protected override void UpdateContextMenu()
		{
			base.UpdateContextMenu();
			mnuEdit.Text = "menu_edit_members";
		}

		private void UpdateStyles(bool onScreen)
		{
			backgroundBrush.Color = BackgroundColor;
			nameBrush.Color = Style.CurrentStyle.NameColor;
			identifierBrush.Color = Style.CurrentStyle.IdentifierColor;

			if (IsSelected && onScreen) {
				borderPen.Color = SelectedBorderColor;
				borderPen.Width = SelectedBorderWidth;
				borderPen.DashStyle = (IsSelectedBorderDashed) ?
					DashStyle.Dash : DashStyle.Solid;
			}
			else {
				borderPen.Color = BorderColor;
				borderPen.Width = BorderWidth;
				borderPen.DashStyle = (IsBorderDashed) ? DashStyle.Dash : DashStyle.Solid;
			}
			borderPen.DashCap = (borderPen.Width == 1) ? DashCap.Round : DashCap.Flat;

			stringFormat.Alignment = GetHorizontalAlignment(
				Style.CurrentStyle.HeaderAlignment);
		}

		private static StringAlignment GetHorizontalAlignment(ContentAlignment alignment)
		{
			switch (alignment) {
				case ContentAlignment.BottomLeft:
				case ContentAlignment.MiddleLeft:
				case ContentAlignment.TopLeft:
					return StringAlignment.Near;

				case ContentAlignment.BottomCenter:
				case ContentAlignment.MiddleCenter:
				case ContentAlignment.TopCenter:
				default:
					return StringAlignment.Center;

				case ContentAlignment.BottomRight:
				case ContentAlignment.MiddleRight:
				case ContentAlignment.TopRight:
					return StringAlignment.Far;
			}
		}

		private static StringAlignment GetVerticalAlignment(ContentAlignment alignment)
		{
			switch (alignment) {
				case ContentAlignment.TopLeft:
				case ContentAlignment.TopCenter:
				case ContentAlignment.TopRight:
					return StringAlignment.Near;

				case ContentAlignment.MiddleLeft:
				case ContentAlignment.MiddleCenter:
				case ContentAlignment.MiddleRight:
				default:
					return StringAlignment.Center;

				case ContentAlignment.BottomLeft:
				case ContentAlignment.BottomCenter:
				case ContentAlignment.BottomRight:
					return StringAlignment.Far;
			}
		}

		protected void DrawLine(Graphics g, int height)
		{
			Region region = g.Clip;
			g.ResetClip();

			int padding = (int) borderPen.Width / 2;
			g.DrawLine(borderPen, padding, height, Width - padding - 1, height);

			g.Clip = region;
		}

		private void DrawSurface(Graphics g)
		{
			int roundingSize = RoundingSize;
			int padding = (int) borderPen.Width / 2;
			GraphicsPath path = new GraphicsPath();

			if (roundingSize == 0) {
				path.AddRectangle(new Rectangle(padding, padding,
					Width - padding * 2 - 1, Height - padding * 2 - 1));
			}
			else {
				path.AddArc(padding, padding, roundingSize * 2, roundingSize * 2, 180, 90);

				path.AddArc(Width - roundingSize * 2 - padding - 1, padding,
					roundingSize * 2, roundingSize * 2, 270, 90);

				path.AddArc(Width - roundingSize * 2 - padding - 1,
					Height - roundingSize * 2 - padding - 1,
					roundingSize * 2, roundingSize * 2, 0, 90);

				path.AddArc(padding, Height - roundingSize * 2 - padding - 1,
					roundingSize * 2, roundingSize * 2, 90, 90);

				path.CloseFigure();
			}

			// Drawing background
			Region region = new Region(path);
			Brush headerBrush;

			if (UseGradientHeader) {
				headerBrush = new LinearGradientBrush(new Rectangle(0, 0, Width, HeaderHeight),
					HeaderColor, BackgroundColor, LinearGradientMode.Horizontal);
			}
			else {
				headerBrush = new SolidBrush(HeaderColor);
			}
			region.Exclude(new Rectangle(0, HeaderHeight, Width, Height));
			g.FillPath(backgroundBrush, path);
			g.FillRegion(headerBrush, region);

			// Drawing border
			g.DrawPath(borderPen, path);

			path.Dispose();
			region.Dispose();
			headerBrush.Dispose();
		}

		private static float GetHeaderTextTop(RectangleF textArea, float textHeight,
			ContentAlignment alignment)
		{
			float top = textArea.Top;

			switch (alignment) {
				case ContentAlignment.BottomLeft:
				case ContentAlignment.BottomCenter:
				case ContentAlignment.BottomRight:
					top += textArea.Height - textHeight;
					break;

				case ContentAlignment.MiddleLeft:
				case ContentAlignment.MiddleCenter:
				case ContentAlignment.MiddleRight:
					top += (textArea.Height - textHeight) / 2;
					break;
			}

			return top;
		}

		private void DrawHeaderText(Graphics g)
		{
			if (!(Entity is TypeBase))
				return;

			TypeBase type = (TypeBase) Entity;
			ContentAlignment alignment = Style.CurrentStyle.HeaderAlignment;

			RectangleF textArea;
			string name = type.Name;

			textArea = new RectangleF(MarginSize, MarginSize, Width - MarginSize * 2,
				HeaderHeight - MarginSize * 2 + 1);

			if (HasIdentifier) {
				string identifier = (Style.CurrentStyle.ShowSignature) ?
					type.Signature : type.Stereotype;
				float nameHeight = NameFont.GetHeight();
				float identifierHeight = IdentifierFont.GetHeight();
				float textHeight = nameHeight + identifierHeight;

				textArea.Y = GetHeaderTextTop(textArea, textHeight,
					Style.CurrentStyle.HeaderAlignment);
				textArea.Height = textHeight;

				// Drawing signature
				if (Style.CurrentStyle.ShowSignature) {
					stringFormat.LineAlignment = StringAlignment.Near;
					g.DrawString(name, NameFont, nameBrush, textArea, stringFormat);

					stringFormat.LineAlignment = StringAlignment.Far;
					g.DrawString(identifier, IdentifierFont, identifierBrush,
						textArea, stringFormat);
				}
				// Drawing stereotype
				else {
					stringFormat.LineAlignment = StringAlignment.Near;
					g.DrawString(type.Stereotype, IdentifierFont, identifierBrush,
						textArea, stringFormat);

					stringFormat.LineAlignment = StringAlignment.Far;
					g.DrawString(name, NameFont, nameBrush, textArea, stringFormat);
				}
			}
			else {
				stringFormat.LineAlignment = GetVerticalAlignment(alignment);
				g.DrawString(name, NameFont, nameBrush, textArea, stringFormat);
			}

			DrawLine(g, HeaderHeight);
		}

		protected abstract void DrawContent(Graphics g);

		protected override void Draw(Graphics g, Point position, float zoom, bool onScreen)
		{
			if (zoom == 1)
				g.SmoothingMode = SmoothingMode.AntiAlias;
			g.ScaleTransform(zoom, zoom);
			g.TranslateTransform(position.X, position.Y);

			UpdateStyles(onScreen);
			DrawSurface(g);
			using (Region region = new Region(MarginBounds)) {
				g.Clip = region;
				DrawHeaderText(g);
				DrawContent(g);
			}
			g.ResetTransform();
			g.ResetClip();
		}

		public override string ToString()
		{
			return Entity.ToString();
		}
	}
}
