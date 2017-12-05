using System;
using System.Windows.Forms;

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

        public static void ReadAll()
        {
            Vars.Header = Vars.GameDataFile.SubArray(Vars.CurrentOffset, 20);
            Vars.CurrentOffset += 20;

            Segment Spell = new Segment("Spell", new string[] {"EffectID", "TypeID", "Reqs", "Mana", "CastingTime", "RecastTime", "MinRange", "MaxRange", "CastingType", "Stats"}, new int[]{2, 2, 12, 2, 4, 4, 2, 2, 2, 44});

        }

        public static void WriteAll()
        {
            
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
        }
    }
}