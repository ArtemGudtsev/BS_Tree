using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BSTree.Tests
{
    [TestClass]
    public class TestTests
    {
        [TestMethod]
        public void CheckTestData()
        {
            var testData = TestDataGenerator.GetKeysAndValues(50);

            for (int i = 0; i < 50; i++)
                Assert.AreEqual(testData.Item1[i], Convert.ToInt32(testData.Item2[i]));
        }
    }
}
