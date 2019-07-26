using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UMLGraph.Grupos.Grupo5.Vista
{
    public partial class Fcinterfaz : Form
    {
        GraficaGrupo5 opener;
        public Fcinterfaz(GraficaGrupo5 parentForm)
        {
            InitializeComponent();
            opener = parentForm;
            txtNombre.Select(txtNombre.TextLength, 0);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {

            opener.nombre = txtNombre.Text;
            opener.metodos = txtMetodos.Text;
            this.Close();
        }

        private void txtNombre_MouseClick(object sender, MouseEventArgs e)
        {
            txtNombre.Text = "";
        }

        private void txtMetodos_MouseClick(object sender, MouseEventArgs e)
        {
            txtMetodos.Text = "";
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtNombre.Text.Length == 0)
            {
                e.KeyChar = e.KeyChar.ToString().ToUpper().ToCharArray()[0];
            }

            else if (txtNombre.Text.Length > 0)
            {
                e.KeyChar = e.KeyChar.ToString().ToLower().ToCharArray()[0];
            }


            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = true;
            }
        }
    }
}
