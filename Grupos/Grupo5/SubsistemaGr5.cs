using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UMLGraph.Grupos.Grupo5;
using UMLGraph.Grupos.Grupo5.Vista;

namespace UMLGraph
{
    internal class SubsistemaGr5:Fachada
    {

        Panel panel;

        public Panel EjecutarEnunciado(Panel panel)
        {
            GraficaGrupo5 graph5 = new GraficaGrupo5(panel);
            this.panel = panel;
            return this.panel;
        }
    }
}
