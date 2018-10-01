/*********************************************************
Author          - lavinds
Date Created    - 30-Jul-2018
**********************************************************
Sn      Author      Date            Comments
**********************************************************
1.      lavinds   30-Jul-2018       Initial draft of file 
*********************************************************/
/*
Alexa has two stacks of non-negative integers, stack  and stack  where index denotes the top of the stack. 
Alexa challenges Nick to play the following game:

In each move, Nick can remove one integer from the top of either stack  or stack .
Nick keeps a running sum of the integers he removes from the two stacks.
Nick is disqualified from the game if, at any point, his running sum becomes greater than some integer  
given at the beginning of the game.
Nick's final score is the total number of integers he has removed from the two stacks.
Given , , and  for  games, find the maximum possible score Nick can achieve (i.e., the maximum number of 
integers he can remove without being disqualified) 
during each game and print it on a new line.
*/

#region Namespaces
using System;
using DataStructuresCsharp;
using Xunit;
#endregion

namespace DSCTest
{
    public class GameOfTwoStacks
    { 
        static int TwoStacks(int x, int[] a, int[] b) 
        {
            var obj1 = new StackUsingLL<int>();
            var sumStack = new StackUsingLL<int>();
            for (int i=a.Length-1;i>=0;i--)
            {
                obj1.Push(a[i]);
            }

            var obj2 = new StackUsingLL<int>();
            for (int i=b.Length-1;i>=0;i--)
            {
                obj2.Push(b[i]);
            }

            while(sumStack.SumStack()+obj1.PeekTop()<=x)
            {
                sumStack.Push(obj1.Pop());
            }

            
            int countStack1 = sumStack.StackLength();
            int sum = sumStack.SumStack();
            int max = countStack1;
            int countStack2 = 0;
            while(obj2.StackLength()!=0 && sumStack.StackLength() >0)
            {
                sum = sum + obj2.Pop();
                countStack2++;
                if(sum>x)
                {
                    sum = sum - sumStack.Pop();
                    countStack1--;
                }
                if(sum<=x && countStack1+countStack2>max)
                {
                    max = countStack1+countStack2;
                }
            }
            return max;
        }
        
        [Fact]
        public void TestProg()
        {       
            int limit = 10;

            int [] a = {4, 2, 4, 6, 1};
            int [] b = {2, 1, 8, 5};

            var c = TwoStacks(limit, a, b);

            Assert.Equal(4,c);
                        
        }

         [Fact]
        public void TestProg2()
        {       
            int limit = 62;

            int [] a = {7, 15, 12, 0, 5, 18, 17, 2, 10, 15, 4, 2, 9, 15, 13, 12, 16};
            int [] b = {12, 16, 6, 8, 16, 15, 18, 3, 11, 0, 17, 7, 6, 11, 14, 13, 15, 6, 18, 6, 16, 12, 16, 11, 16, 11};

            var c = TwoStacks(limit, a, b);

            Assert.Equal(6,c);
                        
        }

        //         sum1 = sum + obj1.PeekTop();
    //         sum2 = sum + obj2.PeekTop();
    //         if(sum1<=x && sum1 > sum2)
    //         {
    //             sum += obj1.Pop();
    //             sum1 = sum;
    //             sum2 = sum;
    //             count++;
    //         }
    //         else if( sum2<=x)
    //         {
    //             sum += obj2.Pop();
    //             sum1 = sum;
    //             sum2 = sum;
    //             count++;
    //         }
    //         else if(sum1 <=x)
    //         {
    //             sum += obj1.Pop();
    //             sum1 = sum;
    //             sum2 = sum;
    //             count++;
    //         }
    //         else
    //         {
    //             break;
    //         }            
    //     }

    //     return count;
    // }

    //   
    }
}
