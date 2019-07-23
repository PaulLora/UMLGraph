using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UMLGraph.Grupos.Grupo6.Vista;

namespace UMLGraph.Grupos.Grupo6.Modelo
{
    class Clase : Figura
    {   
        // Escuchar cuando ocurre evento y manejar el cmabio de posicion
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        // envia mensaje cuando captura un evento
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private PantallaTrabajoGr6 pantallaTrabajo;

        /************************* Atributos *****************************/
        private String idClase;
        private String titulo;
        private List<String> atributos;
        private List<String> metodos;
        private Panel panelContenedor;

        /************************* Constructores *****************************/
        public Clase()
        {
            this.LocalizacionX = 70;
            this.LocalizacionY = 60;
            this.Ancho = 175;
            this.Alto = 210;
        }

        public Clase(PantallaTrabajoGr6 pantallaTrabajoRecibida, string idClase, string titulo, List<string> atributos, List<string> metodos)
        {
            this.LocalizacionX = 70;
            this.LocalizacionY = 60;
            this.Ancho = 175;
            this.Alto = 210;
            this.idClase = idClase;
            this.titulo = titulo;
            this.atributos = atributos;
            this.metodos = metodos;
            this.pantallaTrabajo = pantallaTrabajoRecibida;
        }

        /************************* GETTERS AND SETTERS *****************************/
        public string IdClase { get => idClase; set => idClase = value; }
        public string Titulo { get => titulo; set => titulo = value; }
        public List<string> Atributos { get => atributos; set => atributos = value; }
        public List<string> Metodos { get => metodos; set => metodos = value; }
        public Panel GetPanelContenedor()
        {
            return this.panelContenedor;
        }
        /************************* MÉTODOS *****************************/
        public void crearPanel()
        {
            Panel panelContenedor = new System.Windows.Forms.Panel();

            Label lbl_idClase = new System.Windows.Forms.Label();
            Label lbl_titulo = new System.Windows.Forms.Label();
            Label lbl_atributos = new System.Windows.Forms.Label();
            Label lbl_metodos = new System.Windows.Forms.Label();

            //IdCLase
            lbl_idClase.Location = new Point(60, 8);
            lbl_idClase.UseMnemonic = true;
            lbl_idClase.Size = new Size(40, 15);
            lbl_idClase.BackColor = Color.Transparent;
            //lbl_idClase.
            lbl_idClase.TextAlign = ContentAlignment.MiddleCenter;
            lbl_idClase.Text = this.idClase;
            //Titulo
            lbl_titulo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            lbl_titulo.Location = new Point(10, 25);
            lbl_titulo.UseMnemonic = true;
            lbl_titulo.Size = new Size(150, 15);
            lbl_titulo.BackColor = Color.White;
            lbl_titulo.Text = this.titulo;
            //Atributos
            lbl_atributos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            lbl_atributos.Location = new Point(10, 45);
            lbl_atributos.UseMnemonic = true;
            lbl_atributos.Size = new Size(150, 60);
            lbl_atributos.BackColor = Color.White;
            String atributosString = "";
            foreach (String atributo in this.atributos)
            {
                atributosString += atributo + "\n";
            }
            lbl_atributos.Text = atributosString;
            //Metodos
            lbl_metodos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            lbl_metodos.Location = new Point(10, 110);
            lbl_metodos.UseMnemonic = true;
            lbl_metodos.Size = new Size(150, 60);
            lbl_metodos.BackColor = Color.White;
            String metodosString = "";
            foreach (String metodo in this.metodos)
            {
                metodosString += metodo + "\n";
            }
            lbl_metodos.Text = metodosString;

            //Boton Editar
            Button btn_editarClase = new Button();
            btn_editarClase.Location = new System.Drawing.Point(10, 175);
            btn_editarClase.Size = new System.Drawing.Size(150, 25);
            btn_editarClase.BackColor = Color.LightSteelBlue;
            btn_editarClase.Text = "EDITAR CLASE";
            btn_editarClase.TextAlign = ContentAlignment.MiddleCenter;
            //Configuracion Panel
            panelContenedor.Location = new System.Drawing.Point(this.LocalizacionX, this.LocalizacionY);
            panelContenedor.Size = new System.Drawing.Size(this.Ancho, this.Alto);
            panelContenedor.Name = this.idClase;
            panelContenedor.BackColor = Color.Wheat;
            //Agregamos Atributos metodos al panel
            panelContenedor.Controls.Add(lbl_idClase);
            panelContenedor.Controls.Add(lbl_titulo);
            panelContenedor.Controls.Add(lbl_atributos);
            panelContenedor.Controls.Add(lbl_metodos);
            panelContenedor.Controls.Add(btn_editarClase);
            panelContenedor.MouseDown += new System.Windows.Forms.MouseEventHandler(this.moverFigura);

            this.panelContenedor = panelContenedor;

        }

        /************************* MÉTODOS HEREDADOS *****************************/
        public override void dibujarFigura(Panel espaciotrabajo)
        {
            espaciotrabajo.Controls.Add(this.panelContenedor);
        }
        public override void moverFigura(Object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.panelContenedor.Handle, 0x112, 0xf012, 0);
            this.pantallaTrabajo.actulizarRelaciones();
        }
    }
}
