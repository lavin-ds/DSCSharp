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
    }
}