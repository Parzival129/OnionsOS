using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using Sys = Cosmos.System;

/////////////////////////////////////////////

using TESTTHING; // <= Importing external apps
using CalculatorApp;
using crash;
using RPS;
using NEWHEX;
using Cars;
/*
   ____        _                 
  / __ \____  (_)___  ____  _____
 / / / / __ \/ / __ \/ __ \/ ___/
/ /_/ / / / / / /_/ / / / (__  ) 
\____/_/ /_/_/\____/_/ /_/____/   OS

Developed By Russell Tabata

*/

namespace ONIONS21
{

    public class Kernel : Sys.Kernel

    {

        public static string username { get; set; }
        public static string title_type = "Default";

        // title function to be used multiple times
        public void title_katakana()
        {
            
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("");
            Console.WriteLine(" #       #   ######     ######   #   #   ######   ######## ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" #       #                #      #   #            #      #");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("        #  ########## ########## #   # ########       # ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("       #   #        #     #      #   # #      #      # ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("     ##           ##      #         #       ##      #  ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("   ##           ##        #        #      ##      ## ");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine(" ##           ##           ####  ##     ##      ## ");
            Console.ResetColor();
            Console.WriteLine("Programmed By - Russell Tabata");

            Console.WriteLine("Onions v21 booted successfully!");
            Console.WriteLine("Copyright Enovico 2020");
            // Tandy reference
            Console.WriteLine("OK");
            Console.WriteLine("");
        }

        public void title_english()
        {

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("");
            Console.WriteLine(" ..####...##..##..######...####...##..##...####..");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" .##..##..###.##....##....##..##..###.##..##.....");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(" .##..##..##.###....##....##..##..##.###...####..");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(" .##..##..##..##....##....##..##..##..##......##.");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(" ..####...##..##..######...####...##..##...####..");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(" ................................................");

            Console.WriteLine("Programmed By - Russell Tabata");

            Console.WriteLine("Onions v21 booted successfully!");
            Console.WriteLine("Copyright Enovico 2020");
            // Tandy reference
            Console.WriteLine("OK");
            Console.WriteLine("");
        }

        Sys.FileSystem.CosmosVFS fs;
        string current_directory = @"0:\";

        protected override void BeforeRun()
        {
            // Filesystem Initialization 
            fs = new Sys.FileSystem.CosmosVFS(); Sys.FileSystem.VFS.VFSManager.RegisterVFS(fs); fs.Initialize();

            // Colorful title screen
            title_english();

            Login:

            Console.Write("Logon: ");
            username = Console.ReadLine();
            Console.WriteLine("");
            Console.Write("Password: ");
            string inputed_password = Console.ReadLine();

            if (inputed_password != "onions")
            {
                Console.WriteLine("Incorrect password! - Press key to try again...");
                Console.ReadKey();
                goto Login;
            }
            
    }

