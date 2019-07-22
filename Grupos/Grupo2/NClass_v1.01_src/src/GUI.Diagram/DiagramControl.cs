using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Xml;
using NClass.Core;

namespace NClass.GUI.Diagram
{
	public sealed partial class DiagramControl : Panel, IDiagramVisualizer
	{
		const int MarginSize = 2;
		const int ResizeMargin = 5;
		const int PrecisionSize = 10;
		static readonly Point defaultItemLocation = new Point(5, 5);
		static readonly Color transparentAlternativeColor = Color.FromArgb(194, 203, 207);

		public event EventHandler ContentsChanged;
		public event EventHandler SelectionChanged;
		public event EntityRemovedEventHandler EntityRemoved;
		public event RelationRemovedEventHandler RelationRemoved;
		public event ConnectionCreatedEventHandler ConnectionCreated;

		List<EntityShape> shapes = new List<EntityShape>();
		List<Connection> connections = new List<Connection>();

		// Connection variables
		bool connecting = false;
		RelationType relationType = new RelationType();
		TerminalNode startNode = null; //TODO: nem kéne globális változókat használni,
		TerminalNode endNode = null;   //      mert a previewConnection-ben benne vannak.
		PreviewConnection previewConnection = null;

		// Positioning variables
		bool shapePositioning = false;
		bool shapeHorizontalResizing = false;
		bool shapeVerticalResizing = false;
		Point oldMouseLocation = Point.Empty;
		Size oldSize = Size.Empty;
		TerminalNode modifyingNode = null;

		// Selectioning variables
		bool selecting = false;
		bool selectionChanged = false;
		bool selectionChanging = false;
		int selectedItemCount = 0;
		int selectionChangingSetCount = 0;
		Point selectionStartPoint = Point.Empty;
		Rectangle selectionRectangle = Rectangle.Empty;
		IDiagramElement firstSelectedItem = null;

		public DiagramControl()
		{
			this.AutoScroll = true;
			this.AutoScrollMinSize = new Size(Settings.CurrentSettings.WorkspaceWidth,
				Settings.CurrentSettings.WorkspaceHeight);
			this.BackColor = Style.CurrentStyle.DiagramBackColor;
			this.KeyDown += new KeyEventHandler(KeyDowned);
 		}

		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public override Color BackColor
		{
			get
			{
				return base.BackColor;
			}
			set
			{
				if (value.A < 255)
					base.BackColor = transparentAlternativeColor;
				else
					base.BackColor = value;
			}
		}

		[Browsable(false)]
		public int ItemCount
		{
			get
			{
				return (shapes.Count + connections.Count);
			}
		}
		
		[Browsable(false)]
		public IEnumerable<IDiagramElement> SelectedItems
		{
			get
			{
				for (int i = 0; i < shapes.Count; i++)
					if (shapes[i].IsSelected)
						yield return shapes[i];
				for (int i = 0; i < connections.Count; i++)
					if (connections[i].IsSelected)
						yield return connections[i];
			}
		}
		
		[Browsable(false)]
		public IDiagramElement FirstSelectedItem
		{
			get
			{
				if (SelectedItemCount > 0)
					return firstSelectedItem;
				else
					return null;
			}
		}

		[Browsable(false)]
		public int SelectedItemCount
		{
			get
			{
				return selectedItemCount;
			}
			private set
			{
				if (selectedItemCount != value) {
					selectedItemCount = value;
					OnSelectionChanged(EventArgs.Empty);
				}
				else {
					selectedItemCount = value;
				}
			}
		}

		private bool StartChosen
		{
			get
			{
				if (previewConnection != null)
					return previewConnection.StartChosen;
				else
					return false;
			}
			set
			{
				if (previewConnection != null)
					previewConnection.StartChosen = value;
			}
		}

		private bool EndChosen
		{
			get
			{
				if (previewConnection != null)
					return previewConnection.EndChosen;
				else
					return false;
			}
			set
			{
				if (previewConnection != null)
					previewConnection.EndChosen = value;
			}
		}

