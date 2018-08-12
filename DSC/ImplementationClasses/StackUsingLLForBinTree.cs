/***********************************************************
Author          - lavinds
Date Created    - 12-Aug-2018
Description     - Class that contains the methods for Stack
                  using LinkedLists as the data structure 
                  for storage
************************************************************
Sn      Author      Date            Comments
************************************************************
1.      lavinds     12-Aug-2018     Initial draft of file
************************************************************/

#region Namespaces
using System;
#endregion

namespace DataStructuresCsharp
{       
    public class StackUsingLLForBinTree
    {    
        private LinkedListForBinTree top = new LinkedListForBinTree();  
        private int max = -1;
        private int sum = 0;
        public BinaryTreeNode PeekTop()
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

        public void Push (BinaryTreeNode data)
        {           
            sum +=data.data;
            if(data.data>max)
            {
                max = data.data;
            }
            top.InsertAtHead(data);                   
        }

        public BinaryTreeNode Pop()
        {
            var headData = top.GetDataAtHead();
            top.DeleteFirstNode();           
            max = top.MaxElement(); 
            sum = sum - headData.data;
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