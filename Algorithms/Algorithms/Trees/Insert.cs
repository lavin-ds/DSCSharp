/*********************************************************
Author          - lavinds
Date Created    - 22-Jul-2018
**********************************************************
Sn      Author      Date            Comments
**********************************************************
1.      lavinds   13-Sep-2018       Initial draft of file 
*********************************************************/

#region Namespaces
using DataStructures.ADT;
using DataStructures.Entities;
using Xunit;
#endregion

namespace Algorithms.Trees
{
    public class InsertTest
    {
        [Fact]
        public void BinartTreeInsertTest()
        {
            BinaryTree btObj = new BinaryTree();
            btObj.InsertData(5);
            btObj.InsertData(6);
            btObj.InsertData(7);
            btObj.InsertData(4);
            btObj.InsertData(3);
            btObj.InsertData(8);
        }   

         [Fact]
        public void BinartTreeInsertTestRecursion()
        {
            BinaryTree btObj = new BinaryTree();
            BinaryTreeNode node = new BinaryTreeNode(5);
            btObj.InsertDataWithRecursionBST(node,6);
            btObj.InsertDataWithRecursionBST(node,7);
            btObj.InsertDataWithRecursionBST(node,4);
            btObj.InsertDataWithRecursionBST(node,3);
            btObj.InsertDataWithRecursionBST(node,8);
        }        
    }
}
