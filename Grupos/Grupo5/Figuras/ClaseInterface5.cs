using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMLGraph.Grupos.Grupo5.Figuras
{
    class ClaseInterface5 : Figura5
    {
        GraphicsPath gp;
        GraphicsPath gptxt;

        public String  metodos;
        public Point puntoMedio { get; set; }
        public Rectangle[] rects;
        public ClaseInterface5(Rectangle[] rects, Point puntoInicial, String nombre, String metodos) : base(puntoInicial, nombre)
        {

            this.puntoInicial = new Point(puntoInicial.X + 30, puntoInicial.Y );
            this.puntoMedio = new Point(puntoInicial.X, puntoInicial.Y + 5);
            this.puntoFinal = new Point(puntoInicial.X, puntoInicial.Y + 35);
            this.nombre = nombre;
            this.metodos = metodos;
            this.rects = rects;
            ClaseDibujar();


        }


        private void ClaseDibujar()
        {
            StringFormat string_format = new StringFormat();
            string_format.Alignment = StringAlignment.Near;
            string_format.LineAlignment = StringAlignment.Near;


            gp = new GraphicsPath();
            gptxt = new GraphicsPath();
            gptxt.AddString(this.nombre, new FontFamily("Arial"), (int)FontStyle.Regular, 14, puntoInicial, StringFormat.GenericDefault);
            gptxt.AddString(this.metodos, new FontFamily("Arial"), (int)FontStyle.Regular, 14, puntoFinal, StringFormat.GenericDefault);

            gp.AddRectangles(this.rects);

            gp.CloseFigure();
        }

        //sobrecarga Contructor
        public ClaseInterface5() { }

        public void MostrarClase(Graphics g, Point puntoInicial, Point puntoFinal)
        {
            //Dibujando empezando de arriba hasta llegar punto inicial por la derecha
            Pen pen = new Pen(Color.Black, 2);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            puntoMedio = new Point(puntoFinal.X, puntoFinal.Y + 40);
            Point puntoFin = new Point(puntoFinal.X, puntoFinal.Y + 60);

            Rectangle[] rects =
             {

                new Rectangle(puntoFinal,new Size(150,40)),

                new Rectangle(puntoMedio,new Size(150,20)),

                new Rectangle(puntoFin,new Size(150,120)),


             };
            g.DrawRectangles(pen, rects);
            g.Dispose();
            pen.Dispose();
        }

        public bool Dentro(Point p)
        {
            if (gp.IsOutlineVisible(p, new Pen(Color.DarkViolet)))
            {
                return true;
            }
            else
            {
                return gp.IsVisible(p);
            }
        }
        public void Mover(int dx, int dy)
        {
            gp.Transform(new Matrix(1, 0, 0, 1, dx, dy));
            gptxt.Transform(new Matrix(1, 0, 0, 1, dx, dy));
        }
        public void Dibujar(Graphics e)
        {
            //HatchBrush hBrush = new HatchBrush(
            // HatchStyle.BackwardDiagonal ,Color.White,

            //Color.Black);
            Pen pen = new Pen(Color.Black, 1);
            Pen penL = new Pen(Color.Black, 1);
            e.SmoothingMode = SmoothingMode.AntiAlias;
            e.DrawPath(pen, gp);
           e.DrawPath(penL, gptxt);
        }
    }
}
