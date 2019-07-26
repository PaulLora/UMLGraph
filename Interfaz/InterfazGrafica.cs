using NClass.GUI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using UMLGraph.Grupos;
using UMLGraph.Grupos.Grupo3.Figuras;
using UMLGraph.Grupos.Grupo6.Modelo;
using UMLGraph.Grupos.GrupoX.Figuras;
using UMLGraph.Grupos.Grupo3.Interfaz;
using UMLGraph.Grupos.Grupo6.Controlador;

namespace UMLGraph
{
    public partial class InterfazGrafica : Form
    {
       
        public InterfazGrafica(String usuario)
        {
            InitializeComponent();
            lblUsuario.Text = usuario;
            WindowState = FormWindowState.Maximized;
        }

        private void BtbCerrarSesion_Click(object sender, EventArgs e)
        {
            this.Dispose();
            new Inicio().Show();

        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private static extern void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private static extern void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void InterfazGrafica_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }

        private void PnlTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnRestaurar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
            btnRestaurar.Visible = false;
            btnMaximizar.Visible = true;
        }

        private void BtnMinimizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void BtnMaximizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            btnMaximizar.Visible = false;
            btnRestaurar.Visible = true;
        }

        private void BtnEnunciados_Click(object sender, EventArgs e)
        {
            pnlEjercicios.Visible = true;
            lblEnunciado.Visible = false;
        }

        private void BtnEnunciado1_Click(object sender, EventArgs e)
        {
            //pnlEjercicios.Visible = false;
            //this.pnlDibujar.Controls.Clear();
            //lblEnunciado.Visible = true;
            //this.pnlDibujar.BackgroundImage = base.BackgroundImage;
            //this.pnlDibujar = fachada.EjecutarEnunciado1(pnlDibujar);
            //lblEnunciado.Text = "Problema Grafique el diagrama ded clase de un sistema ATM";

        }

        private void BtnEnunciado2_Click(object sender, EventArgs e)
        {
            //pnlEjercicios.Visible = false;
            //Enunciado en = new Enunciado(4, "Se requiere un sistema para reservar habitaciones en un hotel.\nElabore el diagrama de clases para dicho sistema");
            //lblEnunciado.Visible = true;
            //lblEnunciado.Text = en.EnunciadoTxt;
            //pnlDibujar.Controls.Clear();
            //this.pnlDibujar = fachada.EjecutarEnunciado2(ref pnlDibujar);
        }

        private void BtnEnunciado3_Click(object sender, EventArgs e)
        {
            //pnlEjercicios.Visible = false;
            //lblEnunciado.Visible = true;
            //Enunciado en = new Enunciado(4, "Se requiere un sistema para retirar dinero de un cajero.\nElabore el diagrama de clases para dicho sistema");
            //this.pnlDibujar.BackgroundImage = base.BackgroundImage;
            //this.pnlDibujar.Controls.Clear();
            //Controls.Remove(this.pnlDibujar);
            //this.pnlDibujar = fachada.EjecutarEnunciado3(ref pnlDibujar);
            //Controls.Add(this.pnlDibujar);
            //lblEnunciado.Text = en.EnunciadoTxt;
        }

        private void BtnEnunciado4_Click(object sender, EventArgs e)
        {
            //pnlEjercicios.Visible = false;
            //lblEnunciado.Visible = true;
            //Enunciado en = new Enunciado(4, "Se requiere un sistema para retirar dinero de un cajero.\nElabore el diagrama de clases para dicho sistema");
            //this.pnlDibujar.BackgroundImage = base.BackgroundImage;
            //this.pnlDibujar.Controls.Clear();
            //this.pnlDibujar = fachada.EjecutarEnunciado4(pnlDibujar);
            //lblEnunciado.Text = en.EnunciadoTxt;
        }

        private void BtnEnunciado5_Click(object sender, EventArgs e)
        {
            //pnlEjercicios.Visible = false;
            //this.pnlDibujar.Controls.Clear();
            //Enunciado en = new Enunciado(4, "Se requiere un sistema para reservar habitaciones en un hotel.\nElabore el diagrama de clases para dicho sistema");
            //lblEnunciado.Visible = true;
            //lblEnunciado.Text = en.EnunciadoTxt;
            //this.pnlDibujar.BackgroundImage = base.BackgroundImage;
            ////SubsistemaGr5 sgr5 = new SubsistemaGr5();
            //this.pnlDibujar = sgr5.EjecutarEnunciado(pnlDibujar);
        }

        private void BtnEnunciado6_Click(object sender, EventArgs e)
        {
            pnlEjercicios.Visible = false;
            this.pnlDibujar.Controls.Clear();
            Enunciado en = new Enunciado(4, "Se requiere un sistema para reservar habitaciones en un hotel.\nElabore el diagrama de clases para dicho sistema");
            lblEnunciado.Visible = true;
            lblEnunciado.Text = en.EnunciadoTxt;
            this.pnlDibujar.BackgroundImage = base.BackgroundImage;
            SubsistemaGr6 sgr6 = new SubsistemaGr6();
            this.pnlDibujar = sgr6.EjecutarEnunciado(pnlDibujar);
            DialogResult seguro = MessageBox.Show("\t\tRECUERDE\n" + "\n" + "-->El nombre de la clase empieza con mayuscula." + "\n" + "-->Los atributos se escriben en minuscula." + "\n" + "-->Los metodos se escriben en minuscula.", "confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
