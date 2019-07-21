using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UMLGraph.Grupos.Grupo6.Vista;

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
        public Panel EjecutarEnunciado6(Panel areaTrabajo)
        {

            PantallaTrabajoGr6 gr6 = new PantallaTrabajoGr6(areaTrabajo);
            areaTrabajo = gr6.dibujarPnl_areaTrabajo();
            

            return areaTrabajo;
        }

    }
}
