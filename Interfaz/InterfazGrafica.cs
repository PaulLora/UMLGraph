using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace UMLGraph
{
    public partial class InterfazGrafica : Form
    {
        public InterfazGrafica(String usuario)
        {
            InitializeComponent();
            btnBorrarLienzo.Visible = false;
            lblEnunciado.Text = en.EnunciadoTxt;
            lblNumEjericio.Text = en.NumEjercicio.ToString();
            lblUsuario.Text = usuario;
        }

        List<Clase> listaClases = new List<Clase>();
        Enunciado en = new Enunciado(1, "Se requiere un sistema para retirar dinero de un cajero.\nElabore el diagrama de clases para dicho sistema");

        
        //down es para saber si se esta clickeando algo
        bool down = false;
        //inicial es para definir el punto donde esta el mouse cuando hace click
        Point inicial;

        //Todo lo que tenga Mouse es para mover las figuras
        private void Ctr_MouseMove(object sender, MouseEventArgs e)
        {
            Control ctr = (Control)sender;

            //Si down es true se esta clickeando el mouse, ademas se verifica que no se pueda arrastrar la figura mas alla del espacio permitido
            if (down
                && e.X + ctr.Left - inicial.X >= this.panel1.Width
                && e.Y + ctr.Top - inicial.Y >= panel2.Height)
            {
                ctr.Left = e.X + ctr.Left - inicial.X;
                ctr.Top = e.Y + ctr.Top - inicial.Y;
            }
        }

        private void Ctr_MouseUp(object sender, MouseEventArgs e) => down = false;

        List<Point> lista = new List<Point>();
        private void Ctr_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                down = true;
                inicial = e.Location;
            }
        }

        private void btnClase_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Recuerda que el nombre de las clases es en singular.\n" +
                "Fíjate que los atributos y métodos correspondan a la clase");
            //Se añade una nueva clase a la lista
            listaClases.Add(new Clase(160, 120));

            //Aqui se añade el panel de la clase a los controles del Form
            this.Controls.Add(listaClases.Last().getCaja());
            

            //Este paso es para que el picture box se pueda mover arrastrando con el mouse
            listaClases.Last().getCaja().MouseDown += Ctr_MouseDown;
            listaClases.Last().getCaja().MouseUp += Ctr_MouseUp;
            listaClases.Last().getCaja().MouseMove += Ctr_MouseMove;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }



        private void Button9_Click(object sender, EventArgs e)
        {
            //listaClases.Clear();
            //this.Controls.Add(listaClases.Last().getCaja());
        }

        private void BtnInterfaz_Click(object sender, EventArgs e)
        {

            //Se añade una nueva clase a la lista
            listaClases.Add(new Clase(160, 120));

            //Aqui se añade el panel de la clase a los controles del Form
            this.Controls.Add(listaClases.Last().getCaja());


            //Este paso es para que el picture box se pueda mover arrastrando con el mouse
            listaClases.Last().getCaja().MouseDown += Ctr_MouseDown;
            listaClases.Last().getCaja().MouseUp += Ctr_MouseUp;
            listaClases.Last().getCaja().MouseMove += Ctr_MouseMove;


        }

        private void BtnDependencia_Click(object sender, EventArgs e)
        {
            Dependencia dep = new Dependencia(160,120);
        //    dep.dibujar(e);
        }

        private void BtbCerrarSesion_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Inicio().Show();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void InterfazGrafica_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void PnlTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnRestaurar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            btnRestaurar.Visible = false;
            btnMaximizar.Visible = true;
        }

        private void BtnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void BtnMaximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            btnMaximizar.Visible = false;
            btnRestaurar.Visible = true;
        }
    }
}
