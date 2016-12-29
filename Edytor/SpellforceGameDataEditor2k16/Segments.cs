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

        private static void GetCount()
        {
            PreCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 6);
            Vars.CurrentOffset += 6;
            Count = Utils.LittleEndianToInt(Vars.GameDataFile.SubArray(Vars.CurrentOffset, 4)) / Length;
            Vars.CurrentOffset += 4;
            PostCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 2);
            Vars.CurrentOffset += 2;
        }

        public static void Read()
        {
            GetCount();
            for (int i = 0; i < Count; i++)
                Vars.SpellList.Add(new Spell(Vars.GameDataFile.SubArray(Vars.CurrentOffset + i * Length, Length)));
            Vars.CurrentOffset += Length * Count;
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

        private static void GetCount()
        {
            PreCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 6);
            Vars.CurrentOffset += 6;
            Count = Utils.LittleEndianToInt(Vars.GameDataFile.SubArray(Vars.CurrentOffset, 4)) / Length;
            Vars.CurrentOffset += 4;
            PostCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 2);
            Vars.CurrentOffset += 2;
        }

        public static void Read()
        {
            GetCount();
            for (int i = 0; i < Count; i++)
                Vars.SpellUIList.Add(new SpellUI(Vars.GameDataFile.SubArray(Vars.CurrentOffset + i * Length, Length)));
            Vars.CurrentOffset += Length * Count;
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

        private static void GetCount()
        {
            PreCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 6);
            Vars.CurrentOffset += 6;
            Count = Utils.LittleEndianToInt(Vars.GameDataFile.SubArray(Vars.CurrentOffset, 4)) / Length;
            Vars.CurrentOffset += 4;
            PostCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 2);
            Vars.CurrentOffset += 2;
        }

        public static void Read()
        {
            GetCount();
            for (int i = 0; i < Count; i++)
                Vars.Unknown1List.Add(new Unknown1(Vars.GameDataFile.SubArray(Vars.CurrentOffset + i * Length, Length)));
            Vars.CurrentOffset += Length * Count;
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

        private static void GetCount()
        {
            PreCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 6);
            Vars.CurrentOffset += 6;
            Count = Utils.LittleEndianToInt(Vars.GameDataFile.SubArray(Vars.CurrentOffset, 4)) / Length;
            Vars.CurrentOffset += 4;
            PostCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 2);
            Vars.CurrentOffset += 2;
        }

        public static void Read()
        {
            GetCount();
            for (int i = 0; i < Count; i++)
                Vars.UnitStatsList.Add(new UnitStats(Vars.GameDataFile.SubArray(Vars.CurrentOffset + i * Length, Length)));
            Vars.CurrentOffset += Length * Count;
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

        private static void GetCount()
        {
            PreCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 6);
            Vars.CurrentOffset += 6;
            Count = Utils.LittleEndianToInt(Vars.GameDataFile.SubArray(Vars.CurrentOffset, 4)) / Length;
            Vars.CurrentOffset += 4;
            PostCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 2);
            Vars.CurrentOffset += 2;
        }
        
        public static void Read()
        {
            GetCount();
            for (int i = 0; i < Count; i++)
                Vars.HeroWorkerAbilitiesList.Add(new HeroWorkerAbilities(Vars.GameDataFile.SubArray(Vars.CurrentOffset + i * Length, Length)));
            Vars.CurrentOffset += Length * Count;
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

        private static void GetCount()
        {
            PreCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 6);
            Vars.CurrentOffset += 6;
            Count = Utils.LittleEndianToInt(Vars.GameDataFile.SubArray(Vars.CurrentOffset, 4)) / Length;
            Vars.CurrentOffset += 4;
            PostCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 2);
            Vars.CurrentOffset += 2;
        }

        public static void Read()
        {
            GetCount();
            for (int i = 0; i < Count; i++)
                Vars.HeroSkillsList.Add(new HeroSkills(Vars.GameDataFile.SubArray(Vars.CurrentOffset + i * Length, Length)));
            Vars.CurrentOffset += Length * Count;
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

        private static void GetCount()
        {
            PreCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 6);
            Vars.CurrentOffset += 6;
            Count = Utils.LittleEndianToInt(Vars.GameDataFile.SubArray(Vars.CurrentOffset, 4)) / Length;
            Vars.CurrentOffset += 4;
            PostCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 2);
            Vars.CurrentOffset += 2;
        }

        public static void Read()
        {
            GetCount();
            for (int i = 0; i < Count; i++)
                Vars.ItemTypeList.Add(new ItemType(Vars.GameDataFile.SubArray(Vars.CurrentOffset + i * Length, Length)));
            Vars.CurrentOffset += Length * Count;
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

        private static void GetCount()
        {
            PreCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 6);
            Vars.CurrentOffset += 6;
            Count = Utils.LittleEndianToInt(Vars.GameDataFile.SubArray(Vars.CurrentOffset, 4)) / Length;
            Vars.CurrentOffset += 4;
            PostCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 2);
            Vars.CurrentOffset += 2;
        }

        public static void Read()
        {
            GetCount();
            for (int i = 0; i < Count; i++)
                Vars.ArmorItemStatsList.Add(new ArmorItemStats(Vars.GameDataFile.SubArray(Vars.CurrentOffset + i * Length, Length)));
            Vars.CurrentOffset += Length * Count;
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

        private static void GetCount()
        {
            PreCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 6);
            Vars.CurrentOffset += 6;
            Count = Utils.LittleEndianToInt(Vars.GameDataFile.SubArray(Vars.CurrentOffset, 4)) / Length;
            Vars.CurrentOffset += 4;
            PostCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 2);
            Vars.CurrentOffset += 2;
        }

        public static void Read()
        {
            GetCount();
            for (int i = 0; i < Count; i++)
                Vars.ScrollRuneIDList.Add(new ScrollRuneID(Vars.GameDataFile.SubArray(Vars.CurrentOffset + i * Length, Length)));
            Vars.CurrentOffset += Length * Count;
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

        private static void GetCount()
        {
            PreCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 6);
            Vars.CurrentOffset += 6;
            Count = Utils.LittleEndianToInt(Vars.GameDataFile.SubArray(Vars.CurrentOffset, 4)) / Length;
            Vars.CurrentOffset += 4;
            PostCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 2);
            Vars.CurrentOffset += 2;
        }

        public static void Read()
        {
            GetCount();
            for (int i = 0; i < Count; i++)
                Vars.WeaponItemStatsList.Add(new WeaponItemStats(Vars.GameDataFile.SubArray(Vars.CurrentOffset + i * Length, Length)));
            Vars.CurrentOffset += Length * Count;
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

        private static void GetCount()
        {
            PreCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 6);
            Vars.CurrentOffset += 6;
            Count = Utils.LittleEndianToInt(Vars.GameDataFile.SubArray(Vars.CurrentOffset, 4)) / Length;
            Vars.CurrentOffset += 4;
            PostCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 2);
            Vars.CurrentOffset += 2;
        }

        public static void Read()
        {
            GetCount();
            for (int i = 0; i < Count; i++)
                Vars.ItemRequirementsList.Add(new ItemRequirements(Vars.GameDataFile.SubArray(Vars.CurrentOffset + i * Length, Length)));
            Vars.CurrentOffset += Length * Count;
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

        private static void GetCount()
        {
            PreCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 6);
            Vars.CurrentOffset += 6;
            Count = Utils.LittleEndianToInt(Vars.GameDataFile.SubArray(Vars.CurrentOffset, 4)) / Length;
            Vars.CurrentOffset += 4;
            PostCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 2);
            Vars.CurrentOffset += 2;
        }

        public static void Read()
        {
            GetCount();
            for (int i = 0; i < Count; i++)
                Vars.ItemSpellEffectsList.Add(new ItemSpellEffects(Vars.GameDataFile.SubArray(Vars.CurrentOffset + i * Length, Length)));
            Vars.CurrentOffset += Length * Count;
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

        private static void GetCount()
        {
            PreCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 6);
            Vars.CurrentOffset += 6;
            Count = Utils.LittleEndianToInt(Vars.GameDataFile.SubArray(Vars.CurrentOffset, 4)) / Length;
            Vars.CurrentOffset += 4;
            PostCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 2);
            Vars.CurrentOffset += 2;
        }

        public static void Read()
        {
            GetCount();
            for (int i = 0; i < Count; i++)
                Vars.ItemUIList.Add(new ItemUI(Vars.GameDataFile.SubArray(Vars.CurrentOffset + i * Length, Length)));
            Vars.CurrentOffset += Length * Count;
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

        private static void GetCount()
        {
            PreCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 6);
            Vars.CurrentOffset += 6;
            Count = Utils.LittleEndianToInt(Vars.GameDataFile.SubArray(Vars.CurrentOffset, 4)) / Length;
            Vars.CurrentOffset += 4;
            PostCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 2);
            Vars.CurrentOffset += 2;
        }

        public static void Read()
        {
            GetCount();
            for (int i = 0; i < Count; i++)
                Vars.SpellItemIDList.Add(new SpellItemID(Vars.GameDataFile.SubArray(Vars.CurrentOffset + i * Length, Length)));
            Vars.CurrentOffset += Length * Count;
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

        private static void GetCount()
        {
            PreCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 6);
            Vars.CurrentOffset += 6;
            Count = Utils.LittleEndianToInt(Vars.GameDataFile.SubArray(Vars.CurrentOffset, 4)) / Length;
            Vars.CurrentOffset += 4;
            PostCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 2);
            Vars.CurrentOffset += 2;
        }

        public static void Read()
        {
            GetCount();
            for (int i = 0; i < Count; i++)
                Vars.TextsList.Add(new Texts(Vars.GameDataFile.SubArray(Vars.CurrentOffset + i * Length, Length)));
            Vars.CurrentOffset += Length * Count;
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

        private static void GetCount()
        {
            PreCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 6);
            Vars.CurrentOffset += 6;
            Count = Utils.LittleEndianToInt(Vars.GameDataFile.SubArray(Vars.CurrentOffset, 4)) / Length;
            Vars.CurrentOffset += 4;
            PostCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 2);
            Vars.CurrentOffset += 2;
        }

        public static void Read()
        {
            GetCount();
            for (int i = 0; i < Count; i++)
                Vars.RaceStatsList.Add(new RaceStats(Vars.GameDataFile.SubArray(Vars.CurrentOffset + i * Length, Length)));
            Vars.CurrentOffset += Length * Count;
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

        private static void GetCount()
        {
            PreCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 6);
            Vars.CurrentOffset += 6;
            Count = Utils.LittleEndianToInt(Vars.GameDataFile.SubArray(Vars.CurrentOffset, 4)) / Length;
            Vars.CurrentOffset += 4;
            PostCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 2);
            Vars.CurrentOffset += 2;
        }

        public static void Read()
        {
            GetCount();
            for (int i = 0; i < Count; i++)
                Vars.HeadStatsList.Add(new HeadStats(Vars.GameDataFile.SubArray(Vars.CurrentOffset + i * Length, Length)));
            Vars.CurrentOffset += Length * Count;
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

        private static void GetCount()
        {
            PreCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 6);
            Vars.CurrentOffset += 6;
            Count = Utils.LittleEndianToInt(Vars.GameDataFile.SubArray(Vars.CurrentOffset, 4)) / Length;
            Vars.CurrentOffset += 4;
            PostCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 2);
            Vars.CurrentOffset += 2;
        }

        public static void Read()
        {
            GetCount();
            for (int i = 0; i < Count; i++)
                Vars.UnitNamesList.Add(new UnitNames(Vars.GameDataFile.SubArray(Vars.CurrentOffset + i * Length, Length)));
            Vars.CurrentOffset += Length * Count;
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

        private static void GetCount()
        {
            PreCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 6);
            Vars.CurrentOffset += 6;
            Count = Utils.LittleEndianToInt(Vars.GameDataFile.SubArray(Vars.CurrentOffset, 4)) / Length;
            Vars.CurrentOffset += 4;
            PostCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 2);
            Vars.CurrentOffset += 2;
        }

        public static void Read()
        {
            GetCount();
            for (int i = 0; i < Count; i++)
                Vars.UnitEquipmentList.Add(new UnitEquipment(Vars.GameDataFile.SubArray(Vars.CurrentOffset + i * Length, Length)));
            Vars.CurrentOffset += Length * Count;
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

        private static void GetCount()
        {
            PreCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 6);
            Vars.CurrentOffset += 6;
            Count = Utils.LittleEndianToInt(Vars.GameDataFile.SubArray(Vars.CurrentOffset, 4)) / Length;
            Vars.CurrentOffset += 4;
            PostCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 2);
            Vars.CurrentOffset += 2;
        }

        public static void Read()
        {
            GetCount();
            for (int i = 0; i < Count; i++)
                Vars.UnitSpellsSkillsList.Add(new UnitSpellsSkills(Vars.GameDataFile.SubArray(Vars.CurrentOffset + i * Length, Length)));
            Vars.CurrentOffset += Length * Count;
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

        private static void GetCount()
        {
            PreCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 6);
            Vars.CurrentOffset += 6;
            Count = Utils.LittleEndianToInt(Vars.GameDataFile.SubArray(Vars.CurrentOffset, 4)) / Length;
            Vars.CurrentOffset += 4;
            PostCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 2);
            Vars.CurrentOffset += 2;
        }

        public static void Read()
        {
            GetCount();
            for (int i = 0; i < Count; i++)
                Vars.ArmyRequirementsList.Add(new ArmyRequirements(Vars.GameDataFile.SubArray(Vars.CurrentOffset + i * Length, Length)));
            Vars.CurrentOffset += Length * Count;
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

        private static void GetCount()
        {
            PreCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 6);
            Vars.CurrentOffset += 6;
            Count = Utils.LittleEndianToInt(Vars.GameDataFile.SubArray(Vars.CurrentOffset, 4)) / Length;
            Vars.CurrentOffset += 4;
            PostCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 2);
            Vars.CurrentOffset += 2;
        }

        public static void Read()
        {
            GetCount();
            for (int i = 0; i < Count; i++)
                Vars.UnitLootList.Add(new UnitLoot(Vars.GameDataFile.SubArray(Vars.CurrentOffset + i * Length, Length)));
            Vars.CurrentOffset += Length * Count;
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

        private static void GetCount()
        {
            PreCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 6);
            Vars.CurrentOffset += 6;
            Count = Utils.LittleEndianToInt(Vars.GameDataFile.SubArray(Vars.CurrentOffset, 4)) / Length;
            Vars.CurrentOffset += 4;
            PostCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 2);
            Vars.CurrentOffset += 2;
        }

        public static void Read()
        {
            GetCount();
            for (int i = 0; i < Count; i++)
                Vars.BuildingRequirementsList.Add(new BuildingRequirements(Vars.GameDataFile.SubArray(Vars.CurrentOffset + i * Length, Length)));
            Vars.CurrentOffset += Length * Count;
        }
    }    

    public class MagicIDNameID : Segment
    {
        public static int Length = 0;
        public static byte[] PreCount;
        public static int Count;
        public static byte[] PostCount;

        public MagicIDNameID(byte[] data) : base(data) { }

        private static void GetCount()
        {
            PreCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 6);
            Vars.CurrentOffset += 6;
            Count = Utils.LittleEndianToInt(Vars.GameDataFile.SubArray(Vars.CurrentOffset, 4)) / Length;
            Vars.CurrentOffset += 4;
            PostCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 2);
            Vars.CurrentOffset += 2;
        }

        public static void Read()
        {
            GetCount();
            for (int i = 0; i < Count; i++)
                Vars.MagicIDNameIDList.Add(new MagicIDNameID(Vars.GameDataFile.SubArray(Vars.CurrentOffset + i * Length, Length)));
            Vars.CurrentOffset += Length * Count;
        }
    }

    public class SkillRequirements : Segment
    {
        public static int Length = 0;
        public static byte[] PreCount;
        public static int Count;
        public static byte[] PostCount;

        public SkillRequirements(byte[] data) : base(data) { }

        private static void GetCount()
        {
            PreCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 6);
            Vars.CurrentOffset += 6;
            Count = Utils.LittleEndianToInt(Vars.GameDataFile.SubArray(Vars.CurrentOffset, 4)) / Length;
            Vars.CurrentOffset += 4;
            PostCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 2);
            Vars.CurrentOffset += 2;
        }
        public static void Read()
        {
            GetCount();
            for (int i = 0; i < Count; i++)
                Vars.SkillRequirementsList.Add(new SkillRequirements(Vars.GameDataFile.SubArray(Vars.CurrentOffset + i * Length, Length)));
            Vars.CurrentOffset += Length * Count;
        }
    }

    public class MerchantIDUnitID : Segment
    {
        public static int Length = 0;
        public static byte[] PreCount;
        public static int Count;
        public static byte[] PostCount;

        public MerchantIDUnitID(byte[] data) : base(data) { }

        private static void GetCount()
        {
            PreCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 6);
            Vars.CurrentOffset += 6;
            Count = Utils.LittleEndianToInt(Vars.GameDataFile.SubArray(Vars.CurrentOffset, 4)) / Length;
            Vars.CurrentOffset += 4;
            PostCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 2);
            Vars.CurrentOffset += 2;
        }

        public static void Read()
        {
            GetCount();
            for (int i = 0; i < Count; i++)
                Vars.MerchantIDUnitIDList.Add(new MerchantIDUnitID(Vars.GameDataFile.SubArray(Vars.CurrentOffset + i * Length, Length)));
            Vars.CurrentOffset += Length * Count;
        }
    }

    public class MerchantInventory : Segment
    {
        public static int Length = 0;
        public static byte[] PreCount;
        public static int Count;
        public static byte[] PostCount;

        public MerchantInventory(byte[] data) : base(data) { }

        private static void GetCount()
        {
            PreCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 6);
            Vars.CurrentOffset += 6;
            Count = Utils.LittleEndianToInt(Vars.GameDataFile.SubArray(Vars.CurrentOffset, 4)) / Length;
            Vars.CurrentOffset += 4;
            PostCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 2);
            Vars.CurrentOffset += 2;
        }

        public static void Read()
        {
            GetCount();
            for (int i = 0; i < Count; i++)
                Vars.MerchantInventoryList.Add(new MerchantInventory(Vars.GameDataFile.SubArray(Vars.CurrentOffset + i * Length, Length)));
            Vars.CurrentOffset += Length * Count;
        }
    }
    public class MerchantRates : Segment
    {
        public static int Length = 0;
        public static byte[] PreCount;
        public static int Count;
        public static byte[] PostCount;

        public MerchantRates(byte[] data) : base(data) { }

        private static void GetCount()
        {
            PreCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 6);
            Vars.CurrentOffset += 6;
            Count = Utils.LittleEndianToInt(Vars.GameDataFile.SubArray(Vars.CurrentOffset, 4)) / Length;
            Vars.CurrentOffset += 4;
            PostCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 2);
            Vars.CurrentOffset += 2;
        }

        public static void Read()
        {
            GetCount();
            for (int i = 0; i < Count; i++)
                Vars.MerchantRatesList.Add(new MerchantRates(Vars.GameDataFile.SubArray(Vars.CurrentOffset + i * Length, Length)));
            Vars.CurrentOffset += Length * Count;
        }
    }

    public class sql_goodNames : Segment
    {
        public static int Length = 0;
        public static byte[] PreCount;
        public static int Count;
        public static byte[] PostCount;

        public sql_goodNames(byte[] data) : base(data) { }

        private static void GetCount()
        {
            PreCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 6);
            Vars.CurrentOffset += 6;
            Count = Utils.LittleEndianToInt(Vars.GameDataFile.SubArray(Vars.CurrentOffset, 4)) / Length;
            Vars.CurrentOffset += 4;
            PostCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 2);
            Vars.CurrentOffset += 2;
        }

        public static void Read()
        {
            GetCount();
            for (int i = 0; i < Count; i++)
                Vars.sql_goodNamesList.Add(new sql_goodNames(Vars.GameDataFile.SubArray(Vars.CurrentOffset + i * Length, Length)));
            Vars.CurrentOffset += Length * Count;
        }
    }

    public class PlayerLevelStats : Segment
    {
        public static int Length = 0;
        public static byte[] PreCount;
        public static int Count;
        public static byte[] PostCount;

        public PlayerLevelStats(byte[] data) : base(data) { }

        private static void GetCount()
        {
            PreCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 6);
            Vars.CurrentOffset += 6;
            Count = Utils.LittleEndianToInt(Vars.GameDataFile.SubArray(Vars.CurrentOffset, 4)) / Length;
            Vars.CurrentOffset += 4;
            PostCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 2);
            Vars.CurrentOffset += 2;
        }

        public static void Read()
        {
            GetCount();
            for (int i = 0; i < Count; i++)
                Vars.PlayerLevelStatsList.Add(new PlayerLevelStats(Vars.GameDataFile.SubArray(Vars.CurrentOffset + i * Length, Length)));
            Vars.CurrentOffset += Length * Count;
        }
    }

    public class ObjectStatsNames : Segment
    {
        public static int Length = 0;
        public static byte[] PreCount;
        public static int Count;
        public static byte[] PostCount;

        public ObjectStatsNames(byte[] data) : base(data) { }

        private static void GetCount()
        {
            PreCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 6);
            Vars.CurrentOffset += 6;
            Count = Utils.LittleEndianToInt(Vars.GameDataFile.SubArray(Vars.CurrentOffset, 4)) / Length;
            Vars.CurrentOffset += 4;
            PostCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 2);
            Vars.CurrentOffset += 2;
        }

        public static void Read()
        {
            GetCount();
            for (int i = 0; i < Count; i++)
                Vars.ObjectStatsNamesList.Add(new ObjectStatsNames(Vars.GameDataFile.SubArray(Vars.CurrentOffset + i * Length, Length)));
            Vars.CurrentOffset += Length * Count;
        }
    }

    public class MonumentInteractiveObjectStats : Segment
    {
        public static int Length = 0;
        public static byte[] PreCount;
        public static int Count;
        public static byte[] PostCount;

        public MonumentInteractiveObjectStats(byte[] data) : base(data) { }

        private static void GetCount()
        {
            PreCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 6);
            Vars.CurrentOffset += 6;
            Count = Utils.LittleEndianToInt(Vars.GameDataFile.SubArray(Vars.CurrentOffset, 4)) / Length;
            Vars.CurrentOffset += 4;
            PostCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 2);
            Vars.CurrentOffset += 2;
        }

        public static void Read()
        {
            GetCount();
            for (int i = 0; i < Count; i++)
                Vars.MonumentInteractiveObjectStatsList.Add(new MonumentInteractiveObjectStats(Vars.GameDataFile.SubArray(Vars.CurrentOffset + i * Length, Length)));
            Vars.CurrentOffset += Length * Count;
        }
    }

    public class ChestLoot : Segment
    {
        public static int Length = 0;
        public static byte[] PreCount;
        public static int Count;
        public static byte[] PostCount;

        public ChestLoot(byte[] data) : base(data) { }

        private static void GetCount()
        {
            PreCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 6);
            Vars.CurrentOffset += 6;
            Count = Utils.LittleEndianToInt(Vars.GameDataFile.SubArray(Vars.CurrentOffset, 4)) / Length;
            Vars.CurrentOffset += 4;
            PostCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 2);
            Vars.CurrentOffset += 2;
        }

        public static void Read()
        {
            GetCount();
            for (int i = 0; i < Count; i++)
                Vars.ChestLootList.Add(new ChestLoot(Vars.GameDataFile.SubArray(Vars.CurrentOffset + i * Length, Length)));
            Vars.CurrentOffset += Length * Count;
        }
    }

    public class Unknown2 : Segment
    {
        public static int Length = 0;
        public static byte[] PreCount;
        public static int Count;
        public static byte[] PostCount;

        public Unknown2(byte[] data) : base(data) { }

        private static void GetCount()
        {
            PreCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 6);
            Vars.CurrentOffset += 6;
            Count = Utils.LittleEndianToInt(Vars.GameDataFile.SubArray(Vars.CurrentOffset, 4)) / Length;
            Vars.CurrentOffset += 4;
            PostCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 2);
            Vars.CurrentOffset += 2;
        }

        public static void Read()
        {
            GetCount();
            for (int i = 0; i < Count; i++)
                Vars.Unknown2List.Add(new Unknown2(Vars.GameDataFile.SubArray(Vars.CurrentOffset + i * Length, Length)));
            Vars.CurrentOffset += Length * Count;
        }
    }

    public class QuestMaps : Segment
    {
        public static int Length = 0;
        public static byte[] PreCount;
        public static int Count;
        public static byte[] PostCount;

        public QuestMaps(byte[] data) : base(data) { }

        private static void GetCount()
        {
            PreCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 6);
            Vars.CurrentOffset += 6;
            Count = Utils.LittleEndianToInt(Vars.GameDataFile.SubArray(Vars.CurrentOffset, 4)) / Length;
            Vars.CurrentOffset += 4;
            PostCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 2);
            Vars.CurrentOffset += 2;
        }

        public static void Read()
        {
            GetCount();
            for (int i = 0; i < Count; i++)
                Vars.QuestMapsList.Add(new QuestMaps(Vars.GameDataFile.SubArray(Vars.CurrentOffset + i * Length, Length)));
            Vars.CurrentOffset += Length * Count;
        }
    }

    public class Portals : Segment
    {
        public static int Length = 0;
        public static byte[] PreCount;
        public static int Count;
        public static byte[] PostCount;

        public Portals(byte[] data) : base(data) { }

        private static void GetCount()
        {
            PreCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 6);
            Vars.CurrentOffset += 6;
            Count = Utils.LittleEndianToInt(Vars.GameDataFile.SubArray(Vars.CurrentOffset, 4)) / Length;
            Vars.CurrentOffset += 4;
            PostCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 2);
            Vars.CurrentOffset += 2;
        }

        public static void Read()
        {
            GetCount();
            for (int i = 0; i < Count; i++)
                Vars.PortalsList.Add(new Portals(Vars.GameDataFile.SubArray(Vars.CurrentOffset + i * Length, Length)));
            Vars.CurrentOffset += Length * Count;
        }
    }

    public class Unknown3 : Segment
    {
        public static int Length = 0;
        public static byte[] PreCount;
        public static int Count;
        public static byte[] PostCount;

        public Unknown3(byte[] data) : base(data) { }

        private static void GetCount()
        {
            PreCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 6);
            Vars.CurrentOffset += 6;
            Count = Utils.LittleEndianToInt(Vars.GameDataFile.SubArray(Vars.CurrentOffset, 4)) / Length;
            Vars.CurrentOffset += 4;
            PostCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 2);
            Vars.CurrentOffset += 2;
        }

        public static void Read()
        {
            GetCount();
            for (int i = 0; i < Count; i++)
                Vars.Unknown3List.Add(new Unknown3(Vars.GameDataFile.SubArray(Vars.CurrentOffset + i * Length, Length)));
            Vars.CurrentOffset += Length * Count;
        }
    }
    
    public class QuestGameMenu : Segment
    {
        public static int Length = 0;
        public static byte[] PreCount;
        public static int Count;
        public static byte[] PostCount;

        public QuestGameMenu(byte[] data) : base(data) { }

        private static void GetCount()
        {
            PreCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 6);
            Vars.CurrentOffset += 6;
            Count = Utils.LittleEndianToInt(Vars.GameDataFile.SubArray(Vars.CurrentOffset, 4)) / Length;
            Vars.CurrentOffset += 4;
            PostCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 2);
            Vars.CurrentOffset += 2;
        }

        public static void Read()
        {
            GetCount();
            for (int i = 0; i < Count; i++)
                Vars.QuestGameMenuList.Add(new QuestGameMenu(Vars.GameDataFile.SubArray(Vars.CurrentOffset + i * Length, Length)));
            Vars.CurrentOffset += Length * Count;
        }
    }

    public class ButtonDescription : Segment
    {
        public static int Length = 0;
        public static byte[] PreCount;
        public static int Count;
        public static byte[] PostCount;

        public ButtonDescription(byte[] data) : base(data) { }

        private static void GetCount()
        {
            PreCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 6);
            Vars.CurrentOffset += 6;
            Count = Utils.LittleEndianToInt(Vars.GameDataFile.SubArray(Vars.CurrentOffset, 4)) / Length;
            Vars.CurrentOffset += 4;
            PostCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 2);
            Vars.CurrentOffset += 2;
        }

        public static void Read()
        {
            GetCount();
            for (int i = 0; i < Count; i++)
                Vars.ButtonDescriptionList.Add(new ButtonDescription(Vars.GameDataFile.SubArray(Vars.CurrentOffset + i * Length, Length)));
            Vars.CurrentOffset += Length * Count;
        }
    }

    public class QuestID : Segment
    {
        public static int Length = 0;
        public static byte[] PreCount;
        public static int Count;
        public static byte[] PostCount;

        public QuestID(byte[] data) : base(data) { }

        private static void GetCount()
        {
            PreCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 6);
            Vars.CurrentOffset += 6;
            Count = Utils.LittleEndianToInt(Vars.GameDataFile.SubArray(Vars.CurrentOffset, 4)) / Length;
            Vars.CurrentOffset += 4;
            PostCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 2);
            Vars.CurrentOffset += 2;
        }

        public static void Read()
        {
            GetCount();
            for (int i = 0; i < Count; i++)
                Vars.QuestIDList.Add(new QuestID(Vars.GameDataFile.SubArray(Vars.CurrentOffset + i * Length, Length)));
            Vars.CurrentOffset += Length * Count;
        }
    }

    public class WeaponTypeStats : Segment
    {
        public static int Length = 0;
        public static byte[] PreCount;
        public static int Count;
        public static byte[] PostCount;

        public WeaponTypeStats(byte[] data) : base(data) { }

        private static void GetCount()
        {
            PreCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 6);
            Vars.CurrentOffset += 6;
            Count = Utils.LittleEndianToInt(Vars.GameDataFile.SubArray(Vars.CurrentOffset, 4)) / Length;
            Vars.CurrentOffset += 4;
            PostCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 2);
            Vars.CurrentOffset += 2;
        }

        public static void Read()
        {
            GetCount();
            for (int i = 0; i < Count; i++)
                Vars.WeaponTypeStatsList.Add(new WeaponTypeStats(Vars.GameDataFile.SubArray(Vars.CurrentOffset + i * Length, Length)));
            Vars.CurrentOffset += Length * Count;
        }
    }

    public class WeaponMaterial : Segment
    {
        public static int Length = 0;
        public static byte[] PreCount;
        public static int Count;
        public static byte[] PostCount;

        public WeaponMaterial(byte[] data) : base(data) { }

        private static void GetCount()
        {
            PreCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 6);
            Vars.CurrentOffset += 6;
            Count = Utils.LittleEndianToInt(Vars.GameDataFile.SubArray(Vars.CurrentOffset, 4)) / Length;
            Vars.CurrentOffset += 4;
            PostCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 2);
            Vars.CurrentOffset += 2;
        }

        public static void Read()
        {
            GetCount();
            for (int i = 0; i < Count; i++)
                Vars.WeaponMaterialList.Add(new WeaponMaterial(Vars.GameDataFile.SubArray(Vars.CurrentOffset + i * Length, Length)));
            Vars.CurrentOffset += Length * Count;
        }
    }

    public class Unknown4 : Segment
    {
        public static int Length = 0;
        public static byte[] PreCount;
        public static int Count;
        public static byte[] PostCount;

        public Unknown4(byte[] data) : base(data) { }

        private static void GetCount()
        {
            PreCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 6);
            Vars.CurrentOffset += 6;
            Count = Utils.LittleEndianToInt(Vars.GameDataFile.SubArray(Vars.CurrentOffset, 4)) / Length;
            Vars.CurrentOffset += 4;
            PostCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 2);
            Vars.CurrentOffset += 2;
        }

        public static void Read()
        {
            GetCount();
            for (int i = 0; i < Count; i++)
                Vars.Unknown4List.Add(new Unknown4(Vars.GameDataFile.SubArray(Vars.CurrentOffset + i * Length, Length)));
            Vars.CurrentOffset += Length * Count;
        }
    }

    public class Heads : Segment
    {
        public static int Length = 0;
        public static byte[] PreCount;
        public static int Count;
        public static byte[] PostCount;

        public Heads(byte[] data) : base(data) { }

        private static void GetCount()
        {
            PreCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 6);
            Vars.CurrentOffset += 6;
            Count = Utils.LittleEndianToInt(Vars.GameDataFile.SubArray(Vars.CurrentOffset, 4)) / Length;
            Vars.CurrentOffset += 4;
            PostCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 2);
            Vars.CurrentOffset += 2;
        }

        public static void Read()
        {
            GetCount();
            for (int i = 0; i < Count; i++)
                Vars.HeadsList.Add(new Heads(Vars.GameDataFile.SubArray(Vars.CurrentOffset + i * Length, Length)));
            Vars.CurrentOffset += Length * Count;
        }
    }

    public class UpgradeStatsUI : Segment
    {
        public static int Length = 0;
        public static byte[] PreCount;
        public static int Count;
        public static byte[] PostCount;

        public UpgradeStatsUI(byte[] data) : base(data) { }

        private static void GetCount()
        {
            PreCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 6);
            Vars.CurrentOffset += 6;
            Count = Utils.LittleEndianToInt(Vars.GameDataFile.SubArray(Vars.CurrentOffset, 4)) / Length;
            Vars.CurrentOffset += 4;
            PostCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 2);
            Vars.CurrentOffset += 2;
        }

        public static void Read()
        {
            GetCount();
            for (int i = 0; i < Count; i++)
                Vars.UpgradeStatsUIList.Add(new UpgradeStatsUI(Vars.GameDataFile.SubArray(Vars.CurrentOffset + i * Length, Length)));
            Vars.CurrentOffset += Length * Count;
        }
    }

    public class ItemSets : Segment
    {
        public static int Length = 0;
        public static byte[] PreCount;
        public static int Count;
        public static byte[] PostCount;

        public ItemSets(byte[] data) : base(data) { }

        private static void GetCount()
        {
            PreCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 6);
            Vars.CurrentOffset += 6;
            Count = Utils.LittleEndianToInt(Vars.GameDataFile.SubArray(Vars.CurrentOffset, 4)) / Length;
            Vars.CurrentOffset += 4;
            PostCount = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 2);
            Vars.CurrentOffset += 2;
        }

        public static void Read()
        {
            GetCount();
            for (int i = 0; i < Count; i++)
                Vars.ItemSetsList.Add(new ItemSets(Vars.GameDataFile.SubArray(Vars.CurrentOffset + i * Length, Length)));
            Vars.CurrentOffset += Length * Count;
        }
    }

}