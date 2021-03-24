/***********************************************************
Author          - lavinds
Date Created    - 20-Aug-2018
Description     - Class that contains the methods for Queue
                  using LinkedLists as the data structure 
                  for storage
************************************************************
Sn      Author      Date            Comments
************************************************************
1.      lavinds     20-Aug-2018     Initial draft of file
************************************************************/

#region Namespaces
using DataStructures.Entities;
using DataStructures.Extensions;
using System;
#endregion

namespace DataStructures.ADT
{       
    public class QueueUsingLL<T>
    {    
        private LinkedList<T> top = new LinkedList<T>();  
        private int max = -1;

        public void EnQueue(T data)
        {
            if(data.GetValueAtNode()>max)
            {
                max = data.GetValueAtNode();
            }
            top.InsertAtHead(data);
        }

        public T DeQueue()
        {
            T first = top.GetDataAtTail();
            top.DeleteLastNode();
            return first;
        }

        public T First()
        {
            return top.GetDataAtTail();
        }

        public int QueueSize()
        {
            return top.ListLength();
        }

        public int MaxElement()
        {
            return max;
        }

        public bool IsEmpty()
        {
            return (top.ListLength() == 0);
        }
    }
}