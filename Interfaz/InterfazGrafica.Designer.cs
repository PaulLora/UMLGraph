namespace UMLGraph
{
    partial class InterfazGrafica
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
            this.btnClase = new System.Windows.Forms.Button();
            this.btnRelacion = new System.Windows.Forms.Button();
            this.btnHerencia = new System.Windows.Forms.Button();
            this.btnInterfaz = new System.Windows.Forms.Button();
            this.btnAgregacion = new System.Windows.Forms.Button();
            this.btnDependencia = new System.Windows.Forms.Button();
            this.btnComposicion = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.lblNumEjericio = new System.Windows.Forms.Label();
            this.lblEnunciado = new System.Windows.Forms.Label();
            this.lblBienvenida = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClase
            // 
            this.btnClase.Location = new System.Drawing.Point(4, 121);
            this.btnClase.Margin = new System.Windows.Forms.Padding(4);
            this.btnClase.Name = "btnClase";
            this.btnClase.Size = new System.Drawing.Size(165, 28);
            this.btnClase.TabIndex = 0;
            this.btnClase.Text = "Dibujar clase";
            this.btnClase.UseVisualStyleBackColor = true;
            this.btnClase.Click += new System.EventHandler(this.btnClase_Click);
            // 
            // btnRelacion
            // 
            this.btnRelacion.Location = new System.Drawing.Point(4, 192);
            this.btnRelacion.Margin = new System.Windows.Forms.Padding(4);
            this.btnRelacion.Name = "btnRelacion";
            this.btnRelacion.Size = new System.Drawing.Size(165, 28);
            this.btnRelacion.TabIndex = 1;
            this.btnRelacion.Text = "Dibujar relación";
            this.btnRelacion.UseVisualStyleBackColor = true;
            // 
            // btnHerencia
            // 
            this.btnHerencia.Location = new System.Drawing.Point(4, 335);
            this.btnHerencia.Margin = new System.Windows.Forms.Padding(4);
            this.btnHerencia.Name = "btnHerencia";
            this.btnHerencia.Size = new System.Drawing.Size(165, 28);
            this.btnHerencia.TabIndex = 2;
            this.btnHerencia.Text = "Dibujar herencia";
            this.btnHerencia.UseVisualStyleBackColor = true;
            // 
            // btnInterfaz
            // 
            this.btnInterfaz.Location = new System.Drawing.Point(4, 157);
            this.btnInterfaz.Margin = new System.Windows.Forms.Padding(4);
            this.btnInterfaz.Name = "btnInterfaz";
            this.btnInterfaz.Size = new System.Drawing.Size(165, 28);
            this.btnInterfaz.TabIndex = 4;
            this.btnInterfaz.Text = "Dibujar interfaz";
            this.btnInterfaz.UseVisualStyleBackColor = true;
            // 
            // btnAgregacion
            // 
            this.btnAgregacion.Location = new System.Drawing.Point(4, 228);
            this.btnAgregacion.Margin = new System.Windows.Forms.Padding(4);
            this.btnAgregacion.Name = "btnAgregacion";
            this.btnAgregacion.Size = new System.Drawing.Size(165, 28);
            this.btnAgregacion.TabIndex = 6;
            this.btnAgregacion.Text = "Dibujar agregación";
            this.btnAgregacion.UseVisualStyleBackColor = true;
            // 
            // btnDependencia
            // 
            this.btnDependencia.Location = new System.Drawing.Point(4, 264);
            this.btnDependencia.Margin = new System.Windows.Forms.Padding(4);
            this.btnDependencia.Name = "btnDependencia";
            this.btnDependencia.Size = new System.Drawing.Size(165, 28);
            this.btnDependencia.TabIndex = 7;
            this.btnDependencia.Text = "Dibujar dependencia";
            this.btnDependencia.UseVisualStyleBackColor = true;
            // 
            // btnComposicion
            // 
            this.btnComposicion.Location = new System.Drawing.Point(4, 299);
            this.btnComposicion.Margin = new System.Windows.Forms.Padding(4);
            this.btnComposicion.Name = "btnComposicion";
            this.btnComposicion.Size = new System.Drawing.Size(165, 28);
            this.btnComposicion.TabIndex = 8;
            this.btnComposicion.Text = "Dibujar composición";
            this.btnComposicion.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(16, 553);
            this.button5.Margin = new System.Windows.Forms.Padding(4);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(165, 28);
            this.button5.TabIndex = 9;
            this.button5.Text = "Siguiente ejercicio";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(4, 516);
            this.button9.Margin = new System.Windows.Forms.Padding(4);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(165, 28);
            this.button9.TabIndex = 10;
            this.button9.Text = "Borrar lienzo";
            this.button9.UseVisualStyleBackColor = true;
            // 
            // lblNumEjericio
            // 
            this.lblNumEjericio.AutoSize = true;
            this.lblNumEjericio.Location = new System.Drawing.Point(17, 17);
            this.lblNumEjericio.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNumEjericio.Name = "lblNumEjericio";
            this.lblNumEjericio.Size = new System.Drawing.Size(114, 17);
            this.lblNumEjericio.TabIndex = 11;
            this.lblNumEjericio.Text = "Número ejercicio";
            // 
            // lblEnunciado
            // 
            this.lblEnunciado.AutoSize = true;
            this.lblEnunciado.Location = new System.Drawing.Point(17, 53);
            this.lblEnunciado.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEnunciado.Name = "lblEnunciado";
            this.lblEnunciado.Size = new System.Drawing.Size(75, 17);
            this.lblEnunciado.TabIndex = 12;
            this.lblEnunciado.Text = "Enunciado";
            // 
            // lblBienvenida
            // 
            this.lblBienvenida.AutoSize = true;
            this.lblBienvenida.Location = new System.Drawing.Point(23, 13);
            this.lblBienvenida.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBienvenida.Name = "lblBienvenida";
            this.lblBienvenida.Size = new System.Drawing.Size(78, 17);
            this.lblBienvenida.TabIndex = 13;
            this.lblBienvenida.Text = "Bienvenida";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnClase);
            this.panel1.Controls.Add(this.lblBienvenida);
            this.panel1.Controls.Add(this.btnRelacion);
            this.panel1.Controls.Add(this.btnHerencia);
            this.panel1.Controls.Add(this.btnInterfaz);
            this.panel1.Controls.Add(this.button9);
            this.panel1.Controls.Add(this.btnAgregacion);
            this.panel1.Controls.Add(this.btnDependencia);
            this.panel1.Controls.Add(this.btnComposicion);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(181, 596);
            this.panel1.TabIndex = 14;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lblNumEjericio);
            this.panel2.Controls.Add(this.lblEnunciado);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(181, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(754, 100);
            this.panel2.TabIndex = 15;
            // 
            // InterfazGrafica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(935, 596);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button5);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "InterfazGrafica";
            this.Text = "Graficador";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClase;
        private System.Windows.Forms.Button btnRelacion;
        private System.Windows.Forms.Button btnHerencia;
        private System.Windows.Forms.Button btnInterfaz;
        private System.Windows.Forms.Button btnAgregacion;
        private System.Windows.Forms.Button btnDependencia;
        private System.Windows.Forms.Button btnComposicion;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Label lblNumEjericio;
        private System.Windows.Forms.Label lblEnunciado;
        private System.Windows.Forms.Label lblBienvenida;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}