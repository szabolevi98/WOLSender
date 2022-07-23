using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace WOLSender
{
    public partial class WOLSenderForm : Form
    {
        private string fullConfigPath { get; set; }
        private string configPath { get; set; }
        private const string configFile = "save_data.json";
        private const string configFolder = "WOLSender";
        private const int defaultPort = 7;
        public const string repositoryLink = "https://github.com/szabolevi98/WOLSender";
        List<Profile> profileList = new List<Profile>();

        public WOLSenderForm()
        {
            string appDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + $@"\{configFolder}";
            configPath = appDataFolder;
            fullConfigPath = appDataFolder + $@"\{configFile}";
            InitializeComponent();
        }

        private void WOLSenderForm_Load(object sender, EventArgs e)
        {
            if (!Directory.Exists(configPath))
            {
                try
                {
                    Directory.CreateDirectory(configPath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An exception occurred while createing folder: {configPath}, message: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(0);
                }
                
            }
            if (!File.Exists(fullConfigPath))
            {
                try
                {
                    List<Profile> defaultProfileList = new List<Profile>();
                    defaultProfileList.Add(new Profile("Default", "", "", defaultPort, false));
                    string jsonData = JsonConvert.SerializeObject(defaultProfileList, Formatting.Indented);
                    File.WriteAllText(fullConfigPath, jsonData);
                    MessageBox.Show($"{configFile} (save file) created!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An exception occurred while createing {configFile}, message: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(0);
                }
            }
            string json = File.ReadAllText(fullConfigPath);
            profileList = JsonConvert.DeserializeObject<List<Profile>>(json);
            setDefaults();
            if (profileList.Count > 0)
            {
                profileComboBox.SelectedIndex = 0;
            }
            Text = Application.ProductName;
            versionLinkLabel.Text = versionLinkLabel.Text.Replace("0.0.0.0", Application.ProductVersion);
            setValuesOnMenuStripeSubItems(this.menuStrip.Items.OfType<ToolStripMenuItem>().ToList());
        }

        private void setValuesOnMenuStripeSubItems(List<ToolStripMenuItem> items)
        {
            items.ForEach(item =>
            {
                var dropdown = (ToolStripDropDownMenu)item.DropDown;
                if (dropdown != null)
                {
                    dropdown.ShowImageMargin = false;
                    setValuesOnMenuStripeSubItems(item.DropDownItems.OfType<ToolStripMenuItem>().ToList());
                }
            });
        }

        private void setDefaults()
        {
            profileComboBox.Items.Clear();
            if (profileList.Count > 0)
            {
                foreach (Profile profile in profileList)
                {
                    profileComboBox.Items.Add(profile.Name);
                }
                ipTextBox.Text = profileList[0].IPAddress;
                macTextBox.Text = profileList[0].MACAddress;
                portNumericUpDown.Value = profileList[0].PortNumber;
                localNetworkCheckBox.Checked = profileList[0].IsLocal;
            }
        }

        private static bool IsValidIP(String ipAddress)
        {
            if (string.IsNullOrEmpty(ipAddress))
                return false;

            var items = ipAddress.Split('.');

            if (items.Length != 4)
                return false;

            return items.All(item => byte.TryParse(item, out _));
        }

        private static bool IsValidMAC(String macAddress)
        {
            Regex macRegex = new Regex("^(?:[0-9A-Fa-f]{2}[:-]){5}(?:[0-9A-Fa-f]{2})$");
            return macRegex.IsMatch(macAddress);
        }

        private byte[] convertMacAddress(string macAddress)
        {
            macAddress = Regex.Replace(macAddress, "[: -]", "");
            byte[] macBytes = new byte[6];
            for (int i = 0; i < 6; i++)
            {
                macBytes[i] = Convert.ToByte(macAddress.Substring(i * 2, 2), 16);
            }
            return macBytes;
        }

        private byte[] buildMagicPacket(byte[] macAddress)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                using (BinaryWriter bw = new BinaryWriter(ms))
                {
                    for (int i = 0; i < 6; i++)
                    {
                        bw.Write((byte)0xff);
                    }
                    for (int i = 0; i < 16; i++)
                    {
                        bw.Write(macAddress);
                    }
                }
                return ms.ToArray();
            }
        }

        private void sendMagicPacket(string ipAddress, byte[] macAddress, int portNumber)
        {
            try
            {
                UdpClient udpClient = new UdpClient();
                udpClient.Client.Connect(ipAddress, portNumber);
                byte[] packet = buildMagicPacket(macAddress);
                int sentBytes = udpClient.Client.Send(packet);
                if (sentBytes > 0)
                {
                    MessageBox.Show($"The magic package has been sent to {ipAddress}:{portNumber}", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"An error occurred while sending the magic packet.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An exception occurred while sending the magic packet: {ex.Message}", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void localNetworkCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (localNetworkCheckBox.Checked)
            {
                ipTextBox.ReadOnly = true;
                ipTextBox.Text = IPAddress.Broadcast.ToString();
            }
            else
            {
                ipTextBox.ReadOnly = false;
            }
        }

        private void profileComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (Profile profile in profileList)
            {
                if (profileComboBox.SelectedItem.ToString() == profile.Name)
                {
                    ipTextBox.Text = profile.IPAddress;
                    macTextBox.Text = profile.MACAddress;
                    portNumericUpDown.Value = profile.PortNumber;
                    localNetworkCheckBox.Checked = profile.IsLocal;
                    break;
                }
            }
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            if (!IsValidMAC(macTextBox.Text))
            {
                MessageBox.Show("The given mac address is invalid!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!IsValidIP(ipTextBox.Text))
            {
                MessageBox.Show("The given ip address is invalid!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string ipAddress = ipTextBox.Text;
            byte[] macAddress = convertMacAddress(macTextBox.Text);
            int port = (int)portNumericUpDown.Value;
            sendMagicPacket(ipAddress, macAddress, port);
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(profileComboBox.Text))
            {
                try
                {
                    bool profileExist = false;
                    for (int i = 0; i < profileList.Count; i++)
                    {
                        if (profileList[i].Name == profileComboBox.Text)
                        {
                            profileList[i].IPAddress = ipTextBox.Text;
                            profileList[i].MACAddress = macTextBox.Text;
                            profileList[i].PortNumber = (int)portNumericUpDown.Value;
                            profileList[i].IsLocal = localNetworkCheckBox.Checked;
                            profileExist = true;
                            break;
                        }
                    }
                    if (!profileExist)
                    {
                        profileList.Add(new Profile(profileComboBox.Text, ipTextBox.Text, macTextBox.Text, (int)portNumericUpDown.Value, localNetworkCheckBox.Checked));
                        profileComboBox.Items.Add(profileComboBox.Text);
                    }
                    string jsonData = JsonConvert.SerializeObject(profileList, Formatting.Indented);
                    File.WriteAllText(fullConfigPath, jsonData);
                    MessageBox.Show($"{profileComboBox.Text} successfully saved!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An exception occurred while saving data, message: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("You have to specify a profile name!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (profileList.Count > 0)
            {
                if (!String.IsNullOrEmpty(profileComboBox.Text))
                {
                    int profileIndex = -1;
                    for (int i = 0; i < profileList.Count; i++)
                    {
                        if (profileList[i].Name == profileComboBox.Text)
                        {
                            profileIndex = i;
                            break;
                        }
                    }
                    if (profileIndex >= 0)
                    {
                        profileList.RemoveAt(profileIndex);
                        String jsonData = JsonConvert.SerializeObject(profileList, Formatting.Indented);
                        File.WriteAllText(fullConfigPath, jsonData);
                        MessageBox.Show($"{profileComboBox.Text} successfully removed!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        setDefaults();
                        if (profileList.Count > 0)
                        {
                            profileComboBox.SelectedIndex = 0;
                        }
                        else
                        {
                            profileComboBox.Text = String.Empty;
                            ipTextBox.Text = String.Empty;
                            macTextBox.Text = String.Empty;
                            portNumericUpDown.Value = defaultPort;
                            localNetworkCheckBox.Checked = false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("The profile does not exists!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("You have to specify a profile name!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("No profile saved yet!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void resetProfilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to reset all profiles?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    List<Profile> defaultProfileList = new List<Profile>();
                    defaultProfileList.Add(new Profile("Default", "", "", defaultPort, false));
                    string jsonData = JsonConvert.SerializeObject(defaultProfileList, Formatting.Indented);
                    File.WriteAllText(fullConfigPath, jsonData);
                    profileList = JsonConvert.DeserializeObject<List<Profile>>(jsonData);
                    setDefaults();
                    if (profileList.Count > 0)
                    {
                        profileComboBox.SelectedIndex = 0;
                    }
                    MessageBox.Show("Profiles successfully resetted.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An exception occurred while resetting profiles data, message: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void versionLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(repositoryLink);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.ShowDialog();
        }

        private void closeProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void openSettingsFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", $@"{configPath}");
        }

        Point egerHely;
        private void menuStrip_MouseDown(object sender, MouseEventArgs e)
        {
            egerHely = e.Location;
        }

        private void menuStrip_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int x = e.Location.X - egerHely.X;
                int y = e.Location.Y - egerHely.Y;
                this.Location = new Point(this.Location.X + x, this.Location.Y + y);
            }
        }
    }
}
