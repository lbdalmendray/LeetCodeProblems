using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    public class EnumerableComparer<TElement>
    {
        
        public IComparer<TElement> ElementComparer { get; protected set; }
        
        public EnumerableComparer(IComparer<TElement> ElementComparer = null)
        {
            if (ElementComparer == null)
                this.ElementComparer = Comparer<TElement>.Default;
            else
                this.ElementComparer = ElementComparer;
        }

        public bool Equals( IEnumerable<TElement> elements1 , IEnumerable<TElement> elements2)
        {
            if (elements1.Count() != elements2.Count())
                return false;

            var array1 = elements1.ToArray();
            var array2 = elements2.ToArray();

            for (int i = 0; i < array1.Length; i++)
            {
                if (this.ElementComparer.Compare(array1[i], array2[i]) != 0)
                    return false;
            }

            return true;
        }

        public bool Equivalent(IEnumerable<TElement> set1, IEnumerable<TElement> set2)
        {
            if (set1.Count() != set2.Count())
                return false;

            foreach (var item1 in set1)
            {
                bool exits = false;
                foreach (var item2 in set2)
                {
                    if ( this.ElementComparer.Compare( item1 , item2) == 0 )
                    {
                        exits = true;
                        break;
                    }
                }
                if (!exits)
                    return false;
            }

            return true;
        }
    }
}
