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
    public class SameTreeNonRecursive
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

        public bool IsSameTree(BinaryTreeNode p, BinaryTreeNode q) {
            if(p==null && q == null)
                return true;
            if(p==null || q == null)
                return false;
            Queue<BinaryTreeNode> stage = new Queue<BinaryTreeNode>();

            stage.Enqueue(p);
            stage.Enqueue(q);

            while(stage.Count>0)
            {
                p = stage.Dequeue();
                q = stage.Dequeue();

                if(!Check(p,q)) return false;
                if(p!=null)
                {
                    if(!Check(p.left, q.left)) return false;

                    if(p.left !=null)
                    {

                        stage.Enqueue(p.left);
                        stage.Enqueue(q.left);
                    }

                    if(!Check(p.right, q.right)) return false;

                    if(p.right !=null)
                    {

                        stage.Enqueue(p.right);
                        stage.Enqueue(q.right);
                    }
                }
            }

            return true;
        }

        public bool Check(BinaryTreeNode p, BinaryTreeNode q)
        {
            if(p==null && q == null)
                return true;
            if(p==null || q == null)
                return false;
            if(p.data == q.data)
                return true;           
            return false;
        }

        //TODO: Write a test wrapper for the method
    }
}