using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UMLGraph
{
    class Forma_Interfaz
    {
        bool down = false;
        Point inicial;
        List<Panel> listaPaneles = new List<Panel>(); //Un alista de paneles es una lista de clases
        String hola = "";
        public Panel dynamicPanel;

        public void dibujar(Canvas canvas)
        {
            MessageBox.Show("Recuerde que la interfaz solo contiene metodos");
            dynamicPanel = new Panel();
            //Panel dynamicPanel = new Panel() ;
            dynamicPanel.Location = new System.Drawing.Point(250, 370);
            dynamicPanel.Name = "Panel1";
            dynamicPanel.Size = new System.Drawing.Size(228, 255);
            dynamicPanel.BackColor = Color.LightSkyBlue;

            TextBox textBox1 = new TextBox();
            textBox1.Location = new Point(10, 10);
            textBox1.Text = "Nombre de la interfaz";
            //textBox1.MouseEnter += new System.EventHandler(this.Buttons_MouseEnter);
            textBox1.Size = new Size(200, 30);
            dynamicPanel.Controls.Add(textBox1);
            //CONTROLS[0]



            CheckBox checkBox1 = new CheckBox();
            checkBox1.Location = new Point(10, 235);
            checkBox1.Text = "Check Me";
            checkBox1.Size = new Size(200, 20);
            checkBox1.UseVisualStyleBackColor = true;
            //Utilizado para validar que el check este en visto no 
            // checkBox1.Checked = false;
            checkBox1.CheckedChanged += new System.EventHandler(CheckBox_CheckedChanged);
            //checkBox1.Checked = false;
            dynamicPanel.Controls.Add(checkBox1);

            //CONSTROLS [1]

            RichTextBox rich2 = new RichTextBox();
            rich2.Location = new Point(10, 180);
            rich2.Text = "Metodos";
            rich2.Size = new Size(200, 50);
            //MessageBox.Show(textBox1.Text);
            // CONTROLS[2]
            dynamicPanel.Controls.Add(rich2);
            //Agrego A la lista de paneles lo que yo creee 
            // listaPaneles.Add(dynamicPanel);



            canvas.panelMaster.Controls.Add(dynamicPanel);



            canvas.panelMaster.Controls.OfType<Control>().Where(ctr => ctr is Panel).ToList().ForEach(ctr =>
            {

                ctr.MouseDown += Ctr_MouseDown;
                ctr.MouseUp += Ctr_MouseUp;
                ctr.MouseMove += Ctr_MouseMove;
            });



        }
        private void Ctr_MouseMove(object sender, MouseEventArgs e)
        {
            Control ctr = (Control)sender;
            if (down)
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

        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox check = (CheckBox)dynamicPanel.Controls[1];


            if (check.Checked)
            {
                ValidacionInterfaz validarInterfaz = new ValidacionInterfaz(this);
                int res = validarInterfaz.validar();
                switch (res)
                {
                    case 1:
                        MessageBox.Show("La interfaz es válida");
                        check.Enabled = false;
                        break;
                    case 2:
                        MessageBox.Show("El nombre de la interfaz no puede ser un verbo.\n El nombre de una interfaz debe ser una representación de un conjunto de elementos");
                        break;
                    case 3:
                        MessageBox.Show("Los métodos no pueden ser repetidos");
                        break;

                }
            }
        }
    }
}
