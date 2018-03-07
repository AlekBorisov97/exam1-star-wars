using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Problem04
{
    class Program
    {
        static void Main(string[] args)
        {
            string oneOfTheForces = string.Empty, theOtherOfTheForces = string.Empty;
            Dictionary<string, string> jediData = new Dictionary<string, string>();
            string line;
            int countWhile = 0;
            while ((line = Console.ReadLine()) != "Lumpawaroo")
            {

                string[] elements = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

                string divider = string.Empty;
                string theForce = string.Empty;
                string nameJedi = string.Empty;
                if (elements.Length > 3)
                {//-> divider
                    if (elements.Contains("->"))
                    {
                        divider = elements[elements.Length - 2];
                        theForce = elements[elements.Length - 1];
                        oneOfTheForces = theForce;
                        nameJedi = string.Empty;
                        for (int i = 0; i < elements.Length - 2; i++)
                        {
                            if (i == elements.Length - 3)
                            {
                                nameJedi = nameJedi + elements[i];
                            }
                            else
                            {
                                nameJedi = nameJedi + elements[i] + " ";
                            }
                        }
                    }
                    else
                    {
                        divider = elements[1];
                        theForce = elements[0];
                        for (int i = 2; i < elements.Length; i++)
                        {
                            if (i == elements.Length - 1)
                                nameJedi = nameJedi + elements[i];
                            else
                                nameJedi = nameJedi + elements[i] + " ";
                        }

                    }
                    if (!jediData.ContainsKey(nameJedi))
                    {
                        if (divider.Equals("->"))
                        {
                            Console.WriteLine($"{nameJedi} joins the {theForce} side!");
                        }

                        jediData.Add(nameJedi, theForce);
                    }
                    else
                    {
                        if (divider.Equals("->"))
                        {
                            Console.WriteLine($"{nameJedi} joins the {theForce} side!");
                            jediData[nameJedi] = theForce;
                        }

                    }
                }
                else
                {
                    divider = elements[elements.Length - 2];
                    if (divider.Equals("|"))
                    {
                        theForce = elements[0];
                        oneOfTheForces = theForce;
                        nameJedi = elements[2];
                        if (!jediData.ContainsKey(nameJedi))
                        {
                            jediData.Add(nameJedi, theForce);
                        }
                    }
                    else if (divider.Equals("->"))
                    {
                        theForce = elements[2];
                        oneOfTheForces = theForce;
                        nameJedi = elements[0];

                        if (!jediData.ContainsKey(nameJedi))
                        {
                            jediData.Add(nameJedi, theForce);
                            Console.WriteLine($"{nameJedi} joins the {theForce} side!");
                        }
                        else
                        {
                            Console.WriteLine($"{nameJedi} joins the {theForce} side!");
                            jediData[nameJedi] = theForce;
                        }
                    }
                }


                countWhile++;
            }

            if (countWhile != 0)
            {




                //count//one of the forces initialized
                int oneOfTheForcesCount = 0, theOtherOfTheForcesCount = 0;
                foreach (var pair in jediData)
                {
                    if (pair.Value.Equals(oneOfTheForces))
                    {
                        oneOfTheForcesCount++;
                    }
                    else
                    {
                        theOtherOfTheForcesCount++;
                        theOtherOfTheForces = pair.Value;
                    }
                }








                if (oneOfTheForcesCount == 0)
                {
                    Console.WriteLine($"Side: {theOtherOfTheForces.Trim()}, Members: {theOtherOfTheForcesCount}");
                    foreach (var pair in jediData.OrderBy(x => x.Key))
                    {
                        if (!pair.Value.Equals(oneOfTheForces))
                        {
                            Console.WriteLine($"! {pair.Key.Trim()}");
                        }
                    }
                }
                else if (theOtherOfTheForcesCount == 0)
                {
                    Console.WriteLine($"Side: {oneOfTheForces.Trim()}, Members: {oneOfTheForcesCount}");
                    foreach (var pair in jediData.OrderBy(x => x.Key))
                    {
                        if (pair.Value.Equals(oneOfTheForces))
                        {
                            Console.WriteLine($"! {pair.Key.Trim()}");
                        }
                        else
                        {
                            theOtherOfTheForces = pair.Value;
                        }
                    }
                }
                else if ((oneOfTheForcesCount > theOtherOfTheForcesCount) || ((oneOfTheForcesCount == theOtherOfTheForcesCount)) && IsBigger(oneOfTheForces, theOtherOfTheForces))
                {
                    Console.WriteLine($"Side: {oneOfTheForces.Trim()}, Members: {oneOfTheForcesCount}");
                    foreach (var pair in jediData.OrderBy(x => x.Key))
                    {
                        if (pair.Value.Equals(oneOfTheForces))
                        {
                            Console.WriteLine($"! {pair.Key.Trim()}");
                        }
                        else
                        {
                            theOtherOfTheForces = pair.Value;
                        }
                    }
                    Console.WriteLine($"Side: {theOtherOfTheForces.Trim()}, Members: {theOtherOfTheForcesCount}");
                    foreach (var pair in jediData.OrderBy(x => x.Key))
                    {
                        if (!pair.Value.Equals(oneOfTheForces))
                        {
                            Console.WriteLine($"! {pair.Key.Trim()}");
                        }
                    }
                }
                else if ((oneOfTheForcesCount < theOtherOfTheForcesCount) || ((oneOfTheForcesCount == theOtherOfTheForcesCount)) && IsBigger(theOtherOfTheForces, oneOfTheForces))
                {
                    Console.WriteLine($"Side: {theOtherOfTheForces.Trim()}, Members: {theOtherOfTheForcesCount}");
                    foreach (var pair in jediData.OrderBy(x => x.Key))
                    {
                        if (!pair.Value.Equals(oneOfTheForces))
                        {
                            Console.WriteLine($"! {pair.Key.Trim()}");
                        }
                    }
                    Console.WriteLine($"Side: {oneOfTheForces.Trim()}, Members: {oneOfTheForcesCount}");
                    foreach (var pair in jediData.OrderBy(x => x.Key))
                    {
                        if (pair.Value.Equals(oneOfTheForces))
                        {
                            Console.WriteLine($"! {pair.Key.Trim()}");
                        }
                        else
                        {
                            theOtherOfTheForces = pair.Value;
                        }
                    }
                }





















            }


        }


        private static bool IsBigger(string IsItbigger, string theOther)
        {
            bool result = true;
            for (int i = 0; i < Math.Min(IsItbigger.Length, theOther.Length); i++)
            {
                if (IsItbigger[i] < theOther[i])
                {
                    break;
                }
                else if (IsItbigger[i] == theOther[i])
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