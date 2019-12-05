using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ZumaGame
{
    public class Solution
    {
        /*
         red(R), yellow(Y), blue(B), green(G), and white(W) 
        */
        public int FindMinStep(string board, string hand)
        {
            var boardGroups = GenerateGroups(board);
            var boardDictGroup = GenerateDictionaryGroup(boardGroups);

            var handDictGroup = GenerateDictionaryGroupHand(hand);

            var result = FindMinStepAux(boardGroups, boardDictGroup, handDictGroup,0);

            return result;
        }

        private int FindMinStepAux(LinkedList<Group> boardGroups, Dictionary<char, LinkedList<LinkedListNode<Group>>> boardDictGroup, Dictionary<char, int> handDictGroup, int resultCount)
        {
            if( boardGroups.Count == 0 )
            {
                return resultCount;
            }

            int result = -1;
            var keyValues = handDictGroup.Where(e => e.Value > 0).ToArray();
            foreach (var keyValue in keyValues)
            {
                handDictGroup[keyValue.Key]--;
                foreach (var nodeGroup in boardDictGroup[keyValue.Key].Where(e => e.List == boardGroups))
                {

                    LinkedList <Action> revertActions = new LinkedList<Action>();
                    nodeGroup.Value.Count++;
                    revertActions.AddFirst(() => nodeGroup.Value.Count--);

                    if( nodeGroup.Value.Count == 3)
                    {
                        GenerateRevertActions(nodeGroup, boardGroups, revertActions);
                    }

                    var currentResult = FindMinStepAux(boardGroups, boardDictGroup, handDictGroup, resultCount + 1);

                    if (currentResult != -1)
                    {
                        if (result == -1)
                            result = currentResult;
                        else
                            result = Math.Min(result, currentResult);
                    }

                    foreach (var action in revertActions)
                    {
                        action();
                    } 
                    
                }
                handDictGroup[keyValue.Key]++;
            }

            return result;
        }

        private void GenerateRevertActions(LinkedListNode<Group> nodeGroup, LinkedList<Group> boardGroups, LinkedList<Action> revertActions)
        {
            var prevNode = nodeGroup.Previous;
            var prevNodeValue1 = prevNode;

            boardGroups.Remove(nodeGroup);
            revertActions.AddFirst(() => AddNextTo(prevNodeValue1, nodeGroup, boardGroups));

            while (prevNode!= null && prevNode.Next != null && prevNode.Value.Color == prevNode.Next.Value.Color)
            {
                var sumCount = prevNode.Value.Count + prevNode.Next.Value.Count;                
                var prevPrevNode = prevNode.Previous;
                var prevNodeNext = prevNode.Next;
                var prevNodeValue = prevNode;
                
                revertActions.AddFirst(() => AddNextTo(prevNodeValue, prevNodeNext, boardGroups));
                boardGroups.Remove(prevNode.Next);

                revertActions.AddFirst(() => AddNextTo(prevPrevNode, prevNodeValue, boardGroups));
                boardGroups.Remove(prevNode);

                if (sumCount < 3)
                {
                    var newNode = new LinkedListNode<Group>(new Group { Color = prevNode.Value.Color, Count = sumCount });
                    AddNextTo(prevPrevNode, newNode, boardGroups);
                    revertActions.AddFirst(() => boardGroups.Remove(newNode));
                    break;
                }

                prevNode = prevPrevNode;               
            }
        }

        private void AddNextTo(LinkedListNode<Group> prevNode, LinkedListNode<Group> nodeGroup, LinkedList<Group> boardGroups)
        {
            if ( prevNode !=  null)
            {
                boardGroups.AddAfter(prevNode, nodeGroup);
            }
            else
            {
                boardGroups.AddFirst(nodeGroup);
            }
        }

        private Dictionary<char,int> GenerateDictionaryGroupHand(string hand)
        {
            Dictionary<char, int> result = new Dictionary<char, int>();
            for (int i = 0; i < hand.Length; i++)
            {
                if (!result.ContainsKey(hand[i]))
                    result.Add(hand[i], 0);
                result[hand[i]]++;
            }
            return result;
        }

        private Dictionary<char, LinkedList<LinkedListNode<Group>>> GenerateDictionaryGroup(LinkedList<Group> groups)
        {
            Dictionary<char, LinkedList<LinkedListNode<Group>>> result = new Dictionary<char, LinkedList<LinkedListNode<Group>>>();

            result.Add('R', new LinkedList<LinkedListNode<Group>>());
            result.Add('Y', new LinkedList<LinkedListNode<Group>>());
            result.Add('B', new LinkedList<LinkedListNode<Group>>());
            result.Add('G', new LinkedList<LinkedListNode<Group>>());
            result.Add('W', new LinkedList<LinkedListNode<Group>>());

            var node = groups.First;
            while(node != null)
            {
                result[node.Value.Color].AddLast(node);
                node = node.Next;
            }

            return result;
        }

        private LinkedList<Group> GenerateGroups(string board)
        {
            LinkedList<Group> result = new LinkedList<Group>();
            Group currentGroup = new Group { Color = board[0], Count = 1 };
            result.AddLast(currentGroup);

            for (int i = 1; i < board.Length; i++)
            {
                if(board[i] == currentGroup.Color)
                {
                    currentGroup.Count++;
                }
                else
                {
                    currentGroup = new Group { Color = board[i], Count = 1 };
                    result.AddLast(currentGroup);
                }
            }

            return result;
        }
    }

    internal class Group
    {
        public char Color { get; internal set; }
        public int Count { get; internal set; }
    }
}
