using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace UMLGraph
{
    class Forma_Asociacion : Forma
    {

        //SI SE PONE CANCELAR NO SE DEBE SALIR DEL CODIGO
        //Existe una bandera sin usarse 

        List<Point> lista = new List<Point>();
        List<Panel> listaPaneles = new List<Panel>(); //Un alista de paneles es una lista de clases
        //bool bandera = true;
        Canvas c;
        public int claseA, claseB;
        //Forma_Clase clase;

        //Forma_Clase clases = new Forma_Clase();
        public Graphics g;
        public Forma_Asociacion(Canvas canvas,  int claseA, int claseB)
        {
            this.claseA = claseA - 1;
            this.claseB = claseB - 1;
           // this.listaPaneles = clas;
            //this.clase = clase;
            dibujar(canvas);
        }

        public void dibujar(Canvas canvas)
        {
            Graphics g = canvas.panelMaster.CreateGraphics();
            this.g = g;
           // if (bandera == true)
            //{

                Point A = new Point();
                A = obtenerPuntos(claseA+1);
                Point B = new Point();
                B = obtenerPuntos(claseB+1);
                                             

               Pen lapiz = new Pen(Color.Black, 2);

                g.DrawLine(lapiz, A, B);
              //  bandera = true;
            //}

            //ValidacionAsociacion v = new ValidacionAsociacion(this);
        }

        private void Panel_MouseDown(object sender, MouseEventArgs e)
        {
        }
        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {


            MessageBox.Show("PORFAVOR SELECCIONE UNA CLASE");

        }
        public List<Panel> RecibirClases(List<Panel> clase)
        {

            // MessageBox.Show("RECIBIR DATOS");

            this.listaPaneles = clase;
            return listaPaneles;
        }



        public Point obtenerPuntos(int punto)
        {
            Point vacio = new Point();
            
            
                for (int i = 0; i < ListaFormas.listaClasesInterfaz.Count(); i++)
                {
                    Label txt = (Label)ListaFormas.listaClasesInterfaz[i].Controls[4];
                    String numero = txt.Text;
                    int numero1 = int.Parse(numero);
                    //MessageBox.Show(Convert.ToString(numero1));
                    if (numero1 == punto)
                    {
                        Point x1 = ListaFormas.listaClasesInterfaz[i].Location;
                        x1.X = ListaFormas.listaClasesInterfaz[i].Location.X + 75;
                        x1.Y = ListaFormas.listaClasesInterfaz[i].Location.Y + 100;
                      return x1;
                     
                    }
                }


            

            return vacio;
        }
    }
}