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
        bool [] touched = new bool[content.Length];

        if( TopologicalOrder(result, touched))
            return result.ToArray();
        else
        {
            return [];
        }    
    }

    private bool TopologicalOrder(List<int> result, bool[] touched)
    {
        for (int vertex = 0; vertex < content.Length; vertex++)
        {
            if (touched[vertex])
                continue;
            else
            {
                bool[] currentTouched = new bool[content.Length];
                if (!TopologicalOrder(vertex, result, touched, currentTouched) )
                {
                    return false;
                }
            }
        }

        return true;
    }

    private bool TopologicalOrder(int vertex, List<int> result, bool[] touched, bool[] currentTouched)
    {
        if (currentTouched[vertex]) 
        {
            return false;
        }
        else if (touched[vertex])
        {
            return true;
        }
        else
        {
            currentTouched[vertex] = true;
            touched[vertex] = true;

            foreach (var item in content[vertex])
            {
                if (!TopologicalOrder(item, result, touched, currentTouched))
                    return false;
            }

            result.Add(vertex);
            currentTouched[vertex] = false;

            return true;
        }
    }
}
