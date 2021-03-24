using DataStructures.ADT;
using System;
using System.Text;
using Xunit;

namespace Algorithms.Stacks
{
    public class InfixToPrefix
    {
        /// <summary>
        /// An optimized method using single stack to convert Infix expr to Prefix expr
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public string ConvertInfixToPrefixOptimized(string input)
        {
            return string.Empty;
        }

        /// <summary>
        /// Method to convert an Infix expr to Prefix (Polish Notation). This method uses 2 stacks to hold the values.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public string ConvertInfixToPrefix(string input)
        {
            StackUsingLL<int> staging = new StackUsingLL<int>();
            StackUsingLL<int> result = new StackUsingLL<int>();
            StringBuilder resultString = new StringBuilder();

            for (int i = input.Length-1; i>=0;i--)
            {
                if( input[i] == ')')
                {
                    staging.Push(input[i]);                    
                }                
                else if(IsOperand(input[i]))
                {
                    result.Push(input[i]);
                }
            
                else if(input[i] == '(')
                {
                    while (staging.PeekTop() != ')')
                    {
                        result.Push(staging.Pop());
                    }
                    staging.Pop();
                }

                else
                {
                    if(!staging.IsEmpty() && CheckPrecedence(input[i]) >= CheckPrecedence(staging.PeekTop()))
                    {
                        staging.Push(input[i]);
                    }
                    else if(!staging.IsEmpty() && CheckPrecedence(input[i]) < CheckPrecedence(staging.PeekTop()))
                    {
                        result.Push(staging.Pop());
                        staging.Push(input[i]);
                    }
                    else if(staging.IsEmpty())
                    {
                        staging.Push(input[i]);
                    }
                }                
            }    

            while(!staging.IsEmpty())    
            {
                result.Push(staging.Pop());
            }

            while(!result.IsEmpty())    
            {
                resultString.Append(Convert.ToChar(result.Pop()));
            }

            return resultString.ToString();
        }
    

        public bool IsOperand(char ip)
        {
            if (ip>='a' && ip <='z' || ip>='A' && ip <='z') 
                return true;
            return false;
        }

        public int CheckPrecedence(int ip)
        {
            switch(ip)
            {
                case '*':
                case '/':
                    {return 10;}
                case '+':
                case '-':
                    {return 9;}
                default :
                    {return 0;}
            }
        }

        [Fact]
        public void TestWrap()
        {
            string infix = "(A+B)*(C-D)";

            var result = ConvertInfixToPrefix(infix);

            Assert.Equal("*+AB-CD",result);

            infix = "A+B*C";
            
            result = ConvertInfixToPrefix(infix);
            
            Assert.Equal("+A*BC",result);

            infix = "(A+B)*C";
            
            result = ConvertInfixToPrefix(infix);
            
            Assert.Equal("*+ABC",result);

            infix = "A+B*C+D";

            result = ConvertInfixToPrefix(infix);
            
            Assert.Equal("++A*BCD",result);

            infix = "(A+B)*(C+D)";

            result = ConvertInfixToPrefix(infix);
            
            Assert.Equal("*+AB+CD",result);

            infix = "A*B+C*D";

            result = ConvertInfixToPrefix(infix);
            
            Assert.Equal("+*AB*CD",result);

            infix = "A+B+C+D";

            result = ConvertInfixToPrefix(infix);
            
            Assert.Equal("+++ABCD",result);

            infix = "A/B+C*D";

            result = ConvertInfixToPrefix(infix);
            
            Assert.Equal("+/AB*CD",result);
        }
    }
}