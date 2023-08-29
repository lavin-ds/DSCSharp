/*
2483. Minimum Penalty for a shop
https://leetcode.com/problems/minimum-penalty-for-a-shop/
Medium

You are given the customer visit log of a shop represented by a 0-indexed string customers consisting only of 
characters 'N' and 'Y':

    if the ith character is 'Y', it means that customers come at the ith hour
    whereas 'N' indicates that no customers come at the ith hour.

If the shop closes at the jth hour (0 <= j <= n), the penalty is calculated as follows:

    For every hour when the shop is open and no customers come, the penalty increases by 1.
    For every hour when the shop is closed and customers come, the penalty increases by 1.

Return the earliest hour at which the shop must be closed to incur a minimum penalty.
Note that if a shop closes at the jth hour, it means the shop is closed at the hour j.

Example 1:

Input: customers = "YYNY"
Output: 2
Explanation: 
- Closing the shop at the 0th hour incurs in 1+1+0+1 = 3 penalty.
- Closing the shop at the 1st hour incurs in 0+1+0+1 = 2 penalty.
- Closing the shop at the 2nd hour incurs in 0+0+0+1 = 1 penalty.
- Closing the shop at the 3rd hour incurs in 0+0+1+1 = 2 penalty.
- Closing the shop at the 4th hour incurs in 0+0+1+0 = 1 penalty.
Closing the shop at 2nd or 4th hour gives a minimum penalty. Since 2 is earlier, the optimal closing time is 2.

Example 2:

Input: customers = "NNNNN"
Output: 0
Explanation: It is best to close the shop at the 0th hour as no customers arrive.

Example 3:

Input: customers = "YYYY"
Output: 4
Explanation: It is best to close the shop at the 4th hour as customers arrive at each hour.

 

Constraints:

    1 <= customers.length <= 105
    customers consists only of characters 'Y' and 'N'.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Algorithms.LeetCode.PrefixSum
{
    public class ShopClosing
    {
        public int BestClosingTime(string customers)
        {
            var countY = customers.Count(c => c == 'Y');
            int visitY = 0, visitN = 0;
            var penalty = new Dictionary<int, int>();

            for (int i = 0; i < customers.Length; i++)
            {
                if (customers[i] == 'Y')
                {
                    penalty.Add(i, countY - visitY + visitN);
                    visitY++;
                }
                else
                {
                    penalty.Add(i, countY - visitY + visitN);
                    visitN++;
                }
            }

            penalty.Add(customers.Length, countY - visitY + visitN);
            return penalty.OrderBy(kv => kv.Value).ToDictionary(kv => kv.Key, kv => kv.Value).First().Key;
        }

        public int BestClosingTime2(string customers)
        {
            //The count of Y is just a relative constant. We can eliminate this,
            //and start the reference for calculation where ever we like
            //We can also calculate the min and hour position in a single pass.

            //var countY = customers.Count(c => c == 'Y');
            int cur_pen = 0, min_pen = Int32.MaxValue, hour = 0;
            int visitY = 0, visitN = 0;

            for (int i = 0; i < customers.Length; i++)
            {
                if (customers[i] == 'Y')
                {
                    cur_pen = visitN - visitY;
                    if (cur_pen < min_pen)
                    {
                        min_pen = cur_pen;
                        hour = i;
                    }
                    visitY++;
                }
                else
                {
                    cur_pen = visitN - visitY;
                    if (cur_pen < min_pen)
                    {
                        min_pen = cur_pen;
                        hour = i;
                    }
                    visitN++;
                }
            }

            cur_pen = visitN - visitY;
            if (cur_pen < min_pen)
            {
                min_pen = cur_pen;
                hour = customers.Length;
            }

            return hour;
        }

        [Fact]
        public void TestWrap1()
        {
            var customers1 = "YYNY";

            Assert.Equal(2, BestClosingTime(customers1));

            var customers2 = "YYYY";

            Assert.Equal(4, BestClosingTime(customers2));

            var customers3 = "YN";

            Assert.Equal(1, BestClosingTime(customers3));
        }

        [Fact]
        public void TestWrap2()
        {
            var customers1 = "YYNY";

            Assert.Equal(2, BestClosingTime2(customers1));

            var customers2 = "YYYY";

            Assert.Equal(4, BestClosingTime2(customers2));

            var customers3 = "YN";

            Assert.Equal(1, BestClosingTime2(customers3));
        }
    }
}