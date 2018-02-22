using System;
using System.Collections.Generic;
using System.Text;

namespace FilesSerializer
{
    [Serializable]
    class TreeNode<T>
    {
        List<TreeNode<T>> Children;

        T Item { get; set; }

        public TreeNode(T item)
        {
            Item = item;
            Children = new List<TreeNode<T>>();
        }

        public TreeNode<T> AddChild(T item)
        {
            TreeNode<T> nodeItem = new TreeNode<T>(item);
            Children.Add(nodeItem);
            return nodeItem;
        }

        public T GetNode()
        {
            return Item;
        }

        public List<TreeNode<T>> GetChildren()
        {
            return Children;
        }
    }
}
