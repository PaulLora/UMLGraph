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


namespace Grupo1Propietarios
{
    public partial class GUI : Form
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
        Forma_Interfaz variableInterfaz= new Forma_Interfaz();
        bool estaCreado = true;
        Canvas variableCanvas;
        //Forma_Clase variableClase;

        public int xClick = 0, yClick = 0;
      
       
 
        public GUI()
        {
            InitializeComponent();
               
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
            Application.Exit();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            btnMaximizar.Visible = false;
            btnRestaurar.Visible = true;
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            btnRestaurar.Visible = false;
            btnMaximizar.Visible = true;
        }
        //MOVER EL PANEL GRANDE 
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)

            { xClick = e.X; yClick = e.Y; }

            else

            { this.Left = this.Left + (e.X - xClick); this.Top = this.Top + (e.Y - yClick); }
        }


        //BOTON DE CREAR UNA CLASE
        private void button1_Click(object sender, EventArgs e)
        {

           /* Forma_Clase forma = new Forma_Clase();
            forma.dibujar(new Canvas(this));*/

           if (estaCreado == true)
            {
                Canvas c = new Canvas(this);
                Forma_Clase clase = new Forma_Clase();
                this.variableCanvas = c;
                this.variableClase = clase;
                variableClase.dibujar(variableCanvas);
                estaCreado = false;
            }

            else
            {

                variableClase.dibujar(variableCanvas);


            }
        }

        private void btnAsociacion_Click(object sender, EventArgs e)
        {
          
            Point x= FindLocation(this);
            List<Point> listaAsociacion = new List<Point>();
            listaAsociacion.Add(x);

        }

        private void GUI_Load(object sender, EventArgs e)
        {
            
          
        }

        private void btnInterfaz_Click(object sender, EventArgs e)
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

        // Declaraciones del API

        private static Point FindLocation(Control ctrl)
        {
            Point p;
            for (p = ctrl.Location; ctrl.Parent != null; ctrl = ctrl.Parent)
                p.Offset(ctrl.Parent.Location);
            return p;
        }


    }
}
