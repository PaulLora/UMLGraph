namespace UMLGraph.Grupos.Grupo5.Vista
{
    partial class FLinterface
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
            this.txtNombreI = new System.Windows.Forms.TextBox();
            this.txtNomClase = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtNombreI
            // 
            this.txtNombreI.Location = new System.Drawing.Point(28, 38);
            this.txtNombreI.Name = "txtNombreI";
            this.txtNombreI.Size = new System.Drawing.Size(154, 20);
            this.txtNombreI.TabIndex = 1;
            this.txtNombreI.Text = "Ingrese nombre de la interfaz";
            this.txtNombreI.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtNombreI_MouseClick);
            // 
            // txtNomClase
            // 
            this.txtNomClase.Location = new System.Drawing.Point(28, 83);
            this.txtNomClase.Name = "txtNomClase";
            this.txtNomClase.Size = new System.Drawing.Size(154, 20);
            this.txtNomClase.TabIndex = 2;
            this.txtNomClase.Text = "Ingrese nombre de la clase";
            this.txtNomClase.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtNomClase_MouseClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(56, 147);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(97, 28);
            this.button1.TabIndex = 21;
            this.button1.Text = "Crear relación";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FLinterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(203, 215);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtNomClase);
            this.Controls.Add(this.txtNombreI);
            this.Name = "FLinterface";
            this.Text = "FLinterface";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNombreI;
        private System.Windows.Forms.TextBox txtNomClase;
        private System.Windows.Forms.Button button1;
    }
}