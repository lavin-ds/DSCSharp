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
4.      lavinds     15-Aug-2018     NonrecursiveInorder
5.      lavinds     16-Aug-2018     TreeHeight    
6.      lavinds     19-Aug-2018     NonRecursivePostOrder
7.      lavinds     21-Aug-2018     LevelOrderTraversal
8.      lavinds     23-Aug-2018     FindMax usingRecursion
9.      lavinds     23-Aug-2018     FindMax without Recursion
10.     lavinds     24-Aug-2018     TreeSearchWithoutRecursion
11.     lavinds     25-Aug-2018     TreeSearch with Recursion
12.     lavinds     01-Oct-2018     Insert into tree 
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

        LinkedList<int> resultListLevelOrderNonRecursive = new LinkedList<int>();

        #endregion
        
        #region Methods
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
        
        public void TraverseListPostOrderNonRecursive(BinaryTreeNode root)
        {
            StackUsingLL<BinaryTreeNode> stage = new StackUsingLL<BinaryTreeNode>();  
            while(true)
            {
                if(root!=null)
                {
                    stage.Push(root);
                    root= root.left;
                }                
                else 
                {
                    if(stage.IsEmpty())
                    {
                        break;
                    }
                    else if(stage.PeekTop().right == null)
                    {
                        root = stage.Pop();
                        resultListPostOrderNonRecursive.InsertAtEnd(root.data);
                        if(root == stage.PeekTop().right)
                        {
                            resultListPostOrderNonRecursive.InsertAtEnd(stage.PeekTop().data);
                            stage.Pop();
                        }
                    }
                    if(!stage.IsEmpty())
                    {
                        root = stage.PeekTop().right;                    
                    }
                    else
                    {
                        root = null;
                    }
                }
            }
        }
        public int TreeHeight(BinaryTreeNode root)
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
        
        public void LevelOrderTraversal(BinaryTreeNode root)
        {
            QueueUsingLL<BinaryTreeNode> queueObj = new QueueUsingLL<BinaryTreeNode>();
            BinaryTreeNode temp;
            if(root == null)
            {
                return;
            }
            queueObj.EnQueue(root);
            while(!queueObj.IsEmpty())
            {
                temp = queueObj.DeQueue();
                resultListLevelOrderNonRecursive.InsertAtEnd(temp.data);
                if(temp.left!=null)
                {
                    queueObj.EnQueue(temp.left);
                }
                if(temp.right!=null)
                {
                    queueObj.EnQueue(temp.right);
                }
            }
        }

        public int FindMax(BinaryTreeNode root)
        {
            int rootData=-1, leftMax=-1, rightMax=-1,max=-1;
            if(root!=null)
            {
                rootData = root.data;
                leftMax = FindMax(root.left);
                rightMax = FindMax(root.right);
            }

            if (leftMax>rightMax)
            {
                max = leftMax;
            }
            else
                max = rightMax;
            if(max>rootData)
            {
                rootData = max;
            }
            return max;
        }

        public int FindMaxWithoutRecursion(BinaryTreeNode root)
        {
            int max = -1;
            QueueUsingLL<BinaryTreeNode> queueObj = new QueueUsingLL<BinaryTreeNode>();
            BinaryTreeNode temp;
            if(root!=null)
            {
                queueObj.EnQueue(root);
                while(!queueObj.IsEmpty())
                {
                    temp = queueObj.DeQueue();
                    if(temp.data>max)
                    {
                        max = temp.data;
                    }
                    if(temp.left!=null)
                    {
                        queueObj.EnQueue(temp.left);
                    }
                    if(temp.right!=null)
                    {
                        queueObj.EnQueue(temp.right);
                    }
                }
            }
            return max;
        }

        public bool SearchIfDataExists(BinaryTreeNode root, int data)
        {
            QueueUsingLL<BinaryTreeNode> queueObj = new QueueUsingLL<BinaryTreeNode>();           
            BinaryTreeNode temp; 
            if(root!=null)
            {
                queueObj.EnQueue(root);
                while(!queueObj.IsEmpty())
                {
                    temp = queueObj.DeQueue();
                    if(temp.data == data)
                    {
                        return true;
                    }
                    if(temp.left!=null)
                    {
                        queueObj.EnQueue(temp.left);
                    }
                    if(temp.right!=null)
                    {
                        queueObj.EnQueue(temp.right);
                    }
                }              
            }
            return false;
        }

        public bool SearchIfDataExistsWithRecursion(BinaryTreeNode root, int data)
        {
            if(root==null)
            {
                return false;
            }
            else
            {
                //if data is found
                if(root.data == data)
                {
                    return true;
                }
                else
                {
                    //recur down the tree
                    var temp = SearchIfDataExistsWithRecursion(root.left,data);
                    if(temp)
                    {
                        return temp; 
                    }
                    else
                    {
                        temp = SearchIfDataExistsWithRecursion(root.right,data);
                        return temp;
                    }
                }
            }
        }

        public void InsertData(int data)
        {
            QueueUsingLL<BinaryTreeNode> queueObj = new QueueUsingLL<BinaryTreeNode>();
            if(root!=null)
            {
                queueObj.EnQueue(root);
                while(!queueObj.IsEmpty())
                {
                    var temp = queueObj.DeQueue();
                    if(data<=temp.data)
                    { 
                        if(temp.left == null)
                        {                       
                            temp.left = new BinaryTreeNode(data);
                            break;
                        }
                        else
                        {
                            queueObj.EnQueue(temp.left);
                        }
                    }
                   
                   if(data>temp.data)
                    {
                        if(temp.right == null)
                        {
                        
                            temp.right = new BinaryTreeNode(data);
                            break;
                        }
                        else
                        {
                            queueObj.EnQueue(temp.right);
                        }
                    }
                    
                }
            }
            else
            {
                root = new BinaryTreeNode(data);
            }
        }

        #endregion
    }
}