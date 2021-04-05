using System.Runtime.CompilerServices;
using System.Reflection.Emit;
using System.Collections;
/*
146. LRU Cache
https://leetcode.com/problems/lru-cache/
Medium

Design a data structure that follows the constraints of a Least Recently Used (LRU) cache (https://en.wikipedia.org/wiki/Cache_replacement_policies#LRU).

Implement the LRUCache class:

    LRUCache(int capacity) Initialize the LRU cache with positive size capacity.
    int get(int key) Return the value of the key if the key exists, otherwise return -1.
    void put(int key, int value) Update the value of the key if the key exists. Otherwise, add the key-value pair to the cache. If the number of keys exceeds the capacity from this operation, evict the least recently used key.

Follow up:
Could you do get and put in O(1) time complexity?

Example 1:

Input
["LRUCache", "put", "put", "get", "put", "get", "put", "get", "get", "get"]
[[2], [1, 1], [2, 2], [1], [3, 3], [2], [4, 4], [1], [3], [4]]
Output
[null, null, null, 1, null, -1, null, -1, 3, 4]

Explanation
LRUCache lRUCache = new LRUCache(2);
lRUCache.put(1, 1); // cache is {1=1}
lRUCache.put(2, 2); // cache is {1=1, 2=2}
lRUCache.get(1);    // return 1
lRUCache.put(3, 3); // LRU key was 2, evicts key 2, cache is {1=1, 3=3}
lRUCache.get(2);    // returns -1 (not found)
lRUCache.put(4, 4); // LRU key was 1, evicts key 1, cache is {4=4, 3=3}
lRUCache.get(1);    // return -1 (not found)
lRUCache.get(3);    // return 3
lRUCache.get(4);    // return 4

Constraints:

    1 <= capacity <= 3000
    0 <= key <= 3000
    0 <= value <= 104
    At most 3 * 104 calls will be made to get and put.
*/

using System.Collections.Generic;

namespace Algorithms.LeetCode.Design
{
    public class DoublyLLNode
    {
        public DoublyLLNode Prev;
        public DoublyLLNode Next;
        public int Data;

        public DoublyLLNode(int val, DoublyLLNode prev = null, DoublyLLNode next = null)
        {
            Data = val;
            Prev = prev;
            Next = next;
        }
    }
    public class DoublyLinkedList
    {
        public DoublyLLNode head;

        public DoublyLLNode InsertAtHead(int val)
        {
            if(head != null)
            {
                var nodeToAdd = new DoublyLLNode(val);
                nodeToAdd.Next = head;
                head.Prev = nodeToAdd;            
                head = nodeToAdd;            
                return head;
            }   
            head = new DoublyLLNode(val);            
            return head;
        }

        public void UpgradeToHead(DoublyLLNode node)
        {
            if(head!=null)
            {
                var prev = node.Prev;
                var next = node.Next;
                if(prev!=null)
                    prev.Next = next;
                if(next!=null)
                    next.Prev = prev;

                node.Prev = head.Prev;
                node.Next = head;
                head.Prev = node;
                head = node;
                return;
            }
            head = node;
            return;
        }        

        public void RemoveFromTail()
        {
            if(head!= null)
            {
                var temp = head;

                while(temp.Next != null)
                {
                    temp = temp.Next;
                }

                temp.Prev.Next = null;
                temp.Prev = null;
            }            
        }

        public int Length()
        {
            int length = 0;
            if(head!= null)
            {         
                length = 1;       
                var temp = head;

                while(temp.Next != null)
                {
                    length++;
                    temp = temp.Next;
                }                        
            }
            return length;
        }
    }
    
    public class LRUCache 
    {
        public Dictionary<int, DoublyLLNode> nodeMap = new Dictionary<int, DoublyLLNode>();
        public DoublyLinkedList cache = new DoublyLinkedList();
        private int Capacity;

        public LRUCache(int capacity) 
        {
           Capacity = capacity;
        }
            
        public int Get(int key) 
        {
            if(nodeMap.ContainsKey(key))
            {
                cache.UpgradeToHead(nodeMap[key]);
                return nodeMap[key].Data;                
            }
            else
            {
                return cache.head.Data;
            }
        }
        
        public void Put(int key, int value) 
        {
            DoublyLLNode node;
            if(cache.Length() == 0)
            {
                node = cache.InsertAtHead(value);
                nodeMap.Add(key, node);
                return;
            }
            node = cache.InsertAtHead(value);
            nodeMap.Add(key, node);
            if(cache.Length() > Capacity)
                cache.RemoveFromTail();            
        }
    }
}
