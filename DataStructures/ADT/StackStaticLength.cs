/***********************************************************
Author          - lavinds
Date Created    - 07-Jul-2018
Description     - Class that contains the methods for fixed 
                  length Stack implementation
************************************************************
Sn      Author      Date            Comments
************************************************************
1.      lavinds     07-Jul-2018     Initial draft of file
2.      lavinds     21-Jul-2018     Added empty stack method
************************************************************/

#region Namespaces
using DataStructures.Entities;
using System;
#endregion

namespace DataStructures.ADT
{       
    public class StackStaticLength
    {
        private Stack st;

        /// <summary>
        /// Stack of ints will be created with storage for 10 
        /// </summary>
        public StackStaticLength()
        {
            CreateStack();   
        }        
        public void CreateStack()
        {
            st = new Stack();
            st.Top = -1;
            st.Length = 0;
            st.arr = new int[10];           
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
            return (st.Length ==10);
        }

        public void Push (int data)
        {
            if(IsFull())
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
                st.Top++;
                st.Length++;
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
                st.Length--;
                return st.arr[st.Top--];
            }
        }

        public void EmptyStack()
        {
            st.Top = -1;
            st.Length = 0;
        }
    }
}