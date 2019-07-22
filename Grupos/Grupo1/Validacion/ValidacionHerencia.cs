using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMLGraph
{
    class ValidacionHerencia : Validacion
    {

        Forma_Herencia forma_Herencia;


        public ValidacionHerencia(Forma_Herencia forma_Herencia)
        {
            this.forma_Herencia = forma_Herencia;
        }


        public int validar()
        {

            //forma_Herencia.listaPadreHijo[1].Controls.IndexOf(this.0);
            return 1;
        }
    }
}
