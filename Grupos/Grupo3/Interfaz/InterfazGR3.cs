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
    class InterfazGR3 : Form
    {
        public List<Panel> paneles { get; set; }
        public Lista_Formas Formas { get; set; }
        public Panel masterPanel { get; set; }
        public List<Figura_Relacion> relaciones { get; set; }
        public LlenarClase llenarClase { get; set; }
        public bool drawing { get; set; }
        public bool pnlMvd { get; set; }
        public InterfazGR3(Size tam)
        {
            paneles = new List<Panel>();
            Formas = new Lista_Formas();
            masterPanel = new Panel();
            relaciones = new List<Figura_Relacion>();
            llenarClase = new LlenarClase();
            masterPanel.Location = new System.Drawing.Point(0, 0);
            masterPanel.Size = new Size(tam.Width, tam.Height);
        }
        public void CrearPanel(ref Panel panel)//permite crear un panel con una clase
        {
            MenuItem[] menuItems = new MenuItem[]{new MenuItem("Modificar",MenuItem_Click),//hacemos esto para definir como se comportaran luego
                    new MenuItem("Reiniciar",MenuItem_Click), new MenuItem("Exit",MenuItem_Click)};
            ContextMenu buttonMenu = new ContextMenu(menuItems);
            panel.Location = new System.Drawing.Point(570, 370);
            panel.Name = "Panel " + paneles.Count;//se poodria cambiar por parametro aunque no me parecee necesario
            panel.Size = new System.Drawing.Size(228, 201);
            Figura_Clase fig = new Figura_Clase(panel.Size);
            Formas.Formas.Add(fig);
            panel.BackgroundImage = Image.FromFile(Formas.GetNewBackground());
            panel.BackColor = Color.LightBlue;
            panel.ContextMenu = buttonMenu;
            panel.Click += PointForRelation;//Se guarda en los puntos para utilizarlos en relaciones
            panel.MouseClick += PnlMouseDown;
            panel.MouseMove += PnlMouseMove;
            panel.MouseUp += PnlMouseUp;
            ControlExtension.Draggable(panel, true);
            fig.Contenedor = panel;
            //Controls.Add(panel);
            masterPanel.Controls.Add(panel);
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

                    Formas.Formas.Add(rel);
                    Formas.CanvasSize = masterPanel.Size;
                    Formas.Dibujar();
                    try
                    {
                        //masterPanel.BackgroundImage = Image.FromFile(@"C:\Users\Andres\Dropbox\6toSemestre\AppAmbProp\Examples\PropietariosMov\PropietariosMovDib4\ProyectoPropietarios\ProyectoPropietarios\Reltst1.bmp");
                        masterPanel.BackgroundImage = Image.FromFile(Formas.GetNewBackground());
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
                foreach (Figura_Relacion rel in Formas.Formas.OfType<Figura_Relacion>())
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
                        Formas.Dibujar();
                        masterPanel.BackgroundImage = Image.FromFile(Formas.GetNewBackground());
                    }

                }

                Console.WriteLine("Re-Dibujado2");
            }
        }
        public void MenuItem_Click(object sender, EventArgs e)//es un escuchador para cada item si se le da click al context menu hace algo
        {
            MenuItem mi = sender as MenuItem; //El que envia se vuelve menu item osea el nuevo item creado en Crear Panel
            if (mi != null)
            {
                //aqui deberiamos comprobar 
            }

            if (mi.Text == "Modificar")//Comportamiento para el info
            {
                // aqui se debria abrir el nuevo Form ingresar los datos y setearlos
                String nombre = "None";// = llenarClase.NombreClase;//obtengo nombre clase

                List<string> atributos = new List<string>(); //llenarClase.Atributos;//obtengo atributos
                List<string> metodos = new List<string>();// obtengo metodos
                this.llenarClase = new LlenarClase();
                this.llenarClase.FormClosed += LlenarClase_FormClosed;
                this.llenarClase.ShowDialog();



                //Llegan las listas del form llenarClase
                nombre = llenarClase.NombreClase;
                atributos = llenarClase.Atributos;
                metodos = llenarClase.Metodos;
                // "Desplegando Info";//Aqui se deberia desplegar el form para ingresar los datos

                List<Label> contenido = new List<Label>();

                var cm = (ContextMenu)mi.Parent;//Se obtiene el padree con esta funcion
                Control ctr = cm.SourceControl;
                Label label = new Label();
                label.Location = new System.Drawing.Point(10, 10);//localizacion
                label.Size = new System.Drawing.Size(320, 20);//tamaño

                label.Text = nombre; //Aqui se deberia setear las cosas

                //Se hace visible el label y se le pone sus configuraciones               
                label.BackColor = Color.Gray;
                label.Font = new Font(label.Font.Name, label.Font.SizeInPoints, FontStyle.Regular);
                label.Visible = true;
                //MenuItem[] fue vuelto un menu de contexto y se le agrega el item
                contenido.Add(label);
                int dx = 0;
                foreach (String var in atributos)
                {
                    Label label2 = new Label();
                    Figura_Clase fig = new Figura_Clase(ctr.Size);

                    label2.Font = new Font(label.Font.Name, label.Font.SizeInPoints, FontStyle.Regular);
                    Size textSize = TextRenderer.MeasureText(var, label2.Font);
                    dx += (int)textSize.Height + 5;
                    label2.Location = new Point(fig.PosRectAtributos.X + 5, fig.RectAtributos.Y + 2 + dx);//localizacion
                    label2.Size = new System.Drawing.Size(200, 20);//tamaño
                    label2.Text = var; //Aqui se deberia setear las cosas

                    //Se hace visible el label y se le pone sus configuraciones               
                    label2.BackColor = Color.Gray;

                    label2.Visible = true;
                    contenido.Add(label2);

                }
                dx = 0;
                foreach (String var in metodos)
                {
                    Label label2 = new Label();
                    Figura_Clase fig = new Figura_Clase(ctr.Size);

                    label2.Font = new Font(label.Font.Name, label.Font.SizeInPoints, FontStyle.Regular);
                    Size textSize = TextRenderer.MeasureText(var, label2.Font);
                    dx += (int)textSize.Height + 5;
                    label2.Location = new Point(fig.PosRectMetodos.X + 5, fig.RectMetodos.Y + 2 + dx);//localizacion

                    label2.Size = new System.Drawing.Size(200, 20);//tamaño
                    label2.Text = var; //Aqui se deberia setear las cosas

                    //Se hace visible el label y se le pone sus configuraciones               
                    label2.BackColor = Color.Gray;

                    label2.Visible = true;
                    contenido.Add(label2);

                }
                dx = 0;
                foreach (Label lbl in contenido)
                {
                    Console.WriteLine(lbl.Text);
                    ctr.Controls.Add(lbl);
                }

            }
            else if (mi.Text == "Reiniciar")//Comportamiento para el info2
            {
                foreach (Control item in paneles)
                {
                    //this.Controls.Remove(item);
                }
            }
        }
        private void LlenarClase_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {

        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // InterfazGR3
            // 
            this.ClientSize = new System.Drawing.Size(282, 253);
            this.Name = "InterfazGR3";
            this.Load += new System.EventHandler(this.InterfazGR3_Load);
            this.ResumeLayout(false);

        }

        private void InterfazGR3_Load(object sender, EventArgs e)
        {

        }
    }
}
