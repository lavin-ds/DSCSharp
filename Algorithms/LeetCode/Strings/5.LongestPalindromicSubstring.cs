using System.Text;
/*
5. Longest Palindromic Substring
https://leetcode.com/problems/longest-palindromic-substring/
Medium

Given a string s, return the longest palindromic substring in s.

Example 1:

Input: s = "babad"
Output: "bab"
Note: "aba" is also a valid answer.

Example 2:

Input: s = "cbbd"
Output: "bb"

Example 3:

Input: s = "a"
Output: "a"

Example 4:

Input: s = "ac"
Output: "a"

Constraints:

    1 <= s.length <= 1000
    s consist of only digits and English letters (lower-case and/or upper-case)
 */

using Xunit;

namespace Algorithms.LeetCode.Strings
{
    public class LongestPalindromicSubstring 
    {
        private string _longestPalindrome;
        
        public string LongestPalindrome(string s) 
        {
            _longestPalindrome = string.Empty;
            char[] ca = s.ToLower().ToCharArray();
            int i = 0, j=0,k=0;

            while(i<s.Length)
            {
                while(j>-1 && k<s.Length)
                {
                    var loc = s.Substring(j,k+1);
                    if(CheckPalindrome(loc))
                    {
                        if(_longestPalindrome.Length<loc.Length)
                        {
                            _longestPalindrome = loc;
                        }
                    }
                    j--;
                    k++;   
                }                
                i++;
                j = i;
                k = 0;
            }
            return _longestPalindrome;
        }

        public bool CheckPalindrome(string s)
        {
            char[] staging = s.ToLower().ToCharArray();
            for(int i = 0, j = (staging.Length-1); i<j;i++,j--)
            {
                while(!char.IsLetterOrDigit(staging[i]) && i<j)
                    i++;

                while(!char.IsLetterOrDigit(staging[j]) && i<j)
                    j--;
                    
                if(!staging[i].Equals(staging[j]))
                    return false;
            }
            return true;
        }
    }
}