		private bool Connecting
		{
			get
			{
				return connecting;
			}
			set
			{
				if (value && !connecting) {
					startNode = new TerminalNode();
					endNode = new TerminalNode();
					previewConnection = new PreviewConnection(startNode, endNode);
					connections.Add(previewConnection);
					DeselectItems();
				}
				else if (!value && connecting) {
					if (StartChosen && EndChosen) {
						OnConnectionCreated(new ConnectionCreatedEventArgs(
							startNode.Shape.Entity, endNode.Shape.Entity, relationType));
						connections.Remove(previewConnection);
					}
					else {
						RemoveConnection(previewConnection);
					}
					startNode = null;
					endNode = null;
					previewConnection = null;
					Invalidate();
				}

				StartChosen = false;
				EndChosen = false;
				if (value) {
					startNode.Shape = null;
					endNode.Shape = null;
					Invalidate();
				}
				connecting = value;
			}
		}

		private bool ShapeResizing
		{
			get { return (shapeHorizontalResizing || shapeVerticalResizing); }
		}

		private bool ConnectionPositioning
		{
			get
			{
				return (Connecting && (startNode.Shape != null || endNode.Shape != null));
			}
		}

		private bool SelectionChanging
		{
			get
			{
				return selectionChanging;
			}
			set
			{
				if (value) {
					selectionChangingSetCount++;
					selectionChanging = value;
				}
				else {
					if (--selectionChangingSetCount < 0)
						selectionChangingSetCount = 0;

					if (selectionChangingSetCount == 0) {
						if (selectionChanged)
							OnSelectionChanged(EventArgs.Empty);
						selectionChanged = false;
						selectionChanging = false;
						Invalidate();
					}
				}
			}
		}

		private TerminalNode ModifyingNode
		{
			get
			{
				return modifyingNode;
			}
			set
			{
				if (value != null && modifyingNode == null)
					Cursor = Cursors.SizeAll;
				else if (value == null && modifyingNode != null)
					Cursor = Cursors.Default;

				modifyingNode = value;
			}
		}

		private bool OverTeminalNode
		{
			get { return (ModifyingNode != null); }
		}

		public override void Refresh()
		{
			BackColor = Style.CurrentStyle.DiagramBackColor;
			base.Refresh();
		}

		public void Clear()
		{
			shapes.Clear();
			connections.Clear();
			this.Controls.Clear();

			selecting = false;
			Connecting = false;
			SelectedItemCount = 0;
			Invalidate();
		}

		private Point GetNewLocation(Size shapeSize)
		{
			Point newLocation = defaultItemLocation;
			bool isEmpty = false;

			while (!isEmpty) {
				Rectangle selection = new Rectangle(newLocation, shapeSize);
				isEmpty = true;

				for (int i = 0; i < shapes.Count && isEmpty; i++) {
					Rectangle reserved = new Rectangle(shapes[i].Location, shapes[i].Size);
					if (selection.IntersectsWith(reserved)) {
						newLocation = new Point(defaultItemLocation.X,
							shapes[i].Bottom + defaultItemLocation.Y);
						isEmpty = false;
					}
				}
			}

			return newLocation;
		}

		/// <exception cref="ArgumentException">
		/// There is no type of <paramref name="entity"/>.
		/// </exception>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="entity"/> is null.
		/// </exception>
		public void AddEntity(Entity entity)
		{
			if (entity == null)
				throw new ArgumentNullException("entity");

			EntityShape shape = null;

			if (entity is ClassType)
				shape = new ClassShape((ClassType) entity);

			if (shape == null)
				throw new ArgumentException("Unknown type of entity.", "entity");

			shape.Location = GetNewLocation(shape.Size);
			shape.KeyDown += new KeyEventHandler(KeyDowned);
			shape.Enter += new EventHandler(Shape_Enter);
			shape.Move += new EventHandler(Shape_Move);
			shape.MouseDown += new MouseEventHandler(Shape_MouseDown);
			shape.MouseMove += new MouseEventHandler(Shape_MouseMove);
			shape.MouseUp += new MouseEventHandler(Shape_MouseUp);
			shape.Resize += new EventHandler(Shape_Resize);
			shape.ContentsChanged += new EventHandler(Item_ContentsChanged);
			shape.SelectionChanged += new EventHandler(Item_SelectionChanged);
			shape.Delete += new EventHandler(Item_Delete);
			shapes.Add(shape);
			this.Controls.Add(shape);

			Connecting = false;
			OnContentsChanged(EventArgs.Empty);
		}

