using System;

namespace BSTree
{
    public class StdNode<Key, Value> : IBSNode<Key, Value> where Key : IComparable
    {
        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public StdNode()
        {
            
        }

        /// <summary>
        /// Конструктор для инициализации узла готовыми значениями
        /// </summary>
        public StdNode(Key key, Value value)
        {
            this.NodeKey = key;
            this.NodeValue = value;
        }

        /// <summary>
        /// Ключ узла
        /// </summary>
        public Key NodeKey { get; set; }

        /// <summary>
        /// Значение узла
        /// </summary>
        public Value NodeValue { get; set; }

        /// <summary>
        /// Левый потомок узла
        /// </summary>
        public StdNode<Key, Value> Left { get; set; }

        /// <summary>
        /// Правый потомок узла
        /// </summary>
        public StdNode<Key, Value> Right { get; set; }

        /// <summary>
        /// Помещение данных в дерево под ключом
        /// </summary>
        public void Insert(Key key, Value value)
        {
            if (NodeKey.CompareTo(default(Key)) == 0)
            {
                NodeKey = key;
                NodeValue = value;
            }
            else if (NodeKey.CompareTo(key) == 0)
            {
                NodeValue = value;
            }
            else if (NodeKey.CompareTo(key) > 0)
            {
                if (Left == null)
                    Left = new StdNode<Key, Value>(key, value);
                else
                    Left.Insert(key, value);
            }
            else if (NodeKey.CompareTo(key) < 0)
            {
                if (Right == null)
                    Right = new StdNode<Key, Value>(key, value);
                else
                    Right.Insert(key, value);
            }
        }

        /// <summary>
        /// Поиск в дереву по значению ключа
        /// </summary>
        public Value Find(Key key)
        {
            Value result = default(Value);

            if (NodeKey.CompareTo(key) == 0)
                result = NodeValue;
            else if (NodeKey.CompareTo(key) > 0 && Left != null)
                result = Left.Find(key);
            else if (NodeKey.CompareTo(key) < 0 && Right != null)
                result = Right.Find(key);

            return result;
        }

        /// <summary>
        /// Удаление данных из дерева по ключу
        /// </summary>
        public void Delete(Key key)
        {
            if (NodeKey.CompareTo(key) == 0)
            {
                if (Left == null && Right == null)
                    NodeKey = default(Key);
                else if (Left == null)
                    Copy(Right, this);
                else if (Right == null)
                    Copy(Left, this);
                else
                {
                    if (Right.Left == null)
                    {
                        NodeKey = Right.NodeKey;
                        NodeValue = Right.NodeValue;
                        Right = Right.Right;
                    }
                    else
                    {
                        var parent = Right;
                        var node = parent.Left;

                        while (node.Left != null)
                        {
                            parent = node;
                            node = parent.Left;
                        }

                        NodeKey = node.NodeKey;
                        NodeValue = node.NodeValue;
                        if (node.Right == null)
                            parent.Left = null;
                        else
                            parent.Left = node.Right;
                    }
                }
            }
            else if (NodeKey.CompareTo(key) > 0 && Left != null)
            { 
                Left.Delete(key);
                if (Left.NodeKey.CompareTo(default(Key)) == 0)
                    Left = null;
            }
            else if (NodeKey.CompareTo(key) < 0 && Right != null)
            { 
                Right.Delete(key);
                if (Right.NodeKey.CompareTo(default(Key)) == 0)
                    Right = null;
            }
        }

        protected void Copy(StdNode<Key, Value> src, StdNode<Key, Value> dst)
        {
            dst.NodeKey = src.NodeKey;
            dst.NodeValue = src.NodeValue;
            dst.Left = src.Left;
            dst.Right = src.Right;
        }

        /// <summary>
        /// Left - Node - Right
        /// </summary>
        public void InorderTraverse(Traverse<Key, Value> traverseFunc)
        {
            Left?.InorderTraverse(traverseFunc);
            traverseFunc(NodeKey, NodeValue);
            Right?.InorderTraverse(traverseFunc);
        }

        /// <summary>
        /// Left - Right - Node
        /// </summary>
        public void PostorderTraverse(Traverse<Key, Value> traverseFunc)
        {
            Left?.PostorderTraverse(traverseFunc);
            Right?.PostorderTraverse(traverseFunc);
            traverseFunc(NodeKey, NodeValue);
        }

        /// <summary>
        /// Node - Left - Right
        /// </summary>
        public void PreorderTraverse(Traverse<Key, Value> traverseFunc)
        {
            traverseFunc(NodeKey, NodeValue);
            Left?.PreorderTraverse(traverseFunc);
            Right?.PreorderTraverse(traverseFunc);
        }
    }
}
