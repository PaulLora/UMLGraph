namespace UMLGraph.Grupos.Grupo6.Vista
{
    partial class FormularioActualizarClase
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_actualizarClase = new System.Windows.Forms.Button();
            this.txt_metodos = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_atributos = new System.Windows.Forms.TextBox();
            this.txt_titulo = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.groupBox1.Controls.Add(this.btn_actualizarClase);
            this.groupBox1.Controls.Add(this.txt_metodos);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txt_atributos);
            this.groupBox1.Controls.Add(this.txt_titulo);
            this.groupBox1.Location = new System.Drawing.Point(1, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(232, 130);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Actualizar Clase";
            this.groupBox1.Enter += new System.EventHandler(this.GroupBox1_Enter);
            // 
            // btn_actualizarClase
            // 
            this.btn_actualizarClase.Location = new System.Drawing.Point(9, 96);
            this.btn_actualizarClase.Name = "btn_actualizarClase";
            this.btn_actualizarClase.Size = new System.Drawing.Size(212, 23);
            this.btn_actualizarClase.TabIndex = 8;
            this.btn_actualizarClase.Text = "ACTUALIZAR CLASE";
            this.btn_actualizarClase.UseVisualStyleBackColor = true;
            this.btn_actualizarClase.Click += new System.EventHandler(this.Button1_Click);
            // 
            // txt_metodos
            // 
            this.txt_metodos.Location = new System.Drawing.Point(82, 73);
            this.txt_metodos.Name = "txt_metodos";
            this.txt_metodos.Size = new System.Drawing.Size(141, 20);
            this.txt_metodos.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Metodos";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Atributos";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Titulo";
            // 
            // txt_atributos
            // 
            this.txt_atributos.Location = new System.Drawing.Point(82, 46);
            this.txt_atributos.Name = "txt_atributos";
            this.txt_atributos.Size = new System.Drawing.Size(141, 20);
            this.txt_atributos.TabIndex = 1;
            // 
            // txt_titulo
            // 
            this.txt_titulo.Location = new System.Drawing.Point(82, 19);
            this.txt_titulo.Name = "txt_titulo";
            this.txt_titulo.Size = new System.Drawing.Size(141, 20);
            this.txt_titulo.TabIndex = 0;
            this.txt_titulo.TextChanged += new System.EventHandler(this.Txt_titulo_TextChanged);
            // 
            // FormularioActualizarClase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(234, 132);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormularioActualizarClase";
            this.Load += new System.EventHandler(this.FormularioActualizarClase_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_atributos;
        private System.Windows.Forms.TextBox txt_titulo;
        private System.Windows.Forms.TextBox txt_metodos;
        private System.Windows.Forms.Button btn_actualizarClase;
    }
}