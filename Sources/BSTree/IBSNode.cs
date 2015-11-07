using System;
using System.Collections.Generic;

namespace BSTree
{
    public delegate void Traverse<Key, Value>(Key key, Value value) where Key : IComparable;

    public interface IBSNode<Key, Value> where Key : IComparable
    {
        Value Find(Key key);
        void Insert(Key key, Value value);
        void Delete(Key key);

        void InorderTraverse(Traverse<Key, Value> traverseFunc);
        void PreorderTraverse(Traverse<Key, Value> traverseFunc);
        void PostorderTraverse(Traverse<Key, Value> traverseFunc);
    }
}
