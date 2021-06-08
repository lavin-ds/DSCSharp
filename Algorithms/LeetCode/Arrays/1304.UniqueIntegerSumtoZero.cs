/*
Given an integer n, return any array containing n unique integers such that they add up to 0.
Example 1:

Input: n = 5
Output: [-7,-1,1,3,4]
Explanation: These arrays also are accepted [-5,-1,1,2,3] , [-3,-1,2,-2,4].

Example 2:

Input: n = 3
Output: [-1,0,1]

Example 3:

Input: n = 1
Output: [0]

 

Constraints:

    1 <= n <= 1000
 */

using Xunit;

namespace Algorithms.LeetCode.Arrays
{
    public class ZeroSum 
    {

        public int[] SumZero2(int n)
        {
            int[] arr = new int[n];

            int arrIndx = 0;
            for(int i=1; i<=n/2 ; i = ++i)
            {
                arr[arrIndx++] = i;
                arr[arrIndx++] = -i;                
            }

            if(n%2 !=0)
            {
                arr[arrIndx] = 0;
            }

            return arr;
        }

        public int[] SumZero(int n) 
        {
            int[] arr = new int[n];
            if(n == 1)
            {
                arr[0] = 0;
                return arr;
            }
            
            if(n%2 == 0)
            {
                for(int i=0; i<n ; i = i+2)
                {
                    arr[i] = i+1;
                    arr[i+1] = -(i+1);
                }
            }
            else
            {
                arr[0] = 0;
                for(int i= 1; i<n ; i = i+2)
                {
                    arr[i] = i;
                    arr[i+1] = -i;
                }
            }
                    
            return arr;
        }      

        [Fact]
        public void TestWrapper1()
        {
            int[] arrExp = {0,1,-1};
            var arr = SumZero(3);
            Assert.Equal(arrExp,arr);

            int[] arrExp1 = {0,1,-1,3,-3};
            var arr1 = SumZero(5);
            Assert.Equal(arrExp1,arr1);
            
            int[] arrExp2 = {0};
            var arr2 = SumZero(1);
            Assert.Equal(arrExp2,arr2);
            
            int[] arrExp3 = {1,-1,3,-3,5,-5};
            var arr3 = SumZero(6);
            Assert.Equal(arrExp3,arr3);

            int[] arrExp4 = {1,-1};
            var arr4 = SumZero(2);
            Assert.Equal(arrExp4,arr4);
        }

        
        [Fact]
        public void TestWrapper2()
        {
            int[] arrExp = {1,-1,0};
            var arr = SumZero2(3);
            Assert.Equal(arrExp,arr);

            int[] arrExp1 = {1,-1,2,-2,0};
            var arr1 = SumZero2(5);
            Assert.Equal(arrExp1,arr1);
            
            int[] arrExp2 = {0};
            var arr2 = SumZero2(1);
            Assert.Equal(arrExp2,arr2);
            
            int[] arrExp3 = {1,-1,2,-2,3,-3};
            var arr3 = SumZero2(6);
            Assert.Equal(arrExp3,arr3);

            int[] arrExp4 = {1,-1};
            var arr4 = SumZero2(2);
            Assert.Equal(arrExp4,arr4);
        }
    }
}
