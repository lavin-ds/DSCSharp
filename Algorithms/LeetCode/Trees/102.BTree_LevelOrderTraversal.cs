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
using Xunit;

namespace Algorithms.LeetCode.Trees
{
    public class LevelOrderTraversal 
    {
        public IList<IList<int>> LevelOrder(TreeNode root) 
        {   
            var listTotal = new List<List<int>>();

            if(root == null)
                return listTotal.ToArray();    

            Queue<TreeNode> staging = new Queue<TreeNode>();
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
                    listLocal.Add(temp.val);
                }
            }
            if(listLocal.Count >0)
            {
                listTotal.Add(listLocal);                 
            }                

            return listTotal.ToArray();
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
            var listExpected = new List<List<int>>();
            listExpected.Add(new List<int>{1});
            listExpected.Add(new List<int>{2,3});
            listExpected.Add(new List<int>{4,5});
            
            Assert.Equal(listExpected, LevelOrder(root));


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
            
            listExpected = new List<List<int>>();
            listExpected.Add(new List<int>{1});
            listExpected.Add(new List<int>{2,3});
            listExpected.Add(new List<int>{4,5,6});

            Assert.Equal(listExpected, LevelOrder(root));
        }
    }
}