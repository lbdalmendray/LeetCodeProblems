namespace CourseScheduleII;

public class Solution
{
    public int[] FindOrder(int numCourses, int[][] prerequisites)
    {
        Graph graph = new Graph(numCourses, prerequisites);
        return graph.TopologicalOrder();
    }
}

public class Graph
{
    private readonly List<int>[] content;

    public Graph(int vertexLength, int[][] prerequisites)
    {
        content = Enumerable.Range(0, vertexLength)
            .Select(_ => new List<int>())
            .ToArray();

        foreach (var relationship in prerequisites)
            content[relationship[0]].Add(relationship[1]); 
    }

    public IEnumerable<int> ChildrenOf(int i)
    {
        return content[i];
    }

    public int[] TopologicalOrder()
    {
        List<int> result = new List<int>();
        HashSet<int> touched = new HashSet<int>();

        if( TopologicalOrder(result, touched))
            return result.ToArray();
        else
        {
            return [];
        }    
    }

    private bool TopologicalOrder(List<int> result, HashSet<int> touched)
    {
        for (int vertex = 0; vertex < content.Length; vertex++)
        {
            if (touched.Contains(vertex))
                continue;
            else
            {
                HashSet<int> currentTouched = new HashSet<int>();
                if(!TopologicalOrder(vertex, result, touched, currentTouched) )
                {
                    return false;
                }
            }
        }

        return true;
    }

    private bool TopologicalOrder(int vertex, List<int> result, HashSet<int> touched, HashSet<int> currentTouched)
    {
        if (currentTouched.Contains(vertex)) 
        {
            return false;
        }
        else if (touched.Contains(vertex))
        {
            return true;
        }
        else
        {
            currentTouched.Add(vertex);
            touched.Add(vertex);

            foreach (var item in content[vertex])
            {
                if (!TopologicalOrder(item, result, touched, currentTouched))
                    return false;
            }

            result.Add(vertex);
            currentTouched.Remove(vertex);

            return true;
        }
    }
}
