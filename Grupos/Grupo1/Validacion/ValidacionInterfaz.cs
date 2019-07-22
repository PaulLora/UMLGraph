using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            TextBox nombre=(TextBox) formaInterfaz.dynamicPanel.Controls[0];
            String nombreInterfaz = nombre.Text;
            List<string> metodos = new List<string>();
            String CosasRich = formaInterfaz.dynamicPanel.Controls[2].Text;
            String[] cortes = CosasRich.Split('\n');
            for (int i = 0; i < cortes.Length; i++)
            {
                metodos.Add(cortes[i]);
            }


            if (validarNombre(nombreInterfaz) == 0)
            {
                return 2;
      
            }
            if (validarRepetidos(metodos) == 0)
            {
                return 3;
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
                    
                    return res;

                }
            }

            return res;
        }


    }
}
