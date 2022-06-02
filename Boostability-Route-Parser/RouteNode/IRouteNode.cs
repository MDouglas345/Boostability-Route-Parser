using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boostability_Route_Parser.RouteNode
{
    interface IRouteNode
    {
        public String getValue();

        public IEnumerable<IRouteNode> getPrevious();

        public IEnumerable<IRouteNode> getNext();
        public bool addNext(ref IRouteNode node);

        public bool addPrevious(ref IRouteNode node);

        public bool alreadyExistsInNext(ref IRouteNode node);

        public bool alreadyExistsInPrevious(ref IRouteNode node);

        public void forwardTraverse(string current, ref List<string> list);

        public bool isLeafNode();

        public bool isRootNode();






    }
}
