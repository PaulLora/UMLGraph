namespace UMLGraph.Grupos.Grupo1
{
    partial class GUI1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnAgregacion = new System.Windows.Forms.Button();
            this.btnHerencia = new System.Windows.Forms.Button();
            this.btnAsociacion = new System.Windows.Forms.Button();
            this.btnInterfaz = new System.Windows.Forms.Button();
            this.btnClase = new System.Windows.Forms.Button();
            this.btnComposicion = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel2.Controls.Add(this.btnComposicion);
            this.panel2.Controls.Add(this.btnSalir);
            this.panel2.Controls.Add(this.btnAgregacion);
            this.panel2.Controls.Add(this.btnHerencia);
            this.panel2.Controls.Add(this.btnAsociacion);
            this.panel2.Controls.Add(this.btnInterfaz);
            this.panel2.Controls.Add(this.btnClase);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(170, 470);
            this.panel2.TabIndex = 1;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(0, 368);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(170, 32);
            this.btnSalir.TabIndex = 6;
            this.btnSalir.Text = "Salir GR1";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.button6_Click);
            // 
            // btnAgregacion
            // 
            this.btnAgregacion.Location = new System.Drawing.Point(0, 269);
            this.btnAgregacion.Name = "btnAgregacion";
            this.btnAgregacion.Size = new System.Drawing.Size(170, 33);
            this.btnAgregacion.TabIndex = 4;
            this.btnAgregacion.Text = "Dibujar Agregación";
            this.btnAgregacion.UseVisualStyleBackColor = true;
            this.btnAgregacion.Click += new System.EventHandler(this.btnAgregacion_Click);
            // 
            // btnHerencia
            // 
            this.btnHerencia.Location = new System.Drawing.Point(0, 230);
            this.btnHerencia.Name = "btnHerencia";
            this.btnHerencia.Size = new System.Drawing.Size(170, 33);
            this.btnHerencia.TabIndex = 3;
            this.btnHerencia.Text = "Dibujar Herencia";
            this.btnHerencia.UseVisualStyleBackColor = true;
            this.btnHerencia.Click += new System.EventHandler(this.btnHerencia_Click);
            // 
            // btnAsociacion
            // 
            this.btnAsociacion.Location = new System.Drawing.Point(0, 191);
            this.btnAsociacion.Name = "btnAsociacion";
            this.btnAsociacion.Size = new System.Drawing.Size(170, 33);
            this.btnAsociacion.TabIndex = 2;
            this.btnAsociacion.Text = "Dibujar Asociación";
            this.btnAsociacion.UseVisualStyleBackColor = true;
            this.btnAsociacion.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnInterfaz
            // 
            this.btnInterfaz.Location = new System.Drawing.Point(0, 152);
            this.btnInterfaz.Name = "btnInterfaz";
            this.btnInterfaz.Size = new System.Drawing.Size(170, 33);
            this.btnInterfaz.TabIndex = 1;
            this.btnInterfaz.Text = "Dibujar Interfaz";
            this.btnInterfaz.UseVisualStyleBackColor = true;
            this.btnInterfaz.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnClase
            // 
            this.btnClase.Location = new System.Drawing.Point(0, 116);
            this.btnClase.Name = "btnClase";
            this.btnClase.Size = new System.Drawing.Size(170, 30);
            this.btnClase.TabIndex = 0;
            this.btnClase.Text = "Dibujar Clase";
            this.btnClase.UseVisualStyleBackColor = true;
            this.btnClase.Click += new System.EventHandler(this.btnClase_Click);
            // 
            // btnComposicion
            // 
            this.btnComposicion.Location = new System.Drawing.Point(0, 308);
            this.btnComposicion.Name = "btnComposicion";
            this.btnComposicion.Size = new System.Drawing.Size(170, 33);
            this.btnComposicion.TabIndex = 7;
            this.btnComposicion.Text = "Dibujar Composición";
            this.btnComposicion.UseVisualStyleBackColor = true;
            this.btnComposicion.Click += new System.EventHandler(this.btnComposicion_Click);
            // 
            // GUI1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 470);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(120, 171);
            this.Name = "GUI1";
            this.Text = "GUI1";
            this.Load += new System.EventHandler(this.GUI1_Load);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnAgregacion;
        private System.Windows.Forms.Button btnHerencia;
        private System.Windows.Forms.Button btnAsociacion;
        private System.Windows.Forms.Button btnInterfaz;
        private System.Windows.Forms.Button btnClase;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnComposicion;
    }
}