using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boostability_Route_Parser.RouteNode;
using Boostability_Route_Parser.RouteTree;

namespace Boostability_Route_Parser.UnitTests
{
    public class IRouteTreeImplTests
    {
        [Test]
        public void Setup()
        {

        }

        [Test]
        public void addEntry_ValidData_ExpectedBehavior()
        {
            IRouteTree tester = new RouteTreeImpl();

            

            string[] testData =
            {
                "A",
                "B"
            };

            Assert.That(tester.addEntry(testData[0], testData[1]), Is.True);


        }

        [Test]
        public void getLeafNodes_Empty_ExpectedBehavior()
        {
            IRouteTree tester = new RouteTreeImpl();

            IEnumerable<IRouteNode> res = tester.getLeafNodes();

            Assert.That(res.Count(), Is.EqualTo(0));

        }

        [Test]
        public void getLeafNodes_ContainsData_ExpectedBehavior()
        {
            IRouteTree tester = new RouteTreeImpl();

            string[] testData =
            {
                "A",
                "B",
                "C",
                "D"
            };

            tester.addEntry(testData[0], testData[1]);
            tester.addEntry(testData[2], testData[3]);

            IEnumerable<IRouteNode> res = tester.getLeafNodes();

            Assert.That(res.Count(), Is.EqualTo(2));

            Assert.That(res.ElementAt(0).getValue(), Is.EqualTo("B"));
            Assert.That(res.ElementAt(1).getValue(), Is.EqualTo("D"));

        }

        [Test]
        public void getRootNodes_Empty_ExpectedBehavior()
        {
            IRouteTree tester = new RouteTreeImpl();

            IEnumerable<IRouteNode> res = tester.getRootNodes();

            Assert.That(res.Count(), Is.EqualTo(0));

        }

        [Test]
        public void getRootNodes_ContainsData_ExpectedBehavior()
        {
            IRouteTree tester = new RouteTreeImpl();

            string[] testData =
            {
                "A",
                "B",
                "C",
                "D"
            };

            tester.addEntry(testData[0], testData[1]);
            tester.addEntry(testData[2], testData[3]);

            IEnumerable<IRouteNode> res = tester.getRootNodes();

            Assert.That(res.Count(), Is.EqualTo(2));

            Assert.That(res.ElementAt(0).getValue(), Is.EqualTo("A"));
            Assert.That(res.ElementAt(1).getValue(), Is.EqualTo("C"));

        }

        [Test]
        public void addNode_GoodData_ExpectedBehavior()
        {
            IRouteTree tester = new RouteTreeImpl();
            IRouteNode node = new RouteNodeImpl("test");


            Assert.That(tester.addNode("test", ref node), Is.True);
        }


        [Test]
        public void addNode_BadData_ExpectedBehavior()
        {
            IRouteTree tester = new RouteTreeImpl();
            IRouteNode node = new RouteNodeImpl("boo");


            Assert.That(tester.addNode("test", ref node), Is.False);
        }

        [Test]
        public void getPaths_GoodData_ExpectedBehavior()
        {


            IRouteTree tester = new RouteTreeImpl();

            string[] testData =
            {
                "A",
                "B",
                "C",
                "D"
            };

            tester.addEntry(testData[0], testData[1]);
            tester.addEntry(testData[2], testData[3]);

            IEnumerable<string> expectedPath = new[] 
            {
                "AB",
                "CD"
            };

            IEnumerable<string> res = tester.getPaths();

            Assert.That(res, Is.EquivalentTo(expectedPath));


        }
    }
}
