using Boostability_Route_Parser.RouteTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boostability_Route_Parser.RouteAnalyzer
{
    public class RouteAnalyzerImpl : IRouteAnalyzer
    {
        IRouteTree tree;

        public RouteAnalyzerImpl()
        {
            tree = new RouteTreeImpl();
        }

        IEnumerable<string> IRouteAnalyzer.Process(IEnumerable<string> routes)
        {

            /**
             * Need to parse the array of stringsin (from,to) pairs.
             * Demlimiter is ->
             */

            foreach (string line in routes)
            {
                List<string> words = line.Split("->").ToList(); // need to test that this works!

                if (words.Count() > 2)
                {
                    // Not too sure about this behavior, from example given, each route line has only 2 parts

                    throw new Exception("Invalid route : " + line);
                }

                // A bit hacky...
                if (words.Count() == 1)
                {
                    words.Add("");
                }
                

                tree.addEntry(words[0].Trim(), words[1].Trim());
            }

            tree.outputPaths(); // should think about caching the output so it doesnt need to be recalculated.
            return tree.getPaths();
            
        }
    }
}
