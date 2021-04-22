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

        }
    }
}
