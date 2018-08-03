/*********************************************************
Author          - lavinds
Date Created    - 21-Jul-2018
**********************************************************
Sn      Author      Date            Comments
**********************************************************
1.      lavinds   21-Jul-2018       Initial draft of file 
*********************************************************/

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
            StackUsingLL staging = new StackUsingLL();
            StringBuilder result = new StringBuilder();
            for(int i = 0;i<infix.Length;i++)
            {
                
            }

            return "";
        }

        public int CheckPrecedence(char sym)
        {
            switch(sym)
            {
                case '(':return 10;
                case '*':return 9;
                case '/': return 9;
                case '+':return 8;
                case '-':return 8;
                default: return 0;
            }
        }

        public void TestWrap()
        {
            string infix = "(A+B)*(C-D)";

            var result = ConvertInfixToPostfix(infix);

            Assert.Equal("AB+CD-*",result);
        }
    }
}
