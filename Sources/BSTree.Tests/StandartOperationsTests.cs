using System;
using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BSTree.Tests
{
    [TestClass]
    public class StandartOperationsTests
    {
        protected int treeCount = 20;

        [TestMethod]
        public void TestCreateTree()
        {
            var treeHead = MockFabric.GetMockForBSTree(TestDataGenerator.GetKeysAndValues(treeCount)).Object;

            for (int i = 0; i < treeCount; i++)
                treeHead.Insert(i, Convert.ToString(i));
        }

        [TestMethod]
        public void TestFind()
        {
            var testData = TestDataGenerator.GetKeysAndValues(treeCount);
            var treeHead = MockFabric.GetMockForBSTree(testData).Object;

            for (int i = 0; i < treeCount; i++)
                treeHead.Insert(testData.Item1[i], testData.Item2[i]);

            for (int i = 0; i < treeCount; i++)
                Assert.AreEqual(testData.Item2[i], treeHead.Find(testData.Item1[i]));
        }
    }
}
