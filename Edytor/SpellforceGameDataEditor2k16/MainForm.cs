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

            //nagłówek jako pierwszy Unknown
            Utils.AddUnknown(20);


            Utils.JumpCounter(ref Spell.Count, Spell.Length);
            for (int i = 0; i < Spell.Count; i++)
            {
                byte[] spellData = Vars.GameDataFile.SubArray(Vars.CurrentOffset + i * Spell.Length, Spell.Length);
                Spell temp = new Spell();
                temp.EffectID = spellData.SubArray(0, 2);
                temp.TypeID = spellData.SubArray(2, 2);
                temp.Reqs = spellData.SubArray(4, 12);
                temp.Mana = spellData.SubArray(16, 2);
                temp.CastingTime = spellData.SubArray(18, 4);
                temp.RecastTime = spellData.SubArray(22, 4);
                temp.MinRange = spellData.SubArray(26, 2);
                temp.MaxRange = spellData.SubArray(28, 2);
                temp.CastingType = spellData.SubArray(30, 2);
                temp.Stats = spellData.SubArray(32, 44);
                Vars.SpellList.Add(temp);
            }
            Vars.CurrentOffset += Spell.Length * Spell.Count;

            Utils.JumpCounter(ref SpellUI.Count, SpellUI.Length);
            for (int i = 0; i < SpellUI.Count; i++)
            {
                byte[] spellData = Vars.GameDataFile.SubArray(Vars.CurrentOffset + i * SpellUI.Length, SpellUI.Length);
                SpellUI temp = new SpellUI();
                temp.TypeID = spellData.SubArray(0, 2);
                temp.NameID = spellData.SubArray(2, 2);
                temp.Spellline = spellData.SubArray(4, 2);
                temp.Sorting = spellData.SubArray(6, 3);
                temp.UIName = spellData.SubArray(9, 64);
                temp.Unknown = spellData.SubArray(73, 2);                
                Vars.SpellUIList.Add(temp);
            }
            Vars.CurrentOffset += SpellUI.Length * SpellUI.Count;

            Utils.JumpCounter(ref Unknown1.Count, Unknown1.Length);
            for (int i = 0; i < Unknown1.Count; i++)
            {
                byte[] spellData = Vars.GameDataFile.SubArray(Vars.CurrentOffset + i * Unknown1.Length, Unknown1.Length);
                Unknown1 temp = new Unknown1();
                temp.Unknown = spellData.SubArray(0, 12);
                Vars.Unknown1List.Add(temp);
            }
            Vars.CurrentOffset += Unknown1.Length * Unknown1.Count;

            Utils.JumpCounter(ref UnitStats.Count, UnitStats.Length);
            for (int i = 0; i < UnitStats.Count; i++)
            {
                byte[] spellData = Vars.GameDataFile.SubArray(Vars.CurrentOffset + i * UnitStats.Length, UnitStats.Length);
                UnitStats temp = new UnitStats();
                temp.StatsID = spellData.SubArray(0, 2);
                temp.Level = spellData.SubArray(2, 2);
                temp.RaceID = spellData.SubArray(4, 1);
                temp.Attribute = spellData.SubArray(5, 14);
                temp.Unknown = spellData.SubArray(19, 2);
                temp.Resistance = spellData.SubArray(21, 8);
                temp.Speeds = spellData.SubArray(29, 6);
                temp.Size = spellData.SubArray(35, 2);
                temp.Unknown2 = spellData.SubArray(37, 2);
                temp.SpawningTime = spellData.SubArray(39, 4);
                temp.Gender = spellData.SubArray(43, 1);
                temp.HeadID = spellData.SubArray(44, 2);
                temp.SlotsID = spellData.SubArray(46, 1);
                Vars.UnitStatsList.Add(temp);
            }
            Vars.CurrentOffset += UnitStats.Length * UnitStats.Count;

            Utils.JumpCounter(ref HeroWorkerAbilities.Count, HeroWorkerAbilities.Length);
            for (int i = 0; i < HeroWorkerAbilities.Count; i++)
            {
                byte[] spellData = Vars.GameDataFile.SubArray(Vars.CurrentOffset + i * HeroWorkerAbilities.Length, HeroWorkerAbilities.Length);
                HeroWorkerAbilities temp = new HeroWorkerAbilities();
                temp.StatsID = spellData.SubArray(0, 2);
                temp.UnitAbilities = spellData.SubArray(2, 3);
                Vars.HeroWorkerAbilitiesList.Add(temp);
            }
            Vars.CurrentOffset += HeroWorkerAbilities.Length * HeroWorkerAbilities.Count;

            Utils.JumpCounter(ref HeroSkills.Count, HeroSkills.Length);
            for (int i = 0; i < HeroSkills.Count; i++)
            {
                byte[] spellData = Vars.GameDataFile.SubArray(Vars.CurrentOffset + i * HeroSkills.Length, HeroSkills.Length);
                HeroSkills temp = new HeroSkills();
                temp.StatsID = spellData.SubArray(0, 2);
                temp.SpellNumber = spellData.SubArray(2, 1);
                temp.SpellEffectID = spellData.SubArray(3, 2);
                Vars.HeroSkillsList.Add(temp);
            }
            Vars.CurrentOffset += HeroSkills.Length * HeroSkills.Count;

            Utils.JumpCounter(ref ItemType.Count, ItemType.Length);          
            for (int i = 0; i < ItemType.Count; i++)
            {
                byte[] spellData = Vars.GameDataFile.SubArray(Vars.CurrentOffset + i * ItemType.Length, ItemType.Length);
                ItemType temp = new ItemType();
                temp.ItemID = spellData.SubArray(0, 2);
                temp.Item_Type = spellData.SubArray(2, 2);
                temp.ItemNameID = spellData.SubArray(4, 2);
                temp.UnitStatsID = spellData.SubArray(6, 2);
                temp.ArmyUnitID = spellData.SubArray(8, 2);
                temp.BuildingID = spellData.SubArray(10, 2);
                temp.Unknown = spellData.SubArray(12, 1);
                temp.SellingPrice = spellData.SubArray(13, 4);
                temp.BuyingPrice = spellData.SubArray(17, 4);
                temp.SetID = spellData.SubArray(21, 1);
                Vars.ItemTypeList.Add(temp);
            }
            Vars.CurrentOffset += ItemType.Length * ItemType.Count;

            Utils.JumpCounter(ref ArmorItemStats.Count, ArmorItemStats.Length);
            for (int i = 0; i < ArmorItemStats.Count; i++)
            {
                byte[] spellData = Vars.GameDataFile.SubArray(Vars.CurrentOffset + i * ArmorItemStats.Length, ArmorItemStats.Length);
                ArmorItemStats temp = new ArmorItemStats();
                temp.ItemID = spellData.SubArray(0, 2);
                temp.Strength = spellData.SubArray(2, 2);
                temp.Stamina = spellData.SubArray(4, 2);
                temp.Agility = spellData.SubArray(6, 2);
                temp.Dexterity = spellData.SubArray(8, 2);
                temp.HP = spellData.SubArray(10, 2);
                temp.Charisma = spellData.SubArray(12, 2);
                temp.Intelligence = spellData.SubArray(14, 2);
                temp.Wisdom = spellData.SubArray(16, 2);
                temp.Mana = spellData.SubArray(18, 2);
                temp.ArmorClass = spellData.SubArray(20, 2);
                temp.FireResist = spellData.SubArray(22, 2);
                temp.IceResist = spellData.SubArray(24, 2);
                temp.BlackResist = spellData.SubArray(26, 2);
                temp.MindResist = spellData.SubArray(28, 2);
                temp.RunSpeed = spellData.SubArray(30, 2);
                temp.FightSpeed = spellData.SubArray(32, 2);
                temp.CastSpeed = spellData.SubArray(34, 2);
                Vars.ArmorItemStatsList.Add(temp);
            }
            Vars.CurrentOffset += ArmorItemStats.Length * ArmorItemStats.Count;

            Utils.JumpCounter(ref ScrollRuneID.Count, ScrollRuneID.Length);
            for (int i = 0; i < ScrollRuneID.Count; i++)
            {
                byte[] spellData = Vars.GameDataFile.SubArray(Vars.CurrentOffset + i * ScrollRuneID.Length, ScrollRuneID.Length);
                ScrollRuneID temp = new ScrollRuneID();
                temp.InInventoryID = spellData.SubArray(0, 2);
                temp.AddedID = spellData.SubArray(2, 2);        
                Vars.ScrollRuneIDList.Add(temp);
            }
            Vars.CurrentOffset += ScrollRuneID.Length * ScrollRuneID.Count;

            Utils.JumpCounter(ref WeaponItemStats.Count, WeaponItemStats.Length);
            for (int i = 0; i < WeaponItemStats.Count; i++)
            {
                byte[] spellData = Vars.GameDataFile.SubArray(Vars.CurrentOffset + i * WeaponItemStats.Length, WeaponItemStats.Length);
                WeaponItemStats temp = new WeaponItemStats();
                temp.ItemID = spellData.SubArray(0, 2);
                temp.MinDamage = spellData.SubArray(2, 2);
                temp.MaxDamage = spellData.SubArray(4, 2);
                temp.MinRange = spellData.SubArray(6, 2);
                temp.MaxRange = spellData.SubArray(8, 2);
                temp.WeaponSpeed = spellData.SubArray(10, 2);
                temp.WeaponType = spellData.SubArray(12, 2);
                temp.WeaponMaterial = spellData.SubArray(14, 2);

                Vars.WeaponItemStatsList.Add(temp);
            }
            Vars.CurrentOffset += WeaponItemStats.Length * WeaponItemStats.Count;

            Utils.JumpCounter(ref ItemRequirements.Count, ItemRequirements.Length);
            for (int i = 0; i < ItemRequirements.Count; i++)
            {
                byte[] spellData = Vars.GameDataFile.SubArray(Vars.CurrentOffset + i * ItemRequirements.Length, ItemRequirements.Length);
                ItemRequirements temp = new ItemRequirements();
                temp.ItemID = spellData.SubArray(0, 2);
                temp.RequirementNumber = spellData.SubArray(2, 1);
                temp.CombatMagicSchool = spellData.SubArray(3, 1);
                temp.CombatMagicSubSchool = spellData.SubArray(4, 1);
                temp.Level = spellData.SubArray(5, 1);

                Vars.ItemRequirementsList.Add(temp);
            }
            Vars.CurrentOffset += ItemRequirements.Length * ItemRequirements.Count;

            Utils.JumpCounter(ref ItemSpellEffects.Count, ItemSpellEffects.Length);
            for (int i = 0; i < ItemSpellEffects.Count; i++)
            {
                byte[] spellData = Vars.GameDataFile.SubArray(Vars.CurrentOffset + i * ItemSpellEffects.Length, ItemSpellEffects.Length);
                ItemSpellEffects temp = new ItemSpellEffects();
                temp.ItemID = spellData.SubArray(0, 2);
                temp.ItemEffectNumber = spellData.SubArray(2, 1);
                temp.SpellEffectID = spellData.SubArray(3, 2);

                Vars.ItemSpellEffectsList.Add(temp);
            }
            Vars.CurrentOffset += ItemSpellEffects.Length * ItemSpellEffects.Count;

            Utils.JumpCounter(ref ItemUI.Count, ItemUI.Length);
            for (int i = 0; i < ItemUI.Count; i++)
            {
                byte[] spellData = Vars.GameDataFile.SubArray(Vars.CurrentOffset + i * ItemUI.Length, ItemUI.Length);
                ItemUI temp = new ItemUI();
                temp.ItemID = spellData.SubArray(0, 2);
                temp.UINumber = spellData.SubArray(2, 1);
                temp.UIName = spellData.SubArray(3, 64);
                temp.Unknown = spellData.SubArray(67, 2);
                Vars.ItemUIList.Add(temp);
            }
            Vars.CurrentOffset += ItemUI.Length * ItemUI.Count;

            Utils.JumpCounter(ref SpellItemID.Count, SpellItemID.Length);
            for (int i = 0; i < SpellItemID.Count; i++)
            {
                byte[] spellData = Vars.GameDataFile.SubArray(Vars.CurrentOffset + i * SpellItemID.Length, SpellItemID.Length);
                SpellItemID temp = new SpellItemID();
                temp.ItemID = spellData.SubArray(0, 2);
                temp.SpellEffectID = spellData.SubArray(2, 2);
                Vars.SpellItemIDList.Add(temp);
            }
            Vars.CurrentOffset += SpellItemID.Length * SpellItemID.Count;

            Utils.JumpCounter(ref Texts.Count, Texts.Length);
            for (int i = 0; i < Texts.Count; i++)
            {
                byte[] spellData = Vars.GameDataFile.SubArray(Vars.CurrentOffset + i * Texts.Length, Texts.Length);
                Texts temp = new Texts();
                temp.TextID = spellData.SubArray(0, 2);
                temp.LanguageID = spellData.SubArray(1, 2);
                temp.DialogueNumber = spellData.SubArray(3, 1);
                temp.DialogueName = spellData.SubArray(4, 50);
                temp.RawText = spellData.SubArray(54, 512);
                Vars.TextsList.Add(temp);
            }
            Vars.CurrentOffset += Texts.Length * Texts.Count;

            Utils.JumpCounter(ref RaceStats.Count, RaceStats.Length);
            for (int i = 0; i < RaceStats.Count; i++)
            {
                byte[] spellData = Vars.GameDataFile.SubArray(Vars.CurrentOffset + i * RaceStats.Length, RaceStats.Length);
                RaceStats temp = new RaceStats();
                temp.RaceID = spellData.SubArray(0, 1);
                temp.Unknown1 = spellData.SubArray(1, 6);
                temp.RaceNameID = spellData.SubArray(7, 2);
                temp.Unknown2 = spellData.SubArray(9, 7);
                temp.StatsID = spellData.SubArray(16, 3);
                temp.Unknown3 = spellData.SubArray(19, 8);
                Vars.RaceStatsList.Add(temp);
            }
            Vars.CurrentOffset += RaceStats.Length * RaceStats.Count;

            Utils.JumpCounter(ref HeadStats.Count, HeadStats.Length);
            for (int i = 0; i < HeadStats.Count; i++)
            {
                byte[] spellData = Vars.GameDataFile.SubArray(Vars.CurrentOffset + i * HeadStats.Length, HeadStats.Length);
                HeadStats temp = new HeadStats();
                temp.HeadID1 = spellData.SubArray(0, 1);
                temp.HeadID2 = spellData.SubArray(1, 1);
                temp.Unknown = spellData.SubArray(2, 1);
                Vars.HeadStatsList.Add(temp);
            }
            Vars.CurrentOffset += HeadStats.Length * HeadStats.Count;

            Utils.JumpCounter(ref UnitNames.Count, UnitNames.Length);
            for (int i = 0; i < UnitNames.Count; i++)
            {
                byte[] spellData = Vars.GameDataFile.SubArray(Vars.CurrentOffset + i * UnitNames.Length, UnitNames.Length);
                UnitNames temp = new UnitNames();
                temp.UnitID = spellData.SubArray(0, 2);
                temp.NameID = spellData.SubArray(2, 2);
                temp.UnitStatsID = spellData.SubArray(4, 2);
                temp.UnitExp = spellData.SubArray(6, 4);
                temp.Unknown1 = spellData.SubArray(10, 2);
                temp.HPFactor = spellData.SubArray(12, 4);
                temp.Unknown2 = spellData.SubArray(16, 5);
                temp.UnitAC = spellData.SubArray(21, 2);
                temp.UnitName = spellData.SubArray(23, 40);
                temp.Unknown3 = spellData.SubArray(63, 1);
                Vars.UnitNamesList.Add(temp);
            }
            Vars.CurrentOffset += UnitNames.Length * UnitNames.Count;

            Utils.JumpCounter(ref UnitEquipment.Count, UnitEquipment.Length);
            for (int i = 0; i < UnitEquipment.Count; i++)
            {
                byte[] spellData = Vars.GameDataFile.SubArray(Vars.CurrentOffset + i * UnitEquipment.Length, UnitEquipment.Length);
                UnitEquipment temp = new UnitEquipment();
                temp.UnitID = spellData.SubArray(0, 2);
                temp.SlotID = spellData.SubArray(2, 1);
                temp.ItemID = spellData.SubArray(3, 2);
                Vars.UnitEquipmentList.Add(temp);
            }
            Vars.CurrentOffset += UnitEquipment.Length * UnitEquipment.Count;

            Utils.JumpCounter(ref UnitSpellsSkills.Count, UnitSpellsSkills.Length);
            for (int i = 0; i < UnitSpellsSkills.Count; i++)
            {
                byte[] spellData = Vars.GameDataFile.SubArray(Vars.CurrentOffset + i * UnitSpellsSkills.Length, UnitSpellsSkills.Length);
                UnitSpellsSkills temp = new UnitSpellsSkills();
                temp.UnitID = spellData.SubArray(0, 2);
                temp.SpellSkillNumber = spellData.SubArray(2, 1);
                temp.SpellEffectID = spellData.SubArray(3, 2);
                Vars.UnitSpellsSkillsList.Add(temp);
            }
            Vars.CurrentOffset += UnitSpellsSkills.Length * UnitSpellsSkills.Count;

            Utils.JumpCounter(ref ArmyRequirements.Count, ArmyRequirements.Length);
            for (int i = 0; i < ArmyRequirements.Count; i++)
            {
                byte[] spellData = Vars.GameDataFile.SubArray(Vars.CurrentOffset + i * ArmyRequirements.Length, ArmyRequirements.Length);
                ArmyRequirements temp = new ArmyRequirements();
                temp.UnitID = spellData.SubArray(0, 2);
                temp.ResourceID = spellData.SubArray(2, 1);
                temp.Amount = spellData.SubArray(3, 1);
                Vars.ArmyRequirementsList.Add(temp);
            }
            Vars.CurrentOffset += ArmyRequirements.Length * ArmyRequirements.Count;

            Utils.JumpCounter(ref UnitLoot.Count, UnitLoot.Length);
            for (int i = 0; i < UnitLoot.Count; i++)
            {
                byte[] spellData = Vars.GameDataFile.SubArray(Vars.CurrentOffset + i * UnitLoot.Length, UnitLoot.Length);
                UnitLoot temp = new UnitLoot();
                temp.UnitID = spellData.SubArray(0, 2);
                temp.SlotNumber = spellData.SubArray(2, 1);
                temp.Item1ID = spellData.SubArray(3, 2);
                temp.Item1Chance = spellData.SubArray(5, 1);
                temp.Item2ID = spellData.SubArray(6, 2);
                temp.Item2Chance = spellData.SubArray(8, 1);
                temp.Item3ID = spellData.SubArray(9, 2);
                Vars.UnitLootList.Add(temp);
            }
            Vars.CurrentOffset += UnitLoot.Length * UnitLoot.Count;

            Utils.JumpCounter(ref BuildingRequirements.Count, BuildingRequirements.Length);
            for (int i = 0; i < BuildingRequirements.Count; i++)
            {
                byte[] spellData = Vars.GameDataFile.SubArray(Vars.CurrentOffset + i * BuildingRequirements.Length, BuildingRequirements.Length);
                BuildingRequirements temp = new BuildingRequirements();
                temp.UnitID = spellData.SubArray(0, 2);
                temp.RequirementNumber = spellData.SubArray(2, 1);
                temp.BuildingID = spellData.SubArray(3, 2);
                Vars.BuildingRequirementsList.Add(temp);
            }
            Vars.CurrentOffset += BuildingRequirements.Length * BuildingRequirements.Count;

            //MagicIDNameID

            //END OF MagicIDNameID

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