using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSTree
{
    public class StdNode : IBSNode<int, string>
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
        public StdNode(int key, string value)
        {
            Key = key;
            Value = value;
        }

        /// <summary>
        /// Ключ узла
        /// </summary>
        public int Key { get; set; }

        /// <summary>
        /// Значение узла
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Левый потомок узла
        /// </summary>
        public StdNode Left { get; set; }

        /// <summary>
        /// Правый потомок узла
        /// </summary>
        public StdNode Right { get; set; }

        /// <summary>
        /// Помещение данных в дерево под ключом
        /// </summary>
        public void Insert(int key, string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                if (Key == 0)
                {
                    Key = key;
                    Value = value;
                }
                if (Key == key)
                {
                    Value = value;
                }
                else if (key < Key)
                {
                    if (Left == null)
                        Left = new StdNode(key, value);
                    else
                        Left.Insert(key, value);
                }
                else if (key > Key)
                {
                    if (Right == null)
                        Right = new StdNode(key, value);
                    else
                        Right.Insert(key, value);
                }
            }
        }

        /// <summary>
        /// Поиск в дереву по значению ключа
        /// </summary>
        public string Find(int key)
        {
            string result = string.Empty;

            if (Key == key)
                result = Value;
            else if (key < Key && Left != null)
                result = Left.Find(key);
            else if (key > Key && Right != null)
                result = Right.Find(key);

            return result;
        }

        /// <summary>
        /// Удаление данных из дерева по ключу
        /// </summary>
        public void Delete(int key)
        {
            if (key == Key)
            {
                if (Left == null && Right == null)
                    Key = 0;
                else if (Left == null)
                {
                    Key = Right.Key;
                    Value = Right.Value;
                    Left = Right.Left;
                    Right = Right.Right;
                }
                else if (Right == null)
                {
                    Key = Left.Key;
                    Value = Left.Value;
                    Right = Left.Right;
                    Left = Left.Left;
                }
                else
                {
                    if (Right.Left == null)
                    {
                        Key = Right.Key;
                        Value = Right.Value;
                        Right = Right.Right;
                    }
                    else
                    {
                        StdNode node = Right.Left;

                        while (node.Left != null)
                            node = node.Left;

                        Key = node.Key;
                        Value = node.Value;
                        node.Delete(node.Key);
                    }
                }
            }
            else if (key < Key && Left != null)
            { 
                Left.Delete(key);
                if (Left.Key == 0)
                    Left = null;
            }
            else if (key > Key && Right != null)
            { 
                Right.Delete(key);
                if (Right.Key == 0)
                    Right = null;
            }
        }

        /// <summary>
        /// Left - Node - Right
        /// </summary>
        public void InorderTraverse(Traverse<int, string> traverseFunc)
        {
            Left?.InorderTraverse(traverseFunc);
            traverseFunc(Key, Value);
            Right?.InorderTraverse(traverseFunc);
        }

        /// <summary>
        /// Left - Right - Node
        /// </summary>
        public void PostorderTraverse(Traverse<int, string> traverseFunc)
        {
            Left?.PostorderTraverse(traverseFunc);
            Right?.PostorderTraverse(traverseFunc);
            traverseFunc(Key, Value);
        }

        /// <summary>
        /// Node - Left - Right
        /// </summary>
        public void PreorderTraverse(Traverse<int, string> traverseFunc)
        {
            traverseFunc(Key, Value);
            Left?.PreorderTraverse(traverseFunc);
            Right?.PreorderTraverse(traverseFunc);
        }
    }
}
