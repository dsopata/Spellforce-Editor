using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection;

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

            Vars.Header = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 20);
            Vars.CurrentOffset += 20;

            Spell.Read();
            SpellUI.Read();
            Unknown1.Read();
            UnitStats.Read();
            HeroWorkerAbilities.Read();
            HeroSkills.Read();
            ItemType.Read();
            ArmorItemStats.Read();
            ScrollRuneID.Read();
            WeaponItemStats.Read();
            ItemRequirements.Read();
            ItemSpellEffects.Read();
            ItemUI.Read();
            SpellItemID.Read();
            Texts.Read();
            RaceStats.Read();
            HeadStats.Read();
            UnitNames.Read();
            UnitEquipment.Read();
            UnitSpellsSkills.Read();
            ArmyRequirements.Read();
            UnitLoot.Read();
            BuildingRequirements.Read();

            GameDataLoadStatus.BackColor = Color.Lime;
            GameDataDumpButton.Enabled = true;
        }

        public void GameDataDumpButton_Click(object sender, EventArgs e)
        {
            File.WriteAllBytes(Vars.GameDataPath, Vars.GameDataFile);
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

        public static List<Spell> SpellList = new List<Spell>();
        public static List<SpellUI> SpellUIList = new List<SpellUI>();
        public static List<Unknown1> Unknown1List = new List<Unknown1>();
        public static List<UnitStats> UnitStatsList = new List<UnitStats>();
        public static List<HeroWorkerAbilities> HeroWorkerAbilitiesList = new List<HeroWorkerAbilities>();
        public static List<HeroSkills> HeroSkillsList = new List<HeroSkills>();
        public static List<ItemType> ItemTypeList = new List<ItemType>();
        public static List<ArmorItemStats> ArmorItemStatsList = new List<ArmorItemStats>();
        public static List<ScrollRuneID> ScrollRuneIDList = new List<ScrollRuneID>();
        public static List<WeaponItemStats> WeaponItemStatsList = new List<WeaponItemStats>();
        public static List<ItemRequirements> ItemRequirementsList = new List<ItemRequirements>();
        public static List<ItemSpellEffects> ItemSpellEffectsList = new List<ItemSpellEffects>();
        public static List<ItemUI> ItemUIList = new List<ItemUI>();
        public static List<SpellItemID> SpellItemIDList = new List<SpellItemID>();
        public static List<Texts> TextsList = new List<Texts>();
        public static List<RaceStats> RaceStatsList = new List<RaceStats>();
        public static List<HeadStats> HeadStatsList = new List<HeadStats>();
        public static List<UnitNames> UnitNamesList = new List<UnitNames>();
        public static List<UnitEquipment> UnitEquipmentList = new List<UnitEquipment>();
        public static List<UnitSpellsSkills> UnitSpellsSkillsList = new List<UnitSpellsSkills>();
        public static List<ArmyRequirements> ArmyRequirementsList = new List<ArmyRequirements>();
        public static List<UnitLoot> UnitLootList = new List<UnitLoot>();
        public static List<BuildingRequirements> BuildingRequirementsList = new List<BuildingRequirements>();
        public static List<MagicIDNameID> MagicIDNameIDList = new List<MagicIDNameID>();
        public static List<SkillRequirements> SkillRequirementsList = new List<SkillRequirements>();
        public static List<MerchantIDUnitID> MerchantIDUnitIDList = new List<MerchantIDUnitID>();
        public static List<MerchantInventory> MerchantInventoryList = new List<MerchantInventory>();
        public static List<MerchantRates> MerchantRatesList = new List<MerchantRates>();
        public static List<sql_goodNames> sql_goodNamesList = new List<sql_goodNames>();
        public static List<PlayerLevelStats> PlayerLevelStatsList = new List<PlayerLevelStats>();
        public static List<ObjectStatsNames> ObjectStatsNamesList = new List<ObjectStatsNames>();
        public static List<MonumentInteractiveObjectStats> MonumentInteractiveObjectStatsList = new List<MonumentInteractiveObjectStats>();
        public static List<ChestLoot> ChestLootList = new List<ChestLoot>();
        public static List<Unknown2> Unknown2List = new List<Unknown2>();
        public static List<QuestMaps> QuestMapsList = new List<QuestMaps>();
        public static List<Portals> PortalsList = new List<Portals>();
        public static List<Unknown3> Unknown3List = new List<Unknown3>();
        public static List<QuestGameMenu> QuestGameMenuList = new List<QuestGameMenu>();
        public static List<ButtonDescription> ButtonDescriptionList = new List<ButtonDescription>();
        public static List<QuestID> QuestIDList = new List<QuestID>();
        public static List<WeaponTypeStats> WeaponTypeStatsList = new List<WeaponTypeStats>();
        public static List<WeaponMaterial> WeaponMaterialList = new List<WeaponMaterial>();
        public static List<Unknown4> Unknown4List = new List<Unknown4>();
        public static List<Heads> HeadsList = new List<Heads>();
        public static List<UpgradeStatsUI> UpgradeStatsUIList = new List<UpgradeStatsUI>();
        public static List<ItemSets> ItemSetsList = new List<ItemSets>();
    }
}