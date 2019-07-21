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
using System.Drawing.Drawing2D;

namespace UMLGraph.Grupos.Grupo3.Figuras
{
    internal class Figura_Relacion : Figura
    {
        public Figura_Relacion()
        {
            this.FiguraNombre = "Rel" + DateTime.Now.ToString("hmmss");
        }

        public List<Point> RelPuntos { get; set; }

        public Panel RelIni { get; set; }
        public Panel RelFin { get; set; }
        public Bitmap BtmRelacion { get; set; }


        public bool isFull { get; set; }

        public void Adapt(Size text)
        {
            //this.SizeRectNombre = text;

        }
        public void UpdatePos()
        {
            //this.PosRectNombre = new Point(this.RectNombre.X, this.RectNombre.Y);

        }
        public Bitmap DrawToBitmap(Bitmap drwRel)
        {
            int w = drwRel.Height;
            int h = drwRel.Height;
            Graphics btg;
            Pen lapiz = new Pen(Color.Black, 3);
            btg = Graphics.FromImage(drwRel);
            btg.SmoothingMode = SmoothingMode.AntiAlias;
            if (this.isFull)
            {
                btg.DrawLine(lapiz, this.RelPuntos[0], this.RelPuntos[1]);
            }
            btg.DrawImage(drwRel, Point.Empty);
            try
            {
                drwRel.Save(this.FiguraNombre + ".bmp");
            }
            catch { }
            return drwRel;
        }
    }
}
