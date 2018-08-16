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
3.      lavinds     13-Aug-2018     Generic implemetation                                    
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

        private int height;

        private int current=0;

        LinkedList<int> resultListPreOrderRecursive = new LinkedList<int>();

        LinkedList<int> resultListInOrderRecursive = new LinkedList<int>();

        LinkedList<int> resultListPostOrderRecursive = new LinkedList<int>();

        LinkedList<int> resultListPreOrderNonRecursive = new LinkedList<int>();

        LinkedList<int> resultListInOrderNonRecursive = new LinkedList<int>();

        LinkedList<int> resultListPostOrderNonRecursive = new LinkedList<int>();
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
            StackUsingLL<BinaryTreeNode> stage = new StackUsingLL<BinaryTreeNode>();
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
                if(stage.IsEmpty())
                {
                    break;
                }
                root = stage.Pop();
                root = root.right;
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

        public void TaverseListInorderNonRecursive(BinaryTreeNode root)
        {
            StackUsingLL<BinaryTreeNode> stage = new StackUsingLL<BinaryTreeNode>();  
            while(true)
            {
                while(root!=null)
                {
                    stage.Push(root);
                    root = root.left;
                }
                if(stage.IsEmpty())
                {
                    break;
                }
                
                root = stage.Pop();
                resultListInOrderNonRecursive.InsertAtEnd(root.data);
                root = root.right;                
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
        
        private int TreeHeight(BinaryTreeNode root)
        {            
            if(root!=null)
            {
                current++;
                if(current>height)
                {
                    height = current;
                }

                TraverseListPreOrderRecursive(root.left);
                TraverseListPreOrderRecursive(root.right);
                current--;
            }
            return height;
        }
    }
}