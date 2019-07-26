using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UMLGraph
{
    class Forma_Composicion : Forma
    {

        public List<Panel> listaTodoPartes = new List<Panel>();

        bool bandera = true;
        Canvas c;
        public Graphics g;
        int[] clasesPartes;
        int todo, nroPartes;
        public Forma_Composicion(Canvas canvas, int nroPartes, int[] partesDibujar, int todo)
        {
            this.c = canvas;
            this.todo = todo - 1;
            this.clasesPartes = partesDibujar;
            this.nroPartes = nroPartes;
        }

        public void dibujar(Canvas canvas)
        {

            g = canvas.panelMaster.CreateGraphics();

            List<Point> lista = new List<Point>();


            Point puntoTodo = new Point();


            puntoTodo.X = ListaFormas.listaClasesInterfaz[todo].Location.X + 160;
            puntoTodo.Y = ListaFormas.listaClasesInterfaz[todo].Location.Y + 100;
            listaTodoPartes.Add(ListaFormas.listaClasesInterfaz[todo]);

            List<Point> lista2 = obtenerPuntosPartes();

            Pen lapiz = new Pen(Color.Brown, 2);
            //lapiz.StartCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;


            for (int i = 0; i < clasesPartes.Length; i++)
            {
                g.DrawLine(lapiz, puntoTodo, lista2[i]);

            }
            SolidBrush blueBrush = new SolidBrush(Color.Blue);

            Point[] rombo = coordenadasRombo(puntoTodo);
            g.DrawPolygon(lapiz, rombo);
            g.FillPolygon(blueBrush, rombo);




        }


        public List<Point> obtenerPuntosPartes()
        {
            List<Point> lista = new List<Point>();

            for (int j = 0; j < clasesPartes.Length; j++)
            {
                for (int i = 0; i < ListaFormas.listaClasesInterfaz.Count(); i++)
                {
                    Label txt = (Label)ListaFormas.listaClasesInterfaz[i].Controls[4];
                    String numero = txt.Text;
                    int numero1 = int.Parse(numero);
                    MessageBox.Show(Convert.ToString(numero1));
                    int aux = clasesPartes[j] + 1;
                    if (numero1 == aux)
                    {
                        Point x1 = ListaFormas.listaClasesInterfaz[i].Location;
                        x1.X = ListaFormas.listaClasesInterfaz[i].Location.X + 75;
                        x1.Y = ListaFormas.listaClasesInterfaz[i].Location.Y + 100;
                        listaTodoPartes.Add(ListaFormas.listaClasesInterfaz[i]);

                        lista.Add(x1);
                        MessageBox.Show("El hijo " + j + " está enla posición");
                        MessageBox.Show(Convert.ToString(lista[j].X));
                        MessageBox.Show(Convert.ToString(lista[j].Y));
                    }
                }


            }

            return lista;
        }


        public Point[] coordenadasRombo(Point puntoTodo)
        {
            Point[] rombo = new Point[4];

            rombo[0] = new Point(puntoTodo.X + 8, puntoTodo.Y);
            rombo[1] = new Point(puntoTodo.X, puntoTodo.Y + 8);
            rombo[2] = new Point(puntoTodo.X - 8, puntoTodo.Y);
            rombo[3] = new Point(puntoTodo.X, puntoTodo.Y - 8);

            return rombo;
        }
    }
}
