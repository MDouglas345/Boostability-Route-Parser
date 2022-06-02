

using Boostability_Route_Parser.RouteAnalyzer;
/**
* Route Parser
* Written by Michael Douglas
* 
* 
* Task : Write an application that takes an array of strings that are routes and
* compile them into a new array of strings that are a list of complete paths
* 
* Approach : Essentially a tree where each node has a list of pointers to other nodes that will form
* a complete path when traversed.
* 
* Node :
* List of pointers to previous
* String
* List of pointers to next
* 
* 
* Traversing is a depth first search.
* 
* 
* Use IRouteTree.outputPaths() to print paths.
*/
try
{
    IRouteAnalyzer router = new RouteAnalyzerImpl();
    string[] routes =
    {
        "/home",
        "/our-ceo.html -> /about-us.html",
        "/about-us.html -> /about",
        "/product-1.html -> /seo"

    };

    router.Process(routes);
}
catch(Exception e)
{
    Console.WriteLine(e.ToString());
}
