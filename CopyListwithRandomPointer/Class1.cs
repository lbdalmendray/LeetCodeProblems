using System.Collections.Generic;
using System.Linq;

namespace CopyListwithRandomPointer
{
    /*
// Definition for a Node.
public class Node {
    public int val;
    public Node next;
    public Node random;
    
    public Node(int _val) {
        val = _val;
        next = null;
        random = null;
    }
}
*/
    public class Solution
    {
        public Node CopyRandomList(Node head)
        {
            if (head == null)
                return null;

            LinkedList<Node> nodes = new LinkedList<Node>();
            var currentNode = head ;
            while(currentNode != null)
            {
                nodes.AddLast(currentNode);
                currentNode = currentNode.next; 
            }
            
            Dictionary<Node,int> indexes = new Dictionary<Node,int>(nodes.Count);
            int index = 0;
            foreach( var node1 in nodes)
            {
                indexes.Add(node1, index) ;
                index++;
            }

            return CloneAll(nodes,indexes);                  
        }

        private Node CloneAll(LinkedList<Node> nodes , Dictionary<Node,int> indexes ) 
        {
            var cloneNodes = nodes.Select(e=>Clone(e)).ToArray();
            int lengthLess1 =  cloneNodes.Length - 1 ;            
            for(int i = 0 ; i < lengthLess1; i++)            
            {
                cloneNodes[i].next = cloneNodes[i+1];
            }
            int index = 0;
            foreach( var node in nodes)
            {
                if( node.random != null)
                    cloneNodes[index].random = cloneNodes[indexes[node.random]];
                index++;
            }
            
            return cloneNodes[0];
        }

        private Node Clone(Node node)
        {
            return new Node(node.val);
        }
    }
}
