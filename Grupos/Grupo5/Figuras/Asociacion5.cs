using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

public class Asociacion5
{
    GraphicsPath gp;
    /// <summary>
    /// Obtiene o establece el punto inicial.
    /// </summary>
    public Point PI { get; set; }
    Point puntoMedio;
    /// <summary>
    /// Obtiene o establece el punto final.
    /// </summary>
    public Point PF { get; set; }
    public Asociacion5(){}
    /// <summary>
    /// Crea un figura del objeto GraphicsPath
    /// </summary>
    /// <param name="ptI"></param>
    /// <param name="ptM"></param>
    /// <param name="ptF"></param>
    public Asociacion5(Point ptI, Point ptM , Point ptF)
    {     
        gp = new GraphicsPath();
        Point[] vertices = {ptI,ptM,ptF};
        gp.AddLine(ptI, ptF);
        gp.CloseFigure();
    }
    public void DrawAsociacion(Graphics g, Point puntoInicial,Point puntoFinal)
    {
        Pen pen = new Pen(Color.Black,4);
        g.SmoothingMode = SmoothingMode.AntiAlias;
        g.DrawLine(pen, puntoInicial, puntoFinal);
        
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
    public void Mover(int dx,int dy)
    {
        gp.Transform(new Matrix(1,0,0,1,dx,dy));
    }
    public void Dibujar(Graphics e)
    {
        Pen pen = new Pen(Color.DarkBlue, 4);
        e.SmoothingMode = SmoothingMode.AntiAlias;
        e.DrawPath(pen,gp);
    }
}
 