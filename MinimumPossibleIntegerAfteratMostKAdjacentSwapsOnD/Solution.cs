using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Numerics;
using System.Text;

namespace MinimumPossibleIntegerAfteratMostKAdjacentSwapsOnD
{
    public class Solution
    {
        public string MinInteger(string num, int k)
        {
            var numDigits = num.Select(e => int.Parse(e.ToString())).ToArray();
            var indices = new LinkedList<int>[10];
            for (int i = 0; i < indices.Length; i++)
            {
                indices[i] = new LinkedList<int>();
            }

            for (int i = 0; i < numDigits.Length; i++)
            {
                indices[numDigits[i]].AddLast(i);
            }

            MyAVLCountTree<int, int> avl = new MyAVLCountTree<int, int>();
            avl.Insert(0, int.MaxValue);

            LinkedList<int> result = new LinkedList<int>();

            bool[] processed = new bool[numDigits.Length];

            for (int i = 0; i < numDigits.Length; i++)
            {
                if (processed[i])
                    continue;

                if (k != 0)
                {
                    bool isSelected = false;

                    for (int j = 0; j < numDigits[i]; j++)
                    {
                        if (indices[j].Count == 0)
                            continue;
                        else
                        {
                            while (indices[j].Count > 0 && indices[j].First.Value < i)
                                indices[j].RemoveFirst();
                            if (indices[j].Count == 0)
                                continue;
                        }

                        Get(avl, i, indices[j].First.Value, out int amount);
                        if (k >= amount)
                        {
                            isSelected = true;
                            processed[indices[j].First.Value] = true;
                            SplitAvl(avl, indices[j].First.Value);
                            indices[j].RemoveFirst();
                            k -= amount;
                            result.AddLast(j);
                            i--;
                            break;
                        }
                    }
                    if(!isSelected)
                    {
                        result.AddLast(numDigits[i]);
                    }
                }
                else
                {
                    result.AddLast(numDigits[i]);
                }                
            }

            return new string(result.Select(e => e.ToString()[0]).ToArray());

        }

        private void SplitAvl(MyAVLCountTree<int, int > avl, int index)
        {
            avl.Insert(index + 1, 0);
        }

        private bool Get(MyAVLCountTree<int, int> avl, int index1, int index2, out int amount)
        {
            avl.SearchLTE(index1, out var resultNode1);
            avl.SearchLTE(index2, out var resultNode2);

            if ( resultNode1 == resultNode2)
            {
                amount = index2 - index1;
                return true;
            }
            else
            {

                int amount1 =  avl.AmountNodesGT(resultNode1);
                int amount2 =  avl.AmountNodesGT(resultNode2);
                amount = index2 - index1;
                amount -= amount1 - amount2;
                return true;
            }
        }
    }

    /// <summary>
    /// AVL tree implementado por mi , Luis Benavides Dalmendray  
    /// Cuando hay llaves iguales y se quiere permitir se va a utilizar una lista de iguales por el mismo Key 
    /// La diferencia entre el MyAVLCountTree y el MyAVLTree es que el primero tiene una propiedad Count por cada AVLCountNodeKey
    /// y así puede saber en O(1) cuantos elementos tiene el árbol que representa cada AVLCountNodeKey . 
    /// </summary>
    public class MyAVLCountTree<TKey, TValue>
    {
        public ulong CountLessThan(TKey value)
        {
            return CountLessThan(root, value);
        }

        private ulong CountLessThan(AVLCountNodeKey<TKey, TValue> node, TKey value)
        {

            if (node == null)
                return 0;

            ulong result = 0;

            while (node != null)
            {
                var compResult = Comparer.Compare(value, node.Key);
                if (compResult > 0)
                {
                    var leftChild = node.LeftChild as AVLCountNodeKey<TKey, TValue>;
                    result += (leftChild != null ? leftChild.Count : 0) + (ulong)node.Values.Count;
                    node = node.RigthChild;
                }
                else
                {
                    node = node.LeftChild;
                }
            }

            return result;
        }

        public AVLCountNodeKey<TKey, TValue> root;

