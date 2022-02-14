using System;
using System.Linq;
using System.Collections.Generic;

namespace LongestAbsoluteFilePath
{
    public class Solution
    {
        public int LengthLongestPath(string input)
        {
            if (input == null || input.Length == 0)
                return 0;
            string[] parts = GenerateParts(input);
            Node [] nodes = GenerateNodes(parts);
            ConnectNodes(nodes);
            UpdateMaxChildPath(nodes);
            return nodes[0].MaxChildPath + nodes[0].Value.Length ;
        }

        private void UpdateMaxChildPath(Node[] nodes)
        {
            nodes[0].Parent = new Node();

            for (int i = nodes.Length - 1; i > -1; i--)
            {
                var node = nodes[i];
                if (!node.IsFile)
                {
                    node.Parent.MaxChildPath = Math.Max(node.Parent.MaxChildPath, node.MaxChildPath + node.Value.Length + 1);
                }
                else
                {
                    node.Parent.MaxChildPath = Math.Max(node.Parent.MaxChildPath, node.Value.Length + 1);
                }
            }
        }

        private void ConnectNodes(Node [] nodes)
        {
            LinkedList<Node> path = new LinkedList<Node>();
            path.AddLast(nodes[0]);
            for(int i = 1 ; i < nodes.Length ; i ++ )
            {
                var node = nodes[i];
                while (node.Tabs < path.Last.Value.Tabs + 1)
                {
                    path.RemoveLast();
                }
                node.Parent = path.Last.Value ; 
                if( !node.IsFile)
                {
                    path.AddLast(node);
                }               
            }
        }

        private string [] GenerateParts(string input)
        {
            LinkedList<string> result = new LinkedList<string>();

            for ( int i = 0 ; i < input.Length ; i++ )
            {
                if ( input[i] == '\t' || input[i] == '\n')
                {
                    result.AddLast(input[i].ToString());
                }
                else
                {
                    int j = i + 1;   
                    for( ; j < input.Length ; j++ )
                    {
                        if( input[j] == '\t' || input[j] == '\n')
                        {
                            break;
                        }
                    }
                    result.AddLast(input.Substring(i, j - i));
                    i = j-1;
                }
            }            

            return result.ToArray();
        }

        private Node [] GenerateNodes(string [] parts)
        {
            LinkedList<Node> nodes = new LinkedList<Node>();
            
            Node node = new Node();
            nodes.AddLast(node);
            
            int index = 0;
            while(index < parts.Length)
            {
                var cPart = parts[index];

                if ( cPart == "\t")
                {
                    node.Tabs ++;
                }
                else if ( cPart == "\n")
                {
                    node = new Node();
                    nodes.AddLast(node);
                }
                else if ( IsFile(cPart))
                {
                    node.Value = cPart;
                    node.IsFile = true;
                }
                else 
                {

                    node.Value = cPart;
                    // node.IsFile = false;
                }
                index++;
            }

            return nodes.ToArray();
        }

        private bool IsFile(string cPart)
        {
            if ( cPart == null )
                return false;
            for( int i = 0 ; i < cPart.Length ; i++)
            {
                if ( cPart[i] == '.')
                {
                    if ( i < cPart.Length-1)
                      return true;
                    else
                        return false;                    
                }
            }
            return false;
        }
    }

    public class Node
    {
        public int Tabs {get;set;}
        public string Value {get;set;}
        public bool IsFile {get;set;}
        public Node Parent {get;set;}
        public int MaxChildPath {get;set;}
    }
}
