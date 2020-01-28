using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Difference_Factor
{
    public class Difference_Factor
    {
        const string ALPHA = "abcdefghijklmnopqrstuvwxyz";
        const string ALPHA_UPPER = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        const string NUMERICS = "0123456789";
        const char SPACE = ' ';

        /// <summary>
        /// Returns the starting index and length of the substrings
        /// </summary>
        /// <param name="str"></param>
        /// <returns>First int type is the index of substring, second int type is the length</returns>
        public static Tuple<int, int> FindNextLargestSubstrings(string str)
        {
            // Rotate through string left to right, searching for the same character
            // Every substring must begin with the same character, and be the same length
            // Need inner loop to start from right side to eliminate case "xxxxxxxxxxxxxxxxxxx"

            if (str.Length <= 0)
                throw new ArgumentOutOfRangeException();
            


            for (int i = 0; i < str.Length; i++)
            {
                // First loop rotates through string establishing base character

                for (int j = str.Length - 1; j > i; j--) 
                {
                    // Second loop gives character to compare to first
                        Console.WriteLine(str[i] + " : " + str[j]);
                    
                }
            }

            return new Tuple<int, int>(0, 0);
        }
    }
}
