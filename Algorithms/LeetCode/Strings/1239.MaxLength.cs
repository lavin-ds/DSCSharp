/*
1239. Given an array of strings arr. String s is a concatenation of a sub-sequence of arr which have unique characters.

Return the maximum possible length of s.

 

Example 1:

Input: arr = ["un","iq","ue"]
Output: 4
Explanation: All possible concatenations are "","un","iq","ue","uniq" and "ique".
Maximum length is 4.

Example 2:

Input: arr = ["cha","r","act","ers"]
Output: 6
Explanation: Possible solutions are "chaers" and "acters".

Example 3:

Input: arr = ["abcdefghijklmnopqrstuvwxyz"]
Output: 26

 

Constraints:

    1 <= arr.length <= 16
    1 <= arr[i].length <= 26
    arr[i] contains only lower case English letters.
 */

using System.Collections.Generic;
using Xunit;
using System;
using System.Linq;

namespace Algorithms.LeetCode.Strings
{
    public class MaxLength 
    {
        public int FindMaxLength(IList<string> arr) 
        {
            return 0;
        }

        [Fact]
        public void TestWrapper()
        {
            
        }

    }
}
