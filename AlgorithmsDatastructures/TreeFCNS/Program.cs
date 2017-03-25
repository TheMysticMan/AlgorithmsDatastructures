using System;
using System.Text;

namespace TreeFCNS
{

    internal class Program
    {
        private static void Main(string[] args)
        {
            var kNode = new FirstChildNextSiblingNode<char>('K');
            var jNode = new FirstChildNextSiblingNode<char>('J', kNode);
            var iNode = new FirstChildNextSiblingNode<char>('I', null, jNode);
            var eNode = new FirstChildNextSiblingNode<char>('E', iNode);
            var hNode = new FirstChildNextSiblingNode<char>('H');
            var dNode = new FirstChildNextSiblingNode<char>('D', hNode, eNode);
            var cNode = new FirstChildNextSiblingNode<char>('C', null, dNode);
            var gNode = new FirstChildNextSiblingNode<char>('G');
            var fNode = new FirstChildNextSiblingNode<char>('F', null, gNode);
            var bNode = new FirstChildNextSiblingNode<char>('B', fNode, cNode);
            var aNode = new FirstChildNextSiblingNode<char>('A', bNode);

            var tree = new FirstChildNextSiblingTreePrintable<char>(aNode);

            Console.WriteLine(tree);
            Console.WriteLine($"Size: {tree.GetSize()}");
        }
    }

    public class FirstChildNextSiblingTreePrintable<T> : FirstChildNextSiblingTree<T>
    {
        public FirstChildNextSiblingTreePrintable(FirstChildNextSiblingNode<T> root) : base(root)
        {}

        public int GetSize()
        {
            return GetSize(Root);
        }

        private int GetSize(FirstChildNextSiblingNode<T> node)
        {
            var retVal = 1;
            if (node.FirstChild != null)
            {
                retVal += GetSize(node.FirstChild);
            }
            if (node.NextSibling != null)
            {
                retVal += GetSize(node.NextSibling);
            }

            return retVal;
        }

        public override string ToString()
        {
            return GetPreOrder(Root);
        }

        private string GetPreOrder(FirstChildNextSiblingNode<T> node)
        {
            var sb = new StringBuilder();
            if (node != null)
            {
                sb.Append(node.Data);
                if (node.FirstChild != null)
                {
                    sb.Append(GetPreOrder(node.FirstChild));
                }
                if (node.NextSibling != null)
                {
                    sb.Append(GetPreOrder(node.NextSibling));
                }
            }

            return sb.ToString();
        }
    }
}