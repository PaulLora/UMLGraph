using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UMLGraph
{
    //Esta es la clase fachada desde la cual cada método direcciona a cada subsitema del grupo que corresponda
    public interface Fachada
    {
        Panel EjecutarEnunciado(Panel panel);
    }
}
