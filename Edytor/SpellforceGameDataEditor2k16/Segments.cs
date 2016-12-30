using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.IO;

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
                ((List<Spell>)Vars.ListDict["Spell"]).Add(new Spell(Vars.GameDataFile.SubArray(Vars.CurrentOffset + i * Length, Length)));
            Vars.CurrentOffset += Length * Count;
        }

        public static void Write(FileStream stream)
        {
            int offset = 0;
            using (stream)                
            {
                stream.Write(PreCount, offset, PreCount.Length);
                offset += PreCount.Length;
                stream.Write(Utils.IntToLittleEndian(Count), offset, 4);
                offset += 4;
                stream.Write(PostCount, offset, PostCount.Length);
                offset += PostCount.Length;

                for (int i = 0; i < Count; i++)
                {
                    stream.Write(((List<Spell>)Vars.ListDict["Spell"])[i].Serialize(), offset, Length);
                    offset += Length;
                }
            }
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
                ((List<SpellUI>)Vars.ListDict["SpellUI"]).Add(new SpellUI(Vars.GameDataFile.SubArray(Vars.CurrentOffset + i * Length, Length)));
            Vars.CurrentOffset += Length * Count;
        }

        public static void Write(FileStream stream)
        {
            int offset = 0;
            using (stream)
            {
                stream.Write(PreCount, offset, PreCount.Length);
                offset += PreCount.Length;
                stream.Write(Utils.IntToLittleEndian(Count), offset, 4);
                offset += 4;
                stream.Write(PostCount, offset, PostCount.Length);
                offset += PostCount.Length;

                for (int i = 0; i < Count; i++)
                {
                    stream.Write(((List<SpellUI>)Vars.ListDict["SpellUI"])[i].Serialize(), offset, Length);
                    offset += Length;
                }
            }
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
                ((List<Unknown1>)Vars.ListDict["Unknown1"]).Add(new Unknown1(Vars.GameDataFile.SubArray(Vars.CurrentOffset + i * Length, Length)));
            Vars.CurrentOffset += Length * Count;
        }

        public static void Write(FileStream stream)
        {
            int offset = 0;
            using (stream)
            {
                stream.Write(PreCount, offset, PreCount.Length);
                offset += PreCount.Length;
                stream.Write(Utils.IntToLittleEndian(Count), offset, 4);
                offset += 4;
                stream.Write(PostCount, offset, PostCount.Length);
                offset += PostCount.Length;

                for (int i = 0; i < Count; i++)
                {
                    stream.Write(((List<Unknown1>)Vars.ListDict["Unknown1"])[i].Serialize(), offset, Length);
                    offset += Length;
                }
            }
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
                ((List<UnitStats>)Vars.ListDict["UnitStats"]).Add(new UnitStats(Vars.GameDataFile.SubArray(Vars.CurrentOffset + i * Length, Length)));
            Vars.CurrentOffset += Length * Count;
        }

        public static void Write(FileStream stream)
        {
            int offset = 0;
            using (stream)
            {
                stream.Write(PreCount, offset, PreCount.Length);
                offset += PreCount.Length;
                stream.Write(Utils.IntToLittleEndian(Count), offset, 4);
                offset += 4;
                stream.Write(PostCount, offset, PostCount.Length);
                offset += PostCount.Length;

                for (int i = 0; i < Count; i++)
                {
                    stream.Write(((List<UnitStats>)Vars.ListDict["UnitStats"])[i].Serialize(), offset, Length);
                    offset += Length;
                }
            }
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
                ((List<HeroWorkerAbilities>)Vars.ListDict["HeroWorkerAbilities"]).Add(new HeroWorkerAbilities(Vars.GameDataFile.SubArray(Vars.CurrentOffset + i * Length, Length)));
            Vars.CurrentOffset += Length * Count;
        }

        public static void Write(FileStream stream)
        {
            int offset = 0;
            using (stream)
            {
                stream.Write(PreCount, offset, PreCount.Length);
                offset += PreCount.Length;
                stream.Write(Utils.IntToLittleEndian(Count), offset, 4);
                offset += 4;
                stream.Write(PostCount, offset, PostCount.Length);
                offset += PostCount.Length;

                for (int i = 0; i < Count; i++)
                {
                    stream.Write(((List<HeroWorkerAbilities>)Vars.ListDict["HeroWorkerAbilities"])[i].Serialize(), offset, Length);
                    offset += Length;
                }
            }
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
                ((List<HeroSkills>)Vars.ListDict["HeroSkills"]).Add(new HeroSkills(Vars.GameDataFile.SubArray(Vars.CurrentOffset + i * Length, Length)));
            Vars.CurrentOffset += Length * Count;
        }

        public static void Write(FileStream stream)
        {
            int offset = 0;
            using (stream)
            {
                stream.Write(PreCount, offset, PreCount.Length);
                offset += PreCount.Length;
                stream.Write(Utils.IntToLittleEndian(Count), offset, 4);
                offset += 4;
                stream.Write(PostCount, offset, PostCount.Length);
                offset += PostCount.Length;

                for (int i = 0; i < Count; i++)
                {
                    stream.Write(((List<HeroSkills>)Vars.ListDict["HeroSkills"])[i].Serialize(), offset, Length);
                    offset += Length;
                }
            }
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
                ((List<ItemType>)Vars.ListDict["ItemType"]).Add(new ItemType(Vars.GameDataFile.SubArray(Vars.CurrentOffset + i * Length, Length)));
            Vars.CurrentOffset += Length * Count;
        }

        public static void Write(FileStream stream)
        {
            int offset = 0;
            using (stream)
            {
                stream.Write(PreCount, offset, PreCount.Length);
                offset += PreCount.Length;
                stream.Write(Utils.IntToLittleEndian(Count), offset, 4);
                offset += 4;
                stream.Write(PostCount, offset, PostCount.Length);
                offset += PostCount.Length;

                for (int i = 0; i < Count; i++)
                {
                    stream.Write(((List<ItemType>)Vars.ListDict["ItemType"])[i].Serialize(), offset, Length);
                    offset += Length;
                }
            }
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
                ((List<ArmorItemStats>)Vars.ListDict["ArmorItemStats"]).Add(new ArmorItemStats(Vars.GameDataFile.SubArray(Vars.CurrentOffset + i * Length, Length)));
            Vars.CurrentOffset += Length * Count;
        }

        public static void Write(FileStream stream)
        {
            int offset = 0;
            using (stream)
            {
                stream.Write(PreCount, offset, PreCount.Length);
                offset += PreCount.Length;
                stream.Write(Utils.IntToLittleEndian(Count), offset, 4);
                offset += 4;
                stream.Write(PostCount, offset, PostCount.Length);
                offset += PostCount.Length;

                for (int i = 0; i < Count; i++)
                {
                    stream.Write(((List<ArmorItemStats>)Vars.ListDict["ArmorItemStats"])[i].Serialize(), offset, Length);
                    offset += Length;
                }
            }
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
                ((List<ScrollRuneID>)Vars.ListDict["ScrollRuneID"]).Add(new ScrollRuneID(Vars.GameDataFile.SubArray(Vars.CurrentOffset + i * Length, Length)));
            Vars.CurrentOffset += Length * Count;
        }

        public static void Write(FileStream stream)
        {
            int offset = 0;
            using (stream)
            {
                stream.Write(PreCount, offset, PreCount.Length);
                offset += PreCount.Length;
                stream.Write(Utils.IntToLittleEndian(Count), offset, 4);
                offset += 4;
                stream.Write(PostCount, offset, PostCount.Length);
                offset += PostCount.Length;

                for (int i = 0; i < Count; i++)
                {
                    stream.Write(((List<ScrollRuneID>)Vars.ListDict["ScrollRuneID"])[i].Serialize(), offset, Length);
                    offset += Length;
                }
            }
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
                ((List<WeaponItemStats>)Vars.ListDict["WeaponItemStats"]).Add(new WeaponItemStats(Vars.GameDataFile.SubArray(Vars.CurrentOffset + i * Length, Length)));
            Vars.CurrentOffset += Length * Count;
        }

        public static void Write(FileStream stream)
        {
            int offset = 0;
            using (stream)
            {
                stream.Write(PreCount, offset, PreCount.Length);
                offset += PreCount.Length;
                stream.Write(Utils.IntToLittleEndian(Count), offset, 4);
                offset += 4;
                stream.Write(PostCount, offset, PostCount.Length);
                offset += PostCount.Length;

                for (int i = 0; i < Count; i++)
                {
                    stream.Write(((List<WeaponItemStats>)Vars.ListDict["WeaponItemStats"])[i].Serialize(), offset, Length);
                    offset += Length;
                }
            }
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
                ((List<ItemRequirements>)Vars.ListDict["ItemRequirements"]).Add(new ItemRequirements(Vars.GameDataFile.SubArray(Vars.CurrentOffset + i * Length, Length)));
            Vars.CurrentOffset += Length * Count;
        }

        public static void Write(FileStream stream)
        {
            int offset = 0;
            using (stream)
            {
                stream.Write(PreCount, offset, PreCount.Length);
                offset += PreCount.Length;
                stream.Write(Utils.IntToLittleEndian(Count), offset, 4);
                offset += 4;
                stream.Write(PostCount, offset, PostCount.Length);
                offset += PostCount.Length;

                for (int i = 0; i < Count; i++)
                {
                    stream.Write(((List<ItemRequirements>)Vars.ListDict["ItemRequirements"])[i].Serialize(), offset, Length);
                    offset += Length;
                }
            }
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
                ((List<ItemSpellEffects>)Vars.ListDict["ItemSpellEffects"]).Add(new ItemSpellEffects(Vars.GameDataFile.SubArray(Vars.CurrentOffset + i * Length, Length)));
            Vars.CurrentOffset += Length * Count;
        }

        public static void Write(FileStream stream)
        {
            int offset = 0;
            using (stream)
            {
                stream.Write(PreCount, offset, PreCount.Length);
                offset += PreCount.Length;
                stream.Write(Utils.IntToLittleEndian(Count), offset, 4);
                offset += 4;
                stream.Write(PostCount, offset, PostCount.Length);
                offset += PostCount.Length;

                for (int i = 0; i < Count; i++)
                {
                    stream.Write(((List<ItemSpellEffects>)Vars.ListDict["ItemSpellEffects"])[i].Serialize(), offset, Length);
                    offset += Length;
                }
            }
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
                ((List<ItemUI>)Vars.ListDict["ItemUI"]).Add(new ItemUI(Vars.GameDataFile.SubArray(Vars.CurrentOffset + i * Length, Length)));
            Vars.CurrentOffset += Length * Count;
        }

        public static void Write(FileStream stream)
        {
            int offset = 0;
            using (stream)
            {
                stream.Write(PreCount, offset, PreCount.Length);
                offset += PreCount.Length;
                stream.Write(Utils.IntToLittleEndian(Count), offset, 4);
                offset += 4;
                stream.Write(PostCount, offset, PostCount.Length);
                offset += PostCount.Length;

                for (int i = 0; i < Count; i++)
                {
                    stream.Write(((List<ItemUI>)Vars.ListDict["ItemUI"])[i].Serialize(), offset, Length);
                    offset += Length;
                }
            }
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
                ((List<SpellItemID>)Vars.ListDict["SpellItemID"]).Add(new SpellItemID(Vars.GameDataFile.SubArray(Vars.CurrentOffset + i * Length, Length)));
            Vars.CurrentOffset += Length * Count;
        }

        public static void Write(FileStream stream)
        {
            int offset = 0;
            using (stream)
            {
                stream.Write(PreCount, offset, PreCount.Length);
                offset += PreCount.Length;
                stream.Write(Utils.IntToLittleEndian(Count), offset, 4);
                offset += 4;
                stream.Write(PostCount, offset, PostCount.Length);
                offset += PostCount.Length;

                for (int i = 0; i < Count; i++)
                {
                    stream.Write(((List<SpellItemID>)Vars.ListDict["SpellItemID"])[i].Serialize(), offset, Length);
                    offset += Length;
                }
            }
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
                ((List<Texts>)Vars.ListDict["Texts"]).Add(new Texts(Vars.GameDataFile.SubArray(Vars.CurrentOffset + i * Length, Length)));
            Vars.CurrentOffset += Length * Count;
        }

        public static void Write(FileStream stream)
        {
            int offset = 0;
            using (stream)
            {
                stream.Write(PreCount, offset, PreCount.Length);
                offset += PreCount.Length;
                stream.Write(Utils.IntToLittleEndian(Count), offset, 4);
                offset += 4;
                stream.Write(PostCount, offset, PostCount.Length);
                offset += PostCount.Length;

                for (int i = 0; i < Count; i++)
                {
                    stream.Write(((List<Texts>)Vars.ListDict["Texts"])[i].Serialize(), offset, Length);
                    offset += Length;
                }
            }
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
                ((List<RaceStats>)Vars.ListDict["RaceStats"]).Add(new RaceStats(Vars.GameDataFile.SubArray(Vars.CurrentOffset + i * Length, Length)));
            Vars.CurrentOffset += Length * Count;
        }

        public static void Write(FileStream stream)
        {
            int offset = 0;
            using (stream)
            {
                stream.Write(PreCount, offset, PreCount.Length);
                offset += PreCount.Length;
                stream.Write(Utils.IntToLittleEndian(Count), offset, 4);
                offset += 4;
                stream.Write(PostCount, offset, PostCount.Length);
                offset += PostCount.Length;

                for (int i = 0; i < Count; i++)
                {
                    stream.Write(((List<RaceStats>)Vars.ListDict["RaceStats"])[i].Serialize(), offset, Length);
                    offset += Length;
                }
            }
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
                ((List<HeadStats>)Vars.ListDict["HeadStats"]).Add(new HeadStats(Vars.GameDataFile.SubArray(Vars.CurrentOffset + i * Length, Length)));
            Vars.CurrentOffset += Length * Count;
        }

        public static void Write(FileStream stream)
        {
            int offset = 0;
            using (stream)
            {
                stream.Write(PreCount, offset, PreCount.Length);
                offset += PreCount.Length;
                stream.Write(Utils.IntToLittleEndian(Count), offset, 4);
                offset += 4;
                stream.Write(PostCount, offset, PostCount.Length);
                offset += PostCount.Length;

                for (int i = 0; i < Count; i++)
                {
                    stream.Write(((List<HeadStats>)Vars.ListDict["HeadStats"])[i].Serialize(), offset, Length);
                    offset += Length;
                }
            }
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
                ((List<UnitNames>)Vars.ListDict["UnitNames"]).Add(new UnitNames(Vars.GameDataFile.SubArray(Vars.CurrentOffset + i * Length, Length)));
            Vars.CurrentOffset += Length * Count;
        }

        public static void Write(FileStream stream)
        {
            int offset = 0;
            using (stream)
            {
                stream.Write(PreCount, offset, PreCount.Length);
                offset += PreCount.Length;
                stream.Write(Utils.IntToLittleEndian(Count), offset, 4);
                offset += 4;
                stream.Write(PostCount, offset, PostCount.Length);
                offset += PostCount.Length;

                for (int i = 0; i < Count; i++)
                {
                    stream.Write(((List<UnitNames>)Vars.ListDict["UnitNames"])[i].Serialize(), offset, Length);
                    offset += Length;
                }
            }
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
                ((List<UnitEquipment>)Vars.ListDict["UnitEquipment"]).Add(new UnitEquipment(Vars.GameDataFile.SubArray(Vars.CurrentOffset + i * Length, Length)));
            Vars.CurrentOffset += Length * Count;
        }

        public static void Write(FileStream stream)
        {
            int offset = 0;
            using (stream)
            {
                stream.Write(PreCount, offset, PreCount.Length);
                offset += PreCount.Length;
                stream.Write(Utils.IntToLittleEndian(Count), offset, 4);
                offset += 4;
                stream.Write(PostCount, offset, PostCount.Length);
                offset += PostCount.Length;

                for (int i = 0; i < Count; i++)
                {
                    stream.Write(((List<UnitEquipment>)Vars.ListDict["UnitEquipment"])[i].Serialize(), offset, Length);
                    offset += Length;
                }
            }
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
                ((List<UnitSpellsSkills>)Vars.ListDict["UnitSpellsSkills"]).Add(new UnitSpellsSkills(Vars.GameDataFile.SubArray(Vars.CurrentOffset + i * Length, Length)));
            Vars.CurrentOffset += Length * Count;
        }

        public static void Write(FileStream stream)
        {
            int offset = 0;
            using (stream)
            {
                stream.Write(PreCount, offset, PreCount.Length);
                offset += PreCount.Length;
                stream.Write(Utils.IntToLittleEndian(Count), offset, 4);
                offset += 4;
                stream.Write(PostCount, offset, PostCount.Length);
                offset += PostCount.Length;

                for (int i = 0; i < Count; i++)
                {
                    stream.Write(((List<UnitSpellsSkills>)Vars.ListDict["UnitSpellsSkills"])[i].Serialize(), offset, Length);
                    offset += Length;
                }
            }
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
                ((List<ArmyRequirements>)Vars.ListDict["ArmyRequirements"]).Add(new ArmyRequirements(Vars.GameDataFile.SubArray(Vars.CurrentOffset + i * Length, Length)));
            Vars.CurrentOffset += Length * Count;
        }

        public static void Write(FileStream stream)
        {
            int offset = 0;
            using (stream)
            {
                stream.Write(PreCount, offset, PreCount.Length);
                offset += PreCount.Length;
                stream.Write(Utils.IntToLittleEndian(Count), offset, 4);
                offset += 4;
                stream.Write(PostCount, offset, PostCount.Length);
                offset += PostCount.Length;

                for (int i = 0; i < Count; i++)
                {
                    stream.Write(((List<ArmyRequirements>)Vars.ListDict["ArmyRequirements"])[i].Serialize(), offset, Length);
                    offset += Length;
                }
            }
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
                ((List<UnitLoot>)Vars.ListDict["UnitLoot"]).Add(new UnitLoot(Vars.GameDataFile.SubArray(Vars.CurrentOffset + i * Length, Length)));
            Vars.CurrentOffset += Length * Count;
        }

        public static void Write(FileStream stream)
        {
            int offset = 0;
            using (stream)
            {
                stream.Write(PreCount, offset, PreCount.Length);
                offset += PreCount.Length;
                stream.Write(Utils.IntToLittleEndian(Count), offset, 4);
                offset += 4;
                stream.Write(PostCount, offset, PostCount.Length);
                offset += PostCount.Length;

                for (int i = 0; i < Count; i++)
                {
                    stream.Write(((List<UnitLoot>)Vars.ListDict["UnitLoot"])[i].Serialize(), offset, Length);
                    offset += Length;
                }
            }
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
                ((List<BuildingRequirements>)Vars.ListDict["BuildingRequirements"]).Add(new BuildingRequirements(Vars.GameDataFile.SubArray(Vars.CurrentOffset + i * Length, Length)));
            Vars.CurrentOffset += Length * Count;
        }

        public static void Write(FileStream stream)
        {
            int offset = 0;
            using (stream)
            {
                stream.Write(PreCount, offset, PreCount.Length);
                offset += PreCount.Length;
                stream.Write(Utils.IntToLittleEndian(Count), offset, 4);
                offset += 4;
                stream.Write(PostCount, offset, PostCount.Length);
                offset += PostCount.Length;

                for (int i = 0; i < Count; i++)
                {
                    stream.Write(((List<BuildingRequirements>)Vars.ListDict["BuildingRequirements"])[i].Serialize(), offset, Length);
                    offset += Length;
                }
            }
        }
    }    

    public class MagicIDNameID : Segment
    {
        public static int Length = 0;
        public static byte[] PreCount;
        public static int Count;
        public static byte[] PostCount;

        //TODO

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
                ((List<MagicIDNameID>)Vars.ListDict["MagicIDNameID"]).Add(new MagicIDNameID(Vars.GameDataFile.SubArray(Vars.CurrentOffset + i * Length, Length)));
            Vars.CurrentOffset += Length * Count;
        }

        public static void Write(FileStream stream)
        {
            int offset = 0;
            using (stream)
            {
                stream.Write(PreCount, offset, PreCount.Length);
                offset += PreCount.Length;
                stream.Write(Utils.IntToLittleEndian(Count), offset, 4);
                offset += 4;
                stream.Write(PostCount, offset, PostCount.Length);
                offset += PostCount.Length;

                for (int i = 0; i < Count; i++)
                {
                    stream.Write(((List<MagicIDNameID>)Vars.ListDict["MagicIDNameID"])[i].Serialize(), offset, Length);
                    offset += Length;
                }
            }
        }
    }

    public class SkillRequirements : Segment
    {
        public static int Length = 0;
        public static byte[] PreCount;
        public static int Count;
        public static byte[] PostCount;

        //TODO

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
                ((List<SkillRequirements>)Vars.ListDict["SkillRequirements"]).Add(new SkillRequirements(Vars.GameDataFile.SubArray(Vars.CurrentOffset + i * Length, Length)));
            Vars.CurrentOffset += Length * Count;
        }

        public static void Write(FileStream stream)
        {
            int offset = 0;
            using (stream)
            {
                stream.Write(PreCount, offset, PreCount.Length);
                offset += PreCount.Length;
                stream.Write(Utils.IntToLittleEndian(Count), offset, 4);
                offset += 4;
                stream.Write(PostCount, offset, PostCount.Length);
                offset += PostCount.Length;

                for (int i = 0; i < Count; i++)
                {
                    stream.Write(((List<SkillRequirements>)Vars.ListDict["SkillRequirements"])[i].Serialize(), offset, Length);
                    offset += Length;
                }
            }
        }
    }

    public class MerchantIDUnitID : Segment
    {
        public static int Length = 0;
        public static byte[] PreCount;
        public static int Count;
        public static byte[] PostCount;

        //TODO

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
                ((List<MerchantIDUnitID>)Vars.ListDict["MerchantIDUnitID"]).Add(new MerchantIDUnitID(Vars.GameDataFile.SubArray(Vars.CurrentOffset + i * Length, Length)));
            Vars.CurrentOffset += Length * Count;
        }

        public static void Write(FileStream stream)
        {
            int offset = 0;
            using (stream)
            {
                stream.Write(PreCount, offset, PreCount.Length);
                offset += PreCount.Length;
                stream.Write(Utils.IntToLittleEndian(Count), offset, 4);
                offset += 4;
                stream.Write(PostCount, offset, PostCount.Length);
                offset += PostCount.Length;

                for (int i = 0; i < Count; i++)
                {
                    stream.Write(((List<MerchantIDUnitID>)Vars.ListDict["MerchantIDUnitID"])[i].Serialize(), offset, Length);
                    offset += Length;
                }
            }
        }
    }

    public class MerchantInventory : Segment
    {
        public static int Length = 0;
        public static byte[] PreCount;
        public static int Count;
        public static byte[] PostCount;

        //TODO

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
                ((List<MerchantInventory>)Vars.ListDict["MerchantInventory"]).Add(new MerchantInventory(Vars.GameDataFile.SubArray(Vars.CurrentOffset + i * Length, Length)));
            Vars.CurrentOffset += Length * Count;
        }

        public static void Write(FileStream stream)
        {
            int offset = 0;
            using (stream)
            {
                stream.Write(PreCount, offset, PreCount.Length);
                offset += PreCount.Length;
                stream.Write(Utils.IntToLittleEndian(Count), offset, 4);
                offset += 4;
                stream.Write(PostCount, offset, PostCount.Length);
                offset += PostCount.Length;

                for (int i = 0; i < Count; i++)
                {
                    stream.Write(((List<MerchantInventory>)Vars.ListDict["MerchantInventory"])[i].Serialize(), offset, Length);
                    offset += Length;
                }
            }
        }
    }
    public class MerchantRates : Segment
    {
        public static int Length = 0;
        public static byte[] PreCount;
        public static int Count;
        public static byte[] PostCount;

        //TODO

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
                ((List<MerchantRates>)Vars.ListDict["MerchantRates"]).Add(new MerchantRates(Vars.GameDataFile.SubArray(Vars.CurrentOffset + i * Length, Length)));
            Vars.CurrentOffset += Length * Count;
        }

        public static void Write(FileStream stream)
        {
            int offset = 0;
            using (stream)
            {
                stream.Write(PreCount, offset, PreCount.Length);
                offset += PreCount.Length;
                stream.Write(Utils.IntToLittleEndian(Count), offset, 4);
                offset += 4;
                stream.Write(PostCount, offset, PostCount.Length);
                offset += PostCount.Length;

                for (int i = 0; i < Count; i++)
                {
                    stream.Write(((List<MerchantRates>)Vars.ListDict["MerchantRates"])[i].Serialize(), offset, Length);
                    offset += Length;
                }
            }
        }
    }

    public class sql_goodNames : Segment
    {
        public static int Length = 0;
        public static byte[] PreCount;
        public static int Count;
        public static byte[] PostCount;

        //TODO

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
                ((List<sql_goodNames>)Vars.ListDict["sql_goodNames"]).Add(new sql_goodNames(Vars.GameDataFile.SubArray(Vars.CurrentOffset + i * Length, Length)));
            Vars.CurrentOffset += Length * Count;
        }

        public static void Write(FileStream stream)
        {
            int offset = 0;
            using (stream)
            {
                stream.Write(PreCount, offset, PreCount.Length);
                offset += PreCount.Length;
                stream.Write(Utils.IntToLittleEndian(Count), offset, 4);
                offset += 4;
                stream.Write(PostCount, offset, PostCount.Length);
                offset += PostCount.Length;

                for (int i = 0; i < Count; i++)
                {
                    stream.Write(((List<sql_goodNames>)Vars.ListDict["sql_goodNames"])[i].Serialize(), offset, Length);
                    offset += Length;
                }
            }
        }
    }

    public class PlayerLevelStats : Segment
    {
        public static int Length = 0;
        public static byte[] PreCount;
        public static int Count;
        public static byte[] PostCount;

        //TODO

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
                ((List<PlayerLevelStats>)Vars.ListDict["PlayerLevelStats"]).Add(new PlayerLevelStats(Vars.GameDataFile.SubArray(Vars.CurrentOffset + i * Length, Length)));
            Vars.CurrentOffset += Length * Count;
        }

        public static void Write(FileStream stream)
        {
            int offset = 0;
            using (stream)
            {
                stream.Write(PreCount, offset, PreCount.Length);
                offset += PreCount.Length;
                stream.Write(Utils.IntToLittleEndian(Count), offset, 4);
                offset += 4;
                stream.Write(PostCount, offset, PostCount.Length);
                offset += PostCount.Length;

                for (int i = 0; i < Count; i++)
                {
                    stream.Write(((List<PlayerLevelStats>)Vars.ListDict["PlayerLevelStats"])[i].Serialize(), offset, Length);
                    offset += Length;
                }
            }
        }
    }

    public class ObjectStatsNames : Segment
    {
        public static int Length = 0;
        public static byte[] PreCount;
        public static int Count;
        public static byte[] PostCount;

        //TODO

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
                ((List<ObjectStatsNames>)Vars.ListDict["ObjectStatsNames"]).Add(new ObjectStatsNames(Vars.GameDataFile.SubArray(Vars.CurrentOffset + i * Length, Length)));
            Vars.CurrentOffset += Length * Count;
        }

        public static void Write(FileStream stream)
        {
            int offset = 0;
            using (stream)
            {
                stream.Write(PreCount, offset, PreCount.Length);
                offset += PreCount.Length;
                stream.Write(Utils.IntToLittleEndian(Count), offset, 4);
                offset += 4;
                stream.Write(PostCount, offset, PostCount.Length);
                offset += PostCount.Length;

                for (int i = 0; i < Count; i++)
                {
                    stream.Write(((List<ObjectStatsNames>)Vars.ListDict["ObjectStatsNames"])[i].Serialize(), offset, Length);
                    offset += Length;
                }
            }
        }
    }

    public class MonumentInteractiveObjectStats : Segment
    {
        public static int Length = 0;
        public static byte[] PreCount;
        public static int Count;
        public static byte[] PostCount;

        //TODO

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
                ((List<MonumentInteractiveObjectStats>)Vars.ListDict["MonumentInteractiveObjectStats"]).Add(new MonumentInteractiveObjectStats(Vars.GameDataFile.SubArray(Vars.CurrentOffset + i * Length, Length)));
            Vars.CurrentOffset += Length * Count;
        }

        public static void Write(FileStream stream)
        {
            int offset = 0;
            using (stream)
            {
                stream.Write(PreCount, offset, PreCount.Length);
                offset += PreCount.Length;
                stream.Write(Utils.IntToLittleEndian(Count), offset, 4);
                offset += 4;
                stream.Write(PostCount, offset, PostCount.Length);
                offset += PostCount.Length;

                for (int i = 0; i < Count; i++)
                {
                    stream.Write(((List<MonumentInteractiveObjectStats>)Vars.ListDict["MonumentInteractiveObjectStats"])[i].Serialize(), offset, Length);
                    offset += Length;
                }
            }
        }
    }

    public class ChestLoot : Segment
    {
        public static int Length = 0;
        public static byte[] PreCount;
        public static int Count;
        public static byte[] PostCount;

        //TODO

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
                ((List<ChestLoot>)Vars.ListDict["ChestLoot"]).Add(new ChestLoot(Vars.GameDataFile.SubArray(Vars.CurrentOffset + i * Length, Length)));
            Vars.CurrentOffset += Length * Count;
        }

        public static void Write(FileStream stream)
        {
            int offset = 0;
            using (stream)
            {
                stream.Write(PreCount, offset, PreCount.Length);
                offset += PreCount.Length;
                stream.Write(Utils.IntToLittleEndian(Count), offset, 4);
                offset += 4;
                stream.Write(PostCount, offset, PostCount.Length);
                offset += PostCount.Length;

                for (int i = 0; i < Count; i++)
                {
                    stream.Write(((List<ChestLoot>)Vars.ListDict["ChestLoot"])[i].Serialize(), offset, Length);
                    offset += Length;
                }
            }
        }
    }

    public class Unknown2 : Segment
    {
        public static int Length = 0;
        public static byte[] PreCount;
        public static int Count;
        public static byte[] PostCount;

        //TODO

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
                ((List<Unknown2>)Vars.ListDict["Unknown2"]).Add(new Unknown2(Vars.GameDataFile.SubArray(Vars.CurrentOffset + i * Length, Length)));
            Vars.CurrentOffset += Length * Count;
        }

        public static void Write(FileStream stream)
        {
            int offset = 0;
            using (stream)
            {
                stream.Write(PreCount, offset, PreCount.Length);
                offset += PreCount.Length;
                stream.Write(Utils.IntToLittleEndian(Count), offset, 4);
                offset += 4;
                stream.Write(PostCount, offset, PostCount.Length);
                offset += PostCount.Length;

                for (int i = 0; i < Count; i++)
                {
                    stream.Write(((List<Unknown2>)Vars.ListDict["Unknown2"])[i].Serialize(), offset, Length);
                    offset += Length;
                }
            }
        }
    }

    public class QuestMaps : Segment
    {
        public static int Length = 0;
        public static byte[] PreCount;
        public static int Count;
        public static byte[] PostCount;

        //TODO

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
                ((List<QuestMaps>)Vars.ListDict["QuestMaps"]).Add(new QuestMaps(Vars.GameDataFile.SubArray(Vars.CurrentOffset + i * Length, Length)));
            Vars.CurrentOffset += Length * Count;
        }

        public static void Write(FileStream stream)
        {
            int offset = 0;
            using (stream)
            {
                stream.Write(PreCount, offset, PreCount.Length);
                offset += PreCount.Length;
                stream.Write(Utils.IntToLittleEndian(Count), offset, 4);
                offset += 4;
                stream.Write(PostCount, offset, PostCount.Length);
                offset += PostCount.Length;

                for (int i = 0; i < Count; i++)
                {
                    stream.Write(((List<QuestMaps>)Vars.ListDict["QuestMaps"])[i].Serialize(), offset, Length);
                    offset += Length;
                }
            }
        }
    }

    public class Portals : Segment
    {
        public static int Length = 0;
        public static byte[] PreCount;
        public static int Count;
        public static byte[] PostCount;

        //TODO

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
                ((List<Portals>)Vars.ListDict["Portals"]).Add(new Portals(Vars.GameDataFile.SubArray(Vars.CurrentOffset + i * Length, Length)));
            Vars.CurrentOffset += Length * Count;
        }

        public static void Write(FileStream stream)
        {
            int offset = 0;
            using (stream)
            {
                stream.Write(PreCount, offset, PreCount.Length);
                offset += PreCount.Length;
                stream.Write(Utils.IntToLittleEndian(Count), offset, 4);
                offset += 4;
                stream.Write(PostCount, offset, PostCount.Length);
                offset += PostCount.Length;

                for (int i = 0; i < Count; i++)
                {
                    stream.Write(((List<Portals>)Vars.ListDict["Portals"])[i].Serialize(), offset, Length);
                    offset += Length;
                }
            }
        }
    }

    public class Unknown3 : Segment
    {
        public static int Length = 0;
        public static byte[] PreCount;
        public static int Count;
        public static byte[] PostCount;

        //TODO

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
                ((List<Unknown3>)Vars.ListDict["Unknown3"]).Add(new Unknown3(Vars.GameDataFile.SubArray(Vars.CurrentOffset + i * Length, Length)));
            Vars.CurrentOffset += Length * Count;
        }

        public static void Write(FileStream stream)
        {
            int offset = 0;
            using (stream)
            {
                stream.Write(PreCount, offset, PreCount.Length);
                offset += PreCount.Length;
                stream.Write(Utils.IntToLittleEndian(Count), offset, 4);
                offset += 4;
                stream.Write(PostCount, offset, PostCount.Length);
                offset += PostCount.Length;

                for (int i = 0; i < Count; i++)
                {
                    stream.Write(((List<Unknown3>)Vars.ListDict["Unknown3"])[i].Serialize(), offset, Length);
                    offset += Length;
                }
            }
        }
    }
    
    public class QuestGameMenu : Segment
    {
        public static int Length = 0;
        public static byte[] PreCount;
        public static int Count;
        public static byte[] PostCount;

        //TODO

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
                ((List<QuestGameMenu>)Vars.ListDict["QuestGameMenu"]).Add(new QuestGameMenu(Vars.GameDataFile.SubArray(Vars.CurrentOffset + i * Length, Length)));
            Vars.CurrentOffset += Length * Count;
        }

        public static void Write(FileStream stream)
        {
            int offset = 0;
            using (stream)
            {
                stream.Write(PreCount, offset, PreCount.Length);
                offset += PreCount.Length;
                stream.Write(Utils.IntToLittleEndian(Count), offset, 4);
                offset += 4;
                stream.Write(PostCount, offset, PostCount.Length);
                offset += PostCount.Length;

                for (int i = 0; i < Count; i++)
                {
                    stream.Write(((List<QuestGameMenu>)Vars.ListDict["QuestGameMenu"])[i].Serialize(), offset, Length);
                    offset += Length;
                }
            }
        }
    }

    public class ButtonDescription : Segment
    {
        public static int Length = 0;
        public static byte[] PreCount;
        public static int Count;
        public static byte[] PostCount;

        //TODO

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
                ((List<ButtonDescription>)Vars.ListDict["ButtonDescription"]).Add(new ButtonDescription(Vars.GameDataFile.SubArray(Vars.CurrentOffset + i * Length, Length)));
            Vars.CurrentOffset += Length * Count;
        }

        public static void Write(FileStream stream)
        {
            int offset = 0;
            using (stream)
            {
                stream.Write(PreCount, offset, PreCount.Length);
                offset += PreCount.Length;
                stream.Write(Utils.IntToLittleEndian(Count), offset, 4);
                offset += 4;
                stream.Write(PostCount, offset, PostCount.Length);
                offset += PostCount.Length;

                for (int i = 0; i < Count; i++)
                {
                    stream.Write(((List<ButtonDescription>)Vars.ListDict["ButtonDescription"])[i].Serialize(), offset, Length);
                    offset += Length;
                }
            }
        }
    }

    public class QuestID : Segment
    {
        public static int Length = 0;
        public static byte[] PreCount;
        public static int Count;
        public static byte[] PostCount;

        //TODO

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
                ((List<QuestID>)Vars.ListDict["QuestID"]).Add(new QuestID(Vars.GameDataFile.SubArray(Vars.CurrentOffset + i * Length, Length)));
            Vars.CurrentOffset += Length * Count;
        }

        public static void Write(FileStream stream)
        {
            int offset = 0;
            using (stream)
            {
                stream.Write(PreCount, offset, PreCount.Length);
                offset += PreCount.Length;
                stream.Write(Utils.IntToLittleEndian(Count), offset, 4);
                offset += 4;
                stream.Write(PostCount, offset, PostCount.Length);
                offset += PostCount.Length;

                for (int i = 0; i < Count; i++)
                {
                    stream.Write(((List<QuestID>)Vars.ListDict["QuestID"])[i].Serialize(), offset, Length);
                    offset += Length;
                }
            }
        }
    }

    public class WeaponTypeStats : Segment
    {
        public static int Length = 0;
        public static byte[] PreCount;
        public static int Count;
        public static byte[] PostCount;

        //TODO

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
                ((List<WeaponTypeStats>)Vars.ListDict["WeaponTypeStats"]).Add(new WeaponTypeStats(Vars.GameDataFile.SubArray(Vars.CurrentOffset + i * Length, Length)));
            Vars.CurrentOffset += Length * Count;
        }

        public static void Write(FileStream stream)
        {
            int offset = 0;
            using (stream)
            {
                stream.Write(PreCount, offset, PreCount.Length);
                offset += PreCount.Length;
                stream.Write(Utils.IntToLittleEndian(Count), offset, 4);
                offset += 4;
                stream.Write(PostCount, offset, PostCount.Length);
                offset += PostCount.Length;

                for (int i = 0; i < Count; i++)
                {
                    stream.Write(((List<WeaponTypeStats>)Vars.ListDict["WeaponTypeStats"])[i].Serialize(), offset, Length);
                    offset += Length;
                }
            }
        }
    }

    public class WeaponMaterial : Segment
    {
        public static int Length = 0;
        public static byte[] PreCount;
        public static int Count;
        public static byte[] PostCount;

        //TODO

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
                ((List<WeaponMaterial>)Vars.ListDict["WeaponMaterial"]).Add(new WeaponMaterial(Vars.GameDataFile.SubArray(Vars.CurrentOffset + i * Length, Length)));
            Vars.CurrentOffset += Length * Count;
        }

        public static void Write(FileStream stream)
        {
            int offset = 0;
            using (stream)
            {
                stream.Write(PreCount, offset, PreCount.Length);
                offset += PreCount.Length;
                stream.Write(Utils.IntToLittleEndian(Count), offset, 4);
                offset += 4;
                stream.Write(PostCount, offset, PostCount.Length);
                offset += PostCount.Length;

                for (int i = 0; i < Count; i++)
                {
                    stream.Write(((List<WeaponMaterial>)Vars.ListDict["WeaponMaterial"])[i].Serialize(), offset, Length);
                    offset += Length;
                }
            }
        }
    }

    public class Unknown4 : Segment
    {
        public static int Length = 0;
        public static byte[] PreCount;
        public static int Count;
        public static byte[] PostCount;

        //TODO

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
                ((List<Unknown4>)Vars.ListDict["Unknown4"]).Add(new Unknown4(Vars.GameDataFile.SubArray(Vars.CurrentOffset + i * Length, Length)));
            Vars.CurrentOffset += Length * Count;
        }

        public static void Write(FileStream stream)
        {
            int offset = 0;
            using (stream)
            {
                stream.Write(PreCount, offset, PreCount.Length);
                offset += PreCount.Length;
                stream.Write(Utils.IntToLittleEndian(Count), offset, 4);
                offset += 4;
                stream.Write(PostCount, offset, PostCount.Length);
                offset += PostCount.Length;

                for (int i = 0; i < Count; i++)
                {
                    stream.Write(((List<Unknown4>)Vars.ListDict["Unknown4"])[i].Serialize(), offset, Length);
                    offset += Length;
                }
            }
        }
    }

    public class Heads : Segment
    {
        public static int Length = 0;
        public static byte[] PreCount;
        public static int Count;
        public static byte[] PostCount;

        //TODO

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
                ((List<Heads>)Vars.ListDict["Heads"]).Add(new Heads(Vars.GameDataFile.SubArray(Vars.CurrentOffset + i * Length, Length)));
            Vars.CurrentOffset += Length * Count;
        }

        public static void Write(FileStream stream)
        {
            int offset = 0;
            using (stream)
            {
                stream.Write(PreCount, offset, PreCount.Length);
                offset += PreCount.Length;
                stream.Write(Utils.IntToLittleEndian(Count), offset, 4);
                offset += 4;
                stream.Write(PostCount, offset, PostCount.Length);
                offset += PostCount.Length;

                for (int i = 0; i < Count; i++)
                {
                    stream.Write(((List<Heads>)Vars.ListDict["Heads"])[i].Serialize(), offset, Length);
                    offset += Length;
                }
            }
        }
    }

    public class UpgradeStatsUI : Segment
    {
        public static int Length = 0;
        public static byte[] PreCount;
        public static int Count;
        public static byte[] PostCount;

        //TODO

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
                ((List<UpgradeStatsUI>)Vars.ListDict["UpgradeStatsUI"]).Add(new UpgradeStatsUI(Vars.GameDataFile.SubArray(Vars.CurrentOffset + i * Length, Length)));
            Vars.CurrentOffset += Length * Count;
        }

        public static void Write(FileStream stream)
        {
            int offset = 0;
            using (stream)
            {
                stream.Write(PreCount, offset, PreCount.Length);
                offset += PreCount.Length;
                stream.Write(Utils.IntToLittleEndian(Count), offset, 4);
                offset += 4;
                stream.Write(PostCount, offset, PostCount.Length);
                offset += PostCount.Length;

                for (int i = 0; i < Count; i++)
                {
                    stream.Write(((List<UpgradeStatsUI>)Vars.ListDict["UpgradeStatsUI"])[i].Serialize(), offset, Length);
                    offset += Length;
                }
            }
        }
    }

    public class ItemSets : Segment
    {
        public static int Length = 0;
        public static byte[] PreCount;
        public static int Count;
        public static byte[] PostCount;

        //TODO

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
                ((List<ItemSets>)Vars.ListDict["ItemSets"]).Add(new ItemSets(Vars.GameDataFile.SubArray(Vars.CurrentOffset + i * Length, Length)));
            Vars.CurrentOffset += Length * Count;
        }

        public static void Write(FileStream stream)
        {
            int offset = 0;
            using (stream)
            {
                stream.Write(PreCount, offset, PreCount.Length);
                offset += PreCount.Length;
                stream.Write(Utils.IntToLittleEndian(Count), offset, 4);
                offset += 4;
                stream.Write(PostCount, offset, PostCount.Length);
                offset += PostCount.Length;

                for (int i = 0; i < Count; i++)
                {
                    stream.Write(((List<ItemSets>)Vars.ListDict["ItemSets"])[i].Serialize(), offset, Length);
                    offset += Length;
                }
            }
        }
    }
}