using System.Reflection;
using System.Linq;
/*
A string s is called good if there are no two different characters in s that have the same frequency.

Given a string s, return the minimum number of characters you need to delete to make s good.

The frequency of a character in a string is the number of times it appears in the string. For example, in the string "aab", the frequency of 'a' is 2, while the frequency of 'b' is 1.

 

Example 1:

Input: s = "aab"
Output: 0
Explanation: s is already good.

Example 2:

Input: s = "aaabbbcc"
Output: 2
Explanation: You can delete two 'b's resulting in the good string "aaabcc".
Another way it to delete one 'b' and one 'c' resulting in the good string "aaabbc".

Example 3:

Input: s = "ceabaacb"
Output: 2
Explanation: You can delete both 'c's resulting in the good string "eabaab".
Note that we only care about characters that are still in the string at the end (i.e. frequency of 0 is ignored).

Constraints:

    1 <= s.length <= 105
    s contains only lowercase English letters.


 */

using System.Collections.Generic;
using Xunit;
using System;

public class MinDeletions {
    public int FindMinDeletionsOptimized(string s)
    {
        int[] count = new int[26];
        int deletions = 0;
        
        HashSet<int> freqSeen = new HashSet<int>();
         
        for(int i = 0; i<s.Length;i++)
        {
            count[s[i] - 'a']++;
        }
        
        for(int i =0; i<26;i++)
        {
            int currFreq = count[i];
            while(currFreq >0 && !freqSeen.Add(currFreq))
            {
                currFreq--;
                deletions++;
            }
        }
        
        return deletions;
    }

    public int FindMinDeletions(string s) {
        int curFreq = Int32.MaxValue;
        Dictionary<char, int> frequencies= new Dictionary<char, int>();
        int deletions = 0;
        for(int i = 0; i<s.Length; i++)
        {
            if(frequencies.ContainsKey(s[i]))
            {
                frequencies[s[i]]++;
            }
            else
            {
                frequencies.Add(s[i],1);
            }
        }
        
        var sortedValues = frequencies.Values.OrderByDescending(x=>x).ToList();
        
        for(int i =0;i<= sortedValues.Count()-1;i++)
        {
            if(sortedValues[i] >= curFreq)
            {
                if(curFreq == 0)
                {
                    deletions += sortedValues[i];
                }
                else
                {
                    deletions += sortedValues[i]-curFreq +1;    
                    curFreq--;
                }                
            }
            else
            {
                curFreq = sortedValues[i];
            }
        }
        return deletions;
    }

    [Fact]
    public void TestWrapper()
    {
        var s = "aab";
        var deletions = FindMinDeletions(s);

        Assert.Equal(0,deletions);

        
        s = "aabbcc";
        deletions = FindMinDeletions(s);

        Assert.Equal(3,deletions);

        s = "aaabbbcc";
        deletions = FindMinDeletions(s);

        Assert.Equal(2,deletions);
        
        s = "ceabaacb";
        deletions = FindMinDeletions(s);

        Assert.Equal(2,deletions);
    }

[Fact]
    public void TestWrapper2()
    {
        var s = "aab";
        var deletions = FindMinDeletionsOptimized(s);

        Assert.Equal(0,deletions);

        
        s = "aabbcc";
        deletions = FindMinDeletionsOptimized(s);

        Assert.Equal(3,deletions);

        s = "aaabbbcc";
        deletions = FindMinDeletionsOptimized(s);

        Assert.Equal(2,deletions);
        
        s = "ceabaacb";
        deletions = FindMinDeletionsOptimized(s);

        Assert.Equal(2,deletions);
    }

}

