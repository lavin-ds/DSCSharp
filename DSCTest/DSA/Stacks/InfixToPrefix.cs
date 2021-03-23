using DataStructuresCsharp;
using System.Text;

namespace DSCTest
{
    public class InfixToPrefix
    {
        public string ConvertInfixToPrefix(string input)
        {
            StackUsingLL<int> staging = new StackUsingLL<int>();
            StringBuilder result = new StringBuilder();

            return string.Empty;
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