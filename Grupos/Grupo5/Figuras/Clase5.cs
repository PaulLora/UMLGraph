using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using UMLGraph.Grupos.Grupo5.Figuras;

class Clase5 : Figura5
{
    GraphicsPath gp;
    GraphicsPath gptxt;

    public String  atributos, metodos;
    public Point puntoMedio { get; set; }
    public Rectangle[] rects;
    public Clase5(Rectangle[] rects,Point puntoInicial, String nombre, String atributos, String metodos) : base(puntoInicial,nombre)
    {
       
        this.puntoInicial = new Point(puntoInicial.X + 30, puntoInicial.Y - 20);
        this.puntoMedio = new Point(puntoInicial.X, puntoInicial.Y+5  );
        this.puntoFinal = new Point(puntoInicial.X, puntoInicial.Y + 80);
        this.nombre = nombre;
        this.atributos = atributos;
        this.metodos = metodos;
        this.rects = rects;
        ClaseDibujar();


    }
   

    private void ClaseDibujar()
    {
        StringFormat  string_format = new StringFormat();
        string_format.Alignment = StringAlignment.Near;
        string_format.LineAlignment = StringAlignment.Near;
        

        gp = new GraphicsPath();
        gptxt = new GraphicsPath();
        gptxt.AddString(this.nombre, new FontFamily("Arial"), (int)FontStyle.Regular, 14, puntoInicial, StringFormat.GenericDefault);
        gptxt.AddString(this.atributos, new FontFamily("Arial"), (int)FontStyle.Regular,14, puntoMedio, StringFormat.GenericDefault);
        gptxt.AddString(this.metodos, new FontFamily("Arial"), (int)FontStyle.Regular,14, puntoFinal, StringFormat.GenericDefault);
       
        gp.AddRectangles(this.rects);

        gp.CloseFigure();
    }

   //sobrecarga Contructor
    public Clase5() { }

    public void MostrarClase(Graphics g, Point puntoInicial, Point puntoFinal)
    {
        //Dibujando empezando de arriba hasta llegar punto inicial por la derecha
        Pen pen = new Pen(Color.Black, 2);
        g.SmoothingMode = SmoothingMode.AntiAlias;
        puntoMedio = new Point(puntoFinal.X, puntoFinal.Y + 30);
        Point puntoFin = new Point(puntoFinal.X, puntoFinal.Y + 105);

            Rectangle[] rects =
             {
                
                new Rectangle(puntoFinal,new Size(150,30)),

                new Rectangle(puntoMedio,new Size(150,75)),

                new Rectangle(puntoFin,new Size(150,100)),
               

             };      
        g.DrawRectangles(pen,rects);    
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
        Pen pen = new Pen(Color.Black, 3);
        Pen penL = new Pen(Color.Black,1);
        e.SmoothingMode = SmoothingMode.AntiAlias;
        e.DrawPath(pen, gp);
        e.DrawPath(penL, gptxt);
    }
}