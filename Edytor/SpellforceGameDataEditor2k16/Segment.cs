using System;
using System.Collections.Generic;

namespace SpellforceGameDataEditor2k16
{
    public class Segment
    {
        public string Name;
        public int EntryLength = 0;
        public int EntryCount;
        public byte[] Header;
        public byte[] Footer;
        public List<string> FieldNames;
        public List<int> FieldSizes;
        public List<Entry> Entries;

        public Segment(string Name, string[] FieldNames, int[] FieldSizes)
        {
            this.Name = Name;
            this.FieldNames = new List<string>(FieldNames);
            this.FieldSizes = new List<int>(FieldSizes);

            foreach (int size in FieldSizes)
                EntryLength += size;

            Header = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 6);
            Vars.CurrentOffset += 6;
            EntryCount = Utils.LittleEndianToInt(Vars.GameDataFile.SubArray(Vars.CurrentOffset, 4)) / EntryLength;
            Vars.CurrentOffset += 4;
            Footer = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 2);
            Vars.CurrentOffset += 2;
            Entries = new List<Entry>(EntryCount);
            ReadAllEntries();
            Vars.Segments.Add(Name, this);
        }

        public void ReadAllEntries()
        {
            for (int i = 0; i < EntryCount; i++)
            {
                Entries.Add(new Entry(FieldNames, FieldSizes));
            }
        }

        public byte[] Serialize()
        {
            throw new NotImplementedException();
        }
    }

    public class Entry
    {
        public Dictionary<string, byte[]> EntryData;

        public Entry(List<string> FieldNames, List<int> FieldSizes)
        {
            EntryData = new Dictionary<string, byte[]>();
            for (int field = 0; field < FieldNames.Count; field++)
            {                
                EntryData.Add(FieldNames[field], Vars.GameDataFile.SubArray(Vars.CurrentOffset, FieldSizes[field]));
                Vars.CurrentOffset += FieldSizes[field];
            }            
        }
    }

}