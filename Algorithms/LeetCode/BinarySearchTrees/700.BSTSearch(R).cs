/*
700. Search in a Binary Search Tree
https://leetcode.com/problems/search-in-a-binary-search-tree/
Easy

You are given the root of a binary search tree (BST) and an integer val.

Find the node in the BST that the node's value equals val and return the subtree rooted with that node. If such a node does not exist, return null.

Example 1:
                4
               / \
              2   7
             / \
            1   3   
Input: root = [4,2,7,1,3], val = 2
Output: [2,1,3]

Example 2:
                4
               / \
              2   7
             / \
            1   3   

Input: root = [4,2,7,1,3], val = 5
Output: []

Constraints:

    The number of nodes in the tree is in the range [1, 5000].
    1 <= Node.val <= 107
    root is a binary search tree.
    1 <= val <= 107
*/

using Xunit;

namespace Algorithms.LeetCode.BinarySearchTrees
{
    public class BSTSearchRecursive 
    {
        public int val;
        public TreeNode SearchBST(TreeNode root, int val) 
        {
            this.val = val;
            return ITTSearchBST(root);
        }
        
        public TreeNode ITTSearchBST(TreeNode node)
        {
            if(node == null)
                return null;
            
            if(val == node.val)
                return node;
            else if(val>node.val)
            {
            return ITTSearchBST(node.right);
            }
            else
            {
                return ITTSearchBST(node.left);
            }
        }
    }
}