using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace SpellforceGameDataEditor2k16
{
    public partial class MainForm : Form
    {                
        public MainForm()
        {
            InitializeComponent();
        }             

        public void GameDataPathButton_Click(object sender, EventArgs e)
        {            
            DialogResult userClickedOK = GameDataOpen.ShowDialog();
            if (userClickedOK == DialogResult.OK)
            {
                Vars.GameDataPath = GameDataOpen.FileName;
                GameDataPathTextBox.Text = Vars.GameDataPath;
                GameDataPathStatus.BackColor = System.Drawing.Color.Lime;
                GameDataBackupButton.Enabled = true;
                GameDataLoadButton.Enabled = true;
            }
        }

        public void GameDataBackupButton_Click(object sender, EventArgs e)
        {
            File.Copy(Vars.GameDataPath, Vars.GameDataPath + ".bak", true);
            GameDataBackupStatus.BackColor = System.Drawing.Color.Lime;
        }

        public void GameDataLoadButton_Click(object sender, EventArgs e)
        {
            //trzeba całkowicie przepisać wczytywanie
            Vars.GameDataFile = File.ReadAllBytes(Vars.GameDataPath);

            Utils.InitializeListDict();
            Utils.ReadAll();
            
            Vars.GameDataFile = null;
            GC.Collect();

            TestLabel.Text = "Wszystko cacy! // Nie klikać \"Dump...\"!!!";
            GameDataLoadStatus.BackColor = Color.Lime;
            GameDataDumpButton.Enabled = true;
        }

        public void GameDataDumpButton_Click(object sender, EventArgs e)
        {
            Utils.WriteAll();
            GameDataDumpStatus.BackColor = System.Drawing.Color.Lime;
            DialogResult userClickedOK = MessageBox.Show("Thanks for using our software!", "Bye!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (userClickedOK == DialogResult.OK)
            {
                Environment.Exit(-1);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            
        }
    }

    public static partial class Vars
    {
        public static string GameDataPath;
        public static byte[] GameDataFile; //docelowo: public static List<byte> GameDataFile = new List<byte>();
        public static int CurrentOffset;
        public static byte[] Header = new byte[20];

        public static Dictionary<string, object> ListDict = new Dictionary<string, object>();        
    }
}