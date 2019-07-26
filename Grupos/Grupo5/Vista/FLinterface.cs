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
    public partial class FLinterface : Form
    {
        GraficaGrupo5 opener;
        public FLinterface(GraficaGrupo5 sm)
        {
            InitializeComponent();
           
           opener = sm;
        }

        private void txtNombreI_MouseClick(object sender, MouseEventArgs e)
        {
            txtNombreI.Text = "";

        }

        private void txtNomClase_MouseClick(object sender, MouseEventArgs e)
        {
            txtNomClase.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            opener.nClase1 = txtNombreI.Text;
            opener.nClase2 = txtNomClase.Text;
            this.Close();
        }
    }
}
