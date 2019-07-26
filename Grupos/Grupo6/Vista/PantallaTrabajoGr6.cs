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
        ///Creacion de Botones
        Button btn_clase = new Button();
        Button btn_relacion = new Button();
        Button btn_comprobarModelo = new Button();
        Button btn_eliminar = new Button();
        Button btn_limpiarPanel = new Button();
        ///Creacion de paneles
        Panel pnl_herramienta = new Panel();
        Panel pnl_herramienta1 = new Panel();
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
            //configuracion boton eliminar
            this.btn_eliminar.Location = new System.Drawing.Point(1, 61);
            this.btn_eliminar.Name = "btn_eliminar";
            this.btn_eliminar.Size = new System.Drawing.Size(132, 21);
            this.btn_eliminar.TabIndex = 0;
            this.btn_eliminar.Text = "Eliminar Clase";
            this.btn_eliminar.UseVisualStyleBackColor = true;
            this.btn_eliminar.Enabled = false;
            this.btn_eliminar.Click += new System.EventHandler(this.btn_eliminar_Click);
            //configuracion boton limpiar panel
            this.btn_limpiarPanel.Location = new System.Drawing.Point(1, 90);
            this.btn_limpiarPanel.Name = "btn_limpiarPanel";
            this.btn_limpiarPanel.Size = new System.Drawing.Size(132, 21);
            this.btn_limpiarPanel.TabIndex = 0;
            this.btn_limpiarPanel.Text = "Limpiar Panel";
            this.btn_limpiarPanel.UseVisualStyleBackColor = true;
            this.btn_limpiarPanel.Enabled = false;
            this.btn_limpiarPanel.Click += new System.EventHandler(this.btn_limpiarPanel_Click);
            //Configuracion boton comprobar
            this.btn_comprobarModelo.Location = new System.Drawing.Point(1, 119);
            this.btn_comprobarModelo.Name = "btn_comprobarModelo";
            this.btn_comprobarModelo.Size = new System.Drawing.Size(132, 21);
            this.btn_comprobarModelo.TabIndex = 0;
            this.btn_comprobarModelo.Text = "Comprobar Modelo";
            this.btn_comprobarModelo.ForeColor = Color.White;
            this.btn_comprobarModelo.UseVisualStyleBackColor = true;
            this.btn_comprobarModelo.BackColor = Color.Firebrick;
            this.btn_comprobarModelo.Enabled = false;
            this.btn_comprobarModelo.Click += new System.EventHandler(this.btn_comprobarModelo_Click);

            //configuracion panel herramientas
            this.pnl_herramienta.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)| System.Windows.Forms.AnchorStyles.Left)));
            this.pnl_herramienta.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pnl_herramienta.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnl_herramienta.Controls.Add(this.btn_clase);
            this.pnl_herramienta.Controls.Add(this.btn_relacion);
            this.pnl_herramienta.Controls.Add(this.btn_comprobarModelo);
            this.pnl_herramienta.Controls.Add(this.btn_eliminar);
            this.pnl_herramienta.Controls.Add(this.btn_limpiarPanel);
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
            this.pnl_areaTrabajo.Name = "pnl_areaTrabajo";
            this.pnl_areaTrabajo.Size = new System.Drawing.Size(1360, 630);

            //this.pnl_areaTrabajo.Controls.Add(this.btn_ayuda);
            panel.Size = new System.Drawing.Size(1360, 730);
            this.pnl_areaTrabajo.Visible = true;
            panel.Location = new System.Drawing.Point(2, 131);
            this.pnl_aux.Controls.Add(this.pnl_herramienta);
            this.pnl_aux.Controls.Add(this.pnl_areaTrabajo);
            this.pnl_aux.Controls.Add(this.pnl_herramienta1);
            this.actulizarRelaciones();
        }



        public Panel dibujarPnl_areaTrabajo()
        {
            return this.pnl_aux;
        }

        private void btn_clase_Click(object sender, EventArgs e)
        {
            
            Formulario formularioClase = new Formulario(this);
            formularioClase.Show();
            this.btn_comprobarModelo.Enabled = true;
        }
        public String crearIdClase(int idTemp)
        {

            String id = "Clase" + idTemp;
            foreach (Clase clase in this.clases)
            {
                if (clase.IdClase.Equals(id))
                {
                    id = crearIdClase(idTemp + 1);
                }

            }
            return id;
        }

        public void setDatosClase(String titulo, String atributos, String metodos)
        {
            String id = crearIdClase(1);
            List<String> atributosTemp = new List<String>();
            List<String> metodosTemp = new List<String>();

            String[] atributosSeparados = atributos.Split(',');
            String[] metodosSeparados = metodos.Split(',');

            for (int i = 0; i < atributosSeparados.Length; i++)
            {
                atributosTemp.Add(atributosSeparados[i]);
            }

            for (int i = 0; i < metodosSeparados.Length; i++)
            {
                metodosTemp.Add(metodosSeparados[i]);
            }

            Clase claseTemp = new Clase(this, id, titulo, atributosTemp, metodosTemp);
            claseTemp.crearPanel();
            claseTemp.dibujarFigura(this.pnl_areaTrabajo);
            clases.Add(claseTemp);
            pnl_areaTrabajo.Show();
            this.actulizarRelaciones();
            this.btn_eliminar.Enabled = true;
            this.btn_limpiarPanel.Enabled = true;
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

        public void heredar(String clasePadre, String claseHijo)
        {
            List<String> atributosTemp = new List<String>();
            List<String> metodosTemp = new List<String>();

            foreach (Clase clase in this.clases)
            {
                if (clase.Titulo.Equals(clasePadre))
                {
                    atributosTemp = clase.Atributos;
                    metodosTemp = clase.Metodos;
                    MessageBox.Show(clasePadre);
                }
            }
            foreach (Clase clase in this.clases)
            {
                if (clase.Titulo.Equals(claseHijo))
                {
                    clase.Atributos = atributosTemp;
                    clase.Metodos = metodosTemp;
                }
            }
            actulizarAreaTrabajo();
        }
        public void setActualizarClase(String id, String titulo, String atributos, String metodos)
        {
            List<String> atributosTemp = new List<String>();
            List<String> metodosTemp = new List<String>();
            String[] atributosSeparados = atributos.Split(',');
            String[] metodosSeparados = metodos.Split(',');
            for (int i = 0; i < atributosSeparados.Length; i++)
            {
                atributosTemp.Add(atributosSeparados[i]);
            }

            for (int i = 0; i < metodosSeparados.Length; i++)
            {
                metodosTemp.Add(metodosSeparados[i]);
            }
            foreach (Clase clase in this.clases)
            {
                if (clase.IdClase.Equals(id))
                {
                    clase.Titulo = titulo;
                    clase.Atributos = atributosTemp;
                    clase.Metodos = metodosTemp;
                    clase.crearPanel();
                }
            }
            actulizarAreaTrabajo();
        }
        //accion relacion 
        private void btn_interfaz_Click(object sender, EventArgs e)
        {
           
        }
        //Accion sobre el boton relacion
        private void btn_relacion_Click(object sender, EventArgs e)
        {
            FormularioRelacion formularioRelacion = new FormularioRelacion(this);
            formularioRelacion.Show();
        }

        public void setDatosRelacion(String nombreRelacion, String tipoRelacion, Object padre, Object hijo)
        {
            Clase tempPadre = (Clase)padre;
            Clase tempHijo = (Clase)hijo;

            if (tipoRelacion.Equals("Herencia"))
            {
                foreach (String atributo in tempPadre.Atributos)
                {
                    tempHijo.Atributos.Add(atributo);
                }

                foreach (String metodo in tempPadre.Metodos)
                {
                    tempHijo.Metodos.Add(metodo);
                }
            }
            foreach (Clase clase in this.clases)
            {
                if (clase.IdClase.Equals(tempHijo.IdClase))
                {
                    clase.Atributos = tempHijo.Atributos;
                    clase.Metodos = tempHijo.Metodos;
                    clase.crearPanel();
                }
            }

            Relacion relacionRecibida = new Relacion(nombreRelacion, tipoRelacion, tempPadre, tempHijo);
            relacionRecibida.dibujarFigura(this.pnl_areaTrabajo);
            relaciones.Add(relacionRecibida);
            actulizarAreaTrabajo();
        }
        public void eliminarClaseRelacion(Object claseRecibida)
        {
            Clase claseTemp = (Clase)claseRecibida;
            this.clases.Remove(claseTemp);

            List<Relacion> relacionesAEliminar = new List<Relacion>();

            foreach (Relacion relacion in this.relaciones)
            {
                //MessageBox.Show(relacion.NombreRelacion+"");
                if (claseTemp.Titulo.Equals(relacion.ClasePadre.Titulo))
                {
                    relacionesAEliminar.Add(relacion);
                }
                if (claseTemp.Titulo.Equals(relacion.ClaseHijo.Titulo))
                {
                    relacionesAEliminar.Add(relacion);
                }
            }

            foreach (Relacion relacion in relacionesAEliminar)
            {
                this.relaciones.Remove(relacion);
            }
        }
        private void btn_limpiarPanel_Click(object sender, EventArgs e)
        {
            DialogResult confirmar = MessageBox.Show("Todos los elementos se borrarán ¿Desea continuar?", "confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (confirmar == DialogResult.Yes)
            {
                this.limpiarPanel();
                this.actulizarAreaTrabajo();
            }
        }
        public void limpiarPanel()
        {
            this.clases.Clear();
            this.relaciones.Clear();
        }
        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            EliminarClase eliminar = new EliminarClase(this);
            eliminar.Show();
        }

        //AYUDA 


        private void btn_comprobarModelo_Click(object sender, EventArgs e)
        {
            List<Clase> clasesNoRelacionadas = new List<Clase>();
            bool existeClase = false;
            foreach (Clase clase in this.clases)
            {
                foreach (Relacion relacion in this.relaciones)
                {

                    if (clase.IdClase.Equals(relacion.ClasePadre.IdClase))
                    {
                        existeClase = true;
                    }
                    if (clase.IdClase.Equals(relacion.ClaseHijo.IdClase))
                    {
                        existeClase = true;
                    }
                }

                if (existeClase == false)
                {
                    clasesNoRelacionadas.Add(clase);
                }
                existeClase = false;
            }
            if (!clasesNoRelacionadas.Any())
            {
                MessageBox.Show("El modelo es correcto ");
            }
            else
            {
                String salida = "";
                foreach (Clase clase in clasesNoRelacionadas)
                {
                    salida += "\n" + clase.IdClase;
                }
                MessageBox.Show("Las clases:\n" + salida + "\n\nNo estan relacionadas");
            }
        }

        public void actulizarAreaTrabajo()
        {
            this.pnl_areaTrabajo.Controls.Clear();
            this.pnl_areaTrabajo.CreateGraphics().Clear(System.Drawing.SystemColors.ActiveBorder);
            //this.pnl_areaTrabajo.Controls.Add(this.btn_ayuda);
            //Actualizar clase
            foreach (Clase clase in this.clases)
            {

                clase.dibujarFigura(this.pnl_areaTrabajo);
            }

            foreach (Relacion relacion in this.relaciones)
            {
                relacion.dibujarFigura(this.pnl_areaTrabajo);
            }
        }
        public void actulizarRelaciones()
        {
            this.pnl_areaTrabajo.CreateGraphics().Clear(System.Drawing.SystemColors.ActiveBorder);
            foreach (Relacion relacion in this.relaciones)
            {
                //this.Grafico = espaciotrabajo.CreateGraphics();
                relacion.dibujarFigura(this.pnl_areaTrabajo);

            }
        }
    }
}
