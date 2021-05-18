using System.Numerics;
using System.Collections.Generic;
using System.IO;
using System;

namespace day_10
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines("input.txt");

            List<int> adapters = new List<int>();

            foreach (string row in input)
                adapters.Add(int.Parse(row));

            adapters.Insert(0, 0);
            adapters.Sort();

            int jolt = 0, one_jolt = 0, three_jolt = 1;

            foreach (int adapter in adapters)
            {
                if (adapter - jolt == 1)
                    one_jolt++;
                else if (adapter - jolt == 3)
                    three_jolt++;

                jolt = adapter;
            }
            System.Console.WriteLine("Part one: " + one_jolt + "+" + three_jolt + " = " + (one_jolt * three_jolt));

            BigInteger branches = new BigInteger(1);

            for (int i = 0; i < adapters.Count - 1; i++)
            {
                int groupSize = 0;
                for (int n = 2; i + n < adapters.Count && adapters[i + n] - adapters[i] == n; n++)
                {
                    groupSize++;
                }
                if (groupSize == 1)
                {
                    branches *= 2;
                }
                else if (groupSize == 2)
                {
                    branches *= 4;
                }
                else if (groupSize == 3)
                {
                    branches *= 7;
                }
                
                i += groupSize;
            }
            System.Console.WriteLine("Part two: " + branches);
        }
    }
}
