using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UMLGraph
{
    class ValidacionInterfaz : Validacion
    {
        Forma_Interfaz formaInterfaz;

        public ValidacionInterfaz(Forma_Interfaz formaInterfaz)
        {
            this.formaInterfaz = formaInterfaz;
        }

        public int validar()
        {
            int valido = 1;
            TextBox nombre = (TextBox)formaInterfaz.dynamicPanel.Controls[0];
            String nombreInterfaz = nombre.Text;
            List<string> metodos = new List<string>();
            String CosasRich = formaInterfaz.dynamicPanel.Controls[3].Text;
            String[] cortes = CosasRich.Split('\n');
            for (int i = 0; i < cortes.Length; i++)
            {
                metodos.Add(cortes[i]);
            }

            if (metodos.Contains(""))
            {
                MessageBox.Show("Se necesita escribir al menos un método");
                return 0;
            }



            if (validarNombre(nombreInterfaz) == 0)
            {
                return 0;

            }
            if (validarRepetidos(metodos) == 0)
            {
                return 0;
            }

            if (validarMetodo(metodos) == 0)
            {
                return 0;
            }

            ListaFormas.listaClasesInterfaz.Add(formaInterfaz.dynamicPanel);
            formaInterfaz.dynamicPanel.Controls[4].Text = Convert.ToString(ListaFormas.listaClasesInterfaz.Count());



            return valido;
        }


        public int validarNombre(String nombre)
        {
            int res = 1;
            if (nombre.Equals(""))
            {
                MessageBox.Show("La clase no puede ser vacía");
                return 0;
            }
            int tam_var = nombre.Length;
            String Var_Sub = nombre.Substring((tam_var - 2), 2);
            if (Var_Sub.Equals("ar") || Var_Sub.Equals("er") || Var_Sub.Equals("ir"))
            {
                MessageBox.Show("Error!El nombre de una clase no puede ser un verbo");
                return 0;
            }

            for (int i = 0; i < ListaFormas.listaClasesInterfaz.Count(); i++)
            {

                if (ListaFormas.listaClasesInterfaz[i].Controls[0].Text.Equals(nombre))
                {
                    MessageBox.Show("Error! No se puede crear 2 interfaces con el mismo nombre");
                    return 0;

                }
            }



            return res;


        }

        public int validarRepetidos(List<string> metodos)
        {
            //método para verificar que no estén atributos ni métodos repetidos
            int res = 1;

            var agrupacion2 = metodos.GroupBy(x => x).Select(g => new { Text = g.Key, Count = g.Count() }).ToList();

            foreach (var b in agrupacion2)
            {

                if (b.Count > 1)
                {
                    res = 0;
                    MessageBox.Show("Los métodos no pueden estar repetidos");
                    return res;

                }
            }

            return res;
        }

        public int validarMetodo(List<string> metodos)
        {
            String rgx = @"^[A-Za-z]+(?:ar|er|ir)((_)?[A-Za-z]+)?\(\);$";
            for (int i = 0; i < metodos.Count(); i++)
            {
                if (!Regex.IsMatch(metodos[i], rgx))
                {
                    MessageBox.Show("Para escribir un método, asegúrese de escribir con la siguiente sintaxis \n Verbo(); o Verbo_Sustantivo();");
                    return 0;
                }
            }
            return 1;

        }
    }
}
