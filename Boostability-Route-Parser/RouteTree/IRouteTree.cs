using Boostability_Route_Parser.RouteNode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boostability_Route_Parser.RouteTree
{
    public interface IRouteTree
    {
        public bool addEntry(string from, string to);

        public IEnumerable<IRouteNode> getLeafNodes();

        public IEnumerable<IRouteNode> getRootNodes();

        public void outputPaths();

        public bool addNode(string key, ref IRouteNode node);


        public IEnumerable<string> getPaths();
    }
}
