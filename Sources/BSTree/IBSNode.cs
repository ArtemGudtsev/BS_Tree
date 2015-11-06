using System;

namespace BSTree
{
    public delegate void PerformTraversing<Key, Value>(Key key, Value value) where Key : IComparable;

    public interface IBSNode<Key, Value> where Key : IComparable
    {
        Value Find(Key key);
        void Insert(Key key, Value value);
        void Delete(Key key);

        void InorderTraverse(PerformTraversing<Key, Value> traverseFunc);
        void PreorderTraverse(PerformTraversing<Key, Value> traverseFunc);
        void PostorderTraverse(PerformTraversing<Key, Value> traverseFunc);

        void Split(Key splittingKey, out IBSNode<Key, Value> leftTree, out IBSNode<Key, Value> rightTree);
        void MergeTrees(IBSNode<Key, Value> tree1, IBSNode<Key, Value> tree2);
    }
}
