using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace UMLGraph.Grupos.Grupo5
{
   public class GraficaGrupo5
    {
        public String nombre;
        public String atributos;
        public String metodos;
        List<Asociacion5> Acoleccion;
        List<Clase5> Ccoleccion;
        Asociacion5 Aselec, objaso;
        Clase5 Cselec, objcla;
        Point pos;
        Graphics g;
        ToolSelec toolselec;
     
        bool clic;
        public enum ToolSelec
        {
            puntero, asociacion, clase, linea
        }
        ToolStrip ToolHerramientas = new ToolStrip();
        PictureBox AreaDraw = new PictureBox();
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
        ToolStripButton toolStripButton1 = new System.Windows.Forms.ToolStripButton();
        ToolStripSeparator toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
        ToolStripButton toolStripButton2 = new System.Windows.Forms.ToolStripButton();
        ToolStripSeparator toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();


        

        public GraficaGrupo5(Panel pnlPrincipal)
        {
            clic = false;
            Aselec = null;
            Cselec = null;
            objaso = new Asociacion5();
            objcla = new Clase5();
            Acoleccion = new List<Asociacion5>();
            Ccoleccion = new List<Clase5>();
            toolselec = ToolSelec.puntero;
            toolPuntero.Checked = true;
            toolAsociacion.Checked = false;
            toolClase.Checked = false;
            g = AreaDraw.CreateGraphics();
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
            pnlPrincipal.Size = new System.Drawing.Size(1360, 635);
            this.AreaDraw.Click += new System.EventHandler(this.AreaDraw_Click);
            this.AreaDraw.Paint += new System.Windows.Forms.PaintEventHandler(this.AreaDraw_Paint);
            this.AreaDraw.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AreaDraw_MouseDown);
            this.AreaDraw.MouseMove += new System.Windows.Forms.MouseEventHandler(this.AreaDraw_MouseMove);
            this.AreaDraw.MouseUp += new System.Windows.Forms.MouseEventHandler(this.AreaDraw_MouseUp);
            pnlPrincipal.Location = new System.Drawing.Point(2, 131);
            // 
            // ToolHerramientas
            // 
            this.ToolHerramientas.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolNuevo,
            this.toolSep1,
            this.toolAbrir,
            this.toolSep2,
            this.toolGuardar,
            this.toolSep3,
            this.toolPuntero,
            this.toolSep4,
            this.toolClase,
            this.toolSep5,
            this.toolAsociacion,
            this.toolSep6,
            this.toolStripButton1,
            this.toolStripSeparator2,
            this.toolStripButton2,
            this.toolStripSeparator1});
            this.ToolHerramientas.Location = new System.Drawing.Point(2, 131);
            this.ToolHerramientas.Name = "ToolHerramientas";
            this.ToolHerramientas.Size = new System.Drawing.Size(751, 25);
            this.ToolHerramientas.TabIndex = 2;
            this.ToolHerramientas.Text = "toolStrip1";
            this.ToolHerramientas.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.ToolHerramientas_ItemClicked);
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
            // 
            // toolSep1
            // 
            this.toolSep1.Name = "toolSep1";
            this.toolSep1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolAbrir
            // 
            this.toolAbrir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolAbrir.Image = global::UMLGraph.Properties.Resources.abrir;
            this.toolAbrir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolAbrir.Name = "toolAbrir";
            this.toolAbrir.Size = new System.Drawing.Size(23, 22);
            this.toolAbrir.Text = "Abrir";
            // 
            // toolSep2
            // 
            this.toolSep2.Name = "toolSep2";
            this.toolSep2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolGuardar
            // 
            this.toolGuardar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolGuardar.Image = global::UMLGraph.Properties.Resources.guardar;
            this.toolGuardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolGuardar.Name = "toolGuardar";
            this.toolGuardar.Size = new System.Drawing.Size(23, 22);
            this.toolGuardar.Text = "Guardar";
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
            // toolStripButton1
            // 
            this.toolStripButton1.CheckOnClick = true;
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::UMLGraph.Properties.Resources.Composicion3;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "Agregacion";
            this.toolStripButton1.Click += new System.EventHandler(this.ToolStripButton1_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.CheckOnClick = true;
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = global::UMLGraph.Properties.Resources.Composion4;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "Composicion";
           this.toolStripButton2.Click += new System.EventHandler(this.ToolStripButton2_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);


            toolAsociacion.Enabled = false;
         
            pnlPrincipal.Controls.Add(this.AreaDraw);
            pnlPrincipal.Controls.Add(this.ToolHerramientas);



        }

        public GraficaGrupo5(){}

        private void toolPuntero_Click(object sender, EventArgs e)
        {
            toolAsociacion.Checked = false;
            toolClase.Checked = false;
            toolselec = ToolSelec.puntero;
        }

        private void toolAsociacion_Click(object sender, EventArgs e)
        {
            toolPuntero.Checked = false;
            toolClase.Checked = false;
            toolselec = ToolSelec.asociacion;
        }

        private void toolClase_Click(object sender, EventArgs e)
        {
            toolPuntero.Checked = false;
            toolAsociacion.Checked = false;

            toolselec = ToolSelec.clase;
        }
        private void AreaDraw_MouseDown(object sender, MouseEventArgs e)
        {
            switch (toolselec)
            {
                case ToolSelec.puntero:
                    #region Seleccion Figura
                    foreach (Asociacion5 item in Acoleccion)
                    {
                        Point p = AreaDraw.PointToClient(Cursor.Position);
                        if (item.Dentro(p))
                        {
                            Aselec = item;
                            pos = p;
                            break;
                        }
                    }
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
                    #endregion
                    break;
                case ToolSelec.asociacion:
                    //Punto Inicial   
                    #region Guardar punto inicial
                    foreach (Asociacion5 item in Acoleccion)
                    {
                        Point p = AreaDraw.PointToClient(Cursor.Position);
                        if (Acoleccion.Count != 0 & item.Dentro(p))
                        {
                            MessageBox.Show("No puede dibujar dentro de una figura.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            toolAsociacion.Checked = false;
                            toolPuntero.Checked = true;
                            toolselec = ToolSelec.puntero;
                            clic = false;
                            goto salida;
                        }
                        clic = true;
                        objaso.PI = e.Location;
                        objaso.PF = e.Location;
                    }
                    clic = true;
                    objaso.PI = e.Location;

                salida: break;
                #endregion Guardar punto inicial
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
            }
        }
        private void AreaDraw_MouseMove(object sender, MouseEventArgs e)
        {

            switch (toolselec)
            {
                case ToolSelec.puntero:
                    #region Selección Figura

                    if (Aselec != null)
                    {
                        Aselec.Mover(e.Location.X - pos.X, e.Location.Y - pos.Y);
                        AreaDraw.Invalidate();
                        pos = e.Location;
                    }
                    else
                    {
                        if (Cselec != null)
                        {
                            Cselec.Mover(e.Location.X - pos.X, e.Location.Y - pos.Y);
                            AreaDraw.Invalidate();
                            pos = e.Location;
                        }
                    }
                    #endregion
                    break;
                case ToolSelec.asociacion:
                    #region Dibuja asociacion

                    if (clic)
                    {
                        //if el segundo punto esta dentro de, entonces que mande mensaje
                        //y deje de dibujar                        
                       
                        g = AreaDraw.CreateGraphics();
                        objaso.PF = e.Location;
                        g.Clear(Color.White);
                        objaso.DrawAsociacion(g, objaso.PI, objaso.PF);
                    }
                #endregion
                exit: break;
                case ToolSelec.clase:
                    #region Dibuja Clase


                    if (clic)
                    {

                        g = AreaDraw.CreateGraphics();
                        objcla.puntoFinal = e.Location;
                        g.Clear(Color.White);
                        objcla.DrawClase(g, objcla.puntoInicial, objcla.puntoFinal);

                    }
                    #endregion
                    break;
            }
        }

        private void AreaDraw_Click(object sender, EventArgs e)
        {

        }

        private void ToolStripComboBox1_Click(object sender, EventArgs e)
        {

        }

        private void ToolStripButton1_Click(object sender, EventArgs e)
        {
            toolPuntero.Checked = false;
            toolClase.Checked = false;
            toolselec = ToolSelec.asociacion;
        }

        private void ToolStripButton2_Click(object sender, EventArgs e)
        {
            toolPuntero.Checked = false;
            toolClase.Checked = false;
            toolselec = ToolSelec.asociacion;
        }

        private void ToolHerramientas_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void AreaDraw_MouseUp(object sender, MouseEventArgs e)
        {

            switch (toolselec)
            {
                case ToolSelec.asociacion:
                    #region 
                    //


                    //

                    if (objaso.PI != new Point(0, 0) & objaso.PF != new Point(0, 0) & (objaso.PI != objaso.PF))
                    {

                        Point ptMedio = new Point(objaso.PI.X - (objaso.PF.X - objaso.PI.X), objaso.PF.Y);
                        Acoleccion.Add(new Asociacion5(objaso.PI, ptMedio, objaso.PF));
                        AreaDraw.Invalidate();

                    }
                    #endregion
                    break;
                case ToolSelec.clase:
                    #region

                    if (objcla.puntoInicial != new Point(0, 0) && objcla.puntoFinal != new Point(0, 0))
                    {
                        Point puntoMedio = new Point(objcla.puntoFinal.X, objcla.puntoFinal.Y + 25);
                        Point puntoFin = new Point(objcla.puntoFinal.X, objcla.puntoFinal.Y + 75);
                        Rectangle[] rects =
                                                             {
                                            new Rectangle(objcla.puntoFinal,new Size(100,25)),

                                            new Rectangle(puntoMedio,new Size(100,50)),

                                            new Rectangle(puntoFin,new Size(100,75)),



                                           };


                        FpropiedadesClase frm = new FpropiedadesClase(this);
                         frm.ShowDialog();

                        Ccoleccion.Add(new Clase5(rects, puntoMedio, nombre, atributos, metodos));
                        if (Ccoleccion.Count >= 2) toolAsociacion.Enabled = true;

                        AreaDraw.Invalidate();
                       






                    }
                    #endregion
                    break;
            }
            //reestrableciendo valores
            Aselec = null;
            Cselec = null;
            clic = false;
            toolselec = ToolSelec.puntero;
            toolPuntero.Checked = true;
            toolAsociacion.Checked = false;
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
        }

    }
}
