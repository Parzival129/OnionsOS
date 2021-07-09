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
	    Console.WriteLin("This is an example of how you can implement external apps");
            return text;
        }
    }
}
