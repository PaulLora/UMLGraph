using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UMLGraph.Grupos.Grupo5.Figuras;

namespace UMLGraph.Grupos.Grupo5.Vista
{
   public class GraficaGrupo5
    {
        public String nombre;
        public String atributos;
        public String metodos;
        public String nClase1, nClase2;
        List<Asociacion5> Acoleccion;
        List<Asociacion5> Acont;
        List< Clase5> Ccoleccion;
        List<Generalizacion5> Gcoleccion;
        List<ClaseInterface5> IcColeccion;
        Asociacion5 Aselec, objaso;
        Clase5 Cselec, objcla;
        ClaseInterface5 Icselect, objicla;
        Point pos;
        Graphics g;
        Validar va = new Validar();
        List<Asociacion5> AuxAcoleccion;
        List<Generalizacion5> AuxGcoleccion;
        ToolSelec toolselec;

     
        bool clic;
        public enum ToolSelec
        {
            puntero, asociacion, clase, generalizacion,interfaz,linInterfaz
        }
        
        ToolStrip ToolHerramientas = new ToolStrip();
        PictureBox AreaDraw = new PictureBox();
        PictureBox AreaDraw1 = new PictureBox();
        ToolStripButton toolNuevo = new ToolStripButton();
        ToolStripSeparator toolSep1 = new ToolStripSeparator();
        ToolStripButton toolAbrir = new ToolStripButton();
        ToolStripSeparator toolSep2 = new ToolStripSeparator();
        ToolStripButton toolGuardar = new ToolStripButton();
        ToolStripSeparator toolSep3 = new System.Windows.Forms.ToolStripSeparator();
        ToolStripButton toolPuntero = new System.Windows.Forms.ToolStripButton();
        ToolStripSeparator toolSep4 = new System.Windows.Forms.ToolStripSeparator();
        ToolStripButton toolClase = new System.Windows.Forms.ToolStripButton();
        ToolStripSeparator toolSep5 = new System.Windows.Forms.ToolStripSeparator();
        ToolStripButton toolAsociacion = new System.Windows.Forms.ToolStripButton();
        ToolStripSeparator toolSep6 = new System.Windows.Forms.ToolStripSeparator();
        ToolStripButton toolGeneralizacion = new System.Windows.Forms.ToolStripButton();
        ToolStripSeparator toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
        ToolStripButton toolInterfaz = new System.Windows.Forms.ToolStripButton();
        ToolStripSeparator toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
        ToolStripButton toolLinterfaz = new System.Windows.Forms.ToolStripButton();
        ToolStripSeparator toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
        ToolStripLabel lblNotificacion = new System.Windows.Forms.ToolStripLabel();


