using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UMLGraph.Grupos.GrupoX.Figuras;
using UMLGraph.Grupos.GrupoX;

namespace UMLGraph
{
    public class GraficaGrupo4
    {

        Button btnClase = new Button();
        Button btnInterfaz = new Button();
        Button btnRelacion = new Button();
        Button btnHerencia = new Button();
        Button btnDependencia = new Button();
        Button btnComposicion = new Button();
        Button btnAgregacion = new Button();
        Panel pnlPrincipal = new Panel();

        int contadorClases = 1;
        int contadorInterfaces = 1;
        List<Clase> listaClases = new List<Clase>();
        List<Interfaz> listaInterfaces = new List<Interfaz>();
        List<Relacion> listaRelaciones = new List<Relacion>();
        List<Herencia> listaHerencias = new List<Herencia>();
        List<Dependencia> listaDependencias = new List<Dependencia>();
        List<Composicion> listaComposiciones = new List<Composicion>();
        List<Agregacion> listaAgregaciones = new List<Agregacion>();
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
            this.btnClase.Text = "Dibujar clase";
            this.btnClase.UseVisualStyleBackColor = true;
            this.btnClase.Click += new System.EventHandler(this.btnClase_Click);
            //
            // btnInterfaz
            // 
            this.btnInterfaz.Location = new System.Drawing.Point(1, 32);
            this.btnInterfaz.Name = "btnInterfaz";
            this.btnInterfaz.Size = new System.Drawing.Size(132, 21);
            this.btnInterfaz.TabIndex = 1;
            this.btnInterfaz.Text = "Dibujar interfaz";
            this.btnInterfaz.UseVisualStyleBackColor = true;
            this.btnInterfaz.Click += new System.EventHandler(this.BtnInterfaz_Click);
            // 
            // btnRelacion
            // 
            this.btnRelacion.Location = new System.Drawing.Point(1, 61);
            this.btnRelacion.Name = "btnRelacion";
            this.btnRelacion.Size = new System.Drawing.Size(132, 21);
            this.btnRelacion.TabIndex = 2;
            this.btnRelacion.Text = "Dibujar relacion";
            this.btnRelacion.UseVisualStyleBackColor = true;
            this.btnRelacion.Click += new System.EventHandler(this.btnRelacion_Click);
            // 
            // btnHerencia
            // 
            this.btnHerencia.Location = new System.Drawing.Point(1, 90);
            this.btnHerencia.Name = "btnHerencia";
            this.btnHerencia.Size = new System.Drawing.Size(132, 21);
            this.btnHerencia.TabIndex = 3;
            this.btnHerencia.Text = "Dibujar herencia";
            this.btnHerencia.UseVisualStyleBackColor = true;
            this.btnHerencia.Click += new System.EventHandler(this.btnHerencia_Click);
            //            
            // btnDependencia
            // 
            this.btnDependencia.Location = new System.Drawing.Point(1, 119);
            this.btnDependencia.Name = "btnDependencia";
            this.btnDependencia.Size = new System.Drawing.Size(132, 21);
            this.btnDependencia.TabIndex = 4;
            this.btnDependencia.Text = "Dibujar dependencia";
            this.btnDependencia.UseVisualStyleBackColor = true;
            this.btnDependencia.Click += new System.EventHandler(this.btnDependencia_Click);
            //
            // btnComposicion
            // 
            this.btnComposicion.Location = new System.Drawing.Point(1, 148);
            this.btnComposicion.Name = "btnComposicion";
            this.btnComposicion.Size = new System.Drawing.Size(132, 21);
            this.btnComposicion.TabIndex = 4;
            this.btnComposicion.Text = "Dibujar composicion";
            this.btnComposicion.UseVisualStyleBackColor = true;
            this.btnComposicion.Click += new System.EventHandler(this.btnComposicion_Click);
            //
            // btnAgregacion
            // 
            this.btnAgregacion.Location = new System.Drawing.Point(1, 177);
            this.btnAgregacion.Name = "btnAgregacion";
            this.btnAgregacion.Size = new System.Drawing.Size(132, 21);
            this.btnAgregacion.TabIndex = 4;
            this.btnAgregacion.Text = "Dibujar agregacion";
            this.btnAgregacion.UseVisualStyleBackColor = true;
            this.btnAgregacion.Click += new System.EventHandler(this.btnAgregacion_Click);
            //
            // panel1
            // 
            this.pnlPrincipal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlPrincipal.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pnlPrincipal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlPrincipal.Controls.Add(this.btnClase);
            this.pnlPrincipal.Controls.Add(this.btnInterfaz);
            this.pnlPrincipal.Controls.Add(this.btnRelacion);
            this.pnlPrincipal.Controls.Add(this.btnHerencia);
            this.pnlPrincipal.Controls.Add(this.btnDependencia);
            this.pnlPrincipal.Controls.Add(this.btnComposicion);
            this.pnlPrincipal.Controls.Add(this.btnAgregacion);
            this.pnlPrincipal.Location = new System.Drawing.Point(5, 130);
            this.pnlPrincipal.Margin = new System.Windows.Forms.Padding(2);
            this.pnlPrincipal.Name = "pnlPrincipal";
            this.pnlPrincipal.Size = new System.Drawing.Size(1200, 600);
            this.pnlPrincipal.TabIndex = 5;
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
            listaClases.Add(new Clase(160, 180, "C" + this.contadorClases));
            contadorClases++;

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
            listaInterfaces.Add(new Interfaz(160, 150, "I" + this.contadorInterfaces));
            contadorInterfaces++;

