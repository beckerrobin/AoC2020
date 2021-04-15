using System;
using System.IO;

namespace day_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines("input.txt");
            int validPasswordsPartOne = 0;
            int validPasswordsPartTwo = 0;

            for (int i = 0; i < input.Length; i++)
            {
                string[] lineArray = input[i].Split(": ");
                if (validatePasswordPartOne(lineArray[0], lineArray[1]))
                {
                    validPasswordsPartOne++;
                }
                if (validatePasswordPartTwo(lineArray[0], lineArray[1]))
                {
                    validPasswordsPartTwo++;
                }
            }
            System.Console.WriteLine("Valid passwords, part one: " + validPasswordsPartOne);
            System.Console.WriteLine("Valid passwords, part two: " + validPasswordsPartTwo);
        }
        static bool validatePasswordPartOne(string ruleString, string password)
        {
            string[] rulesArray = ruleString.Split(" ");

            string[] rulesMinMax = rulesArray[0].Split("-");
            int minRule = int.Parse(rulesMinMax[0]);
            int maxRule = int.Parse(rulesMinMax[1]);

            string ruleLetter = rulesArray[1];

            int count = password.Length - password.Replace(ruleLetter, "").Length;
            return count >= minRule && count <= maxRule;
        }
        static bool validatePasswordPartTwo(string ruleString, string password)
        {
            string[] rulesArray = ruleString.Split(" ");

            string[] rulesPositions = rulesArray[0].Split("-");
            int firstPos = int.Parse(rulesPositions[0]);
            int secondPos = int.Parse(rulesPositions[1]);

            string ruleLetter = rulesArray[1];

            return password[firstPos-1].ToString() == ruleLetter ^ password[secondPos-1].ToString() == ruleLetter;
        }
    }
}
