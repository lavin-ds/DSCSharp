/*
2. Add Two Numbers
https://leetcode.com/problems/add-two-numbers/
Medium

You are given two non-empty linked lists representing two non-negative integers. The digits are stored in reverse order, and each of their nodes contains a single digit. Add the two numbers and return the sum as a linked list.
You may assume the two numbers do not contain any leading zero, except the number 0 itself.

Example 1:
            2➡️4➡️3➡️null
            5➡️6➡️4➡️null
            -----------
            7➡️0➡️8➡️null

Input: l1 = [2,4,3], l2 = [5,6,4]
Output: [7,0,8]
Explanation: 342 + 465 = 807.

Example 2:
            0➡️null
            0➡️null   
            ------
            0➡️null  

Input: l1 = [0], l2 = [0]
Output: [0]

Example 3:
            9➡️9➡️9➡️9➡️9➡️9➡️9➡️null
            9➡️9➡️9➡️9➡️null
            ------------------
            8➡️9➡️9➡️9➡️0➡️0➡️0➡️1➡️null

Input: l1 = [9,9,9,9,9,9,9], l2 = [9,9,9,9]
Output: [8,9,9,9,0,0,0,1]

Constraints:

    The number of nodes in each linked list is in the range [1, 100].
    0 <= Node.val <= 9
    It is guaranteed that the list represents a number that does not have leading zeros.
*/

using System.Numerics;
using Xunit;

namespace Algorithms.LeetCode.LinkedLists
{
    public class ListNode 
    {
        public int val;
        public ListNode next;
        public ListNode(int val=0, ListNode next=null) {
            this.val = val;
            this.next = next;
        }
    }
    public class AddTwoNums
    {
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2) 
        {
            BigInteger sum  = FetchNumber(l1) + FetchNumber(l2);
            if(sum ==0)
            {
                return new ListNode(0, null);
            }
            var res = CreateNode(sum); 
            return res;
        }
    
        private BigInteger FetchNumber(ListNode l)
        {
            BigInteger num = 0;
            BigInteger multi = 1;
            while(l != null)
            {
                num += l.val * multi;
                multi = multi*10;
                l = l.next;
            }
            return num;
        }
    
        private ListNode CreateNode(BigInteger num)
        {
            if(num<1)
                return null;
            
            var output = new ListNode((int)(num%10), CreateNode(num/10)); 
            return output;
        }

        [Fact]
        public void TestWrap1()
        {
            ListNode tail1 = new ListNode(3,null);
            ListNode prev1 = new ListNode(4,tail1);
            ListNode head1 = new ListNode(2, prev1);

            ListNode tail2 = new ListNode(4,null);
            ListNode prev2 = new ListNode(6,tail2);
            ListNode head2 = new ListNode(5, prev2);

            ListNode restail = new ListNode(8,null);
            ListNode resprev = new ListNode(0,restail);
            ListNode reshead = new ListNode(7, resprev);
            
            Assert.Equal(reshead.val, AddTwoNumbers(head1, head2).val);

        }

        [Fact]
        public void TestWrap2()
        {
            ListNode head1 = new ListNode(0, null);
            ListNode head2 = new ListNode(0, null);

            ListNode reshead = new ListNode(0, null);
            
            Assert.Equal(reshead.val, AddTwoNumbers(head1, head2).val);
        }

    }
}