using NClass.Core;
using NClass.GUI.Diagram;
using System;
using System.Drawing;
using System.Windows.Forms;
using WindowSettings = NClass.GUI.Properties.Settings;

namespace NClass.GUI
{
    public sealed partial class MainForm : Form
    {
        private Project project;

        #region Enum orders

        private static AccessModifier[] csharpAccessOrder = {
            AccessModifier.Public,
            AccessModifier.ProtectedInternal,
            AccessModifier.Internal,
            AccessModifier.Protected,
            AccessModifier.Private,
            AccessModifier.Default
        };
        private static AccessModifier[] javaAccessOrder = {
            AccessModifier.Public,
            AccessModifier.Protected,
            AccessModifier.Private,
            AccessModifier.Default
        };
        private static InheritanceModifier[] csharpModifierOrder = {
            InheritanceModifier.None,
            InheritanceModifier.Abstract,
            InheritanceModifier.Sealed,
            InheritanceModifier.Static
        };
        private static InheritanceModifier[] javaModifierOrder = {
            InheritanceModifier.None,
            InheritanceModifier.Abstract,
            InheritanceModifier.Sealed,
            InheritanceModifier.Static
        };

        #endregion

        public MainForm()
        {
            Init();

            if (Settings.LoadLastProject && !string.IsNullOrEmpty(Settings.LastProject))
            {
                LoadProject(Settings.LastProject);
            }
            else
            {
                project.NewProject();
            }

            diagram.Select();
        }

        public MainForm(string fileName)
        {
            Init();
            LoadProject(fileName);
        }

        private void Init()
        {
            InitializeComponent();

            project = new Project(diagram);
            lblStatus.Text = "ready";
            project.StateChanged += new EventHandler(project_StateChanged);
        }

        private void LoadProject(string fileName)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                SuspendLayout();
                project.Load(fileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("error" + ": " + ex.Message,
                    "load", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ResumeLayout();
                Cursor = Cursors.Default;
            }
        }

        private Control PanelFromPosition(DockStyle dockStyle)
        {
            switch (dockStyle)
            {
                case DockStyle.Left:
                    return toolStripContainer.LeftToolStripPanel;

                case DockStyle.Right:
                    return toolStripContainer.RightToolStripPanel;

                case DockStyle.Bottom:
                    return toolStripContainer.BottomToolStripPanel;

                case DockStyle.Top:
                default:
                    return toolStripContainer.TopToolStripPanel;
            }
        }

        private DockStyle PositionFromPanel(Control control)
        {
            if (control == toolStripContainer.LeftToolStripPanel)
            {
                return DockStyle.Left;
            }

            if (control == toolStripContainer.RightToolStripPanel)
            {
                return DockStyle.Right;
            }

            if (control == toolStripContainer.BottomToolStripPanel)
            {
                return DockStyle.Bottom;
            }

            return DockStyle.Top;
        }

        private void LoadWindowSettings()
        {
            //Location = WindowSettings.Default.WindowPosition;
            //Size = WindowSettings.Default.WindowSize;
            //if (WindowSettings.Default.IsWindowMaximized)
            //	WindowState = FormWindowState.Maximized;

            elementsToolStrip.Parent =
                PanelFromPosition(WindowSettings.Default.ElementsToolBarPosition);
            typeDetailsToolStrip.Parent =
                PanelFromPosition(WindowSettings.Default.TypeDetailsToolBarPosition);

            elementsToolStrip.Location = WindowSettings.Default.ElementsToolBarLocation;
            typeDetailsToolStrip.Location = WindowSettings.Default.TypeDetailsToolBarLocation;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            LoadWindowSettings();
        }

        protected override void OnDragEnter(DragEventArgs e)
        {
            base.OnDragEnter(e);

            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        protected override void OnDragDrop(DragEventArgs e)
        {
            base.OnDragDrop(e);

            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (files.Length > 0)
                {
                    LoadProject(files[0]);
                }
            }
        }

