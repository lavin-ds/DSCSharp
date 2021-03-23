using DataStructuresCsharp;
using System.Text;
using Xunit;

namespace DSCTest
{
    public class InfixToPrefix
    {
        public string ConvertInfixToPrefix(string input)
        {
            StackUsingLL<int> staging = new StackUsingLL<int>();
            StackUsingLL<int> result = new StackUsingLL<int>();
            StringBuilder resultString = new StringBuilder();

            // for (int i = (input.Length-1); i=0;i--)
            // {

            // }

            

            return string.Empty;
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