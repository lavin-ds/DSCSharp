/*
200. Number of Islands
https://leetcode.com/problems/number-of-islands/
Medium

Given an m x n 2D binary grid grid which represents a map of '1's (land) and '0's (water), 
return the number of islands. An island is surrounded by water and is formed by connecting adjacent 
lands horizontally or vertically. You may assume all four edges of the grid are all surrounded by water.

Example 1:

Input: grid = [
  ["1","1","1","1","0"],
  ["1","1","0","1","0"],
  ["1","1","0","0","0"],
  ["0","0","0","0","0"]
]
Output: 1

Example 2:

Input: grid = [
  ["1","1","0","0","0"],
  ["1","1","0","0","0"],
  ["0","0","1","0","0"],
  ["0","0","0","1","1"]
]
Output: 3

Constraints:

    m == grid.length
    n == grid[i].length
    1 <= m, n <= 300
    grid[i][j] is '0' or '1'.
*/

using Xunit;

namespace Algorithms.LeetCode.Graphs
{
    public class NumberofIslands2
    { 
        int x; // The width of the given grid
        int y; // The height of the given grid

        public int NumIslands(char[][] grid) 
        {
            int result = 0; // Our count to return
            
            // Dimensions of the given graph
            y = grid.Length;
            if(y==0) return 0;
            x = grid[0].Length;
            for (int i = 0; i<y;i++)
            for(int j = 0; j<x ; j++)
            {
                if(grid[i][j] == '1')
                    {
                        if(IsIsland(i,j, grid))
                            result++;
                    }
            }
            return result;
        }

        /// <summary>
        /// Marks the given site as visited, then checks adjacent sites.
        /// Works as a boolean check. For an island to return true it should have water on all its 4 sides.
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        public bool IsIsland(int i , int j, char[][] g)
        {
            //All borders return true
            if(i>=y || j>=x || i<0 || j<0 )
                return true;

            if(g[i][j] =='0')
                return true;

            g[i][j] = '0'; //Mark other numbers to count area etc. Add to hashmap
            bool isIsland = true;
            
            isIsland = isIsland & (IsIsland(i-1,j,g) & IsIsland(i,j-1,g) & IsIsland(i+1,j,g) & IsIsland(i,j+1,g));
             
            return isIsland;
        }
    }    
}