using System;

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
            st.Top = -1;
            st.Length = 0;
            st.arr = new int[10];           
        }   

        public bool IsEmpty()
        {
            return  (st.Top == -1);
        }

        public bool IsFull()
        {
            return (st.Length ==0);
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