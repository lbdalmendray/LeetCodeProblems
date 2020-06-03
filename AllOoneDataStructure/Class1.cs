using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AllOoneDataStructure
{
    public class AllOne
    {
        Dictionary<string,SuperInfo> container = new Dictionary<string,SuperInfo>();
        LinkedList<Info> infos = new LinkedList<Info>();
        /** Initialize your data structure here. */
        public AllOne()
        {

        }

        /** Inserts a new key <Key> with value 1. Or increments an existing key by 1. */
        public void Inc(string key)
        {
            if( container.TryGetValue(key, out var superInfo))
            {
                var info = superInfo.Info ;
                var infoNode = info.Node;
                var infoNodeNext = infoNode.Next;
                if( infoNodeNext == null || infoNodeNext.Value.Value != infoNode.Value.Value + 1 )
                {
                    var newInfo = new Info{ Value = infoNode.Value.Value + 1 } ;
                    newInfo.Node = infoNodeNext = infos.AddAfter(infoNode, newInfo );
                }

                var nextStringList = infoNodeNext.Value.StringList;
                var stringListNode = nextStringList.AddLast(key);

                var cStringList = superInfo.StringListNode.List;
                cStringList.Remove(superInfo.StringListNode);
                if( cStringList.Count == 0)
                {
                    infos.Remove(superInfo.Info.Node);
                }    

                superInfo.StringListNode = stringListNode ;
                superInfo.Info = infoNodeNext.Value;
            }
            else
            {
                Info currentInfo = infos.FirstOrDefault();
                if ( infos.First == null || infos.First.Value.Value > 1 )
                {
                    currentInfo = new Info{ Value = 1  } ;
                    var node = infos.AddFirst(currentInfo);
                    currentInfo.Node = node;
                }
    
                var stringListNode = currentInfo.StringList.AddLast(key);
                var superInfo1 = new SuperInfo { Info = currentInfo , StringListNode = stringListNode } ;
                container.Add(key,superInfo1);    
            }
        }

        /** Decrements an existing key by 1. If Key's value is 1, remove it from the data structure. */
        public void Dec(string key)
        {
            if( container.TryGetValue(key, out var superInfo))
            {
                var info = superInfo.Info ;
                var infoNode = info.Node;
                if( infoNode.Value.Value == 1 )
                {
                    var cStringList = superInfo.StringListNode.List;
                    cStringList.Remove(superInfo.StringListNode);
                    if( cStringList.Count == 0)
                    {
                        infos.Remove(superInfo.Info.Node);
                    } 
                    container.Remove(key);
                }
                else
                {
                    var infoNodePrev = infoNode.Previous;
                    if( infoNodePrev == null || infoNodePrev.Value.Value != infoNode.Value.Value - 1 )
                    {
                        var newInfo = new Info{ Value = infoNode.Value.Value - 1 } ;
                        newInfo.Node = infoNodePrev = infos.AddBefore(infoNode, newInfo );
                    }

                    var nextStringList = infoNodePrev.Value.StringList;
                    var stringListNode = nextStringList.AddLast(key);

                    var cStringList = superInfo.StringListNode.List;
                    cStringList.Remove(superInfo.StringListNode);
                    if( cStringList.Count == 0)
                    {
                        infos.Remove(superInfo.Info.Node);
                    }    

                    superInfo.StringListNode = stringListNode ;
                    superInfo.Info = infoNodePrev.Value;
                }
            }
            /* else
            {
                // NOTHING   
            }
            */
        }

        /** Returns one of the keys with maximal value. */
        public string GetMaxKey()
        {
            if(infos.Count == 0)
                return "";
            return infos.Last.Value.StringList.First.Value;
        }

        /** Returns one of the keys with Minimal value. */
        public string GetMinKey()
        {
            if(infos.Count == 0)
                    return "";
            return infos.First.Value.StringList.First.Value;
        }

        private class Info 
        {
            public int Value {get;set;}
            public LinkedList<string> StringList {get;set;} = new LinkedList<string>();
            public LinkedListNode<Info> Node {get;set;}
        }

        private class SuperInfo 
        {
            public Info Info {get;set;}
            public LinkedListNode<string> StringListNode {get;set;}
        }
    }
}
