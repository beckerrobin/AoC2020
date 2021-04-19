using System.IO;
using System.Collections.Generic;
using System;

namespace day_9
{
    class Program
    {
        static int sizeLimit = 25;
        static List<int> numbersList = new List<int>();

        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines("input.txt");

            // Initial list population
            for (int i = 0; i < sizeLimit; i++)
            {
                int number = int.Parse(input[i]);
                numbersList.Add(number);
            }

            int partOne = 0, partOneIndex = 0;

            // Searching loop
            for (int i = sizeLimit; i < input.Length; i++)
            {
                int currentNumber = int.Parse(input[i]);
                if (!validateNumber(currentNumber))
                {
                    partOneIndex = i;
                    partOne = currentNumber;
                    System.Console.WriteLine("Part one: " + partOne);
                    break;
                }
                numbersList.Add(currentNumber);
            }

            Queue<int> termList = new Queue<int>();
            int sum = 0;

            for (int i = 0; i < partOneIndex; i++)
            {
                sum += numbersList[i];

                while (sum > partOne)
                {
                    sum -= termList.Dequeue();
                }

                if (sum == partOne)
                {
                    int firstTerm = termList.Peek();
                    int lastTerm = termList.ToArray()[termList.Count - 1];
                    System.Console.WriteLine("Part two! " + firstTerm + " + " + lastTerm + " = " + (firstTerm + lastTerm));
                    break;
                }
                termList.Enqueue(numbersList[i]);
            }

        }

        static bool validateNumber(int testNumber)
        {
            for (int i = numbersList.Count - sizeLimit; i < numbersList.Count; i++)
            {
                int tempNumber = testNumber;
                tempNumber -= numbersList[i];
                if (numbersList.Contains(tempNumber))
                    return true;
            }
            return false;
        }
    }
}
