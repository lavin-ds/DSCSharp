/***********************************************************
Author          - lavinds
Date Created    - 12-Aug-2018
Description     - Class that contains the methods for 
                  LinkedLists
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
    public class LinkedListForBinTree
    {
        private LinkedListNodeForBinTree head;

        public void InsertAtHead(BinaryTreeNode data)
        {
            if(head == null)
            {
                head = new LinkedListNodeForBinTree();
                head.next = null;
                head.data = data; 
            }
            else 
            {
                var temp = new LinkedListNodeForBinTree();
                
                temp.data  = data;
                temp.next= head;

                head = temp;                 
            }
        }

        public void InsertInMiddle(BinaryTreeNode data, int position)
        {
            if (head == null)
            {
                throw new IndexOutOfRangeException();
            }

            var temp = head;
            
            for (int i = 1;i<position-1;i++)
            {
                if(temp.next!=null)
                {
                    temp = temp.next;
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
            var newNode = new LinkedListNodeForBinTree();
            newNode.next = temp.next;
            newNode.data = data;
            temp.next = newNode;
        }

        public void InsertAtEnd(BinaryTreeNode data)
        {
            var newNode = new LinkedListNodeForBinTree();
            newNode.next = null;
            newNode.data = data;

            if(head == null)
            {
                head = newNode;
            }
            else
            {
                var temp = head;

                while (temp.next !=null)
                {
                    temp = temp.next;
                }

                temp.next = newNode;                
            }                      
        }
        
        public int ListLength()
        {
            if(head == null)
            {
                return 0;
            }
            else
            {
                var length = 0;
                var temp = head;

                while (temp !=null)
                {
                    temp = temp.next;
                    length++;
                }

                return length;            
            }
        }

        public void DeleteList()
        {        
            head = null;
        }

        public void DeleteFirstNode()
        {
            if(head.next != null)
            {
                head = head.next;
            }

            else
            {
                head = null;
            }            
        }

        public void DeleteLastNode()
        {
            if(head == null || head.next == null)
            {
                head = null;
            }
            else
            {
                var temp = head;

                while(temp.next.next != null)
                {
                    temp = temp.next;
                }
                temp.next = null;
            }
        }

        public void DeleteFromPostion(int position)
        {
            if(head == null || head.next == null)
            {
                throw new IndexOutOfRangeException();
            }
            var temp = head;

            for (int i = 1;i<position-1;i++)
            {
                if(temp.next!=null)
                {
                    temp = temp.next;
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }

            temp.next= temp.next.next;

        }

        public BinaryTreeNode GetDataAtHead()
        {
            if(head == null)
            {
                throw new IndexOutOfRangeException();
            }
            return head.data;
        }

        public int MaxElement()
        {
            var max = -1;
            var temp = head;
            while (temp != null)
            {
                if(temp.data.data > max)
                {
                    max = temp.data.data;
                }
                temp = temp.next;
            }

            return max;
        }
    }
}