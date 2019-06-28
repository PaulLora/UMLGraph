using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UMLGraph
{
    public partial class InterfazGrafica : Form
    {
        public InterfazGrafica(String usuario)
        {
            InitializeComponent();
            lblBienvenida.Text = "Bienvenid@\n" + usuario;
        }

        List<Clase> listaClases = new List<Clase>();
        //down es para saber si se esta clickeando algo
        bool down = false;
        //inicial es para definir el punto donde esta el mouse cuando hace click
        Point inicial;

        //Todo lo que tenga Mouse es para mover las figuras
        private void Ctr_MouseMove(object sender, MouseEventArgs e)
        {
            Control ctr = (Control)sender;

            //Si down es true se esta clickeando el mouse, ademas se verifica que no se pueda arrastrar la figura mas alla del espacio permitido
            if (down
                && e.X + ctr.Left - inicial.X >= this.panel1.Width
                && e.Y + ctr.Top - inicial.Y >= panel2.Height)
            {
                ctr.Left = e.X + ctr.Left - inicial.X;
                ctr.Top = e.Y + ctr.Top - inicial.Y;
            }
        }

        private void Ctr_MouseUp(object sender, MouseEventArgs e) => down = false;

        private void Ctr_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                down = true;
                inicial = e.Location;
            }
        }

        private void btnClase_Click(object sender, EventArgs e)
        {
            //Se añade una nueva clase a la lista
            listaClases.Add(new Clase(160, 120));

            //Aqui se añade el panel de la clase a los controles del Form
            this.Controls.Add(listaClases.Last().getCaja());
            

            //Este paso es para que el picture box se pueda mover arrastrando con el mouse
            listaClases.Last().getCaja().MouseDown += Ctr_MouseDown;
            listaClases.Last().getCaja().MouseUp += Ctr_MouseUp;
            listaClases.Last().getCaja().MouseMove += Ctr_MouseMove;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
