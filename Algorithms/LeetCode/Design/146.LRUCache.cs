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
using Xunit;

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
            if(head!=null && head != node)
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
        
        public void RemoveNode(DoublyLLNode node)
        {
            if(head!=null && head != node)
            {
                var prev = node.Prev;
                var next = node.Next;
                if(prev!=null)
                    prev.Next = next;
                if(next!=null)
                    next.Prev = prev;

                node.Prev = null;
                node.Next = null;                
                return;
            }
            head = null;
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
                
                temp.Data = -1;
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
                if(nodeMap[key].Data != -1)
                {
                    cache.UpgradeToHead(nodeMap[key]);
                    return nodeMap[key].Data;
                }
                return -1;                                
            }
            else
            {
                return -1;
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
            if(nodeMap.ContainsKey(key))
                {
                    cache.RemoveNode(nodeMap[key]);
                    nodeMap[key] = node;
                }
            else
                nodeMap.Add(key, node);
            if(cache.Length() > Capacity)
                cache.RemoveFromTail();
        }
    }

    public class Test 
    {
        [Fact]
        public void TestWrap()
        {      
            LRUCache lRUCache = new LRUCache(2);
            lRUCache.Put(1, 1); // cache is {1=1}
            lRUCache.Put(2, 2); // cache is {1=1, 2=2}

            Assert.Equal(1,lRUCache.Get(1));    // return 1

            lRUCache.Put(3, 3); // LRU key was 2, evicts key 2, cache is {1=1, 3=3}
            Assert.Equal(-1, lRUCache.Get(2));    // returns -1 (not found)
            
            lRUCache.Put(4, 4); // LRU key was 1, evicts key 1, cache is {4=4, 3=3}
            
            Assert.Equal(-1, lRUCache.Get(1));    // return -1 (not found)            
            Assert.Equal(3, lRUCache.Get(3));    // return 3            
            Assert.Equal(4, lRUCache.Get(4));    // return 4
        }

        [Fact]
        public void TestWrap2()
        {      
            LRUCache lRUCache = new LRUCache(1);
            lRUCache.Put(2, 1); // cache is {2=1}
            Assert.Equal(-1, lRUCache.Get(1)); // return -1            
        }

        [Fact]
        public void TestWrap3()
        {      
            LRUCache lRUCache = new LRUCache(1);
            lRUCache.Put(2, 1); // cache is {2=1}
            Assert.Equal(1, lRUCache.Get(2)); // return 1
            lRUCache.Put(3, 2); // cache is {2=1, 3=2}
            Assert.Equal(-1, lRUCache.Get(2)); // return -1
            Assert.Equal(2, lRUCache.Get(3)); // return 2            
        }

        [Fact]
        public void TestWrap4()
        {      
            LRUCache lRUCache = new LRUCache(2);
            lRUCache.Put(2, 1); // cache is {2=1}
            lRUCache.Put(2, 2); // cache is {2=2}
            Assert.Equal(2, lRUCache.Get(2)); // return 2            
            lRUCache.Put(1, 1); // cache is {2=2, 1=1}
            lRUCache.Put(4, 1); // cache is {2=2, 1=1, 4=1}
            Assert.Equal(-1, lRUCache.Get(2)); // return -1            
        }
      
        [Fact]
        public void TestWrap5()
        {      
            LRUCache lRUCache = new LRUCache(2);
            Assert.Equal(-1, lRUCache.Get(2)); // return -1           
            lRUCache.Put(2, 6); // cache is {2=6}
            Assert.Equal(-1, lRUCache.Get(1)); // return -1           
            lRUCache.Put(1, 5); // cache is {2=6, 1=5}
            lRUCache.Put(1, 2); // cache is {2=6, 1=2}
            Assert.Equal(2, lRUCache.Get(1)); // return 2            
            Assert.Equal(6, lRUCache.Get(2)); // return 6
        }


        [Fact]
        public void TestWrap7()
        {      
            LRUCache lRUCache = new LRUCache(4);
            Assert.Equal(-1, lRUCache.Get(2)); // return -1           
            lRUCache.Put(2, 2); // cache is {2=2}
            Assert.Equal(-1, lRUCache.Get(1)); // return -1           
            lRUCache.Put(1, 1); // cache is {2=2, 1=1}
            lRUCache.Put(3, 3); // cache is {2=2, 1=1, 3=3}
            lRUCache.Put(4, 4); // cache is {2=2, 1=1, 3=3, 4=4}
            lRUCache.Put(5, 5); // cache is {1=1, 3=3, 4=4, 5=5}
            Assert.Equal(1, lRUCache.Get(1)); // return 2 // cache is { 3=3, 4=4, 5=5, 1=1}   
            lRUCache.Put(1, 1); // cache is {3=3, 4=4, 5=5, 1=1} 
            Assert.Equal(1, lRUCache.Get(1)); // return 2            
            Assert.Equal(-1, lRUCache.Get(2)); // return 6
        }


        [Fact]
        public void TestWrap6()
        {      
            LRUCache lRUCache = new LRUCache(10);
            lRUCache.Put(10, 13); // cache is {10=13}
            lRUCache.Put(3, 17); // cache is {10=13, 3=17}
            lRUCache.Put(6, 11); // cache is {10=13, 3=17, 6=11}
            lRUCache.Put(10, 5); // cache is {3=17, 6=11, 10=5}
            lRUCache.Put(9, 10); // cache is {3=17, 6=11, 10=5, 9=10}
            Assert.Equal(-1, lRUCache.Get(13)); // return -1
            lRUCache.Put(2, 19); // cache is {3=17, 6=11, 10=5, 9=10, 2=19}
            Assert.Equal(19, lRUCache.Get(2)); // return 19 // cache is {3=17, 6=11, 10=5, 9=10, 2=19}
            Assert.Equal(17, lRUCache.Get(3)); // return 17  // cache is {6=11, 10=5, 9=10, 2=19, 3=17}
            lRUCache.Put(5, 25); // cache is {6=11, 10=5, 9=10, 2=19, 3=17, 5=25}
            Assert.Equal(-1, lRUCache.Get(8)); // return -1
            lRUCache.Put(9, 22); // cache is {6=11, 10=5, 2=19, 3=17, 5=25, 9=22}
            lRUCache.Put(5, 5); // cache is {6=11, 10=5, 2=19, 3=17, 9=22, 5=5}
            lRUCache.Put(1, 30); // cache is {6=11, 10=5, 2=19, 3=17, 9=22, 5=5, 1=30}
            Assert.Equal(-1, lRUCache.Get(11)); // return -1
            lRUCache.Put(9, 12); // cache is {6=11, 10=5, 2=19, 3=17, 5=5, 1=30, 9=12}
            Assert.Equal(-1, lRUCache.Get(7)); // return -1
            Assert.Equal(5, lRUCache.Get(5)); // return 5  // cache is {3=17, 6=11, 10=5, 2=19, 1=30, 9=12, 5=5}
            Assert.Equal(-1, lRUCache.Get(8)); // return -1
            Assert.Equal(12, lRUCache.Get(9)); // return 12 // cache is {3=17, 6=11, 10=5, 2=19, 1=30, 5=5, 9=12}
            lRUCache.Put(4, 30); // cache is {3=17, 6=11, 10=5, 2=19, 1=30, 5=5, 9=12, 4=30}
            lRUCache.Put(9, 3); // cache is {3=17, 6=11, 10=5, 2=19, 1=30, 5=5, 4=30, 9=3}
            Assert.Equal(3, lRUCache.Get(9)); // return 3
            Assert.Equal(5, lRUCache.Get(10)); // return 5 // cache is {3=17, 6=11, 2=19, 1=30, 5=5, 4=30, 9=3, 10=5}
            Assert.Equal(5, lRUCache.Get(10)); // return 5
            lRUCache.Put(6, 14); // cache is {3=17, 2=19, 1=30, 5=5, 4=30, 9=3, 10=5 6=14}
            lRUCache.Put(3, 1); // cache is {2=19, 1=30, 5=5, 4=30, 9=3, 10=5 6=14, 3=1}
            Assert.Equal(1, lRUCache.Get(3)); // return 1
            lRUCache.Put(10, 11); // cache is {2=19, 1=30, 5=5, 4=30, 9=3, 6=14, 3=1, 10=11}
            Assert.Equal(-1, lRUCache.Get(8)); // return -1
            lRUCache.Put(2, 14); // cache is {1=30, 5=5, 4=30, 9=3, 6=14, 3=1, 10=11, 2=14}
            Assert.Equal(30, lRUCache.Get(1)); // return 30 // cache is {5=5, 4=30, 9=3, 6=14, 3=1, 10=11, 2=14, 1=30}
            Assert.Equal(5, lRUCache.Get(5)); // return 5 // cache is {4=30, 9=3, 6=14, 3=1, 10=11, 2=14, 1=30, 5=5}
            Assert.Equal(30, lRUCache.Get(4)); // return 30 // cache is {9=3, 6=14, 3=1, 10=11, 2=14, 1=30, 5=5, 4=30}
            lRUCache.Put(11, 4); // cache is {9=3, 6=14, 3=1, 10=11, 2=14, 1=30, 5=5, 4=30, 11=4}
            lRUCache.Put(12, 24); // cache is {9=3, 6=14, 3=1, 10=11, 2=14, 1=30, 5=5, 4=30, 11=4, 12=24}
            lRUCache.Put(5, 18); // cache is {9=3, 6=14, 3=1, 10=11, 2=14, 1=30, 4=30, 11=4, 12=24, 5=18}
            Assert.Equal(-1, lRUCache.Get(13)); // return -1
            lRUCache.Put(7, 23); // cache is {6=14, 3=1, 10=11, 2=14, 1=30, 4=30, 11=4, 12=24, 5=18, 7=23}
            Assert.Equal(-1, lRUCache.Get(8)); // return -1
            Assert.Equal(24, lRUCache.Get(12)); // return 24 / cache is {6=14, 3=1, 10=11, 2=14, 1=30, 4=30, 11=4, 5=18, 7=23, 12=24}
            lRUCache.Put(3, 27); // cache is {6=14, 10=11, 2=14, 1=30, 4=30, 11=4, 5=18, 7=23, 12=24 3=27}
            lRUCache.Put(2, 12); // cache is {6=14, 10=11, 1=30, 4=30, 11=4, 5=18, 7=23, 12=24 3=27, 2=12}
            Assert.Equal(18, lRUCache.Get(5)); // return 18  // cache is {6=14, 10=11, 1=30, 4=30, 11=4, 7=23, 12=24 3=27, 2=12, 5=18}
            lRUCache.Put(2, 9); // cache is {10=11, 1=30, 4=30, 11=4, 7=23, 12=24 3=27, 2=12, 5=18, 9=2}
            lRUCache.Put(13, 4); // cache is {1=30, 4=30, 11=4, 7=23, 12=24 3=27, 2=12, 5=18, 9=2, 13=4}
            lRUCache.Put(8, 18); // cache is {4=30, 11=4, 7=23, 12=24 3=27, 2=12, 5=18, 9=2, 13=4, 8=18}
            lRUCache.Put(1, 7); // cache is {11=4, 7=23, 12=24 3=27, 2=12, 5=18, 9=2, 13=4, 8=18, 1=7}
            Assert.Equal(-1, lRUCache.Get(6)); // return -1
            lRUCache.Put(9, 29); // cache is {11=4, 7=23, 12=24 3=27, 2=12, 5=18, 13=4, 8=18, 1=7, 9=29}
            lRUCache.Put(8, 21); // cache is {11=4, 7=23, 12=24 3=27, 2=12, 5=18, 13=4, 1=7, 9=29, 8=21}
            Assert.Equal(18, lRUCache.Get(5)); // return 18 // cache is {11=4, 7=23, 12=24 3=27, 2=12, 13=4, 1=7, 9=29, 8=21, 5=18}
            lRUCache.Put(6, 30); // cache is {11=4, 7=23, 12=24 3=27, 2=12, 13=4, 1=7, 9=29, 8=21, 5=18}
            lRUCache.Put(1, 12); // cache is {11=4, 7=23, 12=24 3=27, 2=12, 13=4, 9=29, 8=21, 5=18, 1=12}
            Assert.Equal(-1, lRUCache.Get(10)); // return 11
            lRUCache.Put(4, 15); // cache is {7=23, 12=24 3=27, 2=12, 13=4, 9=29, 8=21, 5=18, 1=12, 4=15}
            lRUCache.Put(7, 22); // cache is {12=24 3=27, 2=12, 13=4, 9=29, 8=21, 5=18, 1=12, 4=15, 7=22}
            lRUCache.Put(11, 26); // cache is {3=27, 2=12, 13=4, 9=29, 8=21, 5=18, 1=12, 4=15, 7=22, 11=26}
            lRUCache.Put(8, 17); // cache is {3=27, 2=12, 13=4, 9=29, 5=18, 1=12, 4=15, 7=22, 11=26, 8=17}
            lRUCache.Put(9, 29); // cache is {3=27, 2=12, 13=4, 5=18, 1=12, 4=15, 7=22, 11=26, 8=17, 9=29}
            Assert.Equal(18, lRUCache.Get(5)); // return 18 // cache is {3=27, 2=12, 13=4, 1=12, 4=15, 7=22, 11=26, 8=17, 9=29, 5=18}
            lRUCache.Put(3, 4); // cache is {2=12, 13=4, 1=12, 4=15, 7=22, 11=26, 8=17, 9=29, 5=18, 3=4}
            lRUCache.Put(11, 30); // cache is {2=12, 13=4, 1=12, 4=15, 7=22, 8=17, 9=29, 5=18, 3=4, 11=30}
            Assert.Equal(-1, lRUCache.Get(12));
            lRUCache.Put(4, 29); // cache is {2=12, 13=4, 1=12, 7=22, 8=17, 9=29, 5=18, 3=4, 11=30, 4=29}
            Assert.Equal(4, lRUCache.Get(3)); // cache is {2=12, 13=4, 1=12, 7=22, 8=17, 9=29, 5=18, 11=30, 4=29, 3=4}
            Assert.Equal(29, lRUCache.Get(9)); // cache is {2=12, 13=4, 1=12, 7=22, 8=17, 5=18, 11=30, 4=29, 3=4, 9=29}
            Assert.Equal(30, lRUCache.Get(6)); 
            lRUCache.Put(3, 4); // cache is {2=12, 13=4, 1=12, 7=22, 8=17, 5=18, 11=30, 4=29, 9=29, 3=4}
            Assert.Equal(12, lRUCache.Get(1));  // cache is {2=12, 13=4, 7=22, 8=17, 5=18, 11=30, 4=29, 9=29, 3=4, 1=12}
            Assert.Equal(-1, lRUCache.Get(10));
        }
    }
}
