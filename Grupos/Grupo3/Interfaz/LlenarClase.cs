using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UMLGraph.Grupos.Grupo3.Interfaz
{
    public partial class LlenarClase : Form
    {
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
                int indice = listaAtributos.SelectedIndex;
                String nombreAtriuto = txtNombreAtributo.Text;
                String tipoAtributo = txtTipoAtributo.Text;
                if (indice != -1)
                {
                    listaAtributos.Items.RemoveAt(indice);
                    listaAtributos.Items.Insert(indice, tipoAtributo + " " + nombreAtriuto);
                }
                botonModificarAtributos.Text = "modificar";
            }

        }
        //Console.WriteLine(indice);

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)//agregar Item a las lista de atributos
        {
            String nombreAtriuto = txtNombreAtributo.Text;
            String tipoAtributo = txtTipoAtributo.Text;

            listaAtributos.Items.Add(tipoAtributo + " " + nombreAtriuto);
        }

        private void Button5_Click(object sender, EventArgs e)//borrarAtributos
        {
            int indice = listaAtributos.SelectedIndex;
            listaAtributos.Items.RemoveAt(indice);
        }

        private void Button2_Click(object sender, EventArgs e)//agregar Metodo
        {
            String nombremetodo = txtNombreMetodo.Text;
            String tipoRetorno = txtRetorno.Text;
            listaMetodos.Items.Add(nombremetodo + " " + tipoRetorno);

        }

        private void ListaMetodos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Button4_Click(object sender, EventArgs e)// Modificar Metodo
        {
            if (botonModificarMetodo.Text == "modificar")
            {
                string metodoSeleccionado = listaMetodos.GetItemText(listaMetodos.SelectedItem);
                string[] valores = metodoSeleccionado.Split(' ');
                txtNombreMetodo.Text = valores[0];
                txtRetorno.Text = valores[1];
                botonModificarMetodo.Text = "guardar";
                //cargado = true;
            }
            else
            {
                int indice = listaMetodos.SelectedIndex;
                String nombreMetodo = txtNombreMetodo.Text;
                String retorno = txtRetorno.Text;
                if (indice != -1)
                {
                    listaMetodos.Items.RemoveAt(indice);
                    listaMetodos.Items.Insert(indice, nombreMetodo + " " + retorno);
                }
                botonModificarMetodo.Text = "modificar";
            }
        }

        private void Button6_Click(object sender, EventArgs e)//Eliminar Metodo
        {
            int indice = listaMetodos.SelectedIndex;
            listaMetodos.Items.RemoveAt(indice);
        }

        private void Button3_Click_1(object sender, EventArgs e)//Boton aceptar
        {
            NombreClase = txtNombreClase.Text;
            foreach (String var in listaAtributos.Items)
            {
                atributos.Add(var);
            }
            foreach (String var in listaMetodos.Items)
            {
                metodos.Add(var);
            }
            Enviar = true;
            Dispose();
        }

        private void Panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void LlenarClase_Load(object sender, EventArgs e)
        {


        }

        private void Button3_Click_2(object sender, EventArgs e)
        {

        }
    }
}
