using System;
using System.IO;
using System.Xml;
using System.Windows.Forms;
using NClass.Core;
using NClass.GUI.Diagram;

namespace NClass.GUI
{
	public sealed class Project : ProjectCore
	{
		bool isDirty;
		bool isReadonly;
		IDiagramVisualizer visualizer;

		public event EventHandler StateChanged;

		/// <exception cref="ArgumentNullException">
		/// <paramref name="visualizer"/> is null.
		/// </exception>
		public Project(IDiagramVisualizer visualizer)
			: this(visualizer, Settings.DefaultLanguage)
		{
		}

		/// <exception cref="ArgumentNullException">
		/// <paramref name="visualizer"/> is null.
		/// </exception>
		public Project(IDiagramVisualizer visualizer, Language language) : base(language)
		{
			if (visualizer == null)
				throw new ArgumentNullException("visualizer");

			isDirty = false;
			isReadonly = false;
			this.visualizer = visualizer;

			this.visualizer.ContentsChanged +=
				new EventHandler(visualizer_ContentsChanged);
			this.visualizer.ConnectionCreated +=
				new ConnectionCreatedEventHandler(visualizer_ConnectionCreated);
			this.visualizer.EntityRemoved +=
				new EntityRemovedEventHandler(visualizer_EntityRemoved);
			this.visualizer.RelationRemoved +=
				new RelationRemovedEventHandler(visualizer_RelationRemoved);
		}

		public bool IsDirty
		{
			get
			{
				return isDirty;
			}
			set
			{
				if (value != isDirty && StateChanged != null) {
					isDirty = value;
					StateChanged(this, EventArgs.Empty);
				}
				else {
					isDirty = value;
				}
			}
		}

		public bool IsReadonly
		{
			get
			{
				return isReadonly;
			}
			private set
			{
				if (value != isReadonly && StateChanged != null) {
					isReadonly = value;
					StateChanged(this, EventArgs.Empty);
				}
				else {
					isReadonly = value;
				}
			}
		}

		public bool IsUntitled
		{
			get { return string.IsNullOrEmpty(ProjectFile); }
		}

		public string ProjectFileName
		{
			get
			{
				if (IsUntitled)
					return "untitled";
				else
					return Path.GetFileName(ProjectFile);
			}
		}

		public string ProjectFileNameWithoutExtension
		{
			get
			{
				if (IsUntitled)
					return "untitled";
				else
					return Path.GetFileNameWithoutExtension(ProjectFile);
			}
		}

		public string ProjectDirectory
		{
			get
			{
				if (IsUntitled)
					return Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
				else
					return Path.GetDirectoryName(ProjectFile);
			}
		}
		
		private void visualizer_ContentsChanged(object sender, EventArgs e)
		{
			IsDirty = true;
		}

		private void visualizer_EntityRemoved(object sender, EntityRemovedEventArgs e)
		{
			RemoveEntity(e.Entity);
			IsDirty = true;
		}

		private void visualizer_RelationRemoved(object sender, RelationRemovedEventArgs e)
		{
			RemoveRelation(e.Relation);
			IsDirty = true;
		}

