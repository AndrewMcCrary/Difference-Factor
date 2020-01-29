using System;
using System.Collections.Generic;
using System.Linq;


namespace Difference_Factor
{
    public class Difference_Factor
    {
        public static int ADFRecursively(string str1, string str2, ref int ADF, bool prepped = false)
        {
            // prep strings, replaces numbers and spaces with string.empty, and converts to upper
            if (!prepped)
            {
                str1 = new string(str1.Where(x => char.IsLetter(x)).ToArray()).ToUpper();
                str2 = new string(str2.Where(x => char.IsLetter(x)).ToArray()).ToUpper();
            }

            string longest = FindLongestSubstring(str1, str2); // if null, there are no more substrings present
            if (longest is null || longest == string.Empty)
                return ADF;
            
            
            ADF += longest.Length;


            // Splits strings

            // First string
            string a1 = str1.Substring(0, str1.IndexOf(longest));
            string a2 = string.Empty;
            if (a1.Length + longest.Length < str1.Length) //checks for empty back half
                a2 = str1.Substring(str1.IndexOf(longest) + longest.Length, str1.Length - a1.Length - longest.Length);

            // Second string
            string b1 = str2.Substring(0, str2.IndexOf(longest));
            string b2 = string.Empty;
            if (b1.Length + longest.Length < str2.Length) //checks for empty back half
                b2 = str2.Substring(str2.IndexOf(longest) + longest.Length, str2.Length - b1.Length - longest.Length);

            ADFRecursively(a2, b2, ref ADF, true); // Back half of both strings
            ADFRecursively(a1, b1, ref ADF, true); // Front half of both strings

            return ADF;

        }


        public static string FindLongestSubstring(string str1, string str2) // Absolutely terrible but it works
        {
            if (str1 == str2)
                return str1;
            if (str1 == string.Empty || str2 == string.Empty || str1 is null || str2 is null)
                return null;

            List<string> substrings = new List<string>();

            for (int i = 0; i < str1.Length; i++)
            {
                for (int j = 0; j < str2.Length; j++)
                {
                    if (str1[i] == str2[j])
                    {
                        int initI = i;
                        int initJ = j;
                        string ss = string.Empty;
                        do
                        {
                            ss += str1[i].ToString();
                            i++;
                            j++;
                            if (i >= str1.Length || j >= str2.Length)
                                break;
                            
                        } while (str1[i] == str2[j]);
                        i = initI;
                        j = initJ;
                        substrings.Add(ss); // GC will get ss, initI, initJ
                    }
                }
            }
            if (substrings.Count == 0)
                return null;

            //foreach (var i in substrings)
            //    Console.WriteLine(i);

            //substrings = substrings.OrderBy(x => x.Length).Reverse().Where(x => x.Length == substrings[0].Length).OrderBy(x => x).ToList();
            substrings = substrings.OrderBy(x => x.Length).Reverse().ToList();
            substrings.RemoveAll(x => x.Length < substrings[0].Length);
            substrings.Sort();

            return substrings.First();
        }
    }
}
