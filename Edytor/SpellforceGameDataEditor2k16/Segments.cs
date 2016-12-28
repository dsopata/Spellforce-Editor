﻿using System;
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
    }

    public class HeroWorkerAbilities
    {
        public static int Length = 5;
        public static int Count;

        public byte[] StatsID = new byte[2];
        public byte[] UnitAbilities = new byte[3];
    }

    public class HeroSkills
    {
        public static int Length = 5;
        public static int Count;

        public byte[] StatsID = new byte[2];
        public byte[] SpellNumber = new byte[1];
        public byte[] SpellEffectID = new byte[2];
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
    }

    public class ScrollRuneID
    {
        public static int Length = 4;
        public static int Count;

        public byte[] InInventoryID = new byte[2];
        public byte[] AddedID = new byte[2];
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
    }

    public class ItemSpellEffects
    {
        public static int Length = 5;
        public static int Count;

        public byte[] ItemID = new byte[2];
        public byte[] ItemEffectNumber = new byte[1];
        public byte[] SpellEffectID = new byte[2];
    }

    public class ItemUI
    {
        public static int Length = 69;
        public static int Count;

        public byte[] ItemID = new byte[2];
        public byte[] UINumber = new byte[1];
        public byte[] UIName = new byte[64];
        public byte[] Unknown = new byte[2];
    }

    public class SpellItemID
    {
        public static int Length = 4;
        public static int Count;

        public byte[] ItemID = new byte[2];
        public byte[] SpellEffectID = new byte[2];
    }

    public class Texts
    {
        public static int Length = 566;
        public static int Count;

        public byte[] TextID = new byte[2];
        public byte[] LanguageID = new byte[1]; //00 DE, 01 EN, 02 FR, 03 SP, 04 IT, where poland? poland stronk :(
        public byte[] DialogueNumber = new byte[1];
        public byte[] DialogueName = new byte[50];
        public byte[] RawText = new byte[512];
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
    }

    public class HeadStats
    {
        public static int Length = 3;
        public static int Count;

        public byte[] HeadID1 = new byte[1];
        public byte[] HeadID2 = new byte[1];
        public byte[] Unknown = new byte[1];
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
    }

    public class UnitEquipment
    {
        public static int Length = 5;
        public static int Count;

        public byte[] UnitID  = new byte[2];
        public byte[] SlotID = new byte[1]; //00 head, 01 rhand, 02 chest, 03 lhand, 04 rring, 05 legs, 06 lring
        public byte[] ItemID = new byte[2];
    }

    public class UnitSpellsSkills
    {
        public static int Length = 5;
        public static int Count;

        public byte[] UnitID = new byte[2];
        public byte[] SpellSkillNumber = new byte[1];
        public byte[] SpellEffectID = new byte[2];
    }

    public class ArmyRequirements
    {
        public static int Length = 4;
        public static int Count;

        public byte[] UnitID = new byte[2];
        public byte[] ResourceID = new byte[1]; //01 wood, 02 stone, 03 log(!), 04 moonsilver, 05 food, 06 berry(!), 07 iron, 08 tree(!), 09 grain(!), 0B fish(!), 0F mushroom(!), 10 meat(!), 12 aria, 13 lenya
        public byte[] Amount = new byte[1];
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
    }

    public class BuildingRequirements
    {
        public static int Length = 5;
        public static int Count;

        public byte[] UnitID = new byte[2];
        public byte[] RequirementNumber = new byte[1];
        public byte[] BuildingID = new byte[2];
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