// /*
// 146. LRU Cache
// https://leetcode.com/problems/lru-cache/
// Medium

// Design a data structure that follows the constraints of a Least Recently Used (LRU) cache (https://en.wikipedia.org/wiki/Cache_replacement_policies#LRU).

// Implement the LRUCache class:

//     LRUCache(int capacity) Initialize the LRU cache with positive size capacity.
//     int get(int key) Return the value of the key if the key exists, otherwise return -1.
//     void put(int key, int value) Update the value of the key if the key exists. Otherwise, add the key-value pair to the cache. If the number of keys exceeds the capacity from this operation, evict the least recently used key.

// Follow up:
// Could you do get and put in O(1) time complexity?

// Example 1:

// Input
// ["LRUCache", "put", "put", "get", "put", "get", "put", "get", "get", "get"]
// [[2], [1, 1], [2, 2], [1], [3, 3], [2], [4, 4], [1], [3], [4]]
// Output
// [null, null, null, 1, null, -1, null, -1, 3, 4]

// Explanation
// LRUCache lRUCache = new LRUCache(2);
// lRUCache.put(1, 1); // cache is {1=1}
// lRUCache.put(2, 2); // cache is {1=1, 2=2}
// lRUCache.get(1);    // return 1
// lRUCache.put(3, 3); // LRU key was 2, evicts key 2, cache is {1=1, 3=3}
// lRUCache.get(2);    // returns -1 (not found)
// lRUCache.put(4, 4); // LRU key was 1, evicts key 1, cache is {4=4, 3=3}
// lRUCache.get(1);    // return -1 (not found)
// lRUCache.get(3);    // return 3
// lRUCache.get(4);    // return 4

// Constraints:

//     1 <= capacity <= 3000
//     0 <= key <= 3000
//     0 <= value <= 104
//     At most 3 * 104 calls will be made to get and put.
// */

// using System.Collections.Generic;
// using Xunit;

// namespace Algorithms.LeetCode.Design
// {
//     public class LRUCacheDesign
//     {
//         /// <summary>
//         ///     Use double linked list to implement LRU cache
//         /// </summary>
//         /// <typeparam name="T">Type of the value</typeparam>
//         /// <param name="capacity">Capacity of the cache</param>
//         /// <returns></returns>
//         public class LRUCache<T> where T : class
//         {
//             private readonly Dictionary<int, LinkedListNode<T>> _cache = new Dictionary<int, LinkedListNode<T>>();
//             private readonly LinkedList<T> _cacheList = new LinkedList<T>();
//             private readonly int _capacity;

//             public LRUCache(int capacity)
//             {
//                 _capacity = capacity;
//             }

//             public int Get(int key)
//             {
//                 if (_cache.ContainsKey(key))
//                 {
//                     _cacheList.Remove(_cache[key]);
//                     _cacheList.AddFirst(_cache[key]);
//                     return _cache[key].data;
//                 }
//                 return -1;
//             }

//                         public void Put(int key, T value)
//             {
//                 if (_cache.ContainsKey(key))
//                 {
//                     _cacheList.Remove(_cache[key]);
//                     _cacheList.AddFirst(_cache[key]);
//                     _cache[key].Value = value;
//                 }
//                 else
//                 {
//                     if (_cacheList.Count == _capacity)
//                     {
//                         _cacheList.RemoveLast();
//                         _cache.Remove(_cacheList.Last.Value);
//                     }
//                     _cacheList.AddFirst(key);
//                     _cache.Add(key, _cacheList.First);
//                     _cache[key].Value = value;
//                 }
//             }
//         }

    
    
    
// }
