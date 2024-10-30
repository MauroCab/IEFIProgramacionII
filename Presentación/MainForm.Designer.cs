namespace Presentación
{
    partial class RPGCMForm
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
            this.panelIngreso = new System.Windows.Forms.Panel();
            this.btLogIn = new System.Windows.Forms.Button();
            this.btRegistro = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panelIngreso.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelIngreso
            // 
            this.panelIngreso.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.panelIngreso.Controls.Add(this.btLogIn);
            this.panelIngreso.Controls.Add(this.btRegistro);
            this.panelIngreso.Controls.Add(this.label1);
            this.panelIngreso.Location = new System.Drawing.Point(88, 27);
            this.panelIngreso.Margin = new System.Windows.Forms.Padding(4);
            this.panelIngreso.Name = "panelIngreso";
            this.panelIngreso.Size = new System.Drawing.Size(872, 494);
            this.panelIngreso.TabIndex = 3;
            this.panelIngreso.TabStop = true;
            // 
            // btLogIn
            // 
            this.btLogIn.Font = new System.Drawing.Font("Palatino Linotype", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btLogIn.Location = new System.Drawing.Point(327, 315);
            this.btLogIn.Margin = new System.Windows.Forms.Padding(4);
            this.btLogIn.Name = "btLogIn";
            this.btLogIn.Size = new System.Drawing.Size(223, 97);
            this.btLogIn.TabIndex = 5;
            this.btLogIn.Text = "Iniciar Sesión";
            this.btLogIn.UseVisualStyleBackColor = true;
            // 
            // btRegistro
            // 
            this.btRegistro.Font = new System.Drawing.Font("Palatino Linotype", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btRegistro.Location = new System.Drawing.Point(327, 220);
            this.btRegistro.Margin = new System.Windows.Forms.Padding(4);
            this.btRegistro.Name = "btRegistro";
            this.btRegistro.Size = new System.Drawing.Size(223, 52);
            this.btRegistro.TabIndex = 4;
            this.btRegistro.Text = "Registrarse";
            this.btRegistro.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(147, 80);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(553, 63);
            this.label1.TabIndex = 3;
            this.label1.Text = "RPG Character Manager";
            // 
            // RPGCMForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1047, 554);
            this.Controls.Add(this.panelIngreso);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "RPGCMForm";
            this.Text = "RPG Character Manager";
            this.panelIngreso.ResumeLayout(false);
            this.panelIngreso.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelIngreso;
        private System.Windows.Forms.Button btLogIn;
        private System.Windows.Forms.Button btRegistro;
        private System.Windows.Forms.Label label1;
    }
}