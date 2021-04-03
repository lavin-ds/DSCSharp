using System.Reflection.Metadata.Ecma335;
/*
142. Linked List Cycle II
https://leetcode.com/problems/linked-list-cycle-ii/
Medium

Given a linked list, return the node where the cycle begins. If there is no cycle, return null.

There is a cycle in a linked list if there is some node in the list that can be reached again by continuously following the next pointer. Internally, pos is used to denote the index of the node that tail's next pointer is connected to. Note that pos is not passed as a parameter.

Notice that you should not modify the linked list.

Example 1:

Input: head = [3,2,0,-4], pos = 1
Output: tail connects to node index 1
Explanation: There is a cycle in the linked list, where tail connects to the second node.

Example 2:

Input: head = [1,2], pos = 0
Output: tail connects to node index 0
Explanation: There is a cycle in the linked list, where tail connects to the first node.

Example 3:

Input: head = [1], pos = -1
Output: no cycle
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
    public class LinkedListCycleII : LinkedListCycle
    {
        public Node DetectCycle() 
    {
        bool hasCycle = false;
        
        var slow = _head;
        var fast = _head;
        
        if(_head!=null)
        {
            while(fast.next!=null && fast.next.next!=null)
            {
                slow = slow.next;
                fast = fast.next.next;
                if(slow == fast)    
                {
                    hasCycle = true;
                    break;
                }
            }
        }

        if(hasCycle)
        {
            slow = _head;
            while (fast!=slow)
            {
                fast = fast.next;
                slow = slow.next;
            }
            return slow;
        }
        return null;
    }

        [Fact]
        public void TestWrapDetectCycle()
        {
            LinkedListCycleII obj = new LinkedListCycleII();
            
            obj.AddAtHead(1);
            obj.AddAtTail(2);
            obj.AddAtTail(3);
            obj.AddAtTail(4);
            obj.AddAtTail(5);

            var res = obj.DetectCycle();
            Assert.Null(res);
 
            obj = new LinkedListCycleII();
            obj.AddAtHead(1);
            obj.AddAtTail(2);
            obj.AddAtTail(3);
            obj.AddAtTail(4);
            obj.AddAtTail(5);
            obj.AddAtTail(6);

            obj.CreateCycle2();
            res = obj.DetectCycle();
            Assert.Equal(3,res.val);
 
            obj = new LinkedListCycleII();
            obj.AddAtHead(1);
            obj.AddAtTail(2);
            obj.AddAtTail(3);
            obj.AddAtTail(4);
            obj.AddAtTail(5);
            obj.AddAtTail(6);

            obj.CreateCycle();
            res = obj.DetectCycle();
            Assert.Equal(1,res.val); 
        } 
    }
}