
namespace BinaryTreeVerticalOrderTraversal
{
    public class Solution
    {
        const int rowRange = 100;
        const int columnRange = 200;
        
        public IList<IList<int>> VerticalOrder(TreeNode root)
        {
            List<int>[,] matrix = new List<int>[rowRange, columnRange];
            ProcessMatrix(root, 0, 0, matrix, columnRange/2);
            List<List<int>> result = new List<List<int>>();
            for (int i = 0; i < columnRange; i++)
            {
                List<int> currentList = new List<int>();
                result.Add(currentList);

                for (int j = 0; j < rowRange; j++)
                {
                    if (matrix[j, i] != null)
                    {
                        foreach (var item in matrix[j, i])
                        {
                            currentList.Add(item);
                        }
                    }
                }
            }

            return result
                .Select(e => e as IList<int>)
                .Where(e=>e?.Count > 0 )
                .ToList();
        }

        private void ProcessMatrix(TreeNode node, int row, int col, List<int>[,]  matrix, int columMax )
        {
            if ( node != null )
            {
                if (matrix[row, columMax + col] == null)
                    matrix[row, columMax + col] = new List<int>();

                matrix[row, columMax + col].Add(node.val);

                if ( node.left != null)
                {
                    ProcessMatrix(node.left, row + 1, col - 1, matrix,  columMax);
                }

                if (node.right != null)
                {
                    ProcessMatrix(node.right, row + 1, col + 1, matrix, columMax);
                }
            }
        }
    }
}
