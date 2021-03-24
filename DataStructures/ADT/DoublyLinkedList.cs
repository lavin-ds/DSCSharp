/***********************************************************
Author          - lavinds
Date Created    - 04-Aug-2018
Description     - Class that contains the methods for 
                  LinkedLists
************************************************************
Sn      Author      Date            Comments
************************************************************
1.      lavinds     04-Aug-2018     Initial draft of file
************************************************************/

#region Namespaces
using DataStructures.Entities;
using System;
#endregion

namespace DataStructures.ADT
{
    public class DoublyLinkedList
    {
        private DoublyLinkedListNode head;

        public void InsertAtHead(int data)
        {
            if(head == null)
            {
                head = new DoublyLinkedListNode();
                head.next = null;
                head.previous = null;
                head.data = data; 
            }
            else 
            {
                var temp = new DoublyLinkedListNode();
                
                temp.data  = data;
                temp.next= head;
                temp.previous = head.previous;
                head.previous =temp;

                head = temp;                 
            }
        }

        public void ReverseDoublyLinkedList()
        {
            var current = head;
            DoublyLinkedListNode temp = null;

            while(current!=null)
                {
                    temp = current.previous;
                    current.previous = current.next;
                    current.next = temp;

                    current = current.previous;
                }
            if (head != null)
            {
                head = temp;
            }
            head = temp.previous;
        }


    }
}