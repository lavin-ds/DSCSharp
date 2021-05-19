/*
226. Invert Binary Tree
https://leetcode.com/problems/invert-binary-tree/
Easy

Given the root of a binary tree, invert the tree, and return its root.

Example 1:
                     4
                   /   \
                  2     3
                 / \   / \
                1   3 6   9
                     
                     ⬇

                     4
                   /   \
                  3     2
                 / \   / \
                9   6 3   1

Input: root = [4,2,7,1,3,6,9]
Output: [4,7,2,9,6,3,1]

Example 2:
                    2                  2
                   / \       ➡       / \
                  1   3              3   1 

Input: root = [2,1,3]
Output: [2,3,1]

Example 3:

Input: root = []
Output: []

Constraints:

    The number of nodes in the tree is in the range [0, 100].
    -100 <= Node.val <= 100
*/

using System;
using Xunit;

namespace Algorithms.LeetCode.Trees
{
    public class InvertBTreeRecursive
    {
        public TreeNode InvertTree(TreeNode root) 
        {        
            return Swap(root);
        }
        
        public TreeNode Swap(TreeNode node)
        {
            if(node!=null)
            {
            TreeNode right = Swap(node.right);
            TreeNode left = Swap(node.left);
            node.right = left;
            node.left = right;   
            }
            return node;                
        }

        [Fact]
        public void TestWrap()
        {
            /*
                Orignal
                        1
                       / \
                      2   3
                         / \
                        4   5
            */
            var s = "1,2,X,X,3,4,X,X,5";
            var obj = new Codec();
            var root = obj.Deserialize(s);
            
            /*
                Inverted
                        1
                       / \
                      3   2
                     / \
                    5   4
            */

            s = "1,3,5,X,X,4,X,X,2";
            var expected = obj.Deserialize(s);
            var res = InvertTree(root);
            var treeTest = new SameTree();
            Assert.True(treeTest.IsSameTree(expected,res));

             /*
                Original
                        1
                       / \
                      2   3
                     / \   \
                    4   5   6
            */
            
            s = "1,2,4,X,X,5,X,X,3,X,6";
            root = obj.Deserialize(s);

            /*
                Inverted
                        1
                       / \
                      3   2
                     /   / \
                    6   5   4

            */

            s = "1,3,6,X,X,X,2,5,X,X,4";
            expected = obj.Deserialize(s);
            res = InvertTree(root);
            Assert.True(treeTest.IsSameTree(expected,res));

            /*
                Original
                        1
                       / \
                      3   2
                     / 
                    5   
            */
            
            s = "1,3,5,X,X,X,2";
            root = obj.Deserialize(s);

            /*
                Inverted
                        1
                       / \
                      2   3
                           \
                            5 
            */

            s = "1,2,X,X,3,X,5";
            expected = obj.Deserialize(s);
            res = InvertTree(root);
            Assert.True(treeTest.IsSameTree(expected,res));
            
            /*
                Original
                        1
                       /
                      3   
                     / 
                    5   
            */
            
            s = "1,3,5,X,X,X";
            root = obj.Deserialize(s);
            
            /*
                Inverted
                       1
                        \
                         3
                          \
                           5
            */

            s = "1,X,3,X,5";
            expected = obj.Deserialize(s);
            res = InvertTree(root);
            Assert.True(treeTest.IsSameTree(expected,res));
            
            /*
                Original
                        1
                       / \
                      3   2 
                     /     \
                    5       6
                   /         \
                  7           8  
            */
            
            s = "1,3,5,7,X,X,X,X,2,X,6,X,8";
            root = obj.Deserialize(s);
            
            /*
                Inverted
                        1
                       / \
                      2   3 
                     /     \
                    6       5
                   /         \
                  8           7  
            */
            
            
            s = "1,2,6,8,X,X,X,X,3,X,5,X,7";
            expected = obj.Deserialize(s);
            res = InvertTree(root);
            Assert.True(treeTest.IsSameTree(expected,res));
            
        }
    }
}  