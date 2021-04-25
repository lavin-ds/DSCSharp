/*
98. Validate Binary Search Tree
https://leetcode.com/problems/validate-binary-search-tree/
Medium

Given the root of a binary tree, determine if it is a valid binary search tree (BST).

A valid BST is defined as follows:

    The left subtree of a node contains only nodes with keys less than the node's key.
    The right subtree of a node contains only nodes with keys greater than the node's key.
    Both the left and right subtrees must also be binary search trees.

Example 1:
                    2
                   / \
                  1   3

Input: root = [2,1,3]
Output: true

Example 2:
                    5
                   / \
                  1   4
                     / \
                    3   6

Input: root = [5,1,4,null,null,3,6]
Output: false
Explanation: The root node's value is 5 but its right child's value is 4.

Constraints:

    The number of nodes in the tree is in the range [1, 104].
    -231 <= Node.val <= 231 - 1
*/

using System.Collections.Generic;
using Xunit;

namespace Algorithms.LeetCode.Trees
{
    public class ValidateBSTRecursive {
       
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
        TreeNode prev;
        public bool IsValidBST(TreeNode root) 
        {
            prev = null;
            return Validate(root);
        }
        
        public bool Validate(TreeNode node)
        {
            if(node != null)
            {
                if(!Validate(node.left))
                    return false;
                    
                if(prev!=null && prev.val >=node.val)
                    return false;
                
                prev = node;
                if(!Validate(node.right))
                    return false;
            }
            return true;
        }

        [Fact]
        public void TestWrap()
        {
            /*
                     1               
                    / \               
                   2   3              
                      / \             
                     4   5    
            */
            var s1 = "1,2,X,X,3,4,X,X,5";
            var obj = new Codec();
            var root1 = obj.Deserialize(s1);
            
            var res = IsValidBST(root1);
            Assert.False(res);

             /*
                     2               
                    / \               
                   1   3              
                      / \             
                     4   5    
            */
            s1 = "2,1,X,X,3,4,X,X,5";
            obj = new Codec();
            root1 = obj.Deserialize(s1);
            
            res = IsValidBST(root1);
            Assert.False(res);

        }
    }
}