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
    public partial class FormularioRelacion : Form
    {
        Clase clasePadre;
        Clase claseHijo;
        String nombreRelacion;
        String tipoRelacion;
        private PantallaTrabajoGr6 pantallaTrabajo;
        public FormularioRelacion(PantallaTrabajoGr6 pantallaTrabajoGr6Recibida)
        {
            InitializeComponent();
            this.pantallaTrabajo = pantallaTrabajoGr6Recibida;
        }

        private void FormularioRelacion_Load(object sender, EventArgs e)
        {

        }

        private void Txt_NompreClasePadre_TextChanged(object sender, EventArgs e)
        {

        }

        private void Btn_relacionar_Click(object sender, EventArgs e)
        {
            //verificar si existe padre
            this.clasePadre = (Clase)pantallaTrabajo.existeClase(this.txt_NompreClasePadre.Text);
            //verificar si existe hjo
            this.claseHijo = (Clase)pantallaTrabajo.existeClase(this.txt_NompreClaseHijo.Text);
            this.tipoRelacion = this.cbox_tipoRelacion.Text;

            if (this.clasePadre != null && this.claseHijo != null)
            {
                this.nombreRelacion = this.tipoRelacion + " ( " + this.clasePadre.Titulo + "<--" + claseHijo.Titulo + " ) ";

                pantallaTrabajo.setDatosRelacion(this.nombreRelacion, this.tipoRelacion, this.clasePadre, this.claseHijo);
                this.Hide();

            }
            if (this.clasePadre == null)
            {
                MessageBox.Show("Debe ingresar el nombre de una Clase Padre existente del modelo");
            }
            if (this.claseHijo == null)
            {
                MessageBox.Show("Debe ingresar el nombre de una Clase Hijo existente del modelo");
            }
        }
    }
}
