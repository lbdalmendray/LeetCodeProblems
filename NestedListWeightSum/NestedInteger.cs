using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NestedListWeightSum
{

    // This is the interface that allows for creating nested lists.
    // You should not implement it, or speculate about its implementation
    public class NestedInteger
    {
        int? value;
        List<NestedInteger> values;
        // Constructor initializes an empty nested list.
        public NestedInteger() { }

        // Constructor initializes a single integer.
        public NestedInteger(int value)
        {
            this.value = value;
        }

        // @return true if this NestedInteger holds a single integer, rather than a nested list.
        public bool IsInteger()
        {
            return value.HasValue;
        }

        // @return the single integer that this NestedInteger holds, if it holds a single integer
        // Return null if this NestedInteger holds a nested list
        public int GetInteger()
        {
            return value.HasValue ? value.Value : 0;
        }

        // Set this NestedInteger to hold a single integer.
        public void SetInteger(int value)
        {
            this.value = value;
        }

        // Set this NestedInteger to hold a nested list and adds a nested integer to it.
        public void Add(NestedInteger ni) 
        {
            if ( IsInteger() || values == null)
            {
                value = null;
                values = new List<NestedInteger>();
            }

            values.Add(ni);
        }

        // @return the nested list that this NestedInteger holds, if it holds a nested list
        // Return null if this NestedInteger holds a single integer
        public IList<NestedInteger> GetList() 
        {
            return values;
        }
    }

}
