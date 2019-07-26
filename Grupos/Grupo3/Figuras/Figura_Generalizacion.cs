using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UMLGraph.Grupos.Grupo3.Librerias;

namespace UMLGraph.Grupos.Grupo3.Figuras
{
    class Figura_Generalizacion : Figura_Relacion
    {
        
        public new Dibujador_Relacion Dibujador { get; set; }
        public PictureBox GenArrow { get; set; }
        public new void DibujarFigura()
        {
            
            if (isFull)
            {
                this.Dibujador = new Dibujador_Relacion();
                this.Dibujador.RelIni = RelIni.Location;
                this.Dibujador.RelFin = RelFin.Location;
                this.Dibujador.CrearLineas();
            }

            GenArrow = new PictureBox
            {
                Image = global::UMLGraph.Properties.Resources.arrow,
                Size = global::UMLGraph.Properties.Resources.arrow.Size,
            };
            this.DetermineLocation();
            this.Dibujador.RelLines.Add(GenArrow);
                       
        }
        private void DetermineLocation()
        {
            int x = this.Dibujador.ConPoint.X - GenArrow.Size.Width;
            int y = this.Dibujador.ConPoint.Y - (int) Math.Round((double) GenArrow.Size.Height / 2);
            GenArrow.Location = new Point(x,y);
        }
        public Figura_Generalizacion(Figura_Relacion father)
        {
            this.RelPuntos = father.RelPuntos;
            this.RelIni = father.RelIni;
            this.RelFin = father.RelFin;
            this.Dibujador = father.Dibujador;
            this.isFull = father.isFull;
            this.FiguraNombre = this.FiguraNombre + father.FiguraNombre;
        }
        public Figura_Generalizacion()
        {
            this.FiguraNombre = "Gen";
        }
    }
}
