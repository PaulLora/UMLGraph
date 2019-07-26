namespace UMLGraph.Grupos.GrupoX
{
    partial class InsertarHerencia
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCrear = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.cmbClase1 = new System.Windows.Forms.ComboBox();
            this.cmbClase2 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(57, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Seleccionar clase hijo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(57, 53);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Seleccionar clase padre";
            // 
            // btnCrear
            // 
            this.btnCrear.Location = new System.Drawing.Point(11, 89);
            this.btnCrear.Margin = new System.Windows.Forms.Padding(2);
            this.btnCrear.Name = "btnCrear";
            this.btnCrear.Size = new System.Drawing.Size(181, 36);
            this.btnCrear.TabIndex = 2;
            this.btnCrear.Text = "Crear";
            this.btnCrear.UseVisualStyleBackColor = true;
            this.btnCrear.Click += new System.EventHandler(this.BtnCrear_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(275, 89);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(181, 36);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // cmbClase1
            // 
            this.cmbClase1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbClase1.FormattingEnabled = true;
            this.cmbClase1.Location = new System.Drawing.Point(183, 11);
            this.cmbClase1.Margin = new System.Windows.Forms.Padding(2);
            this.cmbClase1.Name = "cmbClase1";
            this.cmbClase1.Size = new System.Drawing.Size(199, 21);
            this.cmbClase1.TabIndex = 4;
            // 
            // cmbClase2
            // 
            this.cmbClase2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbClase2.FormattingEnabled = true;
            this.cmbClase2.Location = new System.Drawing.Point(183, 50);
            this.cmbClase2.Margin = new System.Windows.Forms.Padding(2);
            this.cmbClase2.Name = "cmbClase2";
            this.cmbClase2.Size = new System.Drawing.Size(199, 21);
            this.cmbClase2.TabIndex = 5;
            // 
            // InsertarHerencia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 133);
            this.Controls.Add(this.cmbClase2);
            this.Controls.Add(this.cmbClase1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnCrear);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "InsertarHerencia";
            this.Text = "Insertar nueva herencia";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCrear;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.ComboBox cmbClase1;
        private System.Windows.Forms.ComboBox cmbClase2;
    }
}