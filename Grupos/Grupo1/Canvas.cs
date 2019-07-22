using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UMLGraph
{
    class Canvas:Form
    {

     
        public Panel panelMaster { get; set; }
        Button btnSalir = new System.Windows.Forms.Button();
        private Button button1;
        bool bandera = true;
        List<Point> lista = new List<Point>();

        public Canvas(Form GUI)
        {
           
           panelMaster = new Panel();
           panelMaster.Location = new System.Drawing.Point(200, 28);
           panelMaster.Size = new System.Drawing.Size(800, 800);
           panelMaster.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
           GUI.Controls.Add(panelMaster);
        }


        public void iniciar()
        {
            

        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Canvas
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "Canvas";
            this.Load += new System.EventHandler(this.Canvas_Load);
            this.ResumeLayout(false);

        }

        private void Canvas_Load(object sender, EventArgs e)
        {

        }



    }
}
