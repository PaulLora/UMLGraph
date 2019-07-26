using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using UMLGraph.Grupos.Grupo5.Figuras;

class Asociacion5 : Figura5
{
    GraphicsPath gp;

    Point puntoMedio;
    public String nombre2;
   
    
 
    public Asociacion5(Point puntoInicial, Point puntoMedio , Point puntoFinal,String nombre,String nombre2):base(puntoInicial,puntoFinal,nombre)
    {
        this.puntoInicial = puntoInicial;
        this.puntoMedio= puntoMedio;
        this.puntoFinal = new Point(puntoFinal.X,puntoFinal.Y);
        this.nombre = nombre;
        this.nombre2 = nombre2;
       
        AsociacionDibujar();
    }
    private void AsociacionDibujar()
    {

        gp = new GraphicsPath();
        gp.StartFigure();
        if (puntoFinal.X < puntoInicial.X)
        {
            
            if (puntoInicial.Y > puntoFinal.Y)
            {
                //clase1
                puntoInicial = new Point(puntoInicial.X - 50, puntoInicial.Y -55 );
                puntoFinal = new Point(puntoFinal.X + 50, puntoFinal.Y + 150);
               
            }
            else
            {
                //clase2
                puntoInicial = new Point(puntoInicial.X - 50, puntoInicial.Y + 150);
                puntoFinal = new Point(puntoFinal.X +50, puntoFinal.Y - 55);
            }


            gp.AddLine(puntoInicial, puntoFinal);
            gp.CloseFigure();
           


        }
        else
        {
            gp.AddLine(puntoInicial, new Point((puntoFinal.X + puntoInicial.X) / 2, puntoInicial.Y));
            gp.CloseFigure();
            gp.AddLine(new Point((puntoFinal.X + puntoInicial.X) / 2, puntoInicial.Y), new Point((puntoFinal.X + puntoInicial.X) / 2, puntoFinal.Y));
            gp.CloseFigure();
            gp.AddLine(new Point((puntoFinal.X + puntoInicial.X) / 2, puntoFinal.Y), puntoFinal);
        }
      
       


    }
    public Asociacion5() { }

    

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
        Pen pen = new Pen(Color.Black,1);
        e.SmoothingMode = SmoothingMode.AntiAlias;
        e.DrawPath(pen, gp);
    }

}
 