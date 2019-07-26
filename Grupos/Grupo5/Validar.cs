using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using UMLGraph.Grupos.Grupo5.Figuras;

namespace UMLGraph.Grupos.Grupo5
{
     class Validar
    {
        public Clase5 ExisteClase(List<Clase5> Ccoleccion, string nombre)
        {
            Clase5 claseEncontrada = null;
            foreach (Clase5 item in Ccoleccion)
            {
                if (item.nombre.Equals(nombre))
                    claseEncontrada = item;
               
            }
            return claseEncontrada;

        }
        public ClaseInterface5 ExisteInterface(List<ClaseInterface5> Ccoleccion, string nombre)
        {
            ClaseInterface5 claseEncontrada = null;
            foreach (ClaseInterface5 item in Ccoleccion)
            {
                if (item.nombre.Equals(nombre))
                    claseEncontrada = item;

            }
            return claseEncontrada;

        }

        public Asociacion5  ValidarAsociacion(Clase5 clase1, Clase5 clase2)//clases unidas
        {
            Asociacion5 item=null;
            if (clase1 != null && clase2 != null)
            {
                Clase5 aux;
                if (clase1.puntoFinal.X > clase2.puntoFinal.X)
                {
                    aux = clase1;
                    clase1 = clase2;
                    clase2 = aux;


                }
                Point puntoInicial = new Point(clase1.puntoFinal.X + 150, clase1.puntoFinal.Y-50);
                Point puntoFinal = new Point (clase2.puntoFinal.X,clase2.puntoFinal.Y-50);
                Point ptMedio = new Point(puntoInicial.X - (puntoFinal.X - puntoInicial.X), puntoFinal.Y);
                 item =new Asociacion5(puntoInicial, ptMedio, puntoFinal, clase1.nombre, clase2.nombre);
                
            }
            return item;

        }
        public RelacionInterface5 ValidarRelacionInterface(ClaseInterface5 cla1, Clase5 cla2)//clases unidas
        {
            RelacionInterface5 item = null;
            if (cla1 != null && cla2 != null)
            {
                Point aux;
                Point clase1 = cla1.puntoFinal;
                Point clase2 = cla2.puntoFinal;
                if (clase1.X > clase2.X)
                {
                    aux = clase1;
                    clase1 = clase2;
                    clase2 = aux;


                }
                Point puntoInicial = new Point(clase1.X + 150, clase1.Y - 50);
                Point puntoFinal = new Point(clase2.X, clase2.Y - 50);
                Point ptMedio = new Point(puntoInicial.X - (puntoFinal.X - puntoInicial.X), puntoFinal.Y);
                item = new RelacionInterface5(puntoInicial, ptMedio, puntoFinal, cla1.nombre, cla2.nombre);

            }
            return item;

        }

        public Generalizacion5 ValidarGeneralizacion(Clase5 clase1, Clase5 clase2)
        {
            Generalizacion5 item = null;
            if (clase1 != null && clase2 != null)
            {
                Clase5 aux;
                if (clase1.puntoFinal.X > clase2.puntoFinal.X)
                {
                    aux = clase1;
                    clase1 = clase2;
                    clase2 = aux;

                }
                Point puntoInicial = new Point(clase1.puntoFinal.X + 150, clase1.puntoFinal.Y);
                Point puntoFinal = clase2.puntoFinal;
                Point ptMedio = new Point(puntoInicial.X - (puntoFinal.X - puntoInicial.X), puntoFinal.Y);
                item = new Generalizacion5(puntoInicial, ptMedio, puntoFinal, clase1.nombre, clase2.nombre);

            }
            return item;
        }
        public bool ValidarNombre(string nombre)
        {
            bool bandera=false;
            Regex verificarVerbo = new Regex(@"[a-zA-A]+(?:ar|er|ir|s)$");
            if (verificarVerbo.IsMatch(nombre))
            {
                bandera = true;
            }
            return bandera;

        }
        public bool validarAsociacionCont(List<Asociacion5> Acoleccion,List<Clase5> Ccoleccion)
        {

            bool bandera;
            int numAso = Acoleccion.Count;
            int numClase = Ccoleccion.Count;
            if (numAso == 0)
            {
                return false;
            }
            else
            {
                if (numAso < numClase)
                {
                    for (int i = 0; i < numAso; i++)
                    {
                        for (int j = 0; j < numClase; j++)
                        {

                            if (Acoleccion[i].nombre.Equals(Ccoleccion[j].nombre) || Acoleccion[i].nombre2.Equals(Ccoleccion[j].nombre))
                            {
                                
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }

                }
                else
                {
                    for (int j = 0; j < numClase; j++)
                    {
                        for (int i = 0; i < numAso; i++)
                        {

                            if (Acoleccion[i].nombre.Equals(Ccoleccion[j].nombre) || Acoleccion[i].nombre2.Equals(Ccoleccion[j].nombre))
                            {
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }

                }
            }
           

            return true;

        }
    }
}
