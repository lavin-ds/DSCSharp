/*
141. Linked List Cycle
https://leetcode.com/problems/linked-list-cycle/
Easy

Given head, the head of a linked list, determine if the linked list has a cycle in it.

There is a cycle in a linked list if there is some node in the list that can be reached again by continuously following the next pointer. Internally, pos is used to denote the index of the node that tail's next pointer is connected to. Note that pos is not passed as a parameter.

Return true if there is a cycle in the linked list. Otherwise, return false.

Example 1:

Input: head = [3,2,0,-4], pos = 1
Output: true
Explanation: There is a cycle in the linked list, where the tail connects to the 1st node (0-indexed).

Example 2:

Input: head = [1,2], pos = 0
Output: true
Explanation: There is a cycle in the linked list, where the tail connects to the 0th node.

Example 3:

Input: head = [1], pos = -1
Output: false
Explanation: There is no cycle in the linked list.

Constraints:

    The number of the nodes in the list is in the range [0, 104].
    -105 <= Node.val <= 105
    pos is -1 or a valid index in the linked-list.

Follow up: Can you solve it using O(1) (i.e. constant) memory?
*/
using Xunit;

namespace Algorithms.LeetCode.LinkedLists
{
    public class LinkedListCycle : MyLinkedList
    {
        public bool HasCycle() 
        {
            if(_head!=null)
            {
                var slow = _head;
                var fast = _head;

                while(fast.next!=null && fast.next.next!=null)
                {
                    slow = slow.next;
                    fast = fast.next.next;
                    if(slow == fast)
                        return true;
                }
            }
            return false;
            
        }

        public void CreateCycle() 
        {
            if(_head!=null)
            {
                var temp = _head;
                while(temp.next!=null)
                {
                    temp = temp.next;
                }   
                temp.next = _head;
            }
        }
        public void CreateCycle2() 
        {
            if(_head!=null)
            {
                var temp = _head;
                while(temp.next!=null)
                {
                    temp = temp.next;
                }   
                if(_head.next!=null && _head.next.next!=null)
                    temp.next = _head.next.next;
                else if(_head.next!=null)
                {
                    temp.next = _head.next;
                }
                else
                {
                    temp.next = _head;
                }
            }
        }

        [Fact]
        public void TestWrapHasCycle()
        {
            LinkedListCycle obj = new LinkedListCycle();
            
            obj.AddAtHead(1);
            obj.AddAtTail(2);
            obj.AddAtTail(3);
            obj.AddAtTail(4);
            obj.AddAtTail(5);

            var res = obj.HasCycle();
            Assert.False(res);
 
            obj = new LinkedListCycle();
            obj.AddAtHead(1);
            obj.AddAtTail(2);
            obj.AddAtTail(3);
            obj.AddAtTail(4);
            obj.AddAtTail(5);
            obj.AddAtTail(6);

            obj.CreateCycle2();
            res = obj.HasCycle();
            Assert.True(res);

            obj = new LinkedListCycle();
            obj.AddAtHead(1);
            obj.AddAtTail(2);
            obj.AddAtTail(3);
            obj.AddAtTail(4);
            obj.AddAtTail(5);
            obj.AddAtTail(6);

            obj.CreateCycle();
            res = obj.HasCycle();
            Assert.True(res); 
        } 
    }
}