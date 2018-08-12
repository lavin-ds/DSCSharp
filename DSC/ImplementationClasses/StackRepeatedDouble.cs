/***********************************************************
Author          - lavinds
Date Created    - 22-Jul-2018
Description     - Class that contains the methods for Stack
                  using the concept of repeated doubling the 
                  size of stack everytime it gets full
************************************************************
Sn      Author      Date            Comments
************************************************************
1.      lavinds     22-Jul-2018     Initial draft of file
************************************************************/

#region Namespaces
using System;
#endregion

namespace DataStructuresCsharp
{       
    public class StackRepeatedDouble
    {
        private Stack<int> st;
        public StackRepeatedDouble()
        {
            CreateStack();   
        }        
        public void CreateStack()
        {
            st = new Stack<int>();
            st.Top = -1;
            st.Length = 0;
            st.arr = new int[1];           
        }   

        public int PeekTop()
        {
            return st.arr[st.Top];
        }

        public int StackLength()
        {
            return st.Length;
        }

        public bool IsEmpty()
        {
            return  (st.Top == -1);
        }

        public bool IsFull()
        {
            return (st.Length ==st.arr.Length);
        }

        public void Push (int data)
        {
            if(IsFull())
            {
                var tempStack  =new int[st.Length*2];
                for(int i =0 ;i<st.Length;i++)
                {
                    tempStack[i] = st.arr[i];
                }
                st.arr = tempStack;
            }           
            st.Top++;
            st.Length++;
            st.arr[st.Top] = data;                  
        }

        public int Pop()
        {
            if (IsEmpty())
            {
                throw new Exception();
            }
            else
            {
                st.Length--;
                return st.arr[st.Top--];
            }
        }

        public void EmptyStack()
        {
            st.Top = -1;
            st.Length = 0;
            st.arr =new int[1];
        }
    }
}