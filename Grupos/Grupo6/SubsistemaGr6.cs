using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UMLGraph.Grupos.Grupo6.Vista;

namespace UMLGraph.Grupos.Grupo6.Controlador
{
    class SubsistemaGr6 : Fachada
    {
        public Panel EjecutarEnunciado(Panel panel)
        {
            PantallaTrabajoGr6 gr6 = new PantallaTrabajoGr6(panel);
            panel = gr6.dibujarPnl_areaTrabajo();
            return panel;
        }
    }
}
