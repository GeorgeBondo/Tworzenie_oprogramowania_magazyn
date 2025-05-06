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
            this.dataGridViewUprawnienia.Location = new System.Drawing.Point(12, 116);
            this.dataGridViewUprawnienia.Name = "dataGridViewUprawnienia";
            this.dataGridViewUprawnienia.RowHeadersWidth = 51;
            this.dataGridViewUprawnienia.Size = new System.Drawing.Size(776, 322);
            this.dataGridViewUprawnienia.TabIndex = 0;
            // 
            // btnWrocUpr
            // 
            this.btnWrocUpr.BackColor = System.Drawing.Color.White;
            this.btnWrocUpr.Location = new System.Drawing.Point(713, 12);
            this.btnWrocUpr.Name = "btnWrocUpr";
            this.btnWrocUpr.Size = new System.Drawing.Size(75, 23);
            this.btnWrocUpr.TabIndex = 1;
            this.btnWrocUpr.Text = "Wróć";
            this.btnWrocUpr.UseVisualStyleBackColor = false;
            this.btnWrocUpr.Click += new System.EventHandler(this.btnWrocUpr_Click);
            // 
            // BtnInfo
            // 
            this.BtnInfo.Location = new System.Drawing.Point(678, 49);
            this.BtnInfo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.BtnInfo.Name = "BtnInfo";
            this.BtnInfo.Size = new System.Drawing.Size(110, 30);
            this.BtnInfo.TabIndex = 2;
            this.BtnInfo.Text = "Nadaj uprawnienia";
            this.BtnInfo.UseVisualStyleBackColor = true;
            this.BtnInfo.Click += new System.EventHandler(this.BtnInfo_Click);
            // 
            // ListaUprawnien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Salmon;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BtnInfo);
            this.Controls.Add(this.btnWrocUpr);
            this.Controls.Add(this.dataGridViewUprawnienia);
            this.Name = "ListaUprawnien";
            this.Text = "Lista Uprawnień";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUprawnienia)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewUprawnienia;
        private System.Windows.Forms.Button btnWrocUpr;
        private System.Windows.Forms.Button BtnInfo;
    }
}