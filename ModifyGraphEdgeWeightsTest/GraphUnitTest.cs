using ModifyGraphEdgeWeights;
using number = System.Int64;

namespace ModifyGraphEdgeWeightsTest
{
    [TestClass]
    public class GraphTests
    {
        [TestMethod]
        public void GenerateCorrectPositiveGraphFromOneNegativeEdge()
        {
            var vertexAmount = 2;
            var edges = new number[][] { new[] { 0l, 1l, -1l } };

            var graph = Graph.GeneratePositveGraphFrom(vertexAmount, edges);
            
            Assert.AreEqual(graph.VertexAmount, vertexAmount);
            Assert.AreEqual(graph.EdgesAmount, 0); 
        }

        [TestMethod]
        public void GenerateCorrectPositiveGraphFromTwoNegativeEdges()
        {
            var vertexAmount = 3;
            var edges = new number[][] { new[] { 0l, 1l, -1l } , new number[] { 1l,2l,-1l } };

            var graph = Graph.GeneratePositveGraphFrom(vertexAmount, edges);

            Assert.AreEqual(graph.VertexAmount, vertexAmount);
            Assert.AreEqual(graph.EdgesAmount, 0);
        }

        [TestMethod]
        public void GenerateCorrectPositiveGraphFromOnePositiveAndTwoNegativeEdges()
        {
            var vertexAmount = 3;
            var edges = new number[][]
            {
                    new[] { 0L, 1L, -1L }
                ,   new number[] { 1L, 2L, -1L }
                ,   new number[] { 2L, 0L, 3L }
            };

            var graph = Graph.GeneratePositveGraphFrom(vertexAmount, edges);

            Assert.AreEqual(graph.VertexAmount, vertexAmount);
            Assert.AreEqual(graph.EdgesAmount, 1);
        }

        [TestMethod]
        public void CalculateMinDistance_LineGraph_From0_To3()
        {
            var vertexAmount = 4;
            var edges = new number[][]
            {
                    new number[] { 0,1 , 1 }
                ,   new number[] { 1,2 , 2 }
                ,   new number[] { 2,3 , 3 }
            };            

            var graph = Graph.GeneratePositveGraphFrom(vertexAmount, edges);

            number distance = graph.CalculateMinDistance(0, 3, out var minDistTree);

            Assert.AreEqual(distance, 6);
            Assert.AreEqual(minDistTree.EdgesAmount, 3);

            var edgesSum = new number[][]
            {
                    new number[] { 0,1 , 1 }
                ,   new number[] { 1,2 , 3 }
                ,   new number[] { 2,3 , 6 }
            };

            HashSet<(number, number, number)> hashSetEdges = new HashSet<(number, number, number)>(
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
            var edges = new number[][]
            {
                    new number[] { 0,1 , 1 }
                ,   new number[] { 1,2 , 2 }
                ,   new number[] { 2,3 , 3 }
            };

            var graph = Graph.GeneratePositveGraphFrom(vertexAmount, edges);

            number distance = graph.CalculateMinDistance(1, 3, out var minDistTree);

            Assert.AreEqual(distance, 5);
            Assert.AreEqual(minDistTree.EdgesAmount, 3);

            var edgesSum = new number[][]
            {
                    new number[] { 1,0 , 1 }
                ,   new number[] { 1,2 , 2 }
                ,   new number[] { 2,3 , 5 }
            };

            HashSet<(number, number, number)> hashSetEdges = new HashSet<(number, number, number)>(
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
            var edges = new number[][]
            {
                    new number[] { 0,1 , 1 }
                ,   new number[] { 1,2 , 2 }
                ,   new number[] { 2,3 , 3 }
                ,   new number[] { 1,3 , 2 }
            };

            var graph = Graph.GeneratePositveGraphFrom(vertexAmount, edges);

            number distance = graph.CalculateMinDistance(1, 3, out var minDistTree);

            Assert.AreEqual(distance, 2);
            Assert.AreEqual(minDistTree.EdgesAmount, 3);

            var edgesSum = new number[][]
            {
                    new number[] { 1,0 , 1 }
                ,   new number[] { 1,2 , 2 }
                ,   new number[] { 1,3 , 2 }
            };

            HashSet<(number, number, number)> hashSetEdges = new HashSet<(number, number, number)>(
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
            var edges = new number[][]
            {
                    new number[] { 0,1 , 1 }
                ,   new number[] { 1,2 , 2 }
                ,   new number[] { 2,3 , 3 }
                ,   new number[] { 1,3 , 2 }
                ,   new number[] { 3,4 , 5 }
                ,   new number[] { 4,6 , 7 }
                ,   new number[] { 3,5 , 6 }
                ,   new number[] { 5,6 , 2 }
            };

            var graph = Graph.GeneratePositveGraphFrom(vertexAmount, edges);

            number distance = graph.CalculateMinDistance(1, 6, out var minDistTree);

            Assert.AreEqual(distance, 10);
            Assert.AreEqual(minDistTree.EdgesAmount, 6);

            var edgesSum = new number[][]
            {
                    new number[] { 1,0 , 1 }
                ,   new number[] { 1,2 , 2 }
                ,   new number[] { 1,3 , 2 }
                ,   new number[] { 3,4 , 7 }
                ,   new number[] { 3,5 , 8 }
                ,   new number[] { 5,6 , 10 }
            };

            HashSet<(number, number, number)> hashSetEdges = new HashSet<(number, number, number)>(
                edgesSum.Select(e => (e[0], e[1], e[2])));

            var treeEdges = minDistTree.ToEdgeArray();

            foreach (var edge in treeEdges)
            {
                Assert.IsTrue(hashSetEdges.Contains((edge[0], edge[1], edge[2])));
            }
        }
    }
}