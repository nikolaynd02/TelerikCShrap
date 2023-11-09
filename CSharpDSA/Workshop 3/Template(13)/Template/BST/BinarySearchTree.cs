using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Xml.Linq;

namespace BST
{
    public class BinarySearchTree<T> : IBinarySearchTree<T> where T : IComparable<T>
    {
        private BinarySearchTree<T> left;
        private BinarySearchTree<T> right;

        public BinarySearchTree(T value)
        {
            this.Value = value;
            this.left = null;
            this.right = null;
        }

        public T Value
        {
            get;
            private set;
        }

        public IBinarySearchTree<T> Left
        {
            get {  return left; }
        }

        public IBinarySearchTree<T> Right
        {
            get { return right; }
        }

        public int Height
        {
            get { return HeightHelper(this) - 1; }
        }

        private int HeightHelper(BinarySearchTree<T> node)
        {
            if (node == null)
            {
                return 0;
            }
            else
            {

                // Compute height of each subtree
                int lheight = HeightHelper(node.left);
                int rheight = HeightHelper(node.right);

                // use the larger one
                if (lheight > rheight)
                {
                    return (lheight + 1);
                }
                else
                {
                    return (rheight + 1);
                }
            }
        }

        public IList<T> GetInOrder()
        {
            Stack<BinarySearchTree<T>> stack = new Stack<BinarySearchTree<T>>();

            var currentNode = this;

            var result = new List<T>();

            do
            {
                while (currentNode != null)
                {
                    stack.Push(currentNode);
                    currentNode = currentNode.left;
                }

                var temp = stack.Pop();
                result.Add(temp.Value);
                currentNode = temp.right;

            }
            while (currentNode != null || stack.Count != 0);

            return result;
        }

        public IList<T> GetPostOrder()
        {
            var result = new List<T>();
            GetPostOrderHelp(this ,result);
            return result;
        }

        private void GetPostOrderHelp(BinarySearchTree<T> node, List<T> result)
        {
            if(node.left != null)
            {
                GetPostOrderHelp(node.left, result);
            }

            if(node.right != null)
            {
                GetPostOrderHelp(node.right, result);
            }
            result.Add(node.Value);
        }

        public IList<T> GetPreOrder()
        {
            var result = new List<T>();
            GetPreOrderHelp(this, result);
            return result;
        }

        private void GetPreOrderHelp(BinarySearchTree<T> node, List<T> result)
        {
            result.Add(node.Value);
            if (node.left != null)
            {
                GetPreOrderHelp(node.left, result);
            }

            if (node.right != null)
            {
                GetPreOrderHelp(node.right, result);
            }
        }

        public IList<T> GetBFS()
        {
            var result = new List<T>();
            for(int i = 1; i <= Height + 1; i++)
            {
                GetBFSHelp(this, result, i); 
            }
            return result;
        }

        private void GetBFSHelp(BinarySearchTree<T> node, List<T> result, int level)
        {
            if (node == null)
            {
                return;
            }
            if (level == 1)
            {
                result.Add(node.Value);
            }
            else if (level > 1)
            {
                GetBFSHelp(node.left, result, level - 1);
                GetBFSHelp(node.right, result, level - 1);
            }

        }

        public void Insert(T element)
        {
             PrivateInsert(element, this);
        }

        private BinarySearchTree<T> PrivateInsert(T element, BinarySearchTree<T> root)
        {
            if(root == null)
            {
                root = new BinarySearchTree<T>(element);
                return root;
            }

            int compareRes = element.CompareTo(root.Value);

            if( compareRes < 0 )
            {
                root.left = PrivateInsert(element, root.left);
            }
            else
            {
                root.right = PrivateInsert(element, root.right);
            }

            return root;
        }

        public bool Search(T element)
        {
            return GetInOrder().Contains(element);
        }

        // Advanced task!
        public bool Remove(T value)
        {
            if (RemoveHelper(this, value).Value.Equals(value)) 
            {
                return true;
            } 
            return false;
        }

        private BinarySearchTree<T> RemoveHelper(BinarySearchTree<T> node, T value)
        {
            // Base case
            if (node == null)
                return node;

            // Recursive calls for ancestors of
            // node to be deleted
            int compareRes = node.Value.CompareTo(value);
            if (compareRes > 0)
            {
                node.left = RemoveHelper(node.left, value);
                return node;
            }
            else if (compareRes < 0)
            {
                node.right = RemoveHelper(node.right, value);
                return node;
            }

            // We reach here when root is the node
            // to be deleted.

            // If one of the children is empty
            if (node.left == null)
            {
                var temp = node.right;
                node = null;
                return temp;
            }
            else if (node.right == null)
            {
                var temp = node.left;
                node = null;
                return temp;
            }

            // If both children exist
            else
            {

                var succParent = node;

                // Find successor
                var succ = node.right;
                while (succ.left != null)
                {
                    succParent = succ;
                    succ = succ.left;
                }

                // Delete successor.  Since successor
                // is always left child of its parent
                // we can safely make successor's right
                // right child as left of its parent.
                // If there is no succ, then assign
                // succ.right to succParent.right
                if (succParent != node)
                    succParent.left = succ.right;
                else
                    succParent.right = succ.right;

                // Copy Successor Data to root
                node.Value = succ.Value;

                // Delete Successor and return root
                succ = null;
                return node;
            }
        }
    }
}