		private void visualizer_ConnectionCreated(object sender, ConnectionCreatedEventArgs e)
		{
			try {
				Relation relation = AddRelation(e.First, e.Second, e.RelationType);
				visualizer.AddRelation(relation, true);
			}
			catch (ArgumentException ex) {
				MessageBox.Show(ex.Message, "error",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private DialogResult AskSaveModifying()
		{
			return MessageBox.Show("save_changes_confirmation",
				"confirmation",
				MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
		}

		public bool CanClose()
		{
			if (isDirty) {
				switch (AskSaveModifying()) {
					case DialogResult.Yes:
						return Save();
					case DialogResult.No:
						return true;
					case DialogResult.Cancel:
					default:
						return false;
				}
			}
			else {
				return true;
			}
		}

		public override void NewProject()
		{
			if (CanClose()) {
				base.NewProject();

				isDirty = false;
				visualizer.Clear();
				if (StateChanged != null)
					StateChanged(this, EventArgs.Empty);
			}
		}

		public override void NewProject(Language language)
		{
			if (CanClose()) {
				base.NewProject(language);
				Settings.DefaultLanguage = language;
			}
		}

		protected override void AddEntity(Entity entity)
		{
			base.AddEntity(entity);
			visualizer.AddEntity(entity);
		}

		public bool Load()
		{
			try {
				if (CanClose()) {
					using (OpenFileDialog dialog = new OpenFileDialog()) {
						dialog.Filter = string.Format(
							"NClass {0} (*.csd; *.jd)|*.csd;*.jd|C# {0} (*.csd)|" +
							"*.csd|Java {0} (*.jd)|*.jd", "diagrams");
						dialog.InitialDirectory = ProjectDirectory;
						dialog.ShowReadOnly = true;

						if (dialog.ShowDialog() == DialogResult.OK) {
							isDirty = false;
							Load(dialog.FileName);
							IsReadonly = dialog.ReadOnlyChecked;
							return true;
						}
					}
				}
			}
			catch (Exception ex) {
				MessageBox.Show("error" + ": " + ex.Message,
					"load", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

			return false;
		}

		/// <exception cref="IOException">
		/// Could not load the project.
		/// </exception>
		/// <exception cref="InvalidDataException">
		/// The save file is corrupt and could not load.
		/// </exception>
		/// <exception cref="ArgumentException">
		/// <paramref name="fileName"/> is empty string.
		/// </exception>
		public override void Load(string fileName)
		{
			if (CanClose()) {
				visualizer.Clear();
				isDirty = false;
				base.Load(fileName);

				isDirty = false;
				isReadonly = false;
				if (StateChanged != null)
					StateChanged(this, EventArgs.Empty);
				visualizer.LoadingFinished();
			}
		}

		public override bool Save()
		{
			if (IsUntitled || IsReadonly) {
				return SaveAs();
			}
			else {
				try {
					base.Save();
					IsDirty = false;
					return true;
				}
				catch (IOException ex) {
					MessageBox.Show("error" + ": " + ex.Message,
						"save", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return SaveAs();
				}
			}
		}

		/// <exception cref="IOException">
		/// Could not save the project.
		/// </exception>
		/// <exception cref="ArgumentException">
		/// <paramref name="fileName"/> is empty string.
		/// </exception>
		protected override void Save(string fileName)
		{
			base.Save(fileName);

			isDirty = false;
			isReadonly = false;
			if (StateChanged != null)
				StateChanged(this, EventArgs.Empty);
		}

		/// <exception cref="ArgumentNullException">
		/// <paramref name="root"/> is null.
		/// </exception>
		protected override void Serialize(XmlNode node)
		{
			base.Serialize(node);

			XmlElement child = node.OwnerDocument.CreateElement("Positions");
			visualizer.Serialize(child);
			node.AppendChild(child);
		}

		/// <exception cref="InvalidDataException">
		/// The save format is corrupt and could not load.
		/// </exception>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="root"/> is null.
		/// </exception>
		protected override void Deserialize(XmlNode node)
		{
			base.Deserialize(node);

			foreach (Entity entity in Entities)
				visualizer.AddEntity(entity);
			foreach (Relation relation in Relations)
				visualizer.AddRelation(relation, false);

			XmlElement child = node["Positions"];
			if (child != null)
				visualizer.Deserialize(child);
		}

		public bool SaveAs()
		{
			try {
				using (SaveFileDialog dialog = new SaveFileDialog()) {
					dialog.FileName = ProjectFileNameWithoutExtension;
					dialog.InitialDirectory = ProjectDirectory;

					if (Language == Language.CSharp)
						dialog.Filter =  "C#" + "|*.csd";
					else
						dialog.Filter =  "Java" + "|*.jd";

					if (dialog.ShowDialog() == DialogResult.OK) {
						Save(dialog.FileName);
						return true;
					}
				}
			}
			catch (Exception ex) {
				MessageBox.Show("error" + ": " + ex.Message,
					"save_as", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

			return false;
		}

		public override string ToString()
		{
			string fileName;

			if (IsUntitled)
				fileName = "untitled";
			else if (Settings.ShowFullFilePath)
				fileName = ProjectFile;
			else
				fileName = ProjectFileName;

			if (isDirty) {
				if (isReadonly)
					return string.Format("{0}* ({1})", fileName, "readonly");
				else
					return fileName + "*";
			}
			else {
				if (IsReadonly)
					return string.Format("{0} ({1})", fileName, "readonly");
				else
					return fileName;
			}
		}
	}
}
