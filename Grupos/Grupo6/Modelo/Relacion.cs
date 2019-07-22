using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UMLGraph.Grupos.Grupo6.Modelo
{
    class Relacion : Figura
    {
        /************************* Atributos *****************************/
        private String nombreRelacion;
        private String TipoRelacion;
        private Clase clasePadre;
        private Clase claseHijo;
        /************************* Constructores *****************************/
        public Relacion()
        {
        }
        public Relacion(string nombreRelacion, string tipoRelacion, Clase clasePadre, Clase claseHijo)
        {
            this.nombreRelacion = nombreRelacion;
            TipoRelacion = tipoRelacion;
            this.clasePadre = clasePadre;
            this.claseHijo = claseHijo;
        }

        /************************* GETTERS AND SETTERS *****************************/
        public string NombreRelacion { get => nombreRelacion; set => nombreRelacion = value; }
        public string TipoRelacion1 { get => TipoRelacion; set => TipoRelacion = value; }
        internal Clase ClasePadre { get => clasePadre; set => clasePadre = value; }
        internal Clase ClaseHijo { get => claseHijo; set => claseHijo = value; }

        /************************* MÉTODOS *****************************/



        /************************* MÉTODOS HEREDADOS *****************************/


        public override void dibujarFigura(Panel espaciotrabajo)
        {
            int xPadre = this.clasePadre.GetPanelContenedor().Location.X + this.clasePadre.Ancho / 2;
            int yPadre = this.clasePadre.GetPanelContenedor().Location.Y + this.clasePadre.Alto / 2;
            int xHijo = this.claseHijo.GetPanelContenedor().Location.X + this.claseHijo.Ancho / 2;
            int yHijo = claseHijo.GetPanelContenedor().Location.Y + this.claseHijo.Alto / 2;

            Point punto1 = new Point(xPadre, yPadre);
            Point punto2 = new Point(xHijo, yHijo);
            this.Grafico = espaciotrabajo.CreateGraphics();
            this.Bolígrafo = new Pen(Color.Black, 2);

            float x = punto1.X + (punto2.X - punto1.X);
            float y = punto1.Y + (punto2.Y - punto1.Y);
            this.Grafico.DrawString(this.nombreRelacion, new Font("Arial", 10), new SolidBrush(Color.Black), x, y);
            this.Grafico.DrawLine(this.Bolígrafo, punto1, punto2);
        }
        public override void moverFigura(object sender, MouseEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
