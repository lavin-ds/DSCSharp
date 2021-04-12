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
 
using System.Text;
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
           
        public string LongestPalindromeOptimizedN2(string sMod) 
        { 
            StringBuilder stag = new StringBuilder("+");
            foreach(var c in sMod)
            {
                stag.Append(c+"+");
            }
            var s = stag.ToString();
            var _longestPalindrome = string.Empty;
            char[] ca = s.ToLower().ToCharArray();
            int i = 0, j=0,k=1;

            while(i<s.Length)
            {
                while(j>-1 && j+k<=s.Length)
                {
                    var loc = s.Substring(j,k);
                    if(loc[0] == loc[loc.Length-1])
                    {
                        if(_longestPalindrome.Length<loc.Length)
                        {
                            _longestPalindrome = loc;
                        }
                    }
                    else
                    {                             
                        break;
                    }                    
                    j--;
                    k=k+2;   
                }                
                i++;
                j = i;
                k = 1;
            }
            return _longestPalindrome.Replace("+", "");
        }   

        [Fact]
        public void TestWrap1()
        {
            string s = "babad";       
            Assert.Equal("bab", LongestPalindromeOptimizedN2(s));

            s = "aabcc";          
            Assert.Equal("aa", LongestPalindromeOptimizedN2(s));

            s = "aacc";
            Assert.Equal("aa", LongestPalindromeOptimizedN2(s));

            s = "abcc";
            Assert.Equal("cc", LongestPalindromeOptimizedN2(s));

            s = "aeffgcgca";
            Assert.Equal("gcg", LongestPalindromeOptimizedN2(s));

            s = "mamad";
            Assert.Equal("mam", LongestPalindromeOptimizedN2(s));

            s = "asflkj";
            Assert.Equal("a", LongestPalindromeOptimizedN2(s));

            s = "nitin";
            Assert.Equal("nitin", LongestPalindromeOptimizedN2(s));
            
            s = "amanaplanacanalpanama";
            Assert.Equal("amanaplanacanalpanama", LongestPalindromeOptimizedN2(s));

            s = "raceacar"; 
            Assert.Equal("aca", LongestPalindromeOptimizedN2(s));

            s = "0P";
            Assert.Equal("0", LongestPalindromeOptimizedN2(s));

            s = "abb";
            Assert.Equal("bb", LongestPalindromeOptimizedN2(s));

             s = "98";
            Assert.Equal("9",LongestPalindromeOptimizedN2(s));
        }

        [Fact]
        public void TestWrap2()
        {
            string s = "babad";       
            Assert.Equal("bab", LongestPalindrome(s));

            s = "aabcc";          
            Assert.Equal("aa", LongestPalindrome(s));

            s = "aacc";
            Assert.Equal("aa", LongestPalindrome(s));

            s = "abcc";
            Assert.Equal("cc", LongestPalindrome(s));

            s = "aeffgcgca";
            Assert.Equal("gcg", LongestPalindrome(s));

            s = "mamad";
            Assert.Equal("mam", LongestPalindrome(s));

            s = "asflkj";
            Assert.Equal("a", LongestPalindrome(s));

            s = "nitin";
            Assert.Equal("nitin", LongestPalindrome(s));

            s = "A man, a plan, a canal: Panama";
            Assert.Equal("A man, a plan, a canal: Panama", LongestPalindrome(s));

            s = "race a car"; 
            Assert.Equal(" a ca", LongestPalindrome(s));

            s = "0P";
            Assert.Equal("0", LongestPalindrome(s));

            s = "abb";
            Assert.Equal("bb", LongestPalindrome(s));

             s = "9,8";
            Assert.Equal("9,",LongestPalindrome(s));
        }


        [Fact]
        public void TestWrap3()
        {
            string s = "aabcc";            ;
            Assert.False(CheckPalindrome(s));

            s = "aacc";
            Assert.False(CheckPalindrome(s));

            s = "abcc";
            Assert.False(CheckPalindrome(s));

            s = "aeffgcgca";
            Assert.False(CheckPalindrome(s));

            s = "mamad";
            Assert.False(CheckPalindrome(s));

            s = "asflkj";
            Assert.False(CheckPalindrome(s));

            s = "nitin";
            Assert.True(CheckPalindrome(s));

            s = "A man, a plan, a canal: Panama";
            Assert.True(CheckPalindrome(s));

            s = "race a car";
            Assert.False(CheckPalindrome(s));

            s = "0P";
            Assert.False(CheckPalindrome(s));

            s = "abb";
            Assert.False(CheckPalindrome(s));

             s = "9,8";
            Assert.False(CheckPalindrome(s));
        }
    }
}
