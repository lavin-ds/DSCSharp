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
    public class BTreePreorderTraversalRecursive
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
        
        List<int> result;
    
        public IList<int> PreorderTraversal(TreeNode root) 
        {
            result = new List<int>();
            PTT(root);
            return result;
        }
        
        public void PTT(TreeNode root)
        {
            if(root!=null)
            {
                result.Add(root.val);
                PTT(root.left);
                PTT(root.right);
            }
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
            var s = "1,2,X,X,3,4,X,X,5";
            var obj = new Codec();
            var root = obj.Deserialize(s);
            var compare = new List<int>{1,2,3,4,5};
            var res = PreorderTraversal(root);
            Assert.Equal(compare,res);
        }
    }
}