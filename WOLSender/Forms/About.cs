using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace WOLSender
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }

        private void About_Load(object sender, EventArgs e)
        {
            titleLabel.Text = Application.ProductName;
            versionLabel.Text = versionLabel.Text.Replace("0.0.0.0", Application.ProductVersion);
            yearLabel.Text = yearLabel.Text.Replace("year", DateTime.Now.Year.ToString());
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void gitHubLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(WOLSenderForm.repositoryLink);
        }
    }
}
