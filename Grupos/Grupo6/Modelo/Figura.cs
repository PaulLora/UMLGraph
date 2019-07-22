using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UMLGraph.Grupos.Grupo6.Modelo
{
    abstract class Figura
    {
        //Atributs

        private int localizacionX;
        private int localizacionY;
        private int ancho;
        private int alto;
        private Graphics grafico;
        private Pen bolígrafo;

        public int LocalizacionX { get => localizacionX; set => localizacionX = value; }
        public int LocalizacionY { get => localizacionY; set => localizacionY = value; }
        public int Ancho { get => ancho; set => ancho = value; }
        public int Alto { get => alto; set => alto = value; }
        public Graphics Grafico { get => grafico; set => grafico = value; }
        public Pen Bolígrafo { get => bolígrafo; set => bolígrafo = value; }

        //Metodos
        public abstract void dibujarFigura(Panel espaciotrabajo);
        //public abstract void dibujarFigura(Panel espaciotrabajo, Panel clase);
        //public abstract void moverFigura(Panel panelContenedor, MouseEventArgs e, Panel espaciotrabajo);
        public abstract void moverFigura(Object sender, MouseEventArgs e);

    }
}
