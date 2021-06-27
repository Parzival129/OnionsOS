using System;
using System.IO;

namespace NEWHEX
{
    class Class1
    {
        public static string Pad(string s, int len)
        {
            string temp = s;
            for (int i = s.Length; i < len; ++i)
                temp = "0" + temp;
            return temp;
        }
        public static void Main()
        {
            StreamReader sr = new StreamReader(@"C:\Users\Ms.BOSS1\source\repos\ONIONS21\ONIONS21\Assets\CODE.txt");

            string line = "";
            int nCounter = 0;
            int nOffset = 0;
            while ((line = sr.ReadLine()) != null)
            {
                for (int i = 0; i < line.Length; ++i)
                {
                    int c = (int)line[i];
                    string fmt = String.Format("{0:x}", c);
                    if (fmt.Length == 1)
                        fmt = Pad(fmt, 2);
                    if (nOffset % 16 == 0)
                    {
                        string offsetFmt = nOffset.ToString();

                        System.Console.Write(Pad(offsetFmt, 5) + ": ");
                    }

                    System.Console.Write(fmt + " ");
                    if (nCounter == 15)
                    {
                        System.Console.Write("\n");
                        nCounter = 0;
                    }
                    else
                        nCounter++;
                    nOffset++;
                }
            }
        }
    }
}
