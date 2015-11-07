using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace BSTree.Tests
{
    [TestClass]
    public class StandartOperationsTests
    {
        protected int treeCount = 20;

        [TestMethod]
        public void TestCreateTree()
        {
            //var treeHead = MockFabric.GetMockForBSTree(TestDataGenerator.GetKeysAndValues(treeCount)).Object;
            var treeHead = new StdNode();

            for (int i = 0; i < treeCount; i++)
                treeHead.Insert(i, Convert.ToString(i));
        }

        [TestMethod]
        public void TestInsertAndFind()
        {
            var testData = TestDataGenerator.GetKeysAndValues(treeCount);
            //var treeHead = MockFabric.GetMockForBSTree(testData).Object;
            var treeHead = new StdNode();

            for (int i = 0; i < treeCount; i++)
                treeHead.Insert(testData.Item1[i], testData.Item2[i]);

            for (int i = 0; i < treeCount; i++)
                Assert.AreEqual(testData.Item2[i], treeHead.Find(testData.Item1[i]));
        }

        [TestMethod]
        public void TestDelete1()//удаление листа
        {
            var treeHead = new StdNode();
            var keys = new List<int>(new int[] { 10, 5, 15 });
            var keyToDelete = keys[2];

            foreach (int key in keys)
                treeHead.Insert(key, Convert.ToString(key));

            treeHead.Delete(keyToDelete);
            keys.Remove(keyToDelete);

            Assert.AreEqual(string.Empty, treeHead.Find(keyToDelete));

            foreach (int key in keys)
                Assert.AreEqual(Convert.ToString(key), treeHead.Find(key));
        }

        [TestMethod]
        public void TestDelete2()//удаление узла с одним из потомков
        {
            var treeHead = new StdNode();
            var keys = new List<int>(new int[] { 10, 5, 15, 12 });
            var keyToDelete = keys[2];

            foreach (int key in keys)
                treeHead.Insert(key, Convert.ToString(key));

            treeHead.Delete(keyToDelete);
            keys.Remove(keyToDelete);

            Assert.AreEqual(string.Empty, treeHead.Find(keyToDelete));

            foreach (int key in keys)
                Assert.AreEqual(Convert.ToString(key), treeHead.Find(key));
        }

        [TestMethod]
        public void TestDelete3()//удаление узла с обоими потомками, но у правого потомка нет левой ветви
        {
            var treeHead = new StdNode();
            var keys = new List<int>(new int[] { 10, 5, 15, 12, 17, 18 });
            var keyToDelete = keys[2];

            foreach (int key in keys)
                treeHead.Insert(key, Convert.ToString(key));

            treeHead.Delete(keyToDelete);
            keys.Remove(keyToDelete);

            Assert.AreEqual(string.Empty, treeHead.Find(keyToDelete));

            foreach (int key in keys)
                Assert.AreEqual(Convert.ToString(key), treeHead.Find(key));
        }

        [TestMethod]
        public void TestDelete4()//удаление узла с обоими потомками, у правого потомка есть левая ветвь
        {
            var treeHead = new StdNode();
            var keys = new List<int>(new int[] { 10, 5, 17, 14, 19, 18, 20, 13, 15 });
            var keyToDelete = keys[2];

            foreach (int key in keys)
                treeHead.Insert(key, Convert.ToString(key));

            treeHead.Delete(keyToDelete);
            keys.Remove(keyToDelete);

            Assert.AreEqual(string.Empty, treeHead.Find(keyToDelete));

            foreach (int key in keys)
                Assert.AreEqual(Convert.ToString(key), treeHead.Find(key));
        }

        [TestMethod]
        public void TestDeleteComplex()
        {
            var testData = TestDataGenerator.GetKeysAndValues(treeCount);
            var treeHead = new StdNode();

            List<int> existingKeys = new List<int>(testData.Item1);
            List<int> deletedKeys = new List<int>();

            Random rnd = new Random();

            for (int i = 0; i < treeCount; i++)
                treeHead.Insert(testData.Item1[i], testData.Item2[i]);

            while (existingKeys.Count > 0)
            {
                foreach (int key in existingKeys)
                    Assert.AreEqual(Convert.ToString(key), treeHead.Find(key));
                
                int keyToDelete = existingKeys[rnd.Next(0, existingKeys.Count - 1)];

                treeHead.Delete(keyToDelete);
                deletedKeys.Add(keyToDelete);
                existingKeys.RemoveAll(x => x == keyToDelete);

                int deletedKeyToFind = deletedKeys[rnd.Next(0, deletedKeys.Count - 1)];

                Assert.AreEqual(string.Empty, treeHead.Find(deletedKeyToFind));
            }
        }
    }
}