		/// <exception cref="ArgumentException">
		/// There is no type of <paramref name="relation"/>.
		/// </exception>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="relation"/> is null.
		/// </exception>
		public void AddRelation(Relation relation, bool fromScreen)
		{
			if (relation == null)
				throw new ArgumentNullException("relation");

			Connection connection = null;

			if (!fromScreen || startNode == null || endNode == null) {
				startNode = new TerminalNode();
				endNode = new TerminalNode();

				for (int i = 0; i < shapes.Count; i++) {
					if (shapes[i].Entity == relation.First)
						startNode.Shape = shapes[i];
					if (shapes[i].Entity == relation.Second)
						endNode.Shape = shapes[i];
				}
			}

			startNode.IsDirty = true;
			endNode.IsDirty = true;

			if (relation is Association) {
				connection = new AssociationConnection(
					startNode, endNode, (Association) relation);
			}
			if (relation is Generalization) {
				connection = new GeneralizationConnection(
					startNode, endNode, (Generalization) relation);
			}
			if (relation is Realization) {
				connection = new RealizationConnection(
					startNode, endNode, (Realization) relation);
			}
			if (relation is Dependency) {
				connection = new DependencyConnection(
					startNode, endNode, (Dependency) relation);
			}
			if (relation is Nesting) {
				connection = new NestingConnection(
					startNode, endNode, (Nesting) relation);
			}
			if (relation is CommentRelation) {
				connection = new CommentConnection(
					startNode, endNode, (CommentRelation) relation);
			}

			if (connection == null)
				throw new ArgumentException("Unknown type of relation.", "relation");

			connection.ContentsChanged += new EventHandler(Item_ContentsChanged);
			connection.SelectionChanged += new EventHandler(Item_SelectionChanged);
			connection.Delete += new EventHandler(Item_Delete);
			connections.Add(connection);

			OnContentsChanged(EventArgs.Empty);
		}

		public void LoadingFinished()
		{
			Invalidate();
		}

		public void RemoveSelectedItems()
		{
			if (SelectedItemCount == 0)
				return;

			if (MessageBox.Show("delete_confirmation",
				"confirmation", MessageBoxButtons.YesNo,
				MessageBoxIcon.Warning) == DialogResult.Yes)
			{
				for (int i = 0; i < shapes.Count; i++) {
					if (shapes[i].IsSelected) {
						this.Controls.Remove(shapes[i]);
						OnEntityRemoved(new EntityRemovedEventArgs(shapes[i].Entity));
						RemoveConnections(shapes[i]);
						shapes.RemoveAt(i);
						i--;
					}
				}
				for (int i = 0; i < connections.Count; i++) {
					if (connections[i].IsSelected) {
						OnRelationRemoved(
							new RelationRemovedEventArgs(connections[i].Relation));
						RemoveConnection(connections[i--]);
					}
				}

				Invalidate();
				SelectedItemCount = 0;
			}
		}

		private void RemoveConnection(Connection connection)
		{
			if (connection != null) {
				connection.StartNode.Shape = null;
				connection.EndNode.Shape = null;
				connections.Remove(connection);
			}
		}

		private void RemoveConnections(EntityShape entityShape)
		{
			if (entityShape != null) {
				for (int i = 0; i < connections.Count; i++) {
					if (connections[i].Relation.First == entityShape.Entity ||
						connections[i].Relation.Second == entityShape.Entity)
					{
						RemoveConnection(connections[i--]);
					}
				}
			}
		}

		/// <exception cref="ArgumentNullException">
		/// <paramref name="node"/> is null.
		/// </exception>
		public void Serialize(XmlNode node)
		{
			if (node == null)
				throw new ArgumentNullException("node");

			node.RemoveAll();
			for (int i = 0; i < shapes.Count; i++) {
				XmlElement child = node.OwnerDocument.CreateElement("Shape");
				shapes[i].Serialize(child);
				node.AppendChild(child);
			}
			for (int i = 0; i < connections.Count; i++) {
				if (!(connections[i] is PreviewConnection)) {
					XmlElement child = node.OwnerDocument.CreateElement("Connection");
					connections[i].Serialize(child);
					node.AppendChild(child);
				}
			}
		}

