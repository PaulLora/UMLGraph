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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            this.txtUsuario.Text = "admin";
            this.txtClave.Text = "admin";
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Logear(this.txtUsuario.Text, this.txtClave.Text);
        }

        private void Logear(string usuario, string clave)
        {
            try
            {
                if (usuario.Equals("admin"))
                {
                    if (clave.Equals("admin"))
                    {
                        this.Hide();
                        new InterfazGrafica(this.txtUsuario.Text).Show();
                    }
                    else
                    {
                        MessageBox.Show("Clave incorrecta");
                    }
                }
                else
                {
                    MessageBox.Show("Usuario incorrecto");
                }
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }
        }
    }
}
