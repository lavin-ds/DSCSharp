/*200. Number of Islands
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
    public class NumberofIslands1
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
                        MarkVisited(i,j, grid);
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
        public void MarkVisited(int i , int j, char[][] g)
        {
            if(i>=y || j>=x || i<0 || j<0 || g[i][j] !='1')
                return;
            int[][] dir = new int[][]{new int[]{1, 0}, new int[]{-1, 0}, new int[]{0, 1}, new int[]{0, -1}};
            
            g[i][j] = '0'; //Mark other numbers to count area etc. Add to hashmap

            MarkVisited(i-1,j,g);
            MarkVisited(i,j-1,g);
            MarkVisited(i+1,j,g);
            MarkVisited(i,j+1,g);
        }

        [Fact]
        public void TestWrap()
        {
            char[][] ip1 = new char[4][];
            ip1[0] = new char[]{'1','1','1','1','0'};
            ip1[1] = new char[]{'1','1','0','1','0'};
            ip1[2] = new char[]{'1','1','0','0','0'};
            ip1[3] = new char[]{'0','0','0','0','0'};

            Assert.Equal(1, NumIslands(ip1));

        }
    }    
}