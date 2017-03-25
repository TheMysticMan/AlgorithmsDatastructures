using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            var tree = new BinaryTree<int>();
            
            
        }
    }

    public class BinaryTree<T>
    {
        public BinaryTreeNode<T> Root { get; set; }

        public string GetPreOrder(BinaryTreeNode<T> node = null)
        {
            if (node == null)
                node = Root;

            var sb =  new StringBuilder();
            if (node != null)
            {
                sb.Append(node.Data);
                if (node.LeftNode != null)
                {
                    sb.Append(GetPreOrder(node.LeftNode));
                }
                if (node.RightNode != null)
                {
                    sb.Append(GetPreOrder(node.RightNode));
                }
            }

            return sb.ToString();
        }

        public string GetPostOrder(BinaryTreeNode<T> node = null)
        {
            if (node == null)
                node = Root;

            var sb = new StringBuilder();
            if (node != null)
            {
                if (node.LeftNode != null)
                {
                    sb.Append(GetPostOrder(node.LeftNode));
                }
                if (node.RightNode != null)
                {
                    sb.Append(GetPostOrder(node.RightNode));
                }
                sb.Append(node.Data);
            }

            return sb.ToString();
        }
        public string GetInOrder(BinaryTreeNode<T> node = null)
        {
            if (node == null)
                node = Root;

            var sb = new StringBuilder();
            if (node != null)
            {
                if (node.LeftNode != null)
                {
                    sb.Append(GetInOrder(node.LeftNode));
                }
                sb.Append(node.Data);
                if (node.RightNode != null)
                {
                    sb.Append(GetInOrder(node.RightNode));
                }
            }

            return sb.ToString();
        }

        public int GetSize(BinaryTreeNode<T> node)
        {
            if (node == null)
                node = Root;

            var retVal = 0;
            if (node != null)
            {
                retVal++;
                if (node.LeftNode != null)
                {
                    retVal += GetSize(node.LeftNode);
                }
                if (node.RightNode != null)
                {
                    retVal += GetSize(node.RightNode);
                }
            }
            return retVal;
        }
    }

    public class BinaryTreeNode<T>
    {
        public T Data { get; set; }
        public BinaryTreeNode<T> LeftNode { get; set; }
        public BinaryTreeNode<T> RightNode { get; set; }
    }
}
