namespace Magazyn
{
    partial class ZapomnianiUzytkownicy
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
            this.components = new System.ComponentModel.Container();
            this.dataGridViewZapomniani = new System.Windows.Forms.DataGridView();
            this.magazynDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.magazynDataSet = new Magazyn.magazynDataSet();
            this.btnPowrot = new System.Windows.Forms.Button();
            this.txtFiltrImie = new System.Windows.Forms.TextBox();
            this.txtFiltrNazwisko = new System.Windows.Forms.TextBox();
            this.txtFiltrPesel = new System.Windows.Forms.TextBox();
            this.btnWyczyscFiltry = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewZapomniani)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.magazynDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.magazynDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewZapomniani
            // 
            this.dataGridViewZapomniani.AutoGenerateColumns = false;
            this.dataGridViewZapomniani.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewZapomniani.DataSource = this.magazynDataSetBindingSource;
<<<<<<< HEAD
            this.dataGridViewZapomniani.Location = new System.Drawing.Point(12, 207);
            this.dataGridViewZapomniani.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridViewZapomniani.Name = "dataGridViewZapomniani";
            this.dataGridViewZapomniani.RowHeadersWidth = 51;
            this.dataGridViewZapomniani.RowTemplate.Height = 24;
            this.dataGridViewZapomniani.Size = new System.Drawing.Size(957, 331);
=======
            this.dataGridViewZapomniani.Location = new System.Drawing.Point(9, 168);
            this.dataGridViewZapomniani.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridViewZapomniani.Name = "dataGridViewZapomniani";
            this.dataGridViewZapomniani.RowHeadersWidth = 51;
            this.dataGridViewZapomniani.RowTemplate.Height = 24;
            this.dataGridViewZapomniani.Size = new System.Drawing.Size(718, 269);
>>>>>>> e003832b87d69f661b4b9bc824d6ec988cbe8ed5
            this.dataGridViewZapomniani.TabIndex = 0;
            // 
            // magazynDataSetBindingSource
            // 
            this.magazynDataSetBindingSource.DataSource = this.magazynDataSet;
            this.magazynDataSetBindingSource.Position = 0;
            // 
            // magazynDataSet
            // 
            this.magazynDataSet.DataSetName = "magazynDataSet";
            this.magazynDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnPowrot
            // 
<<<<<<< HEAD
            this.btnPowrot.Location = new System.Drawing.Point(889, 14);
            this.btnPowrot.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPowrot.Name = "btnPowrot";
            this.btnPowrot.Size = new System.Drawing.Size(75, 31);
=======
            this.btnPowrot.Location = new System.Drawing.Point(667, 11);
            this.btnPowrot.Margin = new System.Windows.Forms.Padding(2);
            this.btnPowrot.Name = "btnPowrot";
            this.btnPowrot.Size = new System.Drawing.Size(56, 25);
>>>>>>> e003832b87d69f661b4b9bc824d6ec988cbe8ed5
            this.btnPowrot.TabIndex = 1;
            this.btnPowrot.Text = "wróć";
            this.btnPowrot.UseVisualStyleBackColor = true;
            this.btnPowrot.Click += new System.EventHandler(this.btnPowrot_Click_1);
            // 
            // txtFiltrImie
            // 
<<<<<<< HEAD
            this.txtFiltrImie.Location = new System.Drawing.Point(236, 167);
            this.txtFiltrImie.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
=======
            this.txtFiltrImie.Location = new System.Drawing.Point(177, 136);
            this.txtFiltrImie.Margin = new System.Windows.Forms.Padding(2);
>>>>>>> e003832b87d69f661b4b9bc824d6ec988cbe8ed5
            this.txtFiltrImie.Name = "txtFiltrImie";
            this.txtFiltrImie.Size = new System.Drawing.Size(76, 20);
            this.txtFiltrImie.TabIndex = 2;
            // 
            // txtFiltrNazwisko
            // 
<<<<<<< HEAD
            this.txtFiltrNazwisko.Location = new System.Drawing.Point(368, 167);
            this.txtFiltrNazwisko.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
=======
            this.txtFiltrNazwisko.Location = new System.Drawing.Point(276, 136);
            this.txtFiltrNazwisko.Margin = new System.Windows.Forms.Padding(2);
