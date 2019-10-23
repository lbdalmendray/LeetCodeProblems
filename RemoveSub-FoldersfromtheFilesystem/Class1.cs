using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoveSub_FoldersfromtheFilesystem
{
    public class Solution
    {
        public IList<string> RemoveSubfolders(string[] folder)
        {
            Node root = new Node();
            foreach (var item in folder)
            {
                AddFolderToRoot(item, root);
            }

            LinkedList<string> result = new LinkedList<string>();
            DFS(root, result, new LinkedList<string>() );

            return result.ToList() as IList<string>;
        }

        private void DFS(Node root, LinkedList<string> result, LinkedList<string> currentPath)
        {
            if (root.IsImportant)
            {
                result.AddLast(Concatenate(currentPath));
                return;
            }
            foreach (var key in root.childs.Keys)
            {
                currentPath.AddLast("/" + key);
                DFS(root.childs[key], result, currentPath);
                currentPath.RemoveLast();
            }
        }

        private string Concatenate(LinkedList<string> currentPath)
        {
            LinkedList<char> result = new LinkedList<char>();
            foreach (var item in currentPath)
            {
                foreach (var item2 in item)
                {
                    result.AddLast(item2);
                }
            }
            return new string(result.ToArray());
        }

        private void AddFolderToRoot(string item, Node root)
        {
            Node currentNode = root;
            var parts = item.Split('/');
            for (int i = 1; i < parts.Length; i++)
            {
                if( !currentNode.childs.ContainsKey( parts[i]))
                {
                    currentNode.childs.Add(parts[i], new Node());
                }
                currentNode = currentNode.childs[parts[i]];
            }

            currentNode.IsImportant = true;
        }
    }

    public class Node
    {
        public bool IsImportant { get; set; }
        public Dictionary<string, Node> childs = new Dictionary<string, Node>(); 
    }
}
