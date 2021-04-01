
/*
There is an infrastructure of n cities with some number of roads connecting these cities. Each roads[i] = [ai, bi] indicates that there is a bidirectional road between cities ai and bi.

The network rank of two different cities is defined as the total number of directly connected roads to either city. If a road is directly connected to both cities, it is only counted once.

The maximal network rank of the infrastructure is the maximum network rank of all pairs of different cities.

Given the integer n and the array roads, return the maximal network rank of the entire infrastructure.

Example 1:

Input: n = 4, roads = [[0,1],[0,3],[1,2],[1,3]]
Output: 4
Explanation: The network rank of cities 0 and 1 is 4 as there are 4 roads that are connected to either 0 or 1. The road between 0 and 1 is only counted once.

Example 2:

Input: n = 5, roads = [[0,1],[0,3],[1,2],[1,3],[2,3],[2,4]]
Output: 5
Explanation: There are 5 roads that are connected to cities 1 or 2.

Example 3:

Input: n = 6, roads = [[1,2],[2,3],[4,5],[5,6]]
Output: 2
Explanation: The network rank of 1 and 2 is 2. Notice that all the cities have to be connected.

Constraints:

    2 <= n <= 100
    0 <= roads.length <= n * (n - 1) / 2
    roads[i].length == 2
    0 <= ai, bi <= n-1
    ai != bi
    Each pair of cities has at most one road connecting them.
*/
using System.Collections.Generic;
using Xunit;

namespace Algorithms.Codility
{
    public class MaximalNetworkRank
    { 
        public int solutionFind(int[] A, int[] B, int N) 
        {
            if(A.Length ==0 && B.Length == 0 )
                return 0;
            Dictionary<int, int> dict = new Dictionary<int, int>();

            foreach(var item in A)        
            {
                if(dict.ContainsKey(item))
                {
                    dict[item]++;
                }
                else
                {
                    dict.Add(item, 1);
                }
            }

            foreach(var item in B)        
            {
                if(dict.ContainsKey(item))
                {
                    dict[item]++;
                }
                else
                {
                    dict.Add(item, 1);
                }
            }

            int maxValue =  0;
            int red = 0;
            for (int i =0; i< A.Length;i++)
            {
                red = dict[A[i]] + dict[B[i]] -1; 
                if(red > maxValue)
                    maxValue = red;
            }

            return maxValue;
        }

        public int solutionFind2(int[] A, int[] B, int N) 
        {
            if(A.Length ==0 && B.Length == 0 )
                return 0;

            int[] arr = new int[N+1];

            for(int i = 0; i<A.Length;i++)
            {
                arr[A[i]]++;
                arr[B[i]]++;
            }

            int maxValue =  0;
            int reduction = 0;
            for (int i =0; i< A.Length;i++)
            {
                reduction = arr[A[i]] + arr[B[i]] -1; 
                if(reduction > maxValue)
                    maxValue = reduction;
            }

            return maxValue;
        }

        [Fact]
        public void TestWrapper()
        {
            int[] A = {1,2,3,3};
            int[] B = {2,3,1,4};
            int N = 4;
            var result  = solutionFind(A,B,N); 
            Assert.Equal(4, result);    

            int[] A1 = {1,2,4,5};
            int[] B1 = {2,3,5,6};
            N = 6;
            result  = solutionFind(A1,B1,N); 
            Assert.Equal(2, result);   

            int[] A2 = {6,5,1,3,3,4,4,5,1};
            int[] B2 = {7,7,3,2,7,7,5,6,5};
            N = 7;
            result  = solutionFind(A2,B2,N); 
            Assert.Equal(7, result);            
        }
    }    
}

