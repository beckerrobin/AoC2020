using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace day_7
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines("input.txt");

            Regex reColor = new Regex(@"^([a-z\s]+) bags contain");
            Regex reContainer = new Regex(@"\d+ (\w+ \w+) bags?");

            Dictionary<string, List<string>> bagDictionary = new Dictionary<string, List<string>>();
            HashSet<string> canContainSet = new HashSet<string>();

            for (int i = 0; i < input.Length; i++)
            {
                string line = input[i];
                Match match = reColor.Match(line);
                string color = match.Groups[1].ToString();
                System.Console.WriteLine(color);

                if (!line.EndsWith("no other bags."))
                {
                    MatchCollection containMatches = reContainer.Matches(line);

                    for (int j = 0; j < containMatches.Count; j++)
                    {
                        string canContainColor = containMatches[j].Groups[1].ToString();
                        if (canContainColor == "shiny gold" || canContainSet.Contains(canContainColor))
                        {
                            System.Console.WriteLine("\t" + canContainColor);
                            canContainSet.Add(color);
                            break;
                        }
                    }
                }
            }
            System.Console.WriteLine("Part one: " + canContainSet.Count);
        }
    }
}
