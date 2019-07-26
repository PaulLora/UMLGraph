﻿namespace UMLGraph.Grupos.Grupo3.Interfaz
{
    partial class LlenarClase
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtNombreClase = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.comboBoxTipoAtributo = new System.Windows.Forms.ComboBox();
            this.button5 = new System.Windows.Forms.Button();
            this.botonModificarAtributos = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNombreAtributo = new System.Windows.Forms.TextBox();
            this.listaAtributos = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboBoxTipoRetorno = new System.Windows.Forms.ComboBox();
            this.button6 = new System.Windows.Forms.Button();
            this.botonModificarMetodo = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNombreMetodo = new System.Windows.Forms.TextBox();
            this.listaMetodos = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Control;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.txtNombreClase);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Location = new System.Drawing.Point(5, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(454, 50);
            this.panel3.TabIndex = 5;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel3_Paint);
            // 
            // txtNombreClase
            // 
            this.txtNombreClase.Location = new System.Drawing.Point(118, 15);
            this.txtNombreClase.Name = "txtNombreClase";
            this.txtNombreClase.Size = new System.Drawing.Size(197, 20);
            this.txtNombreClase.TabIndex = 1;
            this.txtNombreClase.TextChanged += new System.EventHandler(this.txtNombreClase_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre de la clase:";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.comboBoxTipoAtributo);
            this.panel2.Controls.Add(this.button5);
            this.panel2.Controls.Add(this.botonModificarAtributos);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.txtNombreAtributo);
            this.panel2.Controls.Add(this.listaAtributos);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(5, 60);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(454, 103);
            this.panel2.TabIndex = 6;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // comboBoxTipoAtributo
            // 
            this.comboBoxTipoAtributo.FormattingEnabled = true;
            this.comboBoxTipoAtributo.Items.AddRange(new object[] {
            "byte",
            "short",
            "int",
            "long",
            "float",
            "double",
            "string",
            "boolean"});
            this.comboBoxTipoAtributo.Location = new System.Drawing.Point(113, 48);
            this.comboBoxTipoAtributo.Name = "comboBoxTipoAtributo";
            this.comboBoxTipoAtributo.Size = new System.Drawing.Size(69, 21);
            this.comboBoxTipoAtributo.TabIndex = 8;
            this.comboBoxTipoAtributo.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // button5
            // 
            this.button5.Enabled = false;
            this.button5.Location = new System.Drawing.Point(82, 78);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(63, 20);
            this.button5.TabIndex = 7;
            this.button5.Text = "Borrar";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.Button5_Click_1);
            // 
            // botonModificarAtributos
            // 
            this.botonModificarAtributos.Enabled = false;
            this.botonModificarAtributos.Location = new System.Drawing.Point(13, 78);
            this.botonModificarAtributos.Name = "botonModificarAtributos";
            this.botonModificarAtributos.Size = new System.Drawing.Size(63, 20);
            this.botonModificarAtributos.TabIndex = 6;
            this.botonModificarAtributos.Text = "Modificar";
            this.botonModificarAtributos.UseVisualStyleBackColor = true;
            this.botonModificarAtributos.Click += new System.EventHandler(this.BotonModificarAtributos_Click);
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(188, 48);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(53, 24);
            this.button1.TabIndex = 5;
            this.button1.Text = "Agregar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click_1);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(75, 52);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Tipo:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Nombre del atributo:";
            // 
            // txtNombreAtributo
            // 
            this.txtNombreAtributo.Location = new System.Drawing.Point(112, 26);
            this.txtNombreAtributo.Name = "txtNombreAtributo";
            this.txtNombreAtributo.Size = new System.Drawing.Size(139, 20);
            this.txtNombreAtributo.TabIndex = 2;
            this.txtNombreAtributo.TextChanged += new System.EventHandler(this.txtNombreAtributo_TextChanged);
            // 
            // listaAtributos
            // 
            this.listaAtributos.FormattingEnabled = true;
            this.listaAtributos.Location = new System.Drawing.Point(270, 16);
            this.listaAtributos.Name = "listaAtributos";
            this.listaAtributos.Size = new System.Drawing.Size(176, 82);
            this.listaAtributos.TabIndex = 1;
            this.listaAtributos.SelectedIndexChanged += new System.EventHandler(this.listaAtributos_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Atributos";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.comboBoxTipoRetorno);
            this.panel1.Controls.Add(this.button6);
            this.panel1.Controls.Add(this.botonModificarMetodo);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtNombreMetodo);
            this.panel1.Controls.Add(this.listaMetodos);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(5, 170);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(454, 98);
            this.panel1.TabIndex = 7;
            // 
            // comboBoxTipoRetorno
            // 
            this.comboBoxTipoRetorno.FormattingEnabled = true;
            this.comboBoxTipoRetorno.Items.AddRange(new object[] {
            "byte",
            "short",
            "int",
            "long",
            "float",
            "double",
            "string",
            "boolean"});
            this.comboBoxTipoRetorno.Location = new System.Drawing.Point(112, 49);
            this.comboBoxTipoRetorno.Name = "comboBoxTipoRetorno";
            this.comboBoxTipoRetorno.Size = new System.Drawing.Size(70, 21);
            this.comboBoxTipoRetorno.TabIndex = 9;
            this.comboBoxTipoRetorno.SelectedIndexChanged += new System.EventHandler(this.comboBoxTipoRetorno_SelectedIndexChanged);
            // 
            // button6
            // 
            this.button6.Enabled = false;
            this.button6.Location = new System.Drawing.Point(80, 72);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(63, 20);
            this.button6.TabIndex = 8;
            this.button6.Text = "Borrar";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.Button6_Click_1);
            // 
            // botonModificarMetodo
            // 
            this.botonModificarMetodo.Enabled = false;
            this.botonModificarMetodo.Location = new System.Drawing.Point(11, 72);
            this.botonModificarMetodo.Name = "botonModificarMetodo";
            this.botonModificarMetodo.Size = new System.Drawing.Size(63, 20);
            this.botonModificarMetodo.TabIndex = 7;
            this.botonModificarMetodo.Text = "Modificar";
            this.botonModificarMetodo.UseVisualStyleBackColor = true;
            this.botonModificarMetodo.Click += new System.EventHandler(this.BotonModificarMetodo_Click);
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(188, 46);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(53, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "Agregar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click_1);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(24, 49);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Tipo de retorno:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Nombre del método:";
            // 
            // txtNombreMetodo
            // 
            this.txtNombreMetodo.Location = new System.Drawing.Point(112, 24);
            this.txtNombreMetodo.Name = "txtNombreMetodo";
            this.txtNombreMetodo.Size = new System.Drawing.Size(139, 20);
            this.txtNombreMetodo.TabIndex = 3;
            this.txtNombreMetodo.TextChanged += new System.EventHandler(this.txtNombreMetodo_TextChanged);
            // 
            // listaMetodos
            // 
            this.listaMetodos.FormattingEnabled = true;
            this.listaMetodos.Location = new System.Drawing.Point(270, 11);
            this.listaMetodos.Name = "listaMetodos";
            this.listaMetodos.Size = new System.Drawing.Size(176, 82);
            this.listaMetodos.TabIndex = 2;
            this.listaMetodos.SelectedIndexChanged += new System.EventHandler(this.listaMetodos_SelectedIndexChanged_1);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Metodos";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(327, 274);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(63, 26);
            this.button3.TabIndex = 10;
            this.button3.Text = "Aceptar";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Button3_Click_2);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(396, 274);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(63, 26);
            this.button4.TabIndex = 11;
            this.button4.Text = "Cancelar";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.Button4_Click_1);
            // 
            // LlenarClase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 307);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "LlenarClase";
            this.Text = "LlenarClase";
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        public System.Windows.Forms.TextBox txtNombreClase;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button botonModificarAtributos;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox txtNombreAtributo;
        public System.Windows.Forms.ListBox listaAtributos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button botonModificarMetodo;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox txtNombreMetodo;
        public System.Windows.Forms.ListBox listaMetodos;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ComboBox comboBoxTipoAtributo;
        private System.Windows.Forms.ComboBox comboBoxTipoRetorno;
    }
}