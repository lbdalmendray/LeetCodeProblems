namespace MinimumStringLengthAfterRemovingSubstrings
{
    public class Solution
    {
        public int MinLength(string s)
        {
            LinkedList<char> charList = new LinkedList<char>();
            
            for (int i = 0; i < s.Length; i++)
                charList.AddLast(s[i]);

            LinkedListNode<char> currentNode = charList.First;

            while( currentNode != null)
            {
                if ( Condition(currentNode))
                {
                    var nextCurrentNode = currentNode.Previous == null
                         ? currentNode.Next.Next
                         : currentNode.Previous;
                    charList.Remove(currentNode.Next);
                    charList.Remove(currentNode);
                    currentNode = nextCurrentNode;
                }
                else
                {
                    currentNode = currentNode.Next;
                }
            }

            return charList.Count;
        }

        private bool Condition(LinkedListNode<char> currentNode)
        {
            if (currentNode.Next == null)
                return false;
            else
            {
                return (currentNode.Value == 'A' && currentNode.Next.Value == 'B')
                || (currentNode.Value == 'C' && currentNode.Next.Value == 'D');
            }
        }
    }
}