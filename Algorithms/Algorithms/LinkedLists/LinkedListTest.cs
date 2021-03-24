/*********************************************************
Author          - lavinds
Date Created    - 22-Jul-2018
**********************************************************
Sn      Author      Date            Comments
**********************************************************
1.      lavinds   22-Jul-2018       Initial draft of file 
*********************************************************/

#region Namespaces
using DataStructures.ADT;
using Xunit;
#endregion

namespace Algorithms.LinkedLists
{
    public class LinkedListTest
    {
        [Fact]
        public void CreateList_Test()
        {
            var obj = new LinkedList<int>();
            obj.InsertAtHead(4);
            Assert.Equal(1, obj.ListLength());
        }

        [Fact]
        public void InsertIntoListAtEnd_Test()
        {
            var obj = new LinkedList<int>();
            obj.InsertAtHead(4);
            Assert.Equal(1, obj.ListLength());
            obj.InsertAtEnd(5);
            Assert.Equal(2, obj.ListLength());
        }

        [Fact]
        public void InsertIntoListAtPos_Test()
        {
            var obj = new LinkedList<int>();
            obj.InsertAtHead(4);           
            obj.InsertAtEnd(5);
            obj.InsertAtEnd(8);
            obj.InsertAtEnd(7);
            obj.InsertInMiddle(9,2);
            Assert.Equal(5, obj.ListLength());
        }


        [Fact]
        public void DeleteFromEnd_Test()
        {
            var obj = new LinkedList<int>();
            obj.InsertAtHead(4);           
            obj.InsertAtEnd(5);
            obj.InsertAtEnd(8);
            obj.InsertAtEnd(7);
            obj.InsertInMiddle(9,2);
            obj.DeleteFromPostion(2);
            obj.DeleteFirstNode();
            obj.DeleteLastNode();
            Assert.Equal(2, obj.ListLength());
        }
    }
}
