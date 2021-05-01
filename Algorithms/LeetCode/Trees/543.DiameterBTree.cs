/*
543. Diameter of Binary Tree
https://leetcode.com/problems/diameter-of-binary-tree/
Easy

Given the root of a binary tree, return the length of the diameter of the tree.

The diameter of a binary tree is the length of the longest path between any two nodes in a tree. This path may or may not pass through the root.

The length of a path between two nodes is represented by the number of edges between them.

Example 1:
                    1
                   / \
                  2   3
                 / \
                4   5

Input: root = [1,2,3,4,5]
Output: 3
Explanation: 3 is the length of the path [4,2,1,3] or [5,2,1,3].

Example 2:
                    1
                   /
                  2

Input: root = [1,2]
Output: 1

Constraints:

    The number of nodes in the tree is in the range [1, 104].
    -100 <= Node.val <= 100
*/

using System;
using Xunit;

namespace Algorithms.LeetCode.Trees
{
    public class DiameterBTree {
        private int max;
        public int DiameterOfBinaryTree(TreeNode root) 
        { 
            max = Int32.MinValue;       
            ITT(root);        
            return max;
        }
        public int ITT(TreeNode node)
        {
            if(node!=null)
            {           
                var leftMax = ITT(node.left);            
                var rightMax = ITT(node.right);            
                
                if(leftMax+rightMax > max)
                    max = leftMax + rightMax;
                return Math.Max(leftMax,rightMax) + 1;
            }  
            return 0;
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
            
            var res = DiameterOfBinaryTree(root);
            Assert.Equal(3,res);


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
            
            res = DiameterOfBinaryTree(root);
            Assert.Equal(4,res);

            /*
                        1
                       / \
                      3   2
                     / 
                    5   
            */
            
            s = "1,3,5,X,X,X,2";
            obj = new Codec();
            root = obj.Deserialize(s);
            
            res = DiameterOfBinaryTree(root);
            Assert.Equal(3,res);

            /*
                        1
                       /
                      3   
                     / 
                    5   
            */
            
            s = "1,3,5,X,X,X";
            obj = new Codec();
            root = obj.Deserialize(s);
            
            res = DiameterOfBinaryTree(root);
            Assert.Equal(2,res);

            /*
                        1
                       / \
                      3   2 
                     /     \
                    5       6
                   /         \
                  7           8  
            */
            
            s = "1,3,5,7,X,X,X,X,2,X,6,X,8";
            obj = new Codec();
            root = obj.Deserialize(s);
            
            res = DiameterOfBinaryTree(root);
            Assert.Equal(6,res);
        }
    }
}  