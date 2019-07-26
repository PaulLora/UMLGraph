using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using UMLGraph.Grupos.Grupo5.Figuras;

class Generalizacion5 : Figura5
{
    GraphicsPath gp;
    Point puntoMedio;
    public String nombre2;

    public Generalizacion5(Point puntoInicial, Point puntoMedio, Point puntoFinal, String nombre, String nombre2) : base(puntoInicial, puntoFinal, nombre)
    {
        this.puntoInicial = puntoInicial;
        this.puntoMedio = puntoMedio;
        this.puntoFinal = new Point(puntoFinal.X, puntoFinal.Y);
        this.nombre = nombre;
        this.nombre2 = nombre2;

        GeneralizacionDibujar();
    }
    private void GeneralizacionDibujar()
    {

        gp = new GraphicsPath();
        gp.StartFigure();
        if (puntoFinal.X < puntoInicial.X)
        {

            if (puntoInicial.Y > puntoFinal.Y )
            {
                if (nombre.Contains(nombre2))
                {
                    puntoInicial = new Point(puntoInicial.X - 75, puntoInicial.Y - 105);
                    puntoFinal = new Point(puntoFinal.X + 75, puntoFinal.Y + 100);
                    gp.AddLine(puntoFinal, new Point(puntoFinal.X - 10, puntoFinal.Y + 10));
                    gp.AddLine(new Point(puntoFinal.X - 10, puntoFinal.Y + 10), new Point(puntoFinal.X + 10, puntoFinal.Y + 10));
                    gp.CloseFigure();
                    gp.AddLine(new Point(puntoInicial.X, puntoInicial.Y), new Point(puntoInicial.X, (puntoFinal.Y + puntoInicial.Y) / 2));
                    gp.CloseFigure();
                    gp.AddLine(new Point(puntoInicial.X, (puntoFinal.Y + puntoInicial.Y) / 2), new Point(puntoFinal.X, (puntoFinal.Y + puntoInicial.Y) / 2));
                    gp.CloseFigure();
                    gp.AddLine(new Point(puntoFinal.X, (puntoFinal.Y + puntoInicial.Y) / 2), new Point(puntoFinal.X, puntoFinal.Y + 10));
                    gp.CloseFigure();
                }
                else
                {
                    puntoInicial = new Point(puntoInicial.X - 75, puntoInicial.Y - 105);
                    puntoFinal = new Point(puntoFinal.X + 75, puntoFinal.Y + 100);
                    gp.AddLine(puntoInicial, new Point(puntoInicial.X - 10, puntoInicial.Y - 10));
                    gp.AddLine(new Point(puntoInicial.X - 10, puntoInicial.Y - 10), new Point(puntoInicial.X +10, puntoInicial.Y - 10));
                    gp.CloseFigure();
                    gp.AddLine(new Point(puntoInicial.X, puntoInicial.Y - 10), new Point(puntoInicial.X, (puntoFinal.Y + puntoInicial.Y) / 2));
                    gp.CloseFigure();
                    gp.AddLine(new Point(puntoInicial.X, (puntoFinal.Y + puntoInicial.Y) / 2), new Point(puntoFinal.X, (puntoFinal.Y + puntoInicial.Y) / 2));
                    gp.CloseFigure();
                    gp.AddLine(new Point(puntoFinal.X, (puntoFinal.Y + puntoInicial.Y) / 2), puntoFinal);
                    gp.CloseFigure();
                }

            }
            else
            {
                if (nombre.Contains(nombre2))
                {

                    puntoInicial = new Point(puntoInicial.X - 75, puntoInicial.Y + 100);
                    puntoFinal = new Point(puntoFinal.X + 75, puntoFinal.Y - 105);
                    gp.AddLine(puntoFinal, new Point(puntoFinal.X - 10, puntoFinal.Y - 10));
                    gp.AddLine(new Point(puntoFinal.X - 10, puntoFinal.Y - 10), new Point(puntoFinal.X + 10, puntoFinal.Y - 10));

                    gp.CloseFigure();
                    gp.AddLine(new Point(puntoInicial.X, puntoInicial.Y ), new Point(puntoInicial.X, (puntoFinal.Y + puntoInicial.Y) / 2));
                    gp.CloseFigure();
                    gp.AddLine(new Point(puntoInicial.X, (puntoFinal.Y + puntoInicial.Y) / 2), new Point(puntoFinal.X, (puntoFinal.Y + puntoInicial.Y) / 2));
                    gp.CloseFigure();
                    gp.AddLine(new Point(puntoFinal.X, (puntoFinal.Y + puntoInicial.Y) / 2), new Point(puntoFinal.X, puntoFinal.Y - 10));
                    gp.CloseFigure();


                }
                else
                {
                    puntoInicial = new Point(puntoInicial.X - 75, puntoInicial.Y + 100);
                    puntoFinal = new Point(puntoFinal.X + 75, puntoFinal.Y - 105);
                    gp.AddLine(puntoInicial, new Point(puntoInicial.X - 10, puntoInicial.Y + 10));
                    gp.AddLine(new Point(puntoInicial.X - 10, puntoInicial.Y + 10), new Point(puntoInicial.X + 10, puntoInicial.Y + 10));
                    gp.CloseFigure();
                    gp.AddLine(new Point(puntoInicial.X, puntoInicial.Y + 10), new Point(puntoInicial.X, (puntoFinal.Y + puntoInicial.Y) / 2));
                    gp.CloseFigure();
                    gp.AddLine(new Point(puntoInicial.X, (puntoFinal.Y + puntoInicial.Y) / 2), new Point(puntoFinal.X, (puntoFinal.Y + puntoInicial.Y) / 2));
                    gp.CloseFigure();
                    gp.AddLine(new Point(puntoFinal.X, (puntoFinal.Y + puntoInicial.Y) / 2), puntoFinal);
                    gp.CloseFigure();
                }
                   
            }
           
                




        }
        else
        {
           
            if (nombre.Contains(nombre2))
            {
                gp.AddLine(puntoFinal, new Point(puntoFinal.X - 15, puntoFinal.Y + 15));
                gp.AddLine(new Point(puntoFinal.X - 15, puntoFinal.Y + 15), new Point(puntoFinal.X - 15, puntoFinal.Y - 15));
                gp.CloseFigure();
                gp.AddLine(new Point(puntoInicial.X , puntoInicial.Y), new Point((puntoFinal.X + puntoInicial.X) / 2, puntoInicial.Y));
                gp.CloseFigure();
                gp.AddLine(new Point((puntoFinal.X + puntoInicial.X) / 2, puntoInicial.Y), new Point((puntoFinal.X + puntoInicial.X) / 2, puntoFinal.Y));
                gp.CloseFigure();
                gp.AddLine(new Point((puntoFinal.X + puntoInicial.X) / 2, puntoFinal.Y), new Point(puntoFinal.X-15,puntoFinal.Y));

            }
            else
            {
                gp.AddLine(puntoInicial, new Point(puntoInicial.X + 15, puntoInicial.Y + 15));
                gp.AddLine(new Point(puntoInicial.X + 15, puntoInicial.Y + 15), new Point(puntoInicial.X +15, puntoInicial.Y - 15));
                gp.CloseFigure();
                gp.AddLine(new Point(puntoInicial.X + 15, puntoInicial.Y), new Point((puntoFinal.X + puntoInicial.X) / 2, puntoInicial.Y));
                gp.CloseFigure();
                gp.AddLine(new Point((puntoFinal.X + puntoInicial.X) / 2, puntoInicial.Y), new Point((puntoFinal.X + puntoInicial.X) / 2, puntoFinal.Y));
                gp.CloseFigure();
                gp.AddLine(new Point((puntoFinal.X + puntoInicial.X) / 2, puntoFinal.Y), puntoFinal);
                
            }

            gp.CloseFigure();
            
          
        }
    }
    public Generalizacion5() { }

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

    public void Dibujar(Graphics e)
    {
        Pen pen = new Pen(Color.Black, 2);
        e.SmoothingMode = SmoothingMode.AntiAlias;
        e.DrawPath(pen, gp);
    }




}
   

