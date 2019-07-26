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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtMetodos
            // 
            this.txtMetodos.Location = new System.Drawing.Point(25, 193);
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
            this.txtAtributos.Location = new System.Drawing.Point(26, 114);
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
            this.txtNombre.Location = new System.Drawing.Point(26, 79);
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
            this.button1.Location = new System.Drawing.Point(74, 289);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(77, 28);
            this.button1.TabIndex = 20;
            this.button1.Text = "Crear Clase";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(191, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "La primera letra del nombre de la clase ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(218, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "va en mayúscula, Los atributos en minúscula";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(195, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "y los métodos la primera letra mayúscula";
            // 
            // Fclase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(250, 327);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}