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
using DataStructuresCsharp;
using Xunit;
#endregion

namespace DSCTest
{
    public class EqualStacks
    {


        public int EqualStacks_Method(int[] h1, int[] h2, int[] h3)
        {
            StackUsingLL<int> obj1= new StackUsingLL<int>();
            
            for(int i = h1.Length-1;i>=0;i--)
            {
                obj1.Push(h1[i]);
            }
            
            StackUsingLL<int> obj2= new StackUsingLL<int>();
            
            for(int i = h2.Length-1;i>=0;i--)
            {
                obj2.Push(h2[i]);
            }
            
            StackUsingLL<int> obj3= new StackUsingLL<int>();
            
            for(int i = h3.Length-1;i>=0;i--)
            {
                obj3.Push(h3[i]);
            }
            
            while
                (
                    obj1.SumStack() != obj2.SumStack() ||
                    obj2.SumStack() != obj3.SumStack() ||
                    obj1.SumStack() != obj3.SumStack()
                )                    
            {
                
                var c =  Math.Max(obj1.SumStack(),Math.Max(obj2.SumStack(), obj3.SumStack()));

                if(c == obj1.SumStack())
                {
                    obj1.Pop();
                }
                
                else if(c == obj2.SumStack())
                {
                    obj2.Pop();
                }  
                else if(c == obj3.SumStack())
                {
                    obj3.Pop();
                }  
            }
            
            return obj1.SumStack();

           }
    

        [Fact]
        public void TestWrapper()
        {     

            int[] h1 =  {3, 2, 1, 1, 1};

            int[] h2 = {4,3,2};
            
            int[] h3 = {1,1,4,1};
            
            int result = EqualStacks_Method(h1, h2, h3);

            Assert.Equal(5,result);
        }
    }
}
