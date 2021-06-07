using System;
using System.Collections.Generic;

namespace Task5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Select mode: 1.Console input expression; 2.Read expression from file? ");
            SelectMode(Console.ReadLine());
        }

        private static void SelectMode(string answer)
        {
            int mode;
            try
            {
                mode = int.Parse(answer);
                if (mode < 1 || mode > 2)
                    throw new ArgumentException();
            }
            catch
            {
                Console.WriteLine("Incorrect select!");
                return;
            }

            switch (mode)
            {
                case 1: RunMode1(); break;
                case 2: RunMode2(); break;
            }
        }

        private static void RunMode1()
        {
            while (true)
            {
                Console.Write("Enter expression: ");
                string input = Console.ReadLine();
                try
                {
                    if (input.Contains('(') || input.Contains(')'))
                        throw new ArgumentException();

                    Console.WriteLine("Result: " + MathParser.ParseSimpleExp(input));
                }
                catch
                {
                    Console.WriteLine("Incorrect expression!");
                }
            }
        }

        private static void RunMode2()
        {
            string path = "";
            while (true)
            {
                Console.Write("Enter input file path: ");
                path = Console.ReadLine();
                if (FileIO.FileExist(path))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("File is not exist!");
                }
            }

            Console.Write("Output file name: ");
            FileIO fileIO = new FileIO(path, Console.ReadLine());
            fileIO.Process();
        }
        
    }
}
