using System;

namespace AVLTree
{

    internal class Program
    {
        private static void Main(string[] args)
        {
            var tree = new AVLTree<int>();
            var node2 = new Node<int>(2);
            var node9 = new Node<int>(9);
            var node4 = new Node<int>(4);
            node4.LeftNode = node2;
            var node8 = new Node<int>(8);
            node8.LeftNode = node4;
            node8.RightNode = node9;

            tree.Root = node8;
            Console.WriteLine(tree.GetInOrder());

            tree.Add(1);
            Console.WriteLine(tree.GetInOrder());

            Console.WriteLine(tree.Height(node2));
        }
    }

    internal class AVLTree<T> where T : IComparable
    {
        public Node<T> Root { get; set; }

        public void Add(T data)
        {
            var childAddedSide = default(AddedSide);
            Root = Add(data, Root, out childAddedSide);
        }

        public Node<T> Add(T data, Node<T> node, out AddedSide childAddedSide)
        {
            childAddedSide = default(AddedSide);
            if (node == null)
            {
                return new Node<T>(data);
            }
            var compared = data.CompareTo(node.Element);
            var addedSide = default(AddedSide);
            if (compared < 0)
            {
                node.LeftNode = Add(data, node.LeftNode, out childAddedSide);
                addedSide = AddedSide.Left;
            }
            else if (compared > 0)
            {
                node.RightNode = Add(data, node.RightNode, out childAddedSide);
                addedSide = AddedSide.Right;
            }
            else
            {
                throw new DuplicateItemException(data);
            }

            var retNode = BalanceOut(node, addedSide, childAddedSide);
            childAddedSide = addedSide;
            return retNode;
        }

        private Node<T> BalanceOut(Node<T> node, AddedSide addedSide, AddedSide childAddedSide)
        {
            if (Math.Abs(Height(node.RightNode) - Height(node.LeftNode)) > 1)
            {
                if (addedSide == AddedSide.Left && childAddedSide == AddedSide.Left)
                {
                    return RotateWithLeftChild(node);
                }
                else if (addedSide == AddedSide.Left && childAddedSide == AddedSide.Right)
                {
                    return DoubleRotateWithLeftChild(node);
                }
                else if (addedSide == AddedSide.Right && childAddedSide == AddedSide.Left)
                {
                    return DoubleRotateWithRightChild(node);
                }
                else if (addedSide == AddedSide.Right && childAddedSide == AddedSide.Right)
                {
                    return RotateWithRightChild(node);
                }
                else
                {
                    throw new Exception();
                }
            }
            else
            {
                return node;
            }
        }

        private Node<T>  RotateWithLeftChild(Node<T> k2)
        {
            var k1 = k2.LeftNode;
            k2.LeftNode = k1.RightNode;
            k1.RightNode = k2;
            return k1;
        }

        private Node<T> RotateWithRightChild(Node<T> k2)
        {
            var k1 = k2.RightNode;
            k2.RightNode = k1.LeftNode;
            k1.LeftNode = k2;
            return k1;
        }

        private Node<T> DoubleRotateWithLeftChild(Node<T> k3)
        {
            k3.LeftNode = RotateWithRightChild(k3.LeftNode);
            return RotateWithLeftChild(k3);
        }

        private Node<T> DoubleRotateWithRightChild(Node<T> k3)
        {
            k3.RightNode = RotateWithLeftChild(k3.RightNode);
            return RotateWithRightChild(k3);
        }
        public int Height()
        {
            return Height(Root);
        }

        public int Height(Node<T> node)
        {
            if (node == null)
            {
                return -1;
            }
            return 1 + Math.Max(Height(node.LeftNode), Height(node.RightNode));
        }

        public string GetInOrder()
        {
            return GetInOrder(Root);
        }

        private string GetInOrder(Node<T> node)
        {
            if (node == null)
            {
                return "";
            }
            else
            {
                return $"{GetInOrder(node.LeftNode)}{node.Element},{GetInOrder(node.RightNode)}";
            }
        }
    }

    internal enum AddedSide
    {
        Left,
        Right
    }

    internal class Node<T> where T : IComparable
    {
        public T Element { get; set; }
        public Node<T> LeftNode { get; set; }
        public Node<T> RightNode { get; set; }

        public Node(T data)
        {
            Element = data;
        }
    }

}