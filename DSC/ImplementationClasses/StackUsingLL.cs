/***********************************************************
Author          - lavinds
Date Created    - 22-Jul-2018
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
        private LinkedList st = new LinkedList();  

        public int PeekTop()
        {
            return st.GetDataAtHead();
        }

        public int StackLength()
        {
            return st.ListLength();
        }

        public bool IsEmpty()
        {
            return  (st.ListLength()==0);
        }

        public void Push (int data)
        {           
                st.InsertAtHead(data);                   
        }

        public int Pop()
        {
            var headData = st.GetDataAtHead();
            st.DeleteFirstNode();            
            return headData;
        }

        public void EmptyStack()
        {
           st.DeleteList();
        }
    }
}