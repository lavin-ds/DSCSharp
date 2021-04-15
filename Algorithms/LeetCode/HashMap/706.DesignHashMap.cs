/* 706. Design HashMap
https://leetcode.com/problems/design-hashmap/
Easy

Design a HashMap without using any built-in hash table libraries.

Implement the MyHashMap class:

    MyHashMap() initializes the object with an empty map.
    void put(int key, int value) inserts a (key, value) pair into the HashMap. If the key already exists in the map, update the corresponding value.
    int get(int key) returns the value to which the specified key is mapped, or -1 if this map contains no mapping for the key.
    void remove(key) removes the key and its corresponding value if the map contains the mapping for the key.

Example 1:

Input
["MyHashMap", "put", "put", "get", "get", "put", "get", "remove", "get"]
[[], [1, 1], [2, 2], [1], [3], [2, 1], [2], [2], [2]]
Output
[null, null, null, 1, -1, null, 1, null, -1]

Explanation
MyHashMap myHashMap = new MyHashMap();
myHashMap.put(1, 1); // The map is now [[1,1]]
myHashMap.put(2, 2); // The map is now [[1,1], [2,2]]
myHashMap.get(1);    // return 1, The map is now [[1,1], [2,2]]
myHashMap.get(3);    // return -1 (i.e., not found), The map is now [[1,1], [2,2]]
myHashMap.put(2, 1); // The map is now [[1,1], [2,1]] (i.e., update the existing value)
myHashMap.get(2);    // return 1, The map is now [[1,1], [2,1]]
myHashMap.remove(2); // remove the mapping for 2, The map is now [[1,1]]
myHashMap.get(2);    // return -1 (i.e., not found), The map is now [[1,1]]

Constraints:

    0 <= key, value <= 106
    At most 104 calls will be made to put, get, and remove.

 

Follow up: Please do not use the built-in HashMap library.
*/

using System;
using System.Collections.Generic;
using Xunit;

namespace Algorithms.LeetCode.HashMap
{
    public class MyHashMap 
    {
        public int range = 500;
        public List<Tuple<int,int>>[] bucket;
        
        /** Initialize your data structure here. */
        public MyHashMap() {
            bucket = new List<Tuple<int,int>>[769];
        }
        
        /** value will always be non-negative. */
        public void Put(int key, int value) {
            var hash = key%range;
            
            if(Get(key) != -1) 
                Remove(key);
            
            if(bucket[hash] == null)
                bucket[hash] =  new List<Tuple<int,int>>();
            bucket[hash].Add(new Tuple<int,int>(key, value));
        }
        
        /** Returns the value to which the specified key is mapped, or -1 if this map contains no mapping for the key */
        public int Get(int key) 
        {
            var hash = key%range;        
            if(bucket[hash] == null)        
                return -1;
            
            for(int i = 0; i<bucket[hash].Count; i++)
            {
                if(bucket[hash][i].Item1 == key)
                    return bucket[hash][i].Item2;            
            }
            
            return -1;
        }
        
        /** Removes the mapping of the specified value key if this map contains a mapping for the key */
        public void Remove(int key) {
            
            var hash = key%range;
            
            if(Get(key) == -1)        
                return;
            
            for(int i = 0; i< bucket[hash].Count; i++)
            {
                if(bucket[hash][i].Item1 == key)
                {
                    bucket[hash].RemoveAt(i);
                    return;
                }
            }            
        }
    }
    
    public class MyHashMapQuick
    {   
        private int[] arr;    
    
        /** Initialize your data structure here. */
        public MyHashMapQuick() 
        {
            arr = new int[1000001];
            for(int i = 0;i<arr.Length;i++)
            {
                arr[i] = -1;
            }
        }
        
        public void Put(int key, int value) 
        {
            arr[key] = value;
        }
        
        public void Remove(int key) 
        {
            arr[key] = -1;
        }
        
        /** Returns the value to which the specified key is mapped, or -1 if this map contains no mapping for the key */
        public int Get(int key) 
        {
            return arr[key];
        }
    }
   
}