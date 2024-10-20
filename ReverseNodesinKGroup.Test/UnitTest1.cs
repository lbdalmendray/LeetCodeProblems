namespace ReverseNodesinKGroup.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            ReverseNodesinKGroup.Solution solution = new Solution();
            var result = solution.ReverseKGroup(ArrayToListNode([1, 2, 3, 4, 5]), 2);
            CollectionAssert.AreEquivalent(ListNodeToArray(result), new int[] { 2, 1, 4, 3, 5 });
        }

        [TestMethod]
        public void TestMethod2()
        {
            ReverseNodesinKGroup.Solution solution = new Solution();
            var result = solution.ReverseKGroup(ArrayToListNode([1, 2, 3, 4, 5]), 1);
            CollectionAssert.AreEquivalent(ListNodeToArray(result), new int[] { 1, 2, 3, 4, 5 });
        }

        [TestMethod]
        public void TestMethod3()
        {
            ReverseNodesinKGroup.Solution solution = new Solution();
            var result = solution.ReverseKGroup(ArrayToListNode([1, 2, 3, 4, 5,6,7,8,9]), 3);
            CollectionAssert.AreEquivalent(ListNodeToArray(result), new int[] { 3,2,1,6,5,4,9,8,7 });
        }

        [TestMethod]
        public void TestMethod4()
        {
            ReverseNodesinKGroup.Solution solution = new Solution();
            var result = solution.ReverseKGroup(ArrayToListNode([1, 2, 3, 4, 5, 6, 7, 8, 9,10]), 3);
            CollectionAssert.AreEquivalent(ListNodeToArray(result), new int[] { 3, 2, 1, 6, 5, 4, 9, 8, 7,10 });
        }

        [TestMethod]
        public void TestMethod5()
        {
            ReverseNodesinKGroup.Solution solution = new Solution();
            var result = solution.ReverseKGroup(ArrayToListNode([1, 2, 3, 4, 5, 6, 7, 8, 9, 10,11]), 3);
            CollectionAssert.AreEquivalent(ListNodeToArray(result), new int[] { 3, 2, 1, 6, 5, 4, 9, 8, 7, 10,11 });
        }


        private ListNode ArrayToListNode ( int[] values)
        {
            ListNode result = new ListNode(values[0]);
            var prev = result;
            for (int i = 1; i < values.Length; i++)
            {
                var newNode = new ListNode(values[i]);
                prev.next = newNode;
                prev = newNode;
            }
            return result;
        }

        private int[] ListNodeToArray(ListNode node)
        {
            List<int> result = new List<int>();
            while(node != null)
            {
                result.Add(node.val);
                node = node.next;
            }
            return result.ToArray();
        }
    }
}