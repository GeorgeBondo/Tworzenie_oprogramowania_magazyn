namespace Magazyn
{
    partial class PanelLogowania
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PanelLogowania));
            this.button_zaloguj = new System.Windows.Forms.Button();
            this.button_haslo = new System.Windows.Forms.Button();
            this.button_wyczysc = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textbox_haslo = new System.Windows.Forms.TextBox();
            this.textbox_login = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button_zaloguj
            // 
            this.button_zaloguj.Location = new System.Drawing.Point(315, 144);
            this.button_zaloguj.Name = "button_zaloguj";
            this.button_zaloguj.Size = new System.Drawing.Size(92, 30);
            this.button_zaloguj.TabIndex = 0;
            this.button_zaloguj.Text = "Zaloguj";
            this.button_zaloguj.UseVisualStyleBackColor = true;
            this.button_zaloguj.Click += new System.EventHandler(this.button_zaloguj_Click);
            // 
            // button_haslo
            // 
            this.button_haslo.Location = new System.Drawing.Point(232, 190);
            this.button_haslo.Name = "button_haslo";
            this.button_haslo.Size = new System.Drawing.Size(158, 30);
            this.button_haslo.TabIndex = 1;
            this.button_haslo.Text = "Zapomniałem hasła";
            this.button_haslo.UseVisualStyleBackColor = true;
            this.button_haslo.Click += new System.EventHandler(this.button_haslo_Click);
            // 
            // button_wyczysc
            // 
            this.button_wyczysc.Location = new System.Drawing.Point(214, 144);
            this.button_wyczysc.Name = "button_wyczysc";
            this.button_wyczysc.Size = new System.Drawing.Size(93, 30);
            this.button_wyczysc.TabIndex = 2;
            this.button_wyczysc.Text = "Wyczyść";
            this.button_wyczysc.UseVisualStyleBackColor = true;
            this.button_wyczysc.Click += new System.EventHandler(this.button_wyczysc_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(176, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Login";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(176, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Hasło";
            // 
            // textbox_haslo
            // 
            this.textbox_haslo.Location = new System.Drawing.Point(245, 104);
            this.textbox_haslo.Name = "textbox_haslo";
            this.textbox_haslo.Size = new System.Drawing.Size(130, 22);
            this.textbox_haslo.TabIndex = 5;
            // 
            // textbox_login
            // 
            this.textbox_login.Location = new System.Drawing.Point(245, 68);
            this.textbox_login.Name = "textbox_login";
            this.textbox_login.Size = new System.Drawing.Size(130, 22);
            this.textbox_login.TabIndex = 6;
            // 
            // PanelLogowania
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(606, 296);
            this.Controls.Add(this.textbox_login);
            this.Controls.Add(this.textbox_haslo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_wyczysc);
            this.Controls.Add(this.button_haslo);
            this.Controls.Add(this.button_zaloguj);
            this.Name = "PanelLogowania";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_zaloguj;
        private System.Windows.Forms.Button button_haslo;
        private System.Windows.Forms.Button button_wyczysc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textbox_haslo;
        private System.Windows.Forms.TextBox textbox_login;
    }
}

