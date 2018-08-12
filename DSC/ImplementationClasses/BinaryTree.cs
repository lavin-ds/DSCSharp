/***********************************************************
Author          - lavinds
Date Created    - 05-Aug-2018
Description     - Class that contains the methods for 
                  LinkedLists
************************************************************
Sn      Author      Date            Comments
************************************************************
1.      lavinds     05-Aug-2018     Initial draft of file
************************************************************/

#region Namespaces
using System; 
using DataStructuresCsharp;
#endregion

namespace DataStructuresCsharp
{
    public class BinaryTree
    {
        private BinaryTreeNode root;

        private BinaryTreeNode head;

        LinkedList resultListPreOrderRecursive = new LinkedList();

        public void TraverseListPreOrderRecursive(BinaryTreeNode root)
        {            
            if(root!=null)
            {
                resultListPreOrderRecursive.InsertAtEnd(root.data);
                TraverseListPreOrderRecursive(root.left);
                TraverseListPreOrderRecursive(root.right);
            }
        }

        public void TraverseListInOrderRecursive(BinaryTreeNode root)
        {            
            // if(root)
            // {            
            //     TraverseListPreOrderRecursive(root.left);
            //     resultListPreOrderRecursive.Add(root.data);
            //     TraverseListPreOrderRecursive(root.right);
            // }
        }

        public void TraverseListPostOrderRecursive(BinaryTreeNode root)
        {            
            // if(root)
            // {            
            //     TraverseListPreOrderRecursive(root.left);            
            //     TraverseListPreOrderRecursive(root.right);
            //     resultListPreOrderRecursive.Add(root.data);
            // }
        }

        // public void InsertElement(int data)
        // {
        //     if(root == null)
        //     {
        //         root = new BinaryTreeNode();
        //         root.data = data;
        //         root.left = null;
        //         root.right = null; 
        //         head = root;
        //     }
        //     else 
        //     {
        //         if()         
        //     }
        // }
    }
}