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

            Spell.GetCount();
            for (int i = 0; i < Spell.Count; i++)
                Vars.SpellList.Add(new Spell(Vars.GameDataFile.SubArray(Vars.CurrentOffset + i * Spell.Length, Spell.Length)));
            Vars.CurrentOffset += Spell.Length * Spell.Count;

            SpellUI.GetCount();
            for (int i = 0; i < SpellUI.Count; i++)
                Vars.SpellUIList.Add(new SpellUI(Vars.GameDataFile.SubArray(Vars.CurrentOffset + i * SpellUI.Length, SpellUI.Length)));
            Vars.CurrentOffset += SpellUI.Length * SpellUI.Count;

            Unknown1.GetCount();
            for (int i = 0; i < Unknown1.Count; i++)
                Vars.Unknown1List.Add(new Unknown1(Vars.GameDataFile.SubArray(Vars.CurrentOffset + i * Unknown1.Length, Unknown1.Length)));
            Vars.CurrentOffset += Unknown1.Length * Unknown1.Count;

            UnitStats.GetCount();
            for (int i = 0; i < UnitStats.Count; i++)
                Vars.UnitStatsList.Add(new UnitStats(Vars.GameDataFile.SubArray(Vars.CurrentOffset + i * UnitStats.Length, UnitStats.Length)));
            Vars.CurrentOffset += UnitStats.Length * UnitStats.Count;

            HeroWorkerAbilities.GetCount();
            for (int i = 0; i < HeroWorkerAbilities.Count; i++)
                Vars.HeroWorkerAbilitiesList.Add(new HeroWorkerAbilities(Vars.GameDataFile.SubArray(Vars.CurrentOffset + i * HeroWorkerAbilities.Length, HeroWorkerAbilities.Length)));
            Vars.CurrentOffset += HeroWorkerAbilities.Length * HeroWorkerAbilities.Count;

            HeroSkills.GetCount();
            for (int i = 0; i < HeroSkills.Count; i++)
                Vars.HeroSkillsList.Add(new HeroSkills(Vars.GameDataFile.SubArray(Vars.CurrentOffset + i * HeroSkills.Length, HeroSkills.Length)));
            Vars.CurrentOffset += HeroSkills.Length * HeroSkills.Count;

            ItemType.GetCount();
            for (int i = 0; i < ItemType.Count; i++)
                Vars.ItemTypeList.Add(new ItemType(Vars.GameDataFile.SubArray(Vars.CurrentOffset + i * ItemType.Length, ItemType.Length)));
            Vars.CurrentOffset += ItemType.Length * ItemType.Count;

            ArmorItemStats.GetCount();
            for (int i = 0; i < ArmorItemStats.Count; i++)
                Vars.ArmorItemStatsList.Add(new ArmorItemStats(Vars.GameDataFile.SubArray(Vars.CurrentOffset + i * ArmorItemStats.Length, ArmorItemStats.Length)));
            Vars.CurrentOffset += ArmorItemStats.Length * ArmorItemStats.Count;

            ScrollRuneID.GetCount();
            for (int i = 0; i < ScrollRuneID.Count; i++)
                Vars.ScrollRuneIDList.Add(new ScrollRuneID(Vars.GameDataFile.SubArray(Vars.CurrentOffset + i * ScrollRuneID.Length, ScrollRuneID.Length)));
            Vars.CurrentOffset += ScrollRuneID.Length * ScrollRuneID.Count;

            WeaponItemStats.GetCount();
            for (int i = 0; i < WeaponItemStats.Count; i++)
                Vars.WeaponItemStatsList.Add(new WeaponItemStats(Vars.GameDataFile.SubArray(Vars.CurrentOffset + i * WeaponItemStats.Length, WeaponItemStats.Length)));
            Vars.CurrentOffset += WeaponItemStats.Length * WeaponItemStats.Count;

            ItemRequirements.GetCount();
            for (int i = 0; i < ItemRequirements.Count; i++)
                Vars.ItemRequirementsList.Add(new ItemRequirements(Vars.GameDataFile.SubArray(Vars.CurrentOffset + i * ItemRequirements.Length, ItemRequirements.Length)));
            Vars.CurrentOffset += ItemRequirements.Length * ItemRequirements.Count;

            ItemSpellEffects.GetCount();
            for (int i = 0; i < ItemSpellEffects.Count; i++)
                Vars.ItemSpellEffectsList.Add(new ItemSpellEffects(Vars.GameDataFile.SubArray(Vars.CurrentOffset + i * ItemSpellEffects.Length, ItemSpellEffects.Length)));
            Vars.CurrentOffset += ItemSpellEffects.Length * ItemSpellEffects.Count;

            ItemUI.GetCount();
            for (int i = 0; i < ItemUI.Count; i++)
                Vars.ItemUIList.Add(new ItemUI(Vars.GameDataFile.SubArray(Vars.CurrentOffset + i * ItemUI.Length, ItemUI.Length)));
            Vars.CurrentOffset += ItemUI.Length * ItemUI.Count;

            SpellItemID.GetCount();
            for (int i = 0; i < SpellItemID.Count; i++)
                Vars.SpellItemIDList.Add(new SpellItemID(Vars.GameDataFile.SubArray(Vars.CurrentOffset + i * SpellItemID.Length, SpellItemID.Length)));
            Vars.CurrentOffset += SpellItemID.Length * SpellItemID.Count;

            Texts.GetCount();
            for (int i = 0; i < Texts.Count; i++)
                Vars.TextsList.Add(new Texts(Vars.GameDataFile.SubArray(Vars.CurrentOffset + i * Texts.Length, Texts.Length)));
            Vars.CurrentOffset += Texts.Length * Texts.Count;

            RaceStats.GetCount();
            for (int i = 0; i < RaceStats.Count; i++)
                Vars.RaceStatsList.Add(new RaceStats(Vars.GameDataFile.SubArray(Vars.CurrentOffset + i * RaceStats.Length, RaceStats.Length)));
            Vars.CurrentOffset += RaceStats.Length * RaceStats.Count;

            HeadStats.GetCount();
            for (int i = 0; i < HeadStats.Count; i++)
                Vars.HeadStatsList.Add(new HeadStats(Vars.GameDataFile.SubArray(Vars.CurrentOffset + i * HeadStats.Length, HeadStats.Length)));
            Vars.CurrentOffset += HeadStats.Length * HeadStats.Count;

            UnitNames.GetCount();
            for (int i = 0; i < UnitNames.Count; i++)
                Vars.UnitNamesList.Add(new UnitNames(Vars.GameDataFile.SubArray(Vars.CurrentOffset + i * UnitNames.Length, UnitNames.Length)));
            Vars.CurrentOffset += UnitNames.Length * UnitNames.Count;

            UnitEquipment.GetCount();
            for (int i = 0; i < UnitEquipment.Count; i++)
                Vars.UnitEquipmentList.Add(new UnitEquipment(Vars.GameDataFile.SubArray(Vars.CurrentOffset + i * UnitEquipment.Length, UnitEquipment.Length)));
            Vars.CurrentOffset += UnitEquipment.Length * UnitEquipment.Count;

            UnitSpellsSkills.GetCount();
            for (int i = 0; i < UnitSpellsSkills.Count; i++)
                Vars.UnitSpellsSkillsList.Add(new UnitSpellsSkills(Vars.GameDataFile.SubArray(Vars.CurrentOffset + i * UnitSpellsSkills.Length, UnitSpellsSkills.Length)));
            Vars.CurrentOffset += UnitSpellsSkills.Length * UnitSpellsSkills.Count;

            ArmyRequirements.GetCount();
            for (int i = 0; i < ArmyRequirements.Count; i++)
                Vars.ArmyRequirementsList.Add(new ArmyRequirements(Vars.GameDataFile.SubArray(Vars.CurrentOffset + i * ArmyRequirements.Length, ArmyRequirements.Length)));
            Vars.CurrentOffset += ArmyRequirements.Length * ArmyRequirements.Count;

            UnitLoot.GetCount();
            for (int i = 0; i < UnitLoot.Count; i++)
                Vars.UnitLootList.Add(new UnitLoot(Vars.GameDataFile.SubArray(Vars.CurrentOffset + i * UnitLoot.Length, UnitLoot.Length)));
            Vars.CurrentOffset += UnitLoot.Length * UnitLoot.Count;

            BuildingRequirements.GetCount();
            for (int i = 0; i < BuildingRequirements.Count; i++)
                Vars.BuildingRequirementsList.Add(new BuildingRequirements(Vars.GameDataFile.SubArray(Vars.CurrentOffset + i * BuildingRequirements.Length, BuildingRequirements.Length)));
            Vars.CurrentOffset += BuildingRequirements.Length * BuildingRequirements.Count;

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
        public static List<byte[]> Unknowns = new List<byte[]>();

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
        public static List<QuestMaps> QuestMapsList = new List<QuestMaps>();
        public static List<Portals> PortalsList = new List<Portals>();
        public static List<QuestGameMenu> QuestGameMenuList = new List<QuestGameMenu>();
        public static List<ButtonDescription> ButtonDescriptionList = new List<ButtonDescription>();
        public static List<QuestID> QuestIDList = new List<QuestID>();
        public static List<WeaponTypeStats> WeaponTypeStatsList = new List<WeaponTypeStats>();
        public static List<WeaponMaterial> WeaponMaterialList = new List<WeaponMaterial>();
        public static List<Heads> HeadsList = new List<Heads>();
        public static List<UpgradeStatsUI> UpgradeStatsUIList = new List<UpgradeStatsUI>();
        public static List<ItemSets> ItemSetsList = new List<ItemSets>();
    }
}