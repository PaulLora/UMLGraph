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
    public partial class InsertarHerencia : Form
    {
        private List<Clase> listaClases;
        private List<Interfaz> listaInterfaces;
        private GraficaGrupo4 pnlPrincipal;
        Clase clase1, clase2;
        Interfaz interfaz1, interfaz2;

        public InsertarHerencia(object listaClases, object listaInterfaces, GraficaGrupo4 pnlPrincipal)
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
            else if (cmbClase1.Text.Substring(0, 1).Equals("C") && cmbClase2.Text.Substring(0, 1).Equals("C") && !cmbClase1.Text.Equals(cmbClase2.Text) && validar(clase1, clase2))
            {
                //MessageBox.Show("\n\nentra a funcion\n\n");
                this.pnlPrincipal.agregarHerencia(this.clase1, this.clase2);
                this.Close();
            }
            else
            {
                MessageBox.Show("Tienes errores por resolver o estas tratando de relacionar dos clases que no pueden relacionarse");
                this.Close();
            }
        }

        private bool validar(Clase clase1, Clase clase2)
        {
            String atributosClase1 = clase1.getAtributos();
            String metodosClase1 = clase1.getMetodos();
            String atributosClase2 = clase2.getAtributos();
            String metodosClase2 = clase2.getMetodos();
            String tituloClase1 = clase1.getTitulo();
            String tituloClase2 = clase2.getTitulo();
            String errores = "";
            if (tituloClase2.Equals("")) errores += "Ingresa el nombre de la clase padre\n";
            if (tituloClase1.Equals("")) errores += "Ingresa el nombre de la clase hijo\n";
            if (atributosClase2.Equals("")) errores += "Ingresa los atributos de la clase padre\n";
            if (metodosClase2.Equals("")) errores += "Ingresa los metodos de la clase padre\n";
            if (!atributosClase1.Equals(atributosClase2)) errores += "La clase hijo debe tener los mismos atributos que la clase padre\n";
            if (!metodosClase1.Equals(metodosClase2)) errores += "La clase hijo debe tener los mismos metodos que la clase padre\n";
            if (!errores.Equals("")){
                MessageBox.Show(errores);
                return false;
            }
            else return true;
        }
    }
}