        private void UpdateStatusBar()
        {
            int selectedItemCount = diagram.SelectedItemCount;

            if (selectedItemCount == 0)
            {
                lblStatus.Text = "ready";
            }
            else if (selectedItemCount == 1)
            {
                lblStatus.Text = diagram.FirstSelectedItem.ToString();
            }
            else
            {
                lblStatus.Text = "items_selected";
            }

            if (project.Language == Language.CSharp)
            {
                lblLanguage.Text = "language" + ": C#";
            }
            else
            {
                lblLanguage.Text = "language" + ": Java";
            }
        }

        private void UpdateHeader()
        {
            Text = "NClass - " + project.ToString();
        }

        private void UpdateWindow()
        {
            UpdateHeader();
            diagram.AutoScrollMinSize = new Size(
                Settings.WorkspaceWidth, Settings.WorkspaceHeight);
            diagram.Refresh();
        }

        private void UpdateModifiersToolBar()
        {
            int selectedItemCount = diagram.SelectedItemCount;
            IDiagramElement selectedItem = diagram.FirstSelectedItem;

            if (selectedItemCount == 1 && selectedItem is TypeShape)
            {
                TypeBase type = (TypeBase)((TypeShape)selectedItem).Entity;

                txtName.Text = type.Name;
                txtName.Enabled = true;
                SetAccessLabel(type.AccessModifier);
                cboAccess.Enabled = true;

                if (type is ClassType)
                {
                    SetModifierLabel(((ClassType)type).Modifier);
                    cboModifier.Enabled = true;
                }
                else
                {
                    cboModifier.Text = null;
                    cboModifier.Enabled = false;
                }
            }
            else
            {
                txtName.Text = null;
                txtName.Enabled = false;
                cboAccess.Text = null;
                cboAccess.Enabled = false;
                cboModifier.Text = null;
                cboModifier.Enabled = false;
            }
        }

        private void SetAccessLabel(AccessModifier access)
        {
            AccessModifier[] accessOrder;

            if (project.Language == Language.CSharp)
            {
                accessOrder = csharpAccessOrder;
            }
            else
            {
                accessOrder = javaAccessOrder;
            }

            for (int i = 0; i < accessOrder.Length; i++)
            {
                if (accessOrder[i] == access)
                {
                    cboAccess.SelectedIndex = i;
                    return;
                }
            }

            cboAccess.SelectedIndex = 0;
        }

        private void SetModifierLabel(InheritanceModifier modifier)
        {
            InheritanceModifier[] modifierOrder;

            if (project.Language == Language.CSharp)
            {
                modifierOrder = csharpModifierOrder;
            }
            else
            {
                modifierOrder = javaModifierOrder;
            }

            for (int i = 0; i < modifierOrder.Length; i++)
            {
                if (modifierOrder[i] == modifier)
                {
                    cboModifier.SelectedIndex = i;
                    return;
                }
            }

            cboModifier.SelectedIndex = 0;
        }

        private void UpdateComboBoxes(Language language)
        {
            cboAccess.Items.Clear();
            cboModifier.Items.Clear();

            if (language == Language.CSharp)
            {
                cboAccess.Items.Add("Public");
                cboAccess.Items.Add("Protected Internal");
                cboAccess.Items.Add("Internal");
                cboAccess.Items.Add("Protected");
                cboAccess.Items.Add("Private");
                cboAccess.Items.Add("Default");

                cboModifier.Items.Add("None");
                cboModifier.Items.Add("Abstract");
                cboModifier.Items.Add("Sealed");
                cboModifier.Items.Add("Static");
            }
            else
            {
                cboAccess.Items.Add("Public");
                cboAccess.Items.Add("Protected");
                cboAccess.Items.Add("Private");
                cboAccess.Items.Add("Default");

                cboModifier.Items.Add("None");
                cboModifier.Items.Add("Abstract");
                cboModifier.Items.Add("Sealed");
                cboModifier.Items.Add("Static");
            }
        }

        private void project_StateChanged(object sender, EventArgs e)
        {
            UpdateHeader();
            UpdateStatusBar();
            UpdateComboBoxes(project.Language);

            if (!project.IsUntitled)
            {
                Settings.AddRecentFile(project.ProjectFile);
            }

            bool isNetLanguage = (project.Language == Language.CSharp);
        }

        private void diagram_SelectionChanged(object sender, EventArgs e)
        {
            UpdateStatusBar();
            UpdateModifiersToolBar();
            toolDelete.Enabled = (diagram.SelectedItemCount > 0);
        }

