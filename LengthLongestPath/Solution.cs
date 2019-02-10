using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LengthLongestPath
{
    public class Solution
    {
        public int LengthLongestPath(string input)
        {
            LinkedList<char> currentName = new LinkedList<char>();
            Tree tree = new Tree();

            TreeNodeType newType = TreeNodeType.Directory;
            int newLevel = 1;

            for (int i = 0; i < input.Length; i++)
            {                 
                if ( input[i] != '\n')
                {
                    if (input[i] == '.')
                    {
                        newType = TreeNodeType.File;
                    }
                    currentName.AddLast(input[i]);
                }
                else
                {

                    tree.CreateNewItem(currentName, newLevel, newType);
                    
                    currentName = new LinkedList<char>();
                    newType = TreeNodeType.Directory;
                    newLevel = 1;
                    int j = i + 1;
                    for (; j < input.Length; j++)
                    {
                        if ( input[j] != '\t')
                        {
                            break;
                        }
                        newLevel++;
                    }
                    j--;
                    i = j;                    
                }
            }

            tree.CreateNewItem(currentName, newLevel, newType);

            return tree.LengthLongFilePath;
        }
    }

    public class Tree
    {
        public TreeNode root = new TreeNode { Level = 0, TreeNodeType = TreeNodeType.Directory, PathLength = -1 };
        public TreeNode CurrentNode;
        public int LengthLongFilePath = 0;
        public Tree ()
        {
            CurrentNode = root;
        }
        public int CurrentLevel { get { return CurrentNode.Level; } }

        internal void CreateNewItem(LinkedList<char> currentName, int newLevel, TreeNodeType newType)
        {
            while ( newLevel != CurrentLevel + 1 )
            {
                CurrentNode = CurrentNode.Father;
            }

            CurrentNode.Children.AddLast(new TreeNode { Father = CurrentNode, Level = newLevel, Name = currentName, TreeNodeType = newType, PathLength = CurrentNode.PathLength + currentName.Count + 1 });
            CurrentNode = CurrentNode.Children.Last.Value;
            if ( CurrentNode.TreeNodeType ==  TreeNodeType.File && LengthLongFilePath < CurrentNode.PathLength)
            {
                LengthLongFilePath = CurrentNode.PathLength;
            }
        }
    }

    public class TreeNode
    {
        public TreeNodeType TreeNodeType;
        public int Level;
        public LinkedList<TreeNode> Children = new LinkedList<TreeNode>();
        public LinkedList<char> Name;
        public TreeNode Father { get; set; }
        public int PathLength { get; set; }
    }

    public enum TreeNodeType
    {
        Directory ,
        File,

    }

}
