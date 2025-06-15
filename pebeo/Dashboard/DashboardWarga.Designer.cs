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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DashboardWarga));
            panel1 = new Panel();
            btncek = new Button();
            btnsetorjadwal = new Button();
            btnlihatjadwal = new Button();
            panel2 = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackgroundImage = (Image)resources.GetObject("panel1.BackgroundImage");
            panel1.BackgroundImageLayout = ImageLayout.Zoom;
            panel1.Controls.Add(btncek);
            panel1.Controls.Add(btnsetorjadwal);
            panel1.Controls.Add(btnlihatjadwal);
            panel1.Location = new Point(1, -3);
            panel1.Name = "panel1";
            panel1.Size = new Size(287, 678);
            panel1.TabIndex = 0;
            // 
            // btncek
            // 
            btncek.Location = new Point(72, 327);
            btncek.Name = "btncek";
            btncek.Size = new Size(154, 29);
            btncek.TabIndex = 2;
            btncek.Text = "CEK STATUS SAMPAH";
            btncek.UseVisualStyleBackColor = true;
            // 
            // btnsetorjadwal
            // 
            btnsetorjadwal.Location = new Point(72, 251);
            btnsetorjadwal.Name = "btnsetorjadwal";
            btnsetorjadwal.Size = new Size(154, 29);
            btnsetorjadwal.TabIndex = 1;
            btnsetorjadwal.Text = "SETOR SAMPAH";
            btnsetorjadwal.UseVisualStyleBackColor = true;
            btnsetorjadwal.Click += btnsetorjadwal_Click;
            // 
            // btnlihatjadwal
            // 
            btnlihatjadwal.BackColor = Color.Transparent;
            btnlihatjadwal.ForeColor = Color.Transparent;
            btnlihatjadwal.Location = new Point(72, 172);
            btnlihatjadwal.Name = "btnlihatjadwal";
            btnlihatjadwal.Size = new Size(154, 29);
            btnlihatjadwal.TabIndex = 0;
            btnlihatjadwal.UseVisualStyleBackColor = false;
            btnlihatjadwal.Click += btnlihatjadwal_Click;
            // 
            // panel2
            // 
            panel2.BackgroundImage = (Image)resources.GetObject("panel2.BackgroundImage");
            panel2.BackgroundImageLayout = ImageLayout.Zoom;
            panel2.Location = new Point(263, 2);
            panel2.Name = "panel2";
            panel2.Size = new Size(800, 673);
            panel2.TabIndex = 1;
            panel2.Paint += panel2_Paint;
            // 
            // DashboardWarga
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1041, 666);
            Controls.Add(panel1);
            Controls.Add(panel2);
            Name = "DashboardWarga";
            Text = "DashboardWarga";
            Load += DashboardWarga_Load;
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Button btncek;
        private Button btnsetorjadwal;
        private Button btnlihatjadwal;
    }
}