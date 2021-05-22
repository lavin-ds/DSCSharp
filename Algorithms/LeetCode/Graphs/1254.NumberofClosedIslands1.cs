/*
1254. Number of Closed Islands
https://leetcode.com/problems/number-of-closed-islands/
Medium

Given a 2D grid consists of 0s (land) and 1s (water).  An island is a maximal 4-directionally connected group of 0s and 
a closed island is an island totally (all left, top, right, bottom) surrounded by 1s. Return the number of closed islands.

Example 1:

Input: grid = [[1,1,1,1,1,1,1,0],
               [1,0,0,0,0,1,1,0],
               [1,0,1,0,1,1,1,0],
               [1,0,0,0,0,1,0,1],
               [1,1,1,1,1,1,1,0]]
Output: 2
Explanation: 
Islands in gray are closed because they are completely surrounded by water (group of 1s).

Example 2:

Input: grid = [[0,0,1,0,0],[0,1,0,1,0],[0,1,1,1,0]]
Output: 1

Example 3:

Input: grid = [[1,1,1,1,1,1,1],
               [1,0,0,0,0,0,1],
               [1,0,1,1,1,0,1],
               [1,0,1,0,1,0,1],
               [1,0,1,1,1,0,1],
               [1,0,0,0,0,0,1],
               [1,1,1,1,1,1,1]]
Output: 2

Constraints:
    1 <= grid.length, grid[0].length <= 100
    0 <= grid[i][j] <=1
*/

using Xunit;

namespace Algorithms.LeetCode.Graphs
{
    public class NumberofClosedIslands1
    { 
        int x; // The width of the given grid
        int y; // The height of the given grid
       
        public int ClosedIsland(int[][] grid) 
        {
            int result = 0; // Our count to return
            
            // Dimensions of the given graph
            y = grid.Length;
            if(y==0) return 0;
            x = grid[0].Length;
            //Start at 1 and y-1 so that the edges of grid are removed from count
            for (int i = 1; i<y-1;i++)
                for(int j = 1; j<x-1 ; j++)
                {
                    if(grid[i][j] == 0)
                    {
                        if(IsClosedIsland(i,j, grid))
                            result++;
                    }
                }
            return result;
        }

        /// <summary>
        /// Marks the given site as visited, then checks adjacent sites.
        /// Or, can mark the given site as water, if land, then checks adjacent sites.
        /// Or, given one coordinate (i,j) of an island, obliterates the island
        /// from the given grid, so that it is not counted again.
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        public bool IsClosedIsland(int i , int j, int[][] g)
        {
            //if the node is a border node and it isnt water return false
            if((i==y-1 || j==x-1 || i==0 || j==0) && g[i][j]!=1)
                return false;
            
            if(g[i][j] == 1)
                return true;
            
            g[i][j] = 1; //Mark other numbers to count area etc. Add to hashmap

            var res = true;

            res = res & IsClosedIsland(i-1,j,g) & IsClosedIsland(i,j-1,g) & IsClosedIsland(i+1,j,g) & IsClosedIsland(i,j+1,g);
            return res;
        }

        [Fact]
        public void TestWrap()
        {
            int[][] ip1 = new int[4][];
            ip1[0] = new int[]{0,0,0,0,1};
            ip1[1] = new int[]{0,0,1,0,1};
            ip1[2] = new int[]{0,0,1,1,1};
            ip1[3] = new int[]{1,1,1,1,1};

            Assert.Equal(0, ClosedIsland(ip1));

            int[][] ip2 = new int[7][];
            ip2[0] = new int[]{0,0,0,0,1,0};
            ip2[1] = new int[]{0,0,1,0,1,1};
            ip2[2] = new int[]{0,0,1,1,1,0};
            ip2[3] = new int[]{0,1,1,1,1,1};
            ip2[4] = new int[]{0,1,0,1,1,0};
            ip2[5] = new int[]{0,1,1,1,1,0};
            ip2[6] = new int[]{0,1,1,1,1,0};

            Assert.Equal(1, ClosedIsland(ip2));

            int[][] ip3 = new int[4][];
            ip3[0] = new int[]{1,1,0,0,0};
            ip3[1] = new int[]{1,1,0,0,0};
            ip3[2] = new int[]{0,0,1,0,0};
            ip3[3] = new int[]{0,0,0,1,1};

            Assert.Equal(0, ClosedIsland(ip3));

            int[][] ip4 = new int[5][];
            ip4[0] = new int[]{1,1,1,1,1,1,1,0};
            ip4[1] = new int[]{1,0,0,0,0,1,1,0};
            ip4[2] = new int[]{1,0,1,0,1,1,1,0};
            ip4[3] = new int[]{1,0,0,0,0,1,0,1};
            ip4[4] = new int[]{1,1,1,1,1,1,1,0};

            Assert.Equal(2, ClosedIsland(ip4));

            int[][] ip5 = new int[10][];
            ip5[0] = new int[]{0,0,1,1,0,1,0,0,1,0};
            ip5[1] = new int[]{1,1,0,1,1,0,1,1,1,0};
            ip5[2] = new int[]{1,0,1,1,1,0,0,1,1,0};
            ip5[3] = new int[]{0,1,1,0,0,0,0,1,0,1};
            ip5[4] = new int[]{0,0,0,0,0,0,1,1,1,0};
            ip5[5] = new int[]{0,1,0,1,0,1,0,1,1,1};
            ip5[6] = new int[]{1,0,1,0,1,1,0,0,0,1};
            ip5[7] = new int[]{1,1,1,1,1,1,0,0,0,0};
            ip5[8] = new int[]{1,1,1,0,0,1,0,1,0,1};
            ip5[9] = new int[]{1,1,1,0,1,1,0,1,1,0};

            Assert.Equal(5, ClosedIsland(ip5));
        }
    }    
}