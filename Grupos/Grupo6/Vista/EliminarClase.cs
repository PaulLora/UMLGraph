using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UMLGraph.Grupos.Grupo6.Modelo;

namespace UMLGraph.Grupos.Grupo6.Vista
{
    public partial class EliminarClase : Form
    {
        private String titulo;
        private PantallaTrabajoGr6 pantallaTrabajo;
        public EliminarClase(PantallaTrabajoGr6 pantallaTrabajoRecibida)
        {
            InitializeComponent();
            this.pantallaTrabajo = pantallaTrabajoRecibida;
        }

        private void Btn_limpiarA_Click(object sender, EventArgs e)
        {
            pantallaTrabajo.limpiarPanel();
            this.Hide();
            pantallaTrabajo.actulizarAreaTrabajo();
        }

        private void Btn_eliminar_Click(object sender, EventArgs e)
        {
            Clase clase = (Clase)pantallaTrabajo.existeClase(this.txt_titulo.Text);

            if (clase != null)
            {
                this.titulo = this.txt_titulo.Text;
                pantallaTrabajo.eliminarClaseRelacion(clase);
                this.Hide();
                pantallaTrabajo.actulizarAreaTrabajo();
            }
            else
            {
                MessageBox.Show("No existe una clase con ese nombre");
            }
        }

        private void EliminarClase_Load(object sender, EventArgs e)
        {

        }
    }
}
