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
            new Segment("HeroWorkerAbilities", new string[] { "StatsID", "UnitAbilities" }, new int[] { 2, 3 });
            new Segment("HeroSkills", new string[] { "StatsID", "SpellNumber", "SpellEffectID" }, new int[] { 2, 1, 2 });
            new Segment("ItemType", new string[] { "ItemID", "ItemType", "ItemNameID", "UnitStatsID", "ArmyUnitID", "BuildingID", "Unknown", "SellingPrice", "BuyingPrice", "SetID" }, new int[] { 2, 2, 2, 2, 2, 2, 1, 4, 4, 1 });
            new Segment("ArmorItemStats", new string[] { "ItemID", "Strength", "Stamina", "Agility", "Dexterity", "HP", "Charisma", "Intelligence", "Wisdom", "Mana", "ArmorClass", "FireResist", "IceResist", "BlackResist", "MindResist", "RunSpeed", "FightSpeed", "CastSpeed" }, new int[] { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 });
            new Segment("ScrollRuneID", new string[] { "InventoryID", "AddedID" }, new int[] { 2, 2 });
            new Segment("WeaponItemStats", new string[] { "ItemID", "MinDamage", "MaxDamage", "MinRange", "MaxRange", "WeaponSpeed", "WeaponType", "WeaponMaterial" }, new int[] { 2, 2, 2, 2, 2, 2, 2, 2 });
            new Segment("ItemRequirements", new string[] { "ItemID", "RequirementNumber", "CombatMagicSchool", "CombatMagicSubSchool", "Level" }, new int[] { 2, 1, 1, 1, 1 });
            new Segment("ItemSpellEffects", new string[] { "ItemID", "ItemEffectNumber", "SpellEffectID" }, new int[] { 2, 1, 2 });
            new Segment("ItemUI", new string[] { "ItemID", "UINumber", "UIName", "Unknown" }, new int[] { 2, 1, 64, 2 });
            new Segment("SpellItemID", new string[] { "ItemID", "SpellEffectID" }, new int[] { 2, 2 });
            new Segment("Texts", new string[] { "TextID", "LanguageID", "DialogueNumber", "DialogueName", "RawText" }, new int[] { 2, 1, 1, 50, 512 });


        }

        public static void WriteAll()
        {

        }

    }

    public static partial class Vars
    {
        public static string GameDataPath;
        public static byte[] GameDataFile; //docelowo: public static List<byte> GameDataFile = new List<byte>();
        public static int CurrentOffset;
        public static byte[] Header = new byte[20];
        public static Dictionary<string, Segment> Segments;

    }
}