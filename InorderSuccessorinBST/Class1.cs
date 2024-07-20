
namespace InorderSuccessorinBST;

public class Solution
{
    public TreeNode InorderSuccessor(TreeNode root, TreeNode p)
    {
        if (p.right != null)
        {
            var min = p.right;
            while (min.left != null)
                min = min.left;
            return min;
        }
        else if (root == p)
        {
            return null!;
        }
        else
        {
            LinkedList<TreeNode> parents = new LinkedList<TreeNode>();
            InorderSuccessor(parents, root, p, out TreeNode result);
            return result;
        }
    }

    private bool InorderSuccessor(LinkedList<TreeNode> parents, TreeNode current, TreeNode p, out TreeNode result)
    {
        if ( current == null)
        {
            result = null!;
            return false;
        }
        if (current == p)
        {
            var currentChild = p;
            var currentParentNode = parents.Last;

            while( currentParentNode?.Value.right == currentChild)
            {
                currentChild = currentParentNode.Value;
                currentParentNode = currentParentNode.Previous;
            }
            if (currentParentNode != null)
                result = currentParentNode.Value;
            else
                result = null!;
            return true;
        }

        parents.AddLast(current);
        try
        {
            if (InorderSuccessor(parents, current.left, p, out result))
            {
                return true;
            }
            else
                return InorderSuccessor(parents, current.right, p, out result);
        }
        finally
        {
            parents.RemoveLast();
        }
    }
}
