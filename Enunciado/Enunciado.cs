using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMLGraph
{
    class Enunciado
    {
        private string enunciadoTxt;
        private int numEjercicio;
        public Enunciado(int numEjercicio, String enunciado)
        {
            this.enunciadoTxt = enunciado;
            this.numEjercicio = numEjercicio;

        }
        public string EnunciadoTxt
        {
            get
            {
                return enunciadoTxt;
            }
            set
            {
                enunciadoTxt = value;
            }
        }

        public int NumEjercicio
        {
            get
            {
                return numEjercicio;
            }
            set
            {
                numEjercicio = value;
            }
        }
    }
}
