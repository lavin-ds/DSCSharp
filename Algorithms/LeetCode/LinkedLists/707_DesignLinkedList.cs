/*
707. Design Linked List
https://leetcode.com/problems/design-linked-list/
Medium

Design your implementation of the linked list. You can choose to use a singly or doubly linked list.
A node in a singly linked list should have two attributes: val and next. val is the value of the current node, and next is a pointer/reference to the next node.
If you want to use the doubly linked list, you will need one more attribute prev to indicate the previous node in the linked list. Assume all nodes in the linked list are 0-indexed.

Implement the MyLinkedList class:

MyLinkedList() Initializes the MyLinkedList object.
int get(int index) Get the value of the indexth node in the linked list. If the index is invalid, return -1.
void addAtHead(int val) Add a node of value val before the first element of the linked list. After the insertion, the new node will be the first node of the linked list.
void addAtTail(int val) Append a node of value val as the last element of the linked list.
void addAtIndex(int index, int val) Add a node of value val before the indexth node in the linked list. If index equals the length of the linked list, the node will be appended to the end of the linked list. If index is greater than the length, the node will not be inserted.
void deleteAtIndex(int index) Delete the indexth node in the linked list, if the index is valid.

Example 1:

Input
["MyLinkedList", "addAtHead", "addAtTail", "addAtIndex", "get", "deleteAtIndex", "get"]
[[], [1], [3], [1, 2], [1], [1], [1]]
Output
[null, null, null, null, 2, null, 3]

Explanation
MyLinkedList myLinkedList = new MyLinkedList();
myLinkedList.addAtHead(1);
myLinkedList.addAtTail(3);
myLinkedList.addAtIndex(1, 2);    // linked list becomes 1->2->3
myLinkedList.get(1);              // return 2
myLinkedList.deleteAtIndex(1);    // now the linked list is 1->3
myLinkedList.get(1);              // return 3

Constraints:

0 <= index, val <= 1000
Please do not use the built-in LinkedList library.
At most 2000 calls will be made to get, addAtHead, addAtTail, addAtIndex and deleteAtIndex.
*/
using Xunit;

namespace Algorithms.LeetCode.LinkedLists
{
    public class Node
    {
        public int val;
        public Node next;
    }

    public class MyLinkedList {
        public Node _head;
        
        /** Initialize your data structure here. */
        public MyLinkedList() 
        {

        }
        
        /** Get the value of the index-th node in the linked list. If the index is invalid, return -1. */
        public int Get(int index) 
        {
            if(_head == null)
            {
                return -1;
            }
            if(index ==0)
            {
                return _head.val;
            }

            var temp = _head;
            for(int i = 0; i<index; i++)
            {
                if(temp.next!=null)
                {
                    temp = temp.next;
                }
                else
                    return -1;
            }
            if(temp!=null)
            {
                return temp.val;
            }
            return -1;
        }
        
        /** Add a node of value val before the first element of the linked list. After the insertion, the new node will be the first node of the linked list. */
        public void AddAtHead(int val) 
        {
            if(_head == null)
            {
                _head = new Node();
                _head.val = val;
                _head.next = null;
            }
            else
            {
                var temp = new Node();
                temp.val = val;
                temp.next = _head;
                _head = temp;
            }
        }
        
        /** Append a node of value val to the last element of the linked list. */
        public void AddAtTail(int val) 
        {
            if(_head == null)
            {
                _head = new Node();
                _head.val = val;
                _head.next = null;
            }
            else
            {
                var temp = _head;
                while(temp.next!=null)
                {
                    temp = temp.next;
                }
                var nodeToAdd = new Node();
                nodeToAdd.val = val;
                nodeToAdd.next = null;

                temp.next = nodeToAdd;
            }
        }
        
        public int ListLength()
        {
            if(_head == null)
                return 0;
            
            int length = 1;
            var temp = _head;
            while(temp.next !=null)
            {
                temp = temp.next;
                length++;
            }
            return length;
        }

        /** Add a node of value val before the index-th node in the linked list. If index equals to the length of linked list, the node will be appended to the end of linked list. If index is greater than the length, the node will not be inserted. */
        public void AddAtIndex(int index, int val) 
        {
            if(_head == null && index == 0)
            {
                _head = new Node();
                _head.val = val;
                _head.next = null;
            }
            else if (_head !=null && index ==0)
            {
                var temp = new Node();
                temp.val = val;
                temp.next = _head;
                _head = temp;
            }

            else
            {
                if(ListLength() == index)
                {
                    AddAtTail(val);
                    return;
                }

                var temp = _head;
                for(int i = 0; i < index-1 ; i++)
                {
                    if(temp.next!=null)
                        temp = temp.next;
                    else
                        return;
                }

                if(temp!=null)
                {
                    var node = new Node();
                    node.val = val;
                    node.next = temp.next;
                    temp.next = node;
                }
            }
        }
        
        /** Delete the index-th node in the linked list, if the index is valid. */
        public void DeleteAtIndex(int index) 
        {
            if(_head != null)
            {
                if(index == 0)
                {
                    _head = _head.next;
                    return;
                }

                var temp = _head;
                for(int i= 0; i <index-1;i++)
                {
                    if(temp.next!= null)
                    {
                        temp = temp.next;
                    }
                }

                if(temp.next!=null)
                {
                   if(temp.next.next!=null)
                   {
                       temp.next = temp.next.next;
                   } 
                   else
                   {
                       temp.next = null;
                   }
                }
            }   
        }

        [Fact]
        public void TestWrap()
        {
            // Your MyLinkedList object will be instantiated and called as such:
            MyLinkedList obj = new MyLinkedList();
            
            obj.AddAtHead(2);
            //obj.AddAtTail(2);

            obj.AddAtIndex(0,1);
            obj.AddAtIndex(1,3);
            obj.AddAtIndex(3,4);

            obj.AddAtIndex(6,4);

            obj.DeleteAtIndex(0);
            obj.DeleteAtIndex(2);
            


            //obj.DeleteAtIndex(index);
        }
        
        [Fact]
        public void TestWrap2()
        {
            // Your MyLinkedList object will be instantiated and called as such:
            MyLinkedList obj = new MyLinkedList();
            
            obj.AddAtHead(1);
            obj.AddAtTail(3);

            obj.AddAtIndex(1,2);
            
            var i = obj.Get(1);

            obj.DeleteAtIndex(1);
            obj.Get(1);   
        }

        [Fact]
        public void TestWrap3()
        {
            // Your MyLinkedList object will be instantiated and called as such:
            MyLinkedList obj = new MyLinkedList();
            
            obj.AddAtHead(4);
            var i = obj.Get(1);
            obj.AddAtHead(1);
            obj.AddAtHead(5);
            obj.DeleteAtIndex(3);
            obj.AddAtHead(7);
            i = obj.Get(3);
            i = obj.Get(3);
            i = obj.Get(3);
            obj.AddAtHead(1);
            obj.DeleteAtIndex(4);            
        } 
    }
}