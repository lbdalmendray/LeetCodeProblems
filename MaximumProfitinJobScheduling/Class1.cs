using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaximumProfitinJobScheduling
{
    public class Solution
    {
        public int JobScheduling(int[] startTime, int[] endTime, int[] profit)
        {
            int[][] values = new int[startTime.Length][];
            for (int i = 0; i < startTime.Length; i++)
            {
                values[i] = new int[] { startTime[i], endTime[i], profit[i] };
            }

            Array.Sort(startTime, values);

            MyAVLTree<int, int> solutions = new MyAVLTree<int, int>();
            for (int i = values.Length - 1; i >= 0; i--)
            {
                var currentValue = values[i];

                if (!solutions.SearchGTE(currentValue[0], out AVLNodeKey<int, int> lastNotNullStart) && lastNotNullStart == null)
                {
                    lastNotNullStart = solutions.Insert(currentValue[0], currentValue[2]);
                }
                var searchResultEnd = solutions.SearchGTE(currentValue[1], out AVLNodeKey<int, int> lastNotNullEnd);

                int complement = 0;

                if( searchResultEnd )
                {
                    complement = lastNotNullEnd.Values.First.Value.Value;
                }
                else
                {
                    if ( lastNotNullEnd != null && lastNotNullEnd.Key >= currentValue[1])
                    {
                        complement = lastNotNullEnd.Values.First.Value.Value;
                    }
                }

                if (lastNotNullStart.Key == currentValue[0])
                    lastNotNullStart.Values.First.Value.Value = Math.Max(currentValue[2] + complement, lastNotNullStart.Values.First.Value.Value);
                else
                    solutions.Insert(currentValue[0], Math.Max(currentValue[2] + complement, lastNotNullStart.Values.First.Value.Value));
            }

            return solutions.DFSSortedElements().Max(e => e.Value);
        }
    }

    /// <summary>
    /// AVL tree implementado por mi , Luis Benavides Dalmendray  
    /// Cuando hay llaves iguales y se quiere permitir se va a utilizar una lista de iguales por el mismo Key 
    /// </summary>
    public class MyAVLTree<TKey, TValue>
    {
        public AVLNodeKey<TKey, TValue> root;

        public int Count { get; protected set; }

        public MyAVLTree()
        {
            Comparer = Comparer<TKey>.Default;
        }
        public MyAVLTree(IComparer<TKey> comparer)
        {
            this.Comparer = comparer;
        }
        /// <summary>
        /// Insertar si key no existe en el MyAVLTree
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public AVLNodeKey<TKey, TValue> Insert(TKey key, TValue value)
        {
            if (root == null)
            {
                root = new AVLNodeKey<TKey, TValue>(key, value);
                Count++;
                return root;
            }

            AVLNodeKey<TKey, TValue> lastNotNull;
            if (Search(key, out lastNotNull))
                throw new Exception("This key has been inserted");
            AVLNodeKey<TKey, TValue> result = null;
            var resultCompare = Comparer.Compare(lastNotNull.Key, key);
            if (resultCompare < 0)
            {
                lastNotNull.RigthChild = new AVLNodeKey<TKey, TValue>(key, value) { Father = lastNotNull };
                result = lastNotNull.RigthChild;
            }
            else
            {
                lastNotNull.LeftChild = new AVLNodeKey<TKey, TValue>(key, value) { Father = lastNotNull };
                result = lastNotNull.LeftChild;
            }
            UpdateHeightFrom(lastNotNull);
            UpdateBalance(lastNotNull);
            Count++;
            return result;
        }
        /// <summary>
        /// Insertar y permite tener llaves repetidas . Almacena una lista
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public AVLNodeKey<TKey, TValue> InsertRepeat(TKey key, TValue value)
        {
            if (root == null)
            {
                root = new AVLNodeKey<TKey, TValue>(key, value);
                Count++;
                return root;
            }

            AVLNodeKey<TKey, TValue> lastNotNull;
            if (Search(key, out lastNotNull))
            {
                lastNotNull.Values.AddLast(new AVLNodeValue<TValue, AVLNodeKey<TKey, TValue>>
                {
                    Father = lastNotNull
                ,
                    Value = value
                });
                Count++;
                return lastNotNull;
            }
            else
            {
                AVLNodeKey<TKey, TValue> result = null;
                var resultCompare = Comparer.Compare(lastNotNull.Key, key);
                if (resultCompare < 0)
                {
                    lastNotNull.RigthChild = new AVLNodeKey<TKey, TValue>(key, value) { Father = lastNotNull };
                    result = lastNotNull.RigthChild;
                }
                else
                {
                    lastNotNull.LeftChild = new AVLNodeKey<TKey, TValue>(key, value) { Father = lastNotNull };
                    result = lastNotNull.LeftChild;
                }
                UpdateHeightFrom(lastNotNull);
                UpdateBalance(lastNotNull);
                Count++;
                return result;
            }
        }
        public void Remove(TKey key)
        {
            if (!TryRemove(key, false))
                throw new Exception("This key has not been inserted");
        }

        public void RemoveOne(TKey key)
        {
            if (!TryRemove(key, true))
                throw new Exception("This key has not been inserted");
        }


        void Swap(AVLNodeKey<TKey, TValue> node1, AVLNodeKey<TKey, TValue> node2)
        {
            if (node1 == root)
                root = node2;
            if (node2 == root)
                root = node1;

            var node1IsRightChild = node1.IsRightChild();
            var node2IsRightChild = node2.IsRightChild();
            var node1Height = node1.Height;
            node1.Height = node2.Height;
            node2.Height = node1Height;

            var node1Father = node1.Father;
            var node2Father = node2.Father;

            var node1LeftChild = node1.LeftChild;
            var node2LeftChild = node2.LeftChild;

            var node1RightChild = node1.RigthChild;
            var node2RightChild = node2.RigthChild;

            if (!((node1.Father == node2) || (node2.Father == node1)))
            {
                SwapFathersEspecial(node1, node2);
                SwapRightChildEspecial(node1, node2);
                SwapLeftChildEspecial(node1, node2);
            }

            else if (node1.Father == node2)
            {
                SwapWithOneFatherOfTheOther(node2, node1);
            }
            else
            {
                SwapWithOneFatherOfTheOther(node1, node2);
            }
        }

        private void SwapWithOneFatherOfTheOther(AVLNodeKey<TKey, TValue> node1, AVLNodeKey<TKey, TValue> node2)
        {
            var node1Father = node1.Father;
            var node1IsRightChild = node1.IsRightChild();
            var node2IsRightChild = node2.IsRightChild();
            var node1RightChild = node1.RigthChild;
            var node2RightChild = node2.RigthChild;
            var node1LeftChild = node1.LeftChild;
            var node2LeftChild = node2.LeftChild;

            node1.Father = node2;
            node2.Father = node1Father;

            if (node1IsRightChild)
            {
                node2.Father.RigthChild = node2;
            }
            else
            {
                if (node1Father != null)
                {
                    node2.Father.LeftChild = node2;
                }
            }

            if (node2IsRightChild)
            {
                node2.RigthChild = node1;
                node2.LeftChild = node1LeftChild;
                if (node2.LeftChild != null)
                    node2.LeftChild.Father = node2;
            }
            else
            {
                node2.LeftChild = node1;
                node2.RigthChild = node1RightChild;
                if (node2.RigthChild != null)
                    node2.RigthChild.Father = node2;
            }

            node1.RigthChild = node2RightChild;
            if (node1.RigthChild != null)
                node1.RigthChild.Father = node1;
            node1.LeftChild = node2LeftChild;
            if (node1.LeftChild != null)
                node1.LeftChild.Father = node1;
        }

        private void SwapLeftChildEspecial(AVLNodeKey<TKey, TValue> node1, AVLNodeKey<TKey, TValue> node2)
        {
            var node1LeftChild = node1.LeftChild;
            var node2LeftChild = node2.LeftChild;

            node1.LeftChild = node2LeftChild;
            if (node1.LeftChild != null)
                node1.LeftChild.Father = node1;


            node2.LeftChild = node1LeftChild;
            if (node2.LeftChild != null)
                node2.LeftChild.Father = node2;
        }

        private void SwapRightChildEspecial(AVLNodeKey<TKey, TValue> node1, AVLNodeKey<TKey, TValue> node2)
        {
            var node1RightChild = node1.RigthChild;
            var node2RightChild = node2.RigthChild;

            node1.RigthChild = node2RightChild;
            if (node1.RigthChild != null)
                node1.RigthChild.Father = node1;


            node2.RigthChild = node1RightChild;
            if (node2.RigthChild != null)
                node2.RigthChild.Father = node2;
        }

        /// <summary>
        /// Cambia los padres cuando no son padres e hijos entre ellos
        /// </summary>
        /// <param name="node1"></param>
        /// <param name="node2"></param>
        private void SwapFathersEspecial(AVLNodeKey<TKey, TValue> node1, AVLNodeKey<TKey, TValue> node2)
        {
            var father1 = node1.Father;
            var father2 = node2.Father;
            var node1IsRightChild = node1.IsRightChild();
            var node2IsRightChild = node2.IsRightChild();

            node2.Father = father1;
            if (node1IsRightChild)
                father1.RigthChild = node2;
            else if (father1 != null)
                father1.LeftChild = node2;

            node1.Father = father2;
            if (node2IsRightChild)
                father2.RigthChild = node1;
            else if (father2 != null)
                father2.LeftChild = node1;
        }

        public bool TryRemove(TKey key, bool justOneElement)
        {
            AVLNodeKey<TKey, TValue> lastNotNull;
            if (Search(key, out lastNotNull))
            {
                if (justOneElement && lastNotNull.Values.Count > 1)
                {
                    lastNotNull.Values.RemoveFirst();
                    Count--;
                    return true;
                }
                var candidate = Minimum(lastNotNull.RigthChild);
                if (candidate != null)
                {
                    if (candidate.RigthChild != null)
                    {
                        Swap(candidate, candidate.RigthChild);
                    }
                }
                else
                {
                    candidate = Maximum(lastNotNull.LeftChild);
                    if (candidate != null && candidate.LeftChild != null)
                    {
                        Swap(candidate, candidate.LeftChild);
                    }
                }

                if (candidate != null)
                {
                    Swap(candidate, lastNotNull);
                    var lastNotFullFather = lastNotNull.Father;
                    if (lastNotNull.IsRightChild())
                    {
                        lastNotNull.Father.RigthChild = null;
                    }
                    else if (lastNotNull.Father != null)
                    {
                        lastNotNull.Father.LeftChild = null;
                    }
                    UpdateHeightFrom(lastNotFullFather);
                    UpdateBalance(lastNotFullFather);
                }
                else
                {
                    var lastnotNUllFather = lastNotNull.Father;
                    if (lastNotNull.IsRightChild())
                    {
                        lastNotNull.Father.RigthChild = null;
                    }
                    else if (lastNotNull.Father != null)
                    {
                        lastNotNull.Father.LeftChild = null;
                    }
                    if (root == lastNotNull)
                        root = null;

                    UpdateHeightFrom(lastnotNUllFather);
                    UpdateBalance(lastnotNUllFather);
                }

                Count--;
                return true;
            }
            return false;
        }

        protected Action<AVLNodeKey<TKey, TValue>> UpdateSomeThingLikeHeightFrom;

        private void UpdateHeightFrom(AVLNodeKey<TKey, TValue> node)
        {
            if (node == null)
                return;

            var nodeCurrent = node;
            int maxchildHeight = nodeCurrent.LeftChild == null ? -1 : nodeCurrent.LeftChild.Height;
            maxchildHeight = (nodeCurrent.RigthChild != null && maxchildHeight < nodeCurrent.RigthChild.Height) ? nodeCurrent.RigthChild.Height : maxchildHeight;
            while (maxchildHeight + 1 != nodeCurrent.Height)
            {
                nodeCurrent.Height = maxchildHeight + 1;
                nodeCurrent = nodeCurrent.Father;
                if (nodeCurrent != null)
                {
                    maxchildHeight = nodeCurrent.LeftChild == null ? -1 : nodeCurrent.LeftChild.Height;
                    maxchildHeight = (nodeCurrent.RigthChild != null && maxchildHeight < nodeCurrent.RigthChild.Height) ? nodeCurrent.RigthChild.Height : maxchildHeight;
                }
                else
                {
                    break;
                }
            }
            if (UpdateSomeThingLikeHeightFrom != null)
                UpdateSomeThingLikeHeightFrom(node);
        }

        private void UpdateBalance(AVLNodeKey<TKey, TValue> node)
        {
            if (node == null)
                return;

            while (node != null && node.Balance == Balance.Balanced)
            {
                node = node.Father;
            }

            if (node == null)
                return;

            if (node.Balance == Balance.LeftUnBalanced)
            {
                if (node.LeftChild.SimpleBalance == Balance.RightUnBalanced)
                {
                    node.LeftChild.RotateToLeft();
                }
                node.RotateToRight();
                if (node == root)
                    root = node.Father;
            }
            else if (node.Balance == Balance.RightUnBalanced)
            {
                if (node.RigthChild.SimpleBalance == Balance.LeftUnBalanced)
                {
                    node.RigthChild.RotateToRight();
                }
                node.RotateToLeft();
                if (node == root)
                    root = node.Father;
            }
            UpdateHeightFrom(node.Father.Father);
        }
        public AVLNodeKey<TKey, TValue> Minimum(AVLNodeKey<TKey, TValue> avlNodeRoot)
        {
            if (avlNodeRoot == null)
                return null;
            AVLNodeKey<TKey, TValue> lastNotNull = avlNodeRoot;
            while (true)
            {
                if (lastNotNull.LeftChild != null)
                {
                    lastNotNull = lastNotNull.LeftChild;
                    continue;
                }
                return lastNotNull;
            }
        }
        public AVLNodeKey<TKey, TValue> Maximum(AVLNodeKey<TKey, TValue> avlNodeRoot)
        {
            if (avlNodeRoot == null)
                return null;
            AVLNodeKey<TKey, TValue> lastNotNull = avlNodeRoot;
            while (true)
            {
                if (lastNotNull.RigthChild != null)
                {
                    lastNotNull = lastNotNull.RigthChild;
                    continue;
                }
                return lastNotNull;
            }
        }
        public bool Contains(TKey key)
        {
            AVLNodeKey<TKey, TValue> lastNotNull;
            return Search(key, out lastNotNull);
        }
        public bool Search(TKey key, out AVLNodeKey<TKey, TValue> lastNotNull)
        {
            lastNotNull = root;
            while (lastNotNull != null)
            {
                var result = Comparer.Compare(lastNotNull.Key, key);
                if (result == 0)
                    return true;
                else if (result < 0)
                {
                    if (lastNotNull.RigthChild == null)
                        break;
                    lastNotNull = lastNotNull.RigthChild;
                }
                else
                {
                    if (lastNotNull.LeftChild == null)
                        break;
                    lastNotNull = lastNotNull.LeftChild;
                }
            }
            return false;
        }

        public bool SearchGTE(TKey key, out AVLNodeKey<TKey, TValue> resultNode)
        {
            resultNode = null;
            AVLNodeKey<TKey, TValue> lastNotNull = root;
            while (lastNotNull != null)
            {
                var result = Comparer.Compare(lastNotNull.Key, key);
                if (result == 0)
                {
                    resultNode = lastNotNull;
                    return true;
                }
                else if (result < 0)
                {
                    if (lastNotNull.RigthChild == null)
                        break;
                    lastNotNull = lastNotNull.RigthChild;
                }
                else
                {
                    resultNode = lastNotNull;
                    if (lastNotNull.LeftChild == null)
                        break;
                    lastNotNull = lastNotNull.LeftChild;
                }
            }
            return resultNode != null;
        }
        public IComparer<TKey> Comparer { get; protected set; }
        public int Height { get { return root == null ? -1 : root.Height; } }

        public KeyValuePair<TKey, TValue>[] DFSSortedElements()
        {
            var result = new LinkedList<KeyValuePair<TKey, TValue>>();
            BFS(root, result);
            return result.ToArray();
        }

        public KeyValuePair<TKey, TValue>[] BFSSortedElements()
        {
            var node = root;
            LinkedList<AVLNodeKey<TKey, TValue>> queue = new LinkedList<AVLNodeKey<TKey, TValue>>();
            LinkedList<KeyValuePair<TKey, TValue>> result = new LinkedList<KeyValuePair<TKey, TValue>>();
            queue.AddLast(node);

            while (queue.Count != 0)
            {
                var element = queue.First.Value;
                queue.RemoveFirst();
                if (element.LeftChild != null)
                    queue.AddLast(element.LeftChild);
                if (element.RigthChild != null)
                    queue.AddLast(element.RigthChild);
                foreach (var item in element.Values.Select(v => new KeyValuePair<TKey, TValue> { Key = element.Key, Value = v.Value }))
                {
                    result.AddLast(item);
                }
            }

            return result.ToArray();
        }

        private void BFS(AVLNodeKey<TKey, TValue> currentNode, LinkedList<KeyValuePair<TKey, TValue>> result)
        {
            if (currentNode == null)
                return;
            if (currentNode.IsLeaf)
            {
                foreach (var item in currentNode.Values.Select(v => new KeyValuePair<TKey, TValue> { Key = currentNode.Key, Value = v.Value }))
                {
                    result.AddLast(item);
                }

            }
            else
            {
                BFS(currentNode.LeftChild, result);
                foreach (var item in currentNode.Values.Select(v => new KeyValuePair<TKey, TValue> { Key = currentNode.Key, Value = v.Value }))
                {
                    result.AddLast(item);
                }
                BFS(currentNode.RigthChild, result);
            }

        }

        /// <summary>
        /// Este método es para probar cuan bueno es el árbol pero no debe utilizarse 
        /// </summary>
        /// <returns></returns>
        public bool IsBalanceRecursive()
        {
            if (root != null)
                return root.IsBalanceRecursive();
            return true;
        }
    }

    public class AVLNodeKey<TKey, TValue>
    {
        public AVLNodeKey()
        {
            Values = new LinkedList<AVLNodeValue<TValue, AVLNodeKey<TKey, TValue>>>();
        }
        public AVLNodeKey(TKey key, TValue value)
            : this()
        {
            this.Key = key;
            Values.AddLast(new AVLNodeValue<TValue, AVLNodeKey<TKey, TValue>> { Value = value, Father = this });
        }
        public AVLNodeKey<TKey, TValue> Father { get; internal set; }
        public AVLNodeKey<TKey, TValue> LeftChild { get; internal set; }
        public AVLNodeKey<TKey, TValue> RigthChild { get; internal set; }
        public TKey Key { get; set; }
        public LinkedList<AVLNodeValue<TValue, AVLNodeKey<TKey, TValue>>> Values { get; internal set; }

        public int Height { get; internal set; }

        internal void UpdateFather(AVLNodeKey<TKey, TValue> node)
        {
            if (Father == null)
                return;

            if (Father.LeftChild == node)
            {
                Father.LeftChild = this;
            }
            else
            {
                Father.RigthChild = this;
            }
        }

        internal void UpdateLeftChild()
        {
            if (LeftChild == null)
                return;

            LeftChild.Father = this;
        }
        internal void UpdateRightChild()
        {
            if (RigthChild == null)
                return;

            RigthChild.Father = this;
        }

        internal bool IsRightChild()
        {
            if (Father != null && Father.RigthChild == this)
            {
                return true;
            }

            return false;
        }

        internal void RotateToLeft()
        {
            var father = Father;
            var rightChild = RigthChild;

            RigthChild = rightChild.LeftChild;
            if (RigthChild != null)
                RigthChild.Father = this;

            Father = rightChild;
            rightChild.LeftChild = this;
            rightChild.Father = father;
            if (father != null)
            {
                if (father.LeftChild == this)
                    father.LeftChild = rightChild;
                else
                    father.RigthChild = rightChild;
            }
            Height = Math.Max(LeftChild == null ? -1 : LeftChild.Height, RigthChild == null ? -1 : RigthChild.Height) + 1;
            Father.Height = Math.Max(Father.LeftChild == null ? -1 : Father.LeftChild.Height, Father.RigthChild == null ? -1 : Father.RigthChild.Height) + 1;
        }

        internal void RotateToRight()
        {
            var father = Father;
            var leftChild = LeftChild;

            LeftChild = leftChild.RigthChild;
            if (LeftChild != null)
                LeftChild.Father = this;

            Father = leftChild;
            leftChild.RigthChild = this;
            leftChild.Father = father;
            if (father != null)
            {
                if (father.LeftChild == this)
                    father.LeftChild = leftChild;
                else
                    father.RigthChild = leftChild;
            }
            Height = Math.Max(LeftChild == null ? -1 : LeftChild.Height, RigthChild == null ? -1 : RigthChild.Height) + 1;
            Father.Height = Math.Max(Father.LeftChild == null ? -1 : Father.LeftChild.Height, Father.RigthChild == null ? -1 : Father.RigthChild.Height) + 1;
        }
        /// <summary>
        /// Balance normal con diferencia a lo sumo de 1 sino desbalanceado
        /// </summary>
        internal Balance Balance
        {
            get
            {
                int balance = (RigthChild == null ? -1 : RigthChild.Height) - (LeftChild == null ? -1 : LeftChild.Height);
                if (balance > 1)
                {
                    return Balance.RightUnBalanced;
                }
                else if (balance < -1)
                    return Balance.LeftUnBalanced;
                return Balance.Balanced;
            }
        }

        /// <summary>
        /// Balance Simple con diferencia a lo sumo de 0 sino desbalanceado
        /// </summary>
        internal Balance SimpleBalance
        {
            get
            {
                int balance = (RigthChild == null ? -1 : RigthChild.Height) - (LeftChild == null ? -1 : LeftChild.Height);
                if (balance > 0)
                {
                    return Balance.RightUnBalanced;
                }
                else if (balance < 0)
                    return Balance.LeftUnBalanced;
                return Balance.Balanced;
            }
        }

        public override string ToString()
        {
            return Key.ToString();
        }

        internal bool IsBalanceRecursive()
        {
            if (IsLeaf)
                return true;
            if (LeftChild != null && !LeftChild.IsBalanceRecursive())
                return false;
            if (RigthChild != null && !RigthChild.IsBalanceRecursive())
                return false;
            return Balance != Balance.Balanced;
        }

        public bool IsLeaf { get { return RigthChild == null && LeftChild == null; } }
    }

    public class KeyValuePair<TKey, TValue>
    {
        public TKey Key { get; internal set; }
        public TValue Value { get; internal set; }

        public KeyValuePair()
        {

        }

        public KeyValuePair(TKey key, TValue value)
        {
            this.Key = key;
            this.Value = value;
        }

        public override string ToString()
        {
            return Key.ToString() + " " + Value.ToString();
        }
    }

    public enum Balance
    {
        Balanced,
        RightUnBalanced,
        LeftUnBalanced
    }

    public class AVLNodeValue<TValue, TFather>
    {
        public TValue Value { get; internal set; }
        internal TFather Father { get; set; }
    }
}
