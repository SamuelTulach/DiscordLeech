using System;
using System.Drawing;
using System.Net;
using System.Threading;
using System.Windows.Forms;

namespace DiscordLeech
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void ScanThread()
        {
            mainStatusLabel.Text = "Scanning...";
            try
            {
                var data = Leech.ReadData();
                mainStatusLabel.Text = "Data read";
                devBox.Text = data.Id;
                usernameBox.Text = data.Username;
                discriminatorBox.Text = data.Discriminator;

                var request = WebRequest.Create($"https://cdn.discordapp.com/avatars/{data.Id}/{data.Avatar}.png");
                using (var response = request.GetResponse())
                using (var stream = response.GetResponseStream())
                {
                    profilePictureBox.Image = Image.FromStream(stream);
                }
            }
            catch (Exception ex)
            {
                mainStatusLabel.Text = "ERROR: " + ex.Message;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            new Thread(ScanThread).Start();
        }
    }
}