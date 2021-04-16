using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System;

namespace day_8
{
    class Program
    {
        static void PartOne()
        {
            string[] input = File.ReadAllLines("input.txt");

            Regex regex = new Regex(@"^(\w+) ([+-])(\d+)$");

            int accumulator = 0;
            List<int> visitedAddresses = new List<int>();

            for (int i = 0; i < input.Length;)
            {
                visitedAddresses.Add(i);
                string line = input[i];
                Match result = regex.Match(line);

                string operation = result.Groups[1].ToString();
                string argModifier = result.Groups[2].ToString();
                int argValue = int.Parse(result.Groups[3].ToString());
                if (argModifier == "-")
                    argValue *= -1;

                switch (operation)
                {
                    case "acc":
                        accumulator += argValue;
                        i++;
                        break;
                    case "jmp":
                        i += argValue;
                        break;
                    default:  // "nop"
                        i++;
                        break;
                }
                if (visitedAddresses.Contains(i))
                {
                    System.Console.WriteLine("Part one: " + accumulator);
                    break;
                }
            }

        }

        static void PartTwo()
        {
            HashSet<int> triedChanges = new HashSet<int>();
            string[] input = File.ReadAllLines("input.txt");

            Regex regex = new Regex(@"^(\w+) ([+-])(\d+)$");

            while (true)
            {
                System.Console.WriteLine("Starting " + triedChanges.Count);
                bool loopFound = false;
                Dictionary<int, string> visitedAddresses = new Dictionary<int, string>();

                int accumulator = 0;
                for (int i = 0; i < input.Length;)
                {
                    string line = input[i];
                    Match result = regex.Match(line);

                    string operation = result.Groups[1].ToString();
                    string argModifier = result.Groups[2].ToString();
                    int argValue = int.Parse(result.Groups[3].ToString());
                    if (argModifier == "-")
                        argValue *= -1;

                    visitedAddresses.Add(i, operation);

                    int nextIndex = operation == "jmp" ? i + argValue : i + 1;

                    if (operation == "acc")
                        accumulator += argValue;
                    else if (triedChanges.Contains(i + argValue) || triedChanges.Contains(i + 1))
                    {
                        loopFound = true;
                        break;
                    }
                    else if (operation != "acc")
                    {
                        switch (operation)
                        {
                            case "jmp":
                                operation = "nop";
                                break;
                            case "nop":
                                operation = "jmp";
                                break;
                        }
                        System.Console.WriteLine("Tried pos " + i);
                        triedChanges.Add(i);
                    }

                    i = nextIndex;

                    // Loop found
                    if (visitedAddresses.ContainsKey(i) || triedChanges.Contains(i))
                    {
                        loopFound = true;
                        break;
                    }
                }

                if (!loopFound)
                    break;
            }
            System.Console.WriteLine("Part two!");
        }
        static void Main(string[] args)
        {
            PartOne();
            PartTwo();
        }
    }
}
