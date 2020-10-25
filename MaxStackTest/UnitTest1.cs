using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MaxStack;

namespace MaxStackTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            MaxStack.MaxStack stack = new MaxStack.MaxStack();
            stack.Push(5);
            stack.Push(1);
            stack.Push(5);
            Assert.AreEqual(stack.Top(),5); // -> 5
            Assert.AreEqual(stack.PopMax(),5); // -> 5
            Assert.AreEqual(stack.Top(),1); // -> 1
            Assert.AreEqual(stack.PeekMax(),5); // -> 5
            Assert.AreEqual(stack.Pop(),1); // -> 1
            Assert.AreEqual(stack.Top(),5); // -> 5
        }
    }
}
