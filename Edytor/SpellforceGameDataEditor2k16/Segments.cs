using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace SpellforceGameDataEditor2k16
{
    public class Segment
    {
        public Segment(byte[] data)
        {
            int offset = 0;
            FieldInfo[] fields = GetType().GetFields(BindingFlags.Instance | BindingFlags.Public);
            for (int f = 0; f < fields.Length; f++)
            {
                byte[] field = (byte[])fields[f].GetValue(this);
                int length = field.Length;
                fields[f].SetValue(this, data.SubArray(offset, length));
                offset += length;
            }
        }

        public byte[] Serialize()
        {
            var data = GetType()
                      .GetFields(BindingFlags.Instance | BindingFlags.Public)
                      .Select(field => field.GetValue(this))
                      .ToList()
                      .Cast<byte[]>()
                      .ToList()
                      .SelectMany(a => a)
                      .ToArray();

            return data;
        }
    }

    public class Spell : Segment
    {
        public static int Length = 76;
        public static byte[] PreCount;
        public static int Count;
        public static byte[] PostCount;

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

        public Spell(byte[] data) : base(data) { }

        public static void GetCount()
        {
            PreCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 6);
            Vars.CurrentOffset += 6;
            Count = Utils.LittleEndianToInt(Vars.GameDataFile.SubArray(Vars.CurrentOffset, 4)) / Length;
            Vars.CurrentOffset += 4;
            PostCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 2);
            Vars.CurrentOffset += 2;
        }
    }

    public class SpellUI : Segment
    {
        public static int Length = 75;
        public static byte[] PreCount;
        public static int Count;
        public static byte[] PostCount;

        public byte[] TypeID = new byte[2];
        public byte[] NameID = new byte[2];
        public byte[] Spellline = new byte[2];
        public byte[] Sorting = new byte[3];
        public byte[] UIName = new byte[64];
        public byte[] Unknown = new byte[2];

        public SpellUI(byte[] data) : base(data) { }

        public static void GetCount()
        {
            PreCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 6);
            Vars.CurrentOffset += 6;
            Count = Utils.LittleEndianToInt(Vars.GameDataFile.SubArray(Vars.CurrentOffset, 4)) / Length;
            Vars.CurrentOffset += 4;
            PostCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 2);
            Vars.CurrentOffset += 2;
        }
    }

    public class Unknown1 : Segment
    {
        public static int Length = 12;
        public static byte[] PreCount;
        public static int Count;
        public static byte[] PostCount;

        public byte[] Unknown = new byte[12];

        public Unknown1(byte[] data) : base(data) { }

        public static void GetCount()
        {
            PreCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 6);
            Vars.CurrentOffset += 6;
            Count = Utils.LittleEndianToInt(Vars.GameDataFile.SubArray(Vars.CurrentOffset, 4)) / Length;
            Vars.CurrentOffset += 4;
            PostCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 2);
            Vars.CurrentOffset += 2;
        }
    }

    public class UnitStats : Segment
    {
        public static int Length = 47;
        public static byte[] PreCount;
        public static int Count;
        public static byte[] PostCount;

        public byte[] StatsID = new byte[2];
        public byte[] Level = new byte[2];
        public byte[] RaceID = new byte[1];
        public byte[] Attribute = new byte[14]; 
        public byte[] Unknown = new byte[2];
        public byte[] Resistance = new byte[8];
        public byte[] Speeds = new byte[6]; 
        public byte[] Size = new byte[2];
        public byte[] Unknown2 = new byte[2];
        public byte[] SpawningTime = new byte[4];
        public byte[] Gender = new byte[1];
        public byte[] HeadID = new byte[2];
        public byte[] SlotsID = new byte[1];

        public UnitStats(byte[] data) : base(data) { }

        public static void GetCount()
        {
            PreCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 6);
            Vars.CurrentOffset += 6;
            Count = Utils.LittleEndianToInt(Vars.GameDataFile.SubArray(Vars.CurrentOffset, 4)) / Length;
            Vars.CurrentOffset += 4;
            PostCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 2);
            Vars.CurrentOffset += 2;
        }

    }

    public class HeroWorkerAbilities : Segment
    {
        public static int Length = 5;
        public static byte[] PreCount;
        public static int Count;
        public static byte[] PostCount;

        public byte[] StatsID = new byte[2];
        public byte[] UnitAbilities = new byte[3];

        public HeroWorkerAbilities(byte[] data) : base(data) { }

        public static void GetCount()
        {
            PreCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 6);
            Vars.CurrentOffset += 6;
            Count = Utils.LittleEndianToInt(Vars.GameDataFile.SubArray(Vars.CurrentOffset, 4)) / Length;
            Vars.CurrentOffset += 4;
            PostCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 2);
            Vars.CurrentOffset += 2;
        }

    }

    public class HeroSkills : Segment
    {
        public static int Length = 5;
        public static byte[] PreCount;
        public static int Count;
        public static byte[] PostCount;

        public byte[] StatsID = new byte[2];
        public byte[] SpellNumber = new byte[1];
        public byte[] SpellEffectID = new byte[2];

        public HeroSkills(byte[] data) : base(data) { }

        public static void GetCount()
        {
            PreCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 6);
            Vars.CurrentOffset += 6;
            Count = Utils.LittleEndianToInt(Vars.GameDataFile.SubArray(Vars.CurrentOffset, 4)) / Length;
            Vars.CurrentOffset += 4;
            PostCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 2);
            Vars.CurrentOffset += 2;
        }

    }

    public class ItemType : Segment
    {
        public static int Length = 22;
        public static byte[] PreCount;
        public static int Count;
        public static byte[] PostCount;

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

        public ItemType(byte[] data) : base(data) { }

        public static void GetCount()
        {
            PreCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 6);
            Vars.CurrentOffset += 6;
            Count = Utils.LittleEndianToInt(Vars.GameDataFile.SubArray(Vars.CurrentOffset, 4)) / Length;
            Vars.CurrentOffset += 4;
            PostCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 2);
            Vars.CurrentOffset += 2;
        }
    }
        
    public class ArmorItemStats : Segment
    {
        public static int Length = 36;
        public static byte[] PreCount;
        public static int Count;
        public static byte[] PostCount;

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

        public ArmorItemStats(byte[] data) : base(data) { }

        public static void GetCount()
        {
            PreCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 6);
            Vars.CurrentOffset += 6;
            Count = Utils.LittleEndianToInt(Vars.GameDataFile.SubArray(Vars.CurrentOffset, 4)) / Length;
            Vars.CurrentOffset += 4;
            PostCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 2);
            Vars.CurrentOffset += 2;
        }
    }

    public class ScrollRuneID : Segment
    {
        public static int Length = 4;
        public static byte[] PreCount;
        public static int Count;
        public static byte[] PostCount;

        public byte[] InventoryID = new byte[2];
        public byte[] AddedID = new byte[2];

        public ScrollRuneID(byte[] data) : base(data) { }

        public static void GetCount()
        {
            PreCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 6);
            Vars.CurrentOffset += 6;
            Count = Utils.LittleEndianToInt(Vars.GameDataFile.SubArray(Vars.CurrentOffset, 4)) / Length;
            Vars.CurrentOffset += 4;
            PostCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 2);
            Vars.CurrentOffset += 2;
        }
    }

    public class WeaponItemStats : Segment
    {
        public static int Length = 16;
        public static byte[] PreCount;
        public static int Count;
        public static byte[] PostCount;

        public byte[] ItemID = new byte[2];
        public byte[] MinDamage = new byte[2];
        public byte[] MaxDamage = new byte[2];
        public byte[] MinRange = new byte[2];
        public byte[] MaxRange = new byte[2];
        public byte[] WeaponSpeed = new byte[2];
        public byte[] WeaponType = new byte[2];
        public byte[] WeaponMaterial = new byte[2];

        public WeaponItemStats(byte[] data) : base(data) { }

        public static void GetCount()
        {
            PreCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 6);
            Vars.CurrentOffset += 6;
            Count = Utils.LittleEndianToInt(Vars.GameDataFile.SubArray(Vars.CurrentOffset, 4)) / Length;
            Vars.CurrentOffset += 4;
            PostCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 2);
            Vars.CurrentOffset += 2;
        }
    }

    public class ItemRequirements : Segment
    {
        public static int Length = 6;
        public static byte[] PreCount;
        public static int Count;
        public static byte[] PostCount;

        public byte[] ItemID = new byte[2];
        public byte[] RequirementNumber = new byte[1];
        public byte[] CombatMagicSchool = new byte[1];
        public byte[] CombatMagicSubSchool = new byte[1];
        public byte[] Level = new byte[1];

        public ItemRequirements(byte[] data) : base(data) { }

        public static void GetCount()
        {
            PreCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 6);
            Vars.CurrentOffset += 6;
            Count = Utils.LittleEndianToInt(Vars.GameDataFile.SubArray(Vars.CurrentOffset, 4)) / Length;
            Vars.CurrentOffset += 4;
            PostCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 2);
            Vars.CurrentOffset += 2;
        }
    }

    public class ItemSpellEffects : Segment
    {
        public static int Length = 5;
        public static byte[] PreCount;
        public static int Count;
        public static byte[] PostCount;

        public byte[] ItemID = new byte[2];
        public byte[] ItemEffectNumber = new byte[1];
        public byte[] SpellEffectID = new byte[2];

        public ItemSpellEffects(byte[] data) : base(data) { }

        public static void GetCount()
        {
            PreCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 6);
            Vars.CurrentOffset += 6;
            Count = Utils.LittleEndianToInt(Vars.GameDataFile.SubArray(Vars.CurrentOffset, 4)) / Length;
            Vars.CurrentOffset += 4;
            PostCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 2);
            Vars.CurrentOffset += 2;
        }
    }

    public class ItemUI : Segment
    {
        public static int Length = 69;
        public static byte[] PreCount;
        public static int Count;
        public static byte[] PostCount;

        public byte[] ItemID = new byte[2];
        public byte[] UINumber = new byte[1];
        public byte[] UIName = new byte[64];
        public byte[] Unknown = new byte[2];

        public ItemUI(byte[] data) : base(data) { }

        public static void GetCount()
        {
            PreCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 6);
            Vars.CurrentOffset += 6;
            Count = Utils.LittleEndianToInt(Vars.GameDataFile.SubArray(Vars.CurrentOffset, 4)) / Length;
            Vars.CurrentOffset += 4;
            PostCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 2);
            Vars.CurrentOffset += 2;
        }
    }

    public class SpellItemID : Segment
    {
        public static int Length = 4;
        public static byte[] PreCount;
        public static int Count;
        public static byte[] PostCount;

        public byte[] ItemID = new byte[2];
        public byte[] SpellEffectID = new byte[2];

        public SpellItemID(byte[] data) : base(data) { }

        public static void GetCount()
        {
            PreCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 6);
            Vars.CurrentOffset += 6;
            Count = Utils.LittleEndianToInt(Vars.GameDataFile.SubArray(Vars.CurrentOffset, 4)) / Length;
            Vars.CurrentOffset += 4;
            PostCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 2);
            Vars.CurrentOffset += 2;
        }
    }

    public class Texts : Segment
    {
        public static int Length = 566;
        public static byte[] PreCount;
        public static int Count;
        public static byte[] PostCount;

        public byte[] TextID = new byte[2];
        public byte[] LanguageID = new byte[1]; 
        public byte[] DialogueNumber = new byte[1];
        public byte[] DialogueName = new byte[50];
        public byte[] RawText = new byte[512];

        public Texts(byte[] data) : base(data) { }

        public static void GetCount()
        {
            PreCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 6);
            Vars.CurrentOffset += 6;
            Count = Utils.LittleEndianToInt(Vars.GameDataFile.SubArray(Vars.CurrentOffset, 4)) / Length;
            Vars.CurrentOffset += 4;
            PostCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 2);
            Vars.CurrentOffset += 2;
        }
    }

    public class RaceStats : Segment
    {
        public static int Length = 27;
        public static byte[] PreCount;
        public static int Count;
        public static byte[] PostCount;

        public byte[] RaceID = new byte[1];
        public byte[] Unknown1 = new byte[6];
        public byte[] RaceNameID = new byte[2];
        public byte[] Unknown2 = new byte[7];
        public byte[] StatsID = new byte[3]; 
        public byte[] Unknown3 = new byte[8];

        public RaceStats(byte[] data) : base(data) { }

        public static void GetCount()
        {
            PreCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 6);
            Vars.CurrentOffset += 6;
            Count = Utils.LittleEndianToInt(Vars.GameDataFile.SubArray(Vars.CurrentOffset, 4)) / Length;
            Vars.CurrentOffset += 4;
            PostCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 2);
            Vars.CurrentOffset += 2;
        }
    }

    public class HeadStats : Segment
    {
        public static int Length = 3;
        public static byte[] PreCount;
        public static int Count;
        public static byte[] PostCount;

        public byte[] HeadID1 = new byte[1];
        public byte[] HeadID2 = new byte[1];
        public byte[] Unknown = new byte[1];

        public HeadStats(byte[] data) : base(data) { }

        public static void GetCount()
        {
            PreCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 6);
            Vars.CurrentOffset += 6;
            Count = Utils.LittleEndianToInt(Vars.GameDataFile.SubArray(Vars.CurrentOffset, 4)) / Length;
            Vars.CurrentOffset += 4;
            PostCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 2);
            Vars.CurrentOffset += 2;
        }
    }

    public class UnitNames : Segment
    {
        public static int Length = 64;
        public static byte[] PreCount;
        public static int Count;
        public static byte[] PostCount;

        public byte[] UnitID = new byte[2];
        public byte[] NameID = new byte[2];
        public byte[] UnitStatsID = new byte[2];
        public byte[] UnitExp = new byte[4];
        public byte[] Unknown1 = new byte[2];
        public byte[] HPFactor = {0x0, 0x0, 0x0, 0x0}; 
        public byte[] Unknown2 = new byte[5];
        public byte[] UnitAC = new byte[2];
        public byte[] UnitName = new byte[40];
        public byte[] Unknown3 = new byte[1];

        public UnitNames(byte[] data) : base(data) { }

        public static void GetCount()
        {
            PreCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 6);
            Vars.CurrentOffset += 6;
            Count = Utils.LittleEndianToInt(Vars.GameDataFile.SubArray(Vars.CurrentOffset, 4)) / Length;
            Vars.CurrentOffset += 4;
            PostCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 2);
            Vars.CurrentOffset += 2;
        }
    }

    public class UnitEquipment : Segment
    {
        public static int Length = 5;
        public static byte[] PreCount;
        public static int Count;
        public static byte[] PostCount;

        public byte[] UnitID  = new byte[2];
        public byte[] SlotID = new byte[1]; 
        public byte[] ItemID = new byte[2];

        public UnitEquipment(byte[] data) : base(data) { }

        public static void GetCount()
        {
            PreCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 6);
            Vars.CurrentOffset += 6;
            Count = Utils.LittleEndianToInt(Vars.GameDataFile.SubArray(Vars.CurrentOffset, 4)) / Length;
            Vars.CurrentOffset += 4;
            PostCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 2);
            Vars.CurrentOffset += 2;
        }
    }

    public class UnitSpellsSkills : Segment
    {
        public static int Length = 5;
        public static byte[] PreCount;
        public static int Count;
        public static byte[] PostCount;

        public byte[] UnitID = new byte[2];
        public byte[] SpellSkillNumber = new byte[1];
        public byte[] SpellEffectID = new byte[2];

        public UnitSpellsSkills(byte[] data) : base(data) { }

        public static void GetCount()
        {
            PreCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 6);
            Vars.CurrentOffset += 6;
            Count = Utils.LittleEndianToInt(Vars.GameDataFile.SubArray(Vars.CurrentOffset, 4)) / Length;
            Vars.CurrentOffset += 4;
            PostCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 2);
            Vars.CurrentOffset += 2;
        }
    }

    public class ArmyRequirements : Segment
    {
        public static int Length = 4;
        public static byte[] PreCount;
        public static int Count;
        public static byte[] PostCount;

        public byte[] UnitID = new byte[2];
        public byte[] ResourceID = new byte[1]; 
        public byte[] Amount = new byte[1];

        public ArmyRequirements(byte[] data) : base(data) { }

        public static void GetCount()
        {
            PreCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 6);
            Vars.CurrentOffset += 6;
            Count = Utils.LittleEndianToInt(Vars.GameDataFile.SubArray(Vars.CurrentOffset, 4)) / Length;
            Vars.CurrentOffset += 4;
            PostCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 2);
            Vars.CurrentOffset += 2;
        }
    }

    public class UnitLoot : Segment
    {
        public static int Length = 11;
        public static byte[] PreCount;
        public static int Count;
        public static byte[] PostCount;

        public byte[] UnitID = new byte[2];
        public byte[] SlotNumber = new byte[1];
        public byte[] Item1ID = new byte[2];
        public byte[] Item1Chance = new byte[1];
        public byte[] Item2ID = new byte[2];
        public byte[] Item2Chance = new byte[1];
        public byte[] Item3ID = new byte[2]; 

        public UnitLoot(byte[] data) : base(data) { }

        public static void GetCount()
        {
            PreCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 6);
            Vars.CurrentOffset += 6;
            Count = Utils.LittleEndianToInt(Vars.GameDataFile.SubArray(Vars.CurrentOffset, 4)) / Length;
            Vars.CurrentOffset += 4;
            PostCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 2);
            Vars.CurrentOffset += 2;
        }
    }

    public class BuildingRequirements : Segment
    {
        public static int Length = 5;
        public static byte[] PreCount;
        public static int Count;
        public static byte[] PostCount;

        public byte[] UnitID = new byte[2];
        public byte[] RequirementNumber = new byte[1];
        public byte[] BuildingID = new byte[2];

        public BuildingRequirements(byte[] data) : base(data) { }

        public static void GetCount()
        {
            PreCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 6);
            Vars.CurrentOffset += 6;
            Count = Utils.LittleEndianToInt(Vars.GameDataFile.SubArray(Vars.CurrentOffset, 4)) / Length;
            Vars.CurrentOffset += 4;
            PostCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 2);
            Vars.CurrentOffset += 2;
        }
    }    

    public class MagicIDNameID : Segment
    {
        public static int Length = 0;
        public static byte[] PreCount;
        public static int Count;
        public static byte[] PostCount;

        public MagicIDNameID(byte[] data) : base(data) { }

        public static void GetCount()
        {
            PreCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 6);
            Vars.CurrentOffset += 6;
            Count = Utils.LittleEndianToInt(Vars.GameDataFile.SubArray(Vars.CurrentOffset, 4)) / Length;
            Vars.CurrentOffset += 4;
            PostCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 2);
            Vars.CurrentOffset += 2;
        }
    }

    public class SkillRequirements : Segment
    {
        public static int Length = 0;
        public static byte[] PreCount;
        public static int Count;
        public static byte[] PostCount;

        public SkillRequirements(byte[] data) : base(data) { }

        public static void GetCount()
        {
            PreCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 6);
            Vars.CurrentOffset += 6;
            Count = Utils.LittleEndianToInt(Vars.GameDataFile.SubArray(Vars.CurrentOffset, 4)) / Length;
            Vars.CurrentOffset += 4;
            PostCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 2);
            Vars.CurrentOffset += 2;
        }
    }

    public class MerchantIDUnitID : Segment
    {
        public static int Length = 0;
        public static byte[] PreCount;
        public static int Count;
        public static byte[] PostCount;

        public MerchantIDUnitID(byte[] data) : base(data) { }

        public static void GetCount()
        {
            PreCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 6);
            Vars.CurrentOffset += 6;
            Count = Utils.LittleEndianToInt(Vars.GameDataFile.SubArray(Vars.CurrentOffset, 4)) / Length;
            Vars.CurrentOffset += 4;
            PostCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 2);
            Vars.CurrentOffset += 2;
        }
    }

    public class MerchantInventory : Segment
    {
        public static int Length = 0;
        public static byte[] PreCount;
        public static int Count;
        public static byte[] PostCount;

        public MerchantInventory(byte[] data) : base(data) { }

        public static void GetCount()
        {
            PreCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 6);
            Vars.CurrentOffset += 6;
            Count = Utils.LittleEndianToInt(Vars.GameDataFile.SubArray(Vars.CurrentOffset, 4)) / Length;
            Vars.CurrentOffset += 4;
            PostCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 2);
            Vars.CurrentOffset += 2;
        }
    }
    public class MerchantRates : Segment
    {
        public static int Length = 0;
        public static byte[] PreCount;
        public static int Count;
        public static byte[] PostCount;

        public MerchantRates(byte[] data) : base(data) { }

        public static void GetCount()
        {
            PreCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 6);
            Vars.CurrentOffset += 6;
            Count = Utils.LittleEndianToInt(Vars.GameDataFile.SubArray(Vars.CurrentOffset, 4)) / Length;
            Vars.CurrentOffset += 4;
            PostCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 2);
            Vars.CurrentOffset += 2;
        }
    }

    public class sql_goodNames : Segment
    {
        public static int Length = 0;
        public static byte[] PreCount;
        public static int Count;
        public static byte[] PostCount;

        public sql_goodNames(byte[] data) : base(data) { }

        public static void GetCount()
        {
            PreCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 6);
            Vars.CurrentOffset += 6;
            Count = Utils.LittleEndianToInt(Vars.GameDataFile.SubArray(Vars.CurrentOffset, 4)) / Length;
            Vars.CurrentOffset += 4;
            PostCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 2);
            Vars.CurrentOffset += 2;
        }
    }

    public class PlayerLevelStats : Segment
    {
        public static int Length = 0;
        public static byte[] PreCount;
        public static int Count;
        public static byte[] PostCount;

        public PlayerLevelStats(byte[] data) : base(data) { }

        public static void GetCount()
        {
            PreCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 6);
            Vars.CurrentOffset += 6;
            Count = Utils.LittleEndianToInt(Vars.GameDataFile.SubArray(Vars.CurrentOffset, 4)) / Length;
            Vars.CurrentOffset += 4;
            PostCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 2);
            Vars.CurrentOffset += 2;
        }
    }

    public class ObjectStatsNames : Segment
    {
        public static int Length = 0;
        public static byte[] PreCount;
        public static int Count;
        public static byte[] PostCount;

        public ObjectStatsNames(byte[] data) : base(data) { }

        public static void GetCount()
        {
            PreCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 6);
            Vars.CurrentOffset += 6;
            Count = Utils.LittleEndianToInt(Vars.GameDataFile.SubArray(Vars.CurrentOffset, 4)) / Length;
            Vars.CurrentOffset += 4;
            PostCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 2);
            Vars.CurrentOffset += 2;
        }
    }

    public class MonumentInteractiveObjectStats : Segment
    {
        public static int Length = 0;
        public static byte[] PreCount;
        public static int Count;
        public static byte[] PostCount;

        public MonumentInteractiveObjectStats(byte[] data) : base(data) { }

        public static void GetCount()
        {
            PreCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 6);
            Vars.CurrentOffset += 6;
            Count = Utils.LittleEndianToInt(Vars.GameDataFile.SubArray(Vars.CurrentOffset, 4)) / Length;
            Vars.CurrentOffset += 4;
            PostCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 2);
            Vars.CurrentOffset += 2;
        }
    }

    public class ChestLoot : Segment
    {
        public static int Length = 0;
        public static byte[] PreCount;
        public static int Count;
        public static byte[] PostCount;

        public ChestLoot(byte[] data) : base(data) { }

        public static void GetCount()
        {
            PreCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 6);
            Vars.CurrentOffset += 6;
            Count = Utils.LittleEndianToInt(Vars.GameDataFile.SubArray(Vars.CurrentOffset, 4)) / Length;
            Vars.CurrentOffset += 4;
            PostCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 2);
            Vars.CurrentOffset += 2;
        }
    }

    public class Unknown2 : Segment
    {
        public static int Length = 0;
        public static byte[] PreCount;
        public static int Count;
        public static byte[] PostCount;

        public Unknown2(byte[] data) : base(data) { }

        public static void GetCount()
        {
            PreCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 6);
            Vars.CurrentOffset += 6;
            Count = Utils.LittleEndianToInt(Vars.GameDataFile.SubArray(Vars.CurrentOffset, 4)) / Length;
            Vars.CurrentOffset += 4;
            PostCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 2);
            Vars.CurrentOffset += 2;
        }
    }

    public class QuestMaps : Segment
    {
        public static int Length = 0;
        public static byte[] PreCount;
        public static int Count;
        public static byte[] PostCount;

        public QuestMaps(byte[] data) : base(data) { }

        public static void GetCount()
        {
            PreCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 6);
            Vars.CurrentOffset += 6;
            Count = Utils.LittleEndianToInt(Vars.GameDataFile.SubArray(Vars.CurrentOffset, 4)) / Length;
            Vars.CurrentOffset += 4;
            PostCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 2);
            Vars.CurrentOffset += 2;
        }
    }

    public class Portals : Segment
    {
        public static int Length = 0;
        public static byte[] PreCount;
        public static int Count;
        public static byte[] PostCount;

        public Portals(byte[] data) : base(data) { }

        public static void GetCount()
        {
            PreCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 6);
            Vars.CurrentOffset += 6;
            Count = Utils.LittleEndianToInt(Vars.GameDataFile.SubArray(Vars.CurrentOffset, 4)) / Length;
            Vars.CurrentOffset += 4;
            PostCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 2);
            Vars.CurrentOffset += 2;
        }
    }

    public class Unknown3 : Segment
    {
        public static int Length = 0;
        public static byte[] PreCount;
        public static int Count;
        public static byte[] PostCount;

        public Unknown3(byte[] data) : base(data) { }

        public static void GetCount()
        {
            PreCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 6);
            Vars.CurrentOffset += 6;
            Count = Utils.LittleEndianToInt(Vars.GameDataFile.SubArray(Vars.CurrentOffset, 4)) / Length;
            Vars.CurrentOffset += 4;
            PostCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 2);
            Vars.CurrentOffset += 2;
        }
    }
    
    public class QuestGameMenu : Segment
    {
        public static int Length = 0;
        public static byte[] PreCount;
        public static int Count;
        public static byte[] PostCount;

        public QuestGameMenu(byte[] data) : base(data) { }

        public static void GetCount()
        {
            PreCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 6);
            Vars.CurrentOffset += 6;
            Count = Utils.LittleEndianToInt(Vars.GameDataFile.SubArray(Vars.CurrentOffset, 4)) / Length;
            Vars.CurrentOffset += 4;
            PostCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 2);
            Vars.CurrentOffset += 2;
        }
    }

    public class ButtonDescription : Segment
    {
        public static int Length = 0;
        public static byte[] PreCount;
        public static int Count;
        public static byte[] PostCount;

        public ButtonDescription(byte[] data) : base(data) { }

        public static void GetCount()
        {
            PreCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 6);
            Vars.CurrentOffset += 6;
            Count = Utils.LittleEndianToInt(Vars.GameDataFile.SubArray(Vars.CurrentOffset, 4)) / Length;
            Vars.CurrentOffset += 4;
            PostCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 2);
            Vars.CurrentOffset += 2;
        }
    }

    public class QuestID : Segment
    {
        public static int Length = 0;
        public static byte[] PreCount;
        public static int Count;
        public static byte[] PostCount;

        public QuestID(byte[] data) : base(data) { }

        public static void GetCount()
        {
            PreCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 6);
            Vars.CurrentOffset += 6;
            Count = Utils.LittleEndianToInt(Vars.GameDataFile.SubArray(Vars.CurrentOffset, 4)) / Length;
            Vars.CurrentOffset += 4;
            PostCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 2);
            Vars.CurrentOffset += 2;
        }
    }

    public class WeaponTypeStats : Segment
    {
        public static int Length = 0;
        public static byte[] PreCount;
        public static int Count;
        public static byte[] PostCount;

        public WeaponTypeStats(byte[] data) : base(data) { }

        public static void GetCount()
        {
            PreCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 6);
            Vars.CurrentOffset += 6;
            Count = Utils.LittleEndianToInt(Vars.GameDataFile.SubArray(Vars.CurrentOffset, 4)) / Length;
            Vars.CurrentOffset += 4;
            PostCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 2);
            Vars.CurrentOffset += 2;
        }
    }

    public class WeaponMaterial : Segment
    {
        public static int Length = 0;
        public static byte[] PreCount;
        public static int Count;
        public static byte[] PostCount;

        public WeaponMaterial(byte[] data) : base(data) { }

        public static void GetCount()
        {
            PreCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 6);
            Vars.CurrentOffset += 6;
            Count = Utils.LittleEndianToInt(Vars.GameDataFile.SubArray(Vars.CurrentOffset, 4)) / Length;
            Vars.CurrentOffset += 4;
            PostCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 2);
            Vars.CurrentOffset += 2;
        }
    }

    public class Unknown4 : Segment
    {
        public static int Length = 0;
        public static byte[] PreCount;
        public static int Count;
        public static byte[] PostCount;

        public Unknown4(byte[] data) : base(data) { }

        public static void GetCount()
        {
            PreCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 6);
            Vars.CurrentOffset += 6;
            Count = Utils.LittleEndianToInt(Vars.GameDataFile.SubArray(Vars.CurrentOffset, 4)) / Length;
            Vars.CurrentOffset += 4;
            PostCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 2);
            Vars.CurrentOffset += 2;
        }
    }

    public class Heads : Segment
    {
        public static int Length = 0;
        public static byte[] PreCount;
        public static int Count;
        public static byte[] PostCount;

        public Heads(byte[] data) : base(data) { }

        public static void GetCount()
        {
            PreCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 6);
            Vars.CurrentOffset += 6;
            Count = Utils.LittleEndianToInt(Vars.GameDataFile.SubArray(Vars.CurrentOffset, 4)) / Length;
            Vars.CurrentOffset += 4;
            PostCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 2);
            Vars.CurrentOffset += 2;
        }
    }

    public class UpgradeStatsUI : Segment
    {
        public static int Length = 0;
        public static byte[] PreCount;
        public static int Count;
        public static byte[] PostCount;

        public UpgradeStatsUI(byte[] data) : base(data) { }

        public static void GetCount()
        {
            PreCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 6);
            Vars.CurrentOffset += 6;
            Count = Utils.LittleEndianToInt(Vars.GameDataFile.SubArray(Vars.CurrentOffset, 4)) / Length;
            Vars.CurrentOffset += 4;
            PostCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 2);
            Vars.CurrentOffset += 2;
        }
    }

    public class ItemSets : Segment
    {
        public static int Length = 0;
        public static byte[] PreCount;
        public static int Count;
        public static byte[] PostCount;

        public ItemSets(byte[] data) : base(data) { }

        public static void GetCount()
        {
            PreCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 6);
            Vars.CurrentOffset += 6;
            Count = Utils.LittleEndianToInt(Vars.GameDataFile.SubArray(Vars.CurrentOffset, 4)) / Length;
            Vars.CurrentOffset += 4;
            PostCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 2);
            Vars.CurrentOffset += 2;
        }
    }

}