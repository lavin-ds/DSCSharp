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
using System;
#endregion

namespace DataStructuresCsharp
{       
    public class Queue<T>
    {    
        private LinkedList<T> top = new LinkedList<T>();  
        private int max = -1;
        private int sum = 0;


        public void Enqueue(T data)
        {

        }

        public T Dequeue()
        {
            
        }
    }
}