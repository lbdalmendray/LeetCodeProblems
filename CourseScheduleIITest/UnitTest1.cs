using CourseScheduleII;

namespace CourseScheduleIITest;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void TestMethod1()
    {
        int[][] prerequisites = [[1, 0]];
        Solution solution = new Solution();
        var result = solution.FindOrder(2, prerequisites);
        
        CollectionAssert.AreEquivalent(new int[] { 0, 1 }.ToList(), result.ToList());
    }

    [TestMethod]
    public void TestMethod2()
    {
        int numCourses = 2;
        int[][] prerequisites = [[1, 0]];
        Solution solution = new Solution();
        var result = solution.FindOrder(numCourses, prerequisites);
        CheckResult(numCourses, prerequisites, result);
    }

    [TestMethod]
    public void TestMethod3()
    {
        int numCourses = 4;
        int[][] prerequisites = [[1, 0], [2, 0], [3, 1], [3, 2]];
        Solution solution = new Solution();
        var result = solution.FindOrder(numCourses, prerequisites);

        CheckResult(numCourses, prerequisites, result);
    }

    [TestMethod]
    public void TestMethod4()
    {
        int numCourses = 1;
        int[][] prerequisites = [];
        Solution solution = new Solution();
        var result = solution.FindOrder(numCourses, prerequisites);

        CheckResult(numCourses, prerequisites, result);
    }

    [TestMethod]
    public void TestMethod5()
    {
        int numCourses = 6;
        int[][] prerequisites = [];
        Solution solution = new Solution();
        var result = solution.FindOrder(numCourses, prerequisites);

        CheckResult(numCourses, prerequisites, result);
    }

    [TestMethod]
    public void TestMethod6()
    {
        int numCourses = 6;
        int[][] prerequisites = [[0,1]];
        Solution solution = new Solution();
        var result = solution.FindOrder(numCourses, prerequisites);

        CheckResult(numCourses, prerequisites, result);
    }

    [TestMethod]
    public void TestMethod7()
    {
        int numCourses = 6;
        int[][] prerequisites = [[0, 1], [3,5]];
        Solution solution = new Solution();
        var result = solution.FindOrder(numCourses, prerequisites);

        CheckResult(numCourses, prerequisites, result);
    }


    private HashSet<int> DFS(Graph graph, int i)
    {
        HashSet<int> result = new HashSet<int>();

        DFS(graph, i, result);
        

        return result;
    }

    private void DFS(Graph graph, int i, HashSet<int> result)
    {
        if (result.Contains(i))
            return;
        else
        {
            result.Add(i);
            foreach (int item in graph.ChildrenOf(i))
            {
                DFS(graph, item, result);
            }
        }
    }

    private void CheckResult(int numCourses, int[][] prerequisites, int[] result)
    {
        Graph graph = new Graph(numCourses, prerequisites);

        for (int i = 0; i < result.Length - 1; i++)
        {
            int vertex = result[i];

            HashSet<int> list = DFS(graph, vertex);
            list.Remove(vertex);

            for (int j = i + 1; j < result.Length; j++)
            {
                var vertex2 = result[j];

                if (list.Contains(vertex2))
                    Assert.Fail();
            }
        }
    }
}