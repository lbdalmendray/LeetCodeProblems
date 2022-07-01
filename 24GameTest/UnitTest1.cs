using _24Game;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace _24GameTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Solution solution = new Solution();
            int[] input = new int[]{4, 1, 8, 7};
            var result = solution.JudgePoint24(input);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestMethod2()
        {
            Solution solution = new Solution();
            int[] input = new int[] { 1, 2, 1, 2 };
            var result = solution.JudgePoint24(input);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestMethodAll()
        {
            Solution solution = new Solution();

            for (int i = 1; i < 10 ; i++)
            {
                for (int j = 1; j < 10; j++)
                {
                    for (int k = 1; k < 10; k++)
                    {
                        for (int l = 1; l < 10; l++)
                        {
                            int[] input = new int[] { i, j, k, l };
                            string solution1 = null;
                            var result = solution.JudgePoint24(input, true, ref solution1);
                            if (result)
                            {
                                bool yes = true;
                                foreach (var item in new int[][]
                                    {
                                new int[] { 0 , 1, 2},
                                new int[] { 0 , 2, 1},
                                new int[] { 1 , 0, 2},
                                new int[] { 1 , 2, 0},
                                new int[] { 2 , 0, 1},
                                new int[] { 2 , 1, 0}
                                })
                                {
                                    LinkedList<LinkedListNode<object>> nodes = new LinkedList<System.Collections.Generic.LinkedListNode<object>>();
                                    LinkedList<object> list = new LinkedList<object>();
                                    for (int p  = 0; p < solution1.Length; p++)
                                    {
                                        if ( p % 2 == 0)
                                        {
                                            list.AddLast(double.Parse(solution1[p].ToString()));
                                             
                                        }
                                        else
                                        {
                                            var node = list.AddLast(solution1[p]);
                                            nodes.AddLast(node);
                                        }
                                    }

                                    var nodeArray = nodes.ToArray();
                                    var wrongOperation = false;
                                    foreach (var item1 in nodeArray)
                                    {
                                        var prev = item1.Previous;
                                        var next = item1.Next;
                                        var prevValue = (double)prev.Value;
                                        var nextValue = (double)next.Value;

                                         if ( item1.Value is char operator1)
                                        {
                                            switch (operator1)
                                            {
                                                case '+':
                                                    item1.Value = prevValue + nextValue;

                                                    break;
                                                case '-':
                                                    item1.Value = prevValue - nextValue;

                                                    break;
                                                case '*':
                                                    item1.Value = prevValue * nextValue;
                                                    break;
                                                case '/':
                                                    if (nextValue == 0)
                                                    {
                                                        wrongOperation = true;
                                                    }
                                                    else
                                                    {
                                                        item1.Value = prevValue / nextValue;
                                                    }
                                                    break;
                                            }


                                        }

                                        list.Remove(prev);
                                        list.Remove(next);

                                        if (wrongOperation)
                                            break;
                                    }
                                    if (wrongOperation)
                                        continue;

                                    if (((double)list.First.Value) == 24.0)
                                    {
                                        yes = true;
                                        break;
                                    }
                                }

                                if (!yes)
                                    Assert.IsTrue(!result);
                            }
                            else
                            {

                            }
                        }
                    }
                }
            }            
        }
    }
}