namespace Magazyn
{
    partial class ZmianaHasłaPrzezUżytkownika
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ZmianaHasłaPrzezUżytkownika));
            this.btnNoweHaslo = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLogin = new System.Windows.Forms.TextBox();
            this.txtStareHaslo = new System.Windows.Forms.TextBox();
            this.txtNoweHaslo = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnNoweHaslo
            // 
            this.btnNoweHaslo.Location = new System.Drawing.Point(242, 220);
            this.btnNoweHaslo.Name = "btnNoweHaslo";
            this.btnNoweHaslo.Size = new System.Drawing.Size(150, 36);
            this.btnNoweHaslo.TabIndex = 0;
            this.btnNoweHaslo.Text = "Zmień hasło";
            this.btnNoweHaslo.UseVisualStyleBackColor = true;
            this.btnNoweHaslo.Click += new System.EventHandler(this.btnNoweHaslo_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(176, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "login";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(97, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Podaj stare hasło";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(95, 177);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Podaj nowe hasło";
            // 
            // txtLogin
            // 
            this.txtLogin.Location = new System.Drawing.Point(242, 62);
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new System.Drawing.Size(150, 22);
            this.txtLogin.TabIndex = 4;
            // 
            // txtStareHaslo
            // 
            this.txtStareHaslo.Location = new System.Drawing.Point(242, 119);
            this.txtStareHaslo.Name = "txtStareHaslo";
            this.txtStareHaslo.Size = new System.Drawing.Size(150, 22);
            this.txtStareHaslo.TabIndex = 5;
            // 
            // txtNoweHaslo
            // 
            this.txtNoweHaslo.Location = new System.Drawing.Point(242, 177);
            this.txtNoweHaslo.Name = "txtNoweHaslo";
            this.txtNoweHaslo.Size = new System.Drawing.Size(150, 22);
            this.txtNoweHaslo.TabIndex = 6;
            // 
            // ZmianaHasłaPrzezUżytkownika
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(625, 297);
            this.Controls.Add(this.txtNoweHaslo);
            this.Controls.Add(this.txtStareHaslo);
            this.Controls.Add(this.txtLogin);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnNoweHaslo);
            this.Name = "ZmianaHasłaPrzezUżytkownika";
            this.Text = "ZmianaHasłaPrzezUżytkownika";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnNoweHaslo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtLogin;
        private System.Windows.Forms.TextBox txtStareHaslo;
        private System.Windows.Forms.TextBox txtNoweHaslo;
    }
}