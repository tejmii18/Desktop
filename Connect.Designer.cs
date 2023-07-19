namespace DesktopAppAtemMini
{
    partial class Connect
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Connect));
            ipAdresa = new TextBox();
            label1 = new Label();
            b_connect = new Button();
            pictureBox1 = new PictureBox();
            menuStrip1 = new MenuStrip();
            oAplikaciToolStripMenuItem = new ToolStripMenuItem();
            nápovědaToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // ipAdresa
            // 
            ipAdresa.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            ipAdresa.Location = new Point(234, 268);
            ipAdresa.Margin = new Padding(4, 3, 4, 3);
            ipAdresa.Name = "ipAdresa";
            ipAdresa.Size = new Size(212, 29);
            ipAdresa.TabIndex = 0;
            ipAdresa.TextAlign = HorizontalAlignment.Center;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(205, 223);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(236, 25);
            label1.TabIndex = 1;
            label1.Text = "ATEM Mini Controller";
            // 
            // b_connect
            // 
            b_connect.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point);
            b_connect.Location = new Point(266, 314);
            b_connect.Margin = new Padding(4, 3, 4, 3);
            b_connect.Name = "b_connect";
            b_connect.Size = new Size(150, 45);
            b_connect.TabIndex = 2;
            b_connect.Text = "Připojit";
            b_connect.UseVisualStyleBackColor = true;
            b_connect.Click += b_connect_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.InitialImage = (Image)resources.GetObject("pictureBox1.InitialImage");
            pictureBox1.Location = new Point(166, 31);
            pictureBox1.Margin = new Padding(4, 3, 4, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(354, 188);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { oAplikaciToolStripMenuItem, nápovědaToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(7, 2, 0, 2);
            menuStrip1.Size = new Size(685, 24);
            menuStrip1.TabIndex = 4;
            menuStrip1.Text = "menuStrip1";
            // 
            // oAplikaciToolStripMenuItem
            // 
            oAplikaciToolStripMenuItem.Name = "oAplikaciToolStripMenuItem";
            oAplikaciToolStripMenuItem.Size = new Size(71, 20);
            oAplikaciToolStripMenuItem.Text = "O aplikaci";
            oAplikaciToolStripMenuItem.Click += oAplikaciToolStripMenuItem_Click;
            // 
            // nápovědaToolStripMenuItem
            // 
            nápovědaToolStripMenuItem.Name = "nápovědaToolStripMenuItem";
            nápovědaToolStripMenuItem.Size = new Size(73, 20);
            nápovědaToolStripMenuItem.Text = "Nápověda";
            nápovědaToolStripMenuItem.Click += nápovědaToolStripMenuItem_Click;
            // 
            // Connect
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDarkDark;
            ClientSize = new Size(685, 374);
            Controls.Add(pictureBox1);
            Controls.Add(b_connect);
            Controls.Add(label1);
            Controls.Add(ipAdresa);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MainMenuStrip = menuStrip1;
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Connect";
            Text = "Připojení";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox ipAdresa;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button b_connect;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem oAplikaciToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nápovědaToolStripMenuItem;
    }
}

