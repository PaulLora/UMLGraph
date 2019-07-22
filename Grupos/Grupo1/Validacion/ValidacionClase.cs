using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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


        public ValidacionClase()
        {

        }



        public int validar()
        {
            List<string> atributos = formaClase.obtenerAtributos();
            List<string> metodos = formaClase.ObtenerMetodos();
            TextBox nombre1 = (TextBox)formaClase.dynamicPanel.Controls[0];

            //TextBox nombre = (TextBox) fdynamicPanel.Controls[0];
            string nombreClase = nombre1.Text;

            int valido = 1;

            if (validarNombre(nombreClase) == 0)
            {
                return 2;
            }


            if (validarRepetidos(atributos, metodos) == 0)
            {
                return 3;
            }


            if (esMetodoAccion(atributos) == 0)
            {
                return 4;
            }


            return valido;

        }

        

        public  int validar(String nombre,List<string> atributos, List<string>metodos)
        {
           // List<string> atributos=formaClase.obtenerAtributos();
            //List<string> metodos = formaClase.ObtenerMetodos();
            //TextBox nombre1 = (TextBox)formaClase.dynamicPanel.Controls[0];

            //TextBox nombre = (TextBox) fdynamicPanel.Controls[0];
            //string nombreClase = nombre1.Text;

            int valido = 1;

            if (validarNombre(nombre) == 0)
            {
                return 2;
            }
           
            
          if (validarRepetidos(atributos,metodos) ==0)
                {
                    return 3;
                }


            if (esMetodoAccion(atributos) == 0)
            {
                return 4;
            }
                                          
            
            return valido;

        }

        public int validarNombre(String nombre)
        {
            int res = 1;
            int tam_var = nombre.Length;
            String Var_Sub = nombre.Substring((tam_var - 2), 2);
            if (Var_Sub.Equals("ar") || Var_Sub.Equals("er") || Var_Sub.Equals("ir"))
                return 0;
           

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
                    
                    return res;
                    break;

                }

            }

            foreach (var b in agrupacion2)
            {
                System.Console.WriteLine(b);
                if (b.Count > 1)
                {
                    res = 0;
                    System.Console.WriteLine(b.Count);
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

                    return res;


                }
            }
            return res;
        }
    }
}
