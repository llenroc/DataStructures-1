﻿using System;

namespace LeetcodeSolutions.Array
{
    // Leetcode 300 - https://leetcode.com/problems/longest-increasing-subsequence/
    // Submission - https://leetcode.com/submissions/detail/174288021/
    // Reference - Explanation: https://www.youtube.com/watch?v=CE2b_-XfVDk
    //           - Code : https://github.com/mission-peace/interview/blob/master/src/com/interview/dynamic/LongestIncreasingSubsequence.java
    // Bottom-Up Dynamic Programming

    public class LongestIncreasingSubsequence
    {
        //public static void Main(string[] args)
        //{
        //    LongestIncreasingSubsequence LIS = new LongestIncreasingSubsequence();

        //    int[] arr1 = { 3, 4, -1, 0, 6, 2, 3 }; // 4
        //    Console.WriteLine(LIS.LengthOfLIS(arr1));

        //    int[] arr2 = { 3, 4, 5, 6, 7, 8, 9 }; // 7
        //    Console.WriteLine(LIS.LengthOfLIS(arr2));

        //    int[] arr3 = { 1, 3, -1, 0, 2, -2 }; // 4
        //    Console.WriteLine(LIS.LengthOfLIS(arr3));

        //    int[] arr4 = { 6, 5, 4 }; // 1
        //    Console.WriteLine(LIS.LengthOfLIS(arr4));

        //    int[] arr5 = { }; // 0
        //    Console.WriteLine(LIS.LengthOfLIS(arr5));

        //    Console.ReadKey();
        //}

        // TODO: There is a O(nlogn) solution.
        // Tx = O(n^2)
        // Sx = O(n)
        public int LengthOfLIS(int[] nums)
        {
            int length = nums.Length, maxLIS = 0;

            int[] LIS = new int[length];

            if (length != 0)
            {
                LIS[0] = 1;
                maxLIS = 1;
            }

            for (int i = 1; i < length; i++)
            {
                LIS[i] = 1; // Each number has a sequence of 1.

                for (int j = 0; j < i; j++)
                {
                    if (nums[j] < nums[i])
                    {
                        // Max of the previously computed LIS of J and current number LIS.
                        LIS[i] = System.Math.Max(LIS[i], LIS[j] + 1);
                        maxLIS = System.Math.Max(maxLIS, LIS[i]);
                    }
                }
            }

            return maxLIS;
        }
    }
}
