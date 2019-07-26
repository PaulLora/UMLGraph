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
using UMLGraph.Grupos.Grupo6;

namespace UMLGraph.Grupos.Grupo6.Vista
{
    public partial class Formulario : Form
    {
        private String titulo;
        private String atributos;
        private String metodos;
        private PantallaTrabajoGr6 pantallaTrabajoGr6;
        public Formulario(PantallaTrabajoGr6 pantallaTrabajoGr6Recibida)
        {
            InitializeComponent();
            this.pantallaTrabajoGr6 = pantallaTrabajoGr6Recibida;
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Btn_crear_Click(object sender, EventArgs e)
        {
            //Verificar si existe una clase con el mismo nombre
            //Object clase = pantallaTrabajoGr6.existeClase(this.txt_titulo.Text);
            Object clase = pantallaTrabajoGr6.existeClase(this.txt_titulo.Text);
            if (clase == null)
            {
                this.titulo = this.txt_titulo.Text;
                this.atributos = this.txt_atributos.Text;
                this.metodos = this.txt_metodos.Text;
                pantallaTrabajoGr6.setDatosClase(this.titulo, this.atributos, this.metodos);
                this.Hide();
            }
            else
            {
                MessageBox.Show("Ya existe una clase con este nombre");
            }
            
        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Formulario_Load(object sender, EventArgs e)
        {

        }

        private void Txt_titulo_TextChanged(object sender, EventArgs e)
        {
            validarTitulo(txt_titulo.Text);
        }
        private void validarTitulo(String tituloVeri)
        {
            Regex verificarTitulo = new Regex(@"[a-zA-A]+(?:ar|er|ir)$");


            if (verificarTitulo.IsMatch(tituloVeri))
            {
                DialogResult seguro = MessageBox.Show("EL nombre de una clase no puede ser verbo", "confirmación", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void Txt_atributos_Enter(object sender, EventArgs e)
        {
          
        }
    }
}
