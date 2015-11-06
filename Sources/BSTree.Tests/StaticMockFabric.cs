using Moq;

namespace BSTree.Tests
{
    public class MockFabric
    {
        public static Mock<IBSNode<int, string>> GetMockForBSTree()
        {
            var mock = new Mock<IBSNode<int, string>>();

            mock.Setup(node => node.Insert(1, "1"));
            mock.Setup(node => node.Insert(2, "2"));
            mock.Setup(node => node.Insert(0, "0"));

            mock.Setup(node => node.Find(0)).Returns("0");
            mock.Setup(node => node.Find(1)).Returns("1");
            mock.Setup(node => node.Find(2)).Returns("2");

            return mock;
        }
    }
}
