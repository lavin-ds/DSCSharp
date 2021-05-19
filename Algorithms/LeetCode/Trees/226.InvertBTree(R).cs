/*
226. Invert Binary Tree
https://leetcode.com/problems/invert-binary-tree/
Easy

Given the root of a binary tree, invert the tree, and return its root.

Example 1:
                     4
                   /   \
                  2     3
                 / \   / \
                1   3 6   9
                     
                     ⬇

                     4
                   /   \
                  3     2
                 / \   / \
                9   6 3   1

Input: root = [4,2,7,1,3,6,9]
Output: [4,7,2,9,6,3,1]

Example 2:
                    2                  2
                   / \       ➡       / \
                  1   3              3   1 

Input: root = [2,1,3]
Output: [2,3,1]

Example 3:

Input: root = []
Output: []

Constraints:

    The number of nodes in the tree is in the range [0, 100].
    -100 <= Node.val <= 100
*/

using System;
using Xunit;

namespace Algorithms.LeetCode.Trees
{
    public class InvertBTreeRecursive
    {
        public TreeNode InvertTree(TreeNode root) 
        {        
            return Swap(root);
        }
        
        public TreeNode Swap(TreeNode node)
        {
            if(node!=null)
            {
            TreeNode right = Swap(node.right);
            TreeNode left = Swap(node.left);
            node.right = left;
            node.left = right;   
            }
            return node;                
        }
    }
}  