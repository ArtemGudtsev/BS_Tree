using System;
using Moq;

namespace BSTree.Tests
{
    public class MockFabric
    {
        public static Mock<IBSNode<Int32, string>> GetMockForBSTree()
        {
            return GetMockForBSTree(10);
        }

        public static Mock<IBSNode<Int32, string>> GetMockForBSTree(int count)
        {
            var mock = new Mock<IBSNode<Int32, string>>();
            
            for (int i=0; i< count; i++)
            {
                string val = Convert.ToString(i);
                mock.Setup(node => node.Insert(i, val));
                mock.Setup(node => node.Find(i)).Returns(val);
            }

            return mock;
        }

        public static Mock<IBSNode<Int32, string>> GetMockForBSTree(Tuple<Int32[], string[]> testData)
        {
            Int32[] keys = testData.Item1;
            string[] values = testData.Item2;

            if (keys.Length != values.Length)
                throw new Exception("Keys and Values should have same sizes!");

            int count = keys.Length;
            var mock = new Mock<IBSNode<Int32, string>>();

            for (int i = 0; i < count; i++)
            {
                mock.Setup(node => node.Insert(keys[i], values[i]));
                mock.Setup(node => node.Find(keys[i])).Returns(values[i]);
            }

            return mock;
        }
    }
}
