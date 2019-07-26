namespace UMLGraph.Grupos.Grupo5.Vista
{
    partial class Fclase
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
            this.txtMetodos = new System.Windows.Forms.TextBox();
            this.txtAtributos = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtMetodos
            // 
            this.txtMetodos.Location = new System.Drawing.Point(28, 165);
            this.txtMetodos.Multiline = true;
            this.txtMetodos.Name = "txtMetodos";
            this.txtMetodos.Size = new System.Drawing.Size(187, 77);
            this.txtMetodos.TabIndex = 19;
            this.txtMetodos.Text = "Ingrese los métodos de la clase";
            this.txtMetodos.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtMetodos_MouseClick);
            this.txtMetodos.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtAtributos_KeyUp);
            // 
            // txtAtributos
            // 
            this.txtAtributos.Location = new System.Drawing.Point(28, 75);
            this.txtAtributos.Multiline = true;
            this.txtAtributos.Name = "txtAtributos";
            this.txtAtributos.Size = new System.Drawing.Size(187, 73);
            this.txtAtributos.TabIndex = 18;
            this.txtAtributos.Text = "Ingrese los atributos de la clase";
            this.txtAtributos.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtAtributos_MouseClick);
            this.txtAtributos.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtAtributos_KeyUp);
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(28, 32);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(2);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(187, 20);
            this.txtNombre.TabIndex = 15;
            this.txtNombre.Text = "Ingrese nombre de la clase";
            this.txtNombre.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtNombre_MouseClick);
            this.txtNombre.TextChanged += new System.EventHandler(this.txtNombre_TextChanged);
            this.txtNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombre_KeyPress);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(82, 264);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(77, 28);
            this.button1.TabIndex = 20;
            this.button1.Text = "Crear Clase";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // Fclase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(250, 304);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtMetodos);
            this.Controls.Add(this.txtAtributos);
            this.Controls.Add(this.txtNombre);
            this.Name = "Fclase";
            this.Text = "Propiedades Clase";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMetodos;
        private System.Windows.Forms.TextBox txtAtributos;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Button button1;
    }
}