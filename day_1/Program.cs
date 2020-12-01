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
                string line = input[i];
                string find = Convert.ToString(2020 - Convert.ToInt16(line));
                for (int j = i + 1; j < input.Length; j++)
                {
                    string possibleMatch = input[j];
                    if (find.Equals(possibleMatch))
                    {
                        System.Console.WriteLine(line + " + " + find + " = 2020");
                        System.Console.WriteLine("Answer: " + Convert.ToInt16(line) * Convert.ToInt16(find));
                        return;
                    }
                }

            }
        }
    }
}
