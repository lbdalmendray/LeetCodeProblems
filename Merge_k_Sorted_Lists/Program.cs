using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merge_k_Sorted_Lists
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("MergeLists Beggining");
            //ListNode l1 = new int[] { 1, 2, 99 }.IntArrayToListNode();

            //ListNode l2 = new int[] { 6, 8, 9, 100 }.IntArrayToListNode();

            //ListNode l3 = new int[] { -1, 2, 5 }.IntArrayToListNode();

            ListNode l1 = new int[] { 1 ,  }.IntArrayToListNode();

            ListNode l2 = new int[] { 6, 8  }.IntArrayToListNode();

            ListNode l3 = new int[] { -1 , 3 ,  44   }.IntArrayToListNode();


            Solution ss = new Solution();
            var lresult = ss.MergeKLists(new ListNode[] { l1, l2, l3 });
            var listresult = lresult.ListNodeToList();
            listresult.Execute(v => Console.Write(v + " "), vs => Console.WriteLine());
            Console.WriteLine("MergeLists Finished");

            Console.ReadLine();

            Console.WriteLine("MergeSort Beggining");
        }
    }

    public static class AuxProgram
    {
        public static void Execute<T>(this IEnumerable<T> values, Action<T> action, Action<IEnumerable<T>> lastAction)
        {
            if (values != null)
                foreach (var item in values)
                {
                    action(item);
                }

            lastAction(values);
        }

        public static Tuple<int[], object>[] ObtainRadixSortValues(this int[] numbers)
        {
            var maxDigit = (int)numbers.Max(n => Math.Floor(Math.Log10(n)) + 1);
            maxDigit = numbers.Max(n => n.ToString().Length);
            string zeros = "0000";
            var aaa = numbers.Select(delegate (int n) { var nstring = n.ToString(); var nStringMaxDigit = zeros.Substring(0, maxDigit - nstring.Length) + nstring; return nStringMaxDigit.Select(c => int.Parse(c.ToString())).ToArray(); });
            return aaa.Select(v => new Tuple<int[], object>(v, null)).ToArray();
        }

        public static List<int> ListNodeToList(this ListNode listnode)
        {
            if (listnode == null)
                return null;
            var first = listnode;
            List<int> result = new List<int>();
            while (listnode != null)
            {
                result.Add(listnode.val);
                listnode = listnode.next;
                if (first == listnode)
                    break;
            }

            return result;
        }
        public static ListNode IntArrayToListNode(this int[] array)
        {
            if (array == null || array.Length == 0)
                return null;
            ListNode result = new ListNode(array[0]);
            var resultt = result;
            for (int i = 1; i < array.Length; i++)
            {
                resultt.next = new ListNode(array[i]);
                resultt = result.next;
            }
            return result;
        }
    }
}
