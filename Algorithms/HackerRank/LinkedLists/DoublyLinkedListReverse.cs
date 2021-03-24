/*********************************************************
Author          - lavinds
Date Created    - 04-Aug-2018
**********************************************************
Sn      Author      Date            Comments
**********************************************************
1.      lavinds   04-Aug-2018       Initial draft of file 
*********************************************************/

#region Namespaces
using DataStructures.ADT;
using Xunit;
#endregion

namespace HackerRank.LinkedLists
{
    public class DoublyLinkedListReverse
    {       
        [Fact]
        public void CreateList_Test()
        {
            var obj = new DoublyLinkedList();
            obj.InsertAtHead(4);
            obj.InsertAtHead(3);
            obj.InsertAtHead(1);
            obj.InsertAtHead(3);
            obj.InsertAtHead(2);
            obj.InsertAtHead(9); 
            obj.ReverseDoublyLinkedList();
        }
    }
}
