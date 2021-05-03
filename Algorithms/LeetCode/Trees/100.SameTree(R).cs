using System.Collections.Generic;
/*
100. Same Tree
https://leetcode.com/problems/same-tree/
Easy

Given the roots of two binary trees p and q, write a function to check if they are the same or not.

Two binary trees are considered the same if they are structurally identical, and the nodes have the same value.

Example 1:

            1               1
           / \             / \
          2   3           2   3  
           
Input: p = [1,2,3], q = [1,2,3]
Output: true

Example 2:

            1              1
           /                \
          2                  2  
           

Input: p = [1,2], q = [1,null,2]
Output: false

Example 3:
            1               1
           / \             / \
          2   1           1   2  
           
Input: p = [1,2,1], q = [1,1,2]
Output: false

Constraints:

    The number of nodes in both trees is in the range [0, 100].
    -104 <= Node.val <= 104
 */

using DataStructures.Entities;
using Xunit;

namespace Algorithms.LeetCode.Trees
{
    public class SameTree 
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
        public bool IsSameTree(TreeNode p, TreeNode q) {
            if(p==null && q == null)
                return true;
            if(p==null || q == null)
                return false;
            if(p.val == q.val)
            {
                if(IsSameTree(p.left,q.left) && IsSameTree(p.right,q.right))
                    return true;
                else
                    return false;
            }
            return false;
        }
        
        [Fact]
        public void TestWrap()
        {
            /*
                        1                   1
                       / \                 / \ 
                      2   3               2   3
                         / \                 / \       
                        4   5               4   5
            */
            var s = "1,2,X,X,3,4,X,X,5";
            var obj = new Codec();
            var root1 = obj.Deserialize(s);

            s = "1,2,X,X,3,4,X,X,5";            
            var root2 = obj.Deserialize(s);

            Assert.True(IsSameTree(root1,root2));
        }
    }
}