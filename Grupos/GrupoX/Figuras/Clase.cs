using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UMLGraph

{
    class Clase:Figura
    {

        Graphics g;
        Pen p;
        int x, y, anchura = 130, altura = 20;
        Panel caja;
        TextBox titulo, atributos, metodos;

        public Clase(int x, int y)
        {
            this.x = x;
            this.y = y;
            p = new Pen(Color.Black);

            this.titulo = new System.Windows.Forms.TextBox();
            this.atributos = new System.Windows.Forms.TextBox();
            this.metodos = new System.Windows.Forms.TextBox();


            this.titulo.Location = new System.Drawing.Point(5, 5);
            this.titulo.Multiline = true;
            this.titulo.Name = "textBox1";
            this.titulo.Size = new System.Drawing.Size(anchura, altura);

            this.atributos.Location = new System.Drawing.Point(5, altura + 7);
            this.atributos.Multiline = true;
            this.atributos.Name = "textBox1";
            this.atributos.Size = new System.Drawing.Size(anchura, altura * 3);

            this.metodos.Location = new System.Drawing.Point(5, (altura * 4) + 10);
            this.metodos.Multiline = true;
            this.metodos.Name = "textBox1";
            this.metodos.Size = new System.Drawing.Size(anchura, altura * 2);

            caja = new System.Windows.Forms.Panel();
            caja.Controls.Add(titulo);
            caja.Controls.Add(atributos);
            caja.Controls.Add(metodos);
            caja.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            caja.Location = new System.Drawing.Point(x, y);
            caja.Name = "panel";
            caja.Size = new System.Drawing.Size(anchura + 10, altura * 7);
            caja.TabIndex = 0;
            caja.TabStop = false;
        }

        public override void dibujar()
        {
            
            g = caja.CreateGraphics();


            Rectangle titulo = new Rectangle(new Point(0, 0), new Size(anchura, altura));
            Rectangle atributos = new Rectangle(new Point(0, altura), new Size(anchura, altura * 3));
            Rectangle metodos = new Rectangle(new Point(0, altura * 4), new Size(anchura, altura * 2));


            g.DrawRectangle(p, titulo);
            g.DrawRectangle(p, atributos);
            g.DrawRectangle(p, metodos);

        }


        public Panel getCaja()
        {
            return caja;
        }


    }
}
