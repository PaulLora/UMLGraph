namespace NClass.GUI.Diagram
{
	partial class MembersDialog
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
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtSyntax = new System.Windows.Forms.TextBox();
            this.lblSyntax = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblType = new System.Windows.Forms.Label();
            this.lblAccess = new System.Windows.Forms.Label();
            this.cboAccess = new System.Windows.Forms.ComboBox();
            this.chkStatic = new System.Windows.Forms.CheckBox();
            this.chkReadonly = new System.Windows.Forms.CheckBox();
            this.chkConst = new System.Windows.Forms.CheckBox();
            this.txtInitialValue = new System.Windows.Forms.TextBox();
            this.lblInitValue = new System.Windows.Forms.Label();
            this.lstMembers = new System.Windows.Forms.ListView();
            this.icon = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.type = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.access = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.modifier = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.grpOtherModifiers = new System.Windows.Forms.GroupBox();
            this.chkNew = new System.Windows.Forms.CheckBox();
            this.cboType = new System.Windows.Forms.ComboBox();
            this.cboModifier = new System.Windows.Forms.ComboBox();
            this.lblModifier = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolNewField = new System.Windows.Forms.ToolStripButton();
            this.toolNewMethod = new System.Windows.Forms.ToolStripButton();
            this.toolDelete = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.grpOtherModifiers.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // txtSyntax
            // 
            this.txtSyntax.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSyntax.Location = new System.Drawing.Point(95, 15);
            this.txtSyntax.Margin = new System.Windows.Forms.Padding(4);
            this.txtSyntax.Name = "txtSyntax";
            this.txtSyntax.Size = new System.Drawing.Size(457, 22);
            this.txtSyntax.TabIndex = 0;
            this.txtSyntax.TextChanged += new System.EventHandler(this.MemberChanged);
            this.txtSyntax.Validating += new System.ComponentModel.CancelEventHandler(this.txtSyntax_Validating);
            // 
            // lblSyntax
            // 
            this.lblSyntax.Location = new System.Drawing.Point(0, 18);
            this.lblSyntax.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSyntax.Name = "lblSyntax";
            this.lblSyntax.Size = new System.Drawing.Size(87, 16);
            this.lblSyntax.TabIndex = 10;
            this.lblSyntax.Text = "Syntax";
            this.lblSyntax.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblName
            // 
            this.lblName.Location = new System.Drawing.Point(0, 50);
            this.lblName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(87, 16);
            this.lblName.TabIndex = 11;
            this.lblName.Text = "Name";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(95, 47);
            this.txtName.Margin = new System.Windows.Forms.Padding(4);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(287, 22);
            this.txtName.TabIndex = 1;
            this.txtName.TextChanged += new System.EventHandler(this.MemberChanged);
            this.txtName.Validating += new System.ComponentModel.CancelEventHandler(this.txtName_Validating);
            // 
            // lblType
            // 
            this.lblType.Location = new System.Drawing.Point(0, 82);
            this.lblType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(87, 16);
            this.lblType.TabIndex = 12;
            this.lblType.Text = "Type";
            this.lblType.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblAccess
            // 
            this.lblAccess.Location = new System.Drawing.Point(0, 116);
            this.lblAccess.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAccess.Name = "lblAccess";
            this.lblAccess.Size = new System.Drawing.Size(87, 16);
            this.lblAccess.TabIndex = 13;
            this.lblAccess.Text = "Access";
            this.lblAccess.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cboAccess
            // 
            this.cboAccess.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboAccess.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAccess.FormattingEnabled = true;
            this.cboAccess.Items.AddRange(new object[] {
            "Default",
            "Public",
            "Protected Internal",
            "Internal",
            "Protected",
            "Private"});
            this.cboAccess.Location = new System.Drawing.Point(95, 112);
            this.cboAccess.Margin = new System.Windows.Forms.Padding(4);
            this.cboAccess.Name = "cboAccess";
            this.cboAccess.Size = new System.Drawing.Size(287, 24);
            this.cboAccess.TabIndex = 3;
            this.cboAccess.SelectedIndexChanged += new System.EventHandler(this.cboAccess_SelectedIndexChanged);
            // 
            // chkStatic
            // 
            this.chkStatic.AutoSize = true;
            this.chkStatic.Location = new System.Drawing.Point(15, 27);
            this.chkStatic.Margin = new System.Windows.Forms.Padding(4);
            this.chkStatic.Name = "chkStatic";
            this.chkStatic.Size = new System.Drawing.Size(65, 21);
            this.chkStatic.TabIndex = 0;
            this.chkStatic.Text = "Static";
            this.chkStatic.UseVisualStyleBackColor = true;
            this.chkStatic.CheckedChanged += new System.EventHandler(this.chkStatic_CheckedChanged);
            // 
            // chkReadonly
            // 
            this.chkReadonly.AutoSize = true;
            this.chkReadonly.Location = new System.Drawing.Point(15, 59);
            this.chkReadonly.Margin = new System.Windows.Forms.Padding(4);
            this.chkReadonly.Name = "chkReadonly";
            this.chkReadonly.Size = new System.Drawing.Size(90, 21);
            this.chkReadonly.TabIndex = 1;
            this.chkReadonly.Text = "Readonly";
            this.chkReadonly.UseVisualStyleBackColor = true;
            this.chkReadonly.CheckedChanged += new System.EventHandler(this.chkReadonly_CheckedChanged);
            // 
            // chkConst
            // 
            this.chkConst.AutoSize = true;
            this.chkConst.Location = new System.Drawing.Point(15, 91);
            this.chkConst.Margin = new System.Windows.Forms.Padding(4);
            this.chkConst.Name = "chkConst";
            this.chkConst.Size = new System.Drawing.Size(66, 21);
            this.chkConst.TabIndex = 2;
            this.chkConst.Text = "Const";
            this.chkConst.UseVisualStyleBackColor = true;
            this.chkConst.CheckedChanged += new System.EventHandler(this.chkConst_CheckedChanged);
            // 
            // txtInitialValue
            // 
            this.txtInitialValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInitialValue.Location = new System.Drawing.Point(95, 178);
            this.txtInitialValue.Margin = new System.Windows.Forms.Padding(4);
            this.txtInitialValue.Name = "txtInitialValue";
            this.txtInitialValue.Size = new System.Drawing.Size(287, 22);
            this.txtInitialValue.TabIndex = 5;
            this.txtInitialValue.TextChanged += new System.EventHandler(this.MemberChanged);
            this.txtInitialValue.Validating += new System.ComponentModel.CancelEventHandler(this.txtInitialValue_Validating);
            // 
            // lblInitValue
            // 
            this.lblInitValue.Location = new System.Drawing.Point(0, 182);
            this.lblInitValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInitValue.Name = "lblInitValue";
            this.lblInitValue.Size = new System.Drawing.Size(87, 16);
            this.lblInitValue.TabIndex = 15;
            this.lblInitValue.Text = "Initial value";
            this.lblInitValue.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lstMembers
            // 
            this.lstMembers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstMembers.AutoArrange = false;
            this.lstMembers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.icon,
            this.name,
            this.type,
            this.access,
            this.modifier});
            this.lstMembers.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lstMembers.FullRowSelect = true;
            this.lstMembers.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstMembers.HideSelection = false;
            this.lstMembers.Location = new System.Drawing.Point(16, 256);
            this.lstMembers.Margin = new System.Windows.Forms.Padding(4);
            this.lstMembers.MultiSelect = false;
            this.lstMembers.Name = "lstMembers";
            this.lstMembers.ShowGroups = false;
            this.lstMembers.Size = new System.Drawing.Size(561, 302);
            this.lstMembers.TabIndex = 8;
            this.lstMembers.UseCompatibleStateImageBehavior = false;
            this.lstMembers.View = System.Windows.Forms.View.Details;
            this.lstMembers.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lstMembers_ItemSelectionChanged);
            this.lstMembers.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstMembers_KeyDown);
            // 
            // icon
            // 
            this.icon.Text = "";
            this.icon.Width = 20;
            // 
            // name
            // 
            this.name.Text = "Name";
            this.name.Width = 119;
            // 
            // type
            // 
            this.type.Text = "Type";
            this.type.Width = 101;
            // 
            // access
            // 
            this.access.Text = "Access";
            this.access.Width = 102;
            // 
            // modifier
            // 
            this.modifier.Text = "Modifier";
            // 
            // grpOtherModifiers
            // 
            this.grpOtherModifiers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.grpOtherModifiers.Controls.Add(this.chkNew);
            this.grpOtherModifiers.Controls.Add(this.chkConst);
            this.grpOtherModifiers.Controls.Add(this.chkReadonly);
            this.grpOtherModifiers.Controls.Add(this.chkStatic);
            this.grpOtherModifiers.Location = new System.Drawing.Point(409, 47);
            this.grpOtherModifiers.Margin = new System.Windows.Forms.Padding(4);
            this.grpOtherModifiers.Name = "grpOtherModifiers";
            this.grpOtherModifiers.Padding = new System.Windows.Forms.Padding(4);
            this.grpOtherModifiers.Size = new System.Drawing.Size(169, 156);
            this.grpOtherModifiers.TabIndex = 6;
            this.grpOtherModifiers.TabStop = false;
            this.grpOtherModifiers.Text = "Egyéb módosítók";
            // 
            // chkNew
            // 
            this.chkNew.AutoSize = true;
            this.chkNew.Enabled = false;
            this.chkNew.Location = new System.Drawing.Point(15, 123);
            this.chkNew.Margin = new System.Windows.Forms.Padding(4);
            this.chkNew.Name = "chkNew";
            this.chkNew.Size = new System.Drawing.Size(137, 21);
            this.chkNew.TabIndex = 3;
            this.chkNew.Text = "New (planning...)";
            this.chkNew.UseVisualStyleBackColor = true;
            // 
            // cboType
            // 
            this.cboType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboType.FormattingEnabled = true;
            this.cboType.Location = new System.Drawing.Point(95, 79);
            this.cboType.Margin = new System.Windows.Forms.Padding(4);
            this.cboType.Name = "cboType";
            this.cboType.Size = new System.Drawing.Size(287, 24);
            this.cboType.Sorted = true;
            this.cboType.TabIndex = 2;
            this.cboType.SelectedIndexChanged += new System.EventHandler(this.cboType_SelectedIndexChanged);
            this.cboType.TextChanged += new System.EventHandler(this.MemberChanged);
            this.cboType.Validating += new System.ComponentModel.CancelEventHandler(this.cboType_Validating);
            // 
            // cboModifier
            // 
            this.cboModifier.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboModifier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboModifier.FormattingEnabled = true;
            this.cboModifier.Items.AddRange(new object[] {
            "Default",
            "Public",
            "Protected Internal",
            "Internal",
            "Protected",
            "Private"});
            this.cboModifier.Location = new System.Drawing.Point(95, 145);
            this.cboModifier.Margin = new System.Windows.Forms.Padding(4);
            this.cboModifier.Name = "cboModifier";
            this.cboModifier.Size = new System.Drawing.Size(287, 24);
            this.cboModifier.TabIndex = 4;
            this.cboModifier.SelectedIndexChanged += new System.EventHandler(this.cboModifier_SelectedIndexChanged);
            // 
            // lblModifier
            // 
            this.lblModifier.Location = new System.Drawing.Point(0, 149);
            this.lblModifier.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblModifier.Name = "lblModifier";
            this.lblModifier.Size = new System.Drawing.Size(87, 16);
            this.lblModifier.TabIndex = 14;
            this.lblModifier.Text = "Modifier";
            this.lblModifier.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(479, 566);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 28);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "Bezár";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // toolStrip
            // 
            this.toolStrip.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.toolStrip.AutoSize = false;
            this.toolStrip.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolNewField,
            this.toolNewMethod,
            this.toolDelete});
            this.toolStrip.Location = new System.Drawing.Point(16, 222);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip.Size = new System.Drawing.Size(563, 31);
            this.toolStrip.TabIndex = 7;
            this.toolStrip.Text = "toolStrip1";
            // 
            // toolNewField
            // 
            this.toolNewField.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolNewField.Image = global::NClass.GUI.Diagram.Properties.Resources.Field;
            this.toolNewField.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolNewField.Name = "toolNewField";
            this.toolNewField.Size = new System.Drawing.Size(24, 28);
            this.toolNewField.Text = "New Field";
            this.toolNewField.Click += new System.EventHandler(this.toolNewField_Click);
            // 
            // toolNewMethod
            // 
            this.toolNewMethod.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolNewMethod.Image = global::NClass.GUI.Diagram.Properties.Resources.Method;
            this.toolNewMethod.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolNewMethod.Name = "toolNewMethod";
            this.toolNewMethod.Size = new System.Drawing.Size(24, 28);
            this.toolNewMethod.Text = "New Method";
            this.toolNewMethod.Click += new System.EventHandler(this.toolNewMethod_Click);
            // 
            // toolDelete
            // 
            this.toolDelete.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolDelete.Image = global::NClass.GUI.Diagram.Properties.Resources.Delete;
            this.toolDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolDelete.Name = "toolDelete";
            this.toolDelete.Size = new System.Drawing.Size(24, 28);
            this.toolDelete.Text = "Delete";
            this.toolDelete.Click += new System.EventHandler(this.toolDelete_Click);
            // 
            // MembersDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(595, 609);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.lstMembers);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.cboModifier);
            this.Controls.Add(this.lblModifier);
            this.Controls.Add(this.cboType);
            this.Controls.Add(this.grpOtherModifiers);
            this.Controls.Add(this.txtInitialValue);
            this.Controls.Add(this.lblInitValue);
            this.Controls.Add(this.cboAccess);
            this.Controls.Add(this.lblAccess);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblSyntax);
            this.Controls.Add(this.txtSyntax);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(527, 543);
            this.Name = "MembersDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Members";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PropertiesDialog_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.grpOtherModifiers.ResumeLayout(false);
            this.grpOtherModifiers.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ErrorProvider errorProvider;
		private System.Windows.Forms.Label lblSyntax;
		private System.Windows.Forms.TextBox txtSyntax;
		private System.Windows.Forms.ComboBox cboAccess;
		private System.Windows.Forms.Label lblAccess;
		private System.Windows.Forms.Label lblType;
		private System.Windows.Forms.TextBox txtName;
		private System.Windows.Forms.Label lblName;
		private System.Windows.Forms.TextBox txtInitialValue;
		private System.Windows.Forms.Label lblInitValue;
		private System.Windows.Forms.CheckBox chkConst;
		private System.Windows.Forms.CheckBox chkReadonly;
		private System.Windows.Forms.CheckBox chkStatic;
		private System.Windows.Forms.ListView lstMembers;
		private System.Windows.Forms.ColumnHeader name;
		private System.Windows.Forms.ColumnHeader type;
		private System.Windows.Forms.ColumnHeader access;
		private System.Windows.Forms.GroupBox grpOtherModifiers;
		private System.Windows.Forms.ComboBox cboType;
		private System.Windows.Forms.ComboBox cboModifier;
		private System.Windows.Forms.Label lblModifier;
		private System.Windows.Forms.ColumnHeader icon;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.ColumnHeader modifier;
		private System.Windows.Forms.ToolStrip toolStrip;
		private System.Windows.Forms.ToolStripButton toolNewField;
		private System.Windows.Forms.ToolStripButton toolNewMethod;
		private System.Windows.Forms.ToolStripButton toolDelete;
		private System.Windows.Forms.CheckBox chkNew;
	}
}

