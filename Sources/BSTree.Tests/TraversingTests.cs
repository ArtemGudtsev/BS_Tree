using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace BSTree.Tests
{
    [TestClass]
    public class TraversingTests
    {
        [TestMethod]
        public void TestInorderTraverse()
        {
            var treeHead = GetTree(40);
            List<int> sortedKeys = new List<int>();

            treeHead.InorderTraverse((key, value) => sortedKeys.Add(key));
        }

        protected StdNode GetTree(int count)
        {
            var treeHead = new StdNode();
            var testData = TestDataGenerator.GetKeysAndValues(count);

            FillTreeByTestData(treeHead, testData);

            return treeHead;
        }

        protected void FillTreeByTestData(StdNode head, Tuple<int[], string[]> data)
        {
            var keys = data.Item1;
            var values = data.Item2;

            for (int i = 0; i < keys.Length; i++)
                head.Insert(keys[i], values[i]);
        }

        [TestMethod]
        public void TestPreorderTraverse()
        {
            var treeHead = GetTree(40);
            var allKeys = new List<int>();

            treeHead.PreorderTraverse((key, value) => allKeys.Add(key));
        }

        [TestMethod]
        public void TestPostorderTraverse()
        {
            var treeHead = GetTree(40);
            var allKeys = new List<int>();

            treeHead.PostorderTraverse((key, value) => allKeys.Add(key));
        }
    }

    
}
