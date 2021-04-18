/*
662. Maximum Width of Binary Tree
https://leetcode.com/problems/maximum-width-of-binary-tree/
Medium

Given a binary tree, write a function to get the maximum width of the given tree. The maximum width of a tree is the maximum width among all levels.
The width of one level is defined as the length between the end-nodes (the leftmost and right most non-null nodes in the level, where the null nodes between the end-nodes are also counted into the length calculation.
It is guaranteed that the answer will in the range of 32-bit signed integer.

Example 1:

Input: 

           1
         /   \
        3     2
       / \     \  
      5   3     9 

Output: 4
Explanation: The maximum width existing in the third level with the length 4 (5,3,null,9).

Example 2:

Input: 

          1
         /  
        3    
       / \       
      5   3     

Output: 2
Explanation: The maximum width existing in the third level with the length 2 (5,3).

Example 3:

Input: 

          1
         / \
        3   2 
       /        
      5      

Output: 2
Explanation: The maximum width existing in the second level with the length 2 (3,2).

Example 4:

Input: 

          1
         / \
        3   2
       /     \  
      5       9 
     /         \
    6           7
Output: 8
Explanation:The maximum width existing in the fourth level with the length 8 (6,null,null,null,null,null,null,7).

Constraints:

    The given binary tree will have between 1 and 3000 nodes.
*/

using System.Collections.Generic;
using Xunit;
using System;

namespace Algorithms.LeetCode.Trees
{
    public class MaxWidth 
    {
        int maxWidth;
        Dictionary<int,int> positions;
    
        public int WidthOfBinaryTree(TreeNode root) 
        {
            maxWidth = 0;
            positions = new Dictionary<int,int>();
            Width(root,0, 1);
            return maxWidth;     
        }
        
        public void Width(TreeNode node, int level, int pos)
        {
            if(node == null)
                return;

            if(!positions.ContainsKey(level))
            {
                positions.Add(level, pos);
            }

            maxWidth = Math.Max(maxWidth,(pos - positions[level]+1));
            Width(node.left, level+1, 2*pos);   
            Width(node.right, level+1, 2*pos+1);
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
            
            var res = WidthOfBinaryTree(root);
            Assert.Equal(2,res);


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
            
            res = WidthOfBinaryTree(root);
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
            
            res = WidthOfBinaryTree(root);
            Assert.Equal(2,res);

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
            
            res = WidthOfBinaryTree(root);
            Assert.Equal(1,res);

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
            
            res = WidthOfBinaryTree(root);
            Assert.Equal(8,res);
        }
    }
}
