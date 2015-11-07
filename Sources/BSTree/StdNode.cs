using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSTree
{
    public class StdNode : IBSNode<int, string>
    {
        public StdNode()
        {
            //Random rnd = new Random();
            //Key = rnd.Next(0, int.MaxValue);
        }

        public StdNode(int key, string value)
        {
            Key = key;
            Value = value;
        }

        public int Key { get; set; }

        public string Value { get; set; }

        public StdNode Left { get; set; }

        public StdNode Right { get; set; }

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

        public void InorderTraverse(TraverseAndCollect<Int32, string> traverseFunc)
        {
            throw new NotImplementedException();
        }

        public void InorderTraverse(Traverse<Int32, string> traverseFunc)
        {
            throw new NotImplementedException();
        }

        public void PostorderTraverse(TraverseAndCollect<Int32, string> traverseFunc)
        {
            throw new NotImplementedException();
        }

        public void PostorderTraverse(Traverse<Int32, string> traverseFunc)
        {
            throw new NotImplementedException();
        }

        public void PreorderTraverse(TraverseAndCollect<Int32, string> traverseFunc)
        {
            throw new NotImplementedException();
        }

        public void PreorderTraverse(Traverse<Int32, string> traverseFunc)
        {
            throw new NotImplementedException();
        }

        public void MergeTrees(IBSNode<Int32, string> tree1, IBSNode<Int32, string> tree2)
        {
            throw new NotImplementedException();
        }

        public Tuple<IBSNode<int, string>, IBSNode<int, string>> Split(int splittingKey)
        {
            throw new NotImplementedException();
        }
    }
}
