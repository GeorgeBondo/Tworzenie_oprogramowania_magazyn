namespace Magazyn
{
    partial class ListaUzytkownikow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListaUzytkownikow));
            this.label1 = new System.Windows.Forms.Label();
            this.btwWroc = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(122, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Liasta użytkowników";
            // 
            // btwWroc
            // 
            this.btwWroc.Location = new System.Drawing.Point(391, 161);
            this.btwWroc.Name = "btwWroc";
            this.btwWroc.Size = new System.Drawing.Size(75, 32);
            this.btwWroc.TabIndex = 1;
            this.btwWroc.Text = "Wróć";
            this.btwWroc.UseVisualStyleBackColor = true;
            this.btwWroc.Click += new System.EventHandler(this.btwWroc_Click);
            // 
            // ListaUzytkownikow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(623, 290);
            this.Controls.Add(this.btwWroc);
            this.Controls.Add(this.label1);
            this.Name = "ListaUzytkownikow";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.ListaUzytkownikow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btwWroc;
    }
}