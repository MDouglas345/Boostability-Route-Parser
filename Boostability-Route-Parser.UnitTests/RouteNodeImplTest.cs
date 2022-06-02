using Boostability_Route_Parser.RouteNode;

namespace Boostability_Route_Parser.UnitTests
{
    public class RouteNodeImplTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void getValue_Valid_ExpectedBehavior()
        {
            var tester = new RouteNodeImpl("Test");
            Assert.That(tester.getValue(), Is.EqualTo("Test"));
        }

        [Test]
        public void getPrevious_Valid_ExpectedBehavior()
        {
            var tester = new RouteNodeImpl("Test");

            var previous = tester.getPrevious();

            Assert.That(previous, !Is.EqualTo(null));

            Assert.That(previous.Count(), Is.EqualTo(0));


        }

        [Test]
        public void getPrevious_ContainsData_ExpectedBehavior()
        {
            var tester = new RouteNodeImpl("Test");

            IRouteNode tester2 = new RouteNodeImpl("PrevTest");


            tester.addPrevious(ref tester2);



            var previous = tester.getPrevious();

            Assert.That(previous, !Is.EqualTo(null));


            Assert.That(previous.Count(), Is.EqualTo(1));

            Assert.That(previous.ElementAt(0), Is.EqualTo(tester2));


        }

        [Test]
        public void getNext_Valid_ExpectedBehavior()
        {
            var tester = new RouteNodeImpl("Test");

            var next = tester.getNext();

            Assert.That(next, !Is.EqualTo(null));

            Assert.That(next.Count(), Is.EqualTo(0));


        }

        [Test]
        public void getNext_ContainsData_ExpectedBehavior()
        {
            var tester = new RouteNodeImpl("Test");

            IRouteNode tester2 = new RouteNodeImpl("PrevTest");


            tester.addNext(ref tester2);



            var next = tester.getNext();

            Assert.That(next, !Is.EqualTo(null));


            Assert.That(next.Count(), Is.EqualTo(1));

            Assert.That(next.ElementAt(0), Is.EqualTo(tester2));


        }

        [Test]
        public void alreadyExistsInNext_NoDup_ExpectedBehavior()
        {
            var tester = new RouteNodeImpl("Test");

            IRouteNode tester2 = new RouteNodeImpl("PrevTest");

            Assert.That(tester.alreadyExistsInNext(ref tester2), Is.False);
        }

        [Test]
        public void alreadyExistsInNext_HasDup_ExpectedBehavior()
        {
            var tester = new RouteNodeImpl("Test");

            IRouteNode tester2 = new RouteNodeImpl("PrevTest");


            tester.addNext(ref tester2);

            Assert.That(tester.alreadyExistsInNext(ref tester2), Is.True);
        }

        [Test]
        public void alreadyExistsInPrevious_NoDup_ExpectedBehavior()
        {
            var tester = new RouteNodeImpl("Test");

            IRouteNode tester2 = new RouteNodeImpl("PrevTest");

            Assert.That(tester.alreadyExistsInPrevious(ref tester2), Is.False);
        }

        [Test]
        public void alreadyExistsInPrevious_HasDup_ExpectedBehavior()
        {
            var tester = new RouteNodeImpl("Test");

            IRouteNode tester2 = new RouteNodeImpl("PrevTest");


            tester.addPrevious(ref tester2);

            Assert.That(tester.alreadyExistsInPrevious(ref tester2), Is.True);
        }

        [Test]
        public void forwardTraverse_Empty_ExpectedBehavior()
        {
            var tester = new RouteNodeImpl("Test");
            string current = "";
            List<string> list = new List<string>();

            tester.forwardTraverse(current, ref list);

            Assert.That(list.Count(), Is.EqualTo(1));

            Assert.That(list[0], Is.EqualTo(tester.getValue()));
        }

        [Test]
        public void forwardTraverse_ContainsData_ExpectedBehavior()
        {
            IRouteNode tester = new RouteNodeImpl("Test");
            IRouteNode tester2 = new RouteNodeImpl("Middle");
            IRouteNode tester3 = new RouteNodeImpl("First");

            tester3.addNext(ref tester2);
            tester2.addNext(ref tester);


            string current = "";
            List<string> list = new List<string>();

            tester3.forwardTraverse(current, ref list);

            Assert.That(list.Count(), Is.EqualTo(1));

            Assert.That(list[0], Is.EqualTo("FirstMiddleTest"));
        }

        [Test]
        public void isLeafNode_NotLeaf_ExpectedBehavior()
        {
            IRouteNode tester = new RouteNodeImpl("Test");
            IRouteNode tester2 = new RouteNodeImpl("Middle");
            IRouteNode tester3 = new RouteNodeImpl("First");


            tester3.addNext(ref tester2);
            tester2.addNext(ref tester);

            Assert.That(tester3.isLeafNode(), Is.False);
            Assert.That(tester2.isLeafNode(), Is.False);
        }

        [Test]
        public void isLeafNode_IsLeaf_ExpectedBehavior()
        {
            IRouteNode tester = new RouteNodeImpl("Test");
            IRouteNode tester2 = new RouteNodeImpl("Middle");
            IRouteNode tester3 = new RouteNodeImpl("First");


            tester3.addNext(ref tester2);
            tester2.addNext(ref tester);

            Assert.That(tester.isLeafNode(), Is.True);
            
        }

        [Test]
        public void isRootNode_NotRoot_ExpectedBehavior()
        {
            IRouteNode tester = new RouteNodeImpl("Test");
            IRouteNode tester2 = new RouteNodeImpl("Middle");
            IRouteNode tester3 = new RouteNodeImpl("First");


            tester3.addNext(ref tester2);
            tester2.addNext(ref tester);

            Assert.That(tester.isRootNode(), Is.False);
            Assert.That(tester2.isRootNode(), Is.False);
        }

        [Test]
        public void isRootNode_IsRoot_ExpectedBehavior()
        {
            IRouteNode tester = new RouteNodeImpl("Test");
            IRouteNode tester2 = new RouteNodeImpl("Middle");
            IRouteNode tester3 = new RouteNodeImpl("First");


            tester3.addNext(ref tester2);
            tester2.addNext(ref tester);

            Assert.That(tester3.isRootNode(), Is.True);
            Assert.That(tester2.isRootNode(), Is.False);

        }
    }

   
}