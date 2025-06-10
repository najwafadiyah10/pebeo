namespace pebeo
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            btnlogin = new Button();
            linkregis = new LinkLabel();
            pbbackground = new PictureBox();
            pictureBox4 = new PictureBox();
            tbusername = new TextBox();
            tbpassword = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pbbackground).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            SuspendLayout();
            // 
            // btnlogin
            // 
            btnlogin.AutoEllipsis = true;
            btnlogin.BackColor = Color.Transparent;
            btnlogin.BackgroundImage = Properties.Resources.Frame_2;
            btnlogin.BackgroundImageLayout = ImageLayout.Zoom;
            btnlogin.FlatAppearance.BorderSize = 0;
            btnlogin.FlatStyle = FlatStyle.Flat;
            btnlogin.ForeColor = Color.Transparent;
            btnlogin.Location = new Point(472, 477);
            btnlogin.Name = "btnlogin";
            btnlogin.Size = new Size(140, 71);
            btnlogin.TabIndex = 1;
            btnlogin.TextImageRelation = TextImageRelation.TextAboveImage;
            btnlogin.UseVisualStyleBackColor = false;
            btnlogin.Click += button1_Click;
            // 
            // linkregis
            // 
            linkregis.AutoSize = true;
            linkregis.BackColor = Color.Transparent;
            linkregis.Font = new Font("Rockwell", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            linkregis.LinkColor = Color.FromArgb(128, 255, 128);
            linkregis.Location = new Point(588, 658);
            linkregis.Name = "linkregis";
            linkregis.Size = new Size(107, 28);
            linkregis.TabIndex = 3;
            linkregis.TabStop = true;
            linkregis.Text = "Register";
            linkregis.LinkClicked += this.linkregis_LinkClicked;
            // 
            // pbbackground
            // 
            pbbackground.BackColor = Color.Transparent;
            pbbackground.BackgroundImageLayout = ImageLayout.Zoom;
            pbbackground.Image = (Image)resources.GetObject("pbbackground.Image");
            pbbackground.Location = new Point(-26, -3);
            pbbackground.Name = "pbbackground";
            pbbackground.Size = new Size(1189, 732);
            pbbackground.SizeMode = PictureBoxSizeMode.Zoom;
            pbbackground.TabIndex = 0;
            pbbackground.TabStop = false;
            pbbackground.Click += pictureBox1_Click;
            // 
            // pictureBox4
            // 
            pictureBox4.BackColor = Color.Transparent;
            pictureBox4.BackgroundImage = (Image)resources.GetObject("pictureBox4.BackgroundImage");
            pictureBox4.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox4.Location = new Point(261, 176);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(167, 40);
            pictureBox4.TabIndex = 10;
            pictureBox4.TabStop = false;
            pictureBox4.Click += pictureBox4_Click;
            // 
            // tbusername
            // 
            tbusername.BackColor = Color.DarkSeaGreen;
            tbusername.Location = new Point(356, 346);
            tbusername.Name = "tbusername";
            tbusername.Size = new Size(369, 27);
            tbusername.TabIndex = 11;
            // 
            // tbpassword
            // 
            tbpassword.BackColor = Color.DarkSeaGreen;
            tbpassword.Location = new Point(356, 444);
            tbpassword.Name = "tbpassword";
            tbpassword.Size = new Size(369, 27);
            tbpassword.TabIndex = 12;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Zoom;
            ClientSize = new Size(1128, 716);
            Controls.Add(tbpassword);
            Controls.Add(tbusername);
            Controls.Add(linkregis);
            Controls.Add(btnlogin);
            Controls.Add(pbbackground);
            Controls.Add(pictureBox4);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pbbackground).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnlogin;
        private LinkLabel linkregis;
        private PictureBox pbbackground;
        private PictureBox pictureBox4;
        private TextBox tbusername;
        private TextBox tbpassword;
    }
}
