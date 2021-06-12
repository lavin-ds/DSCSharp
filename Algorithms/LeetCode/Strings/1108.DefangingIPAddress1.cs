/*
1108. Defanging an IP Address
https://leetcode.com/problems/defanging-an-ip-address/
Easy

Given a valid (IPv4) IP address, return a defanged version of that IP address.
A defanged IP address replaces every period "." with "[.]". 

Example 1:

Input: address = "1.1.1.1"
Output: "1[.]1[.]1[.]1"

Example 2:

Input: address = "255.100.50.0"
Output: "255[.]100[.]50[.]0" 

Constraints:

    The given address is a valid IPv4 address.

 */
 
using System.Text;
using Xunit;

namespace Algorithms.LeetCode.Strings
{
    public class DefangingIPAddress1
    {
        public string DefangIPaddr(string address) 
        {
            var ip = address.Split('.');
            StringBuilder res = new StringBuilder();
            foreach(var item in ip)
            {
                res.Append(item);
                res.Append("[.]");
            }
            return res.ToString().TrimEnd('[','.',']');            
        }

        [Fact]
        public void TestWrap1()
        {
            string s = "1.1.1.1";       
            Assert.Equal("1[.]1[.]1[.]1", DefangIPaddr(s));

        }
    }
}
