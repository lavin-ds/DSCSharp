using System.Data;
using System.Reflection.Metadata.Ecma335;
/*
20. Valid Parentheses
https://leetcode.com/problems/valid-parentheses/
Easy

Given a string s containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.

An input string is valid if:

    Open brackets must be closed by the same type of brackets.
    Open brackets must be closed in the correct order.

Example 1:

Input: s = "()"
Output: true

Example 2:

Input: s = "()[]{}"
Output: true

Example 3:

Input: s = "(]"
Output: false

Example 4:

Input: s = "([)]"
Output: false

Example 5:

Input: s = "{[]}"
Output: true

Constraints:

    1 <= s.length <= 104
    s consists of parentheses only '()[]{}'.
 */

using Xunit;
using System.Collections;
using System;

namespace Algorithms.LeetCode.Stacks
{
    public class ValidParentheses 
    {
        public bool IsValid(string s) 
        {
            Stack stage = new Stack();
            for(int i = 0; i<s.Length; i++)
            {    

                if(s[i] ==  '(' || s[i] == '{'  || s[i] == '[')
                {
                    stage.Push(s[i]);
                }
                else
                {
                    if(stage.Count > 0)
                    {
                        switch(s[i])
                        {
                            case ')' :
                                if(Convert.ToChar(stage.Peek()) == '(')
                                    stage.Pop();
                                else 
                                    return false;                        
                                break;
                            case ']' :
                                if(Convert.ToChar(stage.Peek()) == '[')
                                    stage.Pop();
                                else 
                                    return false;
                                break;
                            case '}' :
                                if(Convert.ToChar(stage.Peek()) == '{')
                                    stage.Pop();
                                else 
                                    return false;
                                break;
                        }
                    }
                    else
                        return false;
                }               
            }
            
            if(stage.Count == 0)
                    return true;
            return false;
        }        
        
        [Fact]
        public void TestWrapper1()
        {
            string s = "([{}])";
            var result = IsValid(s);

            Assert.True(result);

            s = "()";
            result = IsValid(s);

            Assert.True(result);

            s = "()[]{}";
            result = IsValid(s);

            Assert.True(result);

            s = "(]";
            result = IsValid(s);

            Assert.False(result);

            s = "([)]";
            result = IsValid(s);

            Assert.False(result);
            
            s = "{[]}";
            result = IsValid(s);

            Assert.True(result);
        }
    }
}
