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

        public void TestWrap()
        {
            string infix = "A+B*(C-D)";

            var result = ConvertInfixToPostfix(infix);

            Assert.Equal("AB+CD-*",result);
        }
    }
}
