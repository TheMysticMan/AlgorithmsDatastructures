namespace TreeFCNS
{

    public class FirstChildNextSiblingNode<T>
    {
        public T Data { get; set; }
        public FirstChildNextSiblingNode<T> FirstChild { get; set; }

        public FirstChildNextSiblingNode<T> NextSibling { get; set; }

        public FirstChildNextSiblingNode(T data)
        {
            Data = data;
        }

        public FirstChildNextSiblingNode(T data, FirstChildNextSiblingNode<T> child)
        {
            Data = data;
            FirstChild = child;
        }

        public FirstChildNextSiblingNode(T data, FirstChildNextSiblingNode<T> child, FirstChildNextSiblingNode<T> sibling)
        {
            Data = data;
            FirstChild = child;
            NextSibling = sibling;
        }
    }

}