using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UMLGraph.Grupos.GrupoX.Figuras;

namespace UMLGraph.Grupos.GrupoX
{
    public partial class InsertarComposicion : Form
    {
        private List<Clase> listaClases;
        private List<Interfaz> listaInterfaces;
        private GraficaGrupo4 pnlPrincipal;
        Clase clase1, clase2;
        Interfaz interfaz1, interfaz2;

        public InsertarComposicion(object listaClases, object listaInterfaces, GraficaGrupo4 pnlPrincipal)
        {
            InitializeComponent();
            this.pnlPrincipal = pnlPrincipal;
            this.listaClases = (List<Clase>)listaClases;
            this.listaInterfaces = (List<Interfaz>)listaInterfaces;
            for (int i = 0; i < this.listaClases.Count(); i++)
            {
                cmbClase1.Items.Add(this.listaClases[i].getNombre());
                cmbClase2.Items.Add(this.listaClases[i].getNombre());
            }
            for (int i = 0; i < this.listaInterfaces.Count(); i++)
            {
                cmbClase1.Items.Add(this.listaInterfaces[i].getNombre());
                cmbClase2.Items.Add(this.listaInterfaces[i].getNombre());
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnCrear_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(listaClases.Count().ToString() + cmbClase1.Items.Count);
            for (int i = 0; i < listaClases.Count(); i++)
            {
                if (listaClases.Count() >= 1)
                {
                    if (listaClases[i].getNombre().Equals(cmbClase1.Text))

                    {
                        this.clase1 = listaClases[i];
                        //MessageBox.Show("\n\nAsignacion Clase1\n\n");
                    }
                }

                if (listaClases.Count() > 0)
                {
                    if (listaClases[i].getNombre().Equals(cmbClase2.Text))
                    {
                        this.clase2 = listaClases[i];
                        //MessageBox.Show("\nAsignacion clase2\n\n");
                    }
                }

            }
            for (int i = 0; i < listaInterfaces.Count(); i++)
            {
                if (listaInterfaces.Count() >= 1)
                {
                    if (listaInterfaces[i].getNombre().Equals(cmbClase1.Text))
                    {
                        this.interfaz1 = listaInterfaces[i];
                        //MessageBox.Show("\n\nAsiganacion interfaz1\n\n");
                    }
                }
                if (listaInterfaces.Count() > 0)
                {
                    if (listaInterfaces[i].getNombre().Equals(cmbClase2.Text))
                    {
                        this.interfaz2 = listaInterfaces[i];
                        //MessageBox.Show("\nAsignacion interfaz2\n\n");
                    }
                }
            }

            if (cmbClase1.Text.Equals(cmbClase2.Text))
            {
                MessageBox.Show("No puedes relacionar la misma clase");
            }
            else if (cmbClase1.Text.Substring(0, 1).Equals("C") && cmbClase2.Text.Substring(0, 1).Equals("C") && !cmbClase1.Text.Equals(cmbClase2.Text))
            {
                //MessageBox.Show("\n\nentra a funcion\n\n");
                this.pnlPrincipal.agregarComposicion(this.clase1, this.clase2);
                this.Close();
            }
            else
            {
                MessageBox.Show("Este tipo de relacion no esta disponible en esta version del programa");
            }
        }

    }
}
