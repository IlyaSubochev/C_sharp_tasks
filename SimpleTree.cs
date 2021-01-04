using System;
using System.Collections.Generic;
namespace AlgorithmsDataStructures
{
    public class SimpleTreeNode<T>
    {
        public T NodeValue; // значение в узле
        public SimpleTreeNode<T> Parent; // родитель или null для корня
        public List<SimpleTreeNode<T>> Children; // список дочерних узлов или null
        public int layer;
        public SimpleTreeNode(T val, SimpleTreeNode<T> parent)
            {
                NodeValue = val;
                Parent = parent;
                Children = null;
            }
    }
    public class SimpleTree<T>
    {
        public SimpleTreeNode<T> Root; // корень, может быть null
        public SimpleTree(SimpleTreeNode<T> root)
        {
            Root = root;
        }
        public void AddChild(SimpleTreeNode<T> ParentNode, SimpleTreeNode<T> NewChild)  // код добавления нового дочернего узла существующему ParentNode
        {
            if (Root == null)
            {
                Root = NewChild;
                Root.layer = 1;
            }
            else
            {
                if (ParentNode.Children == null) 
                    ParentNode.Children = new List<SimpleTreeNode<T>>();
                ParentNode.Children.Add(NewChild);
                NewChild.Parent = ParentNode;
                NewChild.layer = NewChild.Parent.layer + 1;
            }
        }
        public void DeleteNode(SimpleTreeNode<T> NodeToDelete)  //  код удаления существующего узла NodeToDelete
        {
            if (NodeToDelete.Parent == null) 
                Root = null;
            else if (NodeToDelete.Parent.Children.Count == 1) 
                NodeToDelete.Parent.Children = null;
            else NodeToDelete.Parent.Children.Remove(NodeToDelete);
        }
        public List<SimpleTreeNode<T>> GetAllNodes()  // код выдачи всех узлов дерева в определённом порядке
        {
            if (Root != null)
            {
                List<SimpleTreeNode<T>> list = new List<SimpleTreeNode<T>>();
                list = AllNodes(list, Root);
                return list;
            }
            return new List<SimpleTreeNode<T>>();
        }

        private List<SimpleTreeNode<T>> AllNodes(List<SimpleTreeNode<T>> list, SimpleTreeNode<T> node)
        {
            list.Add(node);
            if (node.Children != null)
                foreach (SimpleTreeNode<T> child in node.Children)
                    list = AllNodes(list, child);
            if (list.Count > 0) 
                return list;
            return null;
        }
        public List<SimpleTreeNode<T>> FindNodesByValue(T val) // код поиска узлов по значению
        {
            if (Root != null)
            {
                List<SimpleTreeNode<T>> list = new List<SimpleTreeNode<T>>();
                list = NodesByValue(list, Root, val);
                return list;
            }
            return new List<SimpleTreeNode<T>>();
        }

        private List<SimpleTreeNode<T>> NodesByValue(List<SimpleTreeNode<T>> list, SimpleTreeNode<T> node, T val)
        {
            if (node.NodeValue != null && node.NodeValue.Equals(val)) 
                list.Add(node);
            if (node.Children != null)
                foreach (SimpleTreeNode<T> child in node.Children)
                    list = NodesByValue(list, child, val);
            return list;
        }

        public void MoveNode(SimpleTreeNode<T> OriginalNode, SimpleTreeNode<T> NewParent)  //код перемещения узла вместе с его поддеревом -- в качестве дочернего для узла NewParent
        {
            DeleteNode(OriginalNode);
            AddChild(NewParent, OriginalNode);
        }

        public int Count() // количество всех узлов в дереве
        {
            if (Root != null)
                return Count2(Root.Children) + 1;
            return 0;
        }

        private int Count2(List<SimpleTreeNode<T>> list) 
        {
            if (list != null)
            {
                int count = list.Count;
                foreach (SimpleTreeNode<T> node in list)
                    if (node.Children != null) 
                        count += Count2(node.Children);
                return count;
            }
            return 0;
        }

        public int LeafCount() // количество листьев в дереве
        {
            if (Root != null)
                return LeafCount2(Root.Children);
            return 0;
        }
        private int LeafCount2(List<SimpleTreeNode<T>> list) 
        {
            if (list != null)
            {
                int count = 0;
                foreach (SimpleTreeNode<T> child in list)
                    count += LeafCount2(child.Children);
                return count;
            }
            return 1;
        }

        public void WriteLayer() //записываем каждому узлу его уровень
        {
            if (Root != null)
            {
                Root.layer = 1;
                if (Root.Children != null) 
                    WriteNextLayer(Root);
            }
        }

        private void WriteNextLayer(SimpleTreeNode<T> node)
        {
            if (node.Children != null)
            {
                foreach (SimpleTreeNode<T> child in node.Children)
                {
                    child.layer = node.layer + 1;
                    WriteNextLayer(child);
                }
            }
        }
    }
}
