/*********************************************************
Author          - lavinds
Date Created    - 07-Jul-2018
**********************************************************
Sn      Author      Date            Comments
**********************************************************
1.      lavinds   21-Jul-2018       Initial draft of file 
*********************************************************/

#region Namespaces
using System;
#endregion

namespace DataStructuresCsharp
{       
    public class StackDT
    {
        public int Length;
        public int Top;
        public int[] arr;
    }

    public class Stack
    {
        private StackDT st;
        public Stack()
        {
            CreateStack();   
        }        
        public void CreateStack()
        {
            st = new StackDT();
            st.Top = -1;
            st.Length = 0;
            st.arr = new int[10];           
        }   

        public int PeekTop()
        {
            return st.arr[st.Top];
        }

        public int Length()
        {
            return st.Length;
        }

        public bool IsEmpty()
        {
            return  (st.Top == -1);
        }

        public bool IsFull()
        {
            return (st.Length ==10);
        }

        public void Push (int data)
        {
            if(IsFull())
            {
                throw new Exception();
            }
            else
            {
                st.Top++;
                st.arr[st.Top] = data;
            }            
        }

        public int Pop()
        {
            if (IsEmpty())
            {
                throw new Exception();
            }
            else
            {
                return st.arr[st.Top--];
            }
        }
    }
}