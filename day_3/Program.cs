using System;
using System.IO;

namespace day_3
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines("input.txt");

            // Part one
            System.Console.WriteLine("Part one: " + treeCounter(input, 3, 1));

            // Part two
            long sum = 1;
            int[,] slopes = new int[,] { { 1, 1 }, { 3, 1 }, { 5, 1 }, { 7, 1 }, { 1, 2 } };
            for (int i = 0; i < slopes.Length / 2; i++)
            {
                sum *= treeCounter(input, slopes[i, 0], slopes[i, 1]);;
            }
            System.Console.WriteLine("Part two: " + sum);
        }

        static int treeCounter(string[] input, int xOffset, int yOffset)
        {
            int treeCounter = 0;
            int x = 0;

            for (int i = 0; i < input.Length - 1; i+= yOffset)
            {
                if (i + yOffset >= input.Length)
                    break;
                x += xOffset;
                string nextLine = input[i + yOffset];
                if (x > nextLine.Length - 1)
                {
                    x = x - nextLine.Length;
                }
                if (nextLine[x].ToString() == "#")
                {
                    treeCounter++;
                }
            }
            return treeCounter;
        }
    }
}
