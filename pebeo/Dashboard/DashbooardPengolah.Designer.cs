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
            button1 = new Button();
            btneditjadwal = new Button();
            btnupadate = new Button();
            panel2 = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackgroundImage = (Image)resources.GetObject("panel1.BackgroundImage");
            panel1.BackgroundImageLayout = ImageLayout.Zoom;
            panel1.Controls.Add(button1);
            panel1.Controls.Add(btneditjadwal);
            panel1.Controls.Add(btnupadate);
            panel1.Location = new Point(0, -1);
            panel1.Name = "panel1";
            panel1.Size = new Size(282, 667);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            // 
            // button1
            // 
            button1.BackColor = Color.Transparent;
            button1.BackgroundImage = (Image)resources.GetObject("button1.BackgroundImage");
            button1.BackgroundImageLayout = ImageLayout.Zoom;
            button1.CausesValidation = false;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.ForeColor = Color.Transparent;
            button1.Location = new Point(56, 228);
            button1.Name = "button1";
            button1.Size = new Size(192, 64);
            button1.TabIndex = 1;
            button1.Text = "       LIHAT DATA SETOR";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // btneditjadwal
            // 
            btneditjadwal.BackColor = Color.Transparent;
            btneditjadwal.BackgroundImage = (Image)resources.GetObject("btneditjadwal.BackgroundImage");
            btneditjadwal.BackgroundImageLayout = ImageLayout.Zoom;
            btneditjadwal.FlatAppearance.BorderSize = 0;
            btneditjadwal.FlatStyle = FlatStyle.Flat;
            btneditjadwal.ForeColor = Color.Transparent;
            btneditjadwal.Location = new Point(56, 136);
            btneditjadwal.Name = "btneditjadwal";
            btneditjadwal.Size = new Size(192, 95);
            btneditjadwal.TabIndex = 0;
            btneditjadwal.Text = "         EDIT JADWAL";
            btneditjadwal.UseVisualStyleBackColor = false;
            btneditjadwal.Click += btneditjadwal_Click;
            // 
            // btnupadate
            // 
            btnupadate.BackColor = Color.Transparent;
            btnupadate.BackgroundImage = (Image)resources.GetObject("btnupadate.BackgroundImage");
            btnupadate.BackgroundImageLayout = ImageLayout.Zoom;
            btnupadate.FlatAppearance.BorderSize = 0;
            btnupadate.FlatStyle = FlatStyle.Flat;
            btnupadate.ForeColor = Color.White;
            btnupadate.Location = new Point(56, 309);
            btnupadate.Name = "btnupadate";
            btnupadate.Size = new Size(192, 56);
            btnupadate.TabIndex = 2;
            btnupadate.Text = "    UPDATE  STATUS";
            btnupadate.UseVisualStyleBackColor = false;
            btnupadate.Click += btnupadate_Click;
            // 
            // panel2
            // 
            panel2.BackgroundImage = (Image)resources.GetObject("panel2.BackgroundImage");
            panel2.BackgroundImageLayout = ImageLayout.Zoom;
            panel2.Location = new Point(277, -9);
            panel2.Name = "panel2";
            panel2.Size = new Size(755, 675);
            panel2.TabIndex = 1;
            panel2.Paint += panel2_Paint;
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
            Load += DashbooardPengolah_Load;
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Button button1;
        private Button btnupadate;
        private Button btneditjadwal;
    }
}