
namespace DiscordLeech
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.profilePictureBox = new System.Windows.Forms.PictureBox();
            this.devLabel = new System.Windows.Forms.Label();
            this.devBox = new System.Windows.Forms.TextBox();
            this.usernameBox = new System.Windows.Forms.TextBox();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.discriminatorBox = new System.Windows.Forms.TextBox();
            this.discriminatorLabel = new System.Windows.Forms.Label();
            this.mainStatusStrip = new System.Windows.Forms.StatusStrip();
            this.mainStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.profilePictureBox)).BeginInit();
            this.mainStatusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // profilePictureBox
            // 
            this.profilePictureBox.Image = global::DiscordLeech.Properties.Resources._default;
            this.profilePictureBox.Location = new System.Drawing.Point(104, 12);
            this.profilePictureBox.Name = "profilePictureBox";
            this.profilePictureBox.Size = new System.Drawing.Size(80, 80);
            this.profilePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.profilePictureBox.TabIndex = 0;
            this.profilePictureBox.TabStop = false;
            // 
            // devLabel
            // 
            this.devLabel.AutoSize = true;
            this.devLabel.Location = new System.Drawing.Point(13, 113);
            this.devLabel.Name = "devLabel";
            this.devLabel.Size = new System.Drawing.Size(73, 13);
            this.devLabel.TabIndex = 1;
            this.devLabel.Text = "Developer ID:";
            // 
            // devBox
            // 
            this.devBox.Location = new System.Drawing.Point(92, 110);
            this.devBox.Name = "devBox";
            this.devBox.ReadOnly = true;
            this.devBox.Size = new System.Drawing.Size(180, 20);
            this.devBox.TabIndex = 2;
            // 
            // usernameBox
            // 
            this.usernameBox.Location = new System.Drawing.Point(92, 136);
            this.usernameBox.Name = "usernameBox";
            this.usernameBox.ReadOnly = true;
            this.usernameBox.Size = new System.Drawing.Size(180, 20);
            this.usernameBox.TabIndex = 4;
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Location = new System.Drawing.Point(13, 139);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(58, 13);
            this.usernameLabel.TabIndex = 3;
            this.usernameLabel.Text = "Username:";
            // 
            // discriminatorBox
            // 
            this.discriminatorBox.Location = new System.Drawing.Point(92, 162);
            this.discriminatorBox.Name = "discriminatorBox";
            this.discriminatorBox.ReadOnly = true;
            this.discriminatorBox.Size = new System.Drawing.Size(180, 20);
            this.discriminatorBox.TabIndex = 6;
            // 
            // discriminatorLabel
            // 
            this.discriminatorLabel.AutoSize = true;
            this.discriminatorLabel.Location = new System.Drawing.Point(13, 165);
            this.discriminatorLabel.Name = "discriminatorLabel";
            this.discriminatorLabel.Size = new System.Drawing.Size(70, 13);
            this.discriminatorLabel.TabIndex = 5;
            this.discriminatorLabel.Text = "Discriminator:";
            // 
            // mainStatusStrip
            // 
            this.mainStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mainStatusLabel});
            this.mainStatusStrip.Location = new System.Drawing.Point(0, 211);
            this.mainStatusStrip.Name = "mainStatusStrip";
            this.mainStatusStrip.Size = new System.Drawing.Size(284, 22);
            this.mainStatusStrip.TabIndex = 7;
            this.mainStatusStrip.Text = "statusStrip1";
            // 
            // mainStatusLabel
            // 
            this.mainStatusLabel.Name = "mainStatusLabel";
            this.mainStatusLabel.Size = new System.Drawing.Size(70, 17);
            this.mainStatusLabel.Text = "Initializing...";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 233);
            this.Controls.Add(this.mainStatusStrip);
            this.Controls.Add(this.discriminatorBox);
            this.Controls.Add(this.discriminatorLabel);
            this.Controls.Add(this.usernameBox);
            this.Controls.Add(this.usernameLabel);
            this.Controls.Add(this.devBox);
            this.Controls.Add(this.devLabel);
            this.Controls.Add(this.profilePictureBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(300, 272);
            this.MinimumSize = new System.Drawing.Size(300, 272);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DiscordLeech";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.profilePictureBox)).EndInit();
            this.mainStatusStrip.ResumeLayout(false);
            this.mainStatusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox profilePictureBox;
        private System.Windows.Forms.Label devLabel;
        private System.Windows.Forms.TextBox devBox;
        private System.Windows.Forms.TextBox usernameBox;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.TextBox discriminatorBox;
        private System.Windows.Forms.Label discriminatorLabel;
        private System.Windows.Forms.StatusStrip mainStatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel mainStatusLabel;
    }
}

