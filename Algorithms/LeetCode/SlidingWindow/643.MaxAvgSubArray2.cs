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
    public class MaxAvgSubArray2
    {
        public double FindMaxAverage(int[] nums, int k) 
        {
            double dk = (double)k;
            int maxVal = Int32.MinValue;
            int runningTotals = 0;
            
            //First run the for loop upto k values
            for(int i = 0; i<k; i++)
            {
                runningTotals += nums[i];
            }
            //Assign the total uptil now as the maxVal
            maxVal = runningTotals;

            //Now perform the sliding window on the remaining values, 
            //this allows us to not run if conditions for every pass 
            for(int i = k; i<nums.Length;i++)
            {
                runningTotals += nums[i] - nums[i-k];
                maxVal = Math.Max(maxVal,runningTotals);
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

