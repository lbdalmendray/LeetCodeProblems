using ModifyGraphEdgeWeights;

namespace ModifyGraphEdgeWeightsTest
{
    [TestClass]
    public class GraphTests
    {
        [TestMethod]
        public void GenerateCorrectPositiveGraphFromOneNegativeEdge()
        {
            var vertexAmount = 2;
            var edges = new int[][] { new[] { 0, 1, -1 } };

            var graph = Graph.GeneratePositveGraphFrom(vertexAmount, edges);
            
            Assert.AreEqual(graph.VertexAmount, vertexAmount);
            Assert.AreEqual(graph.EdgesAmount, 0); 
        }

        [TestMethod]
        public void GenerateCorrectPositiveGraphFromTwoNegativeEdges()
        {
            var vertexAmount = 3;
            var edges = new int[][] { new[] { 0, 1, -1 } , new int[] { 1,2,-1 } };

            var graph = Graph.GeneratePositveGraphFrom(vertexAmount, edges);

            Assert.AreEqual(graph.VertexAmount, vertexAmount);
            Assert.AreEqual(graph.EdgesAmount, 0);
        }

        [TestMethod]
        public void GenerateCorrectPositiveGraphFromOnePositiveAndTwoNegativeEdges()
        {
            var vertexAmount = 3;
            var edges = new int[][]
            {
                    new[] { 0, 1, -1 }
                ,   new int[] { 1, 2, -1 }
                ,   new int[] { 2, 0, 3 }
            };

            var graph = Graph.GeneratePositveGraphFrom(vertexAmount, edges);

            Assert.AreEqual(graph.VertexAmount, vertexAmount);
            Assert.AreEqual(graph.EdgesAmount, 1);
        }

        [TestMethod]
        public void CalculateMinDistance_LineGraph_From0_To3()
        {
            var vertexAmount = 4;
            var edges = new int[][]
            {
                    new int[] { 0,1 , 1 }
                ,   new int[] { 1,2 , 2 }
                ,   new int[] { 2,3 , 3 }
            };            

            var graph = Graph.GeneratePositveGraphFrom(vertexAmount, edges);

            int distance = graph.CalculateMinDistance(0, 3, out var minDistTree);

            Assert.AreEqual(distance, 6);
            Assert.AreEqual(minDistTree.EdgesAmount, 3);

            var edgesSum = new int[][]
            {
                    new int[] { 0,1 , 1 }
                ,   new int[] { 1,2 , 3 }
                ,   new int[] { 2,3 , 6 }
            };

            HashSet<(int, int, int)> hashSetEdges = new HashSet<(int, int, int)>(
                edgesSum.Select(e => (e[0], e[1], e[2])));

            var treeEdges =  minDistTree.ToEdgeArray();
            
            foreach (var edge in treeEdges)
            {
                Assert.IsTrue(hashSetEdges.Contains((edge[0], edge[1], edge[2])));
            }
        }

        [TestMethod]
        public void CalculateMinDistance_LineGraph_From1_To3()
        {
            var vertexAmount = 4;
            var edges = new int[][]
            {
                    new int[] { 0,1 , 1 }
                ,   new int[] { 1,2 , 2 }
                ,   new int[] { 2,3 , 3 }
            };

            var graph = Graph.GeneratePositveGraphFrom(vertexAmount, edges);

            int distance = graph.CalculateMinDistance(1, 3, out var minDistTree);

            Assert.AreEqual(distance, 5);
            Assert.AreEqual(minDistTree.EdgesAmount, 3);

            var edgesSum = new int[][]
            {
                    new int[] { 1,0 , 1 }
                ,   new int[] { 1,2 , 2 }
                ,   new int[] { 2,3 , 5 }
            };

            HashSet<(int, int, int)> hashSetEdges = new HashSet<(int, int, int)>(
                edgesSum.Select(e => (e[0], e[1], e[2])));

            var treeEdges = minDistTree.ToEdgeArray();

            foreach (var edge in treeEdges)
            {
                Assert.IsTrue(hashSetEdges.Contains((edge[0], edge[1], edge[2])));
            }
        }

        [TestMethod]
        public void CalculateMinDistance_LineGraphPlus13Edge_From1_To3()
        {
            var vertexAmount = 4;
            var edges = new int[][]
            {
                    new int[] { 0,1 , 1 }
                ,   new int[] { 1,2 , 2 }
                ,   new int[] { 2,3 , 3 }
                ,   new int[] { 1,3 , 2 }
            };

            var graph = Graph.GeneratePositveGraphFrom(vertexAmount, edges);

            int distance = graph.CalculateMinDistance(1, 3, out var minDistTree);

            Assert.AreEqual(distance, 2);
            Assert.AreEqual(minDistTree.EdgesAmount, 3);

            var edgesSum = new int[][]
            {
                    new int[] { 1,0 , 1 }
                ,   new int[] { 1,2 , 2 }
                ,   new int[] { 1,3 , 2 }
            };

            HashSet<(int, int, int)> hashSetEdges = new HashSet<(int, int, int)>(
                edgesSum.Select(e => (e[0], e[1], e[2])));

            var treeEdges = minDistTree.ToEdgeArray();

            foreach (var edge in treeEdges)
            {
                Assert.IsTrue(hashSetEdges.Contains((edge[0], edge[1], edge[2])));
            }
        }

        [TestMethod]
        public void CalculateMinDistance_LineGraphPlus13_34_46_35_56_Edges_From1_To3()
        {
            var vertexAmount = 7;
            var edges = new int[][]
            {
                    new int[] { 0,1 , 1 }
                ,   new int[] { 1,2 , 2 }
                ,   new int[] { 2,3 , 3 }
                ,   new int[] { 1,3 , 2 }
                ,   new int[] { 3,4 , 5 }
                ,   new int[] { 4,6 , 7 }
                ,   new int[] { 3,5 , 6 }
                ,   new int[] { 5,6 , 2 }
            };

            var graph = Graph.GeneratePositveGraphFrom(vertexAmount, edges);

            int distance = graph.CalculateMinDistance(1, 6, out var minDistTree);

            Assert.AreEqual(distance, 10);
            Assert.AreEqual(minDistTree.EdgesAmount, 6);

            var edgesSum = new int[][]
            {
                    new int[] { 1,0 , 1 }
                ,   new int[] { 1,2 , 2 }
                ,   new int[] { 1,3 , 2 }
                ,   new int[] { 3,4 , 7 }
                ,   new int[] { 3,5 , 8 }
                ,   new int[] { 5,6 , 10 }
            };

            HashSet<(int, int, int)> hashSetEdges = new HashSet<(int, int, int)>(
                edgesSum.Select(e => (e[0], e[1], e[2])));

            var treeEdges = minDistTree.ToEdgeArray();

            foreach (var edge in treeEdges)
            {
                Assert.IsTrue(hashSetEdges.Contains((edge[0], edge[1], edge[2])));
            }
        }
    }
}