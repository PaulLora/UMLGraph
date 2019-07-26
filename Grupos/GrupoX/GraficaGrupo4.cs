using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UMLGraph.Grupos.GrupoX.Figuras;

namespace UMLGraph
{
    class GraficaGrupo4
    {

        Button btnClase = new Button();
        Button btnInterfaz = new Button();
        Panel pnlPrincipal = new Panel();

        List<Clase> listaClases = new List<Clase>();
        List<Interfaz> listaInterfaces = new List<Interfaz>();
        public GraficaGrupo4(Panel pnlPrincipal)
        {
            // 
            // btnClase
            // 
            this.pnlPrincipal = pnlPrincipal;
            this.btnClase.Location = new System.Drawing.Point(1, 3);
            this.btnClase.Name = "btnClase";
            this.btnClase.Size = new System.Drawing.Size(132, 21);
            this.btnClase.TabIndex = 0;
            this.btnClase.Text = "ActualizarFiguras clase";
            this.btnClase.UseVisualStyleBackColor = true;
            this.btnClase.Click += new System.EventHandler(this.btnClase_Click);

            // btnInterfaz
            // 
            this.btnInterfaz.Location = new System.Drawing.Point(1, 32);
            this.btnInterfaz.Name = "btnInterfaz";
            this.btnInterfaz.Size = new System.Drawing.Size(132, 21);
            this.btnInterfaz.TabIndex = 4;
            this.btnInterfaz.Text = "ActualizarFiguras interfaz";
            this.btnInterfaz.UseVisualStyleBackColor = true;
            this.btnInterfaz.Click += new System.EventHandler(this.BtnInterfaz_Click);
            // panel1
            // 
            this.pnlPrincipal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlPrincipal.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pnlPrincipal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlPrincipal.Controls.Add(this.btnClase);
            this.pnlPrincipal.Controls.Add(this.btnInterfaz);
            this.pnlPrincipal.Location = new System.Drawing.Point(5, 130);
            this.pnlPrincipal.Margin = new System.Windows.Forms.Padding(2);
            this.pnlPrincipal.Name = "pnlPrincipal";
            this.pnlPrincipal.Size = new System.Drawing.Size(1200, 600);
            this.pnlPrincipal.TabIndex = 14;
            this.pnlPrincipal.Visible = true;

        }
        public Panel dibujar()
        {
            return this.pnlPrincipal;
        }
        private void btnClase_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Recuerda que el nombre de las clases es en singular.\n" +
                   "Fíjate que los atributos y métodos correspondan a la clase");
            //Codigo original dle programa se activara si el elemento seleccionado es GR4

            //Se añade una nueva clase a la lista
            listaClases.Add(new Clase(160, 120));

            //Aqui se añade el panel de la clase a los controles del Form
            this.pnlPrincipal.Controls.Add(listaClases.Last().getCaja());


            //Este paso es para que el picture box se pueda mover arrastrando con el mouse
            listaClases.Last().getCaja().MouseDown += Ctr_MouseDown;
            listaClases.Last().getCaja().MouseUp += Ctr_MouseUp;
            listaClases.Last().getCaja().MouseMove += Ctr_MouseMove;

        }
        private void BtnInterfaz_Click(object sender, EventArgs e)
        {
            //Se añade una nueva clase a la lista
            listaInterfaces.Add(new Interfaz(160, 120));

            //Aqui se añade el panel de la clase a los controles del Form
            this.pnlPrincipal.Controls.Add(listaInterfaces.Last().getCaja());


            //Este paso es para que el picture box se pueda mover arrastrando con el mouse
            listaInterfaces.Last().getCaja().MouseDown += Ctr_MouseDown;
            listaInterfaces.Last().getCaja().MouseUp += Ctr_MouseUp;
            listaInterfaces.Last().getCaja().MouseMove += Ctr_MouseMove;

        }
        private void Ctr_MouseUp(object sender, MouseEventArgs e) => down = false;

        List<Point> lista = new List<Point>();
        private void Ctr_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                down = true;
                inicial = e.Location;
            }
        }

        bool down = false;
        //inicial es para definir el punto donde esta el mouse cuando hace click
        Point inicial;

        //Todo lo que tenga Mouse es para mover las figuras
        private void Ctr_MouseMove(object sender, MouseEventArgs e)
        {
            Control ctr = (Control)sender;

            //Si down es true se esta clickeando el mouse, ademas se verifica que no se pueda arrastrar la figura mas alla del espacio permitido
            if (down
                && e.X + ctr.Left - inicial.X >= 0
                && e.Y + ctr.Top - inicial.Y >= 0)
            {
                ctr.Left = e.X + ctr.Left - inicial.X;
                ctr.Top = e.Y + ctr.Top - inicial.Y;
            }
        }

    }
}


