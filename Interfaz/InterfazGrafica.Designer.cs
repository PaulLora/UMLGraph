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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InterfazGrafica));
            this.btnClase = new System.Windows.Forms.Button();
            this.btnRelacion = new System.Windows.Forms.Button();
            this.btnHerencia = new System.Windows.Forms.Button();
            this.btnInterfaz = new System.Windows.Forms.Button();
            this.btnAgregacion = new System.Windows.Forms.Button();
            this.btnDependencia = new System.Windows.Forms.Button();
            this.btnComposicion = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.btnBorrarLienzo = new System.Windows.Forms.Button();
            this.lblNumEjericio = new System.Windows.Forms.Label();
            this.lblEnunciado = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CmbSelecGrupo = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pnlTitulo = new System.Windows.Forms.Panel();
            this.lblNomProyecto = new System.Windows.Forms.Label();
            this.btnRestaurar = new System.Windows.Forms.PictureBox();
            this.btnMinimizar = new System.Windows.Forms.PictureBox();
            this.btnMaximizar = new System.Windows.Forms.PictureBox();
            this.btnCerrar = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btbCerrarSesion = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pnlTitulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnRestaurar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClase
            // 
            this.btnClase.Location = new System.Drawing.Point(3, 143);
            this.btnClase.Name = "btnClase";
            this.btnClase.Size = new System.Drawing.Size(132, 23);
            this.btnClase.TabIndex = 0;
            this.btnClase.Text = "Dibujar clase";
            this.btnClase.UseVisualStyleBackColor = true;
            this.btnClase.Click += new System.EventHandler(this.btnClase_Click);
            // 
            // btnRelacion
            // 
            this.btnRelacion.Location = new System.Drawing.Point(3, 201);
            this.btnRelacion.Name = "btnRelacion";
            this.btnRelacion.Size = new System.Drawing.Size(132, 23);
            this.btnRelacion.TabIndex = 1;
            this.btnRelacion.Text = "Dibujar relación";
            this.btnRelacion.UseVisualStyleBackColor = true;
            this.btnRelacion.Click += new System.EventHandler(this.BtnRelacion_Click);
            // 
            // btnHerencia
            // 
            this.btnHerencia.Location = new System.Drawing.Point(3, 317);
            this.btnHerencia.Name = "btnHerencia";
            this.btnHerencia.Size = new System.Drawing.Size(132, 23);
            this.btnHerencia.TabIndex = 2;
            this.btnHerencia.Text = "Dibujar herencia";
            this.btnHerencia.UseVisualStyleBackColor = true;
            // 
            // btnInterfaz
            // 
            this.btnInterfaz.Location = new System.Drawing.Point(3, 172);
            this.btnInterfaz.Name = "btnInterfaz";
            this.btnInterfaz.Size = new System.Drawing.Size(132, 23);
            this.btnInterfaz.TabIndex = 4;
            this.btnInterfaz.Text = "Dibujar interfaz";
            this.btnInterfaz.UseVisualStyleBackColor = true;
            this.btnInterfaz.Click += new System.EventHandler(this.BtnInterfaz_Click);
            // 
            // btnAgregacion
            // 
            this.btnAgregacion.Location = new System.Drawing.Point(3, 230);
            this.btnAgregacion.Name = "btnAgregacion";
            this.btnAgregacion.Size = new System.Drawing.Size(132, 23);
            this.btnAgregacion.TabIndex = 6;
            this.btnAgregacion.Text = "Dibujar agregación";
            this.btnAgregacion.UseVisualStyleBackColor = true;
            // 
            // btnDependencia
            // 
            this.btnDependencia.Location = new System.Drawing.Point(3, 259);
            this.btnDependencia.Name = "btnDependencia";
            this.btnDependencia.Size = new System.Drawing.Size(132, 23);
            this.btnDependencia.TabIndex = 7;
            this.btnDependencia.Text = "Dibujar dependencia";
            this.btnDependencia.UseVisualStyleBackColor = true;
            this.btnDependencia.Click += new System.EventHandler(this.BtnDependencia_Click);
            // 
            // btnComposicion
            // 
            this.btnComposicion.Location = new System.Drawing.Point(3, 288);
            this.btnComposicion.Name = "btnComposicion";
            this.btnComposicion.Size = new System.Drawing.Size(132, 23);
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
            // btnBorrarLienzo
            // 
            this.btnBorrarLienzo.Location = new System.Drawing.Point(3, 539);
            this.btnBorrarLienzo.Name = "btnBorrarLienzo";
            this.btnBorrarLienzo.Size = new System.Drawing.Size(132, 23);
            this.btnBorrarLienzo.TabIndex = 10;
            this.btnBorrarLienzo.Text = "Borrar lienzo";
            this.btnBorrarLienzo.UseVisualStyleBackColor = true;
            this.btnBorrarLienzo.Click += new System.EventHandler(this.Button9_Click);
            // 
            // lblNumEjericio
            // 
            this.lblNumEjericio.AutoSize = true;
            this.lblNumEjericio.Location = new System.Drawing.Point(13, 14);
            this.lblNumEjericio.Name = "lblNumEjericio";
            this.lblNumEjericio.Size = new System.Drawing.Size(86, 13);
            this.lblNumEjericio.TabIndex = 11;
            this.lblNumEjericio.Text = "Número ejercicio";
            // 
            // lblEnunciado
            // 
            this.lblEnunciado.AutoSize = true;
            this.lblEnunciado.Location = new System.Drawing.Point(13, 43);
            this.lblEnunciado.Name = "lblEnunciado";
            this.lblEnunciado.Size = new System.Drawing.Size(58, 13);
            this.lblEnunciado.TabIndex = 12;
            this.lblEnunciado.Text = "Enunciado";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.CmbSelecGrupo);
            this.panel1.Controls.Add(this.btnClase);
            this.panel1.Controls.Add(this.btnRelacion);
            this.panel1.Controls.Add(this.btnHerencia);
            this.panel1.Controls.Add(this.btnInterfaz);
            this.panel1.Controls.Add(this.btnBorrarLienzo);
            this.panel1.Controls.Add(this.btnAgregacion);
            this.panel1.Controls.Add(this.btnDependencia);
            this.panel1.Controls.Add(this.btnComposicion);
            this.panel1.Location = new System.Drawing.Point(0, 130);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(140, 470);
            this.panel1.TabIndex = 14;
            // 
            // CmbSelecGrupo
            // 
            this.CmbSelecGrupo.FormattingEnabled = true;
            this.CmbSelecGrupo.Items.AddRange(new object[] {
            "Grupo 5"});
            this.CmbSelecGrupo.Location = new System.Drawing.Point(8, 73);
            this.CmbSelecGrupo.Name = "CmbSelecGrupo";
            this.CmbSelecGrupo.Size = new System.Drawing.Size(121, 21);
            this.CmbSelecGrupo.TabIndex = 12;
            this.CmbSelecGrupo.SelectedIndexChanged += new System.EventHandler(this.CmbSelecGrupo_SelectedIndexChanged);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.lblNumEjericio);
            this.panel2.Controls.Add(this.lblEnunciado);
            this.panel2.Location = new System.Drawing.Point(144, 25);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(856, 103);
            this.panel2.TabIndex = 15;
            // 
            // pnlTitulo
            // 
            this.pnlTitulo.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.pnlTitulo.Controls.Add(this.lblNomProyecto);
            this.pnlTitulo.Controls.Add(this.btnRestaurar);
            this.pnlTitulo.Controls.Add(this.btnMinimizar);
            this.pnlTitulo.Controls.Add(this.btnMaximizar);
            this.pnlTitulo.Controls.Add(this.btnCerrar);
            this.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitulo.Location = new System.Drawing.Point(0, 0);
            this.pnlTitulo.Name = "pnlTitulo";
            this.pnlTitulo.Size = new System.Drawing.Size(1000, 25);
            this.pnlTitulo.TabIndex = 16;
            this.pnlTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PnlTitulo_MouseDown);
            // 
            // lblNomProyecto
            // 
            this.lblNomProyecto.AutoSize = true;
            this.lblNomProyecto.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblNomProyecto.Location = new System.Drawing.Point(3, 3);
            this.lblNomProyecto.Name = "lblNomProyecto";
            this.lblNomProyecto.Size = new System.Drawing.Size(94, 18);
            this.lblNomProyecto.TabIndex = 4;
            this.lblNomProyecto.Text = "UML Graph";
            // 
            // btnRestaurar
            // 
            this.btnRestaurar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRestaurar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRestaurar.Image = ((System.Drawing.Image)(resources.GetObject("btnRestaurar.Image")));
            this.btnRestaurar.Location = new System.Drawing.Point(953, 2);
            this.btnRestaurar.Name = "btnRestaurar";
            this.btnRestaurar.Size = new System.Drawing.Size(19, 19);
            this.btnRestaurar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnRestaurar.TabIndex = 3;
            this.btnRestaurar.TabStop = false;
            this.btnRestaurar.Visible = false;
            this.btnRestaurar.Click += new System.EventHandler(this.BtnRestaurar_Click);
            // 
            // btnMinimizar
            // 
            this.btnMinimizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMinimizar.Image = ((System.Drawing.Image)(resources.GetObject("btnMinimizar.Image")));
            this.btnMinimizar.Location = new System.Drawing.Point(928, 3);
            this.btnMinimizar.Name = "btnMinimizar";
            this.btnMinimizar.Size = new System.Drawing.Size(19, 19);
            this.btnMinimizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnMinimizar.TabIndex = 2;
            this.btnMinimizar.TabStop = false;
            this.btnMinimizar.Click += new System.EventHandler(this.BtnMinimizar_Click);
            // 
            // btnMaximizar
            // 
            this.btnMaximizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMaximizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMaximizar.Image = ((System.Drawing.Image)(resources.GetObject("btnMaximizar.Image")));
            this.btnMaximizar.Location = new System.Drawing.Point(953, 3);
            this.btnMaximizar.Name = "btnMaximizar";
            this.btnMaximizar.Size = new System.Drawing.Size(19, 19);
            this.btnMaximizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnMaximizar.TabIndex = 1;
            this.btnMaximizar.TabStop = false;
            this.btnMaximizar.Click += new System.EventHandler(this.BtnMaximizar_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.Image = ((System.Drawing.Image)(resources.GetObject("btnCerrar.Image")));
            this.btnCerrar.Location = new System.Drawing.Point(978, 3);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(19, 19);
            this.btnCerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnCerrar.TabIndex = 0;
            this.btnCerrar.TabStop = false;
            this.btnCerrar.Click += new System.EventHandler(this.BtnCerrar_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.btbCerrarSesion);
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Controls.Add(this.lblUsuario);
            this.panel3.Location = new System.Drawing.Point(0, 24);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(140, 104);
            this.panel3.TabIndex = 17;
            // 
            // btbCerrarSesion
            // 
            this.btbCerrarSesion.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btbCerrarSesion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.btbCerrarSesion.Location = new System.Drawing.Point(14, 76);
            this.btbCerrarSesion.Name = "btbCerrarSesion";
            this.btbCerrarSesion.Size = new System.Drawing.Size(114, 23);
            this.btbCerrarSesion.TabIndex = 21;
            this.btbCerrarSesion.Text = "Cerrar Sesión";
            this.btbCerrarSesion.UseVisualStyleBackColor = false;
            this.btbCerrarSesion.Click += new System.EventHandler(this.BtbCerrarSesion_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(47, 7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(50, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 20;
            this.pictureBox1.TabStop = false;
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.Location = new System.Drawing.Point(14, 60);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(117, 16);
            this.lblUsuario.TabIndex = 19;
            this.lblUsuario.Text = "NombreUsuario";
            this.lblUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // InterfazGrafica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.pnlTitulo);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "InterfazGrafica";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "UMLGraph";
            this.Load += new System.EventHandler(this.InterfazGrafica_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.InterfazGrafica_MouseDown);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.pnlTitulo.ResumeLayout(false);
            this.pnlTitulo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnRestaurar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
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
        private System.Windows.Forms.Button btnBorrarLienzo;
        private System.Windows.Forms.Label lblNumEjericio;
        private System.Windows.Forms.Label lblEnunciado;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel pnlTitulo;
        private System.Windows.Forms.PictureBox btnRestaurar;
        private System.Windows.Forms.PictureBox btnMinimizar;
        private System.Windows.Forms.PictureBox btnMaximizar;
        private System.Windows.Forms.PictureBox btnCerrar;
        private System.Windows.Forms.Label lblNomProyecto;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btbCerrarSesion;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.ComboBox CmbSelecGrupo;
    }
}