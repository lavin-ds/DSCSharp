/*
617. Merge Two Binary Trees
https://leetcode.com/problems/merge-two-binary-trees/
Easy

You are given two binary trees root1 and root2.

Imagine that when you put one of them to cover the other, some nodes of the two trees are overlapped while the others are not. You need to merge the two trees into a new binary tree. The merge rule is that if two nodes overlap, then sum node values up as the new value of the merged node. Otherwise, the NOT null node will be used as the node of the new tree.

Return the merged tree.

Note: The merging process must start from the root nodes of both trees.

Example 1:

            1                  2                        3
           / \                / \                      / \ 
          3   2              1   3          =>        4   5
         /                    \   \                  / \   \
        5                      4   7                5  4    7
         
Input: root1 = [1,3,2,5], root2 = [2,1,3,null,4,null,7]
Output: [3,4,5,5,4,null,7]

Example 2:

Input: root1 = [1], root2 = [1,2]
Output: [2,2]

Constraints:

    The number of nodes in both trees is in the range [0, 2000].
    -104 <= Node.val <= 104
*/

using Xunit;

namespace Algorithms.LeetCode.Trees
{
    public class MergeBinaryTrees 
    {
        public TreeNode MergeTrees(TreeNode root1, TreeNode root2) 
        {
            return Merge(root1,root2);       
        }
    
        public TreeNode Merge(TreeNode node1, TreeNode node2)
        {
            if(node1==null && node2 == null)
                return null;
            
            if(node1 == null)
            {
                return node2;
            }
            else if(node2==null)
            {
                return node1; 
            } 
            else
            {
                var newNode =  new TreeNode(node1.val+node2.val);
                newNode.left = Merge(node1.left,node2.left);
                newNode.right = Merge(node1.right,node2.right);
                return newNode;
            }
        }
    }
}
