using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UMLGraph.Grupos.Grupo3.Validaciones;

namespace UMLGraph.Grupos.Grupo3.Interfaz
{
    public partial class LlenarClase : Form
    {
        Validador interfazValidar;
        Parametro parametro = new Parametro();

        String nombreClase = "None";
        List<String> atributos = new List<String>();
        List<String> metodos = new List<String>();


        bool enviar = false;


        public LlenarClase()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        public List<string> Metodos { get => metodos; set => metodos = value; }
        public List<string> Atributos { get => Atributos1; set => Atributos1 = value; }
        public string NombreClase { get => nombreClase; set => nombreClase = value; }
        public List<string> Atributos1 { get => atributos; set => atributos = value; }
        public bool Enviar { get => enviar; set => enviar = value; }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Label6_Click(object sender, EventArgs e)
        {

        }

        private void Button3_Click(object sender, EventArgs e)//modificar Atributo
        {
            

        }
        //Console.WriteLine(indice);

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)//agregar Item a las lista de atributos
        {
            
        }

        private void Button5_Click(object sender, EventArgs e)//borrarAtributos
        {
            
        }

        private void Button2_Click(object sender, EventArgs e)//agregar Metodo
        {
            
        }

        private void ListaMetodos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Button4_Click(object sender, EventArgs e)// Modificar Metodo
        {
            
        }

        private void Button6_Click(object sender, EventArgs e)//Eliminar Metodo
        {
            
        }

        private void Button3_Click_1(object sender, EventArgs e)//Boton aceptar
        {
                    }

        private void Panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void LlenarClase_Load(object sender, EventArgs e)
        {


        }

        private void Button3_Click_2(object sender, EventArgs e)
        {
            interfazValidar = new Validador_Nombre();
            if (!interfazValidar.validar(txtNombreClase.Text))
            {
                MessageBox.Show("Nombre de la clase invalido. El nombre de una clase tiene la siguiente estructura: Nombre");
            }
            /*else if (!interValidar.validarRepetidos(txtNombreClase.Text, lista))
            {
                MessageBox.Show("ya existe una clase con este nombre");
            }*/
            else
            {
                parametro.Nombre = txtNombreClase.Text;
                NombreClase = txtNombreClase.Text;
                foreach (String var in listaAtributos.Items)
                {
                    atributos.Add(var);
                }
                foreach (String var in listaMetodos.Items)
                {
                    metodos.Add(var);
                }
                //lista.agregar(parametro);
                //listClaseOrigen.Items.Add(parametro.Nombre);
                //listClaseDestino.Items.Add(parametro.Nombre);
                txtNombreClase.Clear();
                listaAtributos.Items.Clear();
                listaMetodos.Items.Clear();
                //parametro = new Parametro();

                //Form2 form = new Form2();
                //form.listaClases.Items.Add(parametro.Nombre);
                //form.Show();
                //this.Close();
                Enviar = true;
                Dispose();

            }

            //NombreClase = txtNombreClase.Text;



        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            interfazValidar = new Validador_Atributo();
            if (!interfazValidar.validar(txtNombreAtributo.Text))
            {
                MessageBox.Show("Los atributos se escriben de la siguiente manera: tipo Nombre_atributo;");
            }
            else
            {
                listaAtributos.Items.Add(txtTipoAtributo.Text + " " + txtNombreAtributo.Text);
                parametro.AddAtributo(txtTipoAtributo.Text + " " + txtNombreAtributo.Text);
                txtNombreAtributo.Clear();
                txtTipoAtributo.Clear();
            }
            //String nombreAtriuto=txtNombreAtributo.Text;
            //String tipoAtributo = txtTipoAtributo.Text;

            //listaAtributos.Items.Add(tipoAtributo+" "+nombreAtriuto);
        }

