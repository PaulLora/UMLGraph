namespace UMLGraph.Grupos.Grupo6.Vista
{
    partial class EliminarClase
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
            this.btn_eliminarClase = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_titulo = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.groupBox1.Controls.Add(this.btn_eliminarClase);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txt_titulo);
            this.groupBox1.Location = new System.Drawing.Point(2, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(232, 88);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Eliminar Clase";
            // 
            // btn_eliminarClase
            // 
            this.btn_eliminarClase.Location = new System.Drawing.Point(6, 59);
            this.btn_eliminarClase.Name = "btn_eliminarClase";
            this.btn_eliminarClase.Size = new System.Drawing.Size(217, 23);
            this.btn_eliminarClase.TabIndex = 6;
            this.btn_eliminarClase.Text = "ELIMINAR CLASE";
            this.btn_eliminarClase.UseVisualStyleBackColor = true;
            this.btn_eliminarClase.Click += new System.EventHandler(this.Btn_eliminar_Click);
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
            // txt_titulo
            // 
            this.txt_titulo.Location = new System.Drawing.Point(82, 22);
            this.txt_titulo.Name = "txt_titulo";
            this.txt_titulo.Size = new System.Drawing.Size(141, 20);
            this.txt_titulo.TabIndex = 0;
            // 
            // EliminarClase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(234, 90);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "EliminarClase";
            this.Load += new System.EventHandler(this.EliminarClase_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_eliminarClase;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_titulo;
    }
}