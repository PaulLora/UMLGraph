using System;
using System.IO;
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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void BtnRestaurar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            btnRestaurar.Visible = false;
            btnMaximizar.Visible = true;
        }

        private void BtnMaximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            btnMaximizar.Visible = false;
            btnRestaurar.Visible = true;
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void BtnRestaurar_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Inicio().Show();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            ValidarClaveYUsuario(this.txtNomUsuario.Text, this.txtClave.Text);
            
        }

        private void Login_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void ValidarClaveYUsuario(string usuario, string clave)
        {
            string direccion;
            direccion = "Usuarios.txt";
            //Leemos todas las lineas del fichero con está función
            string[] strLineas = File.ReadAllLines(direccion);
            string[] campos;
            //Declaramos una lista para los campos de la linea concreta
            //que estamos recorriendo
            List<string> lineaMatriz = new List<string>(); ;
            //Recorremos todas las lineas del fichero
            foreach (string linea in strLineas)
            {
                
                //Partimos la linea con el caracter separador ";" indicado
                campos = linea.Split(";".ToCharArray());

                lineaMatriz.AddRange(campos.ToList());

                
            }

            for (int i = 0; i < lineaMatriz.Count; i++)
            {
                if (string.Equals(lineaMatriz[i], this.txtNomUsuario.Text))
                {
                    if (string.Equals(lineaMatriz[i + 1], this.txtClave.Text))
                    {
                        
                        this.Hide();
                        new InterfazGrafica(this.txtNomUsuario.Text).Show();
                        break;
                    }
                    else
                    {
                        MessageBox.Show("Clave incorrecta");
                    }
                }
                i++;
            }


        }

        private void TxtNomUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtNomUsuario_MouseUp(object sender, MouseEventArgs e)
        {
            txtNomUsuario.Text = "";

        }

        private void TxtClave_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void TxtClave_MouseUp(object sender, MouseEventArgs e)
        {
            txtClave.Text = "";
        }
    }
}
