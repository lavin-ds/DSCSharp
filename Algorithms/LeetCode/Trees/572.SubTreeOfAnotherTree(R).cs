/*
572. Subtree of Another Tree
Easy

Given the roots of two binary trees root and subRoot, return true if there is a subtree of 
root with the same structure and node values of subRoot and false otherwise.
A subtree of a binary tree tree is a tree that consists of a node in tree and all of this 
node's descendants. The tree tree could also be considered as a subtree of itself.

Example 1:
            root                  subroot  
               3                    4
              / \                  / \ 
             4   5                1   2
            / \
           1   2   
Input: root = [3,4,5,1,2], subRoot = [4,1,2]
Output: true

Example 2:
              root                  subroot  
               3                    4
              / \                  / \ 
             4   5                1   2
            / \
           1   2
              /
             0    
Input: root = [3,4,5,1,2,null,null,null,null,0], subRoot = [4,1,2]
Output: false

Constraints:

    The number of nodes in the root tree is in the range [1, 2000].
    The number of nodes in the subRoot tree is in the range [1, 1000].
    -104 <= root.val <= 104
    -104 <= subRoot.val <= 104
*/

using System;
using Xunit;

namespace Algorithms.LeetCode.Trees
{
    public class SubTreeofTree 
    {
        bool res = false;
        TreeNode sub;
        public bool IsSubtree(TreeNode root, TreeNode subRoot) 
        {
            sub = subRoot;
            if(subRoot == null)
                return true;
            ITT(root);
            return res;
        }
    
        public void ITT(TreeNode root)
        {
            if(root!=null)
            {
                if(root.val == sub.val)
                {
                    if(IsIdentical(root,sub))
                    {    
                        res = true;
                        return;
                    }
                }
                ITT(root.left);
                ITT(root.right);
            }        
        }
        
        public bool IsIdentical(TreeNode root1, TreeNode root2 )
        {
            if(root1==null && root2 == null)
            {
                return true;
            }
            if(root1 ==null || root2 == null)
            {
                return false;
            }
            if(root1.val == root2.val)
            {
                if(IsIdentical(root1.left,root2.left) && IsIdentical(root1.right,root2.right))
                    return true;
            } 
            return false;
        }

        [Fact]
        public void TestWrap()
        {
            /*
                        1                     3            
                       / \                   / \   
                      2   3                 4   5 
                         / \
                        4   5
            */
            var s1 = "1,2,X,X,3,4,X,X,5";
            var s2 = "3,4,X,X,5";
            var obj = new Codec();
            var root1 = obj.Deserialize(s1);
            var root2 = obj.Deserialize(s2);

            Assert.True(IsSubtree(root1, root2));

             /*
                        1                     2
                       / \                   / \   
                      2   3                 4   5
                     / \   \
                    4   5   6
            */
            
            s1 = "1,2,4,X,X,5,X,X,3,X,6";            
            s2 = "2,4,X,X,5";
            root1 = obj.Deserialize(s1);
            root2 = obj.Deserialize(s2);
            Assert.True(IsSubtree(root1, root2));

            /*
                        1                   3
                       / \                 /
                      3   2               5  
                     / 
                    5   
            */
            
            s1 = "1,3,5,X,X,X,2";
            s2 = "3,5";
            root1 = obj.Deserialize(s1);
            root2 = obj.Deserialize(s2);
            Assert.True(IsSubtree(root1, root2));

            /*
                        1                   3
                       /                   / 
                      3                   5  
                     / 
                    5   
            */
            
            s1 = "1,3,5,X,X,X";
            s2 = "3,5";
            root1 = obj.Deserialize(s1);
            root2 = obj.Deserialize(s2);
            Assert.True(IsSubtree(root1, root2));

        }
    }
}  