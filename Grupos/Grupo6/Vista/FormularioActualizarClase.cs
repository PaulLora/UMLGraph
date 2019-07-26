using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UMLGraph.Grupos.Grupo6.Vista
{
    public partial class FormularioActualizarClase : Form
    {
        private String IdClase;
        private String titulo;
        private String atributos;
        private String metodos;
        private PantallaTrabajoGr6 pantallaTrabajo;
        public FormularioActualizarClase(PantallaTrabajoGr6 pantallaTrabajoRecibida, String idClaseRecibido, String tituloRecibido, List<String> atributosRecibido, List<String> metodosRecibido)
        {
            InitializeComponent();
            this.pantallaTrabajo = pantallaTrabajoRecibida;
            this.IdClase = idClaseRecibido;
            this.txt_titulo.Text = tituloRecibido;
            String atributosText = "";
            int cont = 0;
            foreach (String atributo in atributosRecibido)
            {
                cont++;
                if (cont < atributosRecibido.Count)
                {
                    atributosText += atributo + ",";
                }
                else
                {
                    atributosText += atributo;
                }

            }
            this.txt_atributos.Text = atributosText;
            String metodosText = "";
            cont = 0;
            foreach (String metodo in metodosRecibido)
            {
                cont++;
                if (cont < metodosRecibido.Count)
                {
                    metodosText += metodo + ",";
                }
                else
                {
                    metodosText += metodo;
                }

            }
            this.txt_metodos.Text = metodosText;
        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }
        private void Button1_Click(object sender, EventArgs e)
        {
           
                this.titulo = this.txt_titulo.Text;
                this.atributos = this.txt_atributos.Text;
                this.metodos = this.txt_metodos.Text;
                DialogResult confirmar = MessageBox.Show("¿Esta seguro realizar los cambios?", "confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (confirmar == DialogResult.Yes)
                {
                    this.Hide();
                    pantallaTrabajo.setActualizarClase(this.IdClase, this.titulo, this.atributos, this.metodos);
                }
          
        }

        private void Txt_titulo_TextChanged(object sender, EventArgs e)
        {
            validarTitulo(txt_titulo.Text);
        }
        private void validarTitulo(String tituloVeri)
        {
            Regex verificarTitulo = new Regex(@"[a-zA-A]+(?:ar|er|ir)");


            if (verificarTitulo.IsMatch(tituloVeri))
            {
                DialogResult seguro = MessageBox.Show("EL nombre de una clase no puede ser verbo", "confirmación", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void FormularioActualizarClase_Load(object sender, EventArgs e)
        {

        }
    }
}
