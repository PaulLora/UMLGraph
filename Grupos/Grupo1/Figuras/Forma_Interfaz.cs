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
            dynamicPanel.Location = new System.Drawing.Point(250, 370);
            dynamicPanel.Name = "Panel1";
            dynamicPanel.Size = new System.Drawing.Size(150, 205);
            dynamicPanel.BackColor = Color.CadetBlue;

            TextBox textBox1 = new TextBox();
            textBox1.Location = new Point(25, 10);
            textBox1.Text = "Nombre de la interfaz";
            textBox1.Size = new Size(100, 30);
            dynamicPanel.Controls.Add(textBox1);
            //CONTROLS[0]



            CheckBox checkBox1 = new CheckBox();
            checkBox1.Location = new Point(10, 170);
            checkBox1.Text = "Check Me";
            checkBox1.Size = new Size(110, 20);
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += new System.EventHandler(CheckBox_CheckedChanged);

            dynamicPanel.Controls.Add(checkBox1);

            //CONSTROLS [1]



            RichTextBox rich = new RichTextBox();
            rich.Location = new Point(10, 45);
            rich.Text = "";
            rich.Size = new Size(130, 40);
            rich.Enabled = false;
            // CONTROLS[2]
            dynamicPanel.Controls.Add(rich);
            RichTextBox rich2 = new RichTextBox();
            rich2.Location = new Point(10, 100);
            rich2.Text = "Metodos";
            rich2.Size = new Size(130, 50);
            // CONTROLS[3]
            dynamicPanel.Controls.Add(rich2);



            Label numeroClas = new Label();
            numeroClas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            numeroClas.Location = new Point(120, 170);

            numeroClas.Text = "";// + ListaFormas.listaClases.Count();

            numeroClas.Size = new Size(30, 30);
            //agrego el identificador de clase
            dynamicPanel.Controls.Add(numeroClas);
            // CONTROLS[4]

            TextBox textBox2 = new TextBox();
            textBox2.Location = new Point(10, 10);
            // CONTROLS[5]
            textBox2.Text = "<<";
            textBox2.Size = new Size(10, 30);
            textBox2.Enabled = false;

            dynamicPanel.Controls.Add(textBox2);


            TextBox textBox3 = new TextBox();
            textBox3.Location = new Point(130, 10);
            textBox3.Size = new Size(10, 30);
            textBox3.Text = ">>";
            textBox3.Enabled = false;
            // CONTROLS[]
            dynamicPanel.Controls.Add(textBox3);




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


        //VERIFICAR

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
                        // ListaFormas.listaInterfaz.Add(dynamicPanel);
                        //MessageBox.Show("Existe"+Convert.ToString(ListaFormas.listaInterfaz.Count)+" elementos de tipo interfaz");
                        break;
                    default:
                        MessageBox.Show("Corrija los errores ");
                        break;

                }
            }
        }

     }
}
