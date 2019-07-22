using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UMLGraph.Grupos.Grupo5
{
    public partial class FpropiedadesClase : Form
    {
        GraficaGrupo5 opener;
        public FpropiedadesClase(GraficaGrupo5 parentForm)
        {
            InitializeComponent();
            opener = parentForm;
        }
      
        
        private void button1_Click(object sender, EventArgs e)
        {
                
                opener.nombre = txtNombre.Text;
                opener.atributos = txtAtributos.Text;
                opener.metodos = txtMetodos.Text;

                this.Close();
           
        }
    }

}
