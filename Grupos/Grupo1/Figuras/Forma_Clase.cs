using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace UMLGraph
{
    class Forma_Clase:Forma
    {


        bool down = false;
        Point inicial;
        List<Panel> listaPaneles = new List<Panel>(); //Un alista de paneles es una lista de clases
        String hola = "";
        public Panel dynamicPanel;
        Canvas limpiar;
        public Forma_Clase()
        {


        }

        public void dibujar(Canvas canvas)
        {
            dynamicPanel = new Panel();
            //Panel dynamicPanel = new Panel() ;
            dynamicPanel.Location = new System.Drawing.Point(250, 370);
            dynamicPanel.Name = "Panel1";
            dynamicPanel.Size = new System.Drawing.Size(228, 255);
            dynamicPanel.BackColor = Color.LightSkyBlue;

            TextBox textBox1 = new TextBox();
            textBox1.Location = new Point(10, 10);
            textBox1.Text = "Nombre de la clase";
            //textBox1.MouseEnter += new System.EventHandler(this.Buttons_MouseEnter);
            textBox1.Size = new Size(200, 30);
            dynamicPanel.Controls.Add(textBox1);
            //dynamicPanel.Controls.ContainsKey("textBox1");
            //CONTROL 0

            CheckBox checkBox1 = new CheckBox();
            checkBox1.Location = new Point(10, 235);
            checkBox1.Text = "Check Me";
            checkBox1.Size = new Size(180, 20);
            checkBox1.UseVisualStyleBackColor = true;
            //Utilizado para validar que el check este en visto no 
            // checkBox1.Checked = false;
            checkBox1.CheckedChanged += new System.EventHandler(CheckBox_CheckedChanged);
            //checkBox1.Checked = false;
            dynamicPanel.Controls.Add(checkBox1);
            //CONTROL 1
            RichTextBox rich = new RichTextBox();
            rich.Location = new Point(10, 50);
            rich.Text = "Atributos";
            rich.Size = new Size(200, 120);
            dynamicPanel.Controls.Add(rich);
            //CONTROL 2
            RichTextBox rich2 = new RichTextBox();
            rich2.Location = new Point(10, 180);
            rich2.Text = "Metodos";
            rich2.Size = new Size(200, 50);
            dynamicPanel.Controls.Add(rich2);
            //Agrego A la lista de paneles la clase creada
            listaPaneles.Add(dynamicPanel);
            //Servira para identifivcar la clase
            Label numeroClas = new Label();
            numeroClas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            numeroClas.Location = new Point(200, 235);
            numeroClas.Text = "" + listaPaneles.Count();
            numeroClas.Size = new Size(200, 20);
            //agrego el identificador de clase
            dynamicPanel.Controls.Add(numeroClas);
            //  MessageBox.Show("" + listaPaneles.Count());
            canvas.panelMaster.Controls.Add(dynamicPanel);
            limpiar = canvas;
            canvas.panelMaster.Controls.OfType<Control>().Where(ctr => ctr is Panel).ToList().ForEach(ctr =>
            {

                ctr.MouseDown += Ctr_MouseDown;
                ctr.MouseUp += Ctr_MouseUp;
                ctr.MouseMove += Ctr_MouseMove;
            });



        }




        //CUANDO PIDE LA REVISIÓN LLAMA A LA CLASE VALIDACION CLASE

        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            TextBox tex = (TextBox)dynamicPanel.Controls[0];
            CheckBox check = (CheckBox)dynamicPanel.Controls[1];
            RichTextBox rich = (RichTextBox)dynamicPanel.Controls[2];
            RichTextBox rich1 = (RichTextBox)dynamicPanel.Controls[3];
            if (check.Checked)
            {
                ValidacionClase validacion = new ValidacionClase(this);
                int res = validacion.validar();
                switch (res)
                {
                    case 1:
                        MessageBox.Show("La clase es válida");
                        //La idea sería que si la clase es válida se bloquee el check box o se pinte el panel de otro color
                        //ListaFormas.listaClases.Add(dynamicPanel);
                        ListaFormas.listaClases.Add(dynamicPanel);
                        int tamaño = ListaFormas.listaClases.Count();
                        MessageBox.Show("En la lista de clases existe:" + Convert.ToString(tamaño) + " elementos");
                        //tex.Enabled = false;
                        //rich.Enabled = false;
                        //rich1.Enabled = false;
                        check.Enabled = false;
                        break;
                    case 2:
                        MessageBox.Show("El nombre no puede ser un verbo");
                        check.Checked = false;
                        break;
                    case 3:
                        MessageBox.Show("Los atributos y metodos no pueden ser iguales");
                        check.Checked = false;
                        break;
                    case 4:
                        MessageBox.Show("Por lo general, los metodos son verbos, asegúrese de escribir un verbo ");
                        check.Checked = false;
                        break;
                }
            }

        }

        /*
        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {

            CheckBox check = (CheckBox)dynamicPanel.Controls[1];
            //Si le da clic en chek valida esto retorna un true o un false dependiendo de lo que use 
            //CheckBox hola2 = (CheckBox)listaPaneles[0].Controls[2];
            //.Controls[1].Text;

             if (check.Checked)
              {
                List<string> atributos = obtenerAtributos();

                foreach (string element in atributos)
                {
                   
                    MessageBox.Show("Los atributos son:"+element);
                }
                List<string> metodos = ObtenerMetodos();
                foreach (string element in metodos)
                {

                    MessageBox.Show("Los metodos son:" + element);
                }


                // string nombre = dynamicPanel.Controls[0].Select(x => x.Text).ToString();

                TextBox nombre = (TextBox)dynamicPanel.Controls[0];
                string nombreClase = nombre.Text;
                MessageBox.Show("El nombre de la clase es"+nombreClase);
                int res = new ValidacionClase().validar(nombreClase, atributos, metodos);
                switch (res)
                {
                    case 1:
                        MessageBox.Show("La clase es válida");
                        //La idea sería que si la clase es válida se bloquee el check box o se pinte el panel de otro color
                        //ListaFormas.listaClases.Add(dynamicPanel);
                        ListaFormas.listaClases.Add(dynamicPanel);
                        int tamaño=ListaFormas.listaClases.Count();
                        MessageBox.Show("En la lista de clases existe:"+Convert.ToString(tamaño)+" elementos");
                        check.Enabled=false;


                        break;
                    case 2:
                        MessageBox.Show("El nombre no puede ser un verbo");

                        break;
                    case 3:
                        MessageBox.Show("Los atributos y metodos no pueden ser iguales");
                        break;
                    case 4:
                        MessageBox.Show("Por lo general, los metodos son verbos, asegúrese de escribir un verbo ");
                        break;



                }



            }
           


           



        }*/
        /// <summary>
        /// Muy bien ahora empezomos con la creacion la verificacion 
        /// enviar hacer la valicacion 
        /// </summary>
        /// <param name="Text"></param>
        /// 


        //CONTROLES PARA MOVER EL PANEL

        private void Ctr_MouseMove(object sender, MouseEventArgs e)
        {
            Control ctr = (Control)sender;
            if (down)
            {
                ctr.Left = e.X + ctr.Left - inicial.X;
                ctr.Top = e.Y + ctr.Top - inicial.Y;
                // limpiar.Refresh();
            }
        }

        private void Ctr_MouseUp(object sender, MouseEventArgs e) => down = false;

        private void Ctr_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                down = true;
                inicial = e.Location;
                limpiar.Refresh();
            }
        }



        //MÉTODO PARA OBTENER LOS METODOS DEL RICHBOX
        public List<String> ObtenerMetodos()
        {
            List<String> cadena = new List<String>();

            String CosasRich = dynamicPanel.Controls[3].Text;
            String[] cortes = CosasRich.Split('\n');

            for (int i = 0; i < cortes.Length; i++)
            {
                cadena.Add(cortes[i]);
            }
            return cadena;


        }

        //METODO PARA OBTENER LOS ATRIBUTOS DEL RICHBOX
        public List<string> obtenerAtributos()
        {
            List<String> cadena = new List<String>();

            String CosasRich = dynamicPanel.Controls[2].Text;
            String[] cortes = CosasRich.Split('\n');
            for (int i = 0; i < cortes.Length; i++)
            {
                cadena.Add(cortes[i]);


            }
            return cadena;

        }
        public List<Panel> ListaDeClase()
        {
            //  MessageBox.Show(listaPaneles[0].Controls[0].Text);

            return listaPaneles;
        }


    }
}
