using Boostability_Route_Parser.RouteNode;

namespace Boostability_Route_Parser.RouteTree
{
    internal class RouteTreeImpl : IRouteTree
    {
        Dictionary<string,IRouteNode> Nodes;

        public RouteTreeImpl()
        {
            Nodes = new Dictionary<string,IRouteNode>();
        }

        public bool addEntry(string from, string to)
        {
            /**
             * Add the entry into the tree. 
             * 
             * Try to get From node, if it doesnt exist, create it
             * 
             * Try to get To node, if it doesnt exist, create it (if there is a to parameter)
             * 
             * Insert From node into the To node's Previous
             * 
             * Insert To node into the From node's Next (if there is a to parameter)
             */

            // If no from parameter we cannot do anything.
            if (from == null || from.Equals(" ")){
                throw new ArgumentException("From parameter cannot be empty!");
            }

            IRouteNode? FromNode = null;

            if(!Nodes.TryGetValue(from, out FromNode))
            {
                FromNode = new RouteNodeImpl(from);
                if (!addNode(from, ref FromNode))
                {
                    // failed to create a From node, whole operation should cancel.
                    return false;
                }
            }

            // if there isnt a to parameter, cannot insert into From node and we are done.
            if (to == null || to.Equals(""))
            {
                return true;
            }

            IRouteNode? ToNode = null;

            if (!Nodes.TryGetValue(to, out ToNode))
            {
                ToNode = new RouteNodeImpl(to);
                if (!addNode(to, ref ToNode))
                {
                    // failed to create a To node, whole operation should cancel.
                    return false;
                }
            }

            // We are in the clear, we have both nodes and they are ready for linking.


            
            ToNode.addPrevious(ref FromNode);

            FromNode.addNext(ref ToNode);

            return true;

        }

        public bool addNode(string key, ref IRouteNode node)
        {
            return Nodes.TryAdd(key, node);
        }

        public IEnumerable<IRouteNode> getRootNodes()
        {
            // A root node is any node in the dictionary that doesnt have Previous values

            IEnumerable<IRouteNode> ListOfRoot = new List<IRouteNode>();

            foreach (KeyValuePair<string, IRouteNode> entry in Nodes)
            {
                if (entry.Value.getPrevious().Count() == 0)
                {
                    ListOfRoot.(entry.Value);
                }
            }

            return ListOfRoot;
        }

        public IEnumerable<IRouteNode> getLeafNodes()
        {
            // A leaf node is any node in the dictionary that doesnt have Next values

            IEnumerable<IRouteNode> ListOfLeaf = new List<IRouteNode>();

            foreach (KeyValuePair<string, IRouteNode> entry  in Nodes)
            {
                if (entry.Value.getNext().Count() == 0)
                {
                    ListOfLeaf.Append(entry.Value);
                }
            }

            return ListOfLeaf;
        }

        public IEnumerable<string> getPaths()
        {
            IEnumerable<string> routes = new List<string>();

            IEnumerable<IRouteNode> roots = getRootNodes();
            
            foreach (IRouteNode node in roots)
            {
                node.forwardTraverse("", ref routes);
            }

            return routes;
        }

        public void outputPaths()
        {
            IEnumerable<string> paths = getPaths();

            foreach (string path in paths)
            {
                Console.WriteLine(path);
            }
        }
    }
}