            //Aqui se añade el panel de la clase a los controles del Form
            this.pnlPrincipal.Controls.Add(listaInterfaces.Last().getCaja());


            //Este paso es para que el picture box se pueda mover arrastrando con el mouse
            listaInterfaces.Last().getCaja().MouseDown += Ctr_MouseDown;
            listaInterfaces.Last().getCaja().MouseUp += Ctr_MouseUp;
            listaInterfaces.Last().getCaja().MouseMove += Ctr_MouseMove;

        }
        private void btnRelacion_Click(object sender, EventArgs e)
        {
            new InsertarRelacion(this.listaClases, this.listaInterfaces, this).ShowDialog();
        }
        private void btnHerencia_Click(object sender, EventArgs e)
        {
            new InsertarHerencia(this.listaClases, this.listaInterfaces, this).ShowDialog();
        }
        private void btnDependencia_Click(object sender, EventArgs e)
        {
            new InsertarDependencia(this.listaClases, this.listaInterfaces, this).ShowDialog();
        }
        private void btnComposicion_Click(object sender, EventArgs e)
        {
            new InsertarComposicion(this.listaClases, this.listaInterfaces, this).ShowDialog();
        }
        private void btnAgregacion_Click(object sender, EventArgs e)
        {
            new InsertarAgregacion(this.listaClases, this.listaInterfaces, this).ShowDialog();
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
            if (down)
            {
                ctr.Left = e.X + ctr.Left - inicial.X;
                ctr.Top = e.Y + ctr.Top - inicial.Y;
                if ((listaRelaciones.Count() + listaHerencias.Count() + listaDependencias.Count() + listaComposiciones.Count() + listaAgregaciones.Count()) > 0)
                {
                    pnlPrincipal.Refresh();
                    for (int i = 0; i < (listaRelaciones.Count() + listaHerencias.Count() + listaDependencias.Count() + listaComposiciones.Count() + listaAgregaciones.Count()); i++)
                    {
                        if (listaRelaciones.Count() >= 1 && i < listaRelaciones.Count())
                        {
                            listaRelaciones[i].dibujar();
                        }
                        if (listaHerencias.Count() >= 1 && i < listaHerencias.Count())
                        {
                            listaHerencias[i].dibujar();
                        }
                        if (listaDependencias.Count() >= 1 && i < listaDependencias.Count())
                        {
                            listaDependencias[i].dibujar();
                        }
                        if (listaComposiciones.Count() >= 1 && i < listaComposiciones.Count())
                        {
                            listaComposiciones[i].dibujar();
                        }
                        if (listaAgregaciones.Count() >= 1 && i < listaAgregaciones.Count())
                        {
                            listaAgregaciones[i].dibujar();
                        }
                    }
                }
            }
        }
        public void agregarRelacion(Clase clase1, Clase clase2)
        {

            this.listaRelaciones.Add(new Relacion(clase1, clase2, this.pnlPrincipal));
            this.listaRelaciones.Last().dibujar();
        }
        public void agregarHerencia(Clase hijo, Clase padre)
        {

            this.listaHerencias.Add(new Herencia(hijo, padre, this.pnlPrincipal));
            this.listaHerencias.Last().dibujar();
        }
        public void agregarDependencia(Clase dependiente, Clase independiente)
        {

            this.listaDependencias.Add(new Dependencia(dependiente, independiente, this.pnlPrincipal));
            this.listaDependencias.Last().dibujar();
        }
        public void agregarComposicion(Clase parte, Clase todo)
        {

            this.listaComposiciones.Add(new Composicion(parte, todo, this.pnlPrincipal));
            this.listaComposiciones.Last().dibujar();
        }
        public void agregarAgregacion(Clase parte, Clase todo)
        {

            this.listaAgregaciones.Add(new Agregacion(parte, todo, this.pnlPrincipal));
            this.listaAgregaciones.Last().dibujar();
        }
    }
}


