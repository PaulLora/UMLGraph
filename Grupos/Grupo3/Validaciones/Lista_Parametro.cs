using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMLGraph.Grupos.Grupo3.Validaciones
{
    class Lista_Parametro
    {
        List<Parametro> listaParametro = new List<Parametro>();

        public void agregar(Parametro parametro)
        {
            listaParametro.Add(parametro);
        }

        public void quitar(string nombreClase)
        {
            int indice;
            for (indice = 0; indice < listaParametro.Count; indice++)
            {
                if (listaParametro[indice].Nombre.Equals(nombreClase))
                {
                    listaParametro.RemoveAt(indice);
                }
            }

        }
        public Parametro obtenerParametro(int posicion)
        {
            return listaParametro[posicion];
        }
        public int contarElementos()
        {
            return listaParametro.Count;
        }
        public int buscarParametro(string nombreClase)
        {
            int contador;
            for (contador = 0; contador < listaParametro.Count; contador++)
            {
                if (listaParametro[contador].Nombre.Equals(nombreClase))
                {
                    break;
                }
            }
            return contador;
        }
    }
}
