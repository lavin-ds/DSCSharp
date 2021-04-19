using System;
/*
Maximum Width of Binary Tree

Given a binary tree, write a function to get the maximum width of the given tree. The maximum width of a tree is the maximum width among all levels.
The width of one level is defined as the length between the end-nodes (the leftmost and right most non-null nodes in the level, where the null nodes between the end-nodes are also counted into the length calculation.
It is guaranteed that the answer will in the range of 32-bit signed integer.

Example 1:

Input: 

           1
         /   \
        3     2
       / \     \  
      5   3     9 

Output: 4
Explanation: The maximum width existing in the third level with the length 3 (5,3,9).

Example 2:

Input: 

          1
         /  
        3    
       / \       
      5   3     

Output: 2
Explanation: The maximum width existing in the third level with the length 2 (5,3).

Example 3:

Input: 

          1
         / \
        3   2 
       /        
      5      

Output: 2
Explanation: The maximum width existing in the second level with the length 2 (3,2).

Example 4:

Input: 

          1
         / \
        3   2
       /     \  
      5       9 
     /         \
    6           7
Output: 8
Explanation:The maximum width existing in the fourth level with the length 2 (3,2).

Constraints:

    The given binary tree will have between 1 and 3000 nodes.
*/

using Algorithms.LeetCode.Trees;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Algorithms.Codility
{
    public class MaxWidthTreeBFS 
    {
        Queue<TreeNode> staging;
        Dictionary<int,int> result;
    
        public int WidthOfBinaryTree(TreeNode root) 
        {
            result = new Dictionary<int,int>();
            staging = new Queue<TreeNode>();
            Width(root,1);
            return result.OrderByDescending(x=>x.Value).FirstOrDefault().Value;     
        }
        
        public void Width(TreeNode node, int level)
        {   
            if(node == null)
                return;
            
            staging.Enqueue(node);
            int countNodesProcessed = 0;
            int countNodesValid = 0;

            while(staging.Count!=0)
            {
                var locNode = staging.Dequeue();
                countNodesProcessed++;
                if(locNode!=null)
                {
                    countNodesValid++;
                    staging.Enqueue(locNode.left);
                    staging.Enqueue(locNode.right);
                }
                if(countNodesProcessed == Math.Pow(2,level-1))
                {
                    result.Add(level,countNodesValid);
                    level++;
                    countNodesProcessed = 0;
                    countNodesValid=0;
                }
                
            }
        }
    }
}
