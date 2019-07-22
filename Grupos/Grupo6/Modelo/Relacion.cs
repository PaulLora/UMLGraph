using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UMLGraph.Grupos.Grupo6.Modelo
{
    class Relacion : Figura
    {
        /************************* Atributos *****************************/
        private String nombreRelacion;
        private String TipoRelacion;
        private Clase clasePadre;
        private Clase claseHijo;

        /************************* Constructores *****************************/
        public Relacion()
        {
        }

        public Relacion(string nombreRelacion, string tipoRelacion, Clase clasePadre, Clase claseHijo)
        {
            this.nombreRelacion = nombreRelacion;
            TipoRelacion = tipoRelacion;
            this.clasePadre = clasePadre;
            this.claseHijo = claseHijo;
        }

        /************************* GETTERS AND SETTERS *****************************/
        public string NombreRelacion { get => nombreRelacion; set => nombreRelacion = value; }
        public string TipoRelacion1 { get => TipoRelacion; set => TipoRelacion = value; }
        internal Clase ClasePadre { get => clasePadre; set => clasePadre = value; }
        internal Clase ClaseHijo { get => claseHijo; set => claseHijo = value; }

        /************************* MÉTODOS *****************************/



        /************************* MÉTODOS HEREDADOS *****************************/


        public override void dibujarFigura(Panel espaciotrabajo)
        {
            throw new NotImplementedException();
        }

        public override void dibujarFigura(Panel espaciotrabajo, Panel clase)
        {
            throw new NotImplementedException();
        }


        public override void moverFigura(Panel espaciotrabajo, MouseEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
