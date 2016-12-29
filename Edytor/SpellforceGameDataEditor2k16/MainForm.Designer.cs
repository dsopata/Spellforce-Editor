namespace SpellforceGameDataEditor2k16
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
            this.GameDataOpen = new System.Windows.Forms.OpenFileDialog();
            this.GameDataPathButton = new System.Windows.Forms.Button();
            this.GameDataPathTextBox = new System.Windows.Forms.TextBox();
            this.GameDataPathStatus = new System.Windows.Forms.Panel();
            this.GameDataBackupButton = new System.Windows.Forms.Button();
            this.GameDataLoadButton = new System.Windows.Forms.Button();
            this.GameDataDumpButton = new System.Windows.Forms.Button();
            this.GameDataBackupStatus = new System.Windows.Forms.Panel();
            this.GameDataLoadStatus = new System.Windows.Forms.Panel();
            this.GameDataDumpStatus = new System.Windows.Forms.Panel();
            this.TestLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // GameDataOpen
            // 
            this.GameDataOpen.FileName = "GameData.cff";
            this.GameDataOpen.Filter = "GameData.cff File|GameData.cff";
            this.GameDataOpen.Title = "Open...";
            // 
            // GameDataPathButton
            // 
            this.GameDataPathButton.Location = new System.Drawing.Point(12, 12);
            this.GameDataPathButton.Name = "GameDataPathButton";
            this.GameDataPathButton.Size = new System.Drawing.Size(277, 23);
            this.GameDataPathButton.TabIndex = 0;
            this.GameDataPathButton.Text = "Select GameData.cff file ";
            this.GameDataPathButton.UseVisualStyleBackColor = true;
            this.GameDataPathButton.Click += new System.EventHandler(this.GameDataPathButton_Click);
            // 
            // GameDataPathTextBox
            // 
            this.GameDataPathTextBox.Enabled = false;
            this.GameDataPathTextBox.Location = new System.Drawing.Point(12, 43);
            this.GameDataPathTextBox.Name = "GameDataPathTextBox";
            this.GameDataPathTextBox.Size = new System.Drawing.Size(306, 20);
            this.GameDataPathTextBox.TabIndex = 1;
            this.GameDataPathTextBox.Text = "Path to GameData.cff...";
            // 
            // GameDataPathStatus
            // 
            this.GameDataPathStatus.BackColor = System.Drawing.Color.Red;
            this.GameDataPathStatus.Location = new System.Drawing.Point(295, 12);
            this.GameDataPathStatus.Name = "GameDataPathStatus";
            this.GameDataPathStatus.Size = new System.Drawing.Size(23, 23);
            this.GameDataPathStatus.TabIndex = 2;
            // 
            // GameDataBackupButton
            // 
            this.GameDataBackupButton.Enabled = false;
            this.GameDataBackupButton.Location = new System.Drawing.Point(12, 70);
            this.GameDataBackupButton.Name = "GameDataBackupButton";
            this.GameDataBackupButton.Size = new System.Drawing.Size(277, 23);
            this.GameDataBackupButton.TabIndex = 3;
            this.GameDataBackupButton.Text = "Backup GameData.cff";
            this.GameDataBackupButton.UseVisualStyleBackColor = true;
            this.GameDataBackupButton.Click += new System.EventHandler(this.GameDataBackupButton_Click);
            // 
            // GameDataLoadButton
            // 
            this.GameDataLoadButton.Enabled = false;
            this.GameDataLoadButton.Location = new System.Drawing.Point(12, 99);
            this.GameDataLoadButton.Name = "GameDataLoadButton";
            this.GameDataLoadButton.Size = new System.Drawing.Size(277, 23);
            this.GameDataLoadButton.TabIndex = 4;
            this.GameDataLoadButton.Text = "Load GameData.cff to memory";
            this.GameDataLoadButton.UseVisualStyleBackColor = true;
            this.GameDataLoadButton.Click += new System.EventHandler(this.GameDataLoadButton_Click);
            // 
            // GameDataDumpButton
            // 
            this.GameDataDumpButton.Enabled = false;
            this.GameDataDumpButton.Location = new System.Drawing.Point(12, 216);
            this.GameDataDumpButton.Name = "GameDataDumpButton";
            this.GameDataDumpButton.Size = new System.Drawing.Size(278, 23);
            this.GameDataDumpButton.TabIndex = 5;
            this.GameDataDumpButton.Text = "Dump memory to GameData.cff and exit";
            this.GameDataDumpButton.UseVisualStyleBackColor = true;
            this.GameDataDumpButton.Click += new System.EventHandler(this.GameDataDumpButton_Click);
            // 
            // GameDataBackupStatus
            // 
            this.GameDataBackupStatus.BackColor = System.Drawing.Color.Red;
            this.GameDataBackupStatus.Location = new System.Drawing.Point(295, 70);
            this.GameDataBackupStatus.Name = "GameDataBackupStatus";
            this.GameDataBackupStatus.Size = new System.Drawing.Size(23, 23);
            this.GameDataBackupStatus.TabIndex = 3;
            // 
            // GameDataLoadStatus
            // 
            this.GameDataLoadStatus.BackColor = System.Drawing.Color.Red;
            this.GameDataLoadStatus.Location = new System.Drawing.Point(295, 99);
            this.GameDataLoadStatus.Name = "GameDataLoadStatus";
            this.GameDataLoadStatus.Size = new System.Drawing.Size(23, 23);
            this.GameDataLoadStatus.TabIndex = 3;
            // 
            // GameDataDumpStatus
            // 
            this.GameDataDumpStatus.BackColor = System.Drawing.Color.Red;
            this.GameDataDumpStatus.Location = new System.Drawing.Point(295, 216);
            this.GameDataDumpStatus.Name = "GameDataDumpStatus";
            this.GameDataDumpStatus.Size = new System.Drawing.Size(23, 23);
            this.GameDataDumpStatus.TabIndex = 3;
            // 
            // TestLabel
            // 
            this.TestLabel.AutoSize = true;
            this.TestLabel.Location = new System.Drawing.Point(13, 146);
            this.TestLabel.Name = "TestLabel";
            this.TestLabel.Size = new System.Drawing.Size(85, 13);
            this.TestLabel.TabIndex = 6;
            this.TestLabel.Text = "Testuj miszczu...";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 261);
            this.Controls.Add(this.TestLabel);
            this.Controls.Add(this.GameDataDumpStatus);
            this.Controls.Add(this.GameDataLoadStatus);
            this.Controls.Add(this.GameDataBackupStatus);
            this.Controls.Add(this.GameDataDumpButton);
            this.Controls.Add(this.GameDataLoadButton);
            this.Controls.Add(this.GameDataBackupButton);
            this.Controls.Add(this.GameDataPathStatus);
            this.Controls.Add(this.GameDataPathTextBox);
            this.Controls.Add(this.GameDataPathButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(340, 300);
            this.MinimumSize = new System.Drawing.Size(340, 300);
            this.Name = "MainForm";
            this.Text = "Spellforce GameData Editor";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog GameDataOpen;
        private System.Windows.Forms.Button GameDataPathButton;
        private System.Windows.Forms.TextBox GameDataPathTextBox;
        private System.Windows.Forms.Panel GameDataPathStatus;
        private System.Windows.Forms.Button GameDataBackupButton;
        private System.Windows.Forms.Button GameDataLoadButton;
        private System.Windows.Forms.Button GameDataDumpButton;
        private System.Windows.Forms.Panel GameDataBackupStatus;
        private System.Windows.Forms.Panel GameDataLoadStatus;
        private System.Windows.Forms.Panel GameDataDumpStatus;
        private System.Windows.Forms.Label TestLabel;
    }
}

