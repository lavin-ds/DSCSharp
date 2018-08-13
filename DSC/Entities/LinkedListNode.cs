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

namespace DataStructuresCsharp
{       
    public class LinkedListNode<T>
    {
        public T data;
        public LinkedListNode<T> next;

        public int GetValueAtDataNode()
        {
            if(typeof(T) == typeof(int))
            {
                return Convert.ToInt32(data);
            }
            else if(typeof(T) == typeof(BinaryTreeNode))
            {
                BinaryTreeNode temp = Convert.ChangeType(data, typeof(BinaryTreeNode));
                return temp.data;
            }
            return 0;
        }
    }
}