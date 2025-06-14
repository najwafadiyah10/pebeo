namespace pebeo.View
{
    partial class RegisterAlamat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegisterAlamat));
            pictureBox1 = new PictureBox();
            cbdusun = new ComboBox();
            btnregister = new Button();
            cbjalan = new ComboBox();
            cbnorumah = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.Location = new Point(-36, -76);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1104, 740);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // cbdusun
            // 
            cbdusun.DropDownStyle = ComboBoxStyle.DropDownList;
            cbdusun.FormattingEnabled = true;
            cbdusun.Location = new Point(300, 233);
            cbdusun.Name = "cbdusun";
            cbdusun.Size = new Size(378, 28);
            cbdusun.TabIndex = 4;
            cbdusun.SelectedIndexChanged += cbrtrw_SelectedIndexChanged;
            // 
            // btnregister
            // 
            btnregister.BackColor = Color.Transparent;
            btnregister.BackgroundImage = (Image)resources.GetObject("btnregister.BackgroundImage");
            btnregister.BackgroundImageLayout = ImageLayout.Zoom;
            btnregister.FlatStyle = FlatStyle.Flat;
            btnregister.ForeColor = Color.Transparent;
            btnregister.Location = new Point(420, 459);
            btnregister.Name = "btnregister";
            btnregister.Size = new Size(137, 46);
            btnregister.TabIndex = 5;
            btnregister.UseVisualStyleBackColor = false;
            btnregister.Click += btnregister_Click;
            // 
            // cbjalan
            // 
            cbjalan.FormattingEnabled = true;
            cbjalan.Location = new Point(296, 308);
            cbjalan.Name = "cbjalan";
            cbjalan.Size = new Size(382, 28);
            cbjalan.TabIndex = 6;
            cbjalan.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // cbnorumah
            // 
            cbnorumah.FormattingEnabled = true;
            cbnorumah.Location = new Point(296, 394);
            cbnorumah.Name = "cbnorumah";
            cbnorumah.Size = new Size(378, 28);
            cbnorumah.TabIndex = 7;
            // 
            // RegisterAlamat
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1070, 656);
            Controls.Add(cbnorumah);
            Controls.Add(cbjalan);
            Controls.Add(btnregister);
            Controls.Add(cbdusun);
            Controls.Add(pictureBox1);
            Name = "RegisterAlamat";
            Text = "RegisterAlamat";
            Load += RegisterAlamat_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private ComboBox cbdusun;
        private Button btnregister;
        private ComboBox cbjalan;
        private ComboBox cbnorumah;
    }
}