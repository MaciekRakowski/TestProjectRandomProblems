using System;
using System.Collections.Generic;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibraryRoblox;

namespace UnitTestProjectRoblox
{
    [TestClass]
    public class RobloxTests
    {
        [TestMethod]
        public void TestMergedListHappy()
        {
            List<int> l1 = new List<int>(new int[] { 1, 3, 5 });
            List<int> l2 = new List<int>(new int[] { 2, 4, 6, 7 });

            var merged = MergedListProblem.GetMergedList(l1, l2);

            CollectionAssert.AreEqual(merged, new int[] { 1, 2, 3, 4, 5, 6, 7 });
        }

        [TestMethod]
        public void TestMergedListSame()
        {
            List<int> l1 = new List<int>(new int[] { 1, 1, 1 });
            List<int> l2 = new List<int>(new int[] { 1, 1, 1, 1 });

            var merged = MergedListProblem.GetMergedList(l1, l2);

            CollectionAssert.AreEqual(merged, new int[] { 1, 1, 1, 1, 1, 1, 1 });
        }

        [TestMethod]
        public void TestMergedListEmpty()
        {
            List<int> l1 = new List<int>(new int[] { });
            List<int> l2 = new List<int>(new int[] { 1, 1, 1, 1 });

            var merged = MergedListProblem.GetMergedList(l1, l2);

            CollectionAssert.AreEqual(merged, new int[] { 1, 1, 1, 1 });
        }

        [TestMethod]
        public void TestMergedListNull()
        {
            List<int> l1 = new List<int>(new int[] { 2, 2, 3 });
            List<int> l2 = null;

            var merged = MergedListProblem.GetMergedList(l1, l2);

            CollectionAssert.AreEqual(merged, new int[] { 2, 2, 3 });
        }


        [TestMethod]
        public void NormalMax3Test()
        {
            var product = MaximumProductProblem.GetMaxProduct(new List<int>(new int[] { 10, 2, 5, 3, 6, 7, 5, 9, 2, 4, 8, 0, 3 }));
            Assert.AreEqual(product, 720);
        }

        [TestMethod]
        public void TestException()
        {
            try
            {
                var product = MaximumProductProblem.GetMaxProduct(new List<int>(new int[] { 1, 2 }));
                Assert.Fail();
            }
            catch(ArgumentException ex)
            {
                Assert.AreEqual(ex.Message, "List size needs to be < 3.");
            }
        }

        [TestMethod]
        public void TestNegativesSize4()
        {
            var product = MaximumProductProblem.GetMaxProduct(new List<int>(new int[] { -5, 10, 5, -10 }));
            Assert.AreEqual(product, 500);
        }

        [TestMethod]
        public void TestNegativesSize10()
        {
            var product = MaximumProductProblem.GetMaxProduct(new List<int>(new int[] { -10, -10, 4, 9, 8, 7, 5, 10, 1, 0 }));
            Assert.AreEqual(product, 1000);
        }

        [TestMethod]
        public void FromSample()
        {
            var product = MaximumProductProblem.GetMaxProduct(new List<int>(new int[] { 10, 3, 0, -2, 12, 5, 1, 1, 4 }));
            Assert.AreEqual(product, 600);
        }

        [TestMethod]
        public void TestNegativesLower()
        {
            var product = MaximumProductProblem.GetMaxProduct(new List<int>(new int[] { -10, -10, 4, 11, 8, 11, 5, 10, 1, 0 }));
            Assert.AreEqual(product, 1210);
        }

        [TestMethod]
        public void Test2Negative2Positive()
        {
            var product = MaximumProductProblem.GetMaxProduct(new List<int>(new int[] { 2, 2, -2, -2}));
            Assert.AreEqual(product, 8);
        }

        [TestMethod]
        public void TestLarge()
        {
            try
            {
                var product = MaximumProductProblem.GetMaxProduct(new List<int>(new int[] { int.MaxValue, int.MaxValue, int.MaxValue }));
                Assert.Fail();
            }
            catch(ArgumentException ex)
            {
                Assert.AreEqual(ex.Message, "Does not evaluate to valid Int32.");
                Assert.IsTrue(ex.InnerException is OverflowException);
            }
        }
    }
}
