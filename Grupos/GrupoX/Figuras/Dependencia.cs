using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UMLGraph.Grupos.GrupoX.Figuras
    
{
    class Dependencia:Relacion
    {
        Graphics g;
        Pen p;
        int x, y, anchura = 130, altura = 20;
        Panel caja;

        public Dependencia(int x,int y)
        {
            this.x = x;
            this.y = y;
            p = new Pen(Color.Black);

            caja = new System.Windows.Forms.Panel();
            caja.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            caja.Location = new System.Drawing.Point(x, y);
            caja.Name = "panel";
            caja.TabIndex = 0;
            caja.TabStop = false;
        }
        public void dibujar(PaintEventArgs e)
        {

            g = caja.CreateGraphics();
            float[] dashValues = { 5, 2, 15, 4 };
            Pen blackPen = new Pen(Color.Black, 5);
            blackPen.DashPattern = dashValues;
            e.Graphics.DrawLine(blackPen, new Point(5, 5), new Point(405, 5));


        }


        public Panel getCaja()
        {
            return caja;
        }

    }
}
