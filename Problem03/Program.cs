using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem03
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> sides = new Dictionary<string, string>();

            string line;
            string oneOfTheForces = string.Empty;
            int oneOfTheForcesCount = 0;
            int theOtherOfTheForcesCount = 0;
            while ((line = Console.ReadLine())!= "Lumpawaroo")
            {
                string[] tokens = line.Split().ToArray();
                string divider = tokens[1];

                if (divider.Equals("|"))
                {


                    string[] elements = line.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                    string force = elements[0];
                    string name = elements[1];
                    oneOfTheForces = force;

                    if (!sides.ContainsKey(name))
                    {
                        sides.Add(name, force);
                    }
                }
                else if(divider.Equals("->"))
                {
                    string[] elements = line.Split("->").ToArray();
                    string name = elements[0];
                    string movesToForce = elements[1];

                    if (!sides.ContainsKey(name))
                    {
                        sides.Add(name, movesToForce);
                    }
                    else
                    {
                        sides[name] = movesToForce;
                        Console.WriteLine($"{name} joins the {movesToForce} side!");
                    }
                }
            }




            //COUNTING SIDES
            foreach (var pair in sides)
            {
                if (pair.Value.Equals(oneOfTheForces))
                {
                    oneOfTheForcesCount++;
                }
                else
                {
                    theOtherOfTheForcesCount++;
                }
            }


            //PRINT
            string theOtherOfTheForces = string.Empty;
            if ((oneOfTheForcesCount > theOtherOfTheForcesCount) || ((oneOfTheForcesCount==theOtherOfTheForcesCount)) && IsBigger(oneOfTheForces, theOtherOfTheForces))
            {
                Console.WriteLine($"Side: {oneOfTheForces.Trim()}, Members: {oneOfTheForcesCount}");
                foreach (var pair in sides.OrderBy(x=>x.Key))
                {
                    if (pair.Value.Equals(oneOfTheForces))
                    {
                        Console.WriteLine($"!{pair.Key}");
                    }
                    else
                    {
                        theOtherOfTheForces = pair.Value;
                    }
                }
                Console.WriteLine($"Side: {theOtherOfTheForces.Trim()}, Members: {theOtherOfTheForcesCount}");
                foreach (var pair in sides.OrderBy(x => x.Key))
                {
                    if (!pair.Value.Equals(oneOfTheForces))
                    {
                        Console.WriteLine($"!{pair.Key}");
                    }
                }
            }
            else if ((oneOfTheForcesCount < theOtherOfTheForcesCount) || ( (oneOfTheForcesCount==theOtherOfTheForcesCount)) && IsBigger(theOtherOfTheForces, oneOfTheForces))
            {
                Console.WriteLine($"Side: {theOtherOfTheForces.Trim()}, Members: {theOtherOfTheForcesCount}");
                foreach (var pair in sides.OrderBy(x => x.Key))
                {
                    if (!pair.Value.Equals(oneOfTheForces))
                    {
                        Console.WriteLine($"!{pair.Key}");
                    }
                }
                Console.WriteLine($"Side: {oneOfTheForces.Trim()}, Members: {oneOfTheForcesCount}");
                foreach (var pair in sides.OrderBy(x => x.Key))
                {
                    if (pair.Value.Equals(oneOfTheForces))
                    {
                        Console.WriteLine($"!{pair.Key}");
                    }
                    else
                    {
                        theOtherOfTheForces = pair.Value;
                    }
                }
            }
            

        }

        private static bool IsBigger(string IsItbigger, string theOther)
        {
            bool result = true;
            for (int i = 0; i < Math.Min(IsItbigger.Length, theOther.Length); i++)
            {
                if (IsItbigger[i]<theOther[i])
                {
                    break;
                }
                else if(IsItbigger[i] == theOther[i])
                {
                    continue;
                }
                else
                {
                    return false;
                }
            }

            return result;
        }
    }
}