namespace pebeo.User_Control
{
    partial class Jenis
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            btnsimpan = new Button();
            tbdeskripsi = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(39, 131);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(415, 301);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // btnsimpan
            // 
            btnsimpan.Location = new Point(360, 83);
            btnsimpan.Name = "btnsimpan";
            btnsimpan.Size = new Size(94, 29);
            btnsimpan.TabIndex = 1;
            btnsimpan.Text = "SIMPAN";
            btnsimpan.UseVisualStyleBackColor = true;
            btnsimpan.Click += btnsimpan_Click;
            // 
            // tbdeskripsi
            // 
            tbdeskripsi.Location = new Point(41, 449);
            tbdeskripsi.Name = "tbdeskripsi";
            tbdeskripsi.Size = new Size(413, 27);
            tbdeskripsi.TabIndex = 2;
            tbdeskripsi.TextChanged += tbdeskripsi_TextChanged;
            // 
            // Jenis
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tbdeskripsi);
            Controls.Add(btnsimpan);
            Controls.Add(dataGridView1);
            Name = "Jenis";
            Size = new Size(528, 618);
            Load += Jenis_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Button btnsimpan;
        private TextBox tbdeskripsi;
    }
}
