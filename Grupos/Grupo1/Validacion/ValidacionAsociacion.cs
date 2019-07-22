using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace UMLGraph
{
    class ValidacionAsociacion : Form
    {
        List<Point> lista = new List<Point>();
        List<Panel> listaPaneles = new List<Panel>(); //Un alista de paneles es una lista de clases
        bool bandera = true;
        Canvas c;
        int claseA, claseB;
        Forma_Clase clase;

        //Forma_Clase clases = new Forma_Clase();
        Graphics g;
        public ValidacionAsociacion(Canvas canvas, Forma_Clase clase, List<Panel> clas, int claseA, int claseB)
        {
            this.claseA = claseA - 1;
            this.claseB = claseB - 1;
            this.listaPaneles = clas;
            this.clase = clase;
            reglaAsociacionAtributos(claseA, claseB);
            reglaAsociacionMetodos(claseA, claseB);
        }

        public void reglaAsociacionAtributos(int numClaseA, int numClaseB)
        {
            String atributosClaseA = listaPaneles[numClaseA].Controls[2].Text;
            String atributosClaseB = listaPaneles[numClaseB].Controls[2].Text;
            String atrAMasatrB = atributosClaseB + "\n" + atributosClaseA;
            listaPaneles[numClaseB].Controls[2].Text = atrAMasatrB;
        }
        public void reglaAsociacionMetodos(int numClaseA, int numClaseB)
        {
            String atributosClaseA = listaPaneles[numClaseA].Controls[3].Text;
            String atributosClaseB = listaPaneles[numClaseB].Controls[3].Text;
            String atrAMasatrB = atributosClaseB + "\n" + atributosClaseA;
            listaPaneles[numClaseB].Controls[3].Text = atrAMasatrB;
        }
    }
}
