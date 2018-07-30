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
using System;
#endregion

namespace DataStructuresCsharp
{       
    public class StackUsingLL
    {    
        private LinkedList top = new LinkedList();  

        private int max = -1;
        private int sum = 0;
        public int PeekTop()
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

        public void Push (int data)
        {           
            sum +=data;
            if(data>max)
            {
                max = data;
            }
            top.InsertAtHead(data);                   
        }

        public int Pop()
        {
            var headData = top.GetDataAtHead();
            top.DeleteFirstNode();           
            max = top.MaxElement(); 
            sum = sum - headData;
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