namespace LowestCommonAncestorOfABinaryTreeIII;

public class Solution
{
    public Node LowestCommonAncestor(Node p, Node q)
    {
        HashSet<Node> processedNodes = new HashSet<Node>();

        if (p == q)
            return p;
        else
        {
            processedNodes.Add(p);
            processedNodes.Add(q);

            while (p != null || q != null)
            {
                p = p?.parent!;

                if (p != null)
                {
                    if (processedNodes.Contains(p))
                    {
                        return p;
                    }
                    else
                        processedNodes.Add(p);
                }

                q = q?.parent!;

                if (q != null)
                {
                    if (processedNodes.Contains(q))
                    {
                        return q;
                    }
                    else
                        processedNodes.Add(q);
                }
            }

            return null!;
        }
    }
}