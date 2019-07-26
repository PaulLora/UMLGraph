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

            //calculo centrico para nombre de relacion
            float x = 0;
            float y = 0;

            if (punto1.X > punto2.X)
            {
                x = punto2.X + ((punto1.X - punto2.X) / 2);
            }
            else
            {
                x = punto1.X + ((punto2.X - punto1.X) / 2);
            }
            if (punto1.Y > punto2.Y)
            {
                y = punto2.Y + ((punto1.Y - punto2.Y) / 2);
            }
            else
            {
                y = punto1.Y + ((punto2.Y - punto1.Y) / 2);
            }

            this.Grafico.DrawString(this.nombreRelacion, new Font("Arial", 10), new SolidBrush(Color.Black), x, y);
            this.Grafico.DrawLine(this.Bolígrafo, punto1, punto2);
        }
        public override void moverFigura(object sender, MouseEventArgs e)
        {
            throw new NotImplementedException();
        }
        //public override void dibujarFigura(Panel espaciotrabajo)
        //{
        //    float xPadre = this.clasePadre.GetPanelContenedor().Location.X + this.clasePadre.Ancho / 2;
        //    float yPadre = this.clasePadre.GetPanelContenedor().Location.Y + this.clasePadre.Alto / 2;
        //    float xHijo = this.claseHijo.GetPanelContenedor().Location.X + this.claseHijo.Ancho / 2;
        //    float yHijo = claseHijo.GetPanelContenedor().Location.Y + this.claseHijo.Alto / 2;

        //    System.Drawing.PointF puntoPadre = new System.Drawing.PointF(xPadre, yPadre);
        //    System.Drawing.PointF puntoHijo = new System.Drawing.PointF(xHijo, yHijo);

        //    this.Grafico = espaciotrabajo.CreateGraphics();
        //    this.Bolígrafo = new Pen(Color.Gray, 2);

        //    float x = 0;
        //    float y = 0;
        //    double uX = 0;
        //    double uY = 0;
        //    double angle;
        //    double xx;
        //    double yy;


        //    if (puntoPadre.X > puntoHijo.X)
        //    {
        //        x = puntoHijo.X + ((puntoPadre.X - puntoHijo.X) / 2);
        //        xx = puntoPadre.X - puntoHijo.X;

        //    }
        //    else
        //    {
        //        x = puntoPadre.X + ((puntoHijo.X - puntoPadre.X) / 2);
        //        xx = puntoHijo.X - puntoPadre.X;
        //    }
        //    if (puntoPadre.Y > puntoHijo.Y)
        //    {
        //        y = puntoHijo.Y + ((puntoPadre.Y - puntoHijo.Y) / 2);
        //        yy = puntoPadre.Y - puntoHijo.Y;
        //    }
        //    else
        //    {
        //        y = puntoPadre.Y + ((puntoHijo.Y - puntoPadre.Y) / 2);
        //        yy = puntoHijo.Y - puntoPadre.Y;
        //    }

        //    this.Grafico.DrawLine(this.Bolígrafo, puntoPadre, puntoHijo);
        //    this.Grafico.DrawString(this.nombreRelacion, new Font("Arial", 10), new SolidBrush(Color.Black), x, y);
        //    Vector vectorResult = new Vector(xx, yy);
        //    vectorResult.Normalize();
        //    dibujarRmobo(vectorResult);
        //}

        //public void dibujarRmobo(Vector vectorResult)
        //{
        //    int xPadre = this.clasePadre.GetPanelContenedor().Location.X + this.clasePadre.Ancho / 2;
        //    int yPadre = this.clasePadre.GetPanelContenedor().Location.Y + this.clasePadre.Alto / 2;
        //    int xHijo = this.claseHijo.GetPanelContenedor().Location.X + this.claseHijo.Ancho / 2;
        //    int yHijo = claseHijo.GetPanelContenedor().Location.Y + this.claseHijo.Alto / 2;

        //    double angle;

        //    angle = Math.Atan(vectorResult.Y / vectorResult.X) * (180 / Math.PI);
        //    double radians = angle * (Math.PI / 180);
        //    double alturaInclinacionX;
        //    double alturaInclinacionY;
        //    float alturaRombo = 0;
        //    float xx = xPadre;
        //    alturaInclinacionX = Math.Tan(radians) * this.clasePadre.Ancho / 2;
        //    float yy = yPadre;
        //    alturaInclinacionY = Math.Tan(radians) * this.clasePadre.Alto / 2;


        //    /********Maneja costado derecho*************/

        //    if (xPadre < xHijo && yPadre < yHijo)
        //    {

        //        xx = xPadre + (float)alturaInclinacionX;
        //        if (xx > xPadre)
        //        {
        //            xx = xPadre + 13 + this.clasePadre.Ancho / 2;
        //        }
        //        yy = yPadre + (float)alturaInclinacionY;
        //    }

        //    if (xPadre < xHijo && yPadre > yHijo)
        //    {
        //        xx = xPadre + (float)alturaInclinacionX;
        //        if (xx > xPadre)
        //        {
        //            xx = xPadre + 13 + this.clasePadre.Ancho / 2;
        //        }
        //        yy = yPadre - (float)alturaInclinacionY;
        //    }

        //    /********Maneja costado derecho*************/

        //    if (xPadre > xHijo && yPadre < yHijo)
        //    {
        //        xx = xPadre - (float)alturaInclinacionX;
        //        if (xx < xPadre)
        //        {
        //            xx = xPadre - 13 - this.clasePadre.Ancho / 2;
        //        }
        //        yy = yPadre + (float)alturaInclinacionY;
        //    }

        //    if (xPadre > xHijo && yPadre > yHijo)
        //    {
        //        xx = xPadre - (float)alturaInclinacionX;
        //        if (xx < xPadre)
        //        {
        //            xx = xPadre - 13 - this.clasePadre.Ancho / 2;
        //        }
        //        yy = yPadre - (float)alturaInclinacionY;
        //    }



        //    /***** Puntos de Ubicacion ******/
        //    PointF point1 = new PointF(xx, yy - 13);
        //    PointF point2 = new PointF(xx + 13, yy);
        //    PointF point3 = new PointF(xx, yy + 13);
        //    PointF point4 = new PointF(xx - 13, yy);
        //    PointF[] puntosRombo = { point1, point2, point3, point4 };

        //    this.Grafico.FillPolygon(Brushes.White, puntosRombo);
        //    this.Grafico.FillRectangle(Brushes.White, new Rectangle((int)xx, (int)yy, 13, 30));
        //    this.Grafico.DrawPolygon(this.Bolígrafo, puntosRombo);

        //}
    }
}
