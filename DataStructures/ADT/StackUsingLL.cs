/***********************************************************
Author          - lavinds
Date Created    - 22-Jul-2018
Description     - Class that contains the methods for Stack
                  using LinkedLists as the data structure 
                  for storage
************************************************************
Sn      Author      Date            Comments
************************************************************
1.      lavinds     22-Jul-2018     Initial draft of file
************************************************************/

#region Namespaces
using DataStructures.Entities;
using DataStructures.Extensions;
using System;
#endregion

namespace DataStructures.ADT
{       
    public class StackUsingLL<T>
    {    
        private LinkedList<T> top = new LinkedList<T>();  
        private int max = -1;
        private int sum = 0;
        public T PeekTop()
        {
            return top.GetDataAtHead();
        }

        public int StackLength()
        {
            return top.ListLength();
        }

        public bool IsEmpty()
        {
            return  (top.ListLength()==0);
        }

        public void Push (T data)
        {                       
            sum += data.GetValueAtNode();
            if(data.GetValueAtNode()>max)
            {
                max = data.GetValueAtNode();
            }
            top.InsertAtHead(data);                   
        }

        //TODO: Delete tail on emptying stack
        public T Pop()
        {
            var headData = top.GetDataAtHead();
            top.DeleteFirstNode();           
            max = top.MaxElement(); 
            sum = sum - headData.GetValueAtNode();
            return headData;
        }

        public void EmptyStack()
        {
           top.DeleteList();
        }

        public int MaxStack()
        {
            return max; 
        }

        public int SumStack()
        {
            return sum;
        }
    }
}