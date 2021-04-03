using System;
using System.Collections;
/*
449. Serialize and Deserialize BST
https://leetcode.com/problems/serialize-and-deserialize-bst/
Medium

Serialization is converting a data structure or object into a sequence of bits so that it can be stored in a file or memory buffer, or transmitted across a network connection link to be reconstructed later in the same or another computer environment.

Design an algorithm to serialize and deserialize a binary search tree. There is no restriction on how your serialization/deserialization algorithm should work. You need to ensure that a binary search tree can be serialized to a string, and this string can be deserialized to the original tree structure.

The encoded string should be as compact as possible.

Example 1:

Input: root = [2,1,3]
Output: [2,1,3]

Example 2:

Input: root = []
Output: []

Constraints:

    The number of nodes in the tree is in the range [0, 104].
    0 <= Node.val <= 104
    The input tree is guaranteed to be a binary search tree.
*/

using System.Text;
using Xunit;

namespace Algorithms.LeetCode.BinarySearchTrees
{
    public class TreeNode 
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }
  
    public class Codec 
    {
        StringBuilder _serialized;    
        // Encodes a tree to a single string.
        public string Serialize(TreeNode root) {
            if(root!=null)
            {
                _serialized = new StringBuilder();
                ITT(root);
                return _serialized.ToString().TrimEnd(',');
            }
            return string.Empty;
        }
        
        public void ITT(TreeNode node)
        {
            if(node!=null)
            {
                _serialized.Append(node.val);
                _serialized.Append(",");
                ITT(node.left);
                ITT(node.right);
            }
            else
            {
                _serialized.Append("X,");
            } 
        }
        
        private int _pos;

        public TreeNode Deserialize(string s)
        {
            _pos = -1;
            if(s.Length>0)
            {
                return TreeBuilder(s.Split(','));
            }
            return null;
        }

        public TreeNode TreeBuilder(string[] s)
        {
            _pos++;
            if(_pos>s.Length-1)
            {
                return null;
            }
            if(s[_pos] == "X")
            {
                return null;
            }
            TreeNode node = new TreeNode(Convert.ToInt16(s[_pos]));
            node.left = TreeBuilder(s);
            node.right = TreeBuilder(s);
            
            return node;
        }

        [Fact]
        public void TestWrap()
        {
            var s = "1,2,X,X,3,4,X,X,5";
            var result = Deserialize(s);

            var res = Serialize(result);
            Assert.Equal("1,2,X,X,3,4,X,X,5,X,X",res);
            result = Deserialize(res);
       }
    }
}