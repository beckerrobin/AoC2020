using System.Collections.Generic;
using System.IO;

namespace day_6
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines("input.txt");

            int countPartOne = 0;
            HashSet<char> declarationPartOne = new HashSet<char>();

            for (int i = 0; i < input.Length; i++)
            {
                string line = input[i];

                foreach (char letter in line)
                    declarationPartOne.Add(letter);

                if (line.Trim().Length == 0 || i == input.Length - 1)
                {
                    countPartOne += declarationPartOne.Count;
                    declarationPartOne.Clear();
                }
            }

            int countPartTwo = 0;
            List<HashSet<char>> group = new List<HashSet<char>>();

            for (int i = 0; i < input.Length; i++)
            {
                string line = input[i];

                if (line.Trim().Length > 0)
                {
                    HashSet<char> declaration = new HashSet<char>();
                    foreach (char letter in line)
                        declaration.Add(letter);
                    group.Add(declaration);
                }
                if (line.Trim().Length == 0 || i == input.Length - 1)
                {
                    bool hasCommon = true;
                    for (int j = 1; j < group.Count; j++)
                    {
                        if (!group[j - 1].Overlaps(group[j]))
                        {
                            hasCommon = false;
                            break;
                        }
                        group[0].IntersectWith(group[j]);
                    }
                    if (hasCommon)
                        countPartTwo += group[0].Count;
                    group.Clear();
                }
            }

            System.Console.WriteLine("Part one: " + countPartOne);
            System.Console.WriteLine("Part two: " + countPartTwo);
        }
    }
}
