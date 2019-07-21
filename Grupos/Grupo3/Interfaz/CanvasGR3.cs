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
    class CanvasGR3 : Form
    {
        private Button btnClase;
        private Button btnRelacion;
        private Button btnHerencia;
        private Button btnInterfaz;
        private Button btnAgregacion;
        private Button btnDependencia;
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
            CanvasPanel.Size = new Size(tam.Width*2, tam.Height*2);
            InitializeComponent();
        }
        public void CrearPanel()//permite crear un panel con una clase
        {
            Figura_Clase fig = new Figura_Clase();
            fig.Dibujar();
            fig.Contenedor.Click += PointForRelation;//Se guarda en los puntos para utilizarlos en relaciones
            fig.Contenedor.MouseClick += PnlMouseDown;
            fig.Contenedor.MouseMove += PnlMouseMove;
            fig.Contenedor.MouseUp += PnlMouseUp;
            ControlExtension.Draggable(fig.Contenedor, true);
            Figuras.Figuras.Add(fig);
            CanvasPanel.Controls.Add(fig.Contenedor);
        }
        public void PointForRelation(object sender, EventArgs e)//cuando drawing esta activado carga las posiciones de los paneles al una lista
        {
            Panel pan = sender as Panel;
            Graphics g = this.CreateGraphics();
            Pen lapiz = new Pen(Color.Black, 3);
            Figura_Relacion rel;
            if (drawing)
            {
                rel = relaciones.Last();
                if (!rel.isFull)
                {

                    if (rel.RelIni == null)
                    {
                        rel.RelIni = pan;
                    }
                    else if (rel.RelIni != null && rel.RelFin == null)
                    {
                        rel.RelFin = pan;
                        rel.isFull = true;
                        rel.RelPuntos.Add(new Point(rel.RelIni.Location.X + rel.RelIni.Size.Width / 2, rel.RelIni.Location.Y + rel.RelIni.Size.Height / 2));
                        rel.RelPuntos.Add(new Point(rel.RelFin.Location.X + rel.RelFin.Size.Width / 2, rel.RelFin.Location.Y + rel.RelFin.Size.Height / 2));
                    }
                }

                if (rel.isFull)
                {

                    Figuras.Figuras.Add(rel);
                    Figuras.CanvasSize = CanvasPanel.Size;
                    Figuras.Dibujar();
                    try
                    {
                        //CanvasPanel.BackgroundImage = Image.FromFile(@"C:\Users\Andres\Dropbox\6toSemestre\AppAmbProp\Examples\PropietariosMov\PropietariosMovDib4\ProyectoPropietarios\ProyectoPropietarios\Reltst1.bmp");
                        CanvasPanel.BackgroundImage = Image.FromFile(Figuras.GetNewBackground());
                    }
                    catch { }
                    drawing = false;
                }
            }
        }
        public void PnlMouseDown(object sender, EventArgs e)
        {
            this.pnlMvd = false;
        }
        public void PnlMouseMove(object sender, EventArgs e)
        {
            this.pnlMvd = true;
            //Console.WriteLine("Re-Dibujado");
        }
        public void PnlMouseUp(object sender, EventArgs e)
        {
            Panel pan = sender as Panel;
            Console.WriteLine("Re-Dibujado1");
            if (!this.pnlMvd)
            {
                Console.WriteLine("Re-Dibujado2");
                foreach (Figura_Relacion rel in Figuras.Figuras.OfType<Figura_Relacion>())
                {
                    if (rel.isFull)
                    {
                        if (rel.RelIni.Name == pan.Name)
                        {
                            rel.RelIni = pan;
                            rel.RelPuntos[0] = new Point(rel.RelIni.Location.X + rel.RelIni.Size.Width / 2, rel.RelIni.Location.Y + rel.RelIni.Size.Height / 2);
                        }
                        else if (rel.RelFin.Name == pan.Name)
                        {
                            rel.RelFin = pan;
                            rel.RelPuntos[1] = new Point(rel.RelFin.Location.X + rel.RelFin.Size.Width / 2, rel.RelFin.Location.Y + rel.RelFin.Size.Height / 2);
                        }
                        Figuras.Dibujar();
                        CanvasPanel.BackgroundImage = Image.FromFile(Figuras.GetNewBackground());
                    }

                }

                Console.WriteLine("Re-Dibujado2");
            }
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
            this.btnDependencia = new System.Windows.Forms.Button();
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
            this.btnClase.Text = "Dibujar clase";
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
            this.btnRelacion.Text = "Dibujar relación";
            this.btnRelacion.UseVisualStyleBackColor = true;
            this.btnRelacion.Click += new System.EventHandler(this.BtnRelacion_Click);
            // 
            // btnHerencia
            // 
            this.btnHerencia.Location = new System.Drawing.Point(13, 227);
            this.btnHerencia.Margin = new System.Windows.Forms.Padding(4);
            this.btnHerencia.Name = "btnHerencia";
            this.btnHerencia.Size = new System.Drawing.Size(176, 28);
            this.btnHerencia.TabIndex = 11;
            this.btnHerencia.Text = "Dibujar herencia";
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
            this.btnInterfaz.Text = "Dibujar interfaz";
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
            this.btnAgregacion.Text = "Dibujar agregación";
            this.btnAgregacion.UseVisualStyleBackColor = true;
            this.btnAgregacion.Click += new System.EventHandler(this.BtnAgregacion_Click);
            // 
            // btnDependencia
            // 
            this.btnDependencia.Location = new System.Drawing.Point(13, 156);
            this.btnDependencia.Margin = new System.Windows.Forms.Padding(4);
            this.btnDependencia.Name = "btnDependencia";
            this.btnDependencia.Size = new System.Drawing.Size(176, 28);
            this.btnDependencia.TabIndex = 14;
            this.btnDependencia.Text = "Dibujar dependencia";
            this.btnDependencia.UseVisualStyleBackColor = true;
            this.btnDependencia.Click += new System.EventHandler(this.BtnDependencia_Click);
            // 
            // btnComposicion
            // 
            this.btnComposicion.Location = new System.Drawing.Point(13, 191);
            this.btnComposicion.Margin = new System.Windows.Forms.Padding(4);
            this.btnComposicion.Name = "btnComposicion";
            this.btnComposicion.Size = new System.Drawing.Size(176, 28);
            this.btnComposicion.TabIndex = 15;
            this.btnComposicion.Text = "Dibujar composición";
            this.btnComposicion.UseVisualStyleBackColor = true;
            this.btnComposicion.Click += new System.EventHandler(this.BtnComposicion_Click);
            // 
            // InterfazGR3
            // 
            this.ClientSize = new System.Drawing.Size(282, 253);
            /*this.Controls.Add(this.btnClase);
            this.Controls.Add(this.btnRelacion);
            this.Controls.Add(this.btnHerencia);
            this.Controls.Add(this.btnInterfaz);
            this.Controls.Add(this.btnAgregacion);
            this.Controls.Add(this.btnDependencia);
            this.Controls.Add(this.btnComposicion);*/
            CanvasPanel.Controls.Add(this.btnClase);
            CanvasPanel.Controls.Add(this.btnRelacion);
            CanvasPanel.Controls.Add(this.btnHerencia);
            CanvasPanel.Controls.Add(this.btnInterfaz);
            CanvasPanel.Controls.Add(this.btnAgregacion);
            CanvasPanel.Controls.Add(this.btnDependencia);
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
            drawing = true;
            //Creamos una figura_relacion local
            Figura_Relacion tmp = new Figura_Relacion();
            //Inicializamos la lista de puntos donde se guardara para dibuajr la linea
            tmp.RelPuntos = new List<Point>();
            //Agregamos la figura_relacion local a la lista y a la lista de formas
            relaciones.Add(tmp);
            Figuras.Figuras.Add(tmp);
        }

        private void BtnAgregacion_Click(object sender, EventArgs e)
        {

        }

        private void BtnDependencia_Click(object sender, EventArgs e)
        {

        }

        private void BtnComposicion_Click(object sender, EventArgs e)
        {

        }

        private void BtnHerencia_Click(object sender, EventArgs e)
        {

        }
    }
}
