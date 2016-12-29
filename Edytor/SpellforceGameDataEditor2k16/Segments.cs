using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpellforceGameDataEditor2k16
{
    public class Spell
    {
        public static int Length = 76;
        public static int Count;
        public byte[] EffectID = new byte[2];
        public byte[] TypeID = new byte[2];
        public byte[] Reqs = new byte[12];
        public byte[] Mana = new byte[2];
        public byte[] CastingTime = new byte[4];
        public byte[] RecastTime = new byte[4];
        public byte[] MinRange = new byte[2];
        public byte[] MaxRange = new byte[2];
        public byte[] CastingType = new byte[2];
        public byte[] Stats = new byte[44];

        public Spell(byte[] data)
        {
            EffectID = data.SubArray(0, 2);
            TypeID = data.SubArray(2, 2);
            Reqs = data.SubArray(4, 12);
            Mana = data.SubArray(16, 2);
            CastingTime = data.SubArray(18, 4);
            RecastTime = data.SubArray(22, 4);
            MinRange = data.SubArray(26, 2);
            MaxRange = data.SubArray(28, 2);
            CastingType = data.SubArray(30, 2);
            Stats = data.SubArray(32, 44);
        }        
    }

    public class SpellUI
    {
        public static int Length = 75;
        public static int Count;

        public byte[] TypeID = new byte[2];
        public byte[] NameID = new byte[2];
        public byte[] Spellline = new byte[2];
        public byte[] Sorting = new byte[3];
        public byte[] UIName = new byte[64];
        public byte[] Unknown = new byte[2];

        public SpellUI(byte[] data)
        {
            TypeID = data.SubArray(0, 2);
            NameID = data.SubArray(2, 2);
            Spellline = data.SubArray(4, 2);
            Sorting = data.SubArray(6, 3);
            UIName = data.SubArray(9, 64);
            Unknown = data.SubArray(73, 2);
        }
    }

    public class Unknown1
    {
        public static int Length = 12;
        public static int Count;

        public byte[] Unknown = new byte[12];

        public Unknown1(byte[] data)
        {
            Unknown = data.SubArray(0, 12);
        }
    }

    public class UnitStats
    {
        public static int Length = 47;
        public static int Count;

        public byte[] StatsID = new byte[2];
        public byte[] Level = new byte[2];
        public byte[] RaceID = new byte[1];
        public byte[] Attribute = new byte[14]; //7 statów po 2 bajty
        public byte[] Unknown = new byte[2];
        public byte[] Resistance = new byte[8];
        public byte[] Speeds = new byte[6]; //3 szybkości po 2 bajty
        public byte[] Size = new byte[2];
        public byte[] Unknown2 = new byte[2];
        public byte[] SpawningTime = new byte[4];
        public byte[] Gender = new byte[1];
        public byte[] HeadID = new byte[2];
        public byte[] SlotsID = new byte[1];

        public UnitStats(byte[] data)
        {
            StatsID = data.SubArray(0, 2);
            Level = data.SubArray(2, 2);
            RaceID = data.SubArray(4, 1);
            Attribute = data.SubArray(5, 14);
            Unknown = data.SubArray(19, 2);
            Resistance = data.SubArray(21, 8);
            Speeds = data.SubArray(29, 6);
            Size = data.SubArray(35, 2);
            Unknown2 = data.SubArray(37, 2);
            SpawningTime = data.SubArray(39, 4);
            Gender = data.SubArray(43, 1);
            HeadID = data.SubArray(44, 2);
            SlotsID = data.SubArray(46, 1);
        }
    }

    public class HeroWorkerAbilities
    {
        public static int Length = 5;
        public static int Count;

        public byte[] StatsID = new byte[2];
        public byte[] UnitAbilities = new byte[3];

        public HeroWorkerAbilities(byte[] data)
        {
            StatsID = data.SubArray(0, 2);
            UnitAbilities = data.SubArray(2, 3);
        }
    }

    public class HeroSkills
    {
        public static int Length = 5;
        public static int Count;

        public byte[] StatsID = new byte[2];
        public byte[] SpellNumber = new byte[1];
        public byte[] SpellEffectID = new byte[2];

        public HeroSkills(byte[] data)
        {
            StatsID = data.SubArray(0, 2);
            SpellNumber = data.SubArray(2, 1);
            SpellEffectID = data.SubArray(3, 2);
        }
    }

    public class ItemType
    {
        public static int Length = 22;
        public static int Count;

        public byte[] ItemID = new byte[2];
        public byte[] Item_Type = new byte[2];
        public byte[] ItemNameID = new byte[2];
        public byte[] UnitStatsID = new byte[2];
        public byte[] ArmyUnitID = new byte[2];
        public byte[] BuildingID = new byte[2];
        public byte[] Unknown = new byte[1];
        public byte[] SellingPrice = new byte[4];
        public byte[] BuyingPrice = new byte[4];
        public byte[] SetID = new byte[1];

        public ItemType(byte[] data)
        {
            ItemID = data.SubArray(0, 2);
            Item_Type = data.SubArray(2, 2);
            ItemNameID = data.SubArray(4, 2);
            UnitStatsID = data.SubArray(6, 2);
            ArmyUnitID = data.SubArray(8, 2);
            BuildingID = data.SubArray(10, 2);
            Unknown = data.SubArray(12, 1);
            SellingPrice = data.SubArray(13, 4);
            BuyingPrice = data.SubArray(17, 4);
            SetID = data.SubArray(21, 1);
        }
    }
        
    public class ArmorItemStats
    {
        public static int Length = 36;
        public static int Count;

        public byte[] ItemID = new byte[2];
        public byte[] Strength = new byte[2];
        public byte[] Stamina = new byte[2];
        public byte[] Agility = new byte[2];
        public byte[] Dexterity = new byte[2];
        public byte[] HP = new byte[2];
        public byte[] Charisma = new byte[2];
        public byte[] Intelligence = new byte[2];
        public byte[] Wisdom = new byte[2];
        public byte[] Mana = new byte[2];
        public byte[] ArmorClass = new byte[2];
        public byte[] FireResist = new byte[2];
        public byte[] IceResist = new byte[2];
        public byte[] BlackResist = new byte[2];
        public byte[] MindResist = new byte[2];
        public byte[] RunSpeed = new byte[2];
        public byte[] FightSpeed = new byte[2];
        public byte[] CastSpeed = new byte[2];

        public ArmorItemStats(byte[] data)
        {
            ItemID = data.SubArray(0, 2);
            Strength = data.SubArray(2, 2);
            Stamina = data.SubArray(4, 2);
            Agility = data.SubArray(6, 2);
            Dexterity = data.SubArray(8, 2);
            HP = data.SubArray(10, 2);
            Charisma = data.SubArray(12, 2);
            Intelligence = data.SubArray(14, 2);
            Wisdom = data.SubArray(16, 2);
            Mana = data.SubArray(18, 2);
            ArmorClass = data.SubArray(20, 2);
            FireResist = data.SubArray(22, 2);
            IceResist = data.SubArray(24, 2);
            BlackResist = data.SubArray(26, 2);
            MindResist = data.SubArray(28, 2);
            RunSpeed = data.SubArray(30, 2);
            FightSpeed = data.SubArray(32, 2);
            CastSpeed = data.SubArray(34, 2);
        }
    }

    public class ScrollRuneID
    {
        public static int Length = 4;
        public static int Count;

        public byte[] InventoryID = new byte[2];
        public byte[] AddedID = new byte[2];

        public ScrollRuneID(byte[] data)
        {
            InventoryID = data.SubArray(0, 2);
            AddedID = data.SubArray(2, 2);
        }
    }

    public class WeaponItemStats
    {
        public static int Length = 16;
        public static int Count;

        public byte[] ItemID = new byte[2];
        public byte[] MinDamage = new byte[2];
        public byte[] MaxDamage = new byte[2];
        public byte[] MinRange = new byte[2];
        public byte[] MaxRange = new byte[2];
        public byte[] WeaponSpeed = new byte[2];
        public byte[] WeaponType = new byte[2];
        public byte[] WeaponMaterial = new byte[2];

        public WeaponItemStats(byte[] data)
        {
            ItemID = data.SubArray(0, 2);
            MinDamage = data.SubArray(2, 2);
            MaxDamage = data.SubArray(4, 2);
            MinRange = data.SubArray(6, 2);
            MaxRange = data.SubArray(8, 2);
            WeaponSpeed = data.SubArray(10, 2);
            WeaponType = data.SubArray(12, 2);
            WeaponMaterial = data.SubArray(14, 2);
        }
    }

    public class ItemRequirements
    {
        public static int Length = 6;
        public static int Count;

        public byte[] ItemID = new byte[2];
        public byte[] RequirementNumber = new byte[1];
        public byte[] CombatMagicSchool = new byte[1];
        public byte[] CombatMagicSubSchool = new byte[1];
        public byte[] Level = new byte[1];

        public ItemRequirements(byte[] data)
        {
            ItemID = data.SubArray(0, 2);
            RequirementNumber = data.SubArray(2, 1);
            CombatMagicSchool = data.SubArray(3, 1);
            CombatMagicSubSchool = data.SubArray(4, 1);
            Level = data.SubArray(5, 1);
        }
    }

    public class ItemSpellEffects
    {
        public static int Length = 5;
        public static int Count;

        public byte[] ItemID = new byte[2];
        public byte[] ItemEffectNumber = new byte[1];
        public byte[] SpellEffectID = new byte[2];

        public ItemSpellEffects(byte[] data)
        {
            ItemID = data.SubArray(0, 2);
            ItemEffectNumber = data.SubArray(2, 1);
            SpellEffectID = data.SubArray(3, 2);
        }
    }

    public class ItemUI
    {
        public static int Length = 69;
        public static int Count;

        public byte[] ItemID = new byte[2];
        public byte[] UINumber = new byte[1];
        public byte[] UIName = new byte[64];
        public byte[] Unknown = new byte[2];

        public ItemUI(byte[] data)
        {
            ItemID = data.SubArray(0, 2);
            UINumber = data.SubArray(2, 1);
            UIName = data.SubArray(3, 64);
            Unknown = data.SubArray(67, 2);
        }
    }

    public class SpellItemID
    {
        public static int Length = 4;
        public static int Count;

        public byte[] ItemID = new byte[2];
        public byte[] SpellEffectID = new byte[2];

        public SpellItemID(byte[] data)
        {
            ItemID = data.SubArray(0, 2);
            SpellEffectID = data.SubArray(2, 2);
        }
    }

    public class Texts
    {
        public static int Length = 566;
        public static int Count;

        public byte[] TextID = new byte[2];
        public byte[] LanguageID = new byte[1]; //00 DE, 01 EN, 02 FR, 03 SP, 04 IT
        public byte[] DialogueNumber = new byte[1];
        public byte[] DialogueName = new byte[50];
        public byte[] RawText = new byte[512];

        public Texts(byte[] data)
        {
            TextID = data.SubArray(0, 2);
            LanguageID = data.SubArray(1, 2);
            DialogueNumber = data.SubArray(3, 1);
            DialogueName = data.SubArray(4, 50);
            RawText = data.SubArray(54, 512);
        }
    }

    public class RaceStats
    {
        public static int Length = 27;
        public static int Count;

        public byte[] RaceID = new byte[1];
        public byte[] Unknown1 = new byte[6];
        public byte[] RaceNameID = new byte[2];
        public byte[] Unknown2 = new byte[7];
        public byte[] StatsID = new byte[3]; //from race lua script
        public byte[] Unknown3 = new byte[8];

        public RaceStats(byte[] data)
        {
            RaceID = data.SubArray(0, 1);
            Unknown1 = data.SubArray(1, 6);
            RaceNameID = data.SubArray(7, 2);
            Unknown2 = data.SubArray(9, 7);
            StatsID = data.SubArray(16, 3);
            Unknown3 = data.SubArray(19, 8);
        }
    }

    public class HeadStats
    {
        public static int Length = 3;
        public static int Count;

        public byte[] HeadID1 = new byte[1];
        public byte[] HeadID2 = new byte[1];
        public byte[] Unknown = new byte[1];

        public HeadStats(byte[] data)
        {
            HeadID1 = data.SubArray(0, 1);
            HeadID2 = data.SubArray(1, 1);
            Unknown = data.SubArray(2, 1);
        }
    }

    public class UnitNames
    {
        public static int Length = 64;
        public static int Count;

        public byte[] UnitID = new byte[2];
        public byte[] NameID = new byte[2];
        public byte[] UnitStatsID = new byte[2];
        public byte[] UnitExp = new byte[4];
        public byte[] Unknown1 = new byte[2];
        public byte[] HPFactor = {0x0, 0x0, 0x0, 0x0}; //has to be 00 00 00 00, player stats override this anyway
        public byte[] Unknown2 = new byte[5];
        public byte[] UnitAC = new byte[2];
        public byte[] UnitName = new byte[40];
        public byte[] Unknown3 = new byte[1];

        public UnitNames(byte[] data)
        {
            UnitID = data.SubArray(0, 2);
            NameID = data.SubArray(2, 2);
            UnitStatsID = data.SubArray(4, 2);
            UnitExp = data.SubArray(6, 4);
            Unknown1 = data.SubArray(10, 2);
            HPFactor = data.SubArray(12, 4);
            Unknown2 = data.SubArray(16, 5);
            UnitAC = data.SubArray(21, 2);
            UnitName = data.SubArray(23, 40);
            Unknown3 = data.SubArray(63, 1);
        }
    }

    public class UnitEquipment
    {
        public static int Length = 5;
        public static int Count;

        public byte[] UnitID  = new byte[2];
        public byte[] SlotID = new byte[1]; //00 head, 01 rhand, 02 chest, 03 lhand, 04 rring, 05 legs, 06 lring
        public byte[] ItemID = new byte[2];

        public UnitEquipment(byte[] data)
        {
            UnitID = data.SubArray(0, 2);
            SlotID = data.SubArray(2, 1);
            ItemID = data.SubArray(3, 2);
        }
    }

    public class UnitSpellsSkills
    {
        public static int Length = 5;
        public static int Count;

        public byte[] UnitID = new byte[2];
        public byte[] SpellSkillNumber = new byte[1];
        public byte[] SpellEffectID = new byte[2];

        public UnitSpellsSkills(byte[] data)
        {
            UnitID = data.SubArray(0, 2);
            SpellSkillNumber = data.SubArray(2, 1);
            SpellEffectID = data.SubArray(3, 2);
        }
    }

    public class ArmyRequirements
    {
        public static int Length = 4;
        public static int Count;

        public byte[] UnitID = new byte[2];
        public byte[] ResourceID = new byte[1]; //01 wood, 02 stone, 03 log(!), 04 moonsilver, 05 food, 06 berry(!?), 07 iron, 08 tree(!?), 09 grain(!?), 0B fish(!?), 0F mushroom(!?), 10 meat(!?), 12 aria, 13 lenya
        public byte[] Amount = new byte[1];

        public ArmyRequirements(byte[] data)
        {
            UnitID = data.SubArray(0, 2);
            ResourceID = data.SubArray(2, 1);
            Amount = data.SubArray(3, 1);
        }
    }

    public class UnitLoot
    {
        public static int Length = 11;
        public static int Count;

        public byte[] UnitID = new byte[2];
        public byte[] SlotNumber = new byte[1];
        public byte[] Item1ID = new byte[2];
        public byte[] Item1Chance = new byte[1];
        public byte[] Item2ID = new byte[2];
        public byte[] Item2Chance = new byte[1];
        public byte[] Item3ID = new byte[2]; //its chance is 100-(Item1Chance+Item2Chance)

        public UnitLoot(byte[] data)
        {
            UnitID = data.SubArray(0, 2);
            SlotNumber = data.SubArray(2, 1);
            Item1ID = data.SubArray(3, 2);
            Item1Chance = data.SubArray(5, 1);
            Item2ID = data.SubArray(6, 2);
            Item2Chance = data.SubArray(8, 1);
            Item3ID = data.SubArray(9, 2);
        }
    }

    public class BuildingRequirements
    {
        public static int Length = 5;
        public static int Count;

        public byte[] UnitID = new byte[2];
        public byte[] RequirementNumber = new byte[1];
        public byte[] BuildingID = new byte[2];

        public BuildingRequirements(byte[] data)
        {
            UnitID = data.SubArray(0, 2);
            RequirementNumber = data.SubArray(2, 1);
            BuildingID = data.SubArray(3, 2);
        }
    }
    //FIN *.*

    public class MagicIDNameID
    {
        public static int Length = 0;
        public static int Count;

    }

    public class SkillRequirements
    {
        public static int Length = 6;
        public static int Count;

    }

    public class MerchantIDUnitID
    {
        public static int Length = 6;
        public static int Count;

    }

    public class MerchantInventory
    {
        public static int Length = 6;
        public static int Count;

    }
    public class MerchantRates
    {
        public static int Length = 6;
        public static int Count;

    }

    public class sql_goodNames
    {
        public static int Length = 6;
        public static int Count;

    }

    public class PlayerLevelStats
    {
        public static int Length = 6;
        public static int Count;

    }

    public class ObjectStatsNames
    {
        public static int Length = 6;
        public static int Count;

    }

    public class MonumentInteractiveObjectStats
    {
        public static int Length = 6;
        public static int Count;

    }

    public class ChestLoot
    {
        public static int Length = 6;
        public static int Count;

    }

    //public class Unknown2
    //{
    //    public static int Length = ;
    //    public static int Count;
    //
    //}

    public class QuestMaps
    {
        public static int Length = 6;
        public static int Count;

    }

    public class Portals
    {
        public static int Length = 6;
        public static int Count;

    }

    //public class Unknown3 /*(maybe from sql_effect.lua)*/
    //{
    //    public static int Length = ;
    //    public static int Count;
    //
    //}

    public class QuestGameMenu
    {
        public static int Length = 6;
        public static int Count;

    }

    public class ButtonDescription
    {
        public static int Length = 6;
        public static int Count;

    }

    public class QuestID
    {
        public static int Length = 6;
        public static int Count;

    }

    public class WeaponTypeStats
    {
        public static int Length = 6;
        public static int Count;

    }

    public class WeaponMaterial
    {
        public static int Length = 6;
        public static int Count;

    }

    //public class Unknown4
    //{
    //    public static int Length = ;
    //    public static int Count;
    //
    //}

    public class Heads
    {
        public static int Length = 6;
        public static int Count;

    }

    public class UpgradeStatsUI
    {
        public static int Length = 6;
        public static int Count;

    }

    public class ItemSets
    {
        public static int Length = 6;
        public static int Count;

    }

}