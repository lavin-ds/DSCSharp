/*
938. Range Sum of BST
https://leetcode.com/problems/range-sum-of-bst/
Easy

Given the root node of a binary search tree, return the sum of values of all nodes with a value in the range [low, high].

Example 1:
                    10
                   /  \
                  5   15
                 / \    \
                3   7   18

Input: root = [10,5,15,3,7,null,18], low = 7, high = 15
Output: 32

Example 2:
                     10
                   /    \
                  5      15
                 / \    /  \
                3   7  13  18
               /   /     
              1   6 
              
Input: root = [10,5,15,3,7,13,18,1,null,6], low = 6, high = 10
Output: 23

Constraints:

    The number of nodes in the tree is in the range [1, 2 * 104].
    1 <= Node.val <= 105
    1 <= low <= high <= 105
    All Node.val are unique.
*/

using Xunit;

namespace Algorithms.LeetCode.BinarySearchTrees
{
    public class RangeSumofBST 
    {
        public int sum = 0, low=0, high=0;
    
        public int RangeSumBST(TreeNode root, int low, int high) {
            this.low = low;
            this.high=high;
            RangeSum(root);
            return sum;
        }

        public void RangeSum(TreeNode root)
        {
            if (root == null)
            {
                return;
            }
            if(root.val>=low && root.val<=high)
            {
                sum = sum + root.val;
            }
            
            if(root.val>low)
                RangeSum(root.left);
            if(root.val<high)
                RangeSum(root.right);
            
        }

        [Fact]
        public void TestWrap()
        {
            var s = "1,2,X,X,3,4,X,X,5";
            var obj = new Codec();
            var root = obj.Deserialize(s);

            var res = RangeSumBST(root,2,4);
            Assert.Equal(9,res);
       }
    }
}