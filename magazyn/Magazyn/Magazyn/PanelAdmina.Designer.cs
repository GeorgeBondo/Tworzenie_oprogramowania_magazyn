namespace Magazyn
{
    partial class PanelAdmina
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PanelAdmina));
            this.button_testujPolaczenie = new System.Windows.Forms.Button();
            this.btnDodaj = new System.Windows.Forms.Button();
            this.btnLista = new System.Windows.Forms.Button();
            this.btnWyloguj = new System.Windows.Forms.Button();
            this.btnListaUprawnien = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_testujPolaczenie
            // 
            this.button_testujPolaczenie.Location = new System.Drawing.Point(403, 10);
            this.button_testujPolaczenie.Margin = new System.Windows.Forms.Padding(2);
            this.button_testujPolaczenie.Name = "button_testujPolaczenie";
            this.button_testujPolaczenie.Size = new System.Drawing.Size(56, 37);
            this.button_testujPolaczenie.TabIndex = 0;
            this.button_testujPolaczenie.Text = "text bazy";
            this.button_testujPolaczenie.UseVisualStyleBackColor = true;
            this.button_testujPolaczenie.Click += new System.EventHandler(this.button_testujPolaczenie_Click);
            // 
            // btnDodaj
            // 
            this.btnDodaj.Location = new System.Drawing.Point(172, 65);
            this.btnDodaj.Margin = new System.Windows.Forms.Padding(2);
            this.btnDodaj.Name = "btnDodaj";
            this.btnDodaj.Size = new System.Drawing.Size(124, 32);
            this.btnDodaj.TabIndex = 1;
            this.btnDodaj.Text = "Dodaj Użytkownika";
            this.btnDodaj.UseVisualStyleBackColor = true;
            this.btnDodaj.Click += new System.EventHandler(this.btnDodaj_Click);
            // 
            // btnLista
            // 
            this.btnLista.Location = new System.Drawing.Point(172, 110);
            this.btnLista.Margin = new System.Windows.Forms.Padding(2);
            this.btnLista.Name = "btnLista";
            this.btnLista.Size = new System.Drawing.Size(124, 32);
            this.btnLista.TabIndex = 3;
            this.btnLista.Text = "Lista Użytkowników";
            this.btnLista.UseVisualStyleBackColor = true;
            this.btnLista.Click += new System.EventHandler(this.btnLista_Click_1);
            // 
            // btnWyloguj
            // 
            this.btnWyloguj.Location = new System.Drawing.Point(403, 199);
            this.btnWyloguj.Margin = new System.Windows.Forms.Padding(2);
            this.btnWyloguj.Name = "btnWyloguj";
            this.btnWyloguj.Size = new System.Drawing.Size(56, 27);
            this.btnWyloguj.TabIndex = 6;
            this.btnWyloguj.Text = "Wyloguj";
            this.btnWyloguj.UseVisualStyleBackColor = true;
            this.btnWyloguj.Click += new System.EventHandler(this.btnWyloguj_Click);
            // 
            // btnListaUprawnien
            // 
            this.btnListaUprawnien.Location = new System.Drawing.Point(172, 156);
            this.btnListaUprawnien.Name = "btnListaUprawnien";
            this.btnListaUprawnien.Size = new System.Drawing.Size(124, 32);
            this.btnListaUprawnien.TabIndex = 7;
            this.btnListaUprawnien.Text = "Lista Stanowisk";
            this.btnListaUprawnien.UseVisualStyleBackColor = true;
            // 
            // PanelAdmina
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(468, 236);
            this.Controls.Add(this.btnListaUprawnien);
            this.Controls.Add(this.btnWyloguj);
            this.Controls.Add(this.btnLista);
            this.Controls.Add(this.btnDodaj);
            this.Controls.Add(this.button_testujPolaczenie);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "PanelAdmina";
            this.Text = "Panel Admin";
            this.Load += new System.EventHandler(this.PanelAdmina_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_testujPolaczenie;
        private System.Windows.Forms.Button btnDodaj;
        private System.Windows.Forms.Button btnLista;
        private System.Windows.Forms.Button btnWyloguj;
        private System.Windows.Forms.Button btnListaUprawnien;
    }
}