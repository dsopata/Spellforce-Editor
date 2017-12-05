using System;
using System.Collections.Generic;

namespace SpellforceGameDataEditor2k16
{
    public class Segment
    {
        public int Length;
        public int EntityCount;
        public byte[] Header;
        public byte[] Footer;
        public List<string> FieldNames;
        public List<int> FieldSizes;
        public List<byte[]> FieldData;
        

        public Segment(List<string> FieldNames, List<int> FieldSizes, List<byte[]> FieldData)
        {
            this.FieldNames = FieldNames;
            this.FieldSizes = FieldSizes;
            Header = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 6);
            Vars.CurrentOffset += 6;
            EntityCount = Utils.LittleEndianToInt(Vars.GameDataFile.SubArray(Vars.CurrentOffset, 4)) / Length;
            Vars.CurrentOffset += 4;
            Footer = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 2);
            Vars.CurrentOffset += 2;
            this.FieldData = new List<byte[]>(EntityCount);
        }

        public byte[] Serialize()
        {
            throw new NotImplementedException();
        }

    }

}