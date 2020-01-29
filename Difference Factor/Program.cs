using System;
using System.Text.RegularExpressions;
using System.IO;
using System.Collections.Generic;

namespace Difference_Factor
{
    class Program
    {
        // need to implement input through a file ".txt" and only running once
        static void Main(string[] args)
        {
            if (!File.Exists("./input.txt"))
                File.CreateText("./input.txt").Close();
            Help();
            string buffer = string.Empty;
            while (true)
            {
                string raw_input = Console.ReadLine();
                switch (raw_input.ToLower())
                {
                    case "help":
                        Help();
                        break;
                    case "clear":
                        Console.Clear();
                        break;
                    case "":
                    default:
                        if (!File.Exists("./input.txt"))
                        {
                            Console.WriteLine("File not found, making a new one.");
                            File.CreateText("./input.txt").Close();
                        }
                        try
                        {
                            buffer = File.ReadAllText("./input.txt");
                        } catch (Exception e) { Console.WriteLine("Oops, you made a exception:\n\n" + e.Message); }

                        ParseandExecute(buffer);
                        buffer = string.Empty;
                        break;
                }
            }
            

        }

        public static void Help()
        {
            Console.WriteLine("FORMAT DIRECTIONS:\nSeparate different strings on the same input via the enter key.\nPress # on a new line to separate input streams.");
            Console.WriteLine("Example:\n\nString1\nString2\n#\nSecondstring1\nSecondstring2\n\n");
            Console.WriteLine("Type CLEAR to clear the console\nType HELP to show this screen again");
            Console.WriteLine("Please fill the \"input.txt\" with input formatted in this way then press enter in the console to execute.\nYou may reuse the same text file for input, just remember to save.");
        }

        public static void ParseandExecute(string contents)
        {
            List<Tuple<string, string>> Input = new List<Tuple<string, string>>();

            contents = contents.Replace("\r", "");
            foreach (string i in contents.Split('#'))
            {
                if (i[0].ToString() == "\n")
                    i.Remove(0, 1);
                try
                {
                    if (i[0].ToString() == "\n")
                        Input.Add(new Tuple<string, string>(i.Remove(0, 1).Split("\n".ToCharArray()[0])[0], i.Remove(0, 1).Split("\n".ToCharArray()[0])[1]));
                    else
                        Input.Add(new Tuple<string, string>(i.Split("\n".ToCharArray()[0])[0], i.Split("\n".ToCharArray()[0])[1]));

                } catch (IndexOutOfRangeException) { Console.WriteLine("Looks like you have a format error"); return; }
                catch (Exception) { Console.WriteLine("Looks like you have an unknown error!"); }
            }

            int buff = 0;
            foreach (var i in Input)
            {
                Console.WriteLine(Difference_Factor.ADFRecursively(i.Item1, i.Item2, ref buff));
                buff = 0;
            }
            Console.WriteLine("\nExecuted successfully!");
        }
    }
}
