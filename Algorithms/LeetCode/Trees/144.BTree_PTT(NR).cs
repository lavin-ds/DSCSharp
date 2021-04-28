/*
144. Binary Tree Preorder Traversal
https://leetcode.com/problems/binary-tree-preorder-traversal/
Medium

Given the root of a binary tree, return the preorder traversal of its nodes' values.

Example 1:
                1
                 \
                  2
                 /
                3

Input: root = [1,null,2,3]
Output: [1,2,3]

Example 2:
              
Input: root = []
Output: []

Example 3:

Input: root = [1]
Output: [1]

Example 4:
                1
               /
              2
                
Input: root = [1,2]
Output: [1,2]

Example 5:
               1
                \
                 2

Input: root = [1,null,2]
Output: [1,2]

Constraints:

    The number of nodes in the tree is in the range [0, 100].
    -100 <= Node.val <= 100
*/

using System.Collections.Generic;
using Xunit;

namespace Algorithms.LeetCode.Trees
{
    public class BTreePreorderTraversalNonRecursive
     { 
        /**
        * Definition for a binary tree node.
        * public class TreeNode {
        *     public int val;
        *     public TreeNode left;
        *     public TreeNode right;
        *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
        *         this.val = val;
        *         this.left = left;
        *         this.right = right;
        *     }
        * }
        */
        
        private List<int> _lst;
        
        public IList<int> PreorderTraversal(TreeNode root) 
        {
             _lst = new List<int>();
            if(root != null)
            {        
                Stack<TreeNode> staging = new Stack<TreeNode>();
                staging.Push(root);
                while(staging.Count>0)
                {
                    var node = staging.Pop();
                    _lst.Add(node.val);
                    if(node.right != null)
                    {
                        staging.Push(node.right);
                    }
                    if(node.left != null)
                    {
                        staging.Push(node.left);
                    }
                }
            }
            return _lst;
        }
    }
}