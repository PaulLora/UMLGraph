namespace Grupo1Propietarios
{
    partial class GUI
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnRestaurar = new System.Windows.Forms.PictureBox();
            this.btnMaximizar = new System.Windows.Forms.PictureBox();
            this.btnMinimizar = new System.Windows.Forms.PictureBox();
            this.btnCerrar = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnComposicion = new System.Windows.Forms.Button();
            this.btnAgregacion = new System.Windows.Forms.Button();
            this.btnHerencia = new System.Windows.Forms.Button();
            this.btnAsociacion = new System.Windows.Forms.Button();
            this.btnInterfaz = new System.Windows.Forms.Button();
            this.btnClase = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnRestaurar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.btnRestaurar);
            this.panel1.Controls.Add(this.btnMaximizar);
            this.panel1.Controls.Add(this.btnMinimizar);
            this.panel1.Controls.Add(this.btnCerrar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(833, 28);
            this.panel1.TabIndex = 0;
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            // 
            // btnRestaurar
            // 
            this.btnRestaurar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRestaurar.Image = global::Grupo1Propietarios.Properties.Resources.restaurar;
            this.btnRestaurar.Location = new System.Drawing.Point(763, 0);
            this.btnRestaurar.Name = "btnRestaurar";
            this.btnRestaurar.Size = new System.Drawing.Size(32, 28);
            this.btnRestaurar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnRestaurar.TabIndex = 3;
            this.btnRestaurar.TabStop = false;
            this.btnRestaurar.Visible = false;
            this.btnRestaurar.Click += new System.EventHandler(this.btnRestaurar_Click);
            // 
            // btnMaximizar
            // 
            this.btnMaximizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMaximizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMaximizar.Image = global::Grupo1Propietarios.Properties.Resources.maximizar;
            this.btnMaximizar.Location = new System.Drawing.Point(763, 0);
            this.btnMaximizar.Name = "btnMaximizar";
            this.btnMaximizar.Size = new System.Drawing.Size(35, 28);
            this.btnMaximizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnMaximizar.TabIndex = 2;
            this.btnMaximizar.TabStop = false;
            this.btnMaximizar.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // btnMinimizar
            // 
            this.btnMinimizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMinimizar.Image = global::Grupo1Propietarios.Properties.Resources.minimizar;
            this.btnMinimizar.Location = new System.Drawing.Point(726, 0);
            this.btnMinimizar.Name = "btnMinimizar";
            this.btnMinimizar.Size = new System.Drawing.Size(31, 28);
            this.btnMinimizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnMinimizar.TabIndex = 1;
            this.btnMinimizar.TabStop = false;
            this.btnMinimizar.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.Image = global::Grupo1Propietarios.Properties.Resources.cerrar;
            this.btnCerrar.Location = new System.Drawing.Point(804, 0);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(29, 28);
            this.btnCerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnCerrar.TabIndex = 0;
            this.btnCerrar.TabStop = false;
            this.btnCerrar.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Window;
            this.panel2.Controls.Add(this.btnComposicion);
            this.panel2.Controls.Add(this.btnAgregacion);
            this.panel2.Controls.Add(this.btnHerencia);
            this.panel2.Controls.Add(this.btnAsociacion);
            this.panel2.Controls.Add(this.btnInterfaz);
            this.panel2.Controls.Add(this.btnClase);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 28);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(145, 516);
            this.panel2.TabIndex = 1;
            // 
            // btnComposicion
            // 
            this.btnComposicion.Location = new System.Drawing.Point(0, 436);
            this.btnComposicion.Name = "btnComposicion";
            this.btnComposicion.Size = new System.Drawing.Size(145, 35);
            this.btnComposicion.TabIndex = 5;
            this.btnComposicion.Text = "Dibujar Composición";
            this.btnComposicion.UseVisualStyleBackColor = true;
            // 
            // btnAgregacion
            // 
            this.btnAgregacion.Location = new System.Drawing.Point(0, 372);
            this.btnAgregacion.Name = "btnAgregacion";
            this.btnAgregacion.Size = new System.Drawing.Size(145, 35);
            this.btnAgregacion.TabIndex = 4;
            this.btnAgregacion.Text = "Dibujar Agregación";
            this.btnAgregacion.UseVisualStyleBackColor = true;
            // 
            // btnHerencia
            // 
            this.btnHerencia.Location = new System.Drawing.Point(0, 303);
            this.btnHerencia.Name = "btnHerencia";
            this.btnHerencia.Size = new System.Drawing.Size(145, 35);
            this.btnHerencia.TabIndex = 3;
            this.btnHerencia.Text = "Dibujar Herencia";
            this.btnHerencia.UseVisualStyleBackColor = true;
            // 
            // btnAsociacion
            // 
            this.btnAsociacion.Location = new System.Drawing.Point(0, 241);
            this.btnAsociacion.Name = "btnAsociacion";
            this.btnAsociacion.Size = new System.Drawing.Size(145, 35);
            this.btnAsociacion.TabIndex = 2;
            this.btnAsociacion.Text = "Dibujar Asociación";
            this.btnAsociacion.UseVisualStyleBackColor = true;
            this.btnAsociacion.Click += new System.EventHandler(this.btnAsociacion_Click);
            // 
            // btnInterfaz
            // 
            this.btnInterfaz.Location = new System.Drawing.Point(0, 180);
            this.btnInterfaz.Name = "btnInterfaz";
            this.btnInterfaz.Size = new System.Drawing.Size(145, 35);
            this.btnInterfaz.TabIndex = 1;
            this.btnInterfaz.Text = "Dibujar Interfaz";
            this.btnInterfaz.UseVisualStyleBackColor = true;
            this.btnInterfaz.Click += new System.EventHandler(this.btnInterfaz_Click);
            // 
            // btnClase
            // 
            this.btnClase.Location = new System.Drawing.Point(0, 124);
            this.btnClase.Name = "btnClase";
            this.btnClase.Size = new System.Drawing.Size(145, 35);
            this.btnClase.TabIndex = 0;
            this.btnClase.Text = "Dibujar Clase";
            this.btnClase.UseVisualStyleBackColor = true;
            this.btnClase.Click += new System.EventHandler(this.button1_Click);
            // 
            // GUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(833, 544);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GUI";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.GUI_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnRestaurar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox btnCerrar;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox btnMinimizar;
        private System.Windows.Forms.PictureBox btnMaximizar;
        private System.Windows.Forms.PictureBox btnRestaurar;
        private System.Windows.Forms.Button btnComposicion;
        private System.Windows.Forms.Button btnAgregacion;
        private System.Windows.Forms.Button btnHerencia;
        private System.Windows.Forms.Button btnAsociacion;
        private System.Windows.Forms.Button btnInterfaz;
        private System.Windows.Forms.Button btnClase;
    }
}

