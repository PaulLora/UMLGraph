namespace UMLGraph.Grupos.Grupo6.Vista
{
    partial class FormularioRelacion
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
            this.cbox_tipoRelacion = new System.Windows.Forms.ComboBox();
            this.btn_relacionar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_NompreClaseHijo = new System.Windows.Forms.TextBox();
            this.txt_NompreClasePadre = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.groupBox1.Controls.Add(this.cbox_tipoRelacion);
            this.groupBox1.Controls.Add(this.btn_relacionar);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txt_NompreClaseHijo);
            this.groupBox1.Controls.Add(this.txt_NompreClasePadre);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(232, 130);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Creacion de Clase";
            // 
            // cbox_tipoRelacion
            // 
            this.cbox_tipoRelacion.FormattingEnabled = true;
            this.cbox_tipoRelacion.Items.AddRange(new object[] {
            "Agregacion",
            "Composision",
            "Herencia"});
            this.cbox_tipoRelacion.Location = new System.Drawing.Point(83, 73);
            this.cbox_tipoRelacion.Name = "cbox_tipoRelacion";
            this.cbox_tipoRelacion.Size = new System.Drawing.Size(140, 21);
            this.cbox_tipoRelacion.TabIndex = 7;
            this.cbox_tipoRelacion.Text = "Relacion";
            // 
            // btn_relacionar
            // 
            this.btn_relacionar.Location = new System.Drawing.Point(6, 99);
            this.btn_relacionar.Name = "btn_relacionar";
            this.btn_relacionar.Size = new System.Drawing.Size(217, 23);
            this.btn_relacionar.TabIndex = 6;
            this.btn_relacionar.Text = "RELACIONAR";
            this.btn_relacionar.UseVisualStyleBackColor = true;
            this.btn_relacionar.Click += new System.EventHandler(this.Btn_relacionar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Tipo Relacion";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Clase Hijo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Clase Padre";
            // 
            // txt_NompreClaseHijo
            // 
            this.txt_NompreClaseHijo.Location = new System.Drawing.Point(82, 46);
            this.txt_NompreClaseHijo.Name = "txt_NompreClaseHijo";
            this.txt_NompreClaseHijo.Size = new System.Drawing.Size(141, 20);
            this.txt_NompreClaseHijo.TabIndex = 1;
            // 
            // txt_NompreClasePadre
            // 
            this.txt_NompreClasePadre.Location = new System.Drawing.Point(82, 19);
            this.txt_NompreClasePadre.Name = "txt_NompreClasePadre";
            this.txt_NompreClasePadre.Size = new System.Drawing.Size(141, 20);
            this.txt_NompreClasePadre.TabIndex = 0;
            this.txt_NompreClasePadre.TextChanged += new System.EventHandler(this.Txt_NompreClasePadre_TextChanged);
            // 
            // FormularioRelacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(234, 132);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Location = new System.Drawing.Point(2, 400);
            this.Name = "FormularioRelacion";
            this.Load += new System.EventHandler(this.FormularioRelacion_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbox_tipoRelacion;
        private System.Windows.Forms.Button btn_relacionar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_NompreClaseHijo;
        private System.Windows.Forms.TextBox txt_NompreClasePadre;
    }
}