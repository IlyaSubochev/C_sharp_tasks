using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsDataStructures2
{
    public class BSTNode<T>
    {
        public int NodeKey; // ключ узла
        public T NodeValue; // значение в узле
        public BSTNode<T> Parent; // родитель или null для корня
        public BSTNode<T> LeftChild; // левый потомок
        public BSTNode<T> RightChild; // правый потомок
        public BSTNode(int key, T val, BSTNode<T> parent)
        {
            NodeKey = key;
            NodeValue = val;
            Parent = parent;
            LeftChild = null;
            RightChild = null;
        }
    }
    // промежуточный результат поиска
    public class BSTFind<T>
    {
        // null если в дереве вообще нету узлов
        public BSTNode<T> Node;

        // true если узел найден
        public bool NodeHasKey;

        // true, если родительскому узлу надо добавить новый левым
        public bool ToLeft;

        public BSTFind() { Node = null; }
    }
    public class BST<T>
    {
        BSTNode<T> Root; // корень дерева, или null
        public BST(BSTNode<T> node)
        {
            Root = node;
        }
        public BSTFind<T> FindNodeByKey(int key) // ищем в дереве узел и сопутствующую информацию по ключу
        {
            if (Root != null)
            {
                BSTFind<T> bst_find = new BSTFind<T>();
                if (Root.LeftChild != null || Root.RightChild != null)
                    return FindNodeByKey(key, Root, bst_find);
                bst_find.Node = Root;
                bst_find.NodeHasKey = Root.NodeKey == key;
                bst_find.ToLeft = Root.NodeKey > key;
                return bst_find;
            }
            return null;
        }

        private BSTFind<T> FindNodeByKey(int key, BSTNode<T> node, BSTFind<T> bst_find)
        {
            bst_find.Node = node;
            if (node.NodeKey > key)
            {
                if (node.LeftChild != null) return FindNodeByKey(key, node.LeftChild, bst_find);
                bst_find.ToLeft = true;
                return bst_find;
            }
            else
            {
                if (node.NodeKey == key) bst_find.NodeHasKey = true;
                else if (node.RightChild != null) return FindNodeByKey(key, node.RightChild, bst_find);
                return bst_find;
            }
        }
        public bool AddKeyValue(int key, T val) // добавляем ключ-значение в дерево, return false если ключ уже есть
        {
            if (Root == null)
            {
                Root = new BSTNode<T>(key, val, null);
                return true;
            }
            BSTFind<T> bst_find = FindNodeByKey(key);
            if (bst_find.Node != null && !bst_find.NodeHasKey)
            {
                if (bst_find.ToLeft) bst_find.Node.LeftChild = new BSTNode<T>(key, val, bst_find.Node);
                else bst_find.Node.RightChild = new BSTNode<T>(key, val, bst_find.Node);
                return true;
            }
            else if (bst_find.Node == null)
            {
                if (bst_find.ToLeft) Root.LeftChild = new BSTNode<T>(key, val, Root);
                else Root.RightChild = new BSTNode<T>(key, val, Root);
                return true;
            }
            return false;
        }
        public BSTNode<T> FinMinMax(BSTNode<T> FromNode, bool FindMax) // ищем максимальный/минимальный ключ в поддереве
        {
            BSTNode<T> MinMax = FromNode;

            if (MinMax != null)
            {
                if (FindMax)
                    while (MinMax.RightChild != null)
                        MinMax = MinMax.RightChild;
                else
                    while (MinMax.LeftChild != null)
                        MinMax = MinMax.LeftChild;

                return MinMax;
            }
            return null;
        }
        public bool DeleteNodeByKey(int key) // удаляем узел по ключу, return false если узел не найден
        {
            BSTFind<T> bst_find = FindNodeByKey(key);

            if (bst_find.NodeHasKey)
            {
                if (bst_find.Node.Equals(Root)) Root = null;
                else
                {
                    BSTNode<T> node = bst_find.Node;
                    BSTNode<T> inheritor;
                    if (node.RightChild != null)
                    {
                        inheritor = Find(node.RightChild);
                        Remove(inheritor);
                        RebindChild(node, inheritor);
                        ReplaceNode(node, inheritor);
                    }
                    else if (node.LeftChild != null)
                        ReplaceNode(node, node.LeftChild);
                    else if (node.NodeKey < node.Parent.NodeKey) node.Parent.LeftChild = null;
                    else node.Parent.RightChild = null;
                }
                return true;
            }
            return false;
        }

        private BSTNode<T> Find(BSTNode<T> node)
        {
            while (node.LeftChild != null)
                node = node.LeftChild;
            return node;
        }

        private void ReplaceNode(BSTNode<T> child, BSTNode<T> new_child)
        {
            if (child.Parent != null)
            {
                if (child.NodeKey < child.Parent.NodeKey) child.Parent.LeftChild = new_child;
                else child.Parent.RightChild = new_child;
                new_child.Parent = child.Parent;
            }
            else
            {
                Root = new_child;
                Root.Parent = null;
            }
        }

        private void RebindChild(BSTNode<T> node, BSTNode<T> inheritor)
        {
            if (node.LeftChild != null && !node.LeftChild.Equals(inheritor))
            {
                inheritor.LeftChild = node.LeftChild;
                node.LeftChild.Parent = inheritor;
            }
            if (node.RightChild != null && !node.RightChild.Equals(inheritor))
            {
                inheritor.RightChild = node.RightChild;
                node.RightChild.Parent = inheritor;
            }
        }

        private void Remove(BSTNode<T> node)
        {
            if (node.NodeKey < node.Parent.NodeKey) node.Parent.LeftChild = node.RightChild;
            else node.Parent.RightChild = node.RightChild;
            if (node.RightChild != null && !node.Parent.LeftChild.Equals(node))
                node.RightChild.Parent = node.Parent;
        }

        private int CountNodes(BSTNode<T> node)
        {
            if (node != null)
                return CountNodes(node.LeftChild) + CountNodes(node.RightChild) + 1;
            return 0;
        }
        public int Count() // количество узлов в дереве
        {
            if (Root != null)
                return CountNodes(Root.RightChild) + CountNodes(Root.LeftChild) + 1;
            return 0;
        }

        public List<BSTNode<T>> WideAllNodes()
        {
            List<BSTNode<T>> list = new List<BSTNode<T>>();
            if (Root != null)
            {
                list.Add(Root);
                return WideCollectNodes(list);
            }
            return list;
        }

        private List<BSTNode<T>> WideCollectNodes(List<BSTNode<T>> list)
        {
            List<BSTNode<T>> list2 = new List<BSTNode<T>>();
            foreach (BSTNode<T> node in list)
            {
                if (node.LeftChild != null)
                    list2.Add(node.LeftChild);
                if (node.RightChild != null)
                    list2.Add(node.RightChild);
            }
            if (list2.Count != 0) list.AddRange(WideCollectNodes(list2));
            return list;
        }

        public List<BSTNode<T>> DeepAllNodes(int mode)
        {
            List<BSTNode<T>> list = new List<BSTNode<T>>();
            if (Root != null)
            {
                if (mode == 0)
                {
                    InOrder(list, FinMinMax(Root, false));
                }
                else if (mode == 1)
                {
                    PostOrder(list, Root);
                }
                else if (mode == 2)
                {
                    PreOrder(list, Root);
                }
            }

            return list;
        }

        private void InOrder(List<BSTNode<T>> list, BSTNode<T> node)
        {
            list.Add(node);
            if (node.RightChild != null) InOrder(list, FinMinMax(node.RightChild, false));
            if (node.Parent != null && node.Parent.NodeKey > node.NodeKey) InOrder(list, node.Parent);
        }

        private void PostOrder(List<BSTNode<T>> list, BSTNode<T> node)
        {
            if (node.LeftChild != null)
                PostOrder(list, node.LeftChild);
            if (node.RightChild != null)
                PostOrder(list, node.RightChild);
            list.Add(node);
        }

        private void PreOrder(List<BSTNode<T>> list, BSTNode<T> node)
        {
            list.Add(node);
            if (node.LeftChild != null)
                PreOrder(list, node.LeftChild);
            if (node.RightChild != null)
                PreOrder(list, node.RightChild);
        }
        
    }
}
