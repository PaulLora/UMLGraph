using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UMLGraph.Grupos.Grupo6.Modelo;
using UMLGraph.Grupos.Grupo6.Vista;

namespace UMLGraph.Grupos.Grupo6.Vista
{
    public class PantallaTrabajoGr6
    {
        bool down = false;
        //inicial es para definir el punto donde esta el mouse cuando hace click
        Point inicial = new Point();
        ///Creacion de Botones
        Button btn_clase = new Button();
        Button btn_relacion = new Button();
        ///Creacion de paneles
        Panel pnl_herramienta = new Panel();
        Panel pnl_areaTrabajo = new Panel();
        Panel pnl_aux = new Panel();
        ///Lista para guardar clase
        List<Clase> clases = new List<Clase>();
        List<Relacion> relaciones = new List<Relacion>();

        public PantallaTrabajoGr6 (Panel panel)
        {
            this.pnl_aux = panel;

            //Configuracion boton clase
            this.btn_clase.Location = new System.Drawing.Point(1, 3);
            this.btn_clase.Name = "btn_clase";
            this.btn_clase.Size = new System.Drawing.Size(132, 21);
            this.btn_clase.TabIndex = 0;
            this.btn_clase.Text = "Clase";
            this.btn_clase.UseVisualStyleBackColor = true;
            this.btn_clase.Click += new System.EventHandler(this.btn_clase_Click);
            //Configuracion boton relacion
            this.btn_relacion.Location = new System.Drawing.Point(1, 32);
            this.btn_relacion.Name = "btn_relacion";
            this.btn_relacion.Size = new System.Drawing.Size(132, 21);
            this.btn_relacion.TabIndex = 0;
            this.btn_relacion.Text = "Relación";
            this.btn_relacion.UseVisualStyleBackColor = true;
            this.btn_relacion.Click += new System.EventHandler(this.btn_relacion_Click);
            //configuracion panel herramientas
            this.pnl_herramienta.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)| System.Windows.Forms.AnchorStyles.Left)));
            this.pnl_herramienta.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pnl_herramienta.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnl_herramienta.Controls.Add(this.btn_clase);
            this.pnl_herramienta.Controls.Add(this.btn_relacion);
            //this.pnl_herramienta.Location = new System.Drawing.Point(2, 131);
            this.pnl_herramienta.Margin = new System.Windows.Forms.Padding(2);
            this.pnl_herramienta.Name = "pnl_herramienta";
            this.pnl_herramienta.Size = new System.Drawing.Size(140, 202);
            this.pnl_herramienta.TabIndex = 14;
            this.pnl_herramienta.Visible = true;
            //configuracion panel area de trabajo
            this.pnl_areaTrabajo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)| System.Windows.Forms.AnchorStyles.Left)));
            this.pnl_areaTrabajo.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pnl_areaTrabajo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnl_areaTrabajo.Location = new System.Drawing.Point(144, 0);
            //this.pnl_areaTrabajo.Margin = new System.Windows.Forms.Padding(2);
            this.pnl_areaTrabajo.Name = "pnl_areaTrabajo";
            this.pnl_areaTrabajo.Size = new System.Drawing.Size(1360, 504);
            panel.Size = new System.Drawing.Size(1360, 635);
            this.pnl_areaTrabajo.Visible = true;
            panel.Location = new System.Drawing.Point(2, 131);
            //this.pnl_areaTrabajo.TabIndex = 14;
            //this.pnl_areaTrabajo.Visible = true;

            this.pnl_aux.Controls.Add(this.pnl_herramienta);
            this.pnl_aux.Controls.Add(this.pnl_areaTrabajo);

            this.actulizarRelaciones();

        }

        public Panel dibujarPnl_areaTrabajo()
        {

            return this.pnl_aux;
        }


        private void btn_clase_Click(object sender, EventArgs e)
        {
            Formulario formularioClase = new Formulario(this);
            ////this.Hide();
            formularioClase.Show();

        }

        public void setDatosClase(String titulo, String atributos, String metodos)
        {
            String id = "Clase" + (clases.Count+1);
            List<String> atributosTemp = new List<string>();
            List<String> metodosTemp = new List<string>();

            String[] atributoSeparar = atributos.Split(',');
            String[] metodoSeparar = metodos.Split(',');

            for (int i = 0; i < atributoSeparar.Length; i++)
            {
                atributosTemp.Add(atributoSeparar[i]);
            }

            for (int i = 0; i < metodoSeparar.Length; i++)
            {
                metodosTemp.Add(metodoSeparar[i]);
            }

            Clase claseTemp = new Clase(this, id,titulo, atributosTemp, metodosTemp);
            claseTemp.crearPanel();
            claseTemp.dibujarFigura(this.pnl_areaTrabajo);
            clases.Add(claseTemp);
            pnl_areaTrabajo.Show();
            this.actulizarRelaciones();
        }
        public object existeClase(String nombreClase)
        {
            Clase claseEncontrada = null;

            foreach (Clase clase in this.clases)
            {
                if (clase.Titulo.Equals(nombreClase))
                {
                    claseEncontrada = clase;
                }
            }
            return claseEncontrada;
        }

        //Accion sobre el boton relacion

        private void btn_relacion_Click(object sender, EventArgs e)
        {
            FormularioRelacion formularioRelacion = new FormularioRelacion(this);
            formularioRelacion.Show();
        }
        public void setDatosRelacion(String nombreRelacion, String tipoRelacion, Object padre, Object hijo)
        {
            MessageBox.Show(nombreRelacion);
            Relacion relacionRecibida = new Relacion(nombreRelacion, tipoRelacion, (Clase)padre, (Clase)hijo);
            relacionRecibida.dibujarFigura(this.pnl_areaTrabajo);
            relaciones.Add(relacionRecibida);

        }
        public void actulizarRelaciones()
        {
            this.pnl_areaTrabajo.CreateGraphics().Clear(Color.Silver);
            foreach (Relacion relacion in this.relaciones)
            {
                //this.Grafico = espaciotrabajo.CreateGraphics();
                relacion.dibujarFigura(this.pnl_areaTrabajo);

            }
        }




    }
}
