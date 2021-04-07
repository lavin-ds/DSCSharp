/*
206. Reverse Linked List
https://leetcode.com/problems/reverse-linked-list/
Easy

Given the head of a singly linked list, reverse the list, and return the reversed list.

Example 1:

Input: head = [1,2,3,4,5]
Output: [5,4,3,2,1]

Example 2:

Input: head = [1,2]
Output: [2,1]

Example 3:

Input: head = []
Output: []

Constraints:

    The number of nodes in the list is the range [0, 5000].
    -5000 <= Node.val <= 5000
Follow up: A linked list can be reversed either iteratively or recursively. Could you implement both?

*/
using Xunit;

namespace Algorithms.LeetCode.LinkedLists
{
    public class ReverseList : MyLinkedList
    {
        public Node ReverseListIterative(Node head) 
        {
            Node prev = null;
            Node currNode = null;
            while(head!=null)
            {
                currNode = head;
                head = head.next;
                currNode.next = prev;   
                prev = currNode;
            }
            return currNode;   
        }

                
        [Fact]
        public void TestWrapReverseList()
        {
            // Your MyLinkedList object will be instantiated and called as such:
            ReverseList obj = new ReverseList();
            
            obj.AddAtHead(1);
            obj.AddAtTail(2);
            obj.AddAtTail(3);
            obj.AddAtTail(4);
            obj.AddAtTail(5);

            var res = obj.ReverseListIterative(obj._head);
            Assert.Equal(5, res.val);
        } 

        [Fact]
        public void TestWrapReverseList2()
        {
           // Your MyLinkedList object will be instantiated and called as such:
            ReverseList obj = new ReverseList();
            
            obj.AddAtHead(1);
            obj.AddAtTail(2);
            obj.AddAtTail(3);
            obj.AddAtTail(4);
            obj.AddAtTail(5);

            var res = obj.ReverseListIterative(obj._head);
            Assert.Equal(5, res.val);
        } 
    }
}