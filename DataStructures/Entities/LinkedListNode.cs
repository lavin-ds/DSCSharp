/***********************************************************
Author          - lavinds
Date Created    - 22-Jul-2018
************************************************************
Sn      Author      Date            Comments
************************************************************
1.      lavinds     22-Jul-2018     Initial draft of file
2.      lavinds     13-Aug-2018     Generic implementation
************************************************************/

#region Namespaces
using System;
#endregion

namespace DataStructures.Entities
{       
    public class LinkedListNode<T>
    {
        public T data;
        public LinkedListNode<T> next;
    }
}