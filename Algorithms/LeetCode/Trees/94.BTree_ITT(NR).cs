/*
94. Binary Tree Inorder Traversal
https://leetcode.com/problems/binary-tree-inorder-traversal/ 
Medium

Given the root of a binary tree, return the inorder traversal of its nodes' values.

Example 1:
                1
                 \
                  2
                 /
                3

Input: root = [1,null,2,3]
Output: [1,3,2]

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
Output: [2,1]

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
    public class BTreeInorderTraversalNonRecursive
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
        
        public IList<int> InorderTraversal(TreeNode root) 
        {
            _lst = new List<int>();
            if(root !=null)
            {
                Stack<TreeNode> staging = new Stack<TreeNode>();
                while(staging.Count>0 || root !=null)
                {
                    while(root != null)
                    {
                        staging.Push(root);
                        root = root.left;
                    }

                    root = staging.Pop();
                    _lst.Add(root.val);
                    root = root.right;
                }
            }       
            return _lst;
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
            var compare = new List<int>{2,1,4,3,5};
            var res = InorderTraversal(root);
            Assert.Equal(compare,res);


            /*
                        1
                       / \
                      2   3
                     / \   \
                    4   5   6
            */
            
            s = "1,2,4,X,X,5,X,X,3,X,6";
            obj = new Codec();
            root = obj.Deserialize(s);
            compare = new List<int>{4,2,5,1,3,6};
            res = InorderTraversal(root);
            Assert.Equal(compare,res);
        }
    }
}