>>>>>>> e003832b87d69f661b4b9bc824d6ec988cbe8ed5
            this.txtFiltrNazwisko.Name = "txtFiltrNazwisko";
            this.txtFiltrNazwisko.Size = new System.Drawing.Size(76, 20);
            this.txtFiltrNazwisko.TabIndex = 3;
            // 
            // txtFiltrPesel
            // 
<<<<<<< HEAD
            this.txtFiltrPesel.Location = new System.Drawing.Point(497, 167);
            this.txtFiltrPesel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
=======
            this.txtFiltrPesel.Location = new System.Drawing.Point(373, 136);
            this.txtFiltrPesel.Margin = new System.Windows.Forms.Padding(2);
>>>>>>> e003832b87d69f661b4b9bc824d6ec988cbe8ed5
            this.txtFiltrPesel.Name = "txtFiltrPesel";
            this.txtFiltrPesel.Size = new System.Drawing.Size(76, 20);
            this.txtFiltrPesel.TabIndex = 4;
            // 
            // btnWyczyscFiltry
            // 
<<<<<<< HEAD
            this.btnWyczyscFiltry.Location = new System.Drawing.Point(828, 167);
            this.btnWyczyscFiltry.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnWyczyscFiltry.Name = "btnWyczyscFiltry";
            this.btnWyczyscFiltry.Size = new System.Drawing.Size(136, 34);
=======
            this.btnWyczyscFiltry.Location = new System.Drawing.Point(621, 136);
            this.btnWyczyscFiltry.Margin = new System.Windows.Forms.Padding(2);
            this.btnWyczyscFiltry.Name = "btnWyczyscFiltry";
            this.btnWyczyscFiltry.Size = new System.Drawing.Size(102, 28);
>>>>>>> e003832b87d69f661b4b9bc824d6ec988cbe8ed5
            this.btnWyczyscFiltry.TabIndex = 5;
            this.btnWyczyscFiltry.Text = "Wyczyść filtry";
            this.btnWyczyscFiltry.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
<<<<<<< HEAD
            this.label1.Location = new System.Drawing.Point(267, 149);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 16);
=======
            this.label1.Location = new System.Drawing.Point(200, 121);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
>>>>>>> e003832b87d69f661b4b9bc824d6ec988cbe8ed5
            this.label1.TabIndex = 6;
            this.label1.Text = "Imię:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
<<<<<<< HEAD
            this.label2.Location = new System.Drawing.Point(379, 149);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 16);
=======
            this.label2.Location = new System.Drawing.Point(284, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
>>>>>>> e003832b87d69f661b4b9bc824d6ec988cbe8ed5
            this.label2.TabIndex = 7;
            this.label2.Text = "Nazwisko:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
<<<<<<< HEAD
            this.label3.Location = new System.Drawing.Point(520, 149);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 16);
=======
            this.label3.Location = new System.Drawing.Point(390, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
>>>>>>> e003832b87d69f661b4b9bc824d6ec988cbe8ed5
            this.label3.TabIndex = 8;
            this.label3.Text = "PESEL:";
            // 
            // ZapomnianiUzytkownicy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Salmon;
<<<<<<< HEAD
            this.ClientSize = new System.Drawing.Size(979, 545);
=======
            this.ClientSize = new System.Drawing.Size(734, 443);
>>>>>>> e003832b87d69f661b4b9bc824d6ec988cbe8ed5
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnWyczyscFiltry);
            this.Controls.Add(this.txtFiltrPesel);
            this.Controls.Add(this.txtFiltrNazwisko);
            this.Controls.Add(this.txtFiltrImie);
            this.Controls.Add(this.btnPowrot);
            this.Controls.Add(this.dataGridViewZapomniani);
<<<<<<< HEAD
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
=======
            this.Margin = new System.Windows.Forms.Padding(2);
>>>>>>> e003832b87d69f661b4b9bc824d6ec988cbe8ed5
            this.Name = "ZapomnianiUzytkownicy";
            this.Text = "Zapomniani Użytkownicy";
            this.Load += new System.EventHandler(this.ZapomnianiUzytkownicy_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewZapomniani)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.magazynDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.magazynDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewZapomniani;
        private System.Windows.Forms.BindingSource magazynDataSetBindingSource;
        private magazynDataSet magazynDataSet;
        private System.Windows.Forms.Button btnPowrot;
        private System.Windows.Forms.TextBox txtFiltrImie;
        private System.Windows.Forms.TextBox txtFiltrNazwisko;
        private System.Windows.Forms.TextBox txtFiltrPesel;
        private System.Windows.Forms.Button btnWyczyscFiltry;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}