using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

            System.Windows.Forms.Panel panelPadre = forma_Herencia.listaPadreHijo.First();
            TextBox nombrePadre = (TextBox)panelPadre.Controls[0];
            String nombrePadre1 = nombrePadre.Text;

            for (int i = 1; i < forma_Herencia.listaPadreHijo.Count; i++)
            {
                var confirmResult = MessageBox.Show("¿Es " + forma_Herencia.listaPadreHijo[i].Controls[0].Text + " un tipo de " + nombrePadre1 + " ?!!", "Confirm", MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {

                }
                else
                {
                    MessageBox.Show("Error en la herencia.Un hijo hereda todos los métodos y atributos del padre y significa 'es un tipo de' ");
                    forma_Herencia.g.Clear(System.Drawing.Color.White);

                    return 0;
                }



            }

            reglaHerenciaAtributos();
            reglaHerenciaMetodos();
            ListaFormas.listaHerencias.Add(forma_Herencia.listaPadreHijo);







            return 1;



        }


        public void reglaHerenciaMetodos()
        {
            String atributosPadre = forma_Herencia.listaPadreHijo[0].Controls[3].Text;
            for (int i = 1; i < forma_Herencia.listaPadreHijo.Count(); i++)
            {
                String atributosHijo = forma_Herencia.listaPadreHijo[i].Controls[3].Text;
                String padreHijo = atributosHijo + "\n" + atributosPadre;
                forma_Herencia.listaPadreHijo[i].Controls[3].Text = padreHijo;
            }



        }


        public void reglaHerenciaAtributos()
        {
            String atributosPadre = forma_Herencia.listaPadreHijo[0].Controls[2].Text;
            for (int i = 1; i < forma_Herencia.listaPadreHijo.Count(); i++)
            {
                String atributosHijo = forma_Herencia.listaPadreHijo[i].Controls[2].Text;
                String padreHijo = atributosHijo + "\n" + atributosPadre;
                forma_Herencia.listaPadreHijo[i].Controls[2].Text = padreHijo;
            }

        }

    }
}
