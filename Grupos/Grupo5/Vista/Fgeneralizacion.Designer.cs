namespace UMLGraph.Grupos.Grupo5.Vista
{
    partial class Fgeneralizacion
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
            this.txtNombrePadre = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtNombrePadre
            // 
            this.txtNombrePadre.Location = new System.Drawing.Point(57, 36);
            this.txtNombrePadre.Name = "txtNombrePadre";
            this.txtNombrePadre.Size = new System.Drawing.Size(171, 20);
            this.txtNombrePadre.TabIndex = 0;
            this.txtNombrePadre.Text = "Ingrese nombre de la clase padre";
            this.txtNombrePadre.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtNombrePadre_MouseClick);
            this.txtNombrePadre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombrePadre_KeyPress);
            this.txtNombrePadre.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtNombrePadre_KeyUp);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(99, 81);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(92, 32);
            this.button1.TabIndex = 20;
            this.button1.Text = "Verificar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Fgeneralizacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 135);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtNombrePadre);
            this.Name = "Fgeneralizacion";
            this.Text = "Fgeneralizacion";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNombrePadre;
        private System.Windows.Forms.Button button1;
    }
}