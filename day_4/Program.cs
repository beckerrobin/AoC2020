using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace day_4
{
    class Program
    {
        static Regex hgt = new Regex(@"^(\d{2,3})(cm|in)$");
        static Regex hcl = new Regex(@"^#[0-9a-f]{6}$");
        static List<string> eclList = new List<string>() { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };
        static Regex pid = new Regex(@"^\d{9}$");

        static bool validatePassportPartOne(Dictionary<string, string> passport)
        {
            return passport.ContainsKey("byr") &&
                     passport.ContainsKey("iyr") &&
                     passport.ContainsKey("eyr") &&
                     passport.ContainsKey("hgt") &&
                     passport.ContainsKey("hcl") &&
                     passport.ContainsKey("ecl") &&
                     passport.ContainsKey("pid");
        }
        static bool validatePassportPartTwo(Dictionary<string, string> passport)
        {
            if (!validatePassportPartOne(passport))
                return false;

            int byr;
            if (!int.TryParse(passport["byr"], out byr) || byr < 1920 || byr > 2002)
                return false;

            int iyr;
            if (!int.TryParse(passport["iyr"], out iyr) || iyr < 2010 || iyr > 2020)
                return false;

            int eyr;
            if (!int.TryParse(passport["eyr"], out eyr) || eyr < 2020 || eyr > 2030)
                return false;

            Match match = hgt.Match(passport["hgt"]);
            if (!match.Success)
                return false;
            else
            {
                int height = int.Parse(match.Groups[1].ToString());
                if (match.Groups[2].ToString() == "cm")
                {
                    if (height < 150 || height > 193)
                        return false;
                }
                else if (height < 59 || height > 76)
                    return false;
            }

            if (!hcl.IsMatch(passport["hcl"]))
                return false;

            if (!eclList.Contains(passport["ecl"]))
                return false;

            if (!pid.IsMatch(passport["pid"]))
                return false;

            return true;
        }
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines("input.txt");

            int validPassportCounterPartOne = 0;
            int validPassportCounterPartTwo = 0;
            var tempPassport = new Dictionary<string, string>();

            for (int i = 0; i < input.Length; i++)
            {
                string line = input[i];
                if (line.Length > 0)
                {
                    string[] attributes = line.Split(" ");
                    foreach (string kvString in attributes)
                    {
                        string[] kvArr = kvString.Split(":");
                        tempPassport.Add(kvArr[0], kvArr[1]);
                    }
                }
                if (line.Length == 0 || i == input.Length - 1)
                {
                    if (validatePassportPartOne(tempPassport))
                        validPassportCounterPartOne++;
                    if (validatePassportPartTwo(tempPassport))
                        validPassportCounterPartTwo++;
                    tempPassport.Clear();
                }

            }
            System.Console.WriteLine("Part one: " + validPassportCounterPartOne);
            System.Console.WriteLine("Part two: " + validPassportCounterPartTwo);
        }
    }
}
