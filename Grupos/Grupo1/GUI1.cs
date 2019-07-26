using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Microsoft.VisualBasic;
using UMLGraph.Grupos.Grupo1.Validacion;

namespace UMLGraph.Grupos.Grupo1
{
    public partial class GUI1 : Form
    {
        [DllImport("user32.dll")]
        // GetCursorPos()hace todo posible
        static extern bool GetCursorPos(ref Point lpPoint);
        // Variable que necesitaremos para contar los pixeles viajados
        static protected long totalPixels = 0;
        static protected int currX;
        static protected int currY;
        static protected int diffX;
        static protected int diffY;

        Forma_Clase variableClase = new Forma_Clase();
        Forma_Interfaz variableInterfaz = new Forma_Interfaz();
        Forma_Asociacion variableAsociasion;
        List<Panel> clase = new List<Panel>();
        bool estaCreado = true;
        Canvas variableCanvas;
        int claseA, claseB;
        //Forma_Clase variableClase;

        public int xClick = 0, yClick = 0;



        public GUI1()
        {
           // MessageBox.Show("CALLA");
            InitializeComponent();
        }

        private void GUI1_Load(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {

            Application.Exit();
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            //btnRestaurar.Visible = false;
            //btnMaximizar.Visible = true;
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {

        }

        private void btnClase_Click(object sender, EventArgs e)
        {
            if (estaCreado == true)
            {
                Canvas c = new Canvas(this);
                Forma_Clase clase = new Forma_Clase();
                this.variableCanvas = c;
                this.variableClase = clase;
                variableClase.dibujar(variableCanvas);
                //this.clase = variableClase.ListaDeClase();

                // MessageBox.Show("");
                estaCreado = false;

            }

            else
            {
                variableClase.dibujar(variableCanvas);
                clase = variableClase.ListaDeClase();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            if (clase.Count < 2)
            {
                MessageBox.Show("Error para que exista Asociacion por lo menos debe haber 2 clases\n");
            }
            else
            {
                MessageBox.Show("RECUERDA. Asociacion es sinónimo de navegación. La clase A será un atributo de la clase B");
                try
                {
                    String name = Microsoft.VisualBasic.Interaction.InputBox(null, "Porfavor ingresa La clase A");

                    claseA = Int32.Parse(name);
                    name = Microsoft.VisualBasic.Interaction.InputBox(null, "Porfavor ingresa La clase B");
                    claseB = Int32.Parse(name);

                    Forma_Asociacion asociacion = new Forma_Asociacion(variableCanvas, claseA, claseB);
                    ValidacionAsociacion validarAs = new ValidacionAsociacion(asociacion);
                    validarAs.validar();
                    this.variableAsociasion = asociacion;
                }
                catch (Exception ex) {
                    Console.WriteLine(ex.ToString());
                }
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (estaCreado == true)
            {
                Canvas c = new Canvas(this);
                Forma_Interfaz interfaz = new Forma_Interfaz();
                this.variableCanvas = c;
                this.variableInterfaz = interfaz;
                variableInterfaz.dibujar(variableCanvas);
                estaCreado = false;
            }else
            {
                // claseA = (int)name;
                variableInterfaz.dibujar(variableCanvas);
            }

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            ListaFormas.listaClasesInterfaz.Clear();
            ListaFormas.listaHerencias.Clear();
            ListaFormas.listaInterfaz.Clear();


            this.Dispose();
        }

        private void btnHerencia_Click(object sender, EventArgs e)
        {
            try {
                if (ListaFormas.listaClasesInterfaz.Count() < 2)
                {
                    MessageBox.Show("Error para que exista Asociacion por lo menos debe haber 2 clases o interfaz\n");
                }
                else
                {
                    MessageBox.Show("RECUERDA QUE LA HERENCIA SIGNIFICA 'UN TIPO DE '\n TODOS LOS ATRIBUTOS Y METODOS \n DE LA CLASE PADRE PASARÁN A Los HIJOS");

                    String opcion = Microsoft.VisualBasic.Interaction.InputBox(null, "El padre será una clase o una interfaz? Seleccione 1 para clase y 2 para interfaz");
                    int opcion1 = Convert.ToInt32(opcion);



                    //El padre es una clase

                    String name = Microsoft.VisualBasic.Interaction.InputBox(null, "Porfavor ingresa la clase Padre");
                    claseA = Int32.Parse(name);
                    String nroHijos = Microsoft.VisualBasic.Interaction.InputBox(null, "Ingresa el número de hijos que tendrá la clase" + claseA);
                    int[] hijos;
                    hijos = new int[int.Parse(nroHijos)];
                    for (int i = 0; i < int.Parse(nroHijos); i++)
                    {
                        String hijo = Microsoft.VisualBasic.Interaction.InputBox(null, "Porfavor ingresa el hijo " + i);
                        int aux = int.Parse(hijo);
                        hijos[i] = aux - 1;

                    }

                    Forma_Herencia forma_Herencia = new Forma_Herencia(variableCanvas, int.Parse(nroHijos), hijos, claseA, opcion1);
                    ValidacionHerencia validarH = new ValidacionHerencia(forma_Herencia);
                    int res = validarH.validar();
                }
            } catch (Exception ex) {
                Console.WriteLine(ex.ToString());
            }
            

        }

        private void btnAgregacion_Click(object sender, EventArgs e)
        {
            try
            {
                if (ListaFormas.listaClasesInterfaz.Count() < 2)
                {
                    MessageBox.Show("Error para que exista Asociacion por lo menos debe haber 2 clases\n");
                }
                else
                {

                    MessageBox.Show("UNA AGREGACIÓN ES UNA RELACIÓN TODO-PARTES");

                    String padre = Microsoft.VisualBasic.Interaction.InputBox(null, "¿Cuál número de clase será el todo?");
                    int claseTodo = Convert.ToInt32(padre);
                    String nroHijos = Microsoft.VisualBasic.Interaction.InputBox(null, "Ingresa el número de ' partes' que tendrá la clase" + claseA);
                    int[] hijos;
                    hijos = new int[int.Parse(nroHijos)];
                    for (int i = 0; i < int.Parse(nroHijos); i++)
                    {
                        String hijo = Microsoft.VisualBasic.Interaction.InputBox(null, "Porfavor ingresa la clase Partes ");
                        int aux = int.Parse(hijo);
                        hijos[i] = aux - 1;

                    }

                    Forma_Agregacion formaAgregacion = new Forma_Agregacion(variableCanvas, int.Parse(nroHijos), hijos, claseTodo);
                    formaAgregacion.dibujar(variableCanvas);
                    ValidacionAgregacion validarA = new ValidacionAgregacion(formaAgregacion);
                    validarA.validar();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            

        }

        private void btnComposicion_Click(object sender, EventArgs e)
        {
            try {
                if (ListaFormas.listaClasesInterfaz.Count() < 2)
                {
                    MessageBox.Show("Error para que exista la composicion por lo menos debe haber 2 clases\n");
                }
                else
                {

                    MessageBox.Show("UNA COMPOSICIÓN ES UNA RELACIÓN TODO-PARTES");

                    String padre = Microsoft.VisualBasic.Interaction.InputBox(null, "¿Cuál número de clase será el todo?");
                    int claseTodo = Convert.ToInt32(padre);
                    String nroHijos = Microsoft.VisualBasic.Interaction.InputBox(null, "Ingresa el número de ' partes' que tendrá la clase" + claseA);
                    int[] hijos;
                    hijos = new int[int.Parse(nroHijos)];
                    for (int i = 0; i < int.Parse(nroHijos); i++)
                    {
                        String hijo = Microsoft.VisualBasic.Interaction.InputBox(null, "Porfavor ingresa la clase Partes ");
                        int aux = int.Parse(hijo);
                        hijos[i] = aux - 1;

                    }

                    Forma_Composicion formaComposicion = new Forma_Composicion(variableCanvas, int.Parse(nroHijos), hijos, claseTodo);
                    formaComposicion.dibujar(variableCanvas);
                    ValidacionComposicion validarA = new ValidacionComposicion(formaComposicion);
                    validarA.validar();
                }
            } catch (Exception ex) {
                Console.WriteLine(ex.ToString());
                    }
            
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)

            { xClick = e.X; yClick = e.Y; }

            else

            { this.Left = this.Left + (e.X - xClick); this.Top = this.Top + (e.Y - yClick); }
        }

        private static Point FindLocation(Control ctrl)
        {
            Point p;
            for (p = ctrl.Location; ctrl.Parent != null; ctrl = ctrl.Parent)
                p.Offset(ctrl.Parent.Location);
            return p;
        }

    }
}
