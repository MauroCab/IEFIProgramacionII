namespace Presentación
{
    partial class VerificacionIdentidadForm
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
            this.tbxInput = new System.Windows.Forms.TextBox();
            this.lblInstruccion = new System.Windows.Forms.Label();
            this.lblError = new System.Windows.Forms.Label();
            this.btAceptarInput = new System.Windows.Forms.Button();
            this.btCancelar = new System.Windows.Forms.Button();
            this.label34 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbxInput
            // 
            this.tbxInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxInput.Location = new System.Drawing.Point(23, 78);
            this.tbxInput.Name = "tbxInput";
            this.tbxInput.Size = new System.Drawing.Size(285, 22);
            this.tbxInput.TabIndex = 0;
            this.tbxInput.TextChanged += new System.EventHandler(this.tbxInput_TextChanged);
            // 
            // lblInstruccion
            // 
            this.lblInstruccion.AutoSize = true;
            this.lblInstruccion.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInstruccion.Location = new System.Drawing.Point(20, 53);
            this.lblInstruccion.Name = "lblInstruccion";
            this.lblInstruccion.Size = new System.Drawing.Size(54, 22);
            this.lblInstruccion.TabIndex = 1;
            this.lblInstruccion.Text = "label1";
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(20, 103);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(173, 22);
            this.lblError.TabIndex = 2;
            this.lblError.Text = "Contraseña incorrecta";
            // 
            // btAceptarInput
            // 
            this.btAceptarInput.AutoEllipsis = true;
            this.btAceptarInput.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btAceptarInput.Location = new System.Drawing.Point(233, 138);
            this.btAceptarInput.Name = "btAceptarInput";
            this.btAceptarInput.Size = new System.Drawing.Size(75, 24);
            this.btAceptarInput.TabIndex = 3;
            this.btAceptarInput.Text = "Aceptar";
            this.btAceptarInput.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btAceptarInput.UseVisualStyleBackColor = true;
            this.btAceptarInput.Click += new System.EventHandler(this.btAceptarInput_Click);
            // 
            // btCancelar
            // 
            this.btCancelar.AutoEllipsis = true;
            this.btCancelar.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCancelar.Location = new System.Drawing.Point(132, 138);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(75, 24);
            this.btCancelar.TabIndex = 4;
            this.btCancelar.Text = "Cancelar";
            this.btCancelar.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btCancelar.UseVisualStyleBackColor = true;
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label34.Location = new System.Drawing.Point(51, 9);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(233, 28);
            this.label34.TabIndex = 55;
            this.label34.Text = "Verifique su identidad";
            // 
            // VerificacionIdentidadForm
            // 
            this.AcceptButton = this.btAceptarInput;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 184);
            this.Controls.Add(this.label34);
            this.Controls.Add(this.btCancelar);
            this.Controls.Add(this.btAceptarInput);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.lblInstruccion);
            this.Controls.Add(this.tbxInput);
            this.Name = "VerificacionIdentidadForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Verificación De Identidad";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbxInput;
        private System.Windows.Forms.Label lblInstruccion;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Button btAceptarInput;
        private System.Windows.Forms.Button btCancelar;
        private System.Windows.Forms.Label label34;
    }
}