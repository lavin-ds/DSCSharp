/*


This is a demo task.

Write a function:

    class Solution { public int solution(int[] A); }

that, given an array A of N integers, returns the smallest positive integer (greater than 0) that does not occur in A.

For example, given A = [1, 3, 6, 4, 1, 2], the function should return 5.

Given A = [1, 2, 3], the function should return 4.

Given A = [−1, −3], the function should return 1.

Write an efficient algorithm for the following assumptions:

        N is an integer within the range [1..100,000];
        each element of array A is an integer within the range [−1,000,000..1,000,000].

Copyright 2009–2021 by Codility Limited. All Rights Reserved. Unauthorized copying, publication or disclosure prohibited. 

*/

using System.Collections.Generic;
using Xunit;
using System.Linq;

namespace Algorithms.Codility
{
    public class Arrays { 
        public int solutionFind(int[] A)
        {    
            int res = 0;    
            HashSet<int> set = new HashSet<int>();
            for(int i = 0 ; i < A.Length; i ++)
            {
                if(A[i]>0)
                    set.Add(A[i]);
            }

            if(set.Count() == 0)
            {
                res = 1;
            }
            var arr = set.OrderBy(x=>x).ToArray();

            for(int i = 0; i < arr.Count();i++)
            {
                if(arr[i] != i+1)
                {
                    res = i+1;
                    break;
                }
            }

            if (res==0)
            {
                res = (arr[arr.Count()-1] + 1);
            }
            return res;
        }

        [Fact]
        public void TestWrapper()
        {
            int[] ip = {1, 3, 6, 4, 1, 2};
            var result  = solutionFind(ip); 
            Assert.Equal(5, result);

            int[] ip2 = {1, 2, 3};
            result  = solutionFind(ip2); 
            Assert.Equal(4, result);

            int[] ip3 = {-1, -3};
            result  = solutionFind(ip3); 
            Assert.Equal(1, result);

            int[] ip4 = {-3, -10, -555656, 5664, 4545, 2135, 4845};
            result  = solutionFind(ip4); 
            Assert.Equal(1, result);
            
        }
    }
}