/*********************************************************
Author          - lavinds
Date Created    - 21-Jul-2018
**********************************************************
Sn      Author      Date            Comments
**********************************************************
1.      lavinds   21-Jul-2018       Initial draft of file 
*********************************************************/

/* Converting from Infix to Postfix notation */

#region Namespaces
using System;
using System.Text;
using DataStructuresCsharp;
using Xunit;
#endregion

namespace DSCTest
{
    public class InfixToPostfix
    {
        public string ConvertInfixToPostfix(string infix)
        {
            StackUsingLL<int> staging = new StackUsingLL<int>();
            StringBuilder result = new StringBuilder();
            for(int i = 0;i<infix.Length;i++)
            {
                //If scanned character is an operand
                if(IsOperand(infix[i]))
                {
                    result.Append(infix[i]);
                }

                //If scanned character is '(', push it to stack
                else if(infix[i] == '(')
                {
                    staging.Push('(');
                }

                //If scanned character is ')', pop all  operators from stack until '(' is found
                else if(infix[i] == ')')
                {
                    while(!staging.IsEmpty() && staging.PeekTop() != '(')
                    {
                        result.Append(Convert.ToChar(staging.Pop()));
                    }
                    //Invalid string check
                    if(!staging.IsEmpty() && staging.PeekTop() != '(')
                        {
                            return null;
                        }
                    else
                    {
                        staging.Pop();
                    }
                }

                //If operator
                else
                {
                    while(!staging.IsEmpty() && (CheckPrecedence(infix[i]) <= CheckPrecedence(Convert.ToChar(staging.PeekTop()))))
                    {
                        result.Append(Convert.ToChar(staging.Pop()));
                    }
                    staging.Push(infix[i]);
                }
            }

            while(!staging.IsEmpty())
            {
                result.Append(Convert.ToChar(staging.Pop()));
            }

            return result.ToString();
        }


        public bool  IsOperand(char sym)
        {
            return (sym>='a' && sym <='z') || (sym>='A' && sym <='Z');
        }
        public int CheckPrecedence(char sym)
        {
            switch(sym)
            {
                case '*':
                case '/': 
                    return 9;
                case '+':
                case '-':
                    return 8;
                default: return 0;
            }
        }

        [Fact]
        public void TestWrap()
        {
            string infix = "(A+B)*(C-D)";

            var result = ConvertInfixToPostfix(infix);

            Assert.Equal("AB+CD-*",result);

            infix = "A+B*C";
            
            result = ConvertInfixToPostfix(infix);
            
            Assert.Equal("ABC*+",result);

            infix = "(A+B)*C";
            
            result = ConvertInfixToPostfix(infix);
            
            Assert.Equal("AB+C*",result);

            infix = "A+B*C+D";

            result = ConvertInfixToPostfix(infix);
            
            Assert.Equal("ABC*+D+",result);

            infix = "(A+B)*(C+D)";

            result = ConvertInfixToPostfix(infix);
            
            Assert.Equal("AB+CD+*",result);

            infix = "A*B+C*D";

            result = ConvertInfixToPostfix(infix);
            
            Assert.Equal("AB*CD*+",result);

            infix = "A+B+C+D";

            result = ConvertInfixToPostfix(infix);
            
            Assert.Equal("AB+C+D+",result);

            infix = "A/B+C*D";

            result = ConvertInfixToPostfix(infix);
            
            Assert.Equal("AB/CD*+",result);
        }
    }
}
