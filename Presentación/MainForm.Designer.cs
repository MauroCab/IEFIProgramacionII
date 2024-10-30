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
            this.btLogIn = new System.Windows.Forms.Button();
            this.btRegistro = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.TabControlDiseño = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.TabControlDiseño.SuspendLayout();
            this.SuspendLayout();
            // 
            // btLogIn
            // 
            this.btLogIn.Font = new System.Drawing.Font("Palatino Linotype", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btLogIn.Location = new System.Drawing.Point(312, 245);
            this.btLogIn.Margin = new System.Windows.Forms.Padding(4);
            this.btLogIn.Name = "btLogIn";
            this.btLogIn.Size = new System.Drawing.Size(167, 79);
            this.btLogIn.TabIndex = 8;
            this.btLogIn.Text = "Iniciar Sesión";
            this.btLogIn.UseVisualStyleBackColor = true;
            // 
            // btRegistro
            // 
            this.btRegistro.Font = new System.Drawing.Font("Palatino Linotype", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btRegistro.Location = new System.Drawing.Point(312, 179);
            this.btRegistro.Margin = new System.Windows.Forms.Padding(4);
            this.btRegistro.Name = "btRegistro";
            this.btRegistro.Size = new System.Drawing.Size(167, 42);
            this.btRegistro.TabIndex = 7;
            this.btRegistro.Text = "Registrarse";
            this.btRegistro.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(189, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(435, 50);
            this.label1.TabIndex = 6;
            this.label1.Text = "RPG Character Manager";
            // 
            // TabControlDiseño
            // 
            this.TabControlDiseño.Controls.Add(this.tabPage1);
            this.TabControlDiseño.Controls.Add(this.tabPage2);
            this.TabControlDiseño.Location = new System.Drawing.Point(42, 146);
            this.TabControlDiseño.Name = "TabControlDiseño";
            this.TabControlDiseño.SelectedIndex = 0;
            this.TabControlDiseño.Size = new System.Drawing.Size(200, 127);
            this.TabControlDiseño.TabIndex = 9;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(192, 101);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(192, 74);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // RPGCMForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(785, 450);
            this.Controls.Add(this.TabControlDiseño);
            this.Controls.Add(this.btLogIn);
            this.Controls.Add(this.btRegistro);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "RPGCMForm";
            this.Text = "RPG Character Manager";
            this.TabControlDiseño.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btLogIn;
        private System.Windows.Forms.Button btRegistro;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl TabControlDiseño;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
    }
}