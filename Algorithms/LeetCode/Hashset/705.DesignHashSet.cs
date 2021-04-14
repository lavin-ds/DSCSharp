/* TODO: Properly with sequence chaining
705. Design HashSet
https://leetcode.com/problems/design-hashset/
Easy

Design a HashSet without using any built-in hash table libraries.

Implement MyHashSet class:

    void add(key) Inserts the value key into the HashSet.
    bool contains(key) Returns whether the value key exists in the HashSet or not.
    void remove(key) Removes the value key in the HashSet. If key does not exist in the HashSet, do nothing.

Example 1:

Input
["MyHashSet", "add", "add", "contains", "contains", "add", "contains", "remove", "contains"]
[[], [1], [2], [1], [3], [2], [2], [2], [2]]
Output
[null, null, null, true, false, null, true, null, false]

Explanation
MyHashSet myHashSet = new MyHashSet();
myHashSet.add(1);      // set = [1]
myHashSet.add(2);      // set = [1, 2]
myHashSet.contains(1); // return True
myHashSet.contains(3); // return False, (not found)
myHashSet.add(2);      // set = [1, 2]
myHashSet.contains(2); // return True
myHashSet.remove(2);   // set = [1]
myHashSet.contains(2); // return False, (already removed)

Constraints:

    0 <= key <= 106
    At most 104 calls will be made to add, remove, and contains.

 
Follow up: Could you solve the problem without using the built-in HashSet library?
*/
using System.Collections.Generic;
using Xunit;

namespace Algorithms.LeetCode.HashSet
{
    public class MyHashSet 
    {

        public List<int>[] bucket;
            
        /** Initialize your data structure here. */
        public MyHashSet() 
        {
            bucket = new List<int>[769];
        }
        
        public void Add(int key) 
        {
            var hash = key%769;
            
            if(Contains(key))        
                return;
            
            if(bucket[hash] == null)
                bucket[hash] = new List<int>();
            bucket[hash].Add(key);
        }
        
        public void Remove(int key) 
        {
            var hash = key%769;
            if(!Contains(key))        
                return;
            
            for(int i = 0; i<bucket[hash].Count; i++)
            {
                if(bucket[hash][i] == key)
                {
                    bucket[hash].RemoveAt(i);
                    return;
                }
            }            
        }
        
        /** Returns true if this set contains the specified element */
        public bool Contains(int key) 
        {
            var hash = key%769;        
            if(bucket[hash] == null)        
                return false;
            
            for(int i = 0; i<bucket[hash].Count; i++)
            {
                if(bucket[hash][i] == key)
                    return true;            
            }
            
            return false;
        }
    }
    
    public class MyHashSetQuick
    {
        
        private bool[] arr;
    
    
        /** Initialize your data structure here. */
        public MyHashSetQuick(int size) 
        {
            arr = new bool[size];
        }
        
        public void Add(int key) 
        {
            arr[key] = true;
        }
        
        public void Remove(int key) 
        {
            arr[key] = false;
        }
        
        /** Returns true if this set contains the specified element */
        public bool Contains(int key) 
        {
            return arr[key];
        }
    }

    public class Test
    {
        [Fact]
        public void TestWrapHashSetQuick()
        {
            MyHashSetQuick myHashSet = new MyHashSetQuick(1000001);
            myHashSet.Add(1);      // set = [1]
            myHashSet.Add(2);      // set = [1, 2]
            Assert.True(myHashSet.Contains(1)); // return True
            Assert.False(myHashSet.Contains(3)); // return False, (not found)
            myHashSet.Add(2);      // set = [1, 2]
            Assert.True(myHashSet.Contains(2)); // return True
            myHashSet.Remove(2);   // set = [1]
            Assert.False(myHashSet.Contains(2)); // return False, (already removed)
        } 

    }
}