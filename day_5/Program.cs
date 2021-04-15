using System.Collections.Generic;
using System;
using System.IO;

namespace day_5
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines("input.txt");
            
            List<int> seatIds = new List<int>();
            int max = 0;
            for (int i = 0; i < input.Length; i++)
            {
                int seatId = calculateSeatID(input[i]);
                seatIds.Add(seatId);
                max = Math.Max(max, seatId);
            }
            System.Console.WriteLine("Part one: " + max);

            for (int i = 0; i < 126 * 8; i++)
            {
                if (!seatIds.Contains(i) && seatIds.Contains(i - 1) && seatIds.Contains(i + 1))
                {
                    System.Console.WriteLine("Part two: " + i);
                }
            }
        }

        static int calculateSeatID(string seatString)
        {
            int rows = 128;
            int seat = 0;

            for (int i = 0; i < 7; i++)
            {
                rows /= 2;
                if (seatString[i] == 'B')
                    seat += rows;
            }

            int columns = 8;
            int col = 0;
            for (int i = 7; i < 10; i++)
            {
                columns /= 2;
                if (seatString[i] == 'R')
                    col += columns;
            }

            return seat * 8 + col;
        }
    }
}
