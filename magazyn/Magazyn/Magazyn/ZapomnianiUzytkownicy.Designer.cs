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
            this.dataGridViewZapomniani.Location = new System.Drawing.Point(12, 207);
            this.dataGridViewZapomniani.Name = "dataGridViewZapomniani";
            this.dataGridViewZapomniani.RowHeadersWidth = 51;
            this.dataGridViewZapomniani.RowTemplate.Height = 24;
            this.dataGridViewZapomniani.Size = new System.Drawing.Size(1244, 331);
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
            this.btnPowrot.Location = new System.Drawing.Point(682, 47);
            this.btnPowrot.Name = "btnPowrot";
            this.btnPowrot.Size = new System.Drawing.Size(75, 23);
            this.btnPowrot.TabIndex = 1;
            this.btnPowrot.Text = "wróć";
            this.btnPowrot.UseVisualStyleBackColor = true;
            this.btnPowrot.Click += new System.EventHandler(this.btnPowrot_Click_1);
            // 
            // txtFiltrImie
            // 
            this.txtFiltrImie.Location = new System.Drawing.Point(105, 136);
            this.txtFiltrImie.Name = "txtFiltrImie";
            this.txtFiltrImie.Size = new System.Drawing.Size(100, 22);
            this.txtFiltrImie.TabIndex = 2;
            // 
            // txtFiltrNazwisko
            // 
            this.txtFiltrNazwisko.Location = new System.Drawing.Point(290, 135);
            this.txtFiltrNazwisko.Name = "txtFiltrNazwisko";
            this.txtFiltrNazwisko.Size = new System.Drawing.Size(100, 22);
            this.txtFiltrNazwisko.TabIndex = 3;
            // 
            // txtFiltrPesel
            // 
            this.txtFiltrPesel.Location = new System.Drawing.Point(478, 135);
            this.txtFiltrPesel.Name = "txtFiltrPesel";
            this.txtFiltrPesel.Size = new System.Drawing.Size(100, 22);
            this.txtFiltrPesel.TabIndex = 4;
            // 
            // btnWyczyscFiltry
            // 
            this.btnWyczyscFiltry.Location = new System.Drawing.Point(621, 136);
            this.btnWyczyscFiltry.Name = "btnWyczyscFiltry";
            this.btnWyczyscFiltry.Size = new System.Drawing.Size(136, 23);
            this.btnWyczyscFiltry.TabIndex = 5;
            this.btnWyczyscFiltry.Text = "Wyczyść filtry";
            this.btnWyczyscFiltry.UseVisualStyleBackColor = true;
            // 
            // ZapomnianiUzytkownicy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1268, 550);
            this.Controls.Add(this.btnWyczyscFiltry);
            this.Controls.Add(this.txtFiltrPesel);
            this.Controls.Add(this.txtFiltrNazwisko);
            this.Controls.Add(this.txtFiltrImie);
            this.Controls.Add(this.btnPowrot);
            this.Controls.Add(this.dataGridViewZapomniani);
            this.Name = "ZapomnianiUzytkownicy";
            this.Text = "ZapomnianiUzytkownicy";
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
    }
}