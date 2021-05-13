/*
53. Maximum Subarray
https://leetcode.com/problems/maximum-subarray/
Easy

Given an integer array nums, find the contiguous subarray (containing at least one number) which has the largest sum and return its sum.

Example 1:

Input: nums = [-2,1,-3,4,-1,2,1,-5,4]
Output: 6
Explanation: [4,-1,2,1] has the largest sum = 6.

Example 2:

Input: nums = [1]
Output: 1

Example 3:

Input: nums = [5,4,-1,7,8]
Output: 23

Constraints:

    1 <= nums.length <= 3 * 104
    -105 <= nums[i] <= 105

*/

using System;
using Xunit;

namespace Algorithms.LeetCode.SlidingWindow
{
    public class MaximumSubArraySP
    {
        public int MaxSubArray(int[] nums) 
        {
            int result = nums[0];            
            int r = 1;
            int runningTotal = nums[0];
            while(r<nums.Length)
            {
                if(runningTotal<0)
                {
                    runningTotal = nums[r];
                }
                else
                {
                    runningTotal += nums[r];
                }
                                
                result = Math.Max(result,runningTotal);
                r++;                
            }

            return result;
        }
    }
}

