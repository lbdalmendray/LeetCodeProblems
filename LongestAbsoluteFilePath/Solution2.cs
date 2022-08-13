using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LongestAbsoluteFilePath
{
    public class Solution2
    {
        public int LengthLongestPath(string input)
        {
            Node2 root = new Node2 
            { 
                Level = -1 
                , NameLength = -1
                , IsDir = true };
            var inputParts = input.Split('\n');

            Node2 result = null;

            Node2 lastNode = root;
            for (int i = 0; i < inputParts.Length; i++)
            {
                var inputPart = inputParts[i];
                int level = 0;
                for (int j = 0; j < inputPart.Length; j++)
                {
                    if (inputPart[j] == '\t')
                        level++;
                    else
                        break;
                }

                Node2 newNode = new Node2
                {
                    IsDir = !inputPart.Skip(level).Contains('.'),
                    Level = level
                };
                while( lastNode.Level > newNode.Level-1)
                    lastNode = lastNode.Parent;
                newNode.Parent = lastNode;
                newNode.NameLength = newNode.Parent.NameLength + 1 + inputPart.Length -level ;

                lastNode = newNode;
                if ( !newNode.IsDir) //// IS FILE
                {
                    if( result == null || result.NameLength < newNode.NameLength)
                        result = newNode;
                }
            }

            if (result == null)
            {
                return 0;
            }
            else
            {
                return result.NameLength;
            }
        }
    }

    public class Node2
    {
        public int Level { get; set; }
        public int NameLength { get; set; }
        public bool IsDir { get; set; }
        public Node2 Parent { get; set; }
    }
}
