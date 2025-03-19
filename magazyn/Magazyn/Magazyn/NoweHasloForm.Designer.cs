namespace Magazyn
{
    partial class NoweHasloForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NoweHasloForm));
            this.btnKopiuj = new System.Windows.Forms.Button();
            this.lblHaslo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnKopiuj
            // 
            this.btnKopiuj.Location = new System.Drawing.Point(357, 113);
            this.btnKopiuj.Name = "btnKopiuj";
            this.btnKopiuj.Size = new System.Drawing.Size(146, 45);
            this.btnKopiuj.TabIndex = 0;
            this.btnKopiuj.Text = "Skopiuj i kontynuuj";
            this.btnKopiuj.UseVisualStyleBackColor = true;
            this.btnKopiuj.Click += new System.EventHandler(this.btnKopiuj_Click_1);
            // 
            // lblHaslo
            // 
            this.lblHaslo.AutoSize = true;
            this.lblHaslo.Location = new System.Drawing.Point(107, 113);
            this.lblHaslo.Name = "lblHaslo";
            this.lblHaslo.Size = new System.Drawing.Size(135, 16);
            this.lblHaslo.TabIndex = 1;
            this.lblHaslo.Text = "tu będzie nowe hasło";
            // 
            // NoweHasloForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(621, 293);
            this.Controls.Add(this.lblHaslo);
            this.Controls.Add(this.btnKopiuj);
            this.Name = "NoweHasloForm";
            this.Text = "NoweHasloForm";
            this.Load += new System.EventHandler(this.NoweHasloForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnKopiuj;
        private System.Windows.Forms.Label lblHaslo;
    }
}