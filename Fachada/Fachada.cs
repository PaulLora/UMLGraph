using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UMLGraph.Grupos.Grupo5;
using UMLGraph.Grupos.Grupo1;
using UMLGraph.Grupos.Grupo3.Interfaz;
using UMLGraph.Grupos.Grupo6.Vista;
using NClass.GUI;
using UMLGraph.Grupos;


namespace UMLGraph
{
    //Esta es la clase fachada desde la cual cada método direcciona a cada subsitema del grupo que corresponda
    public interface Fachada
    {
        Panel EjecutarEnunciado(Panel panel);
    }
}
