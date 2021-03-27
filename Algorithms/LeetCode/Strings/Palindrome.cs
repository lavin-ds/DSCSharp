/*
Given a string, what is the minimum number of adjacent swaps required to convert a string into a palindrome. If not possible, return -1.

Example 1: Input: “mamad” Output: 3

Example 2: Input: “asflkj” Output: -1

Example 3: Input: “aabb” Output: 2

Example 4: Input: “ntiin” Output: 1

Explanation: swap ‘t’ with ‘i’ => “nitin”
 */

using Xunit;

namespace Algorithms.LeetCode.Strings
{
    public class Palindrome 
    {
        private int totalSwaps = 0;

        public int FindMinimumSwapsToMakePalindrome(string s) 
        {
            totalSwaps = 0;
            if(s == null || s.Length == 0 || !CheckIfPalindrome(s))
                return -1;

            if( s.Length ==1 || s.Length ==2)
                return 0;

            char[] ip = s.ToCharArray();                        

            int localSwap = 0;
            for (int i = 0; i < ip.Length / 2 ; i++) 
            {    
                int left = i;
                int right = s.Length-i-1;

                while (ip[left]!=ip[right])
                {                  
                    right--;
                    localSwap++;
                } 

                if(left == right)
                {
                    localSwap = s.Length/2-left;
                    while(localSwap>0)
                    {
                        SwapVal(ip, left, left+1);
                        localSwap--;                                       
                        left++;                       
                    }
                    i--;
                    continue;
                }
                
                while(localSwap>0)
                {
                    SwapVal(ip, right, right+1);
                    localSwap--;                                       
                    right++; 
                }
            }
    
            return totalSwaps;
        }

        public void SwapVal (char[] chars, int i, int j)
        {
            var temp = chars[i];
            chars[i] = chars[j];
            chars[j] = temp;
            totalSwaps++;
        }

        public bool CheckIfPalindrome(string s)
        {
            int[] count = new int [26] ;
            int oddCount = 0;
            for(int i =0;i<s.Length;i++)
            {
                count[s[i] - 'a']++;
            }

            for(int i = 0; i<26;i++)
            {
                if(count[i]%2 != 0 )
                    oddCount++;
            }   
            return (oddCount<=1);
        }

        [Fact]
        public void TestWrap()
        {
            string s = "aabcc";
            var result = FindMinimumSwapsToMakePalindrome(s);
            Assert.Equal(4,result);

            s = "aacc";
            result = FindMinimumSwapsToMakePalindrome(s);
            Assert.Equal(2,result);

            s = "abcc";
            result = FindMinimumSwapsToMakePalindrome(s);
            Assert.Equal(-1,result);

            s = "aeffgcgca";
            result = FindMinimumSwapsToMakePalindrome(s);
            Assert.Equal(10,result);

            s = "mamad";
            result = FindMinimumSwapsToMakePalindrome(s);
            Assert.Equal(3,result);

            s = "asflkj";
            result = FindMinimumSwapsToMakePalindrome(s);
            Assert.Equal(-1,result);

            s = "ntiin";
            result = FindMinimumSwapsToMakePalindrome(s);
            Assert.Equal(1,result);
        }
    }
}
