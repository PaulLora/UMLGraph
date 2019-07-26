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
    public partial class Fasociacion : Form
    {
        GraficaGrupo5 opener;
   
        
        public Fasociacion(GraficaGrupo5 parentForm )
        {
            InitializeComponent();
            opener = parentForm;
            txtClase1.Select(txtClase1.TextLength, 0);

        }

        private void txtClase1_MouseClick(object sender, MouseEventArgs e)
        {
            txtClase1.Text = "";

        }

        private void txtClase1_KeyUp(object sender, KeyEventArgs e)
        {
            
        }

        private void btnAso_Click(object sender, EventArgs e)
        {
            opener.nClase1 = txtClase1.Text;
            opener.nClase2 = txtClase2.Text;
            this.Close();
            
        }

        private void txtClase2_MouseClick(object sender, MouseEventArgs e)
        {
            txtClase2.Text = "";
        }

        private void txtClase1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtClase1.Text.Length == 0)
            {
                e.KeyChar = e.KeyChar.ToString().ToUpper().ToCharArray()[0];
            }

            else if (txtClase1.Text.Length > 0)
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

        private void txtClase2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtClase2.Text.Length == 0)
            {
                e.KeyChar = e.KeyChar.ToString().ToUpper().ToCharArray()[0];
            }

            else if (txtClase2.Text.Length > 0)
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
