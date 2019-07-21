using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grupo1Propietarios
{
    class Forma_Herencia : Forma
    {
        public List<Panel> listaPadreHijo = new List<Panel>();

        public Forma_Herencia()
        {

        }
        public void dibujar(Canvas canvas)
        {
            throw new NotImplementedException();


        }
    }
}
