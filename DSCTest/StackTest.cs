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
            StackStaticLength obj = new StackStaticLength();
            obj.Push(5);
            obj.Push(6);
            
            Assert.Equal(6, obj.PeekTop());
        }

        [Fact]
        public void Pop_Test()
        {
            StackStaticLength obj = new StackStaticLength();
            obj.Push(5);
            obj.Push(6);
            
            Assert.Equal(6,obj.Pop());
            Assert.Equal(5, obj.PeekTop());
        }

        [Fact]        
        public void IsStackFull_Test()
        {
            var obj = new StackStaticLength();
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

         [Fact]        
        public void EmptyStack_Test()
        {
            var obj = new StackStaticLength();
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
            obj.EmptyStack();
            Assert.Equal(0,obj.StackLength());
            obj.Push(1);
            Assert.Equal(1,obj.StackLength());
        }

        [Fact]
        public void StackRD_Test()
        {
            var obj = new StackRepeatedDouble();
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
            obj.EmptyStack();
            Assert.Equal(0,obj.StackLength());
            obj.Push(1);
            Assert.Equal(1,obj.StackLength());
        }



    }
}