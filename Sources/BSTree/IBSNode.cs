using System;
using System.Collections.Generic;

namespace BSTree
{
    public delegate void Traverse<Key, Value>(Key key, Value value) where Key : IComparable;
    public delegate void TraverseAndCollect<Key, Value>(Key key, Value value, List<Value> buffer) where Key : IComparable;

    public interface IBSNode<Key, Value> where Key : IComparable
    {
        Value Find(Key key);
        void Insert(Key key, Value value);
        void Delete(Key key);

        void InorderTraverse(Traverse<Key, Value> traverseFunc);
        void PreorderTraverse(Traverse<Key, Value> traverseFunc);
        void PostorderTraverse(Traverse<Key, Value> traverseFunc);

        void InorderTraverse(TraverseAndCollect<Key, Value> traverseFunc);
        void PreorderTraverse(TraverseAndCollect<Key, Value> traverseFunc);
        void PostorderTraverse(TraverseAndCollect<Key, Value> traverseFunc);

        Tuple<IBSNode<Key, Value>, IBSNode<Key, Value>> Split(Key splittingKey);
        void MergeTrees(IBSNode<Key, Value> tree1, IBSNode<Key, Value> tree2);
    }
}
