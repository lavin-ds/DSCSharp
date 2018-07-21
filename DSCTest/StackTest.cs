/*********************************************************
Author          - lavinds
Date Created    - 21-Jul-2018
**********************************************************
Sn      Author      Date            Comments
**********************************************************
1.      lavinds   21-Jul-2018       Initial draft of file 
*********************************************************/

#region Namespaces
using System;
using DataStructuresCsharp;
using Xunit;
#endregion

namespace DSCTest
{
    public class StackTest
    {
        [Fact]
        public void CreateStack_Test()
        {
            Stack obj = new Stack();
            obj.Push(5);
            obj.Push(6);
            
            Assert.Equal(6, obj.PeekTop());
        }

        [Fact]
        public void Pop_Test()
        {
            Stack obj = new Stack();
            obj.Push(5);
            obj.Push(6);
            
            Assert.Equal(6,obj.Pop());
            Assert.Equal(5, obj.PeekTop());
        }

        [Fact]        
        public void IsStackFull_Test()
        {
            var obj = new Stack();
            obj.Push(1);
            obj.Push(1);
            obj.Push(1);
            obj.Push(1);
            obj.Push(1);
            obj.Push(1);
            obj.Push(1);
            obj.Push(1);
            obj.Push(1);
            obj.Push(1);
            Assert.Throws<System.IndexOutOfRangeException>(()=> obj.Push(1));
        }
    }
}