        private void BotonModificarAtributos_Click(object sender, EventArgs e)
        {
            if (botonModificarAtributos.Text == "modificar")
            {
                string atributoSelecccionado = listaAtributos.GetItemText(listaAtributos.SelectedItem);
                string[] valores = atributoSelecccionado.Split(' ');
                txtTipoAtributo.Text = valores[0];
                txtNombreAtributo.Text = valores[1];
                botonModificarAtributos.Text = "guardar";

            }
            else
            {
                interfazValidar = new Validador_Atributo();
                int indice = listaAtributos.SelectedIndex;
                if (!interfazValidar.validar(txtNombreAtributo.Text))
                {
                    MessageBox.Show("no se que valida aqui pero es algo de atributo");
                }
                else
                {
                    if (indice != -1)
                    {
                        listaAtributos.Items.RemoveAt(indice);
                        listaAtributos.Items.Insert(indice, txtTipoAtributo.Text + " " + txtNombreAtributo.Text);
                        parametro.modificarAtributo(indice, txtTipoAtributo.Text + " " + txtNombreAtributo.Text);
                    }
                    botonModificarAtributos.Text = "modificar";
                    txtNombreAtributo.Clear();
                    txtTipoAtributo.Clear();
                }
                //int indice = listaAtributos.SelectedIndex;
                //String nombreAtriuto = txtNombreAtributo.Text;
                //String tipoAtributo = txtTipoAtributo.Text;
                //if (indice != -1) {                   
                //listaAtributos.Items.RemoveAt(indice);
                //listaAtributos.Items.Insert(indice, tipoAtributo + " " + nombreAtriuto);
                //}
                //botonModificarAtributos.Text = "modificar";
            }
        }

        private void Button5_Click_1(object sender, EventArgs e)
        {
            int indice = listaAtributos.SelectedIndex;
            listaAtributos.Items.RemoveAt(indice);
            parametro.eliminarAtributo(indice);
        }

        private void Button2_Click_1(object sender, EventArgs e)
        {
            interfazValidar = new Validador_Metodo();
            if (!interfazValidar.validar(txtNombreMetodo.Text))
            {
                MessageBox.Show("error en el metodo ingresado");
            }
            else
            {
                listaMetodos.Items.Add(txtNombreMetodo.Text + ":" + txtRetorno.Text);
                parametro.AddMetodo(txtNombreMetodo.Text + ":" + txtRetorno.Text);
                txtNombreMetodo.Clear();
                txtRetorno.Clear();
            }
            //String nombremetodo = txtNombreMetodo.Text;
            //String tipoRetorno = txtRetorno.Text;
            //listaMetodos.Items.Add(nombremetodo + ":" + tipoRetorno);

        }

        private void BotonModificarMetodo_Click(object sender, EventArgs e)
        {
            if (botonModificarMetodo.Text == "modificar")
            {
                string metodoSeleccionado = listaMetodos.GetItemText(listaMetodos.SelectedItem);
                string[] valores = metodoSeleccionado.Split(':');
                txtNombreMetodo.Text = valores[0];
                txtRetorno.Text = valores[1];
                botonModificarMetodo.Text = "guardar";
                //cargado = true;
            }
            else
            {
                interfazValidar = new Validador_Metodo();
                int indice = listaMetodos.SelectedIndex;
                if (!interfazValidar.validar(txtNombreMetodo.Text))
                {
                    MessageBox.Show("Error en el metodo ingresado");
                }
                else
                {
                    if (indice != -1)
                    {
                        listaMetodos.Items.RemoveAt(indice);
                        listaMetodos.Items.Insert(indice, txtNombreMetodo.Text + ":" + txtRetorno.Text);
                        parametro.modificarMetodo(indice, txtNombreMetodo.Text + ":" + txtRetorno.Text);
                    }
                    botonModificarMetodo.Text = "modificar";
                    txtNombreMetodo.Clear();
                    txtRetorno.Clear();
                }
                /*String nombreMetodo = txtNombreMetodo.Text;
                String retorno = txtRetorno.Text;
                if (indice != -1)
                {
                    listaMetodos.Items.RemoveAt(indice);
                    listaMetodos.Items.Insert(indice, nombreMetodo + " " + retorno);
                }
                botonModificarMetodo.Text = "modificar";*/
            }
        }

        private void Button6_Click_1(object sender, EventArgs e)
        {
            int indice = listaMetodos.SelectedIndex;
            listaMetodos.Items.RemoveAt(indice);
            parametro.eliminarMetodo(indice);
        }

        private void Button4_Click_1(object sender, EventArgs e)
        {

        }
    }
}
