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
            this.btnWroc = new System.Windows.Forms.Button();
            this.dataGridViewUzytkownicy = new System.Windows.Forms.DataGridView();
            this.btnOdswiez = new System.Windows.Forms.Button();
            this.btnEdytuj = new System.Windows.Forms.Button();
            this.btnWyczyśćFiltry = new System.Windows.Forms.Button();
            this.txtFiltrImie = new System.Windows.Forms.TextBox();
            this.txtFiltrNazwisko = new System.Windows.Forms.TextBox();
            this.txtFiltrPesel = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnZapomniani = new System.Windows.Forms.Button();
            this.btnZapomnij = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUzytkownicy)).BeginInit();
            this.SuspendLayout();
            // 
            // btnWroc
            // 
            this.btnWroc.Location = new System.Drawing.Point(536, 25);
            this.btnWroc.Name = "btnWroc";
            this.btnWroc.Size = new System.Drawing.Size(75, 32);
            this.btnWroc.TabIndex = 1;
            this.btnWroc.Text = "Wróć";
            this.btnWroc.UseVisualStyleBackColor = true;
            this.btnWroc.Click += new System.EventHandler(this.btnWroc_Click);
            // 
            // dataGridViewUzytkownicy
            // 
            this.dataGridViewUzytkownicy.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewUzytkownicy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dataGridViewUzytkownicy.Location = new System.Drawing.Point(12, 228);
            this.dataGridViewUzytkownicy.Name = "dataGridViewUzytkownicy";
            this.dataGridViewUzytkownicy.RowHeadersWidth = 51;
            this.dataGridViewUzytkownicy.RowTemplate.Height = 24;
            this.dataGridViewUzytkownicy.Size = new System.Drawing.Size(845, 523);
            this.dataGridViewUzytkownicy.TabIndex = 2;
            // 
            // btnOdswiez
            // 
            this.btnOdswiez.Location = new System.Drawing.Point(223, 25);
            this.btnOdswiez.Name = "btnOdswiez";
            this.btnOdswiez.Size = new System.Drawing.Size(75, 32);
            this.btnOdswiez.TabIndex = 3;
            this.btnOdswiez.Text = "Odśwież ";
            this.btnOdswiez.UseVisualStyleBackColor = true;
            this.btnOdswiez.Click += new System.EventHandler(this.btnOdswiez_Click);
            // 
            // btnEdytuj
            // 
            this.btnEdytuj.Location = new System.Drawing.Point(317, 12);
            this.btnEdytuj.Name = "btnEdytuj";
            this.btnEdytuj.Size = new System.Drawing.Size(196, 58);
            this.btnEdytuj.TabIndex = 4;
            this.btnEdytuj.Text = "Edytuj dane tego użytkownika";
            this.btnEdytuj.UseVisualStyleBackColor = true;
            this.btnEdytuj.Click += new System.EventHandler(this.btnEdytuj_Click);
            // 
            // btnWyczyśćFiltry
            // 
            this.btnWyczyśćFiltry.Location = new System.Drawing.Point(614, 122);
            this.btnWyczyśćFiltry.Name = "btnWyczyśćFiltry";
            this.btnWyczyśćFiltry.Size = new System.Drawing.Size(128, 41);
            this.btnWyczyśćFiltry.TabIndex = 5;
            this.btnWyczyśćFiltry.Text = "Wyczyść filtry";
            this.btnWyczyśćFiltry.UseVisualStyleBackColor = true;
            this.btnWyczyśćFiltry.Click += new System.EventHandler(this.btnWyczyśćFiltry_Click);
            // 
            // txtFiltrImie
            // 
            this.txtFiltrImie.Location = new System.Drawing.Point(234, 200);
            this.txtFiltrImie.Name = "txtFiltrImie";
            this.txtFiltrImie.Size = new System.Drawing.Size(100, 22);
            this.txtFiltrImie.TabIndex = 6;
            // 
            // txtFiltrNazwisko
            // 
            this.txtFiltrNazwisko.Location = new System.Drawing.Point(356, 200);
            this.txtFiltrNazwisko.Name = "txtFiltrNazwisko";
            this.txtFiltrNazwisko.Size = new System.Drawing.Size(100, 22);
            this.txtFiltrNazwisko.TabIndex = 7;
            // 
            // txtFiltrPesel
            // 
            this.txtFiltrPesel.Location = new System.Drawing.Point(626, 200);
            this.txtFiltrPesel.Name = "txtFiltrPesel";
            this.txtFiltrPesel.Size = new System.Drawing.Size(100, 22);
            this.txtFiltrPesel.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(266, 178);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "Imię";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(371, 178);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 16);
            this.label2.TabIndex = 10;
            this.label2.Text = "Nazwisko";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(653, 178);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 16);
            this.label3.TabIndex = 11;
            this.label3.Text = "PESEL";
            // 
            // btnZapomniani
            // 
            this.btnZapomniani.Location = new System.Drawing.Point(1, 132);
            this.btnZapomniani.Name = "btnZapomniani";
            this.btnZapomniani.Size = new System.Drawing.Size(175, 31);
            this.btnZapomniani.TabIndex = 12;
            this.btnZapomniani.Text = "Zapomnieni użytkownicy";
            this.btnZapomniani.UseVisualStyleBackColor = true;
            this.btnZapomniani.Click += new System.EventHandler(this.btnZapomniani_Click);
            // 
            // btnZapomnij
            // 
            this.btnZapomnij.Location = new System.Drawing.Point(31, 83);
            this.btnZapomnij.Name = "btnZapomnij";
            this.btnZapomnij.Size = new System.Drawing.Size(100, 43);
            this.btnZapomnij.TabIndex = 13;
            this.btnZapomnij.Text = "Zapomnij";
            this.btnZapomnij.UseVisualStyleBackColor = true;
            this.btnZapomnij.Click += new System.EventHandler(this.btnZapomnij_Click_1);
            // 
            // ListaUzytkownikow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Salmon;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(869, 763);
            this.Controls.Add(this.btnZapomnij);
            this.Controls.Add(this.btnZapomniani);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtFiltrPesel);
            this.Controls.Add(this.txtFiltrNazwisko);
            this.Controls.Add(this.txtFiltrImie);
            this.Controls.Add(this.btnWyczyśćFiltry);
            this.Controls.Add(this.btnEdytuj);
            this.Controls.Add(this.btnOdswiez);
            this.Controls.Add(this.dataGridViewUzytkownicy);
            this.Controls.Add(this.btnWroc);
            this.Name = "ListaUzytkownikow";
            this.Text = "Lista Użytkowników";
            this.Load += new System.EventHandler(this.ListaUzytkownikow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUzytkownicy)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnWroc;
        private System.Windows.Forms.DataGridView dataGridViewUzytkownicy;
        private System.Windows.Forms.Button btnOdswiez;
        private System.Windows.Forms.Button btnEdytuj;
        private System.Windows.Forms.Button btnWyczyśćFiltry;
        private System.Windows.Forms.TextBox txtFiltrImie;
        private System.Windows.Forms.TextBox txtFiltrNazwisko;
        private System.Windows.Forms.TextBox txtFiltrPesel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnZapomniani;
        private System.Windows.Forms.Button btnZapomnij;
    }
}