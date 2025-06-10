namespace pebeo.View
{
    partial class Register
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Register));
            pictureBox1 = new PictureBox();
            txtNama = new TextBox();
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            txtTelepon = new TextBox();
            btnregister = new Button();
            linkLabel1 = new LinkLabel();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.Location = new Point(-39, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1154, 741);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // txtNama
            // 
            txtNama.BackColor = Color.DarkSeaGreen;
            txtNama.Location = new Point(312, 314);
            txtNama.Name = "txtNama";
            txtNama.Size = new Size(382, 27);
            txtNama.TabIndex = 1;
            // 
            // txtUsername
            // 
            txtUsername.BackColor = Color.DarkSeaGreen;
            txtUsername.Location = new Point(312, 388);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(382, 27);
            txtUsername.TabIndex = 2;
            txtUsername.TextChanged += textBox2_TextChanged;
            // 
            // txtPassword
            // 
            txtPassword.BackColor = Color.DarkSeaGreen;
            txtPassword.Location = new Point(312, 475);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(382, 27);
            txtPassword.TabIndex = 3;
            txtPassword.TextChanged += textBox3_TextChanged;
            // 
            // txtTelepon
            // 
            txtTelepon.BackColor = Color.DarkSeaGreen;
            txtTelepon.Location = new Point(312, 551);
            txtTelepon.Name = "txtTelepon";
            txtTelepon.Size = new Size(382, 27);
            txtTelepon.TabIndex = 4;
            txtTelepon.TextChanged += textBox4_TextChanged;
            // 
            // btnregister
            // 
            btnregister.BackColor = Color.Transparent;
            btnregister.BackgroundImage = (Image)resources.GetObject("btnregister.BackgroundImage");
            btnregister.BackgroundImageLayout = ImageLayout.Zoom;
            btnregister.FlatAppearance.BorderSize = 0;
            btnregister.FlatStyle = FlatStyle.Flat;
            btnregister.ForeColor = Color.Transparent;
            btnregister.Location = new Point(462, 601);
            btnregister.Name = "btnregister";
            btnregister.Size = new Size(143, 48);
            btnregister.TabIndex = 5;
            btnregister.TextImageRelation = TextImageRelation.TextAboveImage;
            btnregister.UseVisualStyleBackColor = false;
            btnregister.Click += btnregister_Click;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.BackColor = Color.Transparent;
            linkLabel1.CausesValidation = false;
            linkLabel1.DisabledLinkColor = Color.Lime;
            linkLabel1.Font = new Font("Rockwell", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            linkLabel1.ForeColor = Color.Black;
            linkLabel1.LinkColor = Color.FromArgb(128, 255, 128);
            linkLabel1.Location = new Point(600, 672);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(71, 26);
            linkLabel1.TabIndex = 7;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Login";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // Register
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1113, 749);
            Controls.Add(linkLabel1);
            Controls.Add(btnregister);
            Controls.Add(txtTelepon);
            Controls.Add(txtPassword);
            Controls.Add(txtUsername);
            Controls.Add(txtNama);
            Controls.Add(pictureBox1);
            Name = "Register";
            Text = "Register";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private TextBox txtNama;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private TextBox txtTelepon;
        private Button btnregister;
        private LinkLabel linkLabel1;
    }
}