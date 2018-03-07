using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Problem02//DICT
{//planet name -> planet population -> attack type -> soldier count
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<long>> attackedPlanetData = new Dictionary<string, List<long>>();
            Dictionary<string, List<long>> destroyedPlanetData = new Dictionary<string, List<long>>();
            int n = int.Parse(Console.ReadLine());
            string line;
            string regexPattern = @"@([A-Z])([a-zA-Z]*)([^@\-!:>]?):(\d+)!([A|D])!->([0-9]+)";
            int attackedPlanets = 0, destroyedPlanets = 0;
            for (int i = 0; i < n; i++)
            {
                line = Console.ReadLine();
                int count = 0;
                foreach (char item in line)
                {
                    if (item == 's' || item == 't' || item == 'a' || item == 'r' || item == 'S' || item == 'T' || item == 'A' || item == 'R')
                    {
                        count++;
                    }
                }
                StringBuilder sb = new StringBuilder();
                foreach (char item in line)
                {
                    sb.Append((char)(item - count));
                }
                string message = sb.ToString();
                Match myMatch = Regex.Match(message, regexPattern);
                if (myMatch.Groups.Count!=7)
                {
                    continue;
                }
                string planet = myMatch.Groups[1].ToString() + myMatch.Groups[2].ToString();
                long population = long.Parse(myMatch.Groups[4].ToString());
                string attackType = myMatch.Groups[5].ToString();
                long soldierCount = long.Parse(myMatch.Groups[6].ToString());

                if (attackType.Equals("A"))
                {
                    attackedPlanets++;
                    if (!attackedPlanetData.ContainsKey(planet))
                    {
                        List<long> newList = new List<long> { population, soldierCount };
                        attackedPlanetData.Add(planet, newList);
                    }
                    else
                    {
                        attackedPlanetData[planet][0] = population;
                        attackedPlanetData[planet][0] = soldierCount;
                    }
                }
                else if (attackType.Equals("D"))
                {
                    destroyedPlanets++;
                    if (!destroyedPlanetData.ContainsKey(planet))
                    {
                        List<long> newList = new List<long> { population, soldierCount };
                        destroyedPlanetData.Add(planet, newList);
                    }
                    else
                    {
                        destroyedPlanetData[planet][0] = population;
                        destroyedPlanetData[planet][0] = soldierCount;
                    }
                }
            }

            Console.WriteLine($"Attacked planets: {attackedPlanets}");
            foreach (var pair in attackedPlanetData.OrderBy(x => x.Key))
            {
                Console.WriteLine($"-> {pair.Key}");
            }
            Console.WriteLine($"Destroyed planets: {destroyedPlanets}");
            foreach (var pair in destroyedPlanetData.OrderBy(x => x.Key))
            {
                Console.WriteLine($"-> {pair.Key}");
            }
        }
    }
}