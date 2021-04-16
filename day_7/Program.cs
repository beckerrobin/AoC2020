using System.Numerics;
using System.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace day_7
{
    class Program
    {
        static Dictionary<string, Dictionary<string, int>> bagDictionary = new Dictionary<string, Dictionary<string, int>>();
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines("input.txt");

            Regex reColor = new Regex(@"^([a-z\s]+) bags contain");
            Regex reContainer = new Regex(@"(\d+) (\w+ \w+) bags?");

            for (int i = 0; i < input.Length; i++)
            {
                string line = input[i];

                Match match = reColor.Match(line);
                string color = match.Groups[1].ToString();
                Dictionary<string, int> contains = new Dictionary<string, int>();
                if (!line.EndsWith("no other bags."))
                {
                    MatchCollection containMatches = reContainer.Matches(line);
                    for (int j = 0; j < containMatches.Count; j++)
                    {
                        string canContainColor = containMatches[j].Groups[2].ToString();
                        int canContainAmount = int.Parse(containMatches[j].Groups[1].ToString());
                        contains.Add(canContainColor, canContainAmount);
                    }
                }
                bagDictionary.Add(color, contains);
            }

            HashSet<string> canContainSet = new HashSet<string>();
            while (true)
            {
                Dictionary<string, Dictionary<string, int>> tmpDictionary = cloneDictionary(bagDictionary);
                bool found = false;
                foreach (KeyValuePair<string, Dictionary<string, int>> entry in tmpDictionary)
                {
                    if (entry.Value.Keys.Contains("shiny gold") || new HashSet<string>(entry.Value.Keys).Overlaps(canContainSet))
                    {
                        canContainSet.Add(entry.Key);
                        bagDictionary.Remove(entry.Key);
                        found = true;
                    }
                }

                if (!found)
                {
                    break;
                }
            }

            System.Console.WriteLine("Part one: " + canContainSet.Count);
            System.Console.WriteLine("Part two: " + (recursiveBagCounter("shiny gold", 0) - 1));
        }
        static Dictionary<string, Dictionary<string, int>> cloneDictionary(Dictionary<string, Dictionary<string, int>> sourceDictionary)
        {
            Dictionary<string, Dictionary<string, int>> targetDictionary = new Dictionary<string, Dictionary<string, int>>();

            foreach (KeyValuePair<string, Dictionary<string, int>> entry in sourceDictionary)
            {
                Dictionary<string, int> tmpDictionary = new Dictionary<string, int>();
                foreach (KeyValuePair<string, int> subEntry in entry.Value)
                {
                    tmpDictionary.Add(subEntry.Key, subEntry.Value);
                }

                targetDictionary.Add(entry.Key, tmpDictionary);
            }
            return targetDictionary;
        }

        static BigInteger recursiveBagCounter(string key, BigInteger counter)
        {
            Dictionary<string, int> contains = bagDictionary[key];
            BigInteger value = 0;
            if (contains.Count == 0)
            {
                return 1;
            }
            foreach (KeyValuePair<string, int> kvp in contains)
            {
                BigInteger bagValue = recursiveBagCounter(kvp.Key, counter);
                value += kvp.Value * bagValue;
            }

            return (counter + value) + 1;
        }
    }
}
