﻿namespace pebeo
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
            linkregis = new LinkLabel();
            pbbackground = new PictureBox();
            pictureBox4 = new PictureBox();
            tbusername = new TextBox();
            tbpassword = new TextBox();
            btnloginn = new Button();
            ((System.ComponentModel.ISupportInitialize)pbbackground).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            SuspendLayout();
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
            linkregis.LinkClicked += linkregis_LinkClicked;
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
            // btnloginn
            // 
            btnloginn.Location = new Point(472, 495);
            btnloginn.Name = "btnloginn";
            btnloginn.Size = new Size(152, 59);
            btnloginn.TabIndex = 13;
            btnloginn.Text = "login";
            btnloginn.UseVisualStyleBackColor = true;
            btnloginn.Click += btnloginn_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Zoom;
            ClientSize = new Size(1128, 716);
            Controls.Add(btnloginn);
            Controls.Add(tbpassword);
            Controls.Add(tbusername);
            Controls.Add(linkregis);
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
        private LinkLabel linkregis;
        private PictureBox pbbackground;
        private PictureBox pictureBox4;
        private TextBox tbusername;
        private TextBox tbpassword;
        private Button btnloginn;
    }
}