        protected override void Run()
        {
            
            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.Write(current_directory + @"\" + username + "@Onions~$> ");
            Console.ResetColor();
            var input = Console.ReadLine();

            // All commands


            if (input == "TEST")
            {
                try
                {
                    Console.WriteLine("Attempt 1 intialzing... [file: Hello1.txt]");
                    StreamWriter thing1 = new StreamWriter("Hello1.txt");
                    thing1.WriteLine("Hello, World, This is my test file.");
                    thing1.Close();

                    Console.WriteLine("Attempt 2 intialzing... [file: Hello2.txt]");
                    StreamWriter thing2 = new StreamWriter(@"0:\Hello2.txt");
                    StreamWriter thing3 = new StreamWriter(@"0:\\Hello3.txt");
                    thing2.WriteLine("Hello, World, This is my test file.");
                    thing2.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
                
            }

            if (input == "rps")
            {
                try
                {
                    RPS.Program.Main();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }


            if (input == "calc")
            {
                try
                {
                    CalculatorApp.Program.Calc();
                    
                }

                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }

   

            if (input == "crash")
            {
                try
                {
                    crash.screen.Main();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }

            if (input == "credits")
            {
                Console.WriteLine("");
                Console.WriteLine("Onions OS V21");
                Console.WriteLine("");
                Console.WriteLine("Programmed By - Russell Tabata");
                Console.WriteLine("Concept Design By - Thomas Lauder");
                Console.WriteLine("");
            }

            if (input == "Cars")
            {
                Cars.Program.Main();
            }

            if (input == "help")
            {
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Commands:");
                Console.ResetColor();
                Console.WriteLine("");
                Console.WriteLine("hexdump - dump memory in hex");
                Console.WriteLine("HEX - Experimental version of hexdump");
                Console.WriteLine("hextest - Another Experimental version of hexdump");
                Console.WriteLine("credits - Show all people that contributed to development of ONIONS");
                Console.WriteLine("ls - List all items in directory");
                Console.WriteLine("dir - List all items in directory with extra information");
                Console.WriteLine("drive - Display drive information");
                Console.WriteLine("make [file] - Creates a file");
                Console.WriteLine("mkdir [folder] - Creates Folder");
                Console.WriteLine("cat [file] - Shows contents of file");
                Console.WriteLine("write [file] - Write to a file");
                Console.WriteLine("deld [directory] - Deletes directory");
                Console.WriteLine("delf [file] - Deletes file");
                Console.WriteLine("shutdown - Shuts down the computer and allows safe removal of boot device");
                Console.WriteLine("reboot - restarts system");
                Console.WriteLine("echo [text] - Displays text");
                Console.WriteLine("OS - Displays Onions OS version");
                Console.WriteLine("neofetch - A fast highly customizable system info script");
                Console.WriteLine("TEST - A test function that may or may not work");
                Console.WriteLine("crash - Crashes the OS beyond usability");
                Console.WriteLine("apps - Menu for launching apps and programs");
                Console.WriteLine("");
            }



            if (input == "apps")
            {
                Console.WriteLine("What app would you like to open?");
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("--Tools--");
                Console.ResetColor();
                Console.WriteLine("1. Calculator");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("--Games / Recreation--");
                Console.ResetColor();
                Console.WriteLine("2. Rock Paper Scissors");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("--System--");
                Console.ResetColor();
                Console.WriteLine("3. CRASH");
                Console.WriteLine("4. Hexdump");
                Console.WriteLine("5. Settings");
                Console.WriteLine("");
                Console.Write("Input number? > ");
                string program_to_run = Console.ReadLine();

                if (program_to_run == "1") 
                {
                    CalculatorApp.Program.Calc();
                }
                if (program_to_run == "2")
                {
                    RPS.Program.Main();
                }

                if (program_to_run == "3")
                {
                    crash.screen.Main();
                }
                if (program_to_run == "4")
                {
                    Console.WriteLine("75 73 69 6e 67 20 53 79 73 74 65 6d 3b 0a 75 73 69 6e 67 20 53 79 73 74 65 6d 2e 43 6f 6c 6c 65 63 74 69 6f 6e 73 2e 47 65 6e 65 72 69 63 3b 0a 75 73 69 6e 67 20 53 79 73 74 65 6d 2e 54 65 78 74 3b 0a 75 73 69 6e 67 20 53 79 73 20 3d 20 43 6f 73 6d 6f 73 2e 53 79 73 74 65 6d 3b 0a 0a 6e 61 6d 65 73 70 61 63 65 20 4f 4e 49 4f 4e 53 54 45 54 53 0a 7b 0a 20 20 20 20 70 75 62 6c 69 63 20 63 6c 61 73 73 20 4b 65 72 6e 65 6c 20 3a 20 53 79 73 2e 4b 65 72 6e 65 6c 0a 20 20 20 20 7b 0a 20 20 20 20 20 20 20 20 53 79 73 2e 46 69 6c 65 53 79 73 74 65 6d 2e 43 6f 73 6d 6f 73 56 46 53 20 66 73 3b 0a 20 20 20 20 20 20 20 20 73 74 72 69 6e 67 20 63 75 72 72 65 6e 74 5f 64 69 72 65 63 74 6f 72 79 20 3d 20 22 30 3a 5c 5c 22 3b 0a 0a 20 20 20 20 20 20 20 20 70 72 6f 74 65 63 74 65 64 20 6f 76 65 72 72 69 64 65 20 76 6f 69 64 20 42 65 66 6f 72 65 52 75 6e 28 29 0a 20 20 20 20 20 20 20 20 7b 0a 20 20 20 20 20 20 20 20 20 20 20 20 66 73 20 3d 20 6e 65 77 20 53 79 73 2e 46 69 6c 65 53 79 73 74 65 6d 2e 43 6f 73 6d 6f 73 56 46 53 28 29 3b 0a 20 20 20 20 20 20 20 20 20 20 20 20 53 79 73 2e 46 69 6c 65 53 79 73 74 65 6d 2e 56 46 53 2e 56 46 53 4d 61 6e 61 67 65 72 2e 52 65 67 69 73 74 65 72 56 46 53 28 66 73 29 3b 0a 20 20 20 20 20 20 20 20 20 20 20 20 43 6f 6e 73 6f 6c 65 2e 57 72 69 74 65 4c 69 6e 65 28 22 22 29 3b 0a 20 20 20 20 20 20 20 20 20 20 20 20 43 6f 6e 73 6f 6c 65 2e 57 72 69 74 65 4c 69 6e 65 28 22 4f 6e 69 6f 6e 73 20 62 6f 6f 74 65 64 20 73 75 63 63 65 73 73 66 75 6c 6c 79 20 22 29 3b 0a 20 20 20 20 20 20 20 20 7d 0a 0a 20 20 20 20 20 20 20 20 70 72 6f 74 65 63 74 65 64 20 6f 76 65 72 72 69 64 65 20 76 6f 69 64 20 52 75 6e 28 29 0a 20 20 20 20 20 20 20 20 7b 0a 20 20 20 20 20 20 20 20 20 20 20 20 43 6f 6e 73 6f 6c 65 2e 57 72 69 74 65 28 22 30 3a 5c 5c 55 73 65 72 40 4f 6e 69 6f 6e 73 7e 24 3e 20 22 29 3b 0a 20 20 20 20 20 20 20 20 20 20 20 20 76 61 72 20 69 6e 70 75 74 20 3d 20 43 6f 6e 73 6f 6c 65 2e 52 65 61 64 4c 69 6e 65 28 29 3b 0a 20 20 20 20 20 20 20 20 20 20 20 20 69 66 20 28 69 6e 70 75 74 20 3d 3d 20 22 68 65 78 64 75 6d 70 22 29 0a 20 20 20 20 20 20 20 20 20 20 20 20 7b 0a 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 43 6f 6e 73 6f 6c 65 2e 57 72 69 74 65 4c 69 6e 65 28 22 48 45 58 53 54 55 46 46 22 29 3b 0a 0a 20 20 20 20 20 20 20 20 20 20 20 20 7d 0a 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 0a 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 0a 0a 0a 20 20 20 20 20 20 20 20 20 20 20 20 69 66 20 28 69 6e 70 75 74 20 3d 3d 20 22 63 72 65 64 69 74 73 22 29 0a 20 20 20 20 20 20 20 20 20 20 20 20 7b 0a 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 43 6f 6e 73 6f 6c 65 2e 57 72 69 74 65 4c 69 6e 65 28 22 22 29 3b 0a 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 43 6f 6e 73 6f 6c 65 2e 57 72 69 74 65 4c 69 6e 65 28 22 4f 6e 69 6f 6e 73 20 4f 53 20 56 30 2e 31 22 29 3b 0a 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 43 6f 6e 73 6f 6c 65 2e 57 72 69 74 65 4c 69 6e 65 28 22 22 29 3b 0a 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 43 6f 6e 73 6f 6c 65 2e 57 72 69 74 65 4c 69 6e 65 28 22 50 72 6f 67 72 61 6d 6d 65 64 20 42 79 20 2d 20 52 75 73 73 65 6c 6c 20 54 61 62 61 74 61 22 29 3b 0a 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 43 6f 6e 73 6f 6c 65 2e 57 72 69 74 65 4c 69 6e 65 28 22 43 6f 6e 63 65 70 74 20 44 65 73 69 67 6e 20 42 79 20 2d 20 54 68 6f 6d 61 73 20 4c 61 75 64 65 72 22 29 3b 0a 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 43 6f 6e 73 6f 6c 65 2e 57 72 69 74 65 4c 69 6e 65 28 22 22 29 3b 0a 20 20 20 20 20 20 20 20 20 20 20 20 7d 0a 20 20 20 20 20 20 20 20 20 20 20 20 69 66 20 28 69 6e 70 75 74 20 3d 3d 20 22 68 65 6c 70 22 29 0a 20 20 20 20 20 20 20 20 20 20 20 20 7b 0a 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 43 6f 6e 73 6f 6c 65 2e 57 72 69 74 65 4c 69 6e 65 28 22 22 29 3b 0a 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 43 6f 6e 73 6f 6c 65 2e 57 72 69 74 65 4c 69 6e 65 28 22 43 6f 6d 6d 61 6e 64 73 3a 22 29 3b 0a 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 43 6f 6e 73 6f 6c 65 2e 57 72 69 74 65 4c 69 6e 65 28 22 22 29 3b 0a 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 43 6f 6e 73 6f 6c 65 2e 57 72 69 74 65 4c 69 6e 65 28 22 68 65 78 64 75 6d 70 20 2d 20 64 75 6d 70 20 6d 65 6d 6f 72 79 20 69 6e 20 68 65 78 22 29 3b 0a 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 43 6f 6e 73 6f 6c 65 2e 57 72 69 74 65 4c 69 6e 65 28 22 63 72 65 64 69 74 73 20 2d 20 53 68 6f 77 20 61 6c 6c 20 70 65 6f 70 6c 65 20 68 61 74 20 22 29 3b 0a 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 43 6f 6e 73 6f 6c 65 2e 57 72 69 74 65 4c 69 6e 65 28 22 6c 73 20 2d 20 4c 69 73 74 20 61 6c 6c 20 69 74 65 6d 73 20 69 6e 20 64 69 72 65 63 74 6f 72 79 22 29 3b 0a 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 43 6f 6e 73 6f 6c 65 2e 57 72 69 74 65 4c 69 6e 65 28 22 64 72 69 76 65 20 2d 20 44 69 73 70 6c 61 79 20 64 72 69 76 65 20 69 6e 66 6f 72 6d 61 74 69 6f 6e 22 29 3b 0a 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 43 6f 6e 73 6f 6c 65 2e 57 72 69 74 65 4c 69 6e 65 28 22 6d 61 6b 65 20 2d 20 43 72 65 61 74 65 73 20 61 20 74 65 73 74 20 74 65 78 74 20 66 69 6c 65 22 29 3b 0a 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 43 6f 6e 73 6f 6c 65 2e 57 72 69 74 65 4c 69 6e 65 28 22 22 29 3b 0a 20 20 20 20 20 20 20 20 20 20 20 20 7d 0a 0a 20 20 20 20 20 20 20 20 20 20 20 20 69 66 20 28 69 6e 70 75 74 20 3d 3d 20 22 6c 73 22 29 0a 20 20 20 20 20 20 20 20 20 20 20 20 7b 0a 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 43 6f 6e 73 6f 6c 65 2e 57 72 69 74 65 4c 69 6e 65 28 22 22 29 3b 0a 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 76 61 72 20 64 69 72 65 63 74 6f 72 79 5f 6c 69 73 74 20 3d 20 53 79 73 2e 46 69 6c 65 53 79 73 74 65 6d 2e 56 46 53 2e 56 46 53 4d 61 6e 61 67 65 72 2e 47 65 74 44 69 72 65 63 74 6f 72 79 4c 69 73 74 69 6e 67 28 22 30 3a 2f 22 29 3b 0a 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 66 6f 72 65 61 63 68 20 28 76 61 72 20 64 69 72 65 63 74 6f 72 79 45 6e 74 72 79 20 69 6e 20 64 69 72 65 63 74 6f 72 79 5f 6c 69 73 74 29 0a 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 7b 0a 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 43 6f 6e 73 6f 6c 65 2e 57 72 69 74 65 4c 69 6e 65 28 64 69 72 65 63 74 6f 72 79 45 6e 74 72 79 2e 6d 4e 61 6d 65 29 3b 0a 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 7d 0a 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 43 6f 6e 73 6f 6c 65 2e 57 72 69 74 65 4c 69 6e 65 28 22 22 29 3b 0a 0a 20 20 20 20 20 20 20 20 20 20 20 20 7d 0a 20 20 20 20 20 20 20 20 20 20 20 20 69 66 20 28 69 6e 70 75 74 20 3d 3d 20 22 64 72 69 76 65 22 29 0a 20 20 20 20 20 20 20 20 20 20 20 20 7b 0a 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 43 6f 6e 73 6f 6c 65 2e 57 72 69 74 65 4c 69 6e 65 28 22 22 29 3b 0a 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 43 6f 6e 73 6f 6c 65 2e 57 72 69 74 65 4c 69 6e 65 28 22 22 29 3b 0a 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 6c 6f 6e 67 20 61 76 61 69 6c 61 62 6c 65 5f 73 70 61 63 65 20 3d 20 53 79 73 2e 46 69 6c 65 53 79 73 74 65 6d 2e 56 46 53 2e 56 46 53 4d 61 6e 61 67 65 72 2e 47 65 74 41 76 61 69 6c 61 62 6c 65 46 72 65 65 53 70 61 63 65 28 22 30 3a 2f 22 29 3b 0a 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 43 6f 6e 73 6f 6c 65 2e 57 72 69 74 65 4c 69 6e 65 28 22 41 76 61 69 6c 61 62 6c 65 20 46 72 65 65 20 53 70 61 63 65 3a 20 22 20 2b 20 61 76 61 69 6c 61 62 6c 65 5f 73 70 61 63 65 29 3b 0a 0a 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 73 74 72 69 6e 67 20 66 73 5f 74 79 70 65 20 3d 20 53 79 73 2e 46 69 6c 65 53 79 73 74 65 6d 2e 56 46 53 2e 56 46 53 4d 61 6e 61 67 65 72 2e 47 65 74 46 69 6c 65 53 79 73 74 65 6d 54 79 70 65 28 22 30 3a 2f 22 29 3b 0a 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 43 6f 6e 73 6f 6c 65 2e 57 72 69 74 65 4c 69 6e 65 28 22 46 69 6c 65 20 53 79 73 74 65 6d 20 54 79 70 65 3a 20 22 20 2b 20 66 73 5f 74 79 70 65 29 3b 0a 0a 0a 20 20 20 20 20 20 20 20 20 20 20 20 7d 0a 0a 20 20 20 20 20 20 20 20 20 20 20 20 69 66 20 28 69 6e 70 75 74 20 3d 3d 20 22 6d 61 6b 65 22 29 0a 20 20 20 20 20 20 20 20 20 20 20 20 7b 0a 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 74 72 79 0a 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 7b 0a 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 53 79 73 2e 46 69 6c 65 53 79 73 74 65 6d 2e 56 46 53 2e 56 46 53 4d 61 6e 61 67 65 72 2e 43 72 65 61 74 65 46 69 6c 65 28 40 22 30 3a 5c 41 5f 46 49 4c 45 2e 74 78 74 22 29 3b 0a 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 7d 0a 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 63 61 74 63 68 20 28 45 78 63 65 70 74 69 6f 6e 20 65 29 0a 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 7b 0a 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 43 6f 6e 73 6f 6c 65 2e 57 72 69 74 65 4c 69 6e 65 28 65 2e 54 6f 53 74 72 69 6e 67 28 29 29 3b 0a 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 7d 0a 20 20 20 20 20 20 20 20 20 20 20 20 7d 0a 20 20 20 20 20 20 20 20 7d 0a 20 20 20 20 7d 0a 7d");
                }

                if (program_to_run == "5")
                {

                    try
                    {
                        Console.WriteLine("What setting would you like to access?");
                        Console.WriteLine("");
                        Console.WriteLine("1. Title type");
                        Console.WriteLine("");
                        Console.Write("Input Num > ");
                        string setting = Console.ReadLine();

                        if (setting == "1")
                        {
                            Console.WriteLine("What kind of title would you like?");
                            Console.WriteLine("");
                            Console.WriteLine("1. Default (English");
                            Console.WriteLine("2. Katakana (Japanese)");
                            Console.WriteLine("");
                            Console.Write("Input Num > ");
                            string inputed = Console.ReadLine();

                            if (inputed == "1")
                            {
                                title_type = "Default";
                            }

                            if (inputed == "2")
                            {
                                title_type = "Katakana";
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.ToString());
                    }
                    
                }
                
            }

            if (input == "hexdump")
            {
                Console.WriteLine("75 73 69 6e 67 20 53 79 73 74 65 6d 3b 0a 75 73 69 6e 67 20 53 79 73 74 65 6d 2e 43 6f 6c 6c 65 63 74 69 6f 6e 73 2e 47 65 6e 65 72 69 63 3b 0a 75 73 69 6e 67 20 53 79 73 74 65 6d 2e 54 65 78 74 3b 0a 75 73 69 6e 67 20 53 79 73 20 3d 20 43 6f 73 6d 6f 73 2e 53 79 73 74 65 6d 3b 0a 0a 6e 61 6d 65 73 70 61 63 65 20 4f 4e 49 4f 4e 53 54 45 54 53 0a 7b 0a 20 20 20 20 70 75 62 6c 69 63 20 63 6c 61 73 73 20 4b 65 72 6e 65 6c 20 3a 20 53 79 73 2e 4b 65 72 6e 65 6c 0a 20 20 20 20 7b 0a 20 20 20 20 20 20 20 20 53 79 73 2e 46 69 6c 65 53 79 73 74 65 6d 2e 43 6f 73 6d 6f 73 56 46 53 20 66 73 3b 0a 20 20 20 20 20 20 20 20 73 74 72 69 6e 67 20 63 75 72 72 65 6e 74 5f 64 69 72 65 63 74 6f 72 79 20 3d 20 22 30 3a 5c 5c 22 3b 0a 0a 20 20 20 20 20 20 20 20 70 72 6f 74 65 63 74 65 64 20 6f 76 65 72 72 69 64 65 20 76 6f 69 64 20 42 65 66 6f 72 65 52 75 6e 28 29 0a 20 20 20 20 20 20 20 20 7b 0a 20 20 20 20 20 20 20 20 20 20 20 20 66 73 20 3d 20 6e 65 77 20 53 79 73 2e 46 69 6c 65 53 79 73 74 65 6d 2e 43 6f 73 6d 6f 73 56 46 53 28 29 3b 0a 20 20 20 20 20 20 20 20 20 20 20 20 53 79 73 2e 46 69 6c 65 53 79 73 74 65 6d 2e 56 46 53 2e 56 46 53 4d 61 6e 61 67 65 72 2e 52 65 67 69 73 74 65 72 56 46 53 28 66 73 29 3b 0a 20 20 20 20 20 20 20 20 20 20 20 20 43 6f 6e 73 6f 6c 65 2e 57 72 69 74 65 4c 69 6e 65 28 22 22 29 3b 0a 20 20 20 20 20 20 20 20 20 20 20 20 43 6f 6e 73 6f 6c 65 2e 57 72 69 74 65 4c 69 6e 65 28 22 4f 6e 69 6f 6e 73 20 62 6f 6f 74 65 64 20 73 75 63 63 65 73 73 66 75 6c 6c 79 20 22 29 3b 0a 20 20 20 20 20 20 20 20 7d 0a 0a 20 20 20 20 20 20 20 20 70 72 6f 74 65 63 74 65 64 20 6f 76 65 72 72 69 64 65 20 76 6f 69 64 20 52 75 6e 28 29 0a 20 20 20 20 20 20 20 20 7b 0a 20 20 20 20 20 20 20 20 20 20 20 20 43 6f 6e 73 6f 6c 65 2e 57 72 69 74 65 28 22 30 3a 5c 5c 55 73 65 72 40 4f 6e 69 6f 6e 73 7e 24 3e 20 22 29 3b 0a 20 20 20 20 20 20 20 20 20 20 20 20 76 61 72 20 69 6e 70 75 74 20 3d 20 43 6f 6e 73 6f 6c 65 2e 52 65 61 64 4c 69 6e 65 28 29 3b 0a 20 20 20 20 20 20 20 20 20 20 20 20 69 66 20 28 69 6e 70 75 74 20 3d 3d 20 22 68 65 78 64 75 6d 70 22 29 0a 20 20 20 20 20 20 20 20 20 20 20 20 7b 0a 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 43 6f 6e 73 6f 6c 65 2e 57 72 69 74 65 4c 69 6e 65 28 22 48 45 58 53 54 55 46 46 22 29 3b 0a 0a 20 20 20 20 20 20 20 20 20 20 20 20 7d 0a 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 0a 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 0a 0a 0a 20 20 20 20 20 20 20 20 20 20 20 20 69 66 20 28 69 6e 70 75 74 20 3d 3d 20 22 63 72 65 64 69 74 73 22 29 0a 20 20 20 20 20 20 20 20 20 20 20 20 7b 0a 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 43 6f 6e 73 6f 6c 65 2e 57 72 69 74 65 4c 69 6e 65 28 22 22 29 3b 0a 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 43 6f 6e 73 6f 6c 65 2e 57 72 69 74 65 4c 69 6e 65 28 22 4f 6e 69 6f 6e 73 20 4f 53 20 56 30 2e 31 22 29 3b 0a 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 43 6f 6e 73 6f 6c 65 2e 57 72 69 74 65 4c 69 6e 65 28 22 22 29 3b 0a 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 43 6f 6e 73 6f 6c 65 2e 57 72 69 74 65 4c 69 6e 65 28 22 50 72 6f 67 72 61 6d 6d 65 64 20 42 79 20 2d 20 52 75 73 73 65 6c 6c 20 54 61 62 61 74 61 22 29 3b 0a 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 43 6f 6e 73 6f 6c 65 2e 57 72 69 74 65 4c 69 6e 65 28 22 43 6f 6e 63 65 70 74 20 44 65 73 69 67 6e 20 42 79 20 2d 20 54 68 6f 6d 61 73 20 4c 61 75 64 65 72 22 29 3b 0a 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 43 6f 6e 73 6f 6c 65 2e 57 72 69 74 65 4c 69 6e 65 28 22 22 29 3b 0a 20 20 20 20 20 20 20 20 20 20 20 20 7d 0a 20 20 20 20 20 20 20 20 20 20 20 20 69 66 20 28 69 6e 70 75 74 20 3d 3d 20 22 68 65 6c 70 22 29 0a 20 20 20 20 20 20 20 20 20 20 20 20 7b 0a 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 43 6f 6e 73 6f 6c 65 2e 57 72 69 74 65 4c 69 6e 65 28 22 22 29 3b 0a 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 43 6f 6e 73 6f 6c 65 2e 57 72 69 74 65 4c 69 6e 65 28 22 43 6f 6d 6d 61 6e 64 73 3a 22 29 3b 0a 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 43 6f 6e 73 6f 6c 65 2e 57 72 69 74 65 4c 69 6e 65 28 22 22 29 3b 0a 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 43 6f 6e 73 6f 6c 65 2e 57 72 69 74 65 4c 69 6e 65 28 22 68 65 78 64 75 6d 70 20 2d 20 64 75 6d 70 20 6d 65 6d 6f 72 79 20 69 6e 20 68 65 78 22 29 3b 0a 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 43 6f 6e 73 6f 6c 65 2e 57 72 69 74 65 4c 69 6e 65 28 22 63 72 65 64 69 74 73 20 2d 20 53 68 6f 77 20 61 6c 6c 20 70 65 6f 70 6c 65 20 68 61 74 20 22 29 3b 0a 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 43 6f 6e 73 6f 6c 65 2e 57 72 69 74 65 4c 69 6e 65 28 22 6c 73 20 2d 20 4c 69 73 74 20 61 6c 6c 20 69 74 65 6d 73 20 69 6e 20 64 69 72 65 63 74 6f 72 79 22 29 3b 0a 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 43 6f 6e 73 6f 6c 65 2e 57 72 69 74 65 4c 69 6e 65 28 22 64 72 69 76 65 20 2d 20 44 69 73 70 6c 61 79 20 64 72 69 76 65 20 69 6e 66 6f 72 6d 61 74 69 6f 6e 22 29 3b 0a 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 43 6f 6e 73 6f 6c 65 2e 57 72 69 74 65 4c 69 6e 65 28 22 6d 61 6b 65 20 2d 20 43 72 65 61 74 65 73 20 61 20 74 65 73 74 20 74 65 78 74 20 66 69 6c 65 22 29 3b 0a 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 43 6f 6e 73 6f 6c 65 2e 57 72 69 74 65 4c 69 6e 65 28 22 22 29 3b 0a 20 20 20 20 20 20 20 20 20 20 20 20 7d 0a 0a 20 20 20 20 20 20 20 20 20 20 20 20 69 66 20 28 69 6e 70 75 74 20 3d 3d 20 22 6c 73 22 29 0a 20 20 20 20 20 20 20 20 20 20 20 20 7b 0a 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 43 6f 6e 73 6f 6c 65 2e 57 72 69 74 65 4c 69 6e 65 28 22 22 29 3b 0a 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 76 61 72 20 64 69 72 65 63 74 6f 72 79 5f 6c 69 73 74 20 3d 20 53 79 73 2e 46 69 6c 65 53 79 73 74 65 6d 2e 56 46 53 2e 56 46 53 4d 61 6e 61 67 65 72 2e 47 65 74 44 69 72 65 63 74 6f 72 79 4c 69 73 74 69 6e 67 28 22 30 3a 2f 22 29 3b 0a 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 66 6f 72 65 61 63 68 20 28 76 61 72 20 64 69 72 65 63 74 6f 72 79 45 6e 74 72 79 20 69 6e 20 64 69 72 65 63 74 6f 72 79 5f 6c 69 73 74 29 0a 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 7b 0a 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 43 6f 6e 73 6f 6c 65 2e 57 72 69 74 65 4c 69 6e 65 28 64 69 72 65 63 74 6f 72 79 45 6e 74 72 79 2e 6d 4e 61 6d 65 29 3b 0a 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 7d 0a 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 43 6f 6e 73 6f 6c 65 2e 57 72 69 74 65 4c 69 6e 65 28 22 22 29 3b 0a 0a 20 20 20 20 20 20 20 20 20 20 20 20 7d 0a 20 20 20 20 20 20 20 20 20 20 20 20 69 66 20 28 69 6e 70 75 74 20 3d 3d 20 22 64 72 69 76 65 22 29 0a 20 20 20 20 20 20 20 20 20 20 20 20 7b 0a 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 43 6f 6e 73 6f 6c 65 2e 57 72 69 74 65 4c 69 6e 65 28 22 22 29 3b 0a 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 43 6f 6e 73 6f 6c 65 2e 57 72 69 74 65 4c 69 6e 65 28 22 22 29 3b 0a 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 6c 6f 6e 67 20 61 76 61 69 6c 61 62 6c 65 5f 73 70 61 63 65 20 3d 20 53 79 73 2e 46 69 6c 65 53 79 73 74 65 6d 2e 56 46 53 2e 56 46 53 4d 61 6e 61 67 65 72 2e 47 65 74 41 76 61 69 6c 61 62 6c 65 46 72 65 65 53 70 61 63 65 28 22 30 3a 2f 22 29 3b 0a 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 43 6f 6e 73 6f 6c 65 2e 57 72 69 74 65 4c 69 6e 65 28 22 41 76 61 69 6c 61 62 6c 65 20 46 72 65 65 20 53 70 61 63 65 3a 20 22 20 2b 20 61 76 61 69 6c 61 62 6c 65 5f 73 70 61 63 65 29 3b 0a 0a 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 73 74 72 69 6e 67 20 66 73 5f 74 79 70 65 20 3d 20 53 79 73 2e 46 69 6c 65 53 79 73 74 65 6d 2e 56 46 53 2e 56 46 53 4d 61 6e 61 67 65 72 2e 47 65 74 46 69 6c 65 53 79 73 74 65 6d 54 79 70 65 28 22 30 3a 2f 22 29 3b 0a 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 43 6f 6e 73 6f 6c 65 2e 57 72 69 74 65 4c 69 6e 65 28 22 46 69 6c 65 20 53 79 73 74 65 6d 20 54 79 70 65 3a 20 22 20 2b 20 66 73 5f 74 79 70 65 29 3b 0a 0a 0a 20 20 20 20 20 20 20 20 20 20 20 20 7d 0a 0a 20 20 20 20 20 20 20 20 20 20 20 20 69 66 20 28 69 6e 70 75 74 20 3d 3d 20 22 6d 61 6b 65 22 29 0a 20 20 20 20 20 20 20 20 20 20 20 20 7b 0a 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 74 72 79 0a 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 7b 0a 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 53 79 73 2e 46 69 6c 65 53 79 73 74 65 6d 2e 56 46 53 2e 56 46 53 4d 61 6e 61 67 65 72 2e 43 72 65 61 74 65 46 69 6c 65 28 40 22 30 3a 5c 41 5f 46 49 4c 45 2e 74 78 74 22 29 3b 0a 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 7d 0a 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 63 61 74 63 68 20 28 45 78 63 65 70 74 69 6f 6e 20 65 29 0a 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 7b 0a 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 43 6f 6e 73 6f 6c 65 2e 57 72 69 74 65 4c 69 6e 65 28 65 2e 54 6f 53 74 72 69 6e 67 28 29 29 3b 0a 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 7d 0a 20 20 20 20 20 20 20 20 20 20 20 20 7d 0a 20 20 20 20 20 20 20 20 7d 0a 20 20 20 20 7d 0a 7d");
            }

            if (input.StartsWith("cd "))
            {
                try
                {
                    fs.GetDirectory(input.Remove(0, 3));
                    current_directory = @"0:/" + input.Remove(0, 3);

                    if (input.Remove(0, 3) == "..")
                    {
                        current_directory = @"0:/";
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }

            if (input == "ls")
            {
                Console.WriteLine("");
                Console.WriteLine(current_directory);
                Console.WriteLine("");
                try
                {
                    string[] filePaths = Directory.GetFiles(current_directory);
                    for (int i = 0; i < filePaths.Length; ++i)
                    {
                        string path = filePaths[i];
                        Console.WriteLine(System.IO.Path.GetFileName(path));
                    }
                    foreach (var d in System.IO.Directory.GetDirectories(current_directory))
                    {
                        var dir = new DirectoryInfo(d);
                        var dirName = dir.Name;
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine(dirName + " <DIR>");
                        Console.ResetColor();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }

                Console.WriteLine("");

            }

            if (input == "logout")
            {
                try
                {
                    Console.Clear();
                    Sys.Power.Reboot();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }

            if (input == "dir")
            {
                try
                {
                    string[] filePaths = Directory.GetFiles(@"0:\");
                    var drive = new DriveInfo("0");
                    Console.WriteLine("Volume in drive 0 is " + $"{drive.VolumeLabel}");
                    Console.WriteLine("Directory of " + @"0:\");
                    Console.WriteLine("\n");
                    for (int i = 0; i < filePaths.Length; ++i)
                    {
                        string path = filePaths[i];
                        Console.Write(System.IO.Path.GetFileName(path) + " ");
                    }
                    Console.WriteLine("");
                    foreach (var d in System.IO.Directory.GetDirectories(@"0:\"))
                    {
                        var dir = new DirectoryInfo(d);
                        var dirName = dir.Name;
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine(dirName + " ");
                        Console.ResetColor();
                    }
                    Console.WriteLine("\n");
                    Console.WriteLine("        " + $"{drive.TotalSize}" + " bytes");
                    Console.WriteLine("        " + $"{drive.AvailableFreeSpace}" + " bytes free");
                    
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }

            if (input == "neofetch")
            {
                if (title_type == "Default")
                {
                    title_english();
                }
                if (title_type == "Katakana")
                {
                    title_katakana();
                }
                
            }

            

            if (input == "drive")
            {
                try
                {
                    Console.WriteLine("");
                    long available_space = Sys.FileSystem.VFS.VFSManager.GetAvailableFreeSpace(@"0:\");
                    Console.WriteLine("Available Free Space: " + available_space);

                    string fs_type = Sys.FileSystem.VFS.VFSManager.GetFileSystemType(@"0:\");
                    Console.WriteLine("File System Type: " + fs_type);

                    Console.WriteLine("");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }


            if (input == "astley")
            {
                Console.WriteLine("5b 56 65 72 73 65 20 31 5d 0a 57 65 27 72 65 20 6e 6f 20 73 74 72 61 6e 67 65 72 73 20 74 6f 20 6c 6f 76 65 0a 59 6f 75 20 6b 6e 6f 77 20 74 68 65 20 72 75 6c 65 73 20 61 6e 64 20 73 6f 20 64 6f 20 49 0a 41 20 66 75 6c 6c 20 63 6f 6d 6d 69 74 6d 65 6e 74 27 73 20 77 68 61 74 20 49 27 6d 20 74 68 69 6e 6b 69 6e 67 20 6f 66 0a 59 6f 75 20 77 6f 75 6c 64 6e 27 74 20 67 65 74 20 74 68 69 73 20 66 72 6f 6d 20 61 6e 79 20 6f 74 68 65 72 20 67 75 79 0a 0a 5b 50 72 65 2d 43 68 6f 72 75 73 5d 0a 49 20 6a 75 73 74 20 77 61 6e 6e 61 20 74 65 6c 6c 20 79 6f 75 20 68 6f 77 20 49 27 6d 20 66 65 65 6c 69 6e 67 0a 47 6f 74 74 61 20 6d 61 6b 65 20 79 6f 75 20 75 6e 64 65 72 73 74 61 6e 64 0a 0a 5b 43 68 6f 72 75 73 5d 0a 4e 65 76 65 72 20 67 6f 6e 6e 61 20 67 69 76 65 20 79 6f 75 20 75 70 0a 4e 65 76 65 72 20 67 6f 6e 6e 61 20 6c 65 74 20 79 6f 75 20 64 6f 77 6e 0a 4e 65 76 65 72 20 67 6f 6e 6e 61 20 72 75 6e 20 61 72 6f 75 6e 64 20 61 6e 64 20 64 65 73 65 72 74 20 79 6f 75 0a 4e 65 76 65 72 20 67 6f 6e 6e 61 20 6d 61 6b 65 20 79 6f 75 20 63 72 79 0a 4e 65 76 65 72 20 67 6f 6e 6e 61 20 73 61 79 20 67 6f 6f 64 62 79 65 0a 4e 65 76 65 72 20 67 6f 6e 6e 61 20 74 65 6c 6c 20 61 20 6c 69 65 20 61 6e 64 20 68 75 72 74 20 79 6f 75 0a 0a 5b 56 65 72 73 65 20 32 5d 0a 57 65 27 76 65 20 6b 6e 6f 77 6e 20 65 61 63 68 20 6f 74 68 65 72 20 66 6f 72 20 73 6f 20 6c 6f 6e 67 0a 59 6f 75 72 20 68 65 61 72 74 27 73 20 62 65 65 6e 20 61 63 68 69 6e 67 2c 20 62 75 74 20 79 6f 75 27 72 65 20 74 6f 6f 20 73 68 79 20 74 6f 20 73 61 79 20 69 74 0a 49 6e 73 69 64 65 2c 20 77 65 20 62 6f 74 68 20 6b 6e 6f 77 20 77 68 61 74 27 73 20 62 65 65 6e 20 67 6f 69 6e 67 20 6f 6e 0a 57 65 20 6b 6e 6f 77 20 74 68 65 20 67 61 6d 65 2c 20 61 6e 64 20 77 65 27 72 65 20 67 6f 6e 6e 61 20 70 6c 61 79 20 69 74 0a 0a 5b 50 72 65 2d 43 68 6f 72 75 73 5d 0a 41 6e 64 20 69 66 20 79 6f 75 20 61 73 6b 20 6d 65 20 68 6f 77 20 49 27 6d 20 66 65 65 6c 69 6e 67 0a 44 6f 6e 27 74 20 74 65 6c 6c 20 6d 65 20 79 6f 75 27 72 65 20 74 6f 6f 20 62 6c 69 6e 64 20 74 6f 20 73 65 65 0a 0a 5b 43 68 6f 72 75 73 5d 0a 4e 65 76 65 72 20 67 6f 6e 6e 61 20 67 69 76 65 20 79 6f 75 20 75 70 0a 4e 65 76 65 72 20 67 6f 6e 6e 61 20 6c 65 74 20 79 6f 75 20 64 6f 77 6e 0a 4e 65 76 65 72 20 67 6f 6e 6e 61 20 72 75 6e 20 61 72 6f 75 6e 64 20 61 6e 64 20 64 65 73 65 72 74 20 79 6f 75 0a 4e 65 76 65 72 20 67 6f 6e 6e 61 20 6d 61 6b 65 20 79 6f 75 20 63 72 79 0a 4e 65 76 65 72 20 67 6f 6e 6e 61 20 73 61 79 20 67 6f 6f 64 62 79 65 0a 4e 65 76 65 72 20 67 6f 6e 6e 61 20 74 65 6c 6c 20 61 20 6c 69 65 20 61 6e 64 20 68 75 72 74 20 79 6f 75 0a 4e 65 76 65 72 20 67 6f 6e 6e 61 20 67 69 76 65 20 79 6f 75 20 75 70 0a 4e 65 76 65 72 20 67 6f 6e 6e 61 20 6c 65 74 20 79 6f 75 20 64 6f 77 6e 0a 4e 65 76 65 72 20 67 6f 6e 6e 61 20 72 75 6e 20 61 72 6f 75 6e 64 20 61 6e 64 20 64 65 73 65 72 74 20 79 6f 75 0a 4e 65 76 65 72 20 67 6f 6e 6e 61 20 6d 61 6b 65 20 79 6f 75 20 63 72 79 0a 4e 65 76 65 72 20 67 6f 6e 6e 61 20 73 61 79 20 67 6f 6f 64 62 79 65 0a 4e 65 76 65 72 20 67 6f 6e 6e 61 20 74 65 6c 6c 20 61 20 6c 69 65 20 61 6e 64 20 68 75 72 74 20 79 6f 75 0a 0a 5b 50 6f 73 74 2d 43 68 6f 72 75 73 5d 0a 4f 6f 68 20 28 47 69 76 65 20 79 6f 75 20 75 70 29 0a 4f 6f 68 2d 6f 6f 68 20 28 47 69 76 65 20 79 6f 75 20 75 70 29 0a 4f 6f 68 2d 6f 6f 68 0a 4e 65 76 65 72 20 67 6f 6e 6e 61 20 67 69 76 65 2c 20 6e 65 76 65 72 20 67 6f 6e 6e 61 20 67 69 76 65 20 28 47 69 76 65 20 79 6f 75 20 75 70 29 0a 4f 6f 68 2d 6f 6f 68 0a 4e 65 76 65 72 20 67 6f 6e 6e 61 20 67 69 76 65 2c 20 6e 65 76 65 72 20 67 6f 6e 6e 61 20 67 69 76 65 20 28 47 69 76 65 20 79 6f 75 20 75 70 29 0a 0a 5b 42 72 69 64 67 65 5d 0a 57 65 27 76 65 20 6b 6e 6f 77 6e 20 65 61 63 68 20 6f 74 68 65 72 20 66 6f 72 20 73 6f 20 6c 6f 6e 67 0a 59 6f 75 72 20 68 65 61 72 74 27 73 20 62 65 65 6e 20 61 63 68 69 6e 67 2c 20 62 75 74 20 79 6f 75 27 72 65 20 74 6f 6f 20 73 68 79 20 74 6f 20 73 61 79 20 69 74 0a 49 6e 73 69 64 65 2c 20 77 65 20 62 6f 74 68 20 6b 6e 6f 77 20 77 68 61 74 27 73 20 62 65 65 6e 20 67 6f 69 6e 67 20 6f 6e 0a 57 65 20 6b 6e 6f 77 20 74 68 65 20 67 61 6d 65 2c 20 61 6e 64 20 77 65 27 72 65 20 67 6f 6e 6e 61 20 70 6c 61 79 20 69 74 0a 0a 5b 50 72 65 2d 43 68 6f 72 75 73 5d 0a 49 20 6a 75 73 74 20 77 61 6e 6e 61 20 74 65 6c 6c 20 79 6f 75 20 68 6f 77 20 49 27 6d 20 66 65 65 6c 69 6e 67 0a 47 6f 74 74 61 20 6d 61 6b 65 20 79 6f 75 20 75 6e 64 65 72 73 74 61 6e 64 0a 0a 5b 43 68 6f 72 75 73 5d 0a 4e 65 76 65 72 20 67 6f 6e 6e 61 20 67 69 76 65 20 79 6f 75 20 75 70 0a 4e 65 76 65 72 20 67 6f 6e 6e 61 20 6c 65 74 20 79 6f 75 20 64 6f 77 6e 0a 4e 65 76 65 72 20 67 6f 6e 6e 61 20 72 75 6e 20 61 72 6f 75 6e 64 20 61 6e 64 20 64 65 73 65 72 74 20 79 6f 75 0a 4e 65 76 65 72 20 67 6f 6e 6e 61 20 6d 61 6b 65 20 79 6f 75 20 63 72 79 0a 4e 65 76 65 72 20 67 6f 6e 6e 61 20 73 61 79 20 67 6f 6f 64 62 79 65 0a 4e 65 76 65 72 20 67 6f 6e 6e 61 20 74 65 6c 6c 20 61 20 6c 69 65 20 61 6e 64 20 68 75 72 74 20 79 6f 75 0a 4e 65 76 65 72 20 67 6f 6e 6e 61 20 67 69 76 65 20 79 6f 75 20 75 70 0a 4e 65 76 65 72 20 67 6f 6e 6e 61 20 6c 65 74 20 79 6f 75 20 64 6f 77 6e 0a 4e 65 76 65 72 20 67 6f 6e 6e 61 20 72 75 6e 20 61 72 6f 75 6e 64 20 61 6e 64 20 64 65 73 65 72 74 20 79 6f 75 0a 4e 65 76 65 72 20 67 6f 6e 6e 61 20 6d 61 6b 65 20 79 6f 75 20 63 72 79 0a 4e 65 76 65 72 20 67 6f 6e 6e 61 20 73 61 79 20 67 6f 6f 64 62 79 65 0a 4e 65 76 65 72 20 67 6f 6e 6e 61 20 74 65 6c 6c 20 61 20 6c 69 65 20 61 6e 64 20 68 75 72 74 20 79 6f 75 0a 4e 65 76 65 72 20 67 6f 6e 6e 61 20 67 69 76 65 20 79 6f 75 20 75 70 0a 4e 65 76 65 72 20 67 6f 6e 6e 61 20 6c 65 74 20 79 6f 75 20 64 6f 77 6e 0a 4e 65 76 65 72 20 67 6f 6e 6e 61 20 72 75 6e 20 61 72 6f 75 6e 64 20 61 6e 64 20 64 65 73 65 72 74 20 79 6f 75 0a 4e 65 76 65 72 20 67 6f 6e 6e 61 20 6d 61 6b 65 20 79 6f 75 20 63 72 79 0a 4e 65 76 65 72 20 67 6f 6e 6e 61 20 73 61 79 20 67 6f 6f 64 62 79 65 0a 4e 65 76 65 72 20 67 6f 6e 6e 61 20 74 65 6c 6c 20 61 20 6c 69 65 20 61 6e 64 20 68 75 72 74 20 79 6f 75");
            }


            if (input.StartsWith("make "))
            {
                Console.WriteLine("Making " + input.Remove(0, 5) + "...");
                
                try
                {
                    string name = input.Remove(0, 5);
                    Console.WriteLine("Attempt 1 intialzing... [file:" + name + @".txt]");
                    StreamWriter writer = new StreamWriter(name);
                    writer.WriteLine("#");
                    writer.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }

            if (input.StartsWith("mkdir "))
            {
                Console.WriteLine("Making directory " + input.Remove(0, 6) + "...");

                try
                {
                    string name = input.Remove(0, 6);
                    Sys.FileSystem.VFS.VFSManager.CreateDirectory(@"0:\" + name);

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }

            }




            if (input.StartsWith("delf "))
            {
                try
                {

                    var name = input.Remove(0, 5);
                    File.Delete(name);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }

            if (input.StartsWith("deld "))
            {
                try
                {

                    var name = input.Remove(0, 5);
                    Directory.Delete(name);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }

            

            if (input.StartsWith("cat "))
            {
                try
                {
                    var hello_file = Sys.FileSystem.VFS.VFSManager.GetFile(@"0:\" + input.Remove(0, 4));
                    var hello_file_stream = hello_file.GetFileStream();

                    if (hello_file_stream.CanRead)
                    {
                        byte[] text_to_read = new byte[hello_file_stream.Length];
                        hello_file_stream.Read(text_to_read, 0, (int)hello_file_stream.Length);
                        Console.WriteLine(Encoding.Default.GetString(text_to_read));
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }

            if (input.StartsWith("write "))
            {
                try
                {
                    var hello_file = Sys.FileSystem.VFS.VFSManager.GetFile(@"0:\" + input.Remove(0, 6));
                    var hello_file_stream = hello_file.GetFileStream();

                    if (hello_file_stream.CanWrite)
                    {
                        Console.Write("Write? > ");
                        string written = Console.ReadLine();
                        byte[] text_to_write = Encoding.ASCII.GetBytes(written);
                        hello_file_stream.Write(text_to_write, 0, text_to_write.Length);
                    }
                    Console.WriteLine("DONE");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }


            if (input == "shutdown")
            {
                Sys.Power.Shutdown();
                Stop();
            }

            if (input == "reboot")
            {
                Sys.Power.Reboot();
            }

            if (input == "hextest")
            {
                try
                {
                    NEWHEX.Class1.Main();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }

            if (input == "HEX")
            {
                try
                {
                    string data = @"Somebody once told me the world is gonna roll me
                                    I ain't the sharpest tool in the shed
                                    She was looking kind of dumb with her finger and her thumb
                                    In the shape of an 'L' on her forehead
                                    Well the years start coming and they don't stop coming
                                    Fed to the rules and I hit the ground running
                                    Didn't make sense not to live for fun
                                    Your brain gets smart but your head gets dumb
                                    So much to do, so much to see
                                    So what's wrong with taking the back streets?
                                    You'll never know if you don't go
                                    You'll never shine if you don't glow
                                    Hey now, you're an all-star, get your game on, go play
                                    Hey now, you're a rock star, get the show on, get paid
                                    And all that glitters is gold
                                    Only shooting stars break the mold
                                    It's a cool place and they say it gets colder
                                    You're bundled up now, wait 'til you get older
                                    But the meteor men beg to differ
                                    Judging by the hole in the satellite picture
                                    The ice we skate is getting pretty thin
                                    The water's getting warm so you might as well swim
                                    My world's on fire, how about yours?
                                    That's the way I like it and I'll never get bored
                                    Hey now, you're an all-star, get your game on, go play
                                    Hey now, you're a rock star, get the show on, get paid
                                    All that glitters is gold
                                    Only shooting stars break the mold
                                    Hey now, you're an all-star, get your game on, go play
                                    Hey now, you're a rock star, get the show, on get paid
                                    And all that glitters is gold
                                    Only shooting stars
                                    Somebody once asked could I spare some change for gas?
                                    I need to get myself away from this place
                                    I said, 'Yup' what a concept
                                    I could use a little fuel myself
                                    And we could all use a little change
                                    Well, the years start coming and they don't stop coming
                                    Fed to the rules and I hit the ground running
                                    Didn't make sense not to live for fun
                                    Your brain gets smart but your head gets dumb
                                    So much to do, so much to see
                                    So what's wrong with taking the back streets?
                                    You'll never know if you don't go(go!)
                                    You'll never shine if you don't glow
                                    Hey now, you're an all-star, get your game on, go play
                                    Hey now, you're a rock star, get the show on, get paid
                                    And all that glitters is gold
                                    Only shooting stars break the mold
                                    And all that glitters is gold
                                    Only shooting stars break the mold";


                    byte[] bytes = Encoding.ASCII.GetBytes(data);
                    int bytesPerLine = 16;
                    int bytesLength = bytes.Length;

                    char[] HexChars = "0123456789ABCDEF".ToCharArray();

                    int firstHexColumn =
                            8                   // 8 characters for the address
                        + 3;                  // 3 spaces

                    int firstCharColumn = firstHexColumn
                        + bytesPerLine * 3       // - 2 digit for the hexadecimal value and 1 space
                        + (bytesPerLine - 1) / 8 // - 1 extra space every 8 characters from the 9th
                        + 2;                  // 2 spaces 

                    int lineLength = firstCharColumn
                        + bytesPerLine           // - characters to show the ascii value
                        + Environment.NewLine.Length; // Carriage return and line feed (should normally be 2)

                    char[] line = (new String(' ', lineLength - Environment.NewLine.Length) + Environment.NewLine).ToCharArray();
                    int expectedLines = (bytesLength + bytesPerLine - 1) / bytesPerLine;
                    StringBuilder result = new StringBuilder(expectedLines * lineLength);

                    for (int i = 0; i < bytesLength; i += bytesPerLine)
                    {
                        line[0] = HexChars[(i >> 28) & 0xF];
                        line[1] = HexChars[(i >> 24) & 0xF];
                        line[2] = HexChars[(i >> 20) & 0xF];
                        line[3] = HexChars[(i >> 17) & 0xF];
                        line[4] = HexChars[(i >> 12) & 0xF];
                        line[5] = HexChars[(i >> 8) & 0xF];
                        line[6] = HexChars[(i >> 4) & 0xF];
                        line[7] = HexChars[(i >> 0) & 0xF];

                        int hexColumn = firstHexColumn;
                        int charColumn = firstCharColumn;

                        for (int j = 0; j < bytesPerLine; j++)
                        {
                            if (j > 0 && (j & 7) == 0) hexColumn++;
                            if (i + j >= bytesLength)
                            {
                                line[hexColumn] = ' ';
                                line[hexColumn + 1] = ' ';
                                line[charColumn] = ' ';
                            }
                            else
                            {
                                byte b = bytes[i + j];
                                line[hexColumn] = HexChars[(b >> 4) & 0xF];
                                line[hexColumn + 1] = HexChars[b & 0xF];
                                line[charColumn] = (b < 32 ? '·' : (char)b);
                            }
                            hexColumn += 3;
                            charColumn++;
                        }
                        int characters = 0;
                        int not_right = 0;
                        foreach (char c in line)
                        {
                            characters += 1;
                        }
                        if (characters == 1)
                        {
                            not_right = 1;
                        }
                        if (not_right == 0)
                        {
                            result.Append(line);
                        }
                     
                    }

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(result.ToString());
                    Console.ResetColor();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }

            if (input == "OS")
            {

                Console.WriteLine("OS - ONIONS OS v.21");
            }

            if (input.StartsWith("echo ")) { Console.WriteLine(input.Remove(0, 5)); }

            if (input == "cls") { Console.Clear(); }

            if (input == "drive2")
            {
                try
                {
                    DriveInfo[] allDrives = DriveInfo.GetDrives();

                    foreach (DriveInfo d in allDrives)
                    {
                        Console.WriteLine("Drive {0}", d.Name);
                        Console.WriteLine("  Drive type: {0}", d.DriveType);
                        if (d.IsReady == true)
                        {
                            Console.WriteLine("  Volume label: {0}", d.VolumeLabel);
                            Console.WriteLine("  File system: {0}", d.DriveFormat);
                            Console.WriteLine(
                                "  Available space to current user:{0, 15} bytes",
                                d.AvailableFreeSpace);

                            Console.WriteLine(
                                "  Total available space:          {0, 15} bytes",
                                d.TotalFreeSpace);

                            Console.WriteLine(
                                "  Total size of drive:            {0, 15} bytes ",
                                d.TotalSize);
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }

            if (input.StartsWith("username "))
            {
                username = input.Remove(0, 9);
            }

        }
    }

}