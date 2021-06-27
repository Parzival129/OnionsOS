using System;

namespace TESTTHING
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(TESTFUNC());

        }
        public static string TESTFUNC()
        {
            string text = "The C# import worked!!!";
            Console.WriteLine("IT WORKED!!!");
            return text;
        }
    }
}
