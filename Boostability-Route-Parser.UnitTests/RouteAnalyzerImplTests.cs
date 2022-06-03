using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Boostability_Route_Parser.RouteAnalyzer;

namespace Boostability_Route_Parser.UnitTests
{
    public class RouteAnalyzerImplTests
    {
        [Test]
        public void Setup()
        {

        }

        [Test]
        public void Process_Good_ExpectedBehavior()
        {
            IRouteAnalyzer tester = new RouteAnalyzerImpl();


                        
            string[] testData =
            {
                 "source",
                 "source -> dest",
                 "dest -> dest2",
                 "source -> dest2"
            };


            IEnumerable<string> actual = new[]
            {
                "sourcedestdest2",
                "sourcedest2"
            };

            IEnumerable<string> res = tester.Process(testData);

            Assert.That(res, !Is.EqualTo(null));

            Assert.That(res, Is.EqualTo(actual));
        }

        [Test]
        public void Process_BadCycle_ExpectedBehavior()
        {
            IRouteAnalyzer tester = new RouteAnalyzerImpl();



            string[] testData =
            {
                 "source",
                 "source -> dest",
                 "dest -> dest2",
                 "source -> dest2",
                 "dest -> source"
            };

            try
            {
                tester.Process(testData);
                Assert.Fail();
            }
            catch(Exception e)
            {
                Assert.Pass();
            }
        }

        [Test]
        public void Process_DuplicatedRoutes_ExpectedBehavior()
        {
            IRouteAnalyzer tester = new RouteAnalyzerImpl();



            string[] testData =
            {
                 "source",
                 "source -> dest",
                 "dest -> dest2",
                 "source -> dest2",
                 "source -> dest"
            };

            IEnumerable<string> actual = new[]
            {
                "sourcedestdest2",
                "sourcedest2"
            };

            IEnumerable<string> res = tester.Process(testData);

            Assert.That(res.Count(), Is.EqualTo(2));

            Assert.That(res, Is.EqualTo(actual));

        }
    }
}
