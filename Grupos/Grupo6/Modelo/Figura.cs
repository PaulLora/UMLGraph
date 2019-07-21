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
        public int localizacionX;
        public int localizacionY;
        public int ancho;
        public int alto;
        public Graphics grafico;
        public Pen bolígrafo;


        //Metodos
        public abstract void dibujarFigura(Panel espaciotrabajo);
        public abstract void dibujarFigura(Panel espaciotrabajo, Panel clase);
        public abstract void moverFigura(Panel espaciotrabajo, MouseEventArgs e);
    }
}
