using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordFilter
{
    public class WordFilter
    {
        Tree tree = new Tree();

        public WordFilter(string[] words)
        {
            int i = 0;
            foreach (string word in words)
            {
                tree.Add(word, i);
                i++;
            }
        }

        public int F(string prefix, string suffix)
        {
            var prefixWordNodes = tree.GetPrefixWordNodes(prefix);
            return tree.GetMaxSufixNode(prefixWordNodes, suffix);
        }
    }

    public class Node
    {
        public int index = -1;
        public char letter;
        public int level;
        public Node Father;
#if DICT
        public Dictionary<char, Node> childrenD = new Dictionary<char, Node>(26);
#else
        public Node [] childrenA = new Node[26];
#endif

        public Node GetChildrenNode(char letter)
        {
#if DICT

            return childrenD[letter];
#else

            return childrenA[letter - 'a'];
#endif

        }

        public bool ExistChildrenNode(char letter)
        {
#if DICT

            return childrenD.ContainsKey(letter);
#else

            return childrenA[letter - 'a'] != null;
#endif

        }

        public void CreateChildrenNode(char letter)
        {
#if DICT
            childrenD.Add(letter, new Node { letter = letter, Father = this, level = level + 1 });
#else
            childrenA[letter - 'a'] = new Node { letter = letter, Father = this, level = level + 1 };
#endif
        }

        public void Add(string word, int index)
        {
            if (word.Length - 1 == level)
            {
                this.index = index;
                return;
            }
            var currentLetter = word[level + 1];
            if (!ExistChildrenNode(currentLetter))
            {
                CreateChildrenNode(currentLetter);
            }

            GetChildrenNode(currentLetter).Add(word, index);
        }

        public Node GetPrefixNode(string prefix)
        {
            if (level == prefix.Length - 1)
                return this;
            var currentLetter = prefix[level + 1];
            if (!ExistChildrenNode(currentLetter))
            {
                return null;
            }
            return GetChildrenNode(currentLetter).GetPrefixNode(prefix);
        }

        internal void GetWordNodes(LinkedList<Node> result)
        {
            if (this.index != -1)
            {
                result.AddLast(this);
            }
            foreach (var node in GetChildren())
            {
                node.GetWordNodes(result);
            }
        }

        private IEnumerable<Node> GetChildren()
        {
#if DICT

            return childrenD.Values;
#else
            return childrenA.Where(v => v != null);
#endif
        }

        public bool HasSuffix(string suffix)
        {
            if (suffix == "")
                return true;
            return HasSuffixByChar(suffix, 0);
        }

        public bool HasSuffixByChar(string suffix, int index)
        {
            if (suffix.Length - 1 - index > 0)
            {
                if (suffix[suffix.Length - 1 - index] == letter && Father != null && Father.HasSuffixByChar(suffix, index + 1))
                    return true;
            }
            else
                if (suffix[suffix.Length - 1 - index] == letter)
                return true;

            return false;
        }
    }

    public class Tree
    {
        Node root = new Node { level = -1 };
        public void Add(string word, int index)
        {
            root.Add(word, index);
        }

        public LinkedList<Node> GetPrefixWordNodes(string prefix)
        {
            LinkedList<Node> result = new LinkedList<Node>();
            var prefixNode = prefix != "" ? root.GetPrefixNode(prefix) : root;
            if (prefixNode != null)
                prefixNode.GetWordNodes(result);

            return result;
        }

        public int GetMaxSufixNode(LinkedList<Node> suffixNodes, string suffix)
        {
            var prefSuffixSet = suffixNodes.Where(n => n.HasSuffix(suffix));

            //int resultLevel = -1;
            int index = -1;

            foreach (var prefSuffixelement in prefSuffixSet)
            {
                if (prefSuffixelement.index > index)
                {
                    //resultLevel = prefSuffixelement.level;
                    index = prefSuffixelement.index;
                }
            }

            return index;
        }
    }





    /**
     * Your WordFilter object will be instantiated and called as such:
     * WordFilter obj = new WordFilter(words);
     * int param_1 = obj.F(prefix,suffix);
     */
}
