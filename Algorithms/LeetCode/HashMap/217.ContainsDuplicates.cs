/*217. Contains Duplicate
https://leetcode.com/problems/contains-duplicate/
Easy

Given an integer array nums, return true if any value appears at 
least twice in the array, and return false if every element is distinct.

Example 1:

Input: nums = [1,2,3,1]
Output: true

Example 2:

Input: nums = [1,2,3,4]
Output: false

Example 3:

Input: nums = [1,1,1,3,3,4,3,2,4,2]
Output: true

Constraints:

    1 <= nums.length <= 105
    -109 <= nums[i] <= 109

*/

using System.Collections.Generic;
using Xunit;

public class Dups
{
    public bool ContainsDuplicate(int[] nums)
    {
        Dictionary<int, int> map = new Dictionary<int, int>();

        for (int i = 0; i < nums.Length; i++)
        {
            if (map.ContainsKey(nums[i]))
            {
                map[nums[i]]++;
            }
            else
            {
                map.Add(nums[i], 1);
            }
        }

        foreach (var kvp in map)
        {
            if (kvp.Value > 1)
            {
                return true;
            }
        }
        return false;
    }

     [Fact]
        public void TestWrap()  
        {
            int[] a = new int[]{2,7,2,15};
            Assert.Equal(true, ContainsDuplicate(a));
            
            int[] a1 = new int[]{3,2,4};
            Assert.Equal(false, ContainsDuplicate(a1));

            int[] a2 = new int[]{3,3};
            Assert.Equal(true, ContainsDuplicate(a2));
        }  
}

