/*
643. Maximum Average Subarray I
https://leetcode.com/problems/maximum-average-subarray-i/
Easy

You are given an integer array nums consisting of n elements, and an integer k.

Find a contiguous subarray whose length is equal to k that has the maximum average value and return this value. Any answer with a calculation error less than 10-5 will be accepted.

Example 1:

Input: nums = [1,12,-5,-6,50,3], k = 4
Output: 12.75000
Explanation: Maximum average is (12 - 5 - 6 + 50) / 4 = 51 / 4 = 12.75

Example 2:

Input: nums = [5], k = 1
Output: 5.00000

Constraints:

    n == nums.length
    1 <= k <= n <= 105
    -104 <= nums[i] <= 104
*/

using System;
using Xunit;

namespace Algorithms.LeetCode.SlidingWindow
{
    public class MaxAvgSubArray
    {
        public double FindMaxAverage(int[] nums, int k) 
        {
            double dk = (double)k;
            int maxVal = Int32.MinValue;
            int runningTotals = 0;
            int l = 0;
            
            for(int i = 0; i<nums.Length; i++)
            {
                runningTotals += nums[i];
                
                if(i>=k-1)
                {
                    maxVal = Math.Max(maxVal,runningTotals);
                    runningTotals -= nums[l] ;
                    l++;
                }
            }
            
            return maxVal/dk;
        }

        [Fact]
        public void TestWrap()
        {
            var arr1 = new int[]{1,12,-5,-6,50,3};
            var k = 4;
            var result = FindMaxAverage(arr1,k);
            Assert.Equal(12.75000,result);

            var arr2 = new int[]{5};
            k = 1;
            result = FindMaxAverage(arr2, k);
            Assert.Equal(5.00000,result);
        } 
    }
}