		/// <exception cref="ArgumentNullException">
		/// <paramref name="node"/> is null.
		/// </exception>
		public void Deserialize(XmlNode node)
		{
			if (node == null)
				throw new ArgumentNullException("node");

			XmlNode child = node["Shape"];
			int shapeIndex = 0;
			int connectionIndex = 0;

			while (child != null && child.Name == "Shape" && shapeIndex < shapes.Count) {
				shapes[shapeIndex++].Deserialize(child);
				child = child.NextSibling;
			}
			while (child != null && child.Name == "Connection" &&
				connectionIndex < connections.Count)
			{
				connections[connectionIndex++].Deserialize(child);
				child = child.NextSibling;
			}
		}

		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);

			this.Focus();

			if (Connecting) {
				if (e.Button == MouseButtons.Left)
					ApplyConnection();
				else if (e.Button == MouseButtons.Right)
					Connecting = false;
			}
			else {
				if (Control.ModifierKeys == Keys.Control && !OverTeminalNode) {
					InvertConnectionSelection(e.Location);
				}
				else {
					DeselectItems();
					SelectOneConnection(e.Location);
					Invalidate();
				}

				if (e.Button == MouseButtons.Left && !OverTeminalNode) {
					selecting = true;
					selectionStartPoint = e.Location;
					SetSelectionRectangle(e.Location);
					SelectItems();
				}
				else if (e.Button == MouseButtons.Right) {
					//TODO: ez kell:
					//TrySelectConnection(e.Location);
				}
			}
		}

		protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);

			if (Connecting) {
				TerminalNode node = (StartChosen) ? endNode : startNode;
				bool needInvalidate = false;

				if (node != null && node.Shape != null)
					needInvalidate = true;
				if (SetNodeShape(node, e.Location))
					needInvalidate = true;

				if (needInvalidate)
					Invalidate();
			}
			else if (selecting) {
				ClearSelectionRectangle();
				SetSelectionRectangle(e.Location);
				DrawSelectionRectangle();
			}
			else if (ModifyingNode != null && e.Button == MouseButtons.Left) {
				if (ModifyingNode.SetPosition(e.Location))
					Invalidate();
			}
			else if (ShapeResizing) {
				shapeHorizontalResizing = false;
				shapeVerticalResizing = false;
				Cursor = Cursors.Default;
			}
			else {
				CheckTerminalNodes(e.Location);
			}
		}

		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);

			if (selecting && selectionRectangle.Size != Size.Empty) {
				ClearSelectionRectangle();
				SelectItems();
				selectionRectangle = Rectangle.Empty;
			}

			selecting = false;
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			DrawConnections(e.Graphics);

			if (Connecting && startNode.Shape != null && endNode.Shape == null) {
				Point mouseLocation =
					Control.MousePosition - (Size) this.PointToScreen(Point.Empty);
				previewConnection.DrawOnlyStartSign(e.Graphics, mouseLocation);
			}
		}

		protected override void OnScroll(ScrollEventArgs se)
		{
			base.OnScroll(se);
			Invalidate();
		}

		protected override void OnLostFocus(EventArgs e)
		{
			base.OnLostFocus(e);
			selecting = false;
		}

		private Rectangle GetDiagramArea()
		{
			if (shapes.Count == 0)
				return Rectangle.Empty;

			Point topLeftCorner;
			Point bottomRightCorner;

			topLeftCorner = shapes[0].Location;
			bottomRightCorner = shapes[0].Location + shapes[0].Size;

			for (int i = 1; i < shapes.Count; i++) {
				Point location = shapes[i].Location;

				if (location.X < topLeftCorner.X)
					topLeftCorner.X = location.X;
				if (location.Y < topLeftCorner.Y)
					topLeftCorner.Y = location.Y;
				if (location.X + shapes[i].Width - 1 > bottomRightCorner.X)
					bottomRightCorner.X = location.X + shapes[i].Size.Width - 1;
				if (location.Y + shapes[i].Height - 1 > bottomRightCorner.Y)
					bottomRightCorner.Y = location.Y + shapes[i].Size.Height - 1;
			}

			return new Rectangle(topLeftCorner.X, topLeftCorner.Y, bottomRightCorner.X -
				topLeftCorner.X, bottomRightCorner.Y - topLeftCorner.Y);
		}

		/// <exception cref="ArgumentNullException">
		/// <paramref name="path"/> is null.-or-
		/// <paramref name="format"/> is null.
		/// </exception>
		public void SaveAsImage(string path, ImageFormat format)
		{
			const int Margin = 20;

			if (format == null)
				throw new ArgumentNullException("format");
			if (path == null)
				throw new ArgumentNullException("path");

			Rectangle area = GetDiagramArea();
			Size marginSize = new Size(Margin, Margin);
			
			using (Image image = new Bitmap(area.Width + Margin * 2, area.Height + Margin * 2))
			using (Graphics g = Graphics.FromImage(image))
			{
				g.Clear(Style.CurrentStyle.DiagramBackColor);
				for (int i = 0; i < shapes.Count; i++)
					shapes[i].Draw(g, shapes[i].Location - (Size) area.Location + marginSize);

				try {
					image.Save(path, format);
				}
				catch (Exception ex) {
					MessageBox.Show(
						string.Format("{0}\n{1}: {2}", "error_in_saving_image",
							"errors_reason", ex.Message),
						"error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		public void Print(PrintPageEventArgs e)
		{
			if (shapes.Count == 0)
				return;

			Rectangle area = GetDiagramArea();
			float scaleX = (float) e.MarginBounds.Width / area.Width;
			float scaleY = (float) e.MarginBounds.Height / area.Height;
			float scale = Math.Min(scaleX, scaleY);

			if (scale > 1) scale = 1;

			for (int i = 0; i < shapes.Count; i++) {
				e.Graphics.TranslateTransform(e.MarginBounds.X, e.MarginBounds.Y);
				shapes[i].Draw(e.Graphics, shapes[i].Location - (Size) area.Location, scale);
				e.Graphics.ResetTransform();
			}
			for (int i = 0; i < connections.Count; i++) {
				e.Graphics.TranslateTransform(e.MarginBounds.X, e.MarginBounds.Y);
				connections[i].Draw(e.Graphics, new Point(-area.X, -area.Y), scale);
				e.Graphics.ResetTransform();
			}
			Connecting = false;
		}

		private void DrawConnections(Graphics g)
		{
			for (int i = 0; i < connections.Count; i++)
				connections[i].DrawOnScreen(g, Point.Empty);
		}

		public void StartConnection(RelationType relationType)
		{
			this.relationType = relationType;
			Connecting = true;
		}

		private void ApplyConnection()
		{
			if (!StartChosen && startNode.Shape != null) {
				StartChosen = true;
			}
			else if (StartChosen && endNode.Shape != null) {
				EndChosen = true;
				Connecting = false;
			}
		}

		private bool IsShapeEdge(EntityShape shape, Point point)
		{
			if (shape == null)
				return false;

			return
				(point.X < shape.Left || point.X >= shape.Right) &&
				(point.X >= shape.Left - Connection.MarginSize) &&
				(point.X < shape.Right + Connection.MarginSize) &&
				(point.Y >= shape.Top && point.Y < shape.Bottom)
				||
				(point.Y < shape.Top || point.Y >= shape.Bottom) &&
				(point.Y >= shape.Top - Connection.MarginSize) &&
				(point.Y < shape.Bottom + Connection.MarginSize) &&
				(point.X >= shape.Left && point.X < shape.Right);
		}

		private bool SetNodeShape(TerminalNode node, Point mouseLocation)
		{
			if (node == null)
				return false;

			for (int i = 0; i < shapes.Count; i++) {
				if (IsShapeEdge(shapes[i], mouseLocation)) {
					node.Shape = shapes[i];
					node.SetPosition(mouseLocation);
					return true;
				}
			}

			node.Shape = null;
			return false;
		}

		private void CheckTerminalNodes(Point mouseLocation)
		{
			for (int i = 0; i < connections.Count; i++) {
				TerminalNode node = connections[i].GetTerminalNode(mouseLocation);

				if (node != null) {
					ModifyingNode = node;
					return;
				}
			}

			ModifyingNode = null;
		}

		private void SetSelectionRectangle(Point mouseLocation)
		{
			if (mouseLocation.X < 1)
				mouseLocation.X = 1;
			if (mouseLocation.X > ClientRectangle.Width - 1)
				mouseLocation.X = ClientRectangle.Width - 1;
			if (mouseLocation.Y < 1)
				mouseLocation.Y = 1;
			if (mouseLocation.Y > ClientRectangle.Height - 1)
				mouseLocation.Y = ClientRectangle.Height - 1;

			selectionRectangle = new Rectangle(
				selectionStartPoint.X, selectionStartPoint.Y,
				mouseLocation.X - selectionStartPoint.X,
				mouseLocation.Y - selectionStartPoint.Y);
		}

		private void DrawSelectionRectangle()
		{
			if (selectionRectangle.Size != Size.Empty) {
				Rectangle rectangle = selectionRectangle;

				rectangle.Location += (Size) this.PointToScreen(Point.Empty);
				ControlPaint.DrawReversibleFrame(rectangle, this.BackColor, FrameStyle.Dashed);
			}
		}

		private void ClearSelectionRectangle()
		{
			DrawSelectionRectangle();
		}

		public void SelectAll()
		{
			SelectionChanging = true;
			for (int i = 0; i < shapes.Count; i++)
				shapes[i].IsSelected = true;
			for (int i = 0; i < connections.Count; i++)
				connections[i].IsSelected = true;
			SelectionChanging = false;

			Invalidate();
		}

		private void SelectItems()
		{
			Rectangle rectangle = selectionRectangle;

			if (rectangle.Size != Size.Empty) {
				//TODO: ezt nem lehetne szebben?
				if (rectangle.Width < 0) {
					rectangle.X += selectionRectangle.Width;
					rectangle.Width *= -1;
				}
				if (rectangle.Height < 0) {
					rectangle.Y += selectionRectangle.Height;
					rectangle.Height *= -1;
				}

				SelectionChanging = true;
				for (int i = 0; i < shapes.Count; i++)
					shapes[i].TrySelect(rectangle);
				for (int i = 0; i < connections.Count; i++)
					connections[i].TrySelect(rectangle);
				SelectionChanging = false;
			}
		}

		private void SelectOneConnection(Point mouseLocation)
		{
			for (int i = 0; i < connections.Count; i++) {
				if (connections[i].CanSelect(mouseLocation)){
					connections[i].IsSelected = true;
					return;
				}
			}
		}

		private void InvertConnectionSelection(Point mouseLocation)
		{
			for (int i = 0; i < connections.Count; i++) {
				if (connections[i].CanSelect(mouseLocation))
					connections[i].IsSelected = !connections[i].IsSelected;
			}

			Invalidate();
		}

		private void DeselectConnections(Point mouseLocation)
		{
			for (int i = 0; i < connections.Count; i++) {
				if (connections[i].IsSelected && connections[i].CanSelect(mouseLocation))
					connections[i].IsSelected = false;
			}
			Invalidate();
		}

		private void DeselectItems()
		{
			if (SelectedItemCount > 0) {
				SelectionChanging = true;
				for (int i = 0; i < shapes.Count; i++)
					shapes[i].IsSelected = false;
				for (int i = 0; i < connections.Count; i++)
					connections[i].IsSelected = false;

				SelectedItemCount = 0;
				SelectionChanging = false;
			}
		}

		private void CountSelectedItems()
		{
			int count = 0;

			for (int i = 0; i < shapes.Count; i++)
				if (shapes[i].IsSelected)
					count++;
			for (int i = 0; i < connections.Count; i++)
				if (connections[i].IsSelected)
					count++;

			selectedItemCount = count;
		}

		private void Item_SelectionChanged(object sender, EventArgs e)
		{
			CountSelectedItems();
			if (SelectedItemCount == 1)
				firstSelectedItem = (IDiagramElement) sender;

			if (SelectionChanging)
				selectionChanged = true;
			else
				OnSelectionChanged(EventArgs.Empty);
		}

		private void Item_ContentsChanged(object sender, EventArgs e)
		{
			if (ContentsChanged != null)
				ContentsChanged(this, e);
		}

		private Size CheckDiagramBorders(Size movingSize)
		{
			Size scrolled = new Size(HorizontalScroll.Value, VerticalScroll.Value);

			for (int i = 0; i < shapes.Count; i++) {
				if (shapes[i].IsSelected) {
					Point newLocation = shapes[i].Location + movingSize + scrolled;

					if (newLocation.X < MarginSize)
						movingSize.Width -= newLocation.X - MarginSize;
					if (newLocation.Y < MarginSize)
						movingSize.Height -= newLocation.Y - MarginSize;
				}
			}

			return movingSize;
		}

		private void  SnapLocations(Point location, ref Size movingSize)
		{
			for (int i = 0; i < shapes.Count; i++) {
				if (!shapes[i].IsSelected) {
					Point newLocation = location + movingSize;

					if (Math.Abs(newLocation.X - shapes[i].Left) < PrecisionSize &&
						movingSize.Width != 0)
					{
						MoveSelectedItems(new Size(shapes[i].Left - location.X, 0));
						movingSize.Width = 0;
					}

					if (Math.Abs(newLocation.Y - shapes[i].Top) < PrecisionSize &&
						movingSize.Height != 0)
					{
						MoveSelectedItems(new Size(0, shapes[i].Top - location.Y));
						movingSize.Height = 0;
					}
				}
			}
		}
				
		private void SnapEdges(EntityShape shape, ref Size movingSize)
		{
			if (shape == null)
				return;

			for (int i = 0; i < shapes.Count; i++) {
				if (shape != shapes[i]) {
					Point bottomRight = shape.Location + shape.Size;
					int newRight  = bottomRight.X + movingSize.Width;
					int newBottom = bottomRight.Y + movingSize.Height;

					if (Math.Abs(shapes[i].Right - newRight) < PrecisionSize &&
						movingSize.Width != 0)
					{
						int oldWidth = shape.Width;
						shape.Width += shapes[i].Right - shape.Right;
						oldMouseLocation.X += shape.Width - oldWidth;
						movingSize.Width = 0;
					}

					if (Math.Abs(shapes[i].Bottom - newBottom) < PrecisionSize &&
						movingSize.Height != 0)
					{
						int oldHeight = shape.Height;

						shape.Height += shapes[i].Bottom - shape.Bottom;
						oldMouseLocation.Y += shape.Height - oldHeight;
						movingSize.Height = 0;
					}
				}
			}
		}

		private void MoveSelectedItems(Size movingSize)
		{
			for (int i = 0; i < shapes.Count; i++) {
				if (shapes[i].IsSelected)
					shapes[i].Location += movingSize;
			}
		}

		//TODO: nem inkább Shape_Delete?
		private void Item_Delete(object sender, EventArgs e)
		{
			RemoveSelectedItems();
		}

		private void Shape_Enter(object sender, EventArgs e)
		{
			if (!Connecting) {
				EntityShape shape = (EntityShape) sender;

				SelectionChanging = true;
				if (!shape.IsSelected && Control.ModifierKeys != Keys.Control) {
					DeselectItems();
					shape.IsSelected = !shape.IsSelected;
				}
				else if (Control.ModifierKeys == Keys.Control) {
					shape.IsSelected = !shape.IsSelected;
				}
				else {
					shape.IsSelected = true;
				}
				SelectionChanging = false;
			}
		}

		private void Shape_Move(object sender, EventArgs e)
		{
			if (shapePositioning) {
				EntityShape shape = (EntityShape) sender;

				if (shape.TerminalNodes.Count > 0)
					Invalidate();
				if (ContentsChanged != null)
					ContentsChanged(this, e);

			}
		}

		private void Shape_MouseDown(object sender, MouseEventArgs e)
		{
			if (Connecting) {
				if (e.Button == MouseButtons.Left)
					ApplyConnection();
			}
			else if (e.Button == MouseButtons.Left) {
				oldMouseLocation = e.Location;
				oldSize = ((EntityShape) sender).Size;
				shapePositioning = true;
			}
		}

		private void Shape_MouseMove(object sender, MouseEventArgs e)
		{
			EntityShape shape = (EntityShape) sender;

			if (shapePositioning) {
				Size movingSize = new Size(e.Location.X - oldMouseLocation.X,
					e.Location.Y - oldMouseLocation.Y);

				// Resizing
				if (ShapeResizing) {
					if (!shapeHorizontalResizing) movingSize.Width  = 0;
					if (!shapeVerticalResizing)   movingSize.Height = 0;

					if (Settings.CurrentSettings.UsePrecisionSnapping &&
						Control.ModifierKeys != Keys.Shift)
					{
						SnapEdges(shape, ref movingSize);
					}
					oldMouseLocation += movingSize;
					Size oldSize = shape.Size;
					shape.Size += movingSize;
					oldMouseLocation -= oldSize - shape.Size + movingSize;
				}
				// Moving
				else {
					movingSize = CheckDiagramBorders(movingSize);
					if (Settings.CurrentSettings.UsePrecisionSnapping &&
						Control.ModifierKeys != Keys.Shift)
					{
						SnapLocations(shape.Location, ref movingSize);
					}
					MoveSelectedItems(movingSize);
				}
			}
			else if (ConnectionPositioning) {
				if (startNode != null && !StartChosen) {
					if (startNode.IsVertical)
						startNode.RelativeLocation = e.X;
					else
						startNode.RelativeLocation = e.Y;
				}
				else if (endNode != null) {
					if (endNode.IsVertical)
						endNode.RelativeLocation = e.X;
					else
						endNode.RelativeLocation = e.Y;
				}
				Invalidate();
			}
			else if (!Connecting) {
				shapeHorizontalResizing = (e.Location.X >= shape.Width - ResizeMargin);
				shapeVerticalResizing = (e.Location.Y >= shape.Height - ResizeMargin);

				if (shapeHorizontalResizing && shapeVerticalResizing)
					Cursor = Cursors.SizeNWSE;
				else if (shapeHorizontalResizing)
					Cursor = Cursors.SizeWE;
				else if (shapeVerticalResizing)
					Cursor = Cursors.SizeNS;
				else
					Cursor = Cursors.Default;
			}
		}

		private void Shape_MouseUp(object sender, MouseEventArgs e)
		{
			shapePositioning = false;
		}

		private void Shape_Resize(object sender, EventArgs e)
		{
			EntityShape shape = (EntityShape) sender;

			if (shape == null)
				return;

			for (int i = 0; i < shape.TerminalNodes.Count; i++) {
				TerminalNode node = shape.TerminalNodes[i];

				if (node.IsVertical && node.RelativeLocation >= shape.Width)
					node.RelativeLocation = shape.Width - 1;
				else if (node.IsHorizontal && node.RelativeLocation >= shape.Height)
					node.RelativeLocation = shape.Height - 1;
			}

			Invalidate();
			OnContentsChanged(EventArgs.Empty);
		}

		private void OnContentsChanged(EventArgs e)
		{
			if (ContentsChanged != null)
				ContentsChanged(this, e);
		}

		private void OnSelectionChanged(EventArgs e)
		{
			if (SelectionChanged != null)
				SelectionChanged(this, e);
		}

		private void OnEntityRemoved(EntityRemovedEventArgs e)
		{
			if (EntityRemoved != null)
				EntityRemoved(this, e);
		}

		private void OnRelationRemoved(RelationRemovedEventArgs e)
		{
			if (RelationRemoved != null)
				RelationRemoved(this, e);
		}

		private void OnConnectionCreated(ConnectionCreatedEventArgs e)
		{
			if (ConnectionCreated != null)
				ConnectionCreated(this, e);
		}

		private void KeyDowned(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Delete)
				RemoveSelectedItems();

			if (e.KeyCode == Keys.Escape) {
				DeselectItems();
				shapePositioning = false;
				Connecting = false;
			}
		}
	}
}
