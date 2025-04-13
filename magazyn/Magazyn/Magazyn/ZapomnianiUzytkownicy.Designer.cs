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
            this.btnPowrot = new System.Windows.Forms.Button();
            this.txtFiltrId = new System.Windows.Forms.TextBox();
            this.btnWyczyscFiltry = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePickerFiltr = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewZapomniani)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.magazynDataSetBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewZapomniani
            // 
            this.dataGridViewZapomniani.AutoGenerateColumns = false;
            this.dataGridViewZapomniani.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewZapomniani.DataSource = this.magazynDataSetBindingSource;
            this.dataGridViewZapomniani.Location = new System.Drawing.Point(9, 168);
            this.dataGridViewZapomniani.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridViewZapomniani.Name = "dataGridViewZapomniani";
            this.dataGridViewZapomniani.RowHeadersWidth = 51;
            this.dataGridViewZapomniani.RowTemplate.Height = 24;
            this.dataGridViewZapomniani.Size = new System.Drawing.Size(718, 269);
            this.dataGridViewZapomniani.TabIndex = 0;
            // 
            // btnPowrot
            // 
            this.btnPowrot.Location = new System.Drawing.Point(667, 11);
            this.btnPowrot.Margin = new System.Windows.Forms.Padding(2);
            this.btnPowrot.Name = "btnPowrot";
            this.btnPowrot.Size = new System.Drawing.Size(56, 25);
            this.btnPowrot.TabIndex = 1;
            this.btnPowrot.Text = "wróć";
            this.btnPowrot.UseVisualStyleBackColor = true;
            this.btnPowrot.Click += new System.EventHandler(this.btnPowrot_Click_1);
            // 
            // txtFiltrId
            // 
            this.txtFiltrId.Location = new System.Drawing.Point(70, 144);
            this.txtFiltrId.Margin = new System.Windows.Forms.Padding(2);
            this.txtFiltrId.Name = "txtFiltrId";
            this.txtFiltrId.Size = new System.Drawing.Size(76, 20);
            this.txtFiltrId.TabIndex = 2;
            // 
            // btnWyczyscFiltry
            // 
            this.btnWyczyscFiltry.Location = new System.Drawing.Point(621, 136);
            this.btnWyczyscFiltry.Margin = new System.Windows.Forms.Padding(2);
            this.btnWyczyscFiltry.Name = "btnWyczyscFiltry";
            this.btnWyczyscFiltry.Size = new System.Drawing.Size(102, 28);
            this.btnWyczyscFiltry.TabIndex = 5;
            this.btnWyczyscFiltry.Text = "Wyczyść filtry";
            this.btnWyczyscFiltry.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(96, 126);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "ID:";
            // 
            // dateTimePickerFiltr
            // 
            this.dateTimePickerFiltr.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerFiltr.Location = new System.Drawing.Point(261, 144);
            this.dateTimePickerFiltr.Name = "dateTimePickerFiltr";
            this.dateTimePickerFiltr.ShowCheckBox = true;
            this.dateTimePickerFiltr.Size = new System.Drawing.Size(105, 20);
            this.dateTimePickerFiltr.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(271, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Data zapomnienia:";
            // 
            // ZapomnianiUzytkownicy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Salmon;
            this.ClientSize = new System.Drawing.Size(734, 443);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateTimePickerFiltr);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnWyczyscFiltry);
            this.Controls.Add(this.txtFiltrId);
            this.Controls.Add(this.btnPowrot);
            this.Controls.Add(this.dataGridViewZapomniani);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ZapomnianiUzytkownicy";
            this.Text = "Zapomniani Użytkownicy";
            this.Load += new System.EventHandler(this.ZapomnianiUzytkownicy_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewZapomniani)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.magazynDataSetBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewZapomniani;
        private System.Windows.Forms.BindingSource magazynDataSetBindingSource;

        private System.Windows.Forms.Button btnPowrot;
        private System.Windows.Forms.Button btnWyczyscFiltry;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtFiltrId;
        private System.Windows.Forms.DateTimePicker dateTimePickerFiltr;
        private System.Windows.Forms.Label label2;
    }
}