using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UMLGraph
{
   static class ListaFormas
    {


        public static List<Panel> listaClasesInterfaz = new List<Panel>();//= new List<Panel>();
        static List<Forma_Asociacion> listaAsociaciones;
        static List<Forma_Composicion> listaComposiciones;
        static List<Forma_Agregacion> listaAgregaciones;
        public static List<Panel> listaInterfaz = new List<Panel>();
        public static List<List<Panel>> listaHerencias = new List<List<Panel>>();



    }
}
