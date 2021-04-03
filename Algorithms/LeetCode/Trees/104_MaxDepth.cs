using System;
/*
104. Maximum Depth of Binary Tree
https://leetcode.com/problems/maximum-depth-of-binary-tree/
Easy

Given the root of a binary tree, return its maximum depth.

A binary tree's maximum depth is the number of nodes along the longest path from the root node down to the farthest leaf node.

 

Example 1:

Input: root = [3,9,20,null,null,15,7]
Output: 3

Example 2:

Input: root = [1,null,2]
Output: 2

Example 3:

Input: root = []
Output: 0

Example 4:

Input: root = [0]
Output: 1

Constraints:

    The number of nodes in the tree is in the range [0, 104].
    -100 <= Node.val <= 100
*/

namespace Algorithms.LeetCode.Trees
{
    public class MaximumDepth {
         private int _length;
        private int _maxLength;
        
        public int MaxDepth(TreeNode root) 
        {        
            _length = 0;
            ITT(root);
            return _maxLength;
        }
        
        public TreeNode ITT(TreeNode node)
        {
            if(node!=null)
            {
                _length++;
                if(_length>_maxLength)
                {
                    _maxLength = _length;
                }         
                ITT(node.left);            
                ITT(node.right);
                _length--;
            }  
            return null;
        }

        public int MaxDepth2(TreeNode node)
        {
            return GetMaxDepth(node);
        }

        public int GetMaxDepth(TreeNode node)
        {
            if(node == null)
            {
                return 0;
            }

            int leftDepth = GetMaxDepth(node.left);
            int rightDepth = GetMaxDepth(node.right);

            return Math.Max(leftDepth,rightDepth)+1;
        }
        //TODO: Write a test wrapper for the method
    }
}