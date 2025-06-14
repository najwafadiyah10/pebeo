namespace pebeo.Dashboard
{
    partial class DashboardWarga
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
            panel1 = new Panel();
            panel2 = new Panel();
            label1 = new Label();
            btnlihatjadwal = new Button();
            btnsetorjadwal = new Button();
            btncek = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(btncek);
            panel1.Controls.Add(btnsetorjadwal);
            panel1.Controls.Add(btnlihatjadwal);
            panel1.Location = new Point(1, -1);
            panel1.Name = "panel1";
            panel1.Size = new Size(322, 676);
            panel1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Controls.Add(label1);
            panel2.Location = new Point(324, -1);
            panel2.Name = "panel2";
            panel2.Size = new Size(739, 676);
            panel2.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(151, 62);
            label1.Name = "label1";
            label1.Size = new Size(353, 20);
            label1.TabIndex = 0;
            label1.Text = "SELAMAT ANDA BERHASIL LOGIN SEBAGAI WARGA";
            // 
            // btnlihatjadwal
            // 
            btnlihatjadwal.Location = new Point(72, 193);
            btnlihatjadwal.Name = "btnlihatjadwal";
            btnlihatjadwal.Size = new Size(184, 29);
            btnlihatjadwal.TabIndex = 0;
            btnlihatjadwal.Text = "LIHAT JADWAL";
            btnlihatjadwal.UseVisualStyleBackColor = true;
            // 
            // btnsetorjadwal
            // 
            btnsetorjadwal.Location = new Point(72, 331);
            btnsetorjadwal.Name = "btnsetorjadwal";
            btnsetorjadwal.Size = new Size(184, 29);
            btnsetorjadwal.TabIndex = 1;
            btnsetorjadwal.Text = "SETOR SAMPAH";
            btnsetorjadwal.UseVisualStyleBackColor = true;
            // 
            // btncek
            // 
            btncek.Location = new Point(72, 481);
            btncek.Name = "btncek";
            btncek.Size = new Size(184, 29);
            btncek.TabIndex = 2;
            btncek.Text = "CEK STATUS SAMPAH";
            btncek.UseVisualStyleBackColor = true;
            // 
            // DashboardWarga
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1063, 677);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "DashboardWarga";
            Text = "DashboardWarga";
            Load += DashboardWarga_Load;
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Button btncek;
        private Button btnsetorjadwal;
        private Button btnlihatjadwal;
        private Label label1;
    }
}