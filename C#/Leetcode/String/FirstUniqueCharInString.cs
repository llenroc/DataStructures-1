﻿using System;

namespace LeetcodeSolutions.String
{
    // Leetcode 387 - https://leetcode.com/problems/first-unique-character-in-a-string/
    // Submission Detail - https://leetcode.com/submissions/detail/136150730/
    // Frequencies Technique

    public class FirstUniqueCharInString
    {
        //static void Main(string[] args)
        //{
        //    FirstUniqueCharInString uniqChar = new FirstUniqueCharInString();
        //    Console.WriteLine($"expected:0\tactual:{uniqChar.FirstUniqChar("leetcode")}");
        //    Console.WriteLine($"expected:2\tactual:{uniqChar.FirstUniqChar("eetcode")}");
        //    Console.WriteLine($"expected:2\tactual:{uniqChar.FirstUniqChar("loveleetcode")}");
        //    Console.WriteLine($"expected:-1\tactual:{uniqChar.FirstUniqChar("baba")}");
        //    Console.WriteLine($"expected:-1\tactual:{uniqChar.FirstUniqChar("")}");
        //    Console.WriteLine($"expected:0\tactual:{uniqChar.FirstUniqChar("c")}");
        //    Console.WriteLine($"expected:8\tactual:{uniqChar.FirstUniqChar("dddccdbba")}");

        //    Console.ReadKey();
        //}

        //Runtime : 136 ms
        //Tx = O(n)
        //Sx = O(1)
        public int FirstUniqCharReadable(string s)
        {
            int[] freq = new int[26];

            // Calculate the frequencies of the all the characters.
            for (int i = 0; i < s.Length; i++)
                freq[s[i] - 'a']++;

            // Check if the current charcter has frequency 1. Then return the index.
            for (int i = 0; i < s.Length; i++)
                if (freq[s[i] - 'a'] == 1)
                    return i;

            return -1;
        }

        // Runtime : 135 ms
        // Tx = O(n) { n : length of the string }
        // Sx = O(1) { Actually O(128) }
        public int FirstUniqChar(string s)
        {
            int[] uniqueCharIndices = new int[128];
            int length = s.Length;

            if (length == 1)
                return 0;
            else if (length == 0)
                return -1;

            for (int index = 0; index < length; index++)
            {
                int currentCharValue = s[index];
                int currentUniqueCharIndexValue = uniqueCharIndices[currentCharValue];

                if (currentUniqueCharIndexValue == 0)
                {
                    uniqueCharIndices[currentCharValue] = length - index;
                }
                else if (currentUniqueCharIndexValue <= length)
                {
                    uniqueCharIndices[currentCharValue] = length + 1;
                }
            }

            int minIndex = 0;
            for (int index = 0; index < uniqueCharIndices.Length; index++)
            {
                if (uniqueCharIndices[index] <= length && uniqueCharIndices[index] > minIndex)
                {
                    minIndex = uniqueCharIndices[index];
                }
            }
            
            return minIndex != 0 ? length - minIndex : -1;
        }
    }
}
