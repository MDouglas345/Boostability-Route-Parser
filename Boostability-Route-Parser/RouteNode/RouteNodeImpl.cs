using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boostability_Route_Parser.RouteNode
{
    public class RouteNodeImpl : IRouteNode
    {
        List<IRouteNode> Previous;
        List<IRouteNode> Next;

        string Value;

        public RouteNodeImpl(string value)
        {
            Previous = new List<IRouteNode>();

            Next = new List<IRouteNode>();

            Value = value;

        }

        public bool addNext(ref IRouteNode node)
        {
            if (alreadyExistsInNext(ref node)){
                return false;
            }

            if (alreadyExistsInPrevious(ref node))
            {
                throw new Exception("Oh no! A cycle has been detected!");
            }

            Next.Add(node);
            IRouteNode me = this;
            node.addPrevious(ref me);

            return true;
        }

        public bool addPrevious(ref IRouteNode node)
        {

            if (alreadyExistsInPrevious(ref node))
            {
                return false;
            }
            if (alreadyExistsInNext(ref node))
            {
                throw new Exception("Oh no! A cycle has been detected!");
            }

            Previous.Add(node);
            IRouteNode me = this;
            node.addNext(ref me);
            return true;
        }

        public bool alreadyExistsInNext(ref IRouteNode node)
        {
            foreach(IRouteNode N in Next)
            {
                if (N.getValue().Equals(node.getValue()))
                {
                    return true;
                }
            }
            return false;
        }

        public bool alreadyExistsInPrevious(ref IRouteNode node)
        {

            foreach (IRouteNode N in Previous)
            {
                if (N.getValue().Equals(node.getValue()))
                {
                    return true;
                }
            }
            return false;
        }

        public void forwardTraverse(string current, ref List<string> list)
        {
            // Add the previous string value with the current string value
            string newcurrent  = current + getValue();

            if (isLeafNode())
            {
                list.Add(newcurrent);
                return;
            }

            foreach (IRouteNode N in Next)
            {
                N.forwardTraverse(newcurrent, ref list);
            }
        }

        public IEnumerable<IRouteNode>? getNext()
        {
            if (Next == null)
            {
                return null;
            }

            return Next;
            
        }

        public IEnumerable<IRouteNode>? getPrevious()
        {
            if (Previous == null)
            {
                return null;
            }
            return Previous;
        }

        public string? getValue()
        {
            if (Value == null)
            {
                return null;
            }
            return Value;
            
        }

        public bool isLeafNode()
        {
            if (Next.Count() == 0)
            {
                return true;
            }

            return false;
        }

        public bool isRootNode()
        {
            if (Previous.Count() == 0)
            {
                return true;
            }

            return false;
        }
    }
}
