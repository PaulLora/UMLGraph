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
using UMLGraph.Grupos;
using UMLGraph.Grupos.Grupo3.Interfaz;
using UMLGraph.Grupos.Grupo3;
using UMLGraph.Grupos.Grupo3.Figuras;

namespace UMLGraph
{
    public partial class InterfazGrafica : Form
    {
        //Se creo una clase que contenga las varialbes minimas necesarias para el funcionamiento del código
        //Del grupo diferente en este caso la llame InterfazGR3 pero no es un interface en si mismo
        InterfazGR3 gr3;
        //Strign para chequear cual grupo fue seleccionado
        String selected = "GRX";
        public InterfazGrafica(String usuario)
        {
            InitializeComponent();
            btnBorrarLienzo.Visible = false;
            lblEnunciado.Text = en.EnunciadoTxt;
            lblNumEjericio.Text = en.NumEjercicio.ToString();
            lblUsuario.Text = usuario;
            /////////////////////////////////////////////
            //Mi codigo funcionaba mejor maximizado por lo que agrege esa linea
            this.WindowState = FormWindowState.Maximized;
            //En las lineas siguientes creo una lista de grupos para que se pueda seleccionar GR1,GR2,...
            var grupos = new List<Groups>();//Se creo una clase Groups sencilla que guarda un name y un value
            grupos.Add(new Groups() { Name = "Grupo X", Value = "GRX" });//Agregue los gurpos el codigo original es el X de esta forma deberian agregarse los sigueintes grupos
            grupos.Add(new Groups() { Name = "Grupo 3", Value = "GR3" });
            //Se llena el comboBox
            this.CmbSelecGrupo.DataSource = grupos;
            this.CmbSelecGrupo.DisplayMember = "Name";//Se define que será mostrado y seleccionamos el atributo name
            this.CmbSelecGrupo.ValueMember = "Value";//Se define cual sera el valor de lo mostrado y seleccionamos el atributo value
            //Instancio la interfaz, la mia necesita los tamanios de la ventana por lo que le envio eso
            gr3 = new InterfazGR3(new Size(this.Width * 3, this.Height * 3));
        }

        List<Clase> listaClases = new List<Clase>();
        List<Interfaz> listaInterfaces = new List<Interfaz>();
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
            //Codigo original dle programa se activara si el elemento seleccionado es GRX
            if (selected.Equals("GRX"))
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
            //Parte anexada del Grupo 3 se activa si es GR3
            else if (selected.Equals("GR3"))
            {
                //Se crea un panel local
                Panel panel = new Panel();
                //Aplicamos la funcion crearpanel que inicializa todo lo que la clase debe tener
                gr3.CrearPanel(ref panel);
                //agrego a la lista de paneles al nuevo panel
                gr3.paneles.Add(panel);
            }
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
            if (selected.Equals("GRX"))
            {
                //Se añade una nueva clase a la lista
                listaInterfaces.Add(new Interfaz(160, 120));

                //Aqui se añade el panel de la clase a los controles del Form
                this.Controls.Add(listaInterfaces.Last().getCaja());


                //Este paso es para que el picture box se pueda mover arrastrando con el mouse
                listaInterfaces.Last().getCaja().MouseDown += Ctr_MouseDown;
                listaInterfaces.Last().getCaja().MouseUp += Ctr_MouseUp;
                listaInterfaces.Last().getCaja().MouseMove += Ctr_MouseMove;
            }
            


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

        private void InterfazGrafica_Load(object sender, EventArgs e)
        {

        }

        private void CmbSelecGrupo_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Console.WriteLine(CmbSelecGrupo.GetItemText(CmbSelecGrupo.SelectedItem));
            //Determinamos que item fue seleccionado y si pertenece a un grupo determinado
            if (CmbSelecGrupo.GetItemText(CmbSelecGrupo.SelectedItem).Equals("Grupo 3"))
            {
                Controls.Add(gr3.masterPanel);
                this.selected = "GR3";
            }
        }

        private void BtnRelacion_Click(object sender, EventArgs e)
        {
            if (selected.Equals("GRX"))
            {

            }
            //Parte anexada del Grupo 3 se activa si es GR3
            else if (selected.Equals("GR3"))
            {
                //Habilitamos drawing bandera que sirve para guardar los puntos
                gr3.drawing = true;
                //Creamos una figura_relacion local
                Figura_Relacion tmp = new Figura_Relacion();
                //Inicializamos la lista de puntos donde se guardara para dibuajr la linea
                tmp.RelPuntos = new List<Point>();
                //Agregamos la figura_relacion local a la lista y a la lista de formas
                gr3.relaciones.Add(tmp);
                gr3.Formas.Formas.Add(tmp);
            }
        }
    }
}
