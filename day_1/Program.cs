using System;
using System.IO;

namespace day_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines("input.txt");

            for (int i = 0; i < input.Length; i++)
            {
                int line = Convert.ToInt16(input[i]);
                int find = 2020 - line;
                for (int j = i + 1; j < input.Length; j++)
                {
                    int possibleMatch = Convert.ToInt16(input[j]);
                    if (find.Equals(possibleMatch))
                    {
                        System.Console.WriteLine(line + " + " + find + " = 2020");
                        System.Console.WriteLine("Part one answer: " + line * possibleMatch);
                    }
                    else if (possibleMatch < find)
                    {
                        int lastFind = 2020 - line - possibleMatch;
                        for (int k = j + 1; k < input.Length; k++)
                        {
                            int possibleLastMatch = Convert.ToInt16(input[k]);
                            if (lastFind.Equals(possibleLastMatch))
                            {
                                System.Console.WriteLine(line + " + " + possibleMatch + " + " + possibleLastMatch + " = 2020");
                                System.Console.WriteLine("Part two answer: " + line * possibleMatch * possibleLastMatch);
                                return;
                            }
                        }
                    }
                }
            }
        }
    }
}
