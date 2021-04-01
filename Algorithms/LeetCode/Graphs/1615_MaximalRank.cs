
using System;
/*
TODO:Incorrect

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

Input: n = 8, roads = [[0,1],[1,2],[2,3],[2,4],[5,6],[5,7]]
Output: 5
Explanation: The network rank of 2 and 5 is 5. Notice that all the cities do not have to be connected.

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

namespace Algorithms.Graphs
{
    public class MaximalNetworkRank
    { 
        public int MaximalRank(int n, int[][] roads) 
        {
            if(roads.Length ==0 )
                return 0;
            Dictionary<int, int> dict = new Dictionary<int, int>();

            foreach(var arr in roads)        
            {
                foreach(var item in arr)
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
            }

            int maxValue =  0;
            int red = 0;
            foreach(var arr in roads)        
            {
                red = dict[arr[0]] + dict[arr[1]] -1; 
                if(red > maxValue)
                    maxValue = red;
            }

            return maxValue;
        }

         public int MaximalRank2(int n, int[][] roads) 
        {
           if(roads.Length ==0 )
                return 0;

            int[] arr = new int[n+1];

            for(int i = 0; i<roads.Length;i++)
            {
                arr[roads[i][0]]++;
                arr[roads[i][1]]++;
            }

            int maxNode = 0;
            int nextMaxNode = 0;
            bool joint = false;
            int res =0 ;
            for (int i =0; i< roads.Length;i++)
            {
                maxNode = Math.Max(maxNode,Math.Max(arr[roads[i][0]],arr[roads[i][1]]));
                nextMaxNode = Math.Max(nextMaxNode,Math.Min(arr[roads[i][0]],arr[roads[i][1]]));

                if((maxNode == arr[roads[i][0]] && nextMaxNode == arr[roads[i][1]]) || (nextMaxNode == arr[roads[i][0]] && maxNode == arr[roads[i][1]]))
                    joint = true;   
                                
            }

            res= maxNode+nextMaxNode;
            if(joint)
                res--;
            return res;
        }

        [Fact]
        public void TestWrapper()
        {
            int[][] roads = new int[4][];
            roads[0] = new int[] {1,2};
            roads[1] = new int[] {2,3};
            roads[2] = new int[] {3,1};
            roads[3] = new int[] {3,4};

            int N = 4;
            var result  = MaximalRank(N, roads); 
            Assert.Equal(4, result);    

            int[][] roads1 = new int[4][];
            roads1[0] = new int[] {1,2};
            roads1[1] = new int[] {2,3};
            roads1[2] = new int[] {4,5};
            roads1[3] = new int[] {5,6};
            
            N = 6;
            result  = MaximalRank(N, roads1); 
            Assert.Equal(2, result);   

            int[][] roads2 = new int[9][];
            roads2[0] = new int[] {6,7};
            roads2[1] = new int[] {5,7};
            roads2[2] = new int[] {1,3};
            roads2[3] = new int[] {3,2};
            roads2[4] = new int[] {3,7};
            roads2[5] = new int[] {4,7};
            roads2[6] = new int[] {4,5};
            roads2[7] = new int[] {5,6};
            roads2[8] = new int[] {1,5};
            
            N = 7;
            result  = MaximalRank(N, roads2); 
            Assert.Equal(7, result);  

            int[][] roads3 = new int[6][];
            roads3[0] = new int[] {0,1};
            roads3[1] = new int[] {1,2};
            roads3[2] = new int[] {2,3};
            roads3[3] = new int[] {2,4};
            roads3[4] = new int[] {5,6};
            roads3[5] = new int[] {5,7};
      
            N = 8;
            result  = MaximalRank2(N, roads3); 
            Assert.Equal(5, result);  
        }
    }    
}