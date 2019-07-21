using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

public class Clase5 
{
    GraphicsPath gp;
    public Point puntoInicial { get; set; }
    public Point puntoFinal { get; set; }
    public Point puntoMedio { get; set; }
    


    public Clase5() { }
    public Clase5(Rectangle[] rects, Point puntoPrincipio,String nombre,String atributos,String metodos)
    {
        gp = new GraphicsPath();
        puntoInicial = new Point(puntoPrincipio.X+30 , puntoPrincipio.Y-20);
        Font font1 = new Font("Arial", 13, FontStyle.Bold, GraphicsUnit.Point);
        puntoMedio = new Point(puntoPrincipio.X , puntoPrincipio.Y);
        puntoFinal = new Point(puntoPrincipio.X, puntoPrincipio.Y+50);
        gp.AddString(nombre, new FontFamily("Helvetica"), (int)FontStyle.Regular, 14,puntoInicial , StringFormat.GenericDefault);
        gp.AddString(atributos, new FontFamily("Helvetica"), (int)FontStyle.Regular, 14, puntoMedio, StringFormat.GenericDefault);
        gp.AddString(metodos, new FontFamily("Helvetica"), (int)FontStyle.Regular, 14, puntoFinal, StringFormat.GenericTypographic);

        gp.AddRectangles(rects);
       
        gp.CloseFigure();
    }
  
    public void DrawClase(Graphics g, Point puntoInicial, Point puntoFinal)
    {
        //Dibujando empezando de arriba hasta llegar punto inicial por la derecha
        Pen pen = new Pen(Color.Black, 2);
        g.SmoothingMode = SmoothingMode.AntiAlias;
         puntoMedio = new Point(puntoFinal.X, puntoFinal.Y + 25);
        Point puntoFin = new Point(puntoFinal.X, puntoFinal.Y + 75);

            Rectangle[] rects =
             {
                
                new Rectangle(puntoFinal,new Size(100,25)),

                new Rectangle(puntoMedio,new Size(100,50)),

                new Rectangle(puntoFin,new Size(100,75)),

               

             };
      
        g.DrawRectangles(pen,rects);
    
        g.Dispose();
        pen.Dispose();
    }
    public bool Dentro(Point p)
    {
        if (gp.IsOutlineVisible(p,new Pen(Color.DarkViolet)))
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
        gp.Transform(new Matrix(1,0,0,1,dx,dy));
    }
    public void Dibujar(Graphics e)
    {
        Pen pen = new Pen(Color.Black, 2);
        e.SmoothingMode = SmoothingMode.AntiAlias;
        e.DrawPath(pen, gp);
    }
}