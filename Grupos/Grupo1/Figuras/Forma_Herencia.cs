using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UMLGraph
{
    class Forma_Herencia : Forma
    {
        public List<Panel> listaPadreHijo = new List<Panel>();

        bool bandera = true;
        Canvas c;
        public Graphics g;
        int[] clasesHijas;


        int padre, coi;

        public Forma_Herencia(Canvas canvas, int nroHijos, int[] hijosDibujar, int papa, int classorInt)
        {

            clasesHijas = new int[nroHijos];
            clasesHijas = hijosDibujar;
            this.padre = papa - 1;
            this.coi = classorInt;
            dibujar(canvas);

        }
        public void dibujar(Canvas canvas)
        {
            g = canvas.panelMaster.CreateGraphics();

            List<Point> lista = new List<Point>();

            if (bandera == true)
            {

                Point puntoPadre = new Point();

                puntoPadre.X = ListaFormas.listaClasesInterfaz[padre].Location.X + 75;
                puntoPadre.Y = ListaFormas.listaClasesInterfaz[padre].Location.Y + 205;
                listaPadreHijo.Add(ListaFormas.listaClasesInterfaz[padre]);




                List<Point> lista2 = obtenerPuntosHijos();

                Pen lapiz = new Pen(Color.BlueViolet, 7);
                lapiz.StartCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;


                for (int i = 0; i < clasesHijas.Length; i++)
                {
                    g.DrawLine(lapiz, puntoPadre, lista2[i]);

                }

                bandera = true;
            }

        }


        public List<Point> obtenerPuntosHijos()
        {
            List<Point> lista = new List<Point>();
            for (int j = 0; j < clasesHijas.Length; j++)
            {
                for (int i = 0; i < ListaFormas.listaClasesInterfaz.Count(); i++)
                {
                    Label txt = (Label)ListaFormas.listaClasesInterfaz[i].Controls[4];
                    String numero = txt.Text;
                    int numero1 = int.Parse(numero);
                    //MessageBox.Show(Convert.ToString(numero1));
                    int aux = clasesHijas[j] + 1;
                    if (numero1 == aux)
                    {
                        Point x1 = ListaFormas.listaClasesInterfaz[i].Location;
                        x1.X = ListaFormas.listaClasesInterfaz[i].Location.X + 75;
                        listaPadreHijo.Add(ListaFormas.listaClasesInterfaz[i]);

                        lista.Add(x1);
                       // MessageBox.Show("El hijo " + j + " está enla posición");
                        //MessageBox.Show(Convert.ToString(lista[j].X));
                        //MessageBox.Show(Convert.ToString(lista[j].Y));
                    }
                }


            }

            return lista;
        }

    }
}
