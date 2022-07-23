using System.Windows.Forms;

namespace WOLSender
{
    partial class WOLSenderForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WOLSenderForm));
            this.sendButton = new System.Windows.Forms.Button();
            this.ipTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.macTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.portNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.localNetworkCheckBox = new System.Windows.Forms.CheckBox();
            this.profileComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.versionLinkLabel = new System.Windows.Forms.LinkLabel();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openSettingsFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeProgramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetProfilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.portNumericUpDown)).BeginInit();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // sendButton
            // 
            this.sendButton.Location = new System.Drawing.Point(15, 131);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(197, 24);
            this.sendButton.TabIndex = 5;
            this.sendButton.Text = "Send Magic Packet";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // ipTextBox
            // 
            this.ipTextBox.Location = new System.Drawing.Point(85, 30);
            this.ipTextBox.Name = "ipTextBox";
            this.ipTextBox.Size = new System.Drawing.Size(127, 20);
            this.ipTextBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP Address";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "MAC Address";
            // 
            // macTextBox
            // 
            this.macTextBox.Location = new System.Drawing.Point(85, 56);
            this.macTextBox.Name = "macTextBox";
            this.macTextBox.Size = new System.Drawing.Size(127, 20);
            this.macTextBox.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Port number";
            // 
            // portNumericUpDown
            // 
            this.portNumericUpDown.Location = new System.Drawing.Point(85, 82);
            this.portNumericUpDown.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.portNumericUpDown.Name = "portNumericUpDown";
            this.portNumericUpDown.Size = new System.Drawing.Size(127, 20);
            this.portNumericUpDown.TabIndex = 3;
            this.portNumericUpDown.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            // 
            // localNetworkCheckBox
            // 
            this.localNetworkCheckBox.AutoSize = true;
            this.localNetworkCheckBox.Location = new System.Drawing.Point(15, 108);
            this.localNetworkCheckBox.Name = "localNetworkCheckBox";
            this.localNetworkCheckBox.Size = new System.Drawing.Size(183, 17);
            this.localNetworkCheckBox.TabIndex = 4;
            this.localNetworkCheckBox.Text = "Use your local broadcast address";
            this.localNetworkCheckBox.UseVisualStyleBackColor = true;
            this.localNetworkCheckBox.CheckedChanged += new System.EventHandler(this.localNetworkCheckBox_CheckedChanged);
            // 
            // profileComboBox
            // 
            this.profileComboBox.FormattingEnabled = true;
            this.profileComboBox.Location = new System.Drawing.Point(236, 54);
            this.profileComboBox.MaxDropDownItems = 20;
            this.profileComboBox.Name = "profileComboBox";
            this.profileComboBox.Size = new System.Drawing.Size(127, 21);
            this.profileComboBox.TabIndex = 6;
            this.profileComboBox.SelectedIndexChanged += new System.EventHandler(this.profileComboBox_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(234, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Manage your profiles";
            // 
            // saveButton
            // 
            this.saveButton.BackColor = System.Drawing.SystemColors.Control;
            this.saveButton.Location = new System.Drawing.Point(303, 81);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(60, 21);
            this.saveButton.TabIndex = 8;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(236, 81);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(60, 21);
            this.deleteButton.TabIndex = 7;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // versionLinkLabel
            // 
            this.versionLinkLabel.ActiveLinkColor = System.Drawing.Color.Blue;
            this.versionLinkLabel.AutoSize = true;
            this.versionLinkLabel.LinkColor = System.Drawing.Color.RoyalBlue;
            this.versionLinkLabel.Location = new System.Drawing.Point(285, 137);
            this.versionLinkLabel.Name = "versionLinkLabel";
            this.versionLinkLabel.Size = new System.Drawing.Size(78, 13);
            this.versionLinkLabel.TabIndex = 0;
            this.versionLinkLabel.TabStop = true;
            this.versionLinkLabel.Text = "Version 0.0.0.0";
            this.versionLinkLabel.VisitedLinkColor = System.Drawing.Color.RoyalBlue;
            this.versionLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.versionLinkLabel_LinkClicked);
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.Color.White;
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(375, 24);
            this.menuStrip.TabIndex = 9;
            this.menuStrip.Text = "menuStrip1";
            this.menuStrip.MouseDown += new System.Windows.Forms.MouseEventHandler(this.menuStrip_MouseDown);
            this.menuStrip.MouseMove += new System.Windows.Forms.MouseEventHandler(this.menuStrip_MouseMove);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openSettingsFolderToolStripMenuItem,
            this.resetProfilesToolStripMenuItem,
            this.closeProgramToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openSettingsFolderToolStripMenuItem
            // 
            this.openSettingsFolderToolStripMenuItem.Name = "openSettingsFolderToolStripMenuItem";
            this.openSettingsFolderToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.openSettingsFolderToolStripMenuItem.Text = "Open settings folder";
            this.openSettingsFolderToolStripMenuItem.Click += new System.EventHandler(this.openSettingsFolderToolStripMenuItem_Click);
            // 
            // closeProgramToolStripMenuItem
            // 
            this.closeProgramToolStripMenuItem.Name = "closeProgramToolStripMenuItem";
            this.closeProgramToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.closeProgramToolStripMenuItem.Text = "Close program";
            this.closeProgramToolStripMenuItem.Click += new System.EventHandler(this.closeProgramToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // resetProfilesToolStripMenuItem
            // 
            this.resetProfilesToolStripMenuItem.Name = "resetProfilesToolStripMenuItem";
            this.resetProfilesToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.resetProfilesToolStripMenuItem.Text = "Reset profiles";
            this.resetProfilesToolStripMenuItem.Click += new System.EventHandler(this.resetProfilesToolStripMenuItem_Click);
            // 
            // WOLSenderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(375, 167);
            this.Controls.Add(this.versionLinkLabel);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.profileComboBox);
            this.Controls.Add(this.localNetworkCheckBox);
            this.Controls.Add(this.portNumericUpDown);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.macTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ipTextBox);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.Name = "WOLSenderForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Title";
            this.Load += new System.EventHandler(this.WOLSenderForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.portNumericUpDown)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button sendButton;
        private TextBox ipTextBox;
        private Label label1;
        private Label label2;
        private TextBox macTextBox;
        private Label label3;
        private NumericUpDown portNumericUpDown;
        private CheckBox localNetworkCheckBox;
        private ComboBox profileComboBox;
        private Label label4;
        private Button saveButton;
        private Button deleteButton;
        private LinkLabel versionLinkLabel;
        private MenuStrip menuStrip;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ToolStripMenuItem openSettingsFolderToolStripMenuItem;
        private ToolStripMenuItem closeProgramToolStripMenuItem;
        private ToolStripMenuItem resetProfilesToolStripMenuItem;
    }
}

