using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
    class Program
    {
        static void Main(string[] args)
        {
            var bst = new BinarySearchTree<int>();
            bst.Insert(3);
            bst.Insert(6);
            bst.Insert(2);
            bst.Insert(1);

            Console.WriteLine(bst.GetInOrder());

            bst.Remove(1);
            Console.WriteLine(bst.GetInOrder());

            bst.Insert(8);
            bst.Insert(5);

            Console.WriteLine(bst.GetInOrder());
            bst.Remove(6);
            Console.WriteLine(bst.GetInOrder());

            bst.Remove(3);
            Console.WriteLine(bst.GetInOrder());

            bst = new BinarySearchTree<int>();
            var random = new Random();
            for (var i = 0; i < 100000; i++)
            {
                bst.Insert(random.Next(100000));
            }

            Console.WriteLine(bst.GetInOrder());

            for (var i = 0; i < 100000; i++)
            {
                Console.WriteLine($"Removing {i}");
                bst.Remove(i);
            }

            Console.WriteLine(bst.GetInOrder());
        }
    }

    public class BinarySearchTree<T> where T : IComparable
    {
        public Node<T> Root { get; set; }

        public void Insert(T data)
        {
            if (Root != null)
            {
                Root.Insert(data);
            }
            else
            {
                Root = new Node<T>(data);
            }
        }

        public string GetInOrder()
        {
            if (Root != null)
            {
                return Root.GetInOrder();
            }
            else
            {
                return "";
            }
        }

        public void Remove(T data)
        {
            Root = Root?.Remove(data);
        }
    }

    public class Node<T> where T : IComparable
    {
        public T Element { get; set; }
        public Node <T> LeftNode { get; set; }
        public Node<T> RightNode { get; set; }

        public Node(T element)
        {
            Element = element;
        }

        public void Insert(T data)
        {
            var compared = data.CompareTo(Element);
            if (compared < 0)
            {
                if (LeftNode != null)
                {
                    LeftNode.Insert(data);
                }
                else
                {
                    LeftNode = new Node<T>(data);
                }
            }
            else if(compared > 0)
            {
                if (RightNode != null)
                {
                    RightNode.Insert(data);
                }
                else
                {
                    RightNode = new Node<T>(data);
                }
            }
        }

        public string GetInOrder()
        {
            var sb= new StringBuilder();

            if (LeftNode != null)
            {
                sb.Append(LeftNode.GetInOrder());
            }
            sb.Append(Element);
            sb.Append(",");
            if (RightNode != null)
            {
                sb.Append(RightNode.GetInOrder());
            }
            return sb.ToString();
        }

        public Node<T> Remove(T data)
        {
            var compared = data.CompareTo(Element);
            if (compared == 0)
            {
                // this element should be removed
                if (LeftNode == null)
                {
                    return RightNode;
                }
                else if(RightNode == null)
                {
                    return LeftNode;
                }
                else
                {
                    Element = RightNode.FindMin();
                    RightNode = RightNode.RemoveMin();
                }
            }
            else if (compared < 0)
            {
                LeftNode = LeftNode?.Remove(data);
            }
            else
            {
                RightNode = RightNode?.Remove(data);
            }

            return this;
        }

        private Node<T> RemoveMin()
        {
            if (LeftNode == null)
            {
                return RightNode;
            }
            LeftNode = LeftNode.RemoveMin();
            return this;
        }

        private T FindMin()
        {
            return this.LeftNode != null
                ? LeftNode.FindMin()
                : Element;
        }
    }
}