        private void Texts_LanguageChanged(object sender, EventArgs e)
        {
            UpdateStatusBar();
        }

        private void OpenRecentFile_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripItem && ((ToolStripItem)sender).Tag is int)
            {
                int index = (int)((ToolStripItem)sender).Tag;
                if (index >= 0 && index < Settings.RecentFileCount)
                {
                    LoadProject(Settings.GetRecentFile(index));
                }
            }
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        #region Diagram menu eventhandlers
        private void mnuNewClass_Click(object sender, EventArgs e)
        {
            project.AddClass("NewClass");
        }

        private void mnuNewAssociation_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Recuerda que en herencia la flecha apunta al padre.\n" +
                   "cada clase hijo debe tener los metodos del padre");
            diagram.StartConnection(RelationType.Association);
        }

        private void mnuNewComposition_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Recuerda que en herencia la flecha apunta al padre.\n" +
                   "cada clase hijo debe tener los metodos del padre");
            diagram.StartConnection(RelationType.Composition);
        }

        private void mnuNewAggregation_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Recuerda que en herencia la flecha apunta al padre.\n" +
                   "cada clase hijo debe tener los metodos del padre");
            diagram.StartConnection(RelationType.Aggregation);
        }
        private void mnuShowType_CheckedChanged(object sender, EventArgs e)
        {
            Settings.ShowType = ((ToolStripMenuItem)sender).Checked;
            diagram.Refresh();
        }

        private void mnuShowParameters_CheckedChanged(object sender, EventArgs e)
        {
            Settings.ShowParameters = ((ToolStripMenuItem)sender).Checked;
            diagram.Refresh();
        }

        private void mnuShowParameterNames_CheckedChanged(object sender, EventArgs e)
        {
            Settings.ShowParameterNames = ((ToolStripMenuItem)sender).Checked;
            diagram.Refresh();
        }

        private void mnuShowInitialValue_CheckedChanged(object sender, EventArgs e)
        {
            Settings.ShowInitialValue = ((ToolStripMenuItem)sender).Checked;
            diagram.Refresh();
        }

        private void mnuDelete_Click(object sender, EventArgs e)
        {
            diagram.RemoveSelectedItems();
        }

        #endregion
        #region Details toolbar eventhandlers

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            if (diagram.SelectedItemCount == 1 && diagram.FirstSelectedItem is TypeShape)
            {
                TypeShape shape = (TypeShape)diagram.FirstSelectedItem;
                TypeBase type = (TypeBase)shape.Entity;

                if (type.Name != txtName.Text)
                {
                    try
                    {
                        type.Name = txtName.Text;
                        project.IsDirty = true;
                        UpdateStatusBar();
                        shape.Refresh();
                    }
                    catch (BadSyntaxException)
                    {
                        // Ignores the incorrect name
                    }
                }
            }
        }

        private void cboAccess_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (diagram.SelectedItemCount == 1 && diagram.FirstSelectedItem is TypeShape)
            {
                TypeShape shape = (TypeShape)diagram.FirstSelectedItem;
                TypeBase type = (TypeBase)shape.Entity;

                int index = cboAccess.SelectedIndex;
                if (type.Language == Language.CSharp)
                {
                    type.AccessModifier = csharpAccessOrder[index];
                }
                else
                {
                    type.AccessModifier = javaAccessOrder[index];
                }

                shape.Refresh();
            }
        }

        private void cboModifier_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (diagram.SelectedItemCount == 1 && diagram.FirstSelectedItem is ClassShape)
            {
                ClassShape shape = (ClassShape)diagram.FirstSelectedItem;
                ClassType type = (ClassType)shape.Entity;

                int index = cboModifier.SelectedIndex;
                if (type.Language == Language.CSharp)
                {
                    type.Modifier = csharpModifierOrder[index];
                }
                else
                {
                    type.Modifier = javaModifierOrder[index];
                }

                shape.Refresh();
            }
        }

        #endregion

        private void toolNewGeneralization_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Recuerda que en herencia la flecha apunta al padre.\n" +
                   "cada clase hijo debe tener los metodos del padre");
            diagram.StartConnection(RelationType.Generalization);
        }
    }
}