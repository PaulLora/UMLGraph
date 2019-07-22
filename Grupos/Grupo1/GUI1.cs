using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Microsoft.VisualBasic;

namespace UMLGraph.Grupos.Grupo1
{
    public partial class GUI1 : Form
    {
        [DllImport("user32.dll")]
        // GetCursorPos()hace todo posible
        static extern bool GetCursorPos(ref Point lpPoint);
        // Variable que necesitaremos para contar los pixeles viajados
        static protected long totalPixels = 0;
        static protected int currX;
        static protected int currY;
        static protected int diffX;
        static protected int diffY;

        Forma_Clase variableClase = new Forma_Clase();
        Forma_Interfaz variableInterfaz = new Forma_Interfaz();
        Forma_Asociacion variableAsociasion;
        List<Panel> clase = new List<Panel>();
        bool estaCreado = true;
        Canvas variableCanvas;
        int claseA, claseB;
        //Forma_Clase variableClase;

        public int xClick = 0, yClick = 0;



        public GUI1()
        {
           // MessageBox.Show("CALLA");
            InitializeComponent();
        }

        private void GUI1_Load(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {

            Application.Exit();
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            //btnRestaurar.Visible = false;
            //btnMaximizar.Visible = true;
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {

        }

        private void btnClase_Click(object sender, EventArgs e)
        {
            if (estaCreado == true)
            {
                Canvas c = new Canvas(this);
                Forma_Clase clase = new Forma_Clase();
                this.variableCanvas = c;
                this.variableClase = clase;
                variableClase.dibujar(variableCanvas);
                //this.clase = variableClase.ListaDeClase();

                // MessageBox.Show("");
                estaCreado = false;

            }

            else
            {
                variableClase.dibujar(variableCanvas);
                clase = variableClase.ListaDeClase();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (clase.Count < 2)
            {
                MessageBox.Show("Error para que exista Asociacion por lo menos debe haber 2 clases\n");
            }
            else
            {
                MessageBox.Show("RECUERDA TODOS LOS ATRIBUTOS Y METODOS \nDE LA CLASE A SE PASARAN A LA CLASE B");
                String name = Microsoft.VisualBasic.Interaction.InputBox(null, "Porfavor ingresa La clase A");
                claseA = Int32.Parse(name);
                name = Microsoft.VisualBasic.Interaction.InputBox(null, "Porfavor ingresa La clase B");
                claseB = Int32.Parse(name);
                Forma_Asociacion asociacion = new Forma_Asociacion(variableCanvas, variableClase, clase, claseA, claseB);
                this.variableAsociasion = asociacion;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (estaCreado == true)
            {
                Canvas c = new Canvas(this);
                Forma_Interfaz interfaz = new Forma_Interfaz();
                this.variableCanvas = c;
                this.variableInterfaz = interfaz;
                variableInterfaz.dibujar(variableCanvas);
                estaCreado = false;
            }

            else
            {

                variableInterfaz.dibujar(variableCanvas);


            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)

            { xClick = e.X; yClick = e.Y; }

            else

            { this.Left = this.Left + (e.X - xClick); this.Top = this.Top + (e.Y - yClick); }
        }

        private static Point FindLocation(Control ctrl)
        {
            Point p;
            for (p = ctrl.Location; ctrl.Parent != null; ctrl = ctrl.Parent)
                p.Offset(ctrl.Parent.Location);
            return p;
        }

    }
}
