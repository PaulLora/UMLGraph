﻿namespace UMLGraph
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
            this.CmbSelecGrupo = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblEnunciado = new System.Windows.Forms.Label();
            this.pnlEjercicios = new System.Windows.Forms.Panel();
            this.btnEnunciado6 = new System.Windows.Forms.Button();
            this.btnEnunciado5 = new System.Windows.Forms.Button();
            this.btnEnunciado2 = new System.Windows.Forms.Button();
            this.btnEnunciado3 = new System.Windows.Forms.Button();
            this.btnEnunciado4 = new System.Windows.Forms.Button();
            this.btnEnunciado1 = new System.Windows.Forms.Button();
            this.btnEnunciados = new System.Windows.Forms.Button();
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
            this.btnBorrarLienzo = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlDibujar = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            this.pnlEjercicios.SuspendLayout();
            this.pnlTitulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnRestaurar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.pnlDibujar.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClase
            // 
            this.btnClase.Location = new System.Drawing.Point(1, 4);
            this.btnClase.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnClase.Name = "btnClase";
            this.btnClase.Size = new System.Drawing.Size(176, 26);
            this.btnClase.TabIndex = 0;
            this.btnClase.Text = "Dibujar clase";
            this.btnClase.UseVisualStyleBackColor = true;
            this.btnClase.Click += new System.EventHandler(this.btnClase_Click);
            // 
            // btnRelacion
            // 
            this.btnRelacion.Location = new System.Drawing.Point(1, 75);
            this.btnRelacion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnRelacion.Name = "btnRelacion";
            this.btnRelacion.Size = new System.Drawing.Size(176, 26);
            this.btnRelacion.TabIndex = 1;
            this.btnRelacion.Text = "Dibujar relación";
            this.btnRelacion.UseVisualStyleBackColor = true;
            this.btnRelacion.Click += new System.EventHandler(this.BtnRelacion_Click);
            // 
            // btnHerencia
            // 
            this.btnHerencia.Location = new System.Drawing.Point(1, 218);
            this.btnHerencia.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnHerencia.Name = "btnHerencia";
            this.btnHerencia.Size = new System.Drawing.Size(176, 26);
            this.btnHerencia.TabIndex = 2;
            this.btnHerencia.Text = "Dibujar herencia";
            this.btnHerencia.UseVisualStyleBackColor = true;
            // 
            // btnInterfaz
            // 
            this.btnInterfaz.Location = new System.Drawing.Point(1, 39);
            this.btnInterfaz.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnInterfaz.Name = "btnInterfaz";
            this.btnInterfaz.Size = new System.Drawing.Size(176, 26);
            this.btnInterfaz.TabIndex = 4;
            this.btnInterfaz.Text = "Dibujar interfaz";
            this.btnInterfaz.UseVisualStyleBackColor = true;
            this.btnInterfaz.Click += new System.EventHandler(this.BtnInterfaz_Click);
            // 
            // btnAgregacion
            // 
            this.btnAgregacion.Location = new System.Drawing.Point(1, 111);
            this.btnAgregacion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAgregacion.Name = "btnAgregacion";
            this.btnAgregacion.Size = new System.Drawing.Size(176, 26);
            this.btnAgregacion.TabIndex = 6;
            this.btnAgregacion.Text = "Dibujar agregación";
            this.btnAgregacion.UseVisualStyleBackColor = true;
            // 
            // btnDependencia
            // 
            this.btnDependencia.Location = new System.Drawing.Point(1, 146);
            this.btnDependencia.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDependencia.Name = "btnDependencia";
            this.btnDependencia.Size = new System.Drawing.Size(176, 26);
            this.btnDependencia.TabIndex = 7;
            this.btnDependencia.Text = "Dibujar dependencia";
            this.btnDependencia.UseVisualStyleBackColor = true;
            this.btnDependencia.Click += new System.EventHandler(this.BtnDependencia_Click);
            // 
            // btnComposicion
            // 
            this.btnComposicion.Location = new System.Drawing.Point(1, 182);
            this.btnComposicion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnComposicion.Name = "btnComposicion";
            this.btnComposicion.Size = new System.Drawing.Size(176, 26);
            this.btnComposicion.TabIndex = 8;
            this.btnComposicion.Text = "Dibujar composición";
            this.btnComposicion.UseVisualStyleBackColor = true;
            // 
            // CmbSelecGrupo
            // 
            this.CmbSelecGrupo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CmbSelecGrupo.BackColor = System.Drawing.SystemColors.Menu;
            this.CmbSelecGrupo.FormattingEnabled = true;
            this.CmbSelecGrupo.Items.AddRange(new object[] {
            "Grupo 5"});
            this.CmbSelecGrupo.Location = new System.Drawing.Point(788, 5);
            this.CmbSelecGrupo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CmbSelecGrupo.Name = "CmbSelecGrupo";
            this.CmbSelecGrupo.Size = new System.Drawing.Size(343, 24);
            this.CmbSelecGrupo.TabIndex = 12;
            this.CmbSelecGrupo.Visible = false;
            this.CmbSelecGrupo.SelectedIndexChanged += new System.EventHandler(this.CmbSelecGrupo_SelectedIndexChanged);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.lblEnunciado);
            this.panel2.Controls.Add(this.pnlEjercicios);
            this.panel2.Controls.Add(this.CmbSelecGrupo);
            this.panel2.Controls.Add(this.btnEnunciados);
            this.panel2.Location = new System.Drawing.Point(192, 31);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1140, 126);
            this.panel2.TabIndex = 15;
            // 
            // lblEnunciado
            // 
            this.lblEnunciado.AutoSize = true;
            this.lblEnunciado.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEnunciado.Location = new System.Drawing.Point(16, 57);
            this.lblEnunciado.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEnunciado.Name = "lblEnunciado";
            this.lblEnunciado.Size = new System.Drawing.Size(102, 24);
            this.lblEnunciado.TabIndex = 14;
            this.lblEnunciado.Text = "Enunciado";
            this.lblEnunciado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlEjercicios
            // 
            this.pnlEjercicios.Controls.Add(this.btnEnunciado6);
            this.pnlEjercicios.Controls.Add(this.btnEnunciado5);
            this.pnlEjercicios.Controls.Add(this.btnEnunciado2);
            this.pnlEjercicios.Controls.Add(this.btnEnunciado3);
            this.pnlEjercicios.Controls.Add(this.btnEnunciado4);
            this.pnlEjercicios.Controls.Add(this.btnEnunciado1);
            this.pnlEjercicios.Location = new System.Drawing.Point(20, 48);
            this.pnlEjercicios.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlEjercicios.Name = "pnlEjercicios";
            this.pnlEjercicios.Size = new System.Drawing.Size(672, 44);
            this.pnlEjercicios.TabIndex = 18;
            this.pnlEjercicios.Visible = false;
            // 
            // btnEnunciado6
            // 
            this.btnEnunciado6.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnEnunciado6.FlatAppearance.BorderSize = 0;
            this.btnEnunciado6.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnEnunciado6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnunciado6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnunciado6.Location = new System.Drawing.Point(549, 4);
            this.btnEnunciado6.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnEnunciado6.Name = "btnEnunciado6";
            this.btnEnunciado6.Size = new System.Drawing.Size(101, 33);
            this.btnEnunciado6.TabIndex = 21;
            this.btnEnunciado6.Text = "Ejercicio 6";
            this.btnEnunciado6.UseVisualStyleBackColor = false;
            this.btnEnunciado6.Click += new System.EventHandler(this.BtnEnunciado6_Click);
            // 
            // btnEnunciado5
            // 
            this.btnEnunciado5.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnEnunciado5.FlatAppearance.BorderSize = 0;
            this.btnEnunciado5.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnEnunciado5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnunciado5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnunciado5.Location = new System.Drawing.Point(441, 4);
            this.btnEnunciado5.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnEnunciado5.Name = "btnEnunciado5";
            this.btnEnunciado5.Size = new System.Drawing.Size(100, 33);
            this.btnEnunciado5.TabIndex = 20;
            this.btnEnunciado5.Text = "Ejercicio 5";
            this.btnEnunciado5.UseVisualStyleBackColor = false;
            this.btnEnunciado5.Click += new System.EventHandler(this.BtnEnunciado5_Click);
            // 
            // btnEnunciado2
            // 
            this.btnEnunciado2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnEnunciado2.FlatAppearance.BorderSize = 0;
            this.btnEnunciado2.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnEnunciado2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnunciado2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnunciado2.Location = new System.Drawing.Point(115, 4);
            this.btnEnunciado2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnEnunciado2.Name = "btnEnunciado2";
            this.btnEnunciado2.Size = new System.Drawing.Size(100, 33);
            this.btnEnunciado2.TabIndex = 19;
            this.btnEnunciado2.Text = "Ejercicio 2";
            this.btnEnunciado2.UseVisualStyleBackColor = false;
            this.btnEnunciado2.Click += new System.EventHandler(this.BtnEnunciado2_Click);
            // 
            // btnEnunciado3
            // 
            this.btnEnunciado3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnEnunciado3.FlatAppearance.BorderSize = 0;
            this.btnEnunciado3.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnEnunciado3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnunciado3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnunciado3.Location = new System.Drawing.Point(223, 4);
            this.btnEnunciado3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnEnunciado3.Name = "btnEnunciado3";
            this.btnEnunciado3.Size = new System.Drawing.Size(103, 33);
            this.btnEnunciado3.TabIndex = 19;
            this.btnEnunciado3.Text = "Ejercicio 3";
            this.btnEnunciado3.UseVisualStyleBackColor = false;
            this.btnEnunciado3.Click += new System.EventHandler(this.BtnEnunciado3_Click);
            // 
            // btnEnunciado4
            // 
            this.btnEnunciado4.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnEnunciado4.FlatAppearance.BorderSize = 0;
            this.btnEnunciado4.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnEnunciado4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnunciado4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnunciado4.Location = new System.Drawing.Point(333, 4);
            this.btnEnunciado4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnEnunciado4.Name = "btnEnunciado4";
            this.btnEnunciado4.Size = new System.Drawing.Size(100, 33);
            this.btnEnunciado4.TabIndex = 19;
            this.btnEnunciado4.Text = "Ejercicio 4";
            this.btnEnunciado4.UseVisualStyleBackColor = false;
            this.btnEnunciado4.Click += new System.EventHandler(this.BtnEnunciado4_Click);
            // 
            // btnEnunciado1
            // 
            this.btnEnunciado1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnEnunciado1.FlatAppearance.BorderSize = 0;
            this.btnEnunciado1.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnEnunciado1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnunciado1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnunciado1.Location = new System.Drawing.Point(4, 4);
            this.btnEnunciado1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnEnunciado1.Name = "btnEnunciado1";
            this.btnEnunciado1.Size = new System.Drawing.Size(103, 33);
            this.btnEnunciado1.TabIndex = 18;
            this.btnEnunciado1.Text = "Ejercicio 1";
            this.btnEnunciado1.UseVisualStyleBackColor = false;
            this.btnEnunciado1.Click += new System.EventHandler(this.BtnEnunciado1_Click);
            // 
            // btnEnunciados
            // 
            this.btnEnunciados.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnEnunciados.FlatAppearance.BorderSize = 0;
            this.btnEnunciados.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnEnunciados.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnunciados.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnunciados.Location = new System.Drawing.Point(4, 7);
            this.btnEnunciados.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnEnunciados.Name = "btnEnunciados";
            this.btnEnunciados.Size = new System.Drawing.Size(185, 33);
            this.btnEnunciados.TabIndex = 13;
            this.btnEnunciados.Text = "Escoger ejercicio";
            this.btnEnunciados.UseVisualStyleBackColor = false;
            this.btnEnunciados.Click += new System.EventHandler(this.BtnEnunciados_Click);
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
            this.pnlTitulo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlTitulo.Name = "pnlTitulo";
            this.pnlTitulo.Size = new System.Drawing.Size(1333, 31);
            this.pnlTitulo.TabIndex = 16;
            this.pnlTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PnlTitulo_MouseDown);
            // 
            // lblNomProyecto
            // 
            this.lblNomProyecto.AutoSize = true;
            this.lblNomProyecto.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblNomProyecto.Location = new System.Drawing.Point(4, 4);
            this.lblNomProyecto.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNomProyecto.Name = "lblNomProyecto";
            this.lblNomProyecto.Size = new System.Drawing.Size(115, 24);
            this.lblNomProyecto.TabIndex = 4;
            this.lblNomProyecto.Text = "UML Graph";
            // 
            // btnRestaurar
            // 
            this.btnRestaurar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRestaurar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRestaurar.Image = ((System.Drawing.Image)(resources.GetObject("btnRestaurar.Image")));
            this.btnRestaurar.Location = new System.Drawing.Point(1271, 2);
            this.btnRestaurar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnRestaurar.Name = "btnRestaurar";
            this.btnRestaurar.Size = new System.Drawing.Size(25, 23);
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
            this.btnMinimizar.Location = new System.Drawing.Point(1237, 4);
            this.btnMinimizar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnMinimizar.Name = "btnMinimizar";
            this.btnMinimizar.Size = new System.Drawing.Size(25, 23);
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
            this.btnMaximizar.Location = new System.Drawing.Point(1271, 4);
            this.btnMaximizar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnMaximizar.Name = "btnMaximizar";
            this.btnMaximizar.Size = new System.Drawing.Size(25, 23);
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
            this.btnCerrar.Location = new System.Drawing.Point(1304, 4);
            this.btnCerrar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(25, 23);
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
            this.panel3.Location = new System.Drawing.Point(0, 30);
            this.panel3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(185, 127);
            this.panel3.TabIndex = 17;
            // 
            // btbCerrarSesion
            // 
            this.btbCerrarSesion.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btbCerrarSesion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btbCerrarSesion.Location = new System.Drawing.Point(19, 94);
            this.btbCerrarSesion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btbCerrarSesion.Name = "btbCerrarSesion";
            this.btbCerrarSesion.Size = new System.Drawing.Size(152, 28);
            this.btbCerrarSesion.TabIndex = 21;
            this.btbCerrarSesion.Text = "Cerrar Sesión";
            this.btbCerrarSesion.UseVisualStyleBackColor = false;
            this.btbCerrarSesion.Click += new System.EventHandler(this.BtbCerrarSesion_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(63, 9);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(67, 62);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 20;
            this.pictureBox1.TabStop = false;
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.Location = new System.Drawing.Point(19, 74);
            this.lblUsuario.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(139, 20);
            this.lblUsuario.TabIndex = 19;
            this.lblUsuario.Text = "NombreUsuario";
            this.lblUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnBorrarLienzo
            // 
            this.btnBorrarLienzo.Location = new System.Drawing.Point(4, 663);
            this.btnBorrarLienzo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnBorrarLienzo.Name = "btnBorrarLienzo";
            this.btnBorrarLienzo.Size = new System.Drawing.Size(176, 28);
            this.btnBorrarLienzo.TabIndex = 10;
            this.btnBorrarLienzo.Text = "Borrar lienzo";
            this.btnBorrarLienzo.UseVisualStyleBackColor = true;
            this.btnBorrarLienzo.Click += new System.EventHandler(this.Button9_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.btnBorrarLienzo);
            this.panel1.Controls.Add(this.btnClase);
            this.panel1.Controls.Add(this.btnDependencia);
            this.panel1.Controls.Add(this.btnRelacion);
            this.panel1.Controls.Add(this.btnComposicion);
            this.panel1.Controls.Add(this.btnAgregacion);
            this.panel1.Controls.Add(this.btnHerencia);
            this.panel1.Controls.Add(this.btnInterfaz);
            this.panel1.Location = new System.Drawing.Point(15, 15);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(185, 248);
            this.panel1.TabIndex = 14;
            this.panel1.Visible = false;
            // 
            // pnlDibujar
            // 
            this.pnlDibujar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlDibujar.Controls.Add(this.panel1);
            this.pnlDibujar.Location = new System.Drawing.Point(0, 161);
            this.pnlDibujar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlDibujar.Name = "pnlDibujar";
            this.pnlDibujar.Size = new System.Drawing.Size(1329, 582);
            this.pnlDibujar.TabIndex = 18;
            this.pnlDibujar.Paint += new System.Windows.Forms.PaintEventHandler(this.PnlDibujar_Paint);
            // 
            // InterfazGrafica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1333, 738);
            this.Controls.Add(this.pnlDibujar);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.pnlTitulo);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "InterfazGrafica";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "UMLGraph";
            this.Load += new System.EventHandler(this.InterfazGrafica_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.InterfazGrafica_MouseDown);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.pnlEjercicios.ResumeLayout(false);
            this.pnlTitulo.ResumeLayout(false);
            this.pnlTitulo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnRestaurar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.pnlDibujar.ResumeLayout(false);
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
        private System.Windows.Forms.Button btnEnunciados;
        private System.Windows.Forms.Button btnBorrarLienzo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlEjercicios;
        private System.Windows.Forms.Button btnEnunciado1;
        private System.Windows.Forms.Button btnEnunciado6;
        private System.Windows.Forms.Button btnEnunciado5;
        private System.Windows.Forms.Button btnEnunciado2;
        private System.Windows.Forms.Button btnEnunciado3;
        private System.Windows.Forms.Button btnEnunciado4;
        private System.Windows.Forms.Label lblEnunciado;
        private System.Windows.Forms.Panel pnlDibujar;
    }
}