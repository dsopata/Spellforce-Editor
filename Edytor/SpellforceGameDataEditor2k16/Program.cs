using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SpellforceGameDataEditor2k16
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }

    public static class Utils
    {
        public static int LittleEndianToInt(byte[] little)
        {
            int integer = 0;
            for (int i = 0; i < little.Length; i++)
            {
                integer += little[i] * (int)Math.Pow(256, i);
            }
            return integer;
        }

        public static byte[] IntToLittleEndian(int integer, int length = 4)
        {
            byte[] little = new byte[length];
            for (int i = 0; i < length; i++)
            {
                little[i] = (byte)((integer / Math.Pow(256, i)) % 256);
            }
            return little;
        }

        public static T[] SubArray<T>(this T[] data, int index, int length)
        {
            T[] result = new T[length];
            Array.Copy(data, index, result, 0, length);
            return result;
        }

        public static void ReadAll()
        {
            Vars.Segments = new Dictionary<string, Segment>();
            Vars.CurrentOffset = 0;
            Vars.Header = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 20);
            Vars.CurrentOffset += 20;

            new Segment("Spell", new string[] { "EffectID", "TypeID", "Reqs", "Mana", "CastingTime", "RecastTime", "MinRange", "MaxRange", "CastingType", "Stats" }, new int[] { 2, 2, 12, 2, 4, 4, 2, 2, 2, 44 });
            new Segment("SpellUI", new string[] { "TypeID", "NameID", "SpellLine", "Sorting", "UIName", "Unknown" }, new int[] { 2, 2, 2, 3, 64, 2 });
            new Segment("Unknown1", new string[] { "Unknown" }, new int[] { 12 });
            new Segment("UnitStats", new string[] { "StatsID", "Level", "RaceID", "Attribute", "Unknown1", "Resistance", "Speeds", "Size", "Unknown2", "SpawningTime", "Gender", "HeadID", "SlotsID" }, new int[] { 2, 2, 1, 14, 2, 8, 6, 2, 2, 4, 1, 2, 1 });
            new Segment("HeroOrWorkerAbilities", new string[] { "StatsID", "UnitAbilities" }, new int[] { 2, 3 });
            new Segment("HeroSkills", new string[] { "StatsID", "SpellNumber", "SpellEffectID" }, new int[] { 2, 1, 2 });
            new Segment("ItemType", new string[] { "ItemID", "ItemType", "ItemNameID", "UnitStatsID", "ArmyUnitID", "BuildingID", "Unknown", "SellingPrice", "BuyingPrice", "SetID" }, new int[] { 2, 2, 2, 2, 2, 2, 1, 4, 4, 1 });
            new Segment("ArmorItemStats", new string[] { "ItemID", "Strength", "Stamina", "Agility", "Dexterity", "HP", "Charisma", "Intelligence", "Wisdom", "Mana", "ArmorClass", "FireResist", "IceResist", "BlackResist", "MindResist", "RunSpeed", "FightSpeed", "CastSpeed" }, new int[] { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 });
            new Segment("ScrollRuneID", new string[] { "InventoryID", "AddedID" }, new int[] { 2, 2 });
            new Segment("WeaponItemStats", new string[] { "ItemID", "MinDamage", "MaxDamage", "MinRange", "MaxRange", "WeaponSpeed", "WeaponType", "WeaponMaterial" }, new int[] { 2, 2, 2, 2, 2, 2, 2, 2 });
            new Segment("ItemRequirements", new string[] { "ItemID", "RequirementNumber", "CombatOrMagicSchool", "CombatOrMagicSubSchool", "Level" }, new int[] { 2, 1, 1, 1, 1 });
            new Segment("ItemSpellEffects", new string[] { "ItemID", "ItemEffectNumber", "SpellEffectID" }, new int[] { 2, 1, 2 });
            new Segment("ItemUI", new string[] { "ItemID", "UINumber", "UIName", "Unknown" }, new int[] { 2, 1, 64, 2 });
            new Segment("SpellItemID", new string[] { "ItemID", "SpellEffectID" }, new int[] { 2, 2 });
            new Segment("Texts", new string[] { "TextID", "LanguageID", "DialogueNumber", "DialogueName", "RawText" }, new int[] { 2, 1, 1, 50, 512 });
            new Segment("RaceStats", new string[] { "RaceID", "Unknown1", "RaceNameID", "Unknown2", "StatsID", "Unknown3" }, new int[] { 1, 6, 2, 7, 3, 8 });
            new Segment("HeadStats", new string[] { "HeadID1", "HeadID2", "Unknown" }, new int[] { 1, 1, 1 });
            new Segment("UnitNames", new string[] { "UnitID", "NameID", "UnitStatsID", "UnitExp", "Unknown1", "HPFactor", "Unknown2", "UnitAC", "UnitName", "Unknown3" }, new int[] { 2, 2, 2, 4, 2, 4, 5, 2, 40, 1 });
            new Segment("UnitEquipment", new string[] { "UnitID", "SlotID", "ItemID" }, new int[] { 2, 1, 2 });
            new Segment("UnitSpellsOrSkills", new string[] { "UnitID", "SpellOrSkillNumber", "SpellEffectID" }, new int[] { 2, 1, 2 });
            new Segment("UnitCosts", new string[] { "UnitID", "ResourceID", "Amount" }, new int[] { 2, 1, 1 });
            new Segment("UnitCorpseLoot", new string[] { "UnitID", "SlotNumber", "Item1ID", "Item1Chance", "Item2ID", "Item2Chance", "Item3ID" }, new int[] { 2, 1, 2, 1, 2, 1, 2 });
            new Segment("UnitBuildings", new string[] { "UnitID", "RequirementNumber", "BuildingID" }, new int[] { 2, 1, 2 });
            /* TODO:
            new Segment("BuildingStats", new string[] { }, new int[] { });
            new Segment("BuildingStats2", new string[] { }, new int[] { });
            new Segment("BuildingRequirements", new string[] { }, new int[] { });
            new Segment("MagicIDNameID", new string[] { }, new int[] { });
            new Segment("SkillRequirements", new string[] { }, new int[] { });
            new Segment("MerchantIDUnitID", new string[] { }, new int[] { });
            new Segment("MerchantInventory", new string[] { }, new int[] { });
            new Segment("MerchantRates", new string[] { }, new int[] { });
            new Segment("sql_goodNames", new string[] { }, new int[] { });
            new Segment("PlayerLevelStats", new string[] { }, new int[] { });
            new Segment("ObjectStatsNames", new string[] { }, new int[] { });
            new Segment("MonumentInteractiveObjectStats", new string[] { }, new int[] { });
            new Segment("ChestLoot", new string[] { }, new int[] { });
            new Segment("Unknown2", new string[] { }, new int[] { });
            new Segment("QuestMaps", new string[] { }, new int[] { });
            new Segment("Portals", new string[] { }, new int[] { });
            new Segment("Unknown3", new string[] { }, new int[] { });
            new Segment("QuestGameMenu", new string[] { }, new int[] { });
            new Segment("ButtonDescription", new string[] { }, new int[] { });
            new Segment("QuestID", new string[] { }, new int[] { });
            new Segment("WeaponTypeStats", new string[] { }, new int[] { });
            new Segment("WeaponMaterial", new string[] { }, new int[] { });
            new Segment("Unknown4", new string[] { }, new int[] { });
            new Segment("Heads", new string[] { }, new int[] { });
            new Segment("UpgradeStatsUI", new string[] { }, new int[] { });
            new Segment("ItemSets", new string[] { }, new int[] { });
            */            
        }

        public static void WriteAll()
        {

        }

    }

    public static partial class Vars
    {
        public static string GameDataPath;
        public static byte[] GameDataFile;
        public static int CurrentOffset;
        public static byte[] Header = new byte[20];
        public static Dictionary<string, Segment> Segments;
    }
}