using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMLGraph.Grupos.Grupo3.Validaciones
{
    class Validador_Metodo : Validador
    {
        public Boolean validar(string parametro)
        {
            string mayuscula = parametro.Substring(0, 1);
            string caracterFinal = parametro.Substring(parametro.Length - 1, 1);

            if (mayuscula != mayuscula.ToUpper() || !caracterFinal.Equals(";") || !parametro.Contains("(") || !parametro.Contains(")"))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public Boolean validarRepetidos(string parametro, Lista_Parametro lista)
        {
            return true;
        }
    }
}
