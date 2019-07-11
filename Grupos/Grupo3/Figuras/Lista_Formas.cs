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
    class Lista_Formas
    {
        public List<Forma> Formas { get; set; }
        public Size CanvasSize { get; set; }
        public void Dibujar()
        {
            Bitmap previousBtm = new Bitmap(CanvasSize.Width, CanvasSize.Height);
            foreach (Figura_Relacion rel in Formas.OfType<Figura_Relacion>())//Creo un nuevo Bitmap para ir dobujando sobre el en el foreach lo que hago es dibujar cada linea hasta obtener una imagen "final", perteneciente solo a las relaciones 
            {
                rel.BtmRelacion = rel.DrawToBitmap(previousBtm);
                previousBtm = rel.BtmRelacion;
            }

        }
        public String GetNewBackground()
        {
            return this.Formas.Last().FormaNombre + ".bmp";
        }

        public Lista_Formas(Size tam)
        {
            this.CanvasSize = tam;
            this.Formas = new List<Forma>();
        }
        public Lista_Formas()
        {
            this.Formas = new List<Forma>();
        }


    }
}
