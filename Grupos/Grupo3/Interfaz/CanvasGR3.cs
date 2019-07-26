using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UMLGraph.Grupos.Grupo3.Figuras;
using UMLGraph.Grupos.Grupo3.Librerias;

namespace UMLGraph.Grupos.Grupo3.Interfaz
{
    public class CanvasGR3 : Form
    {
        private Button btnClase;
        private Button btnRelacion;
        private Button btnHerencia;
        private Button btnInterfaz;
        private Button btnAgregacion;
        private Button btnComposicion;

        public List<Panel> paneles { get; set; }
        public Lista_Figuras Figuras { get; set; }
        public Panel CanvasPanel { get; set; }
        public List<Figura_Relacion> relaciones { get; set; }

        public bool drawing { get; set; }
        public bool pnlMvd { get; set; }
        public CanvasGR3(Size tam)
        {

            //paneles = new List<Panel>();
            Figuras = new Lista_Figuras();
            CanvasPanel = new Panel();
            
            relaciones = new List<Figura_Relacion>();
            CanvasPanel.Location = new System.Drawing.Point(0, 150);
            CanvasPanel.Size = new Size(tam.Width * 2, tam.Height * 2);
            ControlCanvas.DefineOrigin(CanvasPanel, this);
            InitializeComponent();
        }
        public void CrearPanel()//permite crear un panel con una clase
        {
            Figura_Clase fig = new Figura_Clase();
            fig.DibujarFigura();
            
            ControlExtension.Draggable(fig.Contenedor, true);
            ControlCanvas.Relatable(fig.Contenedor, true);
            CargarFigura(fig);
            /*foreach(Control con in fig.ReturnControls())
            {
                CanvasPanel.Controls.Add(con);
            }*/
            CanvasPanel.Controls.Add(fig.Contenedor);

            //Console.WriteLine("Hola" + fig.Contenedor.Location);
        }
        private void LlenarClase_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {

        }

        private void InitializeComponent()
        {
            this.btnClase = new System.Windows.Forms.Button();
            this.btnRelacion = new System.Windows.Forms.Button();
            this.btnHerencia = new System.Windows.Forms.Button();
            this.btnInterfaz = new System.Windows.Forms.Button();
            this.btnAgregacion = new System.Windows.Forms.Button();
            
            this.btnComposicion = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnClase
            // 
            this.btnClase.Location = new System.Drawing.Point(13, 13);
            this.btnClase.Margin = new System.Windows.Forms.Padding(4);
            this.btnClase.Name = "btnClase";
            this.btnClase.Size = new System.Drawing.Size(176, 28);
            this.btnClase.TabIndex = 9;
            this.btnClase.Text = "Figuras clase";
            this.btnClase.UseVisualStyleBackColor = true;
            this.btnClase.Click += new System.EventHandler(this.BtnClase_Click);
            // 
            // btnRelacion
            // 
            this.btnRelacion.Location = new System.Drawing.Point(13, 84);
            this.btnRelacion.Margin = new System.Windows.Forms.Padding(4);
            this.btnRelacion.Name = "btnRelacion";
            this.btnRelacion.Size = new System.Drawing.Size(176, 28);
            this.btnRelacion.TabIndex = 10;
            this.btnRelacion.Text = "Crear Asociacion";
            this.btnRelacion.UseVisualStyleBackColor = true;
            this.btnRelacion.Click += new System.EventHandler(this.BtnRelacion_Click);
            // 
            // btnHerencia
            // 
            this.btnHerencia.Location = new System.Drawing.Point(13, 192);
            this.btnHerencia.Margin = new System.Windows.Forms.Padding(4);
            this.btnHerencia.Name = "btnHerencia";
            this.btnHerencia.Size = new System.Drawing.Size(176, 28);
            this.btnHerencia.TabIndex = 11;
            this.btnHerencia.Text = "Crear Herencia";
            this.btnHerencia.UseVisualStyleBackColor = true;
            this.btnHerencia.Click += new System.EventHandler(this.BtnHerencia_Click);
            // 
            // btnInterfaz
            // 
            this.btnInterfaz.Location = new System.Drawing.Point(13, 49);
            this.btnInterfaz.Margin = new System.Windows.Forms.Padding(4);
            this.btnInterfaz.Name = "btnInterfaz";
            this.btnInterfaz.Size = new System.Drawing.Size(176, 28);
            this.btnInterfaz.TabIndex = 12;
            this.btnInterfaz.Text = "Figuras interfaz";
            this.btnInterfaz.UseVisualStyleBackColor = true;
            this.btnInterfaz.Click += new System.EventHandler(this.BtnInterfaz_Click);
            // 
            // btnAgregacion
            // 
            this.btnAgregacion.Location = new System.Drawing.Point(13, 120);
            this.btnAgregacion.Margin = new System.Windows.Forms.Padding(4);
            this.btnAgregacion.Name = "btnAgregacion";
            this.btnAgregacion.Size = new System.Drawing.Size(176, 28);
            this.btnAgregacion.TabIndex = 13;
            this.btnAgregacion.Text = "Crear agregación";
            this.btnAgregacion.UseVisualStyleBackColor = true;
            this.btnAgregacion.Click += new System.EventHandler(this.BtnAgregacion_Click);
           
            // 
            // btnComposicion
            // 
            this.btnComposicion.Location = new System.Drawing.Point(13, 156);
            this.btnComposicion.Margin = new System.Windows.Forms.Padding(4);
            this.btnComposicion.Name = "btnComposicion";
            this.btnComposicion.Size = new System.Drawing.Size(176, 28);
            this.btnComposicion.TabIndex = 15;
            this.btnComposicion.Text = "Crear composición";
            this.btnComposicion.UseVisualStyleBackColor = true;
            this.btnComposicion.Click += new System.EventHandler(this.BtnComposicion_Click);
            // 
            // InterfazGR3
            // 
            this.ClientSize = new System.Drawing.Size(282, 253);
            
            CanvasPanel.Controls.Add(this.btnClase);
            CanvasPanel.Controls.Add(this.btnRelacion);
            CanvasPanel.Controls.Add(this.btnHerencia);
            CanvasPanel.Controls.Add(this.btnInterfaz);
            CanvasPanel.Controls.Add(this.btnAgregacion);
            CanvasPanel.Controls.Add(this.btnComposicion);
            this.Name = "InterfazGR3";
            this.Load += new System.EventHandler(this.InterfazGR3_Load);
            this.ResumeLayout(false);

        }

