using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMLGraph.Grupos.Grupo3.Validaciones
{
    class Validador_Nombre : Validador
    {
        public Boolean validar(string parametro)
        {
            string mayuscula = parametro.Substring(0, 1);
            if (mayuscula != mayuscula.ToUpper())
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
            bool validarRepetido = true;
            for (int contador = 0; contador < lista.contarElementos(); contador++)
            {
                if (lista.obtenerParametro(contador).Nombre.Equals(parametro))
                {
                    validarRepetido = false;
                    break;
                }
                else
                {
                    validarRepetido = true;
                }
            }
            return validarRepetido;
        }
    }
}
