/***********************************************************
Author          - lavinds
Date Created    - 13-Aug-2018
************************************************************
Sn      Author      Date            Comments
************************************************************
1.      lavinds     13-Aug-2018     Initial draft of file
************************************************************/

#region Namespaces
using System;
#endregion

namespace DataStructuresCsharp
{
    public static class GenericExtensions
    {
        public static int GetValueAtNode<T>(this T data)
        {
            if(typeof(T) == typeof(int))
            {
                return Convert.ToInt32(data);
            }
            else if(typeof(T) == typeof(BinaryTreeNode))
            {
                BinaryTreeNode temp = (BinaryTreeNode)Convert.ChangeType(data, typeof(BinaryTreeNode));
                return temp.data;
            }
            return 0;
        }
    }
}
