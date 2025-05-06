namespace Magazyn
{
    partial class InformacjeUprawnienia
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
            this.lblNazwa = new System.Windows.Forms.Label();
            this.txtOpis = new System.Windows.Forms.TextBox();
            this.btnPowrot = new System.Windows.Forms.Button();
            this.BtnZapisz = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblNazwa
            // 
            this.lblNazwa.AutoSize = true;
            this.lblNazwa.Location = new System.Drawing.Point(446, 18);
            this.lblNazwa.Name = "lblNazwa";
            this.lblNazwa.Size = new System.Drawing.Size(40, 13);
            this.lblNazwa.TabIndex = 0;
            this.lblNazwa.Text = "Nazwa";
            this.lblNazwa.Click += new System.EventHandler(this.lblNazwa_Click);
            // 
            // txtOpis
            // 
            this.txtOpis.Location = new System.Drawing.Point(106, 46);
            this.txtOpis.Multiline = true;
            this.txtOpis.Name = "txtOpis";
            this.txtOpis.Size = new System.Drawing.Size(739, 213);
            this.txtOpis.TabIndex = 1;
            // 
            // btnPowrot
            // 
            this.btnPowrot.Location = new System.Drawing.Point(808, 484);
            this.btnPowrot.Name = "btnPowrot";
            this.btnPowrot.Size = new System.Drawing.Size(115, 37);
            this.btnPowrot.TabIndex = 2;
            this.btnPowrot.Text = "Powrót";
            this.btnPowrot.UseVisualStyleBackColor = true;
            this.btnPowrot.Click += new System.EventHandler(this.btnPowrot_Click);
            // 
            // BtnZapisz
            // 
            this.BtnZapisz.Location = new System.Drawing.Point(412, 306);
            this.BtnZapisz.Name = "BtnZapisz";
            this.BtnZapisz.Size = new System.Drawing.Size(126, 40);
            this.BtnZapisz.TabIndex = 3;
            this.BtnZapisz.Text = "Zapisz";
            this.BtnZapisz.UseVisualStyleBackColor = true;
            this.BtnZapisz.Click += new System.EventHandler(this.BtnZapisz_Click);
            // 
            // InformacjeUprawnienia
            // 
            this.BackColor = System.Drawing.Color.Salmon;
            this.ClientSize = new System.Drawing.Size(935, 533);
            this.Controls.Add(this.BtnZapisz);
            this.Controls.Add(this.btnPowrot);
            this.Controls.Add(this.txtOpis);
            this.Controls.Add(this.lblNazwa);
            this.Name = "InformacjeUprawnienia";
            this.Text = "Nadawanie Uprawnień";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNazwa;
        private System.Windows.Forms.TextBox txtOpis;
        private System.Windows.Forms.Button btnPowrot;
        private System.Windows.Forms.Button BtnZapisz;
    }
}