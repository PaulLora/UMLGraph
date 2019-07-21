using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UMLGraph
{
    class Fachada
    {
        public Panel EjecutarEnunciado1(Panel panel)
        {
            panel.Dispose();
        return panel;
        }
        public void EjecutarEnunciado2()
        {



        }
        public void EjecutarEnunciado3()
        {

        }
        public Panel EjecutarEnunciado4(Panel panel)
        {
            //panel.Dispose();
            GraficaGrupo4 graph4 = new GraficaGrupo4(panel);
            panel = graph4.dibujar();
            return panel;
            
        }
        public void EjecutarEnunciado5()
        {

        }
        public void EjecutarEnunciado6()
        {

        }

    }
}
