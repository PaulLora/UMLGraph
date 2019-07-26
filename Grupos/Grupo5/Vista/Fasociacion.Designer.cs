namespace UMLGraph.Grupos.Grupo5.Vista
{
    partial class Fasociacion
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
            this.btnAso = new System.Windows.Forms.Button();
            this.txtClase1 = new System.Windows.Forms.TextBox();
            this.txtClase2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnAso
            // 
            this.btnAso.Location = new System.Drawing.Point(94, 78);
            this.btnAso.Name = "btnAso";
            this.btnAso.Size = new System.Drawing.Size(99, 23);
            this.btnAso.TabIndex = 0;
            this.btnAso.Text = "Crear Asociación";
            this.btnAso.UseVisualStyleBackColor = true;
            this.btnAso.Click += new System.EventHandler(this.btnAso_Click);
            // 
            // txtClase1
            // 
            this.txtClase1.Location = new System.Drawing.Point(42, 12);
            this.txtClase1.Name = "txtClase1";
            this.txtClase1.Size = new System.Drawing.Size(147, 20);
            this.txtClase1.TabIndex = 1;
            this.txtClase1.Text = "Ingrese nombre de la clase 1";
            this.txtClase1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtClase1_MouseClick);
            this.txtClase1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtClase1_KeyPress);
            this.txtClase1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtClase1_KeyUp);
            // 
            // txtClase2
            // 
            this.txtClase2.Location = new System.Drawing.Point(42, 38);
            this.txtClase2.Name = "txtClase2";
            this.txtClase2.Size = new System.Drawing.Size(147, 20);
            this.txtClase2.TabIndex = 2;
            this.txtClase2.Text = "Ingrese nombre de la clase 2";
            this.txtClase2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtClase2_MouseClick);
            this.txtClase2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtClase2_KeyPress);
            // 
            // Fasociacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(205, 109);
            this.Controls.Add(this.txtClase2);
            this.Controls.Add(this.txtClase1);
            this.Controls.Add(this.btnAso);
            this.Name = "Fasociacion";
            this.Text = "Crear Asociacion";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAso;
        private System.Windows.Forms.TextBox txtClase1;
        private System.Windows.Forms.TextBox txtClase2;
    }
}