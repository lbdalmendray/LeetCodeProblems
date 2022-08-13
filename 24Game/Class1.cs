using System.Collections.Generic;

namespace _24Game
{
    public class Solution
    {
        public bool JudgePoint24(int[] cards)
        {
            string solution = null;
            return JudgePoint24(cards, false, ref solution) ;
        }

        public bool JudgePoint24(int[] cards, bool getSolution, ref string solution  )
        {
            IEnumerable<Double[]> cardPermutations = GeneratePermutations(cards.Select(e=>(double)e).ToArray());
            // '+', '-', '*', '/'
            IEnumerable<char[]> operatorEnumerable = GenerateOperators(new char[] { '+', '-', '*', '/' }, 3);

            foreach (var operators in operatorEnumerable)
            {
                var operatorsList = GeneratePermutations(operators);

                foreach (var cOperators in operatorsList)
                {
                    foreach (var cardPermutation in cardPermutations)
                    {
                        var operatorNodesPosList = GeneratePermutations(new int[] { 0, 1, 2 });

                        foreach (var operatorNodesPos in operatorNodesPosList)
                        {
                            LinkedList<object> formula = new LinkedList<object>();
                            LinkedList<LinkedListNode<object>> nodes = new LinkedList<LinkedListNode<object>>();

                            var cOperatorEnumerator = cOperators.GetEnumerator();
                            var cCardPermutationEnumerator = cardPermutation.GetEnumerator();

                            cCardPermutationEnumerator.MoveNext();
                            formula.AddLast(cCardPermutationEnumerator.Current);

                            cOperatorEnumerator.MoveNext();
                            var operator1 = formula.AddLast(cOperatorEnumerator.Current);

                            nodes.AddLast(operator1);

                            cCardPermutationEnumerator.MoveNext();
                            formula.AddLast(cCardPermutationEnumerator.Current);

                            cOperatorEnumerator.MoveNext();
                            operator1 = formula.AddLast(cOperatorEnumerator.Current);

                            nodes.AddLast(operator1);


                            cCardPermutationEnumerator.MoveNext();
                            formula.AddLast(cCardPermutationEnumerator.Current);

                            cOperatorEnumerator.MoveNext();
                            operator1 = formula.AddLast(cOperatorEnumerator.Current);

                            nodes.AddLast(operator1);

                            cCardPermutationEnumerator.MoveNext();
                            formula.AddLast(cCardPermutationEnumerator.Current);

                            if(getSolution)
                            {
                                solution = "";
                                foreach (var item in formula)
                                {
                                    solution += item;
                                }
                            }

                            var operatorNodes = nodes.ToArray();

                            bool wrongOperation = false;

                            foreach (var operatorNodesPos1 in operatorNodesPos)
                            {
                                var node = operatorNodes[operatorNodesPos1];

                                double prevValue = (double)node.Previous.Value;
                                double nextValue = (double)node.Next.Value;
                                double currentValue = 0;

                                switch ((char)node.Value)
                                {
                                    case '+':
                                        currentValue = prevValue + nextValue;
                                        break;
                                    case '-':
                                        currentValue = prevValue - nextValue;
                                        break;
                                    case '*':
                                        currentValue = prevValue * nextValue;
                                        break;
                                    case '/':
                                        if (nextValue == 0)
                                        {
                                            wrongOperation = true;
                                            break;
                                        }
                                        else
                                        {
                                            currentValue =  prevValue / nextValue ;
                                        }
                                        break;
                                }

                                if (wrongOperation)
                                    break;

                                formula.Remove(node.Previous);
                                formula.Remove(node.Next);
                                node.Value = currentValue;
                            }

                            if (wrongOperation)
                                continue;

                            var result = ((double)formula.First.Value);
                            if (Math.Abs(result - 24.0 ) <=  0.0000000000001d )
                            {
                                return true;
                            }
                        }
                    }
                }
            }

            return false;
        }

        private IEnumerable<char[]> GenerateOperators(char[] operators, int maxLength)
        {
            LinkedList<char[]> result = new LinkedList<char[]>();
            GenerateOperators(operators, maxLength, 0, 0, result, new (int, int)[operators.Length]);
            return new HashSet<(char,char,char)>
                ( 
                    result.Select(e=>(e[0],e[1],e[2]))
                )
                .Select(e=>new char[] { e.Item1, e.Item2, e.Item3 });
        }
        private void GenerateOperators(char[] operators, int maxLength, int currentAmount, int index, LinkedList<char[]> result, (int,int) [] currentValue)
        {

            if ( currentAmount == maxLength)
            {
                LinkedList<char> cResult = new LinkedList<char>();

                foreach (var item in currentValue)
                {
                    for (int i = 0; i < item.Item2; i++)
                    {
                        cResult.AddLast(operators[item.Item1]);
                    }
                }

                result.AddLast(cResult.ToArray());
            }
            else if ( index == operators.Length)
            {
                /// DO NOTHING 
            }
            else
            {
                for (int i = 0; i <= maxLength - currentAmount; i++)
                {
                    currentValue[index] = (index, i);
                    GenerateOperators(operators, maxLength, currentAmount + i, index + 1, result, currentValue);
                    currentValue[index] = (index, 0);
                }
            }
        }

        private IEnumerable<T[]> GeneratePermutations<T>(T[] cards)
        {
            LinkedList<T[]> result = new LinkedList<T[]>();
            GeneratePermutations(cards, 0, result);
            return result;
        }

        private void GeneratePermutations<T>(T[] elements, int index, LinkedList<T[]> result)
        {
            if ( index == elements.Length)
            {
                result.AddLast(elements.ToArray());
            }
            else
            {
                for (int i = index; i < elements.Length; i++)
                {
                    var swapI = elements[i];
                    elements[i] = elements[index];
                    elements[index] = swapI;
                    GeneratePermutations(elements, index + 1, result);
                    elements[index] = elements[i];
                    elements[i] = swapI;
                }
            }            
        }
    }
}