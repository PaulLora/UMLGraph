using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UMLGraph.Grupos.Grupo5;

namespace UMLGraph
{
    class Fachada
    {
        public Panel EjecutarEnunciado1(Panel panel)
        {

            panel.Controls.Clear();
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

            panel.Controls.Clear();
            GraficaGrupo4 graph4 = new GraficaGrupo4(panel);
            panel = graph4.dibujar();
            return panel;
            
        }

        public Panel EjecutarEnunciado5(Panel panel)

        {
            GraficaGrupo5 graph5 = new GraficaGrupo5(panel);
            
            return panel;

        }
        public void EjecutarEnunciado6()
        {

        }

    }
}