        public int Count { get; protected set; }

        public MyAVLCountTree()
        {
            Comparer = Comparer<TKey>.Default;
        }
        public MyAVLCountTree(IComparer<TKey> comparer)
        {
            this.Comparer = comparer;
        }
        /// <summary>
        /// Insertar si key no existe en el MyAVLTree
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public AVLCountNodeKey<TKey, TValue> Insert(TKey key, TValue value)
        {
            if (root == null)
            {
                root = new AVLCountNodeKey<TKey, TValue>(key, value);
                Count++;
                this.root.Count = 1;
                return root;
            }

            AVLCountNodeKey<TKey, TValue> lastNotNull;
            if (Search(key, out lastNotNull))
                throw new Exception("This key has been inserted");
            AVLCountNodeKey<TKey, TValue> result = null;
            var resultCompare = Comparer.Compare(lastNotNull.Key, key);
            if (resultCompare < 0)
            {
                lastNotNull.RigthChild = new AVLCountNodeKey<TKey, TValue>(key, value) { Father = lastNotNull, Count = 1 };
                result = lastNotNull.RigthChild;
            }
            else
            {
                lastNotNull.LeftChild = new AVLCountNodeKey<TKey, TValue>(key, value) { Father = lastNotNull, Count = 1 };
                result = lastNotNull.LeftChild;
            }
            UpdateHeightFrom(lastNotNull);
            UpdateBalanceAndCount(lastNotNull);
            Count++;
            return result;
        }
        /// <summary>
        /// Insertar y permite tener llaves repetidas . Almacena una lista
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public AVLCountNodeKey<TKey, TValue> InsertRepeat(TKey key, TValue value)
        {
            if (root == null)
            {
                root = new AVLCountNodeKey<TKey, TValue>(key, value);
                Count++;
                root.Count = 1;
                return root;
            }

            AVLCountNodeKey<TKey, TValue> lastNotNull;
            if (Search(key, out lastNotNull))
            {
                lastNotNull.Values.AddLast(new AVLCountNodeValue<TValue, AVLCountNodeKey<TKey, TValue>>
                {
                    Father = lastNotNull
                ,
                    Value = value
                });
                Count++;
                UpdateCount(lastNotNull);
                return lastNotNull;
            }
            else
            {
                AVLCountNodeKey<TKey, TValue> result = null;
                var resultCompare = Comparer.Compare(lastNotNull.Key, key);
                if (resultCompare < 0)
                {
                    lastNotNull.RigthChild = new AVLCountNodeKey<TKey, TValue>(key, value) { Father = lastNotNull, Count = 1 };
                    result = lastNotNull.RigthChild;
                }
                else
                {
                    lastNotNull.LeftChild = new AVLCountNodeKey<TKey, TValue>(key, value) { Father = lastNotNull, Count = 1 };
                    result = lastNotNull.LeftChild;
                }
                UpdateHeightFrom(lastNotNull);
                UpdateBalanceAndCount(lastNotNull);
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


        void Swap(AVLCountNodeKey<TKey, TValue> node1, AVLCountNodeKey<TKey, TValue> node2)
        {
            if (node1 == root)
                root = node2;
            if (node2 == root)
                root = node1;

            var node1Height = node1.Height;
            node1.Height = node2.Height;
            node2.Height = node1Height;

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

        private void SwapWithOneFatherOfTheOther(AVLCountNodeKey<TKey, TValue> node1, AVLCountNodeKey<TKey, TValue> node2)
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

        private void SwapLeftChildEspecial(AVLCountNodeKey<TKey, TValue> node1, AVLCountNodeKey<TKey, TValue> node2)
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

        private void SwapRightChildEspecial(AVLCountNodeKey<TKey, TValue> node1, AVLCountNodeKey<TKey, TValue> node2)
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
        private void SwapFathersEspecial(AVLCountNodeKey<TKey, TValue> node1, AVLCountNodeKey<TKey, TValue> node2)
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
            AVLCountNodeKey<TKey, TValue> lastNotNull;
            if (Search(key, out lastNotNull))
            {
                if (justOneElement && lastNotNull.Values.Count > 1)
                {
                    lastNotNull.Values.RemoveFirst();
                    UpdateCount(lastNotNull);
                    Count--;
                    return true;
                }
                var candidate = Minimum(lastNotNull.RigthChild);
                if (candidate != null)
                {
                    if (candidate.RigthChild != null)
                    {
                        var aux = candidate.RigthChild;
                        Swap(candidate, candidate.RigthChild);
                        UpdateCount(aux);
                    }
                }
                else
                {
                    candidate = Maximum(lastNotNull.LeftChild);
                    if (candidate != null && candidate.LeftChild != null)
                    {
                        var aux = candidate.LeftChild;
                        Swap(candidate, candidate.LeftChild);
                        UpdateCount(aux);
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
                    UpdateBalanceAndCount(lastNotFullFather);
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
                    UpdateBalanceAndCount(lastnotNUllFather);
                }

                Count--;
                return true;
            }
            return false;
        }

        protected Action<AVLCountNodeKey<TKey, TValue>> UpdateSomeThingLikeHeightFrom;

        private void UpdateHeightFrom(AVLCountNodeKey<TKey, TValue> node)
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

        private void UpdateCount(AVLCountNodeKey<TKey, TValue> node)
        {
            if (node == null)
                return;

            var currentNode = node;
            while (currentNode != null)
            {
                var currentNodeLeft = currentNode.LeftChild;
                var currentNodeRight = currentNode.RigthChild;

                if (currentNode.Count != (currentNodeLeft != null ? currentNodeLeft.Count : 0) + (currentNodeRight != null ? currentNodeRight.Count : 0) + (uint)currentNode.Values.Count)
                {
                    currentNode.Count = (currentNodeLeft != null ? currentNodeLeft.Count : 0) + (currentNodeRight != null ? currentNodeRight.Count : 0) + (uint)currentNode.Values.Count;
                }
                else
                    break;
                currentNode = currentNode.Father;
            }
        }

        private void UpdateBalanceAndCount(AVLCountNodeKey<TKey, TValue> node)
        {
            if (node == null)
                return;
            var nodeCount = node;
            UpdateCount(nodeCount);

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

        public AVLCountNodeKey<TKey, TValue> Minimum(AVLCountNodeKey<TKey, TValue> avlNodeRoot)
        {
            if (avlNodeRoot == null)
                return null;
            return avlNodeRoot.Minimum();
        }
        public AVLCountNodeKey<TKey, TValue> Maximum(AVLCountNodeKey<TKey, TValue> avlNodeRoot)
        {
            if (avlNodeRoot == null)
                return null;
            return avlNodeRoot.Maximum();
        }

        public bool Contains(TKey key)
        {
            AVLCountNodeKey<TKey, TValue> lastNotNull;
            return Search(key, out lastNotNull);
        }
        public bool Search(TKey key, out AVLCountNodeKey<TKey, TValue> lastNotNull)
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

        /// <summary>
        /// Search Greater Than or Equals To 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="resultNode"></param>
        /// <returns></returns>
        public bool SearchGTE(TKey key, out AVLCountNodeKey<TKey, TValue> resultNode)
        {
            resultNode = null;
            AVLCountNodeKey<TKey, TValue> lastNotNull = root;
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

        /// <summary>
        /// Search Less Than or Equals To 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="resultNode"></param>
        /// <returns></returns>
        public bool SearchLTE(TKey key, out AVLCountNodeKey<TKey, TValue> resultNode)
        {
            resultNode = null;
            AVLCountNodeKey<TKey, TValue> lastNotNull = root;
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
                    resultNode = lastNotNull;
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
            LinkedList<AVLCountNodeKey<TKey, TValue>> queue = new LinkedList<AVLCountNodeKey<TKey, TValue>>();
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

        private void BFS(AVLCountNodeKey<TKey, TValue> currentNode, LinkedList<KeyValuePair<TKey, TValue>> result)
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

        public int AmountNodesGT(AVLCountNodeKey<int, int> resultNode)
        {
            ulong result = 0;
            bool isGreater = true;

            while(true)
            {
                if (isGreater && resultNode.RigthChild != null)
                    result += resultNode.RigthChild.Count;

                if (resultNode.Father == null)
                    break;
                if (resultNode.Father.LeftChild == resultNode)
                {
                    result++;
                    isGreater = true;
                }
                else
                {
                    isGreater = false;
                }

                resultNode = resultNode.Father;
            }

            return (int)result;
        }
    }

    public class AVLCountNodeKey<TKey, TValue>
    {
        public ulong Count { get; internal set; }
        public AVLCountNodeKey()
        {
            Values = new LinkedList<AVLCountNodeValue<TValue, AVLCountNodeKey<TKey, TValue>>>();
        }
        public AVLCountNodeKey(TKey key, TValue value)
            : this()
        {
            this.Key = key;
            Values.AddLast(new AVLCountNodeValue<TValue, AVLCountNodeKey<TKey, TValue>> { Value = value, Father = this });
        }
        public AVLCountNodeKey<TKey, TValue> Father { get; internal set; }
        public AVLCountNodeKey<TKey, TValue> LeftChild { get; internal set; }
        public AVLCountNodeKey<TKey, TValue> RigthChild { get; internal set; }
        public TKey Key { get; set; }
        public LinkedList<AVLCountNodeValue<TValue, AVLCountNodeKey<TKey, TValue>>> Values { get; internal set; }

        public int Height { get; internal set; }

        internal void UpdateFather(AVLCountNodeKey<TKey, TValue> node)
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
            var rightChildOrigin = RigthChild;
            var count = Count;
            var rCount = RigthChild.Count;
            this.Count -= rCount;
            rightChildOrigin.Count = count;

            RigthChild = rightChildOrigin.LeftChild;
            if (RigthChild != null)
            {
                this.Count += RigthChild.Count;
                RigthChild.Father = this;
            }

            Father = rightChildOrigin;
            rightChildOrigin.LeftChild = this;
            rightChildOrigin.Father = father;
            if (father != null)
            {
                if (father.LeftChild == this)
                    father.LeftChild = rightChildOrigin;
                else
                    father.RigthChild = rightChildOrigin;
            }
            Height = Math.Max(LeftChild == null ? -1 : LeftChild.Height, RigthChild == null ? -1 : RigthChild.Height) + 1;
            Father.Height = Math.Max(Father.LeftChild == null ? -1 : Father.LeftChild.Height, Father.RigthChild == null ? -1 : Father.RigthChild.Height) + 1;
        }

        internal void RotateToRight()
        {
            var father = Father;
            var leftChildOrigin = LeftChild;
            var count = Count;
            var lCount = leftChildOrigin.Count;
            this.Count -= lCount;
            leftChildOrigin.Count = count;

            LeftChild = leftChildOrigin.RigthChild;
            if (LeftChild != null)
            {
                this.Count += LeftChild.Count;
                LeftChild.Father = this;
            }

            Father = leftChildOrigin;
            leftChildOrigin.RigthChild = this;
            leftChildOrigin.Father = father;
            if (father != null)
            {
                if (father.LeftChild == this)
                    father.LeftChild = leftChildOrigin;
                else
                    father.RigthChild = leftChildOrigin;
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

        public AVLCountNodeKey<TKey, TValue> Maximum()
        {
            AVLCountNodeKey<TKey, TValue> lastNotNull = this;
            while (lastNotNull.RigthChild != null)
            {
                lastNotNull = lastNotNull.RigthChild;
            }
            return lastNotNull;
        }

        public AVLCountNodeKey<TKey, TValue> Minimum()
        {
            AVLCountNodeKey<TKey, TValue> lastNotNull = this;
            while (lastNotNull.LeftChild != null)
            {
                lastNotNull = lastNotNull.LeftChild;
            }
            return lastNotNull;
        }
    }

    public class AVLCountNodeValue<TValue, TFather>
    {
        public TValue Value { get; internal set; }
        internal TFather Father { get; set; }
    }

    public enum Balance
    {
        Balanced,
        RightUnBalanced,
        LeftUnBalanced
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

}
