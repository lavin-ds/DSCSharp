using System;
/*
543. Diameter of Binary Tree
https://leetcode.com/problems/diameter-of-binary-tree/
Easy

Given the root of a binary tree, return the length of the diameter of the tree.

The diameter of a binary tree is the length of the longest path between any two nodes in a tree. This path may or may not pass through the root.

The length of a path between two nodes is represented by the number of edges between them.

Example 1:

Input: root = [1,2,3,4,5]
Output: 3
Explanation: 3is the length of the path [4,2,1,3] or [5,2,1,3].

Example 2:

Input: root = [1,2]
Output: 1

Constraints:

    The number of nodes in the tree is in the range [1, 104].
    -100 <= Node.val <= 100


*/

namespace Algorithms.LeetCode.Trees
{
    public class DiameterBTree {
        private int max;
        public int DiameterOfBinaryTree(TreeNode root) 
        {        
            ITT(root);        
            return max;
        }
        public int ITT(TreeNode node)
        {
            if(node!=null)
            {           
                var leftMax = ITT(node.left);            
                var rightMax = ITT(node.right);            
                
                if(leftMax+rightMax > max)
                    max = leftMax + rightMax;
                return Math.Max(leftMax,rightMax) + 1;
            }  
            return 0;
        }    

        //TODO: Write a test wrapper for the method
    }
}