using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UMLGraph.Grupos.GrupoX.Figuras

{
    public class Clase : Figura
    {

        Graphics g;
        Pen p;
        int x, y, anchura = 130, altura = 20;
        Panel caja;
        String nombre;
        Label identificador;
        TextBox titulo, atributos, metodos;



        public Clase(int x, int y, String nombre)
        {
            this.nombre = nombre;
            this.x = x;
            this.y = y;
            p = new Pen(Color.Black);


            this.identificador = new System.Windows.Forms.Label();
            this.identificador.AutoSize = true;
            this.identificador.Location = new System.Drawing.Point(55, 0);
            this.identificador.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.identificador.Name = "lblNombre";
            this.identificador.Size = new System.Drawing.Size(114, 17);
            this.identificador.TabIndex = 11;
            this.identificador.Text = this.nombre;

            this.titulo = new System.Windows.Forms.TextBox();
            this.atributos = new System.Windows.Forms.TextBox();
            this.metodos = new System.Windows.Forms.TextBox();


            this.titulo.Location = new System.Drawing.Point(5, 20);
            this.titulo.Multiline = true;
            this.titulo.Name = "textBox1";
            this.titulo.Size = new System.Drawing.Size(anchura, altura);

            this.atributos.Location = new System.Drawing.Point(5, altura + 22);
            this.atributos.Multiline = true;
            this.atributos.Name = "textBox1";
            this.atributos.Size = new System.Drawing.Size(anchura, altura * 3);

            this.metodos.Location = new System.Drawing.Point(5, (altura * 4) + 23);
            this.metodos.Multiline = true;
            this.metodos.Name = "textBox1";
            this.metodos.Size = new System.Drawing.Size(anchura, altura * 2);

            caja = new System.Windows.Forms.Panel();
            caja.Controls.Add(identificador);
            caja.Controls.Add(titulo);
            caja.Controls.Add(atributos);
            caja.Controls.Add(metodos);
            caja.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            caja.Location = new System.Drawing.Point(x, y);
            caja.Name = "panel";
            caja.Size = new System.Drawing.Size(anchura + 10, (altura * 7) + 10);
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

        public int getX()
        {
            this.x = caja.Location.X;
            return caja.Location.X;
        }

        public int getY()
        {
            this.y = caja.Location.Y;
            return caja.Location.Y;
        }

        public String getNombre()
        {
            return this.nombre;
        }

        public int getAltura()
        {
            return this.altura;
        }

        public int getAnchura()
        {
            return this.anchura;
        }

        public String getAtributos()
        {
            return this.atributos.Text;
        }
        public String getMetodos()
        {
            return this.metodos.Text;
        }
        public String getTitulo()
        {
            return this.titulo.Text;
        }

    }
}
