/*
21. Best Time to Buy and Sell Stock
https://leetcode.com/problems/best-time-to-buy-and-sell-stock/
Easy

You are given an array prices where prices[i] is the price of a given stock on the ith day.

You want to maximize your profit by choosing a single day to buy one stock and choosing a different day in the future to sell that stock.

Return the maximum profit you can achieve from this transaction. If you cannot achieve any profit, return 0.

Example 1:

Input: prices = [7,1,5,3,6,4]
Output: 5
Explanation: Buy on day 2 (price = 1) and sell on day 5 (price = 6), profit = 6-1 = 5.
Note that buying on day 2 and selling on day 1 is not allowed because you must buy before you sell.

Example 2:

Input: prices = [7,6,4,3,1]
Output: 0
Explanation: In this case, no transactions are done and the max profit = 0.

Constraints:

    1 <= prices.length <= 105
    0 <= prices[i] <= 104
 */

using Xunit;
using System;
namespace Algorithms.LeetCode.Arrays
{
    public class BuySellStock 
    {
        public int MaxProfit(int[] prices) {
            
            int profit = 0;
            int lowest =0;
            int highest = 0;
            
            if(prices.Length!= 0)
                lowest = prices[0];
            
            for(int i=1; i<prices.Length; i++)
            {   
                
                if(prices[i]< lowest)
                {
                    if(highest>0 && highest > lowest)
                    {
                        profit = (highest - lowest)>profit?highest-lowest:profit;
                    }
                    
                    lowest = prices[i];      
                    highest = 0;
                    
                }
                else if(prices[i]>highest)
                {
                    highest = prices[i];
                    
                    if(highest>0 && highest > lowest)
                    {
                        profit = (highest - lowest)>profit?highest-lowest:profit;
                    }
                }                
            }
            
            return profit;
        }
        
        public int MaxProfitOptimized(int[] prices) 
        {            
            if(prices.Length < 1)
            {
                return 0;
            }

            int profit = int.MinValue;
            int buyPrice = int.MaxValue;

            foreach(var price in prices)
            {
                buyPrice = (Math.Min(buyPrice, price));
                profit = (Math.Max(profit, price- buyPrice));
            }
            return profit;
        }
        
        [Fact]
        public void TestWrapper1()
        {
            int[] arr1 = {1,7,5,0,6};
            var result = MaxProfit(arr1);
            Assert.Equal(6, result);

            int[] arr2 = {7,1,5,3,6,4};
            result = MaxProfit(arr2);
            Assert.Equal(5, result);

            int[] arr3 = {7,6,4,3,1};
            result = MaxProfit(arr3);
            Assert.Equal(0, result);
        }
                
        [Fact]
        public void TestWrapper2()
        {
            int[] arr1 = {1,7,5,0,6};
            var result = MaxProfitOptimized(arr1);
            Assert.Equal(6, result);

            int[] arr2 = {7,1,5,3,6,4};
            result = MaxProfitOptimized(arr2);
            Assert.Equal(5, result);

            int[] arr3 = {7,6,4,3,1};
            result = MaxProfitOptimized(arr3);
            Assert.Equal(0, result);
        }

    }
}
