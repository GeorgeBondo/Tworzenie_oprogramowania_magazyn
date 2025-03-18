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
            this.btnKopiuj = new System.Windows.Forms.Button();
            this.lblHaslo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnKopiuj
            // 
            this.btnKopiuj.Location = new System.Drawing.Point(487, 132);
            this.btnKopiuj.Name = "btnKopiuj";
            this.btnKopiuj.Size = new System.Drawing.Size(146, 45);
            this.btnKopiuj.TabIndex = 0;
            this.btnKopiuj.Text = "Skopiuj i kontynuuj";
            this.btnKopiuj.UseVisualStyleBackColor = true;
            // 
            // lblHaslo
            // 
            this.lblHaslo.AutoSize = true;
            this.lblHaslo.Location = new System.Drawing.Point(209, 161);
            this.lblHaslo.Name = "lblHaslo";
            this.lblHaslo.Size = new System.Drawing.Size(135, 16);
            this.lblHaslo.TabIndex = 1;
            this.lblHaslo.Text = "tu będzie nowe hasło";
            // 
            // NoweHasloForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
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