/*********************************************************
Author          - lavinds
Date Created    - 25-Jul-2018
**********************************************************
Sn      Author      Date            Comments
**********************************************************
1.      lavinds   25-Jul-2018       Initial draft of file 
*********************************************************/
/*
A bracket is considered to be any one of the following characters: (, ), {, }, [, or ].

Two brackets are considered to be a matched pair if the an opening bracket (i.e., (, [, or {) occurs to the left of a closing bracket (i.e., ), ], or }) of the exact same type. There are three types of matched pairs of brackets: [], {}, and ().

A matching pair of brackets is not balanced if the set of brackets it encloses are not matched. For example, {[(])} is not balanced because the contents in between { and } are not balanced. The pair of square brackets encloses a single, unbalanced opening bracket, (, and the pair of parentheses encloses a single, unbalanced closing square bracket, ].

By this logic, we say a sequence of brackets is balanced if the following conditions are met:

It contains no unmatched brackets.
The subset of brackets enclosed within the confines of a matched pair of brackets is also a matched pair of brackets.
Given  strings of brackets, determine whether each sequence of brackets is balanced. If a string is balanced, return YES. Otherwise, return NO.
 */

#region Namespaces
using System;
using DataStructuresCsharp;
using Xunit;
#endregion

namespace DSCTest.Problems.Stacks
{
    public class BracketMatching
    {
        public bool IsBalanced(string s)
        {
            StackUsingLL obj = new StackUsingLL();

            for(int i = 0;i<s.Length;i++)
            {
                if(s[i] =='{' ||s[i] =='['||s[i] =='(')
                {
                    obj.Push(s[i]);
                }
                else 
                {
                    switch(s[i])
                    {
                        case '}': if(obj.PeekTop() == '{')
                                    {
                                        obj.Pop();
                                    } 
                                    break;
                                    

                        case ']':  if(obj.PeekTop() == '[')
                                    {
                                        obj.Pop();
                                    } 
                                    break;

                        case ')':   if(obj.PeekTop() == '(')
                                    {
                                        obj.Pop();
                                    } 
                                    break;
                    }

                }

            }

            if(obj.StackLength() == 0)
            {
                return true;
            }
            else return false;

        }

        [Fact]
        public void TestWrapper()
        {            
            string s = "([{}])";
            var result = IsBalanced(s);

            Assert.Equal(true, result);
        }
    }
}
