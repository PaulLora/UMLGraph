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
    public partial class Fclase : Form
    {
        GraficaGrupo5 opener;
        public Fclase(GraficaGrupo5 parentForm)
        {
            InitializeComponent();
            opener = parentForm;
            txtNombre.Select(txtNombre.TextLength, 0);
        }
      
        
        private void button1_Click(object sender, EventArgs e)
        {
                
               
           
        }

        private void txtAtributos_KeyUp(object sender, KeyEventArgs e)
        {
          
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_KeyPress(object sender, KeyPressEventArgs e)
        {
           
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

        private void button1_Click_1(object sender, EventArgs e)
        {
            opener.nombre = txtNombre.Text;
            opener.atributos = txtAtributos.Text;
            opener.metodos = txtMetodos.Text;

            this.Close();

        }

        private void txtNombre_MouseClick(object sender, MouseEventArgs e)
        {
            txtNombre.Text="";
        }

        private void txtAtributos_MouseClick(object sender, MouseEventArgs e)
        {
            txtAtributos.Text = "";
        }

        private void txtMetodos_MouseClick(object sender, MouseEventArgs e)
        {
            txtMetodos.Text = "";
        }
    }

}
