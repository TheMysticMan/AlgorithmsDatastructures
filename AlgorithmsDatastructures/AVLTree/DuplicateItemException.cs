using System;

namespace AVLTree
{

    internal class DuplicateItemException : Exception
    {
        public DuplicateItemException(IComparable data)
        {
            throw new NotImplementedException();
        }
    }

}