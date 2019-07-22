using System;
using System.Xml;
using System.Drawing;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using NClass.Core;

namespace NClass.GUI.Diagram
{
	public abstract class EntityShape : Control, IDiagramElement
	{
		bool isSelected = false;
		List<TerminalNode> terminalNodes = new List<TerminalNode>();

		IContainer components;
		ContextMenuStrip contextMenu;
		ToolStripMenuItem mnuCopyToClipboard;
		ToolStripMenuItem mnuDelete;

		public event EventHandler SelectionChanged;
		public event EventHandler ContentsChanged;
		public event EventHandler Delete;

		protected EntityShape()
		{
			this.MinimumSize = new Size(50, 50);
			this.ResizeRedraw = true;
			this.DoubleBuffered = true;
			this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);

			InitContextMenu();
		}

		public bool IsSelected
		{
			get
			{
				return isSelected;
			}
			set
			{
				if (value != isSelected) {
					isSelected = value;
					if (value)
						this.BringToFront();
					Invalidate();
					OnSelectionChanged(EventArgs.Empty);
				}
				else {
					isSelected = value;
				}
			}
		}

		protected int MinHeight
		{
			get
			{
				return MinimumSize.Height;
			}
			set
			{
				if (value != MinimumSize.Height)
					MinimumSize = new Size(MinimumSize.Width, value);
			}
		}

		internal List<TerminalNode> TerminalNodes
		{
			get { return terminalNodes; }
		}

		public abstract Entity Entity
		{
			get;
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
				components.Dispose();

			base.Dispose(disposing);
		}

		protected virtual void InitContextMenu()
		{
			components = new Container();
			contextMenu = new ContextMenuStrip(components);
			
			mnuCopyToClipboard = new ToolStripMenuItem(
				"menu_copy_image_to_clipboard", Properties.Resources.Image,
				new EventHandler(mnuCopyImage_Click));
			mnuDelete = new ToolStripMenuItem(
				"menu_delete", Properties.Resources.Delete,
				new EventHandler(mnuDelete_Click));

			contextMenu.Items.Add(mnuCopyToClipboard);
			contextMenu.Items.Add(mnuDelete);

			this.ContextMenuStrip = contextMenu;
		}

		protected virtual void UpdateContextMenu()
		{
			mnuCopyToClipboard.Text = "menu_copy_image_to_clipboard";
			mnuDelete.Text = "menu_delete";
		}

		private void Texts_LanguageChanged(object sender, EventArgs e)
		{
			UpdateContextMenu();
		}

		/// <exception cref="ArgumentNullException">
		/// <paramref name="node"/> is null.
		/// </exception>
		public void Serialize(XmlNode node)
		{
			if (node == null)
				throw new ArgumentNullException("node");

			XmlElement child;
			
			child = node.OwnerDocument.CreateElement("Location");
			child.SetAttribute("left", Left.ToString());
			child.SetAttribute("top", Top.ToString());
			node.AppendChild(child);

			child = node.OwnerDocument.CreateElement("Size");
			child.SetAttribute("width", Width.ToString());
			child.SetAttribute("height", Height.ToString());
			node.AppendChild(child);
		}

		/// <exception cref="ArgumentNullException">
		/// <paramref name="node"/> is null.
		/// </exception>
		public void Deserialize(XmlNode node)
		{
			if (node == null)
				throw new ArgumentNullException("node");

			XmlElement child;

			child = node["Location"];
			if (child != null) {
				int left, top;

				int.TryParse(child.GetAttribute("left"), out left);
				int.TryParse(child.GetAttribute("top"), out top);
				this.Location = new Point(left, top);
			}

			child = node["Size"];
			if (child != null) {
				int width, height;

				int.TryParse(child.GetAttribute("width"), out width);
				int.TryParse(child.GetAttribute("height"), out height);
				this.Size = new Size(width, height);
			}
		}

		private void mnuCopyImage_Click(object sender, EventArgs e)
		{
			CopyToClipboard();
		}

		private void mnuDelete_Click(object sender, EventArgs e)
		{
			if (Delete != null)
				Delete(this, e);
		}

		private void CopyToClipboard()
		{
			//TODO: jók a méretek kicsinyítésnél is?
			using (Image image = new Bitmap(Width, Height))
			using (Graphics g = Graphics.FromImage(image))
			{
				g.Clear(Color.White);
				Draw(g, Point.Empty, 1.0F);
				Clipboard.SetImage(image);
			}
		}

		protected virtual void OnSelectionChanged(EventArgs e)
		{
			if (SelectionChanged != null)
				SelectionChanged(this, e);
		}

		protected virtual void OnContentsChanged(EventArgs e)
		{
			if (ContentsChanged != null)
				ContentsChanged(this, e);
		}

		protected override void OnMouseDown(MouseEventArgs e)
		{
			OnEnter(EventArgs.Empty);
			base.OnMouseDown(e);
		}

		protected override void OnMove(EventArgs e)
		{
			base.OnMove(e);
			for (int i = 0; i < TerminalNodes.Count; i++)
				TerminalNodes[i].IsDirty = true;
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			Draw(e.Graphics, Point.Empty, 1.0F, true);
		}

		public virtual void TrySelect(Rectangle selectionRectangle)
		{
			Rectangle rectangle = new Rectangle(Location, Size);

			if (selectionRectangle.IntersectsWith(rectangle))
				IsSelected = true;
		}

		public void Draw(Graphics g, Point position)
		{
			Draw(g, position, 1.0F, false);
		}

		public void Draw(Graphics g, Point position, float zoom)
		{
			Draw(g, position, zoom, false);
		}

		protected abstract void Draw(Graphics g, Point position, float zoom, bool onScreen);
	}
}
