using System;

namespace NClass.GUI
{
	sealed partial class MainForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.toolStripContainer = new System.Windows.Forms.ToolStripContainer();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblLanguage = new System.Windows.Forms.ToolStripStatusLabel();
            this.diagram = new NClass.GUI.Diagram.DiagramControl();
            this.diagramContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);

            this.typeDetailsToolStrip = new System.Windows.Forms.ToolStrip();
            this.lblName = new System.Windows.Forms.ToolStripLabel();
            this.txtName = new System.Windows.Forms.ToolStripTextBox();
            this.lblAccess = new System.Windows.Forms.ToolStripLabel();
            this.cboAccess = new System.Windows.Forms.ToolStripComboBox();
            this.lblModifier = new System.Windows.Forms.ToolStripLabel();
            this.cboModifier = new System.Windows.Forms.ToolStripComboBox();

            this.elementsToolStrip = new System.Windows.Forms.ToolStrip();
            this.toolNewClass = new System.Windows.Forms.ToolStripButton();
            this.toolSepEntities = new System.Windows.Forms.ToolStripSeparator();
            this.toolNewAssociation = new System.Windows.Forms.ToolStripButton();
            this.toolNewComposition = new System.Windows.Forms.ToolStripButton();
            this.toolNewAggregation = new System.Windows.Forms.ToolStripButton();
            this.toolNewGeneralization = new System.Windows.Forms.ToolStripButton();
            this.toolSepRelations = new System.Windows.Forms.ToolStripSeparator();
            this.toolDelete = new System.Windows.Forms.ToolStripButton();

            this.typeDetailsToolStrip = new System.Windows.Forms.ToolStrip();
            this.lblName = new System.Windows.Forms.ToolStripLabel();
            this.txtName = new System.Windows.Forms.ToolStripTextBox();
            this.lblAccess = new System.Windows.Forms.ToolStripLabel();
            this.cboAccess = new System.Windows.Forms.ToolStripComboBox();
            this.lblModifier = new System.Windows.Forms.ToolStripLabel();
            this.cboModifier = new System.Windows.Forms.ToolStripComboBox();
            this.mnuAddNewElementContext = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNewClassContext = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNewStructContext = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNewInterfaceContext = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNewEnumContext = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNewDelegateContext = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNewCommentContext = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSepElementContext = new System.Windows.Forms.ToolStripSeparator();
            this.mnuNewAssociationContext = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNewCompositionContext = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNewAggregationContext = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNewGeneralizationContext = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNewRealizationContext = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNewDependencyContext = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNewNestingContext = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNewCommentRelationContext = new System.Windows.Forms.ToolStripMenuItem();

            this.mnuMembersFormatContext = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuShowTypeContext = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuShowParametersContext = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuShowParameterNamesContext = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuShowInitialValueContext = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSelectAllContext = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSepSelectAll = new System.Windows.Forms.ToolStripSeparator();
            this.mnuSaveAsImageContext = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOpenFile = new System.Windows.Forms.ToolStripMenuItem();
            this.sepOpenFile = new System.Windows.Forms.ToolStripSeparator();
            this.mnuRecentFile1 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRecentFile2 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRecentFile3 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRecentFile4 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRecentFile5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolNewCSharpDiagram = new System.Windows.Forms.ToolStripMenuItem();
            this.toolNewJavaDiagram = new System.Windows.Forms.ToolStripMenuItem();
            this.toolRecentFile1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolRecentFile2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolRecentFile3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolRecentFile4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolRecentFile5 = new System.Windows.Forms.ToolStripMenuItem();
            this.printDocument = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog = new System.Windows.Forms.PrintPreviewDialog();
            this.printDialog = new System.Windows.Forms.PrintDialog();
            this.pageSetupDialog = new System.Windows.Forms.PageSetupDialog();
            this.saveAsImageDialog = new System.Windows.Forms.SaveFileDialog();
            this.toolStripContainer.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer.ContentPanel.SuspendLayout();
            this.toolStripContainer.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.typeDetailsToolStrip.SuspendLayout();
            this.elementsToolStrip.SuspendLayout();

            this.SuspendLayout();
            // 
            // toolStripContainer
            // 
            // 
            // toolStripContainer.BottomToolStripPanel
            // 
            this.toolStripContainer.BottomToolStripPanel.Controls.Add(this.statusStrip);
            // 
            // toolStripContainer.ContentPanel
            // 
            this.toolStripContainer.ContentPanel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.toolStripContainer.ContentPanel.Controls.Add(this.diagram);
            this.toolStripContainer.ContentPanel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.toolStripContainer.ContentPanel.Margin = new System.Windows.Forms.Padding(4);
            this.toolStripContainer.ContentPanel.Padding = new System.Windows.Forms.Padding(1);
            this.toolStripContainer.ContentPanel.Size = new System.Drawing.Size(1425, 671);
            this.toolStripContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer.Margin = new System.Windows.Forms.Padding(4);
            this.toolStripContainer.Name = "toolStripContainer";
            this.toolStripContainer.Size = new System.Drawing.Size(1425, 724);
            this.toolStripContainer.TabIndex = 0;
            this.toolStripContainer.Text = "toolStripContainer1";
            // 
            // toolStripContainer.TopToolStripPanel
            // 
            this.toolStripContainer.TopToolStripPanel.Controls.Add(this.elementsToolStrip);
            this.toolStripContainer.TopToolStripPanel.Controls.Add(this.typeDetailsToolStrip);
            // 
            // statusStrip
            // 
            this.statusStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus,
            this.lblLanguage});
            this.statusStrip.Location = new System.Drawing.Point(0, 0);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode;
            this.statusStrip.Size = new System.Drawing.Size(1425, 25);
            this.statusStrip.TabIndex = 0;
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(1336, 20);
            this.lblStatus.Spring = true;
            this.lblStatus.Text = "Status";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLanguage
            // 
            this.lblLanguage.Enabled = false;
            this.lblLanguage.Name = "lblLanguage";
            this.lblLanguage.Size = new System.Drawing.Size(74, 20);
            this.lblLanguage.Text = "Language";
            this.lblLanguage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // diagram
            // 
            this.diagram.AutoScroll = true;
            this.diagram.AutoScrollMinSize = new System.Drawing.Size(3200, 2400);
            this.diagram.ContextMenuStrip = this.diagramContextMenuStrip;
            this.diagram.Dock = System.Windows.Forms.DockStyle.Fill;
            this.diagram.Location = new System.Drawing.Point(1, 1);
            this.diagram.Margin = new System.Windows.Forms.Padding(4);
            this.diagram.Name = "diagram";
            this.diagram.Size = new System.Drawing.Size(1423, 669);
            this.diagram.TabIndex = 0;
            this.diagram.SelectionChanged += new System.EventHandler(this.diagram_SelectionChanged);
            // 
            // diagramContextMenuStrip
            // 
            this.diagramContextMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.diagramContextMenuStrip.Name = "diagramContextMenuStrip";
            this.diagramContextMenuStrip.Size = new System.Drawing.Size(61, 4);
            // 
            // typeDetailsToolStrip
            // 
            this.typeDetailsToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.typeDetailsToolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.typeDetailsToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblName,
            this.txtName,
            this.lblAccess,
            this.cboAccess,
            this.lblModifier,
            this.cboModifier});
            this.typeDetailsToolStrip.Location = new System.Drawing.Point(174, 0);
            this.typeDetailsToolStrip.Name = "typeDetailsToolStrip";
            this.typeDetailsToolStrip.Size = new System.Drawing.Size(637, 28);
            this.typeDetailsToolStrip.TabIndex = 5;
            // 
            // lblName
            // 
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(52, 25);
            this.lblName.Text = "Name:";
            // 
            // txtName
            // 
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(200, 28);
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // lblAccess
            // 
            this.lblAccess.Name = "lblAccess";
            this.lblAccess.Size = new System.Drawing.Size(56, 25);
            this.lblAccess.Text = "Access:";
            // 
            // cboAccess
            // 
            this.cboAccess.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAccess.Enabled = false;
            this.cboAccess.Name = "cboAccess";
            this.cboAccess.Size = new System.Drawing.Size(121, 28);
            this.cboAccess.SelectedIndexChanged += new System.EventHandler(this.cboAccess_SelectedIndexChanged);
            // 
            // lblModifier
            // 
            this.lblModifier.Name = "lblModifier";
            this.lblModifier.Size = new System.Drawing.Size(69, 25);
            this.lblModifier.Text = "Modifier:";
            // 
            // cboModifier
            // 
            this.cboModifier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboModifier.Enabled = false;
            this.cboModifier.Name = "cboModifier";
            this.cboModifier.Size = new System.Drawing.Size(121, 28);
            this.cboModifier.SelectedIndexChanged += new System.EventHandler(this.cboModifier_SelectedIndexChanged);
            // 
            // elementsToolStrip
            // 
            this.elementsToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.elementsToolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.elementsToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolNewClass,
            this.toolSepEntities,
            this.toolNewAssociation,
            this.toolNewComposition,
            this.toolNewAggregation,
            this.toolNewGeneralization,
            this.toolSepRelations,
            this.toolDelete});
            this.elementsToolStrip.Location = new System.Drawing.Point(6, 0);

            this.elementsToolStrip.Name = "elementsToolStrip";
            this.elementsToolStrip.Size = new System.Drawing.Size(168, 27);
            this.elementsToolStrip.TabIndex = 5;
            // 
            // toolNewClass
            // 
            this.toolNewClass.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolNewClass.Image = global::NClass.GUI.Properties.Resources.Class;
            this.toolNewClass.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolNewClass.Name = "toolNewClass";
            this.toolNewClass.Size = new System.Drawing.Size(24, 24);
            this.toolNewClass.Click += new System.EventHandler(this.mnuNewClass_Click);
            // 
            // toolSepEntities
            // 
            this.toolSepEntities.Name = "toolSepEntities";
            this.toolSepEntities.Size = new System.Drawing.Size(6, 27);
            // 
            // toolNewAssociation
            // 
            this.toolNewAssociation.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolNewAssociation.Image = global::NClass.GUI.Properties.Resources.Association;
            this.toolNewAssociation.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolNewAssociation.Name = "toolNewAssociation";
            this.toolNewAssociation.Size = new System.Drawing.Size(24, 24);
            this.toolNewAssociation.Click += new System.EventHandler(this.mnuNewAssociation_Click);
            // 
            // toolNewComposition
            // 
            this.toolNewComposition.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolNewComposition.Image = global::NClass.GUI.Properties.Resources.Composition;
            this.toolNewComposition.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolNewComposition.Name = "toolNewComposition";
            this.toolNewComposition.Size = new System.Drawing.Size(24, 24);
            this.toolNewComposition.Click += new System.EventHandler(this.mnuNewComposition_Click);
            // 
            // toolNewAggregation
            // 
            this.toolNewAggregation.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolNewAggregation.Image = global::NClass.GUI.Properties.Resources.Aggregation;
            this.toolNewAggregation.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolNewAggregation.Name = "toolNewAggregation";
            this.toolNewAggregation.Size = new System.Drawing.Size(24, 24);
            this.toolNewAggregation.Click += new System.EventHandler(this.mnuNewAggregation_Click);
            // 
            // toolNewGeneralization
            // 
            this.toolNewGeneralization.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolNewGeneralization.Image = global::NClass.GUI.Properties.Resources.Generalization;
            this.toolNewGeneralization.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolNewGeneralization.Name = "toolNewGeneralization";
            this.toolNewGeneralization.Size = new System.Drawing.Size(24, 24);
            this.toolNewGeneralization.Text = "toolStripButton1";
            this.toolNewGeneralization.Click += new System.EventHandler(this.toolNewGeneralization_Click);
            // 
            // toolSepRelations
            // 
            this.toolSepRelations.Name = "toolSepRelations";
            this.toolSepRelations.Size = new System.Drawing.Size(6, 27);
            // 
            // toolDelete
            // 
            this.toolDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolDelete.Enabled = false;
            this.toolDelete.Image = global::NClass.GUI.Properties.Resources.Delete;
            this.toolDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolDelete.Name = "toolDelete";
            this.toolDelete.Size = new System.Drawing.Size(24, 24);
            this.toolDelete.Click += new System.EventHandler(this.mnuDelete_Click);
            // 
            // mnuMembersFormatContext
            // 
            this.mnuMembersFormatContext.Name = "mnuMembersFormatContext";
            this.mnuMembersFormatContext.Size = new System.Drawing.Size(32, 19);
            // 
            // mnuShowTypeContext
            // 
            this.mnuShowTypeContext.CheckOnClick = true;
            this.mnuShowTypeContext.Name = "mnuShowTypeContext";
            this.mnuShowTypeContext.Size = new System.Drawing.Size(201, 26);
            this.mnuShowTypeContext.Text = "&Type";
            this.mnuShowTypeContext.CheckedChanged += new System.EventHandler(this.mnuShowType_CheckedChanged);
            // 
            // mnuShowParametersContext
            // 
            this.mnuShowParametersContext.CheckOnClick = true;
            this.mnuShowParametersContext.Name = "mnuShowParametersContext";
            this.mnuShowParametersContext.Size = new System.Drawing.Size(201, 26);
            this.mnuShowParametersContext.Text = "&Parameters";
            this.mnuShowParametersContext.CheckedChanged += new System.EventHandler(this.mnuShowParameters_CheckedChanged);
            // 
            // mnuShowParameterNamesContext
            // 
            this.mnuShowParameterNamesContext.CheckOnClick = true;
            this.mnuShowParameterNamesContext.Name = "mnuShowParameterNamesContext";
            this.mnuShowParameterNamesContext.Size = new System.Drawing.Size(201, 26);
            this.mnuShowParameterNamesContext.Text = "Parameter &Names";
            this.mnuShowParameterNamesContext.CheckedChanged += new System.EventHandler(this.mnuShowParameterNames_CheckedChanged);
            // 
            // mnuShowInitialValueContext
            // 
            this.mnuShowInitialValueContext.CheckOnClick = true;
            this.mnuShowInitialValueContext.Name = "mnuShowInitialValueContext";
            this.mnuShowInitialValueContext.Size = new System.Drawing.Size(201, 26);
            this.mnuShowInitialValueContext.Text = "&Initial Value";
            this.mnuShowInitialValueContext.CheckedChanged += new System.EventHandler(this.mnuShowInitialValue_CheckedChanged);
            // 
            // mnuSelectAllContext
            // 
            this.mnuSelectAllContext.Name = "mnuSelectAllContext";
            this.mnuSelectAllContext.Size = new System.Drawing.Size(32, 19);
            // 
            // mnuSepSelectAll
            // 
            this.mnuSepSelectAll.Name = "mnuSepSelectAll";
            this.mnuSepSelectAll.Size = new System.Drawing.Size(195, 6);
            // 
            // mnuSaveAsImageContext
            // 
            this.mnuSaveAsImageContext.Name = "mnuSaveAsImageContext";
            this.mnuSaveAsImageContext.Size = new System.Drawing.Size(32, 19);
            // 
            // mnuOpenFile
            // 
            this.mnuOpenFile.Name = "mnuOpenFile";
            this.mnuOpenFile.Size = new System.Drawing.Size(32, 19);
            // 
            // sepOpenFile
            // 
            this.sepOpenFile.Name = "sepOpenFile";
            this.sepOpenFile.Size = new System.Drawing.Size(174, 6);
            // 
            // mnuRecentFile1
            // 
            this.mnuRecentFile1.Name = "mnuRecentFile1";
            this.mnuRecentFile1.Size = new System.Drawing.Size(177, 22);
            this.mnuRecentFile1.Tag = 0;
            this.mnuRecentFile1.Text = "Recent file 1";
            this.mnuRecentFile1.Click += new System.EventHandler(this.OpenRecentFile_Click);
            // 
            // mnuRecentFile2
            // 
            this.mnuRecentFile2.Name = "mnuRecentFile2";
            this.mnuRecentFile2.Size = new System.Drawing.Size(177, 22);
            this.mnuRecentFile2.Tag = 1;
            this.mnuRecentFile2.Text = "Recent file 2";
            this.mnuRecentFile2.Click += new System.EventHandler(this.OpenRecentFile_Click);
            // 
            // mnuRecentFile3
            // 
            this.mnuRecentFile3.Name = "mnuRecentFile3";
            this.mnuRecentFile3.Size = new System.Drawing.Size(177, 22);
            this.mnuRecentFile3.Tag = 2;
            this.mnuRecentFile3.Text = "Recent file 3";
            this.mnuRecentFile3.Click += new System.EventHandler(this.OpenRecentFile_Click);
            // 
            // mnuRecentFile4
            // 
            this.mnuRecentFile4.Name = "mnuRecentFile4";
            this.mnuRecentFile4.Size = new System.Drawing.Size(177, 22);
            this.mnuRecentFile4.Tag = 3;
            this.mnuRecentFile4.Text = "Recent file 4";
            this.mnuRecentFile4.Click += new System.EventHandler(this.OpenRecentFile_Click);
            // 
            // mnuRecentFile5
            // 
            this.mnuRecentFile5.Name = "mnuRecentFile5";
            this.mnuRecentFile5.Size = new System.Drawing.Size(177, 22);
            this.mnuRecentFile5.Tag = 4;
            this.mnuRecentFile5.Text = "Recent file 5";
            this.mnuRecentFile5.Click += new System.EventHandler(this.OpenRecentFile_Click);
            // 
            // toolNewCSharpDiagram
            // 
            this.toolNewCSharpDiagram.Name = "toolNewCSharpDiagram";
            this.toolNewCSharpDiagram.Size = new System.Drawing.Size(32, 19);
            // 
            // toolNewJavaDiagram
            // 
            this.toolNewJavaDiagram.Name = "toolNewJavaDiagram";
            this.toolNewJavaDiagram.Size = new System.Drawing.Size(32, 19);
            // 
            // toolRecentFile1
            // 
            this.toolRecentFile1.Name = "toolRecentFile1";
            this.toolRecentFile1.Size = new System.Drawing.Size(145, 22);
            this.toolRecentFile1.Tag = 0;
            this.toolRecentFile1.Text = "Recent file 1";
            this.toolRecentFile1.Click += new System.EventHandler(this.OpenRecentFile_Click);
            // 
            // toolRecentFile2
            // 
            this.toolRecentFile2.Name = "toolRecentFile2";
            this.toolRecentFile2.Size = new System.Drawing.Size(145, 22);
            this.toolRecentFile2.Tag = 1;
            this.toolRecentFile2.Text = "Recent file 2";
            this.toolRecentFile2.Click += new System.EventHandler(this.OpenRecentFile_Click);
            // 
            // toolRecentFile3
            // 
            this.toolRecentFile3.Name = "toolRecentFile3";
            this.toolRecentFile3.Size = new System.Drawing.Size(145, 22);
            this.toolRecentFile3.Tag = 2;
            this.toolRecentFile3.Text = "Recent file 3";
            this.toolRecentFile3.Click += new System.EventHandler(this.OpenRecentFile_Click);
            // 
            // toolRecentFile4
            // 
            this.toolRecentFile4.Name = "toolRecentFile4";
            this.toolRecentFile4.Size = new System.Drawing.Size(145, 22);
            this.toolRecentFile4.Tag = 3;
            this.toolRecentFile4.Text = "Recent file 4";
            this.toolRecentFile4.Click += new System.EventHandler(this.OpenRecentFile_Click);
            // 
            // toolRecentFile5
            // 
            this.toolRecentFile5.Name = "toolRecentFile5";
            this.toolRecentFile5.Size = new System.Drawing.Size(145, 22);
            this.toolRecentFile5.Tag = 4;
            this.toolRecentFile5.Text = "Recent file 5";
            this.toolRecentFile5.Click += new System.EventHandler(this.OpenRecentFile_Click);
            // 
            // printPreviewDialog
            // 
            this.printPreviewDialog.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog.ClientSize = new System.Drawing.Size(396, 296);
            this.printPreviewDialog.Document = this.printDocument;
            this.printPreviewDialog.Enabled = true;
            this.printPreviewDialog.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog.Icon")));
            this.printPreviewDialog.Name = "printPreviewDialog";
            this.printPreviewDialog.ShowIcon = false;
            this.printPreviewDialog.UseAntiAlias = true;
            this.printPreviewDialog.Visible = false;
            // 
            // printDialog
            // 
            this.printDialog.Document = this.printDocument;
            this.printDialog.UseEXDialog = true;
            // 
            // pageSetupDialog
            // 
            this.pageSetupDialog.Document = this.printDocument;
            // 
            // saveAsImageDialog
            // 
            this.saveAsImageDialog.DefaultExt = "png";
            this.saveAsImageDialog.Filter = "BMP (*.bmp)|*.bmp|GIF (*.gif)|*.gif|JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|PNG (*.png)|" +
    "*.png";
            this.saveAsImageDialog.FilterIndex = 4;
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1425, 724);
            this.Controls.Add(this.toolStripContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "NClass";
            this.toolStripContainer.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer.BottomToolStripPanel.PerformLayout();
            this.toolStripContainer.ContentPanel.ResumeLayout(false);
            this.toolStripContainer.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer.TopToolStripPanel.PerformLayout();
            this.toolStripContainer.ResumeLayout(false);
            this.toolStripContainer.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.typeDetailsToolStrip.ResumeLayout(false);
            this.typeDetailsToolStrip.PerformLayout();
            this.elementsToolStrip.ResumeLayout(false);
            this.elementsToolStrip.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ToolStripContainer toolStripContainer;
		private System.Windows.Forms.StatusStrip statusStrip;
		private System.Windows.Forms.ToolStripMenuItem mnuOpenFile;
		private System.Windows.Forms.ToolStripSeparator sepOpenFile;
		private System.Windows.Forms.ToolStripMenuItem mnuRecentFile1;
		private System.Windows.Forms.ToolStripMenuItem mnuRecentFile2;
		private System.Windows.Forms.ToolStripMenuItem mnuRecentFile3;
		private System.Windows.Forms.ToolStripMenuItem mnuRecentFile4;
		private System.Windows.Forms.ToolStripMenuItem mnuRecentFile5;
		private System.Windows.Forms.ToolStripMenuItem toolNewCSharpDiagram;
		private System.Windows.Forms.ToolStripMenuItem toolNewJavaDiagram;
		private System.Windows.Forms.ToolStripMenuItem toolRecentFile1;
		private System.Windows.Forms.ToolStripMenuItem toolRecentFile2;
		private System.Windows.Forms.ToolStripMenuItem toolRecentFile3;
		private System.Windows.Forms.ToolStripMenuItem toolRecentFile4;
		private System.Windows.Forms.ToolStripMenuItem toolRecentFile5;
		private System.Windows.Forms.ToolStripStatusLabel lblLanguage;
		private System.Drawing.Printing.PrintDocument printDocument;
		private System.Windows.Forms.PrintPreviewDialog printPreviewDialog;
		private System.Windows.Forms.PrintDialog printDialog;
		private System.Windows.Forms.PageSetupDialog pageSetupDialog;

		private System.Windows.Forms.ToolStrip typeDetailsToolStrip;
		private System.Windows.Forms.ToolStripLabel lblName;
		private System.Windows.Forms.ToolStripTextBox txtName;
		private System.Windows.Forms.ToolStripLabel lblAccess;
		private System.Windows.Forms.ToolStripComboBox cboAccess;
		private System.Windows.Forms.ToolStripLabel lblModifier;
		private System.Windows.Forms.ToolStripComboBox cboModifier;
		private System.Windows.Forms.ToolStrip elementsToolStrip;
		private System.Windows.Forms.ToolStripButton toolNewClass;
		private System.Windows.Forms.ToolStripButton toolDelete;
		private System.Windows.Forms.ContextMenuStrip diagramContextMenuStrip;
		private GUI.Diagram.DiagramControl diagram;
		private System.Windows.Forms.SaveFileDialog saveAsImageDialog;

		private System.Windows.Forms.ToolStripMenuItem mnuAddNewElementContext;
		private System.Windows.Forms.ToolStripMenuItem mnuMembersFormatContext;
		private System.Windows.Forms.ToolStripMenuItem mnuSelectAllContext;
		private System.Windows.Forms.ToolStripSeparator mnuSepSelectAll;
		private System.Windows.Forms.ToolStripMenuItem mnuSaveAsImageContext;

		private System.Windows.Forms.ToolStripMenuItem mnuNewClassContext;
		private System.Windows.Forms.ToolStripMenuItem mnuNewStructContext;
		private System.Windows.Forms.ToolStripMenuItem mnuNewInterfaceContext;
		private System.Windows.Forms.ToolStripMenuItem mnuNewEnumContext;
		private System.Windows.Forms.ToolStripMenuItem mnuNewDelegateContext;
		private System.Windows.Forms.ToolStripMenuItem mnuNewCommentContext;
		private System.Windows.Forms.ToolStripMenuItem mnuShowTypeContext;
		private System.Windows.Forms.ToolStripMenuItem mnuShowParametersContext;
		private System.Windows.Forms.ToolStripMenuItem mnuShowParameterNamesContext;
		private System.Windows.Forms.ToolStripMenuItem mnuShowInitialValueContext;
		private System.Windows.Forms.ToolStripStatusLabel lblStatus;
		private System.Windows.Forms.ToolStripSeparator toolSepEntities;
		private System.Windows.Forms.ToolStripButton toolNewAssociation;
		private System.Windows.Forms.ToolStripButton toolNewComposition;
		private System.Windows.Forms.ToolStripButton toolNewAggregation;
		private System.Windows.Forms.ToolStripSeparator toolSepRelations;

        private System.Windows.Forms.ToolStripButton toolNewGeneralization;
        private System.Windows.Forms.ToolStrip typeDetailsToolStrip;
        private System.Windows.Forms.ToolStripLabel lblName;
        private System.Windows.Forms.ToolStripTextBox txtName;
        private System.Windows.Forms.ToolStripLabel lblAccess;
        private System.Windows.Forms.ToolStripComboBox cboAccess;
        private System.Windows.Forms.ToolStripLabel lblModifier;
        private System.Windows.Forms.ToolStripComboBox cboModifier;

		private System.Windows.Forms.ToolStripSeparator mnuSepElementContext;
		private System.Windows.Forms.ToolStripMenuItem mnuNewAssociationContext;
		private System.Windows.Forms.ToolStripMenuItem mnuNewCompositionContext;
		private System.Windows.Forms.ToolStripMenuItem mnuNewAggregationContext;
		private System.Windows.Forms.ToolStripMenuItem mnuNewGeneralizationContext;
		private System.Windows.Forms.ToolStripMenuItem mnuNewRealizationContext;
		private System.Windows.Forms.ToolStripMenuItem mnuNewDependencyContext;
		private System.Windows.Forms.ToolStripMenuItem mnuNewNestingContext;
		private System.Windows.Forms.ToolStripMenuItem mnuNewCommentRelationContext;
        private System.Windows.Forms.ToolStripButton toolNewGeneralization;
    }
}