using System.Xml.Serialization;

namespace NClass.GUI.Diagram
{
	[XmlType("DiagramSettings")]
	public class Settings
	{
		static Settings currentSettings = new Settings();

		bool usePrecisionSnapping = true;
		int workspaceWidth = 3200;
		int workspaceHeight = 2400;

		bool isPublicVisible = true;
		bool isProtintVisible = true;
		bool isInternalVisible = true;
		bool isProtectedVisible = true;
		bool isPrivateVisible = true;

		bool showType = true;
		bool showParameters = true;
		bool showParameterNames = true;
		bool showInitialValue = true;

		private Settings() { }

		public static Settings CurrentSettings
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

		public bool UsePrecisionSnapping
		{
			get { return usePrecisionSnapping; }
			set { usePrecisionSnapping = value; }
		}

		public int WorkspaceWidth
		{
			get
			{
				return workspaceWidth;
			}
			set
			{
				if (value >= 100 && value <= 10000)
					workspaceWidth = value;
			}
		}

		public int WorkspaceHeight
		{
			get
			{
				return workspaceHeight;
			}
			set
			{
				if (value >= 100 && value <= 10000)
					workspaceHeight = value;
			}
		}

		public bool IsPublicVisible
		{
			get { return isPublicVisible; }
			set { isPublicVisible = value; }
		}

		public bool IsProtintVisible
		{
			get { return isProtintVisible; }
			set { isProtintVisible = value; }
		}

		public bool IsInternalVisible
		{
			get { return isInternalVisible; }
			set { isInternalVisible = value; }
		}

		public bool IsProtectedVisible
		{
			get { return isProtectedVisible; }
			set { isProtectedVisible = value; }
		}

		public bool IsPrivateVisible
		{
			get { return isPrivateVisible; }
			set { isPrivateVisible = value; }
		}

		public bool ShowType
		{
			get { return showType; }
			set { showType = value; }
		}

		public bool ShowParameters
		{
			get
			{
				return showParameters;
			}
			set
			{
				if (!value)
					showParameterNames = false;
				showParameters = value;
			}
		}

		public bool ShowParameterNames
		{
			get
			{
				return showParameterNames;
			}
			set
			{
				if (value)
					showParameters = true;
				showParameterNames = value;
			}
		}

		public bool ShowInitialValue
		{
			get { return showInitialValue; }
			set { showInitialValue = value; }
		}
	}
}
