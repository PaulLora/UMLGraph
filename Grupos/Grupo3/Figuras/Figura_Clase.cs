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

namespace UMLGraph.Grupos.Grupo3.Figuras
{
    internal class Figura_Clase : Forma
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

        public Figura_Clase(Size tam)
        {
            this.FormaNombre = "Rel" + DateTime.Now.ToString("hmmss");
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
                this.BtmClase.Save(this.FormaNombre + ".bmp", ImageFormat.Bmp);
            }
            catch { }
            //Se guarda la imagen

        }

        public Figura_Clase() { }
        public void Adapt(Size text)//adapta el tamaño aumentando el alto
        {
            this.SizeRectNombre = text;
            this.SizeRectAtributos = text;
            this.SizeRectMetodos = text;
            this.PosRectAtributos = new Point(this.PosRectAtributos.X, this.PosRectNombre.Y + this.SizeRectNombre.Height);
            this.PosRectMetodos = new Point(this.PosRectMetodos.X, this.PosRectAtributos.Y + SizeRectNombre.Height);
        }

        public void UpdatePos()//actualiza su posicion
        {
            this.PosRectNombre = new Point(this.RectNombre.X, this.RectNombre.Y);
            this.PosRectAtributos = new Point(this.RectAtributos.X, this.RectAtributos.Y);
            this.PosRectMetodos = new Point(this.RectMetodos.X, this.RectMetodos.Y);
        }

    }
}
