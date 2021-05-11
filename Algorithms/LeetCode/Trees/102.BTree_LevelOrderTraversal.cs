/*
102. Binary Tree Level Order Traversal
https://leetcode.com/problems/binary-tree-level-order-traversal/
Medium

Given the root of a binary tree, return the level order traversal of its nodes' values. (i.e., from left to right, level by level).

Example 1:

                     3
                    / \
                   9  20
                     /  \
                    15   7
                    
Input: root = [3,9,20,null,null,15,7]
Output: [[3],[9,20],[15,7]]

Example 2:

Input: root = [1]
Output: [[1]]

Example 3:

Input: root = []
Output: []

Constraints:

    The number of nodes in the tree is in the range [0, 2000].
    -1000 <= Node.val <= 1000
*/

using System.Collections.Generic;
using DataStructures.Entities;
using Xunit;

namespace Algorithms.LeetCode.Trees
{
    public class LevelOrderTraversal 
    {
        private int count = 0;
        public IList<IList<int>> LevelOrder(BinaryTreeNode root) 
        {   
            var listTotal = new List<List<int>>();

            if(root == null)
                return listTotal.ToArray();    

            Queue<BinaryTreeNode> staging = new Queue<BinaryTreeNode>();
            //listTotal.Add(new List<int>{root.data});
            
            var listLocal = new List<int>();
            var queueLength = 1;
            staging.Enqueue(root);
            while(staging.Count > 0)   
            {    
                
                if(queueLength == 0)
                {
                    queueLength = staging.Count;
                    listTotal.Add(listLocal);
                    listLocal = new List<int>();
                }             

                var temp = staging.Dequeue();
                queueLength--;
            
                if(temp!=null)
                {
                    staging.Enqueue(temp.left);
                    staging.Enqueue(temp.right);
                    listLocal.Add(temp.data);
                }
            }
            if(listLocal.Count >0)
            {
                listTotal.Add(listLocal);                 
            }                

            return listTotal.ToArray();
        }
    }
}