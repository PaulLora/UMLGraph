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
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
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

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Inicio().Show();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void IngresarUsuario(string usuario, string clave)
        {
            StreamWriter WriteReportFile = File.AppendText(@"Usuarios.txt");
            WriteReportFile.WriteLine("\n\n"+usuario+";"+clave);
            WriteReportFile.Close();
        }

        private void BtnRegistrarse_Click(object sender, EventArgs e)
        {
            MessageBox.Show("asd");
            if (string.Equals(this.txtClave.Text, this.txtConfirmacionClave.Text))
            {
                MessageBox.Show("Usuario registrado correctamente.\nRegrese al inicio para poder ingresar");
                IngresarUsuario(this.txtNomUsuario.Text, this.txtClave.Text);
            }
            else
            {
                MessageBox.Show("La confirmacion de clave y la clave deben ser iguales");
            }
        }
    }
}
