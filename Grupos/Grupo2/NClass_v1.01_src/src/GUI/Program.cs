using System;
using System.Windows.Forms;

namespace NClass.GUI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ToolStripManager.VisualStylesEnabled = false;

            Settings.LoadSettings();

            //if (args.Length >= 1)
            //	Application.Run(new MainForm(args[0]));
            //else
            Application.Run(new Login());

            Settings.SaveSettings();
        }
    }
}