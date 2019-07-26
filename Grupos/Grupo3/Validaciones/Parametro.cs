using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMLGraph.Grupos.Grupo3.Validaciones
{
    class Parametro
    {
        string nombre;
        List<string> atributos = new List<string>();
        List<string> metodos = new List<string>();

        public string Nombre
        {
            get
            {
                return nombre;
            }
            set
            {
                nombre = value;
            }
        }
        public List<string> Atributo
        {
            get
            { return atributos; }
        }

        public List<string> Metodo
        {
            get
            { return metodos; }
        }



        public void AddAtributo(string line)
        {
            atributos.Add(line);
        }

        public void AddMetodo(string line)
        {
            metodos.Add(line);
        }

        public void ModificarAtributo(int indice, string atributo)
        {
            atributos.RemoveAt(indice);
            atributos.Insert(indice, atributo);
        }

        public void EliminarAtributo(int indice)
        {
            atributos.RemoveAt(indice);
        }

        public void ModificarMetodo(int indice, string metodo)
        {
            metodos.RemoveAt(indice);
            metodos.Insert(indice, metodo);
        }

        public void EliminarMetodo(int indice)
        {
            metodos.RemoveAt(indice);
        }
    }
}
