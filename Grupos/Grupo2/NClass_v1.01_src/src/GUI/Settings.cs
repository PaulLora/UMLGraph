using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;
using NClass.Core;

namespace NClass.GUI
{
	public sealed class Settings
	{
		[XmlType("GeneralSettings")]
		public class General
		{
			const int MaxRecentCount = 5;
			static General currentSettings = new General();

			Language defaultLanguage = Language.CSharp;
			bool loadLastProject = true;
			bool showFullFilePath = true;
			List<string> recentFiles = new List<string>(MaxRecentCount);

			private General() { }

			public static General CurrentSettings
			{
				get
				{
					return currentSettings;
				}
				set
				{
					if (value != null)
						currentSettings = value;
				}
			}

			public Language DefaultLanguage
			{
				get { return defaultLanguage; }
				set { defaultLanguage = value; }
			}

			public bool LoadLastProject
			{
				get { return loadLastProject; }
				set { loadLastProject = value; }
			}

			public bool ShowFullFilePath
			{
				get { return showFullFilePath; }
				set { showFullFilePath = value; }
			}

			[XmlArrayItem("File")]
			public List<string> RecentFiles
			{
				get
				{
					return recentFiles;
				}
				set
				{
					if (value != null)
						recentFiles = value;
				}
			}

			public void AddRecentFile(string recentFile)
			{
				if (!File.Exists(recentFile))
					return;

				int index = recentFiles.IndexOf(recentFile);

				if (index >= 0) {
					if (index > 0) {
						string temp = recentFiles[index];
						for (int i = index; i > 0; i--)
							recentFiles[i] = recentFiles[i - 1];
						recentFiles[0] = temp;
					}
				}
				else {
					if (recentFiles.Count < MaxRecentCount)
						recentFiles.Add("");
					for (int i = recentFiles.Count - 2; i >= 0; i--)
						recentFiles[i + 1] = recentFiles[i];
					recentFiles[0] = recentFile;
				}
			}

			/// <exception cref="ArgumentOutOfRangeException">
			/// <paramref name="index"/> is less than 0 or 
			/// is equal to or greater than <see cref="RecentFileCount"/>.
			/// </exception>
			public string GetRecentFile(int index)
			{
				return recentFiles[index];
			}

			internal void RemoveDeadRecents()
			{
				for (int i = 0; i < RecentFiles.Count; i++) {
					if (!File.Exists(RecentFiles[i]))
						RecentFiles.RemoveAt(i--);
				}
			}
		}

		static readonly string filePath =
			Path.Combine(Application.StartupPath, "settings.xml");
		static Settings currentSettings = new Settings();

		private Settings() { }

		[XmlElement("General")]
		public General GeneralSettings
		{
			get { return General.CurrentSettings; }
			set { General.CurrentSettings = value; }
		}

		[XmlElement("Diagram")]
		public Diagram.Settings DiagramSettings
		{
			get { return Diagram.Settings.CurrentSettings; }
			set { Diagram.Settings.CurrentSettings = value; }
		}

		#region Static properties

		public static Language DefaultLanguage
		{
			get { return General.CurrentSettings.DefaultLanguage; }
			set { General.CurrentSettings.DefaultLanguage = value; }
		}

		public static bool LoadLastProject
		{
			get { return General.CurrentSettings.LoadLastProject; }
			set { General.CurrentSettings.LoadLastProject = value; }
		}

		public static string LastProject
		{
			get
			{
				if (RecentFileCount > 0)
					return GetRecentFile(0);
				else
					return null;
			}
		}

		public static bool ShowFullFilePath
		{
			get { return General.CurrentSettings.ShowFullFilePath; }
			set { General.CurrentSettings.ShowFullFilePath = value; }
		}

		public static int RecentFileCount
		{
			get { return General.CurrentSettings.RecentFiles.Count; }
		}

		public static bool UsePrecisionSnapping
		{
			get { return Diagram.Settings.CurrentSettings.UsePrecisionSnapping; }
			set { Diagram.Settings.CurrentSettings.UsePrecisionSnapping = value; }
		}

		public static int WorkspaceWidth
		{
			get { return Diagram.Settings.CurrentSettings.WorkspaceWidth; }
			set { Diagram.Settings.CurrentSettings.WorkspaceWidth = value; }
		}

		public static int WorkspaceHeight
		{
			get { return Diagram.Settings.CurrentSettings.WorkspaceHeight; }
			set { Diagram.Settings.CurrentSettings.WorkspaceHeight = value; }
		}

		public static bool IsPublicVisible
		{
			get { return Diagram.Settings.CurrentSettings.IsPublicVisible; }
			set { Diagram.Settings.CurrentSettings.IsPublicVisible = value; }
		}

		public static bool IsProtintVisible
		{
			get { return Diagram.Settings.CurrentSettings.IsProtintVisible; }
			set { Diagram.Settings.CurrentSettings.IsProtintVisible = value; }
		}

		public static bool IsInternalVisible
		{
			get { return Diagram.Settings.CurrentSettings.IsInternalVisible; }
			set { Diagram.Settings.CurrentSettings.IsInternalVisible = value; }
		}

		public static bool IsProtectedVisible
		{
			get { return Diagram.Settings.CurrentSettings.IsProtectedVisible; }
			set { Diagram.Settings.CurrentSettings.IsProtectedVisible = value; }
		}

		public static bool IsPrivateVisible
		{
			get { return Diagram.Settings.CurrentSettings.IsPrivateVisible; }
			set { Diagram.Settings.CurrentSettings.IsPrivateVisible = value; }
		}

		public static bool ShowType
		{
			get { return Diagram.Settings.CurrentSettings.ShowType; }
			set { Diagram.Settings.CurrentSettings.ShowType = value; }
		}

		public static bool ShowParameters
		{
			get { return Diagram.Settings.CurrentSettings.ShowParameters; }
			set { Diagram.Settings.CurrentSettings.ShowParameters = value; }
		}

		public static bool ShowParameterNames
		{
			get { return Diagram.Settings.CurrentSettings.ShowParameterNames; }
			set { Diagram.Settings.CurrentSettings.ShowParameterNames = value; }
		}

		public static bool ShowInitialValue
		{
			get { return Diagram.Settings.CurrentSettings.ShowInitialValue; }
			set { Diagram.Settings.CurrentSettings.ShowInitialValue = value; }
		}

		#endregion

		public static void AddRecentFile(string recentFile)
		{
			General.CurrentSettings.AddRecentFile(recentFile);
		}

		/// <exception cref="ArgumentOutOfRangeException">
		/// <paramref name="index"/> is less than 0 or 
		/// is equal to or greater than <see cref="RecentFileCount"/>.
		/// </exception>
		public static string GetRecentFile(int index)
		{
			return General.CurrentSettings.GetRecentFile(index);
		}

		public static void ClearRecentsList()
		{
			General.CurrentSettings.RecentFiles.Clear();
		}

		public static bool LoadSettings()
		{
			try {
				XmlTextReader reader = new XmlTextReader(filePath);
				XmlSerializer serializer = new XmlSerializer(typeof(Settings));

				currentSettings = (Settings) serializer.Deserialize(reader);
				currentSettings.GeneralSettings.RemoveDeadRecents();
				return true;
			}
			catch {
				return false;
			}
		}

		public static bool SaveSettings()
		{
			try {
				TextWriter writer = new StreamWriter(filePath);
				XmlSerializer serializer = new XmlSerializer(typeof(Settings));
				XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
				namespaces.Add("", "");

				serializer.Serialize(writer, currentSettings, namespaces);
				return true;
			}
			catch {
				return false;
			}
		}
	}
}
