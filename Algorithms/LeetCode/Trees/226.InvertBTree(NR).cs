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

using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Algorithms.LeetCode.Trees
{
    public class InvertBTreeNonRecursive
    {
        public TreeNode InvertTree(TreeNode root) 
        {   
            var a = root;
            if(root!=null)
            {
                Stack<TreeNode> staging = new Stack<TreeNode>();
                staging.Push(root);
                while(staging.Any())
                {
                    root = staging.Pop();
                    TreeNode left = root.left;
                    root.left = root.right;
                    root.right = left;

                    if(root.left!=null)
                    {
                        staging.Push(root.left);                    
                    }
                    if(root.right!=null)
                    {
                        staging.Push(root.right);                    
                    }
                }
            }
            return a;
        }
    }
}  