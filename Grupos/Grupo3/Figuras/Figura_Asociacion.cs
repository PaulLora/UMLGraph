using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UMLGraph.Grupos.Grupo3.Librerias;

namespace UMLGraph.Grupos.Grupo3.Figuras
{
    class Figura_Asociacion : Figura_Relacion
    {
        public Figura_Asociacion(Figura_Relacion father)
        {
            this.FiguraNombre = "Asc" + father.FiguraNombre;
            this.RelPuntos = father.RelPuntos;
            this.RelIni = father.RelIni;
            this.RelFin = father.RelFin;
            this.Dibujador = father.Dibujador;
            this.isFull = father.isFull;
        }
        public Figura_Asociacion()
        {
            this.FiguraNombre = "Asc";
        }
    }
}
