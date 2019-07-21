using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.IO;
using UMLGraph.Grupos.Grupo3.Interfaz;
using UMLGraph.Grupos.Grupo3.Librerias;

namespace UMLGraph.Grupos.Grupo3.Figuras
{
    internal class Figura_Clase : Figura
    {

        public Rectangle RectNombre { get; set; }
        public Rectangle RectAtributos { get; set; }
        public Rectangle RectMetodos { get; set; }
        public Size SizeRectNombre { get; set; }
        public Size SizeRectAtributos { get; set; }
        public Size SizeRectMetodos { get; set; }
        public Point PosRectNombre { get; set; }
        public Point PosRectAtributos { get; set; }
        public Point PosRectMetodos { get; set; }

        public Bitmap BtmClase { get; set; }
        public Panel Contenedor { get; set; }
        public bool Dragging { get; set; }
        public LlenarClase llenarClase { get; set; }
        public Figura_Clase(Size tam)
        {
            this.FiguraNombre = "Rel" + DateTime.Now.ToString("hmmss");
            //Se obtiene alto y ancho
            int w = tam.Width;
            int h = tam.Height;
            //Localizaciones y tamaños
            this.SizeRectNombre = new Size(w, h / 3);
            this.PosRectNombre = new Point(0, 0);
            this.RectNombre = new Rectangle(this.PosRectNombre, this.SizeRectNombre);
            this.SizeRectAtributos = new Size(w, h / 3);
            this.PosRectAtributos = new Point(0, this.PosRectNombre.Y + this.SizeRectNombre.Height);
            this.RectAtributos = new Rectangle(this.PosRectAtributos, this.SizeRectAtributos);
            this.SizeRectMetodos = new Size(w, h / 3);
            this.PosRectMetodos = new Point(0, this.PosRectAtributos.Y + SizeRectNombre.Height);
            this.RectMetodos = new Rectangle(this.PosRectMetodos, this.SizeRectMetodos);
            //Se dibujan las formas
            Graphics btg;
            Font font1 = new Font("Arial", 10, FontStyle.Bold, GraphicsUnit.Point);
            this.BtmClase = new Bitmap(w, h);
            btg = Graphics.FromImage(this.BtmClase);
            btg.Clear(Color.Gray);
            btg.DrawRectangle(new Pen(Brushes.Wheat), this.RectNombre);
            btg.DrawRectangle(new Pen(Brushes.Wheat), this.RectAtributos);
            btg.DrawRectangle(new Pen(Brushes.Wheat), this.RectMetodos);
            btg.DrawImage(this.BtmClase, Point.Empty);//Gardamos todo lo dibujado con "Draw" o "Fill" en el Bitmap
            try
            {
                this.BtmClase.Save(this.FiguraNombre + ".bmp", ImageFormat.Bmp);
            }
            catch { }
            //Se guarda la imagen
            
        }

        public Figura_Clase()
        {
            this.FiguraNombre = "Cls" + DateTime.Now.ToString("hmmss");
        }
        public void Adapt(Size tam)//adapta el tamaño aumentando el alto
        {
            this.SizeRectNombre = tam;
            this.SizeRectAtributos = tam;
            this.SizeRectMetodos = tam;
            this.PosRectAtributos = new Point(this.PosRectAtributos.X, this.PosRectNombre.Y + this.SizeRectNombre.Height);
            this.PosRectMetodos = new Point(this.PosRectMetodos.X, this.PosRectAtributos.Y + SizeRectNombre.Height);
        }
        public void ResizePanel(Size tam) { }
        public void PrepararBitmap(Size tam)
        {
            this.FiguraNombre = "Rel" + DateTime.Now.ToString("hmmss");
            //Se obtiene alto y ancho
            int w = tam.Width;
            int h = tam.Height;
            //Localizaciones y tamaños
            this.SizeRectNombre = new Size(w, h / 3);
            this.PosRectNombre = new Point(0, 0);
            this.RectNombre = new Rectangle(this.PosRectNombre, this.SizeRectNombre);
            this.SizeRectAtributos = new Size(w, h / 3);
            this.PosRectAtributos = new Point(0, this.PosRectNombre.Y + this.SizeRectNombre.Height);
            this.RectAtributos = new Rectangle(this.PosRectAtributos, this.SizeRectAtributos);
            this.SizeRectMetodos = new Size(w, h / 3);
            this.PosRectMetodos = new Point(0, this.PosRectAtributos.Y + SizeRectNombre.Height);
            this.RectMetodos = new Rectangle(this.PosRectMetodos, this.SizeRectMetodos);
            //Se dibujan las formas
            Graphics btg;
            Font font1 = new Font("Arial", 10, FontStyle.Bold, GraphicsUnit.Point);
            this.BtmClase = new Bitmap(w, h);
            btg = Graphics.FromImage(this.BtmClase);
            btg.Clear(Color.Gray);
            btg.DrawRectangle(new Pen(Brushes.Wheat), this.RectNombre);
            btg.DrawRectangle(new Pen(Brushes.Wheat), this.RectAtributos);
            btg.DrawRectangle(new Pen(Brushes.Wheat), this.RectMetodos);
            btg.DrawImage(this.BtmClase, Point.Empty);//Gardamos todo lo dibujado con "Draw" o "Fill" en el Bitmap
            try
            {
                this.BtmClase.Save(this.FiguraNombre + ".bmp", ImageFormat.Bmp);
            }
            catch { }
            //Se guarda la imagen

        }
        public void Dibujar()
        {
            MenuItem[] menuItems = new MenuItem[]{new MenuItem("Modificar",MenuItem_Click),//hacemos esto para definir como se comportaran luego
                    new MenuItem("Reiniciar",MenuItem_Click), new MenuItem("Exit",MenuItem_Click)};
            ContextMenu buttonMenu = new ContextMenu(menuItems);
            Contenedor = new Panel();
            Contenedor.Location = new System.Drawing.Point(570, 370);
            Contenedor.Name = "Panel "; //+ paneles.Count;//se poodria cambiar por parametro aunque no me parecee necesario
            Contenedor.Size = new System.Drawing.Size(228, 201);
            PrepararBitmap(Contenedor.Size);
            //Figuras.Figuras.Add(fig);
            Contenedor.BackgroundImage = Image.FromFile(this.FiguraNombre + ".bmp");
            Contenedor.BackColor = Color.LightBlue;
            Contenedor.ContextMenu = buttonMenu;
            
            //ControlExtension.Draggable(, true);
            //fig.Contenedor = panel;

            
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
                llenarClase = new LlenarClase();
                //llenarClase.FormClosed += LlenarClase_FormClosed;
                llenarClase.ShowDialog();



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
                //foreach (Control item in paneles)
                //{
                //    //this.Controls.Remove(item);
                //}
            }
        }

    }
}
