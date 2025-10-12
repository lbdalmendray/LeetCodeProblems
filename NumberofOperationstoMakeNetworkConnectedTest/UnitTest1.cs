using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NumberofOperationstoMakeNetworkConnected;
using Utils;

namespace NumberofOperationstoMakeNetworkConnectedTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Solution s = new Solution();
            var result = s.MakeConnected(6, Utils.Utils.ParseArrayArrayInteger("[[0,1],[0,2],[0,3],[1,2],[1,3]]"));
            Assert.AreEqual(result, 2);
        }

        [TestMethod]
        public void TestMethod2()
        {
            Solution s = new Solution();
            var result = s.MakeConnected(6, Utils.Utils.ParseArrayArrayInteger("[[0,1],[0,2],[0,3],[1,2]]"));
            Assert.AreEqual(result, -1);
        }

        [TestMethod]
        public void TestMethod3()
        {
            Solution s = new Solution();
            var result = s.MakeConnected(5, Utils.Utils.ParseArrayArrayInteger("[[0,1],[0,2],[3,4],[2,3]]"));
            Assert.AreEqual(result, 0);
        }

        [TestMethod]
        public void TestMethod4()
        {
            Solution s = new Solution();
            var result = s.MakeConnected(1, Utils.Utils.ParseArrayArrayInteger("[]"));
            Assert.AreEqual(result, 0);
        }
    }
}
