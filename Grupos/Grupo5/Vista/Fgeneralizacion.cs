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
    public partial class Fgeneralizacion : Form
    {
     
        GraficaGrupo5 opener;
        public Fgeneralizacion(GraficaGrupo5 parentForm)
        {
            InitializeComponent();
            opener = parentForm;
            txtNombrePadre.Select(txtNombrePadre.TextLength, 0);


        }
        
        private void txtNombrePadre_MouseClick(object sender, MouseEventArgs e)
        {
            txtNombrePadre.Text = "";
        }

        private void txtNombrePadre_KeyUp(object sender, KeyEventArgs e)
        {
            
        }

        private void txtAtributos_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMetodos_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            opener.nClase1 = txtNombrePadre.Text;
            this.Close();
        }

        private void txtNombrePadre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtNombrePadre.Text.Length == 0)
            {
                e.KeyChar = e.KeyChar.ToString().ToUpper().ToCharArray()[0];
            }

            else if (txtNombrePadre.Text.Length > 0)
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
