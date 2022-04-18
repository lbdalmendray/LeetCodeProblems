using System;
using System.Collections.Generic;
using System.Linq;
using Tree = System.Collections.Generic.Dictionary<string, System.Collections.Generic.Dictionary<string, double>>;

namespace EvaluateDivision
{
    public class Solution
    {
        public double[] CalcEquation(
            IList<IList<string>> equations
            , double[] values
            , IList<IList<string>> queries)
        {
            var tree = GenerateTree(equations, values);

            LinkedList<double> result = new LinkedList<double>();

            for (int i = 0; i < queries.Count; i++)
            {
                var query = queries[i];
                var Ai = query[0];
                var Bi = query[1];
                LinkedList<string> path = CalculateMinPath(Ai, Bi, tree);
                if (path == null)
                {
                    result.AddLast(-1.0);
                }
                else
                {
                    double product = 1;
                    while (path.Count > 1)
                    {
                        var second = path.Last.Value;
                        path.RemoveLast();
                        var first = path.Last.Value;
                        var coeficient = tree[first][second];
                        product *= coeficient;
                    }
                    result.AddLast(product);
                }
            }

            return result.ToArray();
        }

        private LinkedList<string> CalculateMinPath(string Ai, string Bi, Tree tree)
        {
            if (!tree.ContainsKey(Ai) || !tree.ContainsKey(Bi))
                return null;

            if ( Ai == Bi)
            {
                var result = new LinkedList<string>();
                result.AddLast(Ai);
                return result;
            }
            else
            {
                Dictionary<string, string> selectedParent = new Dictionary<string, string>();
                selectedParent.Add(Ai, null);

                LinkedList<string> queue = new LinkedList<string>();
                queue.AddLast(Ai);

                while (queue.Count != 0)
                {
                    var aiValue = queue.First.Value;
                    queue.RemoveFirst();

                    foreach (var (bi, coef) in tree[aiValue].Where(kv => !selectedParent.ContainsKey(kv.Key)))
                    {
                        selectedParent.Add(bi, aiValue);
                        queue.AddLast(bi);
                        if (bi == Bi)
                        {
                            return CalculateMinPathFrom(selectedParent, Ai, Bi);
                        }
                    }
                }

                return null;
            }            
        }

        private LinkedList<string> CalculateMinPathFrom(Dictionary<string, string> selectedParent, string ai, string bi)
        {
            LinkedList<string> result = new LinkedList<string>();

            string currentI = bi;
            result.AddFirst(currentI);
            while(currentI != ai)
            {
                currentI = selectedParent[currentI];
                result.AddFirst(currentI);
            }

            return result;
        }

        private Tree GenerateTree(IList<IList<string>> equations, double[] values)
        {
            Tree result = new Tree();

            for (int i = 0; i < equations.Count; i++)
            {
                var equation = equations[i];
                var Ai = equation[0];
                var Bi = equation[1];
                var valuei = values[i];

                if ( !result.TryGetValue(Ai, out var aiDict))
                {
                    aiDict = new Dictionary<string, double>();
                    result[Ai] = aiDict;
                }

                aiDict[Bi] = valuei;

                if (!result.TryGetValue(Bi, out var biDict))
                {
                    biDict = new Dictionary<string, double>();
                    result[Bi] = biDict;
                }

                biDict[Ai] = 1.0/valuei;
            }

            return result;
        }
    }
}
