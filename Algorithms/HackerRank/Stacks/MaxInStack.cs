/*********************************************************
Author          - lavinds
Date Created    - 25-Jul-2018
**********************************************************
Sn      Author      Date            Comments
**********************************************************
1.      lavinds   25-Jul-2018       Initial draft of file 
*********************************************************/
/*
You have an empty sequence, and you will be given  queries. Each query is one of these three types:

1 x  -Push the element x into the stack.
2    -Delete the element present at the top of the stack.
3    -Print the maximum element in the stack.
Input Format

The first line of input contains an integer, . The next  lines each contain an above mentioned query. 
(It is guaranteed that each query is valid.)
*/

#region Namespaces
using System;
using DataStructures.ADT;
using Xunit;
#endregion

namespace Algorithms.Stacks
{
    public class MaxInStack
    {
        [Fact]
        public void TestProg()
        {      
            
            var max = 0;
            StackUsingLL<int> obj = new StackUsingLL<int>();
            
            string s = "1 94";
            string t = "3";
            string u = "0";

            for(int i=0;i<3;i++)
            {
                if(s.Length>1)
                {
                    var c = s.Split(' ');
                    obj.Push(Convert.ToInt32(c[1]));
                    s = "";

                    
                }
                else
                {                
                    if(Convert.ToInt16(u) == 2)
                    {
                        obj.Pop();
                        t = "0";
                    }
                    if(Convert.ToInt16(t) == 3)
                    {
                        max = obj.MaxStack();
                        u = "2";

                    }
                }
            }

            Assert.Equal(94,max);
        }
    }
}
