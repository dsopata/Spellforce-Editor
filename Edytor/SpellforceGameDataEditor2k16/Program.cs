using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;

namespace SpellforceGameDataEditor2k16
{
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

        public static void InitializeListDict()
        {
            Vars.ListDict.Add("Spell", new List<Spell>());
            Vars.ListDict.Add("SpellUI", new List<SpellUI>());
            Vars.ListDict.Add("Unknown1", new List<Unknown1>());
            Vars.ListDict.Add("UnitStats", new List<UnitStats>());
            Vars.ListDict.Add("HeroWorkerAbilities", new List<HeroWorkerAbilities> ());
            Vars.ListDict.Add("HeroSkills", new List<HeroSkills>());
            Vars.ListDict.Add("ItemType", new List<ItemType>());
            Vars.ListDict.Add("ArmorItemStats", new List<ArmorItemStats>());
            Vars.ListDict.Add("ScrollRuneID", new List<ScrollRuneID>());
            Vars.ListDict.Add("WeaponItemStats", new List<WeaponItemStats>());
            Vars.ListDict.Add("ItemRequirements", new List<ItemRequirements>());
            Vars.ListDict.Add("ItemSpellEffects", new List<ItemSpellEffects>());
            Vars.ListDict.Add("ItemUI", new List<ItemUI>());
            Vars.ListDict.Add("SpellItemID", new List<SpellItemID>());
            Vars.ListDict.Add("Texts", new List<Texts>());
            Vars.ListDict.Add("RaceStats", new List<RaceStats>());
            Vars.ListDict.Add("HeadStats", new List<HeadStats>());
            Vars.ListDict.Add("UnitNames", new List<UnitNames>());
            Vars.ListDict.Add("UnitEquipment", new List<UnitEquipment>());
            Vars.ListDict.Add("UnitSpellsSkills", new List<UnitSpellsSkills>());
            Vars.ListDict.Add("ArmyRequirements", new List<ArmyRequirements>());
            Vars.ListDict.Add("UnitLoot", new List<UnitLoot>());
            Vars.ListDict.Add("BuildingRequirements", new List<BuildingRequirements>());
            Vars.ListDict.Add("MagicIDNameID", new List<MagicIDNameID>());
            Vars.ListDict.Add("SkillRequirements", new List<SkillRequirements>());
            Vars.ListDict.Add("MerchantIDUnitID", new List<MerchantIDUnitID>());
            Vars.ListDict.Add("MerchantInventory", new List<MerchantInventory>());
            Vars.ListDict.Add("MerchantRates", new List<MerchantRates>());
            Vars.ListDict.Add("sql_goodNames", new List<sql_goodNames>());
            Vars.ListDict.Add("PlayerLevelStats", new List<PlayerLevelStats>());
            Vars.ListDict.Add("ObjectStatsNames", new List<ObjectStatsNames>());
            Vars.ListDict.Add("MonumentInteractiveObjectStats", new List<MonumentInteractiveObjectStats>());
            Vars.ListDict.Add("ChestLoot", new List<ChestLoot>());
            Vars.ListDict.Add("Unknown2", new List<Unknown2>());
            Vars.ListDict.Add("QuestMaps", new List<QuestMaps>());
            Vars.ListDict.Add("Portals", new List<Portals>());
            Vars.ListDict.Add("Unknown3", new List<Unknown3>());
            Vars.ListDict.Add("QuestGameMenu", new List<QuestGameMenu>());
            Vars.ListDict.Add("ButtonDescription", new List<ButtonDescription>());
            Vars.ListDict.Add("QuestID", new List<QuestID>());
            Vars.ListDict.Add("WeaponTypeStats", new List<WeaponTypeStats>());
            Vars.ListDict.Add("WeaponMaterial", new List<WeaponMaterial>());
            Vars.ListDict.Add("Unknown4", new List<Unknown4>());
            Vars.ListDict.Add("Heads", new List<Heads>());
            Vars.ListDict.Add("UpgradeStatsUI", new List<UpgradeStatsUI>());
            Vars.ListDict.Add("ItemSets", new List<ItemSets>());
        }

        public static void ReadAll()
        {
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
            //MagicIDNameID.Read();
            //SkillRequirements.Read();
            //MerchantIDUnitID.Read();
            //MerchantInventory.Read();
            //MerchantRates.Read();
            //sql_goodNames.Read();
            //PlayerLevelStats.Read();
            //ObjectStatsNames.Read();
            //MonumentInteractiveObjectStats.Read();
            //ChestLoot.Read();
            //Unknown2.Read();
            //QuestMaps.Read();
            //Portals.Read();
            //Unknown3.Read();
            //QuestGameMenu.Read();
            //ButtonDescription.Read();
            //QuestID.Read();
            //WeaponTypeStats.Read();
            //WeaponMaterial.Read();
            //Unknown4.Read();
            //Heads.Read();
            //UpgradeStatsUI.Read();
            //ItemSets.Read();
        }

        public static void WriteAll()
        {
            FileStream header = new FileStream(Vars.GameDataPath, FileMode.Create);
            header.Write(Vars.Header, 0, Vars.Header.Length);
            header.Close();

            FileStream stream = new FileStream(Vars.GameDataPath, FileMode.Append);
            Spell.Write(stream);
            SpellUI.Write(stream);
            Unknown1.Write(stream);
            UnitStats.Write(stream);
            HeroWorkerAbilities.Write(stream);
            HeroSkills.Write(stream);
            ItemType.Write(stream);
            ArmorItemStats.Write(stream);
            ScrollRuneID.Write(stream);
            WeaponItemStats.Write(stream);
            ItemRequirements.Write(stream);
            ItemSpellEffects.Write(stream);
            ItemUI.Write(stream);
            SpellItemID.Write(stream);
            Texts.Write(stream);
            RaceStats.Write(stream);
            HeadStats.Write(stream);
            UnitNames.Write(stream);
            UnitEquipment.Write(stream);
            UnitSpellsSkills.Write(stream);
            ArmyRequirements.Write(stream);
            UnitLoot.Write(stream);
            BuildingRequirements.Write(stream);
            MagicIDNameID.Write(stream);
            SkillRequirements.Write(stream);
            MerchantIDUnitID.Write(stream);
            MerchantInventory.Write(stream);
            MerchantRates.Write(stream);
            sql_goodNames.Write(stream);
            PlayerLevelStats.Write(stream);
            ObjectStatsNames.Write(stream);
            MonumentInteractiveObjectStats.Write(stream);
            ChestLoot.Write(stream);
            Unknown2.Write(stream);
            QuestMaps.Write(stream);
            Portals.Write(stream);
            Unknown3.Write(stream);
            QuestGameMenu.Write(stream);
            ButtonDescription.Write(stream);
            QuestID.Write(stream);
            WeaponTypeStats.Write(stream);
            WeaponMaterial.Write(stream);
            Unknown4.Write(stream);
            Heads.Write(stream);
            UpgradeStatsUI.Write(stream);
            ItemSets.Write(stream);
            stream.Close();
        }
    }

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
            //test
        }
    }
}
