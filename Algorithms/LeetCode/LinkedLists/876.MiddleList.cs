/*
876. Middle of the Linked List
https://leetcode.com/problems/middle-of-the-linked-list/
Easy

Given a non-empty, singly linked list with head node head, return a middle node of linked list.

If there are two middle nodes, return the second middle node.

Example 1:

Input: [1,2,3,4,5]
Output: Node 3 from this list (Serialization: [3,4,5])
The returned node has value 3.  (The judge's serialization of this node is [3,4,5]).
Note that we returned a ListNode object ans, such that:
ans.val = 3, ans.next.val = 4, ans.next.next.val = 5, and ans.next.next.next = NULL.

Example 2:

Input: [1,2,3,4,5,6]
Output: Node 4 from this list (Serialization: [4,5,6])
Since the list has two middle nodes with values 3 and 4, we return the second one.

Note:

    The number of nodes in the given list will be between 1 and 100.
*/
using Xunit;

namespace Algorithms.LeetCode.LinkedLists
{
    public class MiddleList : MyLinkedList
    {
        public Node MiddleNode() 
        {
            var length = base.ListLength();

            var temp = _head;
            for(int i = 0;i< length/2; i++)
            {
                temp = temp.next;   
            }
            return temp;   
        }

        public Node MiddleNode2() 
        {
            var slow = _head;
            var fast = _head;
            
            while(fast !=null && fast.next !=null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }
                
            return slow;   
        }

        [Fact]
        public void TestWrapMiddleList()
        {
            // Your MyLinkedList object will be instantiated and called as such:
            MiddleList obj = new MiddleList();
            
            obj.AddAtHead(1);
            obj.AddAtTail(2);
            obj.AddAtTail(3);
            obj.AddAtTail(4);
            obj.AddAtTail(5);

            var res = obj.MiddleNode();
            Assert.Equal(3,res.val);
 
            obj = new MiddleList();
            obj.AddAtHead(1);
            obj.AddAtTail(2);
            obj.AddAtTail(3);
            obj.AddAtTail(4);
            obj.AddAtTail(5);
            obj.AddAtTail(6);

            res = obj.MiddleNode();
            Assert.Equal(4,res.val);
        } 

        [Fact]
        public void TestWrapMiddleList2()
        {
            // Your MyLinkedList object will be instantiated and called as such:
            MiddleList obj = new MiddleList();
            
            obj.AddAtHead(1);
            obj.AddAtTail(2);
            obj.AddAtTail(3);
            obj.AddAtTail(4);
            obj.AddAtTail(5);

            var res = obj.MiddleNode2();
            Assert.Equal(3,res.val);
 
            obj = new MiddleList();
            obj.AddAtHead(1);
            obj.AddAtTail(2);
            obj.AddAtTail(3);
            obj.AddAtTail(4);
            obj.AddAtTail(5);
            obj.AddAtTail(6);

            res = obj.MiddleNode2();
            Assert.Equal(4,res.val);
        } 
    }
}