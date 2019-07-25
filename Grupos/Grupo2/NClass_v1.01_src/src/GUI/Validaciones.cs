using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NClass.GUI
{
    public class Validaciones
    {
        public static string ValidaNombre(string name)
        {
            if (name.Contains(" "))
            {
                return "Nombre contiene espacios";
            }
            if (name.Any(ch => char.IsUpper(ch)))
            {
                return "Nombre contiene mayusculas";
            }
            return "bien";
        }
    }
}
