namespace pebeo.Dashboard
{
    partial class DashbooardPengolah
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DashbooardPengolah));
            panel1 = new Panel();
            btnupadate = new Button();
            button1 = new Button();
            btneditjadwal = new Button();
            panel2 = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackgroundImage = (Image)resources.GetObject("panel1.BackgroundImage");
            panel1.BackgroundImageLayout = ImageLayout.Zoom;
            panel1.Controls.Add(btnupadate);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(btneditjadwal);
            panel1.Location = new Point(0, -1);
            panel1.Name = "panel1";
            panel1.Size = new Size(284, 667);
            panel1.TabIndex = 0;
            // 
            // btnupadate
            // 
            btnupadate.Location = new Point(106, 324);
            btnupadate.Name = "btnupadate";
            btnupadate.Size = new Size(94, 29);
            btnupadate.TabIndex = 2;
            btnupadate.Text = "update status";
            btnupadate.UseVisualStyleBackColor = true;
            btnupadate.Click += btnupadate_Click;
            // 
            // button1
            // 
            button1.Location = new Point(86, 244);
            button1.Name = "button1";
            button1.Size = new Size(137, 29);
            button1.TabIndex = 1;
            button1.Text = "lihat data setor";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // btneditjadwal
            // 
            btneditjadwal.Location = new Point(72, 170);
            btneditjadwal.Name = "btneditjadwal";
            btneditjadwal.Size = new Size(151, 29);
            btneditjadwal.TabIndex = 0;
            btneditjadwal.Text = "edit jadwal";
            btneditjadwal.UseVisualStyleBackColor = true;
            btneditjadwal.Click += btneditjadwal_Click;
            // 
            // panel2
            // 
            panel2.BackgroundImage = (Image)resources.GetObject("panel2.BackgroundImage");
            panel2.BackgroundImageLayout = ImageLayout.Zoom;
            panel2.Location = new Point(278, -1);
            panel2.Name = "panel2";
            panel2.Size = new Size(754, 667);
            panel2.TabIndex = 1;
            // 
            // DashbooardPengolah
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1030, 663);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "DashbooardPengolah";
            Text = "DashbooardPengolah";
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Button btneditjadwal;
        private Button button1;
        private Button btnupadate;
    }
}