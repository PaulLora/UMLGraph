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
        List<Point> lista = new List<Point>();
        List<Panel> listaPaneles = new List<Panel>(); //Un alista de paneles es una lista de clases
        bool bandera = true;
        Canvas c;
        Graphics g;
        int claseA, claseB;
        Forma_Clase clase;

        public Forma_Asociacion(Canvas canvas, Forma_Clase clase, List<Panel> clas, int claseA, int claseB)
        {
            this.claseA = claseA - 1;
            this.claseB = claseB - 1;
            this.listaPaneles = clas;
            this.clase = clase;
            dibujar(canvas);
        }
        public void dibujar(Canvas canvas)
        {
            Graphics g = canvas.panelMaster.CreateGraphics();
            this.g = g;
            if (bandera == true)
            {
                //Guardo toda las ubicaciones de las clases
                for (int i = 0; i < listaPaneles.Count; i++)
                {
                    Point pt1 = listaPaneles[i].Location;
                    pt1.X = pt1.X + ((pt1.X * 20) / 100);
                    pt1.Y = pt1.Y + ((pt1.Y * 20) / 100);
                    lista.Add(pt1);
                }
                Pen lapiz = new Pen(Color.Black, 1);
                g.DrawLine(lapiz, lista[claseA], lista[claseB]);
                bandera = true;
            }
            ValidacionAsociacion v = new ValidacionAsociacion(canvas, clase, listaPaneles, claseA, claseB);
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
    }
}
