using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UMLGraph.Grupos.Grupo1.Validacion
{
    class ValidacionComposicion
    {
        Forma_Composicion formaComposicion;
        public ValidacionComposicion(Forma_Composicion formaComposicion)
        {
            this.formaComposicion = formaComposicion;
        }
        public int validar()
        {

            System.Windows.Forms.Panel panelPadre = formaComposicion.listaTodoPartes.First();
            TextBox nombrePadre = (TextBox)panelPadre.Controls[0];
            String nombrePadre1 = nombrePadre.Text;

            for (int i = 1; i < formaComposicion.listaTodoPartes.Count; i++)
            {
                var confirmResult = MessageBox.Show("¿Es " + formaComposicion.listaTodoPartes[i].Controls[0].Text + " parte de  " + nombrePadre1 + " ?!!", "Confirm", MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {

                }
                else
                {
                    MessageBox.Show("Error en la Agregación.Un hijo hereda todos los métodos y atributos del padre y significa 'es parte de' ");
                    formaComposicion.g.Clear(System.Drawing.Color.White);

                    return 0;
                }

                var confirmResult2 = MessageBox.Show("¿Si desaparece la clase Todo llamada " + nombrePadre1 + ", la clase  " + formaComposicion.listaTodoPartes[i].Controls[0].Text + " desaparece ?!!", "Confirm", MessageBoxButtons.YesNo);
                if (confirmResult2 == DialogResult.Yes)
                {

                }
                else
                {
                    MessageBox.Show("Error en la Agregación.Si es cohesiva la existencia del todo con las partes se recomienda usar Composición ");
                    formaComposicion.g.Clear(System.Drawing.Color.White);

                    return 0;
                }




            }
            return 1;
        }
    }
}
