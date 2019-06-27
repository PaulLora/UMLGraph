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
            this.lienzo = new System.Windows.Forms.PictureBox();
            this.btnInterfaz = new System.Windows.Forms.Button();
            this.btnAgregacion = new System.Windows.Forms.Button();
            this.btnDependencia = new System.Windows.Forms.Button();
            this.btnComposicion = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.lblNumEjericio = new System.Windows.Forms.Label();
            this.lblEnunciado = new System.Windows.Forms.Label();
            this.lblBienvenida = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.lienzo)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClase
            // 
            this.btnClase.Location = new System.Drawing.Point(12, 99);
            this.btnClase.Name = "btnClase";
            this.btnClase.Size = new System.Drawing.Size(124, 23);
            this.btnClase.TabIndex = 0;
            this.btnClase.Text = "Dibujar clase";
            this.btnClase.UseVisualStyleBackColor = true;
            // 
            // btnRelacion
            // 
            this.btnRelacion.Location = new System.Drawing.Point(12, 157);
            this.btnRelacion.Name = "btnRelacion";
            this.btnRelacion.Size = new System.Drawing.Size(124, 23);
            this.btnRelacion.TabIndex = 1;
            this.btnRelacion.Text = "Dibujar relación";
            this.btnRelacion.UseVisualStyleBackColor = true;
            // 
            // btnHerencia
            // 
            this.btnHerencia.Location = new System.Drawing.Point(12, 273);
            this.btnHerencia.Name = "btnHerencia";
            this.btnHerencia.Size = new System.Drawing.Size(124, 23);
            this.btnHerencia.TabIndex = 2;
            this.btnHerencia.Text = "Dibujar herencia";
            this.btnHerencia.UseVisualStyleBackColor = true;
            // 
            // lienzo
            // 
            this.lienzo.Location = new System.Drawing.Point(142, 99);
            this.lienzo.Name = "lienzo";
            this.lienzo.Size = new System.Drawing.Size(547, 373);
            this.lienzo.TabIndex = 3;
            this.lienzo.TabStop = false;
            // 
            // btnInterfaz
            // 
            this.btnInterfaz.Location = new System.Drawing.Point(12, 128);
            this.btnInterfaz.Name = "btnInterfaz";
            this.btnInterfaz.Size = new System.Drawing.Size(124, 23);
            this.btnInterfaz.TabIndex = 4;
            this.btnInterfaz.Text = "Dibujar interfaz";
            this.btnInterfaz.UseVisualStyleBackColor = true;
            // 
            // btnAgregacion
            // 
            this.btnAgregacion.Location = new System.Drawing.Point(12, 186);
            this.btnAgregacion.Name = "btnAgregacion";
            this.btnAgregacion.Size = new System.Drawing.Size(124, 23);
            this.btnAgregacion.TabIndex = 6;
            this.btnAgregacion.Text = "Dibujar agregación";
            this.btnAgregacion.UseVisualStyleBackColor = true;
            // 
            // btnDependencia
            // 
            this.btnDependencia.Location = new System.Drawing.Point(12, 215);
            this.btnDependencia.Name = "btnDependencia";
            this.btnDependencia.Size = new System.Drawing.Size(124, 23);
            this.btnDependencia.TabIndex = 7;
            this.btnDependencia.Text = "Dibujar dependencia";
            this.btnDependencia.UseVisualStyleBackColor = true;
            // 
            // btnComposicion
            // 
            this.btnComposicion.Location = new System.Drawing.Point(12, 244);
            this.btnComposicion.Name = "btnComposicion";
            this.btnComposicion.Size = new System.Drawing.Size(124, 23);
            this.btnComposicion.TabIndex = 8;
            this.btnComposicion.Text = "Dibujar composición";
            this.btnComposicion.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(12, 449);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(124, 23);
            this.button5.TabIndex = 9;
            this.button5.Text = "Siguiente ejercicio";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(12, 420);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(124, 23);
            this.button9.TabIndex = 10;
            this.button9.Text = "Borrar lienzo";
            this.button9.UseVisualStyleBackColor = true;
            // 
            // lblNumEjericio
            // 
            this.lblNumEjericio.AutoSize = true;
            this.lblNumEjericio.Location = new System.Drawing.Point(142, 17);
            this.lblNumEjericio.Name = "lblNumEjericio";
            this.lblNumEjericio.Size = new System.Drawing.Size(86, 13);
            this.lblNumEjericio.TabIndex = 11;
            this.lblNumEjericio.Text = "Número ejercicio";
            // 
            // lblEnunciado
            // 
            this.lblEnunciado.AutoSize = true;
            this.lblEnunciado.Location = new System.Drawing.Point(142, 46);
            this.lblEnunciado.Name = "lblEnunciado";
            this.lblEnunciado.Size = new System.Drawing.Size(58, 13);
            this.lblEnunciado.TabIndex = 12;
            this.lblEnunciado.Text = "Enunciado";
            // 
            // lblBienvenida
            // 
            this.lblBienvenida.AutoSize = true;
            this.lblBienvenida.Location = new System.Drawing.Point(12, 9);
            this.lblBienvenida.Name = "lblBienvenida";
            this.lblBienvenida.Size = new System.Drawing.Size(60, 13);
            this.lblBienvenida.TabIndex = 13;
            this.lblBienvenida.Text = "Bienvenida";
            // 
            // Graficador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(701, 484);
            this.Controls.Add(this.lblBienvenida);
            this.Controls.Add(this.lblEnunciado);
            this.Controls.Add(this.lblNumEjericio);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.btnComposicion);
            this.Controls.Add(this.btnDependencia);
            this.Controls.Add(this.btnAgregacion);
            this.Controls.Add(this.btnInterfaz);
            this.Controls.Add(this.lienzo);
            this.Controls.Add(this.btnHerencia);
            this.Controls.Add(this.btnRelacion);
            this.Controls.Add(this.btnClase);
            this.Name = "Graficador";
            this.Text = "Graficador";
            ((System.ComponentModel.ISupportInitialize)(this.lienzo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClase;
        private System.Windows.Forms.Button btnRelacion;
        private System.Windows.Forms.Button btnHerencia;
        private System.Windows.Forms.PictureBox lienzo;
        private System.Windows.Forms.Button btnInterfaz;
        private System.Windows.Forms.Button btnAgregacion;
        private System.Windows.Forms.Button btnDependencia;
        private System.Windows.Forms.Button btnComposicion;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Label lblNumEjericio;
        private System.Windows.Forms.Label lblEnunciado;
        private System.Windows.Forms.Label lblBienvenida;
    }
}