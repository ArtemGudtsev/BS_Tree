using Moq;

namespace BSTree.Tests
{
    public class MockFabric
    {
        public static Mock<IBSNode<int, string>> GetMockForBSTree()
        {
            var mock = new Mock<IBSNode<int, string>>();

            return mock;
        }
    }
}
