using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UMLGraph.Grupos.GrupoX.Figuras

{
    class Dependencia : Figura
    {
        Graphics g;
        Pen p;
        Clase clase1, clase2;
        Panel pnlPrincipal;
        public Dependencia(Clase clase1, Clase clase2, Panel pnlPrincipal)
        {
            this.pnlPrincipal = pnlPrincipal;
            this.clase1 = clase1;
            this.clase2 = clase2;
        }
        public override void dibujar()
        {
            GraphicsPath capPath = new GraphicsPath();
            capPath.AddLine(5, -5, 0, 0);
            capPath.AddLine(-5, -5, 0, 0);
            g = pnlPrincipal.CreateGraphics();
            p = new Pen(Color.Black, 3);
            p.DashStyle = DashStyle.Dash;
            p.CustomEndCap = new System.Drawing.Drawing2D.CustomLineCap(null, capPath);
            if (clase1.getY() + 75 > clase2.getY() + 300)
            {
                g.DrawLine(this.p, new Point(clase1.getX() + 130, clase1.getY() + 65), new Point(clase2.getX() + 70, clase2.getY() + 150));
            }
            else if (clase1.getY() + 75 < clase2.getY() - 150)
            {
                g.DrawLine(this.p, new Point(clase1.getX() + 130, clase1.getY() + 65), new Point(clase2.getX() + 70, clase2.getY()));
            }
            else if (clase1.getY() + 75 < clase2.getY() + 300 && clase1.getY() + 75 > clase2.getY() + 150 && clase1.getX() + 70 < clase2.getX())
            {
                g.DrawLine(this.p, new Point(clase1.getX() + 130, clase1.getY() + 65), new Point(clase2.getX(), clase2.getY() + 75));
            }
            else if (clase1.getY() + 75 < clase2.getY() + 300 && clase1.getY() + 75 > clase2.getY() + 150 && clase1.getX() + 70 > clase2.getX() + 140)
            {
                g.DrawLine(this.p, new Point(clase1.getX() + 130, clase1.getY() + 65), new Point(clase2.getX() + 140, clase2.getY() + 75));
            }
            else
            {
                g.DrawLine(this.p, new Point(clase1.getX() + 130, clase1.getY() + 65), new Point(clase2.getX(), clase2.getY() + 75));
            }
        }
    }
}