        private void InterfazGR3_Load(object sender, EventArgs e)
        {

        }

        private void BtnClase_Click(object sender, EventArgs e)
        {
            //Se crea un panel local
            //Panel panel = new Panel();
            //panel.Dispose();

            //Aplicamos la funcion crearpanel que inicializa todo lo que la clase debe tener
            CrearPanel();
            //agrego a la lista de paneles al nuevo panel
            //paneles.Add(panel);
        }

        private void BtnInterfaz_Click(object sender, EventArgs e)
        {

        }

        private void BtnRelacion_Click(object sender, EventArgs e)
        {
            //Habilitamos drawing bandera que sirve para guardar los puntos
            ControlCanvas.Drawing = true;
            //Creamos una figura_relacion local
            Figura_Asociacion tmp = new Figura_Asociacion();
            //ControlCanvas.Figuras.Figuras.Add(tmp);
            CargarFigura(tmp);
        }

        private void BtnAgregacion_Click(object sender, EventArgs e)
        {
            //Habilitamos drawing bandera que sirve para guardar los puntos
            ControlCanvas.Drawing = true;
            //Creamos una figura_relacion local
            Figura_Agregacion tmp = new Figura_Agregacion();
            //ControlCanvas.Figuras.Figuras.Add(tmp);
            CargarFigura(tmp);
        }

        private void BtnComposicion_Click(object sender, EventArgs e)
        {
            //Habilitamos drawing bandera que sirve para guardar los puntos
            ControlCanvas.Drawing = true;
            //Creamos una figura_relacion local
            Figura_Composicion tmp = new Figura_Composicion();
            //ControlCanvas.Figuras.Figuras.Add(tmp);
            CargarFigura(tmp);
        }

        private void BtnHerencia_Click(object sender, EventArgs e)
        {
            //Habilitamos drawing bandera que sirve para guardar los puntos
            ControlCanvas.Drawing = true;
            //Creamos una figura_relacion local
            Figura_Generalizacion tmp = new Figura_Generalizacion();

            //Agregamos la figura_relacion local a la lista y a la lista de formas
            //relaciones.Add(tmp);
            //ControlCanvas.Figuras.Figuras.Add(tmp);
            CargarFigura(tmp);
        }

        public void CargarFigura(UMLGraph.Grupos.Grupo3.Figuras.Figura tmp)
        {
            ControlCanvas.Figuras.Figuras.Add(tmp);
            AddEvent?.Invoke();
        }
        // Delegate type for the event handler
        public delegate void AddEventHandler();

        // Declare the event.
        public event AddEventHandler AddEvent;
    }
}
