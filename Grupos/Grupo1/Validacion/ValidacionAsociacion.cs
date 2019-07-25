using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace UMLGraph
{
    class ValidacionAsociacion : Validacion
    {
    
            List<Point> lista = new List<Point>();
            List<Panel> listaPaneles = new List<Panel>(); //Un alista de paneles es una lista de clases
            bool bandera = true;
            Canvas c;
           // int claseA, claseB;
            Forma_Asociacion formaAsociacion;

            //Forma_Clase clases = new Forma_Clase();
            Graphics g;
            public ValidacionAsociacion(Forma_Asociacion formaAsociacion)
            {

            this.formaAsociacion = formaAsociacion;
        
            }


            private void ValidacionAsociacion_Load(object sender, EventArgs e)
            {

            }

            public void reglaAsociacion()
            {

                String nombreClaseA = ListaFormas.listaClasesInterfaz[formaAsociacion.claseA].Controls[0].Text;
                String atributosClaseB = ListaFormas.listaClasesInterfaz[formaAsociacion.claseA].Controls[2].Text;
                String atrAMasatrB = atributosClaseB + "\n" + nombreClaseA;
                ListaFormas.listaClasesInterfaz[formaAsociacion.claseB].Controls[2].Text = atrAMasatrB;
            }

           public int validar()
            {
                reglaAsociacion();
                return 1;
            }
        }
}