namespace TreeFCNS
{

    public class FirstChildNextSiblingTree<T>
    {
        public FirstChildNextSiblingNode<T> Root { get; set; }

        public FirstChildNextSiblingTree(FirstChildNextSiblingNode<T> root)
        {
            Root = root;
        }
    }

}