using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UMLGraph.Grupos.Grupo3.Interfaz;

namespace UMLGraph.Grupos.Grupo3
{
    
    internal class SubsistemaGr3 : Fachada
    {
        Panel panel { get; set; } = new Panel();

        
        public Panel EjecutarEnunciado(Panel panel)
        {
            panel.Controls.Clear();
            CanvasGR3 gr3;
            gr3 = new CanvasGR3(new Size(panel.Width * 3, panel.Height * 3));
            return gr3.CanvasPanel;
        }
    }
}
