using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boostability_Route_Parser.RouteAnalyzer
{
    interface IRouteAnalyzer
    {
        IEnumerable<string> Process(IEnumerable<string> routes);

    }
}
