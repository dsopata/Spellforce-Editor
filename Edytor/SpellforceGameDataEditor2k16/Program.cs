using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public static void AddUnknown(int length)
        {
            byte[] unk = new byte[length];
            unk = Vars.GameDataFile.SubArray(Vars.CurrentOffset, length);
            Vars.Unknowns.Add(unk);
            Vars.CurrentOffset += length;
        }

        public static void JumpCounter(ref int classCounter, int classLength, int bytesBeforeCounter = 6 , int bytesAfterCounter = 2, int counterSize = 4)
        {
            if (bytesBeforeCounter != 0)
                Utils.AddUnknown(bytesBeforeCounter);

            classCounter = Utils.LittleEndianToInt(Vars.GameDataFile.SubArray(Vars.CurrentOffset, counterSize)) / classLength;
            Vars.CurrentOffset += counterSize;

            if (bytesAfterCounter != 0)
                Utils.AddUnknown(bytesAfterCounter);
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
