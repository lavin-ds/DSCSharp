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

using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Algorithms.LeetCode.PrefixSum
{
    public class ShopClosing
    {
        public int BestClosingTime(string customers)
        {
            var cust = customers.Split();
            var countY = customers.Count(c => c == 'Y');
            var countN = customers.Count(c => c == 'N');
            int visitY = 0, visitN = 0;
            var penalty = new Dictionary<int, int>();

            for (int i = 0; i < cust.Length; i++)
            {
                if (cust[i] == "Y")
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

            penalty.Add(cust.Length + 1, countY - visitY + visitN);
            return penalty.OrderBy(kv => kv.Value).ToDictionary(kv => kv.Key, kv => kv.Value).First().Key;
        }

        [Fact]
        public void TestWrap1()
        {
            var customers1 = "YYNY";

            Assert.Equal(2, BestClosingTime(customers1));

            var customers2 = "YYYY";

            Assert.Equal(4, BestClosingTime(customers2));
        }
    }
}