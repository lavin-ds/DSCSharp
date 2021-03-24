/***********************************************************
Author          - lavinds
Date Created    - 05-Aug-2018
************************************************************
Sn      Author      Date            Comments
************************************************************
1.      lavinds     05-Aug-2018     Initial draft of file
************************************************************/

#region Namespaces
using System;
#endregion

namespace DataStructures.Entities
{       
    public class BinaryTreeNode
    {
        public int data;
        public BinaryTreeNode left;
        public BinaryTreeNode right;

        public BinaryTreeNode(int value)
        {
            data = value;
        }
    }
}