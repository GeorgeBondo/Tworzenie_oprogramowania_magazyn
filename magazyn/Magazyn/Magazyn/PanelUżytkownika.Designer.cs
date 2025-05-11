namespace Magazyn
{
    partial class PanelUżytkownika
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PanelUżytkownika));
            this.btnZmien = new System.Windows.Forms.Button();
            this.btnWyloguj = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnZmien
            // 
            this.btnZmien.Location = new System.Drawing.Point(435, 56);
            this.btnZmien.Name = "btnZmien";
            this.btnZmien.Size = new System.Drawing.Size(147, 38);
            this.btnZmien.TabIndex = 0;
            this.btnZmien.Text = "Zmień hasło";
            this.btnZmien.UseVisualStyleBackColor = true;
            this.btnZmien.Click += new System.EventHandler(this.btnZmien_Click);
            // 
            // btnWyloguj
            // 
            this.btnWyloguj.Location = new System.Drawing.Point(436, 218);
            this.btnWyloguj.Name = "btnWyloguj";
            this.btnWyloguj.Size = new System.Drawing.Size(146, 41);
            this.btnWyloguj.TabIndex = 1;
            this.btnWyloguj.Text = "Wyloguj";
            this.btnWyloguj.UseVisualStyleBackColor = true;
            this.btnWyloguj.Click += new System.EventHandler(this.btnWyloguj_Click);
            // 
            // PanelUżytkownika
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(626, 291);
            this.Controls.Add(this.btnWyloguj);
            this.Controls.Add(this.btnZmien);
            this.Name = "PanelUżytkownika";
            this.Text = "PanelUżytkownika";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnZmien;
        private System.Windows.Forms.Button btnWyloguj;
    }
}