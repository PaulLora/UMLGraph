using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UMLGraph
{
    class ValidacionClase
    {
        Forma_Clase formaClase;

        public ValidacionClase(Forma_Clase formaClase)
        {
            this.formaClase = formaClase;
        }


        public int validar()
        {
            List<string> atributos = obtenerAtributos();
            List<string> metodos = ObtenerMetodos();
            TextBox nombre1 = (TextBox)formaClase.dynamicPanel.Controls[0];
            string nombreClase = nombre1.Text;


            if (atributos.Contains("") || metodos.Contains(""))
            {
                MessageBox.Show("Los métodos ni los atributos pueden ser vacíos");
                return 0;
            }
            int valido = 1;
            int invalido = 0;


            if (validarNombre(nombreClase) == 0)
            {
                return invalido;
            }

            if (validarRepetidos(atributos, metodos) == 0)
            {
                return invalido;
            }
            if (esMetodoAccion(atributos) == 0)

            {
                return invalido;
            }

            if (validarMetodo(metodos) == 0)
            {
                return invalido;
            }


            ListaFormas.listaClasesInterfaz.Add(formaClase.dynamicPanel);
            ListaFormas.listaClasesInterfaz.Last().Controls[4].Text = Convert.ToString(ListaFormas.listaClasesInterfaz.Count());
            return valido;

        }





        public int validarNombre(String nombre)
        {
            int res = 1;
            if (nombre.Equals(""))
            {
                MessageBox.Show("El nombre de una clase no puede ser vacía");

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
                    MessageBox.Show("Error! No se puede crear 2 clases con el mismo nombre");
                    return 0;

                }
            }


            return res;

        }

        public int esVerbo(String palabra)
        {
            int res = 1;
            String Var_Sub = palabra.Substring((palabra.Length - 2), 2);

            if (Var_Sub.Equals("ar") || Var_Sub.Equals("er") || Var_Sub.Equals("ir"))
            {

                return 0;
            }


            return res;
        }

        public int validarRepetidos(List<string> atributos, List<string> metodos)
        {
            //método para verificar que no estén atributos ni métodos repetidos
            int res = 1;
            var agrupacion = atributos.GroupBy(x => x).Select(g => new { Text = g.Key, Count = g.Count() }).ToList();
            var agrupacion2 = metodos.GroupBy(x => x).Select(g => new { Text = g.Key, Count = g.Count() }).ToList();
            foreach (var a in agrupacion)
            {
                System.Console.WriteLine(a.Text + "\n");
                if (a.Count > 1 || esVerbo(a.Text) == 0)
                {
                    res = 0;
                    MessageBox.Show("Error!No pueden haber atributos repetidos");
                    return res;
                    // break;

                }

            }

            foreach (var b in agrupacion2)
            {
                System.Console.WriteLine(b);
                if (b.Count > 1)
                {
                    MessageBox.Show("Error!No pueden haber métodos repetidos");
                    res = 0;
                    return res;

                }
            }

            return res;
        }



        public int esMetodoAccion(List<string> atributos)
        {
            int res = 1;
            foreach (string a in atributos)
            {
                if (esVerbo(a) == 0)
                {
                    res = 0;
                    MessageBox.Show("Error!Los atributos no pueden ser verbos");

                    return res;


                }
            }
            return res;
        }


        //VALIDAR QUE LOS MÉTODOS TENGAN LA ESTRUCTURA ();
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
        //MÉTODO PARA OBTENER LOS METODOS DEL RICHBOX
        public List<String> ObtenerMetodos()
        {
            List<String> cadena = new List<String>();

            String CosasRich = formaClase.dynamicPanel.Controls[3].Text;
            String[] cortes = CosasRich.Split('\n');

            for (int i = 0; i < cortes.Length; i++)
            {
                cadena.Add(cortes[i]);
            }
            return cadena;


        }

        //METODO PARA OBTENER LOS ATRIBUTOS DEL RICHBOX
        public List<string> obtenerAtributos()
        {
            List<String> cadena = new List<String>();

            String CosasRich = formaClase.dynamicPanel.Controls[2].Text;
            String[] cortes = CosasRich.Split('\n');
            for (int i = 0; i < cortes.Length; i++)
            {
                cadena.Add(cortes[i]);


            }
            return cadena;

        }
    }
}
