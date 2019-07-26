using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;

namespace UMLGraph.Grupos.Grupo5.Figuras
{
   
    class Figura5
    {
        public Point puntoInicial { get; set; }
        public Point puntoFinal { get; set; }
        public String nombre { get; set; }
        public Figura5(Point puntoInicial, Point puntoFinal, String nombre)
        {
            this.puntoInicial = puntoInicial;
            this.puntoFinal = puntoFinal;
            this.nombre = nombre;
        }
        public Figura5(Point puntoInicial, String nombre)
        {
            this.puntoInicial = puntoInicial;
            this.nombre = nombre;
        }
        //sobrecarga
        public Figura5()
        {
        }
        public Figura5(GraphicsPath gp)
        {
        }

    }
  
}
