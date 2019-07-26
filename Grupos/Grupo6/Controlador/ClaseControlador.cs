using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMLGraph.Grupos.Grupo6.Modelo;

namespace UMLGraph.Grupos.Grupo6.Controlador
{
    class ClaseControlador
    {
        List<Clase> clases = new List<Clase>();
        //private PantallaTrabajoGr6 pantallaTrabajo;

        public String crearIdClase(int idTemp)
        {
            String id = "Clase" + idTemp;
            foreach (Clase clase in this.clases)
            {
                if (clase.IdClase.Equals(id))
                {
                    id = crearIdClase(idTemp + 1);
                }

            }
            return id;
        }
        public void setDatosClase(String titulo, String atributos, String metodos)
        {
            String id = crearIdClase(1);
            List<String> atributosTemp = new List<String>();
            List<String> metodosTemp = new List<String>();

            String[] atributosSeparados = atributos.Split(',');
            String[] metodosSeparados = metodos.Split(',');

            for (int i = 0; i < atributosSeparados.Length; i++)
            {
                atributosTemp.Add(atributosSeparados[i]);
            }

            for (int i = 0; i < metodosSeparados.Length; i++)
            {
                metodosTemp.Add(metodosSeparados[i]);
            }

        }
        public void agregarClaseLista(Clase clase)
        {
            clases.Add(clase);
        }
        public void setActualizarClase(String id, String titulo, String atributos, String metodos)
        {
            List<String> atributosTemp = new List<String>();
            List<String> metodosTemp = new List<String>();
            String[] atributosSeparados = atributos.Split(',');
            String[] metodosSeparados = metodos.Split(',');
            for (int i = 0; i < atributosSeparados.Length; i++)
            {
                atributosTemp.Add(atributosSeparados[i]);
            }

            for (int i = 0; i < metodosSeparados.Length; i++)
            {
                metodosTemp.Add(metodosSeparados[i]);
            }
            foreach (Clase clase in this.clases)
            {
                if (clase.IdClase.Equals(id))
                {
                    clase.Titulo = titulo;
                    clase.Atributos = atributosTemp;
                    clase.Metodos = metodosTemp;
                    clase.crearPanel();
                }
            }
        }
    }
}
