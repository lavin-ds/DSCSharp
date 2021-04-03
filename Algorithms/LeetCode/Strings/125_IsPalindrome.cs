/*
Given a string s, determine if it is a palindrome, considering only alphanumeric characters and ignoring cases.

Example 1:

Input: s = "A man, a plan, a canal: Panama"
Output: true
Explanation: "amanaplanacanalpanama" is a palindrome.

Example 2:

Input: s = "race a car"
Output: false
Explanation: "raceacar" is not a palindrome.

Constraints:

    1 <= s.length <= 2 * 105
    s consists only of printable ASCII characters.

 */

using System.Text;
using Xunit;

namespace Algorithms.LeetCode.Strings
{
    public class IsPalindrome 
    {        
        public bool IsPalindromeOptimized(string s)
        {
            char[] ca= s.ToLower().ToCharArray();

            for (int i = 0, j=(ca.Length-1); i<j; i++,j--)
            {
                while(!char.IsLetterOrDigit(ca[i]) &&  j>i)
                {
                    i++;
                }

                while(!char.IsLetterOrDigit(ca[j]) &&  j>i)
                {
                    j--;
                }

                if(!ca[i].Equals(ca[j]))
                    return false;
            }

            return true;
        }

        private StringBuilder _cleanString;

        public bool CheckPalindrome(string s)
        {
            s= s.ToLower();
            _cleanString = new StringBuilder();
            if(CleanCheckIsNotPalindrome(s))
                return false;
            
            int left = 0;
            s = _cleanString.ToString();
            int right = _cleanString.Length - left - 1;
            while(right>left)
            {
                if(left == right)
                {
                    return true;
                }

                if(s[left] != s[right])
                    return false;
                
                left++;
                right--;
            }
            return true;
        }       

        public bool CleanCheckIsNotPalindrome(string s)
        {
                  
            int[] countChar = new int [26] ;
            int[] countInt = new int [10] ;
            int oddCount = 0;
            for(int i =0;i<s.Length;i++)
            {
                if(s[i]>='a' && s[i]<= 'z')
                    {
                        _cleanString.Append(s[i]);
                        countChar[s[i] - 'a']++;
                    }

                if(s[i] >='0' && s[i]<= '9')
                    {
                        _cleanString.Append(s[i]);
                        countInt[s[i] - '0']++;
                    }
            }

            for(int i = 0; i<26;i++)
            {
                if(countChar[i]%2 != 0 )
                    oddCount++;
            }   
             for(int i = 0; i<9;i++)
            {
                if(countInt[i]%2 != 0 )
                    oddCount++;
            }               
            return (oddCount>1);
        }
     
        [Fact]
        public void TestWrap()
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
            Assert.False(!CheckPalindrome(s));

            s = "A man, a plan, a canal: Panama";
            Assert.False(!CheckPalindrome(s));

            s = "race a car";
            Assert.False(CheckPalindrome(s));

            s = "0P";
            Assert.False(CheckPalindrome(s));

            s = "abb";
            Assert.False(CheckPalindrome(s));

             s = "9,8";
            Assert.False(CheckPalindrome(s));
        }

        [Fact]
        public void TestWrap1()
        {
            string s = "aabcc";            ;
            Assert.False(IsPalindromeOptimized(s));

            s = "aacc";
            Assert.False(IsPalindromeOptimized(s));

            s = "abcc";
            Assert.False(IsPalindromeOptimized(s));

            s = "aeffgcgca";
            Assert.False(IsPalindromeOptimized(s));

            s = "mamad";
            Assert.False(IsPalindromeOptimized(s));

            s = "asflkj";
            Assert.False(IsPalindromeOptimized(s));

            s = "nitin";
            Assert.False(!IsPalindromeOptimized(s));

            s = "A man, a plan, a canal: Panama";
            Assert.False(!IsPalindromeOptimized(s));

            s = "race a car";
            Assert.False(IsPalindromeOptimized(s));

            s = "0P";
            Assert.False(IsPalindromeOptimized(s));

            s = "abb";
            Assert.False(IsPalindromeOptimized(s));

             s = "9,8";
            Assert.False(IsPalindromeOptimized(s));
        }
    }
}
