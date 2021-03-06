/*
101. Symmetric Tree
https://leetcode.com/problems/symmetric-tree/
Easy

Given the root of a binary tree, check whether it is a mirror of itself (i.e., symmetric around its center).

Example 1:

                      1
                   /  |  \
                  2   |   2
                 / \  |  / \
                3   4 | 4   3
      
Input: root = [1,2,2,3,4,4,3]
Output: true

Example 2:
                     1
                   /   \
                  2     2
                   \     \
                    3     3

Input: root = [1,2,2,null,3,null,3]
Output: false

Constraints:

    The number of nodes in the tree is in the range [1, 1000].
    -100 <= Node.val <= 100

Follow up: Could you solve it both recursively and iteratively?
*/

using System.Collections.Generic;
using Xunit;

namespace Algorithms.LeetCode.Trees
{
    public class SymmetricBTree 
    {
        public bool IsSymmetric(TreeNode root) 
        {
            if(root!=null)
            {
                return IsSymmetricTree(root.left, root.right);
            }
            return false;
        }
    
        public bool IsSymmetricTree(TreeNode p, TreeNode q) 
        {
                if(p==null && q == null)
                    return true;
                if(p==null || q == null)
                    return false;
                if(p.val == q.val)
                {
                    if(IsSymmetricTree(p.left,q.right) && IsSymmetricTree(p.right,q.left))
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
                        1
                       / \
                      2   3
                         / \
                        4   5
            */
            var s = "1,2,X,X,3,4,X,X,5";
            var obj = new Codec();
            var root = obj.Deserialize(s);

            Assert.False(IsSymmetric(root));


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

            Assert.False(IsSymmetric(root));

             /*
                         1
                       /   \
                      2     2
                     / \   / \
                    4   5 5   4
            */
            
            s = "1,2,4,X,X,5,X,X,2,5,X,X,4";
            obj = new Codec();
            root = obj.Deserialize(s);

            Assert.True(IsSymmetric(root));
        }
    }
}