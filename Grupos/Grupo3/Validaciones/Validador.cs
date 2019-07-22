using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMLGraph.Grupos.Grupo3.Validaciones
{
    interface Validador
    {
        Boolean validar(string parametro);
        Boolean validarRepetidos(string parametro, Lista_Parametro lista);
    }
}
