/*
Given the root of a binary tree, return the inorder traversal of its nodes' values.

https://leetcode.com/problems/binary-tree-inorder-traversal/ 

Example 1:

Input: root = [1,null,2,3]
Output: [1,3,2]

Example 2:

Input: root = []
Output: []

Example 3:

Input: root = [1]
Output: [1]

Example 4:

Input: root = [1,2]
Output: [2,1]

Example 5:

Input: root = [1,null,2]
Output: [1,2]

 

Constraints:

    The number of nodes in the tree is in the range [0, 100].
    -100 <= Node.val <= 100
*/


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

using System.Collections.Generic;
using DataStructures.ADT;
using DataStructures.Entities;
using Xunit;

namespace Algorithms.LeetCode.Trees
{
    public class BTreeInorderTraversal {
       
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
        
        public IList<int> InorderTraversal(BinaryTreeNode root) {
            _lst = new List<int>();
            ITT(root);       
            return _lst;
        }
        
        public void ITT(BinaryTreeNode node)
        {
            if(node != null)
            {
                ITT(node.left);
                _lst.Add(node.data);            
                ITT(node.right);
            }
        }

        //TODO: Write a test wrapper for the method
    }
}