        public GraficaGrupo5(Panel pnlPrincipal)
        {
            clic = false;
            Aselec = null;
            Cselec = null;
            Icselect = null;
            objcla = new Clase5();
            objicla = new ClaseInterface5();
            Acoleccion = new List<Asociacion5>();
            Acont = new List<Asociacion5>();
            Ccoleccion = new List<Clase5>();
            IcColeccion = new List<ClaseInterface5>();

            AuxAcoleccion = new List<Asociacion5>();
            AuxGcoleccion = new List<Generalizacion5>();
            Gcoleccion = new List<Generalizacion5>();
            toolselec = ToolSelec.puntero;
            toolPuntero.Checked = true;
            toolAsociacion.Checked = false;
            toolClase.Checked = false;
            g = AreaDraw.CreateGraphics();
            #region DiseñoGr5
            // 
            // AreaDraw
            // 

            pnlPrincipal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.AreaDraw.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.AreaDraw.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AreaDraw.Location = new System.Drawing.Point(0, 0);
            this.AreaDraw.Name = "AreaDraw";
            this.AreaDraw.Size = new System.Drawing.Size(1360, 635);
            this.AreaDraw.TabIndex = 3;
            this.AreaDraw.TabStop = false;
           
            //this.AreaDraw.Click += new System.EventHandler(this.AreaDraw_Click);
            this.AreaDraw.Paint += new System.Windows.Forms.PaintEventHandler(this.AreaDraw_Paint);
            this.AreaDraw.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AreaDraw_MouseDown);
            this.AreaDraw.MouseMove += new System.Windows.Forms.MouseEventHandler(this.AreaDraw_MouseMove);
            this.AreaDraw.MouseUp += new System.Windows.Forms.MouseEventHandler(this.AreaDraw_MouseUp);
            pnlPrincipal.Size = new System.Drawing.Size(1360, 635);
            pnlPrincipal.Location = new System.Drawing.Point(2, 131);

           
            // 
            // ToolHerramientas
            // 
            this.ToolHerramientas.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolNuevo,
            this.toolSep1,
            //this.toolAbrir,
            this.toolSep2,
           // this.toolGuardar,
            this.toolSep3,
            this.toolPuntero,
            this.toolSep4,
            this.toolClase,
            this.toolSep5,
            this.toolAsociacion,
            this.toolSep6,
            this.toolGeneralizacion,
            this.toolStripSeparator2,
            this.toolInterfaz,
            this.toolStripSeparator1,            
           this.toolLinterfaz,this.toolStripSeparator1,
            this.lblNotificacion,});
            this.ToolHerramientas.Location = new System.Drawing.Point(2, 131);
            this.ToolHerramientas.Name = "ToolHerramientas";
            this.ToolHerramientas.Size = new System.Drawing.Size(751, 25);
            this.ToolHerramientas.TabIndex = 2;
            this.ToolHerramientas.Text = "toolStrip1";
            
            // 
            // 
            // toolNuevo
            // 
            this.toolNuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolNuevo.Image = global::UMLGraph.Properties.Resources.nuevo;
            this.toolNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolNuevo.Name = "toolNuevo";
            this.toolNuevo.Size = new System.Drawing.Size(23, 22);
            this.toolNuevo.Text = "Nuevo";
            this.toolNuevo.Click += new System.EventHandler(this.toolNuevo_Click);
            // 
            // toolSep1
            // 
            this.toolSep1.Name = "toolSep1";
            this.toolSep1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolAbrir
            // 
            //this.toolAbrir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            //this.toolAbrir.Image = global::UMLGraph.Properties.Resources.abrir;
            //this.toolAbrir.ImageTransparentColor = System.Drawing.Color.Magenta;
            //this.toolAbrir.Name = "toolAbrir";
            //this.toolAbrir.Size = new System.Drawing.Size(23, 22);
            //this.toolAbrir.Text = "Abrir";
            // 
            // toolSep2
            // 
            this.toolSep2.Name = "toolSep2";
            this.toolSep2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolGuardar
            // 
            //this.toolGuardar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            //this.toolGuardar.Image = global::UMLGraph.Properties.Resources.guardar;
            //this.toolGuardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            //this.toolGuardar.Name = "toolGuardar";
            //this.toolGuardar.Size = new System.Drawing.Size(23, 22);
            //this.toolGuardar.Text = "Guardar";
            // 
            // toolSep3
            // 
            this.toolSep3.Name = "toolSep3";
            this.toolSep3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolPuntero
            // 
            this.toolPuntero.CheckOnClick = true;
            this.toolPuntero.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolPuntero.Image = global::UMLGraph.Properties.Resources.puntero;

            this.toolPuntero.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolPuntero.Name = "toolPuntero";
            this.toolPuntero.Size = new System.Drawing.Size(23, 22);
            this.toolPuntero.Text = "Puntero";
            this.toolPuntero.Click += new System.EventHandler(this.toolPuntero_Click);
            // 
            // toolSep4
            // 
            this.toolSep4.Name = "toolSep4";
            this.toolSep4.Size = new System.Drawing.Size(6, 25);
            // 
            // toolClase
            // 
            this.toolClase.CheckOnClick = true;
            this.toolClase.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolClase.Image = global::UMLGraph.Properties.Resources.Clase1;
            this.toolClase.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolClase.Name = "toolClase";
            this.toolClase.Size = new System.Drawing.Size(23, 22);
            this.toolClase.Text = "Clase";
            this.toolClase.Click += new System.EventHandler(this.toolClase_Click);
            // 
            // toolSep5
            // 
            this.toolSep5.Name = "toolSep5";
            this.toolSep5.Size = new System.Drawing.Size(6, 25);
            // 
            // toolAsociacion
            // 
            this.toolAsociacion.CheckOnClick = true;
            this.toolAsociacion.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolAsociacion.Image = global::UMLGraph.Properties.Resources.asociacion;
            this.toolAsociacion.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolAsociacion.Name = "toolAsociacion";
            this.toolAsociacion.Size = new System.Drawing.Size(23, 22);
            this.toolAsociacion.Text = "Asociacion";
           this.toolAsociacion.Click += new System.EventHandler(this.toolAsociacion_Click);
            // 
            // toolSep6
            // 
            this.toolSep6.Name = "toolSep6";
            this.toolSep6.Size = new System.Drawing.Size(6, 25);
            // 
            // toolGeneralización
            // 
            this.toolGeneralizacion.CheckOnClick = true;
            this.toolGeneralizacion.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolGeneralizacion.Image = global::UMLGraph.Properties.Resources.Generalización;
            this.toolGeneralizacion.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolGeneralizacion.Name = "toolGeneralizacion";
            this.toolGeneralizacion.Size = new System.Drawing.Size(50, 50);
            this.toolGeneralizacion.Text = "Generalización";
            this.toolGeneralizacion.Click += new System.EventHandler(this.toolGeneralizacion_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton2
            // 
            this.toolInterfaz.CheckOnClick = true;
            this.toolInterfaz.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolInterfaz.Image = global::UMLGraph.Properties.Resources.Cinterfaz;
            this.toolInterfaz.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolInterfaz.Name = "toolInterfaz";
            this.toolInterfaz.Size = new System.Drawing.Size(23, 22);
            this.toolInterfaz.Text = "Interfaz";
           this.toolInterfaz.Click += new System.EventHandler(this.toolInterfaz_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // LINterfas
            this.toolLinterfaz.CheckOnClick = true;
            this.toolLinterfaz.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolLinterfaz.Image = global::UMLGraph.Properties.Resources.Linter;
            this.toolLinterfaz.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolLinterfaz.Name = "toolLInterfaz";
            this.toolLinterfaz.Size = new System.Drawing.Size(23, 22);
            this.toolLinterfaz.Text = "Relacion Interfaz";
            this.toolLinterfaz.Click += new System.EventHandler(this.toolLInterfaz_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);

            //tool lblNotificacion
            this.lblNotificacion.AutoSize = true;
            this.lblNotificacion.Name = "lblNotificacion";
            this.lblNotificacion.Size = new System.Drawing.Size(23, 22);
           
            this.lblNotificacion.Text = "";


            pnlPrincipal.Controls.Add(this.AreaDraw);
            pnlPrincipal.Controls.Add(this.ToolHerramientas);
            #endregion DiseñoGr5


        }

        public GraficaGrupo5(){}

        private void toolPuntero_Click(object sender, EventArgs e)
        {
            toolAsociacion.Checked = false;
            toolClase.Checked = false;
            toolGeneralizacion.Checked = false;
            toolInterfaz.Checked = false;
            toolselec = ToolSelec.puntero;
        }
        private void toolNuevo_Click(object sender, EventArgs e)
        {
            toolAsociacion.Checked = false;
            toolClase.Checked = false;
            toolGeneralizacion.Checked = false;
            toolInterfaz.Checked = false;
            toolselec = ToolSelec.puntero;
            Acoleccion.Clear();
            Ccoleccion.Clear();
            Acont.Clear();
            Gcoleccion.Clear();
            IcColeccion.Clear();
            AreaDraw.Invalidate();
            MessageBox.Show("Creando nueva area de dibujo");

        }

        private void toolAsociacion_Click(object sender, EventArgs e)
        {
           
            nClase1 = "";
            nClase2 = "";
            if(Ccoleccion.Count == 0)
            {
                MessageBox.Show("No existen clases para asociar");
            }else if (Ccoleccion.Count == 1)
            {

                MessageBox.Show("Necesita una clase más para crear asociación");
            }
            else
            {

                Fasociacion frm = new Fasociacion(this);
                va = new Validar();
                frm.ShowDialog();
                Clase5 clase1, clase2;
                clase1 = va.ExisteClase(Ccoleccion, nClase1);
                clase2 = va.ExisteClase(Ccoleccion, nClase2);
                Asociacion5 aux = va.ValidarAsociacion(clase1, clase2);
                if (aux != null)
                {
                    Acoleccion.Add(aux);
                    Acoleccion.Add(aux);
                }

                else
                {
                    MessageBox.Show("Ingrese nombres de clases existentes");
                }
                
                AreaDraw.Invalidate();


            }

            Aselec = null;
            Cselec = null;
            clic = false;
            toolselec = ToolSelec.puntero;
            toolPuntero.Checked = true;
            toolAsociacion.Checked = false;
            toolGeneralizacion.Checked = false;
            toolInterfaz.Checked = false;
            toolClase.Checked = false;
        }

        private void toolClase_Click(object sender, EventArgs e)
        {
            toolPuntero.Checked = false;
            toolAsociacion.Checked = false;
            toolGeneralizacion.Checked = false;
            toolInterfaz.Checked = false;
            toolselec = ToolSelec.clase;
        }
        private void toolGeneralizacion_Click(object sender, EventArgs e)
        {
            toolPuntero.Checked = false;
            toolAsociacion.Checked = false;
            toolClase.Checked = false;
            toolInterfaz.Checked = false;
            toolselec = ToolSelec.generalizacion;
            
        }
        private void toolInterfaz_Click(object sender, EventArgs e)
        {
            toolPuntero.Checked = false;
            toolAsociacion.Checked = false;
            toolClase.Checked = false;
            toolGeneralizacion.Checked = false;
            toolselec = ToolSelec.interfaz;
        }
        private void toolLInterfaz_Click(object sender, EventArgs e)
        {
            toolPuntero.Checked = false;
            toolAsociacion.Checked = false;
            toolClase.Checked = false;
            toolGeneralizacion.Checked = false;
            toolLinterfaz.Checked = false;
            toolselec = ToolSelec.puntero;
           
        }
        private void AreaDraw_MouseDown(object sender, MouseEventArgs e)
        {
            switch (toolselec)
            {
                case ToolSelec.puntero:
                    #region Seleccion Figura
                 
                    foreach (Clase5 item in Ccoleccion)
                    {
                        Point p = AreaDraw.PointToClient(Cursor.Position);
                        if (item.Dentro(p))
                        {
                            Cselec = item;
                            
                            pos = p;
                            break;
                        }
                    }
                    foreach (ClaseInterface5 item in IcColeccion)
                    {
                        Point p = AreaDraw.PointToClient(Cursor.Position);
                        if (item.Dentro(p))
                        {
                            Icselect = item;

                            pos = p;
                            break;
                        }
                    }

                    #endregion
                    break;

                case ToolSelec.generalizacion:
                    //Punto Inicial
                    #region Guarda punto inicial
                    foreach (Clase5 item in Ccoleccion)
                    {
                        Point p = AreaDraw.PointToClient(Cursor.Position);
                        if (Ccoleccion.Count != 0 & item.Dentro(p))
                        {
                            MessageBox.Show("No puede dibujar dentro de una figura.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            toolClase.Checked = false;
                            toolPuntero.Checked = true;
                            toolselec = ToolSelec.puntero;
                            clic = false;
                            goto salir;
                        }

                        clic = true;
                        objcla.puntoInicial = e.Location;
                        objcla.puntoFinal = e.Location;
                    }
                    clic = true;
                    objcla.puntoInicial = e.Location;
                    salir: break;
                    #endregion Guarda punto inicial
                    
                case ToolSelec.clase:
                    //Punto Inicial
                    #region Guarda punto inicial
                    foreach (Clase5 item in Ccoleccion)
                    {
                        Point p = AreaDraw.PointToClient(Cursor.Position);
                        if (Ccoleccion.Count != 0 & item.Dentro(p))
                        {
                            MessageBox.Show("No puede dibujar dentro de una figura.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            toolClase.Checked = false;
                            toolPuntero.Checked = true;
                            toolselec = ToolSelec.puntero;
                            clic = false;
                            goto exit;
                        }

                        clic = true;
                        objcla.puntoInicial = e.Location;
                          objcla.puntoFinal = e.Location;
                    }
                    clic = true;
                    objcla.puntoInicial = e.Location;
                    exit: break;
                #endregion Guarda punto inicial
                case ToolSelec.interfaz:
                    //Punto Inicial
                    #region Guarda punto inicial
                    foreach (ClaseInterface5 item in IcColeccion)
                    {
                        Point p = AreaDraw.PointToClient(Cursor.Position);
                        if (IcColeccion.Count != 0 & item.Dentro(p))
                        {
                            MessageBox.Show("No puede dibujar dentro de una figura.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            toolInterfaz.Checked = false;
                            toolPuntero.Checked = true;
                            toolselec = ToolSelec.puntero;
                            clic = false;
                            goto exitI;
                        }

                        clic = true;
                        objicla.puntoInicial = e.Location;
                        objicla.puntoFinal = e.Location;
                    }
                    clic = true;
                    objicla.puntoInicial = e.Location;
                    exitI: break;
                    #endregion Guarda punto inicial
            }
        }
        private void AreaDraw_MouseMove(object sender, MouseEventArgs e)
        {
            
            switch (toolselec)
            {
                case ToolSelec.puntero:
                    #region Selección Figura
                    
                    
                        if (Cselec != null)
                        {
                            
                           Cselec.Mover(e.Location.X - pos.X, e.Location.Y - pos.Y);
                           AreaDraw.Invalidate();
                           pos = e.Location;
                           objcla.puntoFinal = new Point(e.Location.X , e.Location.Y );

                        }
                        if (Icselect != null)
                        {

                            Icselect.Mover(e.Location.X - pos.X, e.Location.Y - pos.Y);
                            AreaDraw.Invalidate();
                            pos = e.Location;
                            objicla.puntoFinal = new Point(e.Location.X, e.Location.Y);

                        }





                    #endregion
                    break;
              
                case ToolSelec.clase:
                    #region Dibuja Clase


                    if (clic)
                    {

                        g = AreaDraw.CreateGraphics();
                       
                        objcla.puntoFinal = e.Location;
                         g.Clear(SystemColors.ActiveCaption);
                        objcla.MostrarClase(g, objcla.puntoInicial, objcla.puntoFinal);

                    }
                    #endregion
                    break;
                case ToolSelec.generalizacion:
                    #region Dibuja generalizacion


                    if (clic)
                    {
                        g = AreaDraw.CreateGraphics();
                        objcla.puntoFinal = e.Location;
                        g.Clear(SystemColors.ActiveCaption);
                        objcla.MostrarClase(g, objcla.puntoInicial, objcla.puntoFinal);

                    }
                    #endregion
                    break;
                case ToolSelec.interfaz:
                    #region Dibuja interfaz


                    if (clic)
                    {

                        g = AreaDraw.CreateGraphics();

                        objicla.puntoFinal = e.Location;
                        g.Clear(SystemColors.ActiveCaption);
                        objicla.MostrarClase(g, objicla.puntoInicial, objicla.puntoFinal);

                    }
                    #endregion
                    break;
            }
        }

   

        

        private void AreaDraw_MouseUp(object sender, MouseEventArgs e)
        {

            switch (toolselec)
            {
                
                   
                case ToolSelec.clase:
                    #region

                    if (objcla.puntoInicial != new Point(0, 0) && objcla.puntoFinal != new Point(0, 0))
                    {

                       
                        Fclase frm = new Fclase(this);
                        frm.ShowDialog();
                        if("".Equals(nombre)|| "".Equals(atributos)|| "".Equals(metodos)|| nombre ==null || atributos == null || metodos == null|| "Ingrese nombre de la clase".Equals(nombre)|| "Ingrese los atributos de la clase".Equals(atributos)|| "Ingrese los métodos de la clase".Equals(metodos))
                        {
                            MessageBox.Show("No ingreso algun parametro solicitado. Vuelva a interlo");
                        }else if (va.ValidarNombre(nombre))
                        {
                            DialogResult seguro = MessageBox.Show("Una clase es un concepto por lo tanto no puede ser verbo ni plural, Intenta nuevamente", "HELP", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        }
                        else
                        {

                            Clase5 aux = va.ExisteClase(Ccoleccion,nombre);
                            if (aux == null)
                            {
                                Ccoleccion.Add(new Clase5(rectangulosClase(), new Point(objcla.puntoFinal.X, objcla.puntoFinal.Y + 25), nombre, atributos, metodos));
                                lblNotificacion.Text = "Recuerda que todas las clases deben estar relacionadas";
                            }
                            else
                            {
                                MessageBox.Show("Ya existe clase con el nombre: "+nombre);
                            }
                            
                        }

                        AreaDraw.Invalidate();
                        
                       

                    }
                    #endregion
                    break;
                case ToolSelec.generalizacion:
                    #region
                    if (objcla.puntoInicial != new Point(0, 0) && objcla.puntoFinal != new Point(0, 0))
                    {
                        nClase1 = "";
                      

                        Fgeneralizacion frmg = new Fgeneralizacion(this);
                        frmg.ShowDialog();
                        Clase5 clase1,clase2;
                       
                       
                         MessageBox.Show("Recuerda que la clase hijo herada sus atributos y métodos de la clase padre");
                            clase1 = va.ExisteClase(Ccoleccion, nClase1);
                            if (clase1 != null)
                            {
                                
                                Fclase frm = new Fclase(this);
                                frm.ShowDialog();
                            if ("".Equals(nombre) || "Ingrese nombre de la clase".Equals(nombre) || "Ingrese los atributos de la clase".Equals(atributos) || "Ingrese los métodos de la clase".Equals(metodos))
                            {
                                MessageBox.Show("No ingreso algun parametro solicitado. Vuelva a interlo");
                            }
                            else
                            {
                                String nombreHijo = "" + nombre + ":" + nClase1;
                                metodos = " " + metodos + " " + clase1.metodos;
                                atributos = " " + atributos + " " + clase1.atributos;
                                Ccoleccion.Add(new Clase5(rectangulosClase(), new Point(objcla.puntoFinal.X, objcla.puntoFinal.Y + 25), nombreHijo, atributos, metodos));
                                clase2 = va.ExisteClase(Ccoleccion, nombreHijo);

                                Generalizacion5 aux = va.ValidarGeneralizacion(clase1, clase2);
                                Asociacion5 aux1 = va.ValidarAsociacion(clase1, clase2);
                                
                                if (aux != null)
                                {
                                    Gcoleccion.Add(aux);
                                    Acont.Add(aux1);
                                    
                                }

                              }
                                 

                            }
                            else
                            {
                                MessageBox.Show("No se encuentra la clase padre");
                            }



                        AreaDraw.Invalidate();


                    }
                    #endregion
                    break;
                case ToolSelec.interfaz:
                    #region

                    if (objicla.puntoInicial != new Point(0, 0) && objicla.puntoFinal != new Point(0, 0))
                    {
                        Fcinterfaz frm = new Fcinterfaz(this);
                        frm.ShowDialog();
                        if ("".Equals(nombre) || "".Equals(metodos) || nombre == null || metodos == null)
                        {
                            MessageBox.Show("No ingreso algun parametro solicitado. Vuelva a interla");
                        }
                        else
                        {
                            nClase1 = "<< " + nombre + " >>";
                            IcColeccion.Add(new ClaseInterface5(rectangulosInterfaz(), new Point(objicla.puntoFinal.X, objicla.puntoFinal.Y + 25), nClase1, metodos));
                            AreaDraw.Invalidate();
                        }
                        


                    }
                    #endregion
                    break;
                case ToolSelec.puntero:
                    #region puntero
                    if (Cselec != null)
                    {

                       
                        String nombre = Cselec.nombre;
                        Ccoleccion.Add(new Clase5(rectangulosClase(), new Point(objcla.puntoFinal.X, objcla.puntoFinal.Y + 25), Cselec.nombre, Cselec.atributos, Cselec.metodos));
                        Ccoleccion.Remove(Cselec);
                        AuxAcoleccion = new List<Asociacion5>();
                        AuxGcoleccion = new List<Generalizacion5>();
                        for(int i = 0; i < Gcoleccion.Count; i++)
                        {
                            if (Gcoleccion[i].nombre.Equals(Cselec.nombre))
                            {
                                nClase1 = Gcoleccion[i].nombre;
                                nClase2 = Gcoleccion[i].nombre2;
                                Clase5 clase1 = va.ExisteClase(Ccoleccion, nClase1);
                                Clase5 clase2 = va.ExisteClase(Ccoleccion, nClase2);
                                Generalizacion5 aux = va.ValidarGeneralizacion(clase1, clase2);
                                if (aux != null) AuxGcoleccion.Add(aux);


                            }
                            else if (Gcoleccion[i].nombre2.Equals(Cselec.nombre))
                            {
                                nClase1 = Gcoleccion[i].nombre;
                                nClase2 = Gcoleccion[i].nombre2;
                                Clase5 clase1 = va.ExisteClase(Ccoleccion, nClase1);
                                Clase5 clase2 = va.ExisteClase(Ccoleccion, nClase2);
                                Generalizacion5 aux = va.ValidarGeneralizacion(clase1, clase2);
                                if (aux != null) AuxGcoleccion.Add(aux);



                            }
                            else
                            {
                                nClase1 = Gcoleccion[i].nombre;
                                nClase2 = Gcoleccion[i].nombre2;
                                Clase5 clase1 = va.ExisteClase(Ccoleccion, nClase1);
                                Clase5 clase2 = va.ExisteClase(Ccoleccion, nClase2);
                                Generalizacion5 aux = va.ValidarGeneralizacion(clase1, clase2);
                                if (aux != null) AuxGcoleccion.Add(aux);


                            }
                        }
                        for (int i = 0; i < Acoleccion.Count; i++)
                        {
                          
                            if (Acoleccion[i].nombre.Equals(Cselec.nombre))
                            {
                                nClase1 = Acoleccion[i].nombre;
                                nClase2 = Acoleccion[i].nombre2;
                                Clase5 clase1 = va.ExisteClase(Ccoleccion, nClase1);
                                Clase5 clase2 = va.ExisteClase(Ccoleccion, nClase2);
                                Asociacion5 aux = va.ValidarAsociacion(clase1, clase2);
                                if (aux != null) AuxAcoleccion.Add(aux);
                               
                                
                            }
                            else if (Acoleccion[i].nombre2.Equals(Cselec.nombre))
                            {
                                nClase1 = Acoleccion[i].nombre;
                                nClase2 = Acoleccion[i].nombre2;
                                Clase5 clase1 = va.ExisteClase(Ccoleccion, nClase1);
                                Clase5 clase2 = va.ExisteClase(Ccoleccion, nClase2);
                                Asociacion5 aux = va.ValidarAsociacion(clase1, clase2);
                                if (aux != null) AuxAcoleccion.Add(aux);
                              
                            }
                            else
                            {
                                nClase1 = Acoleccion[i].nombre;
                                nClase2 = Acoleccion[i].nombre2;
                                Clase5 clase1 = va.ExisteClase(Ccoleccion, nClase1);
                                Clase5 clase2 = va.ExisteClase(Ccoleccion, nClase2);
                                Asociacion5 aux = va.ValidarAsociacion(clase1, clase2);
                                if (aux!=null) AuxAcoleccion.Add(aux);
                            }
                           
                            AreaDraw.Invalidate();
                        }
                        Acoleccion.Clear();
                        Gcoleccion.Clear();
                        foreach (Asociacion5 item in AuxAcoleccion)
                        {
                            Acoleccion.Add(item);
                        }
                        foreach (Generalizacion5 item in AuxGcoleccion)
                        {
                            Gcoleccion.Add(item);
                        }
                        AreaDraw.Invalidate();
                        
                   

                    }if (Icselect != null)
                    {
                        String nombre = Icselect.nombre;
                        IcColeccion.Add(new ClaseInterface5(rectangulosInterfaz(), new Point(objicla.puntoFinal.X, objicla.puntoFinal.Y + 25), Icselect.nombre, Icselect.metodos));
                        IcColeccion.Remove(Icselect);
                        AreaDraw.Invalidate();
                    }
                    
                       

                    break;
                    #endregion
            }
            //reestrableciendo valores
            nombre = "";
            metodos = "";
            atributos = "";
            Aselec = null;
            Cselec = null;
            Icselect = null;
            clic = false;
            toolselec = ToolSelec.puntero;
            toolPuntero.Checked = true;
            toolAsociacion.Checked = false;
            toolGeneralizacion.Checked = false;
            toolInterfaz.Checked = false;
            toolClase.Checked = false;
        }
      
       

        private void AreaDraw_Paint(object sender, PaintEventArgs e)
        {
            foreach (Asociacion5 item in Acoleccion)
            {
                item.Dibujar(e.Graphics);
            }
            foreach (Clase5 item in Ccoleccion)
            {
                item.Dibujar(e.Graphics);
            }
            foreach (ClaseInterface5 item in IcColeccion)
            {
                item.Dibujar(e.Graphics);
            }
            foreach (Generalizacion5 item in Gcoleccion)
            {
                item.Dibujar(e.Graphics);
            }

        }
        private Rectangle[] rectangulosClase()
        {
            Point puntoMedio = new Point(objcla.puntoFinal.X, objcla.puntoFinal.Y + 30);
            Point puntoFin = new Point(objcla.puntoFinal.X, objcla.puntoFinal.Y + 105);
        
            Rectangle[] rects =
         {

                new Rectangle(objcla.puntoFinal,new Size(150,30)),

                new Rectangle(puntoMedio,new Size(150,75)),

                new Rectangle(puntoFin,new Size(150,100)),


             };
            return rects;
        }
        private Rectangle[] rectangulosInterfaz()
        {
            Point puntoMedio = new Point(objicla.puntoFinal.X, objicla.puntoFinal.Y + 40);
            Point puntoFin = new Point(objicla.puntoFinal.X, objicla.puntoFinal.Y + 60);

            Rectangle[] rects =
               {

                new Rectangle(objicla.puntoFinal,new Size(150,40)),

                new Rectangle(puntoMedio,new Size(150,20)),

                new Rectangle(puntoFin,new Size(150,120)),


             };
            return rects;
        }

    }
}
