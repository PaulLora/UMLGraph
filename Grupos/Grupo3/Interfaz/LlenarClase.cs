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
        // bool isflag = true;
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

        private void Button3_Click_2(object sender, EventArgs e)//enviar los datos a la clase
        {

            interfazValidar = new Validador_Nombre();
            if (!interfazValidar.validar(txtNombreClase.Text) && txtNombreClase.Text != null)
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

        private void Button1_Click_1(object sender, EventArgs e)//agragar atributo
        {
            interfazValidar = new Validador_Atributo();
            if (!interfazValidar.validar(txtNombreAtributo.Text))
            {
                MessageBox.Show("El nombre de los atributos tiene la siguiente estructura: Nombre_atributo;");
            }
            else
            {
                listaAtributos.Items.Add(comboBoxTipoAtributo.SelectedItem.ToString() + " " + txtNombreAtributo.Text);
                parametro.AddAtributo(comboBoxTipoAtributo.SelectedItem.ToString() + " " + txtNombreAtributo.Text);
                txtNombreAtributo.Clear();
                comboBoxTipoAtributo.SelectedIndex = -1;

            }
            //String nombreAtriuto=txtNombreAtributo.Text;
            //String tipoAtributo = txtTipoAtributo.Text;

            //listaAtributos.Items.Add(tipoAtributo+" "+nombreAtriuto);
        }

        private void BotonModificarAtributos_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            if (botonModificarAtributos.Text == "Modificar")
            {

                string atributoSelecccionado = listaAtributos.GetItemText(listaAtributos.SelectedItem);
                string[] valores = atributoSelecccionado.Split(' ');
                /*for (int i=0; i<comboBoxTipoAtributo.Items.Count; i++) {
                    if (comboBoxTipoAtributo.Items[i].ToString().Equals(valores[0])) {
                        comboBoxTipoAtributo.SelectedIndex = i;
                    }
                }*/
                comboBoxTipoAtributo.SelectedText = valores[0];//VERIFICARRRRR!!!! txtTipoAtributo.text psdt:creo que si vale :-)
                txtNombreAtributo.Text = valores[1];
                botonModificarAtributos.Text = "Guardar";

            }
            else
            {

                interfazValidar = new Validador_Atributo();
                int indice = listaAtributos.SelectedIndex;
                if (!interfazValidar.validar(txtNombreAtributo.Text))
                {
                    MessageBox.Show("El nombre de los atributos tiene la siguiente estructura: Nombre_atributo;");
                }
                else
                {
                    if (indice != -1)
                    {
                        listaAtributos.Items.RemoveAt(indice);
                        listaAtributos.Items.Insert(indice, comboBoxTipoAtributo.SelectedItem.ToString() + " " + txtNombreAtributo.Text);
                        parametro.ModificarAtributo(indice, comboBoxTipoAtributo.SelectedItem.ToString() + " " + txtNombreAtributo.Text);
                    }
                    botonModificarAtributos.Text = "Modificar";
                    txtNombreAtributo.Clear();
                    comboBoxTipoAtributo.SelectedIndex = -1;

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

        private void Button5_Click_1(object sender, EventArgs e)//borrar atributo
        {
            int indice = listaAtributos.SelectedIndex;
            listaAtributos.Items.RemoveAt(indice);
            parametro.EliminarAtributo(indice);
            button5.Enabled = false;


        }

        private void Button2_Click_1(object sender, EventArgs e)//agregar metodo
        {

            interfazValidar = new Validador_Metodo();
            if (!interfazValidar.validar(txtNombreMetodo.Text))
            {
                MessageBox.Show("El nombre de los métodos tiene la siguiente estructura: Nombremetodo(); ");
            }
            else
            {
                listaMetodos.Items.Add(txtNombreMetodo.Text + ":" + comboBoxTipoRetorno.SelectedItem.ToString());
                parametro.AddMetodo(txtNombreMetodo.Text + ":" + comboBoxTipoRetorno.SelectedItem.ToString());
                txtNombreMetodo.Clear();
                comboBoxTipoRetorno.SelectedIndex = -1;

            }
            //String nombremetodo = txtNombreMetodo.Text;
            //String tipoRetorno = txtRetorno.Text;
            //listaMetodos.Items.Add(nombremetodo + ":" + tipoRetorno);

        }

        private void BotonModificarMetodo_Click(object sender, EventArgs e)
        {
            if (botonModificarMetodo.Text == "Modificar")
            {
                string metodoSeleccionado = listaMetodos.GetItemText(listaMetodos.SelectedItem);
                string[] valores = metodoSeleccionado.Split(':');
                txtNombreMetodo.Text = valores[0];
                comboBoxTipoRetorno.SelectedText = valores[1];//verificar!!! txtRetorno.text
                botonModificarMetodo.Text = "Guardar";
                //cargado = true;
            }
            else
            {
                interfazValidar = new Validador_Metodo();
                int indice = listaMetodos.SelectedIndex;
                if (!interfazValidar.validar(txtNombreMetodo.Text))
                {
                    MessageBox.Show("El nombre de los métodos tiene la siguiente estructura: Nombremetodo();");
                }
                else
                {
                    if (indice != -1)
                    {
                        listaMetodos.Items.RemoveAt(indice);
                        listaMetodos.Items.Insert(indice, txtNombreMetodo.Text + ":" + comboBoxTipoRetorno.SelectedItem.ToString());
                        parametro.ModificarMetodo(indice, txtNombreMetodo.Text + ":" + comboBoxTipoRetorno.SelectedItem.ToString());
                    }
                    botonModificarMetodo.Text = "Modificar";
                    txtNombreMetodo.Clear();
                    comboBoxTipoRetorno.SelectedIndex = -1;

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
            parametro.EliminarMetodo(indice);
            button6.Enabled = false;


        }

        private void Button4_Click_1(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtTipoAtributo_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxTipoAtributo.SelectedIndex != -1)
            {
                var bl = !string.IsNullOrEmpty(txtNombreAtributo.Text);
                button1.Enabled = bl;
            }
            else
            {
                button1.Enabled = false;
            }
        }
        private void listaAtributos_SelectedIndexChanged(object sender, EventArgs e)
        {
            button5.Enabled = true;
            // listaAtributos.SelectedIndex = 1;
            // listaAtributos.ClearSelected();
        }

        private void txtNombreAtributo_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNombreAtributo.Text))
            {
                comboBoxTipoAtributo.SelectedIndex = -1;
                button1.Enabled = false;

            }
            else
            {
                button1.Enabled = true;
            }

        }

        private void txtNombreMetodo_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNombreMetodo.Text))
            {
                comboBoxTipoRetorno.SelectedIndex = -1;
                button2.Enabled = false;

            }
            else
            {
                button2.Enabled = false;
            }
        }

        private void comboBoxTipoRetorno_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNombreMetodo.Text))
            {
                var bl = !string.IsNullOrEmpty(txtNombreMetodo.Text);
                button2.Enabled = bl;
            }
            else
            {
                button2.Enabled = false;
            }


        }

        private void listaMetodos_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            button6.Enabled = true;
        }

        private void txtNombreClase_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
