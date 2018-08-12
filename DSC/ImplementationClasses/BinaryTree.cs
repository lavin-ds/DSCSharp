/***********************************************************
Author          - lavinds
Date Created    - 05-Aug-2018
Description     - Class that contains the methods for 
                  LinkedLists
********************************************************************
Sn      Author      Date            Comments
********************************************************************
1.      lavinds     05-Aug-2018     Initial draft of file
2.      lavinds     12-Aug-2018     Updated to use LinkedList
                                    Added onrecursive traversal
*******************************************************************/

#region Namespaces
using System; 
using DataStructuresCsharp;
#endregion

namespace DataStructuresCsharp
{
    public class BinaryTree
    {
        #region Variables
        private BinaryTreeNode root;

        private BinaryTreeNode head;

        LinkedList resultListPreOrderRecursive = new LinkedList();

        LinkedList resultListInOrderRecursive = new LinkedList();

        LinkedList resultListPostOrderRecursive = new LinkedList();

        LinkedList resultListPreOrderNonRecursive = new LinkedList();

        LinkedList resultListInOrderNonRecursive = new LinkedList();

        LinkedList resultListPostOrderNonRecursive = new LinkedList();
        #endregion
        
        public void TraverseListPreOrderRecursive(BinaryTreeNode root)
        {            
            if(root!=null)
            {
                resultListPreOrderRecursive.InsertAtEnd(root.data);
                TraverseListPreOrderRecursive(root.left);
                TraverseListPreOrderRecursive(root.right);
            }
        }

        public void TraverseListPreOrderNonRecursive(BinaryTreeNode root)
        {
            StackUsingLLForBinTree
            while(true)
            {
                while(root!=null)
                {
                    resultListPreOrderNonRecursive.InsertAtEnd(root.data);
                    if(root.left!=null)
                    {
                        stage.Push(root);
                        root = root.left;
                    }
                }
            }
        }

        public void TraverseListInOrderRecursive(BinaryTreeNode root)
        {            
            if(root!=null)
            {            
                TraverseListInOrderRecursive(root.left);
                resultListInOrderRecursive.InsertAtEnd(root.data);
                TraverseListInOrderRecursive(root.right);
            }
        }

        public void TraverseListPostOrderRecursive(BinaryTreeNode root)
        {            
            if(root!=null)
            {            
                TraverseListPostOrderRecursive(root.left);            
                TraverseListPostOrderRecursive(root.right);
                resultListPostOrderRecursive.InsertAtEnd(root.data);
            }
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