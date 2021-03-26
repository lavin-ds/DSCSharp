/*
Write a function that, given an array A of N integers, returns the lagest integer K > 0 
such that both values K and -K exist in array A. 

If there is no such integer, the function should return 0.
 */

using System.Collections.Generic;
using Xunit;
using System.Linq;

namespace Algorithms.LeetCode.Strings
{
    public class LargestK {

        public int FindLargestK(int[] s) {
            Dictionary<int, int> frequencies = new Dictionary<int, int>();
            s = s.OrderByDescending(x=>x).ToArray();
            for(int i = 0; i<s.Length; i++)
            {
                if(s[i]<0){
                    s[i] = -s[i];
                }
                if(frequencies.ContainsKey(s[i]))
                {
                    frequencies[s[i]]++;
                }
                else
                {
                    frequencies.Add(s[i],1);
                }
            }
            
            return frequencies.Where(x=>x.Value==2).FirstOrDefault().Key;

        }

        //TODO: Write a test wrapper for the method
        [Fact]
        public void TestWrap()
        {
            int[] arr = {1, -1, 4, 5};
            var result = FindLargestK(arr);
            Assert.Equal(1,result);

            int[] arr2 = {4, -4, 23, 5, 44, 501,2,-23};
            result = FindLargestK(arr2);
            Assert.Equal(23,result);

            int[] arr3 = {4, -2, 23, 5, 44, 501,6};
            result = FindLargestK(arr3);
            Assert.Equal(0,result);
        }
    }
}
