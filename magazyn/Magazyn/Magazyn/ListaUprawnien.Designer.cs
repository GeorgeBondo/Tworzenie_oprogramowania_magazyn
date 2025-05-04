namespace Magazyn
{
    partial class ListaUprawnien
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
            this.dataGridViewUprawnienia = new System.Windows.Forms.DataGridView();
            this.btnWrocUpr = new System.Windows.Forms.Button();
            this.BtnInfo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUprawnienia)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewUprawnienia
            // 
            this.dataGridViewUprawnienia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewUprawnienia.Location = new System.Drawing.Point(16, 143);
            this.dataGridViewUprawnienia.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridViewUprawnienia.Name = "dataGridViewUprawnienia";
            this.dataGridViewUprawnienia.RowHeadersWidth = 51;
            this.dataGridViewUprawnienia.Size = new System.Drawing.Size(1035, 396);
            this.dataGridViewUprawnienia.TabIndex = 0;
            // 
            // btnWrocUpr
            // 
            this.btnWrocUpr.BackColor = System.Drawing.Color.White;
            this.btnWrocUpr.Location = new System.Drawing.Point(951, 15);
            this.btnWrocUpr.Margin = new System.Windows.Forms.Padding(4);
            this.btnWrocUpr.Name = "btnWrocUpr";
            this.btnWrocUpr.Size = new System.Drawing.Size(100, 28);
            this.btnWrocUpr.TabIndex = 1;
            this.btnWrocUpr.Text = "Wróć";
            this.btnWrocUpr.UseVisualStyleBackColor = false;
            this.btnWrocUpr.Click += new System.EventHandler(this.btnWrocUpr_Click);
            // 
            // BtnInfo
            // 
            this.BtnInfo.Location = new System.Drawing.Point(791, 60);
            this.BtnInfo.Name = "BtnInfo";
            this.BtnInfo.Size = new System.Drawing.Size(260, 37);
            this.BtnInfo.TabIndex = 2;
            this.BtnInfo.Text = "Informacje o uprawnieniach";
            this.BtnInfo.UseVisualStyleBackColor = true;
            this.BtnInfo.Click += new System.EventHandler(this.BtnInfo_Click);
            // 
            // ListaUprawnien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Salmon;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.BtnInfo);
            this.Controls.Add(this.btnWrocUpr);
            this.Controls.Add(this.dataGridViewUprawnienia);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ListaUprawnien";
            this.Text = "ListaUprawnien";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUprawnienia)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewUprawnienia;
        private System.Windows.Forms.Button btnWrocUpr;
        private System.Windows.Forms.Button BtnInfo;
    }
}