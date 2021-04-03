using System;
/*
110. Balanced Binary Tree
https://leetcode.com/problems/balanced-binary-tree/
Easy

Given a binary tree, determine if it is height-balanced.

For this problem, a height-balanced binary tree is defined as:

    a binary tree in which the left and right subtrees of every node differ in height by no more than 1.

Example 1:
                        3
                       / \
                      9   20
                         /  \
                        15   7

Input: root = [3,9,20,null,null,15,7]
Output: true

Example 2:
                        1
                       / \
                      2   2
                     / \ 
                    3   3
                   / \ 
                  4   4

Input: root = [1,2,2,3,3,null,null,4,4]
Output: false

Example 3:

Input: root = []
Output: true

Constraints:

    The number of nodes in the tree is in the range [0, 5000].
    -104 <= Node.val <= 104
*/

namespace Algorithms.LeetCode.Trees
{
    public class BalancedTree 
    { 
        private bool isBalanced = true;
        public bool IsBalanced(TreeNode root) 
        {
            if(root!=null)
            {
                MaxDepth(root);                
                return isBalanced;
            }
            return true;
        }
        
        public int MaxDepth(TreeNode node)        
        {
            if(node != null)
            {
                var leftMax = MaxDepth(node.left);
                var rightMax = MaxDepth(node.right);
                if(!(Math.Abs(leftMax - rightMax)<=1))                    
                {
                    isBalanced = false;
                    return 0;
                }
                    
                return Math.Max(leftMax,rightMax) + 1;
            }
            return 0;
        }
        //TODO: Write a test wrapper for the method
    }
}