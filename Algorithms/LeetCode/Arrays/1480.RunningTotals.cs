/*
1480. Running Sum of 1d Array
https://leetcode.com/problems/running-sum-of-1d-array/
Easy

Given an array nums. We define a running sum of an array as runningSum[i] = sum(nums[0]…nums[i]).

Return the running sum of nums.

Example 1:

Input: nums = [1,2,3,4]
Output: [1,3,6,10]
Explanation: Running sum is obtained as follows: [1, 1+2, 1+2+3, 1+2+3+4].

Example 2:

Input: nums = [1,1,1,1,1]
Output: [1,2,3,4,5]
Explanation: Running sum is obtained as follows: [1, 1+1, 1+1+1, 1+1+1+1, 1+1+1+1+1].

Example 3:

Input: nums = [3,1,2,10,1]
Output: [3,4,6,16,17]

Constraints:

    1 <= nums.length <= 1000
    -10^6 <= nums[i] <= 10^6
 */

using Xunit;
using System;
namespace Algorithms.LeetCode.Arrays
{
    public class RunningTotals 
    {
        public int[] RunningSum(int[] nums) 
        {
            int runTot = 0;
            for(int i =0; i< nums.Length;i++)
            {
                nums[i] = runTot+nums[i];
                runTot = nums[i];
            }
            return nums;
        }

        public int[] RunningSum2(int[] nums) 
        {
            //Index starts at 1 as we start with [i-1]
            for(int i =1; i< nums.Length;i++)
            {
                nums[i] = nums[i]+ nums[i-1];
            }
            return nums;
        }

        [Fact]
        public void TestWrapper1()
        {
            int[] arr1 = {1,2,3,4};
            var result = RunningSum(arr1);
            Assert.Equal(new int[]{1,3,6,10}, result);

            int[] arr2 = {1,1,1,1,1};
            result = RunningSum(arr2);
            Assert.Equal(new int[]{1,2,3,4,5}, result);

            int[] arr3 = {3,1,2,10,1};
            result = RunningSum(arr3);
            Assert.Equal(new int[]{3,4,6,16,17}, result);
        }
          
    }
}
