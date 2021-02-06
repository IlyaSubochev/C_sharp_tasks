using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmsDataStructures2
{
	public class BSTNode
	{
		public int NodeKey; // ключ узла
		public BSTNode Parent; // родитель или null для корня
		public BSTNode LeftChild; // левый потомок
		public BSTNode RightChild; // правый потомок	
		public int Level; // глубина узла

		public BSTNode(int key, BSTNode parent)
		{
			NodeKey = key;
			Parent = parent;
			LeftChild = null;
			RightChild = null;
		}
	}


	public class BalancedBST
	{
		public BSTNode Root; // корень дерева

		public BalancedBST()
		{
			Root = null;
		}

		public void GenerateTree(int[] a) // создаём дерево с нуля из неотсортированного массива a
		{
			int[] BSTArray = CreateBSTArray(a);
			if (BSTArray.Length > 0)
			{
				Root = new BSTNode(BSTArray[BSTArray.Length / 2], null);
				Root.Level = 1;
				Root.LeftChild = CreateChild(CutArray(BSTArray, false), Root);
				Root.RightChild = CreateChild(CutArray(BSTArray, true), Root);
			}

		}

		public static int[] CreateBSTArray(int[] a)
		{

			if (a != null)
			{
				a = a.OrderBy(i => i).ToArray();
				return a;
			}
			return null;
		}

		private BSTNode CreateChild(int[] a, BSTNode parent)
		{
			if (a.Length != 0)
			{
				BSTNode node = new BSTNode(a[a.Length / 2], parent);
				node.Level = parent.Level + 1;
				node.LeftChild = CreateChild(CutArray(a, false), node);
				node.RightChild = CreateChild(CutArray(a, true), node);
				return node;
			}
			return null;
		}

		private int[] CutArray(int[] a, bool rightHalf)
		{
			int[] b = new int[a.Length / 2];
			if (rightHalf) 
				Array.Copy(a, a.Length / 2 + 1, b, 0, b.Length);
			else Array.Copy(a, 0, b, 0, b.Length);
			return b;
		}
		public bool IsBalanced(BSTNode root_node) // сбалансировано ли дерево с корнем root_node
		{
			List<int> depths = new List<int>();
			AddLeafsLevel(depths, root_node);
			int[] levels = depths.ToArray();
			Array.Sort(levels);
			return Math.Abs(levels[0] - levels[levels.Length - 1]) < 2;
		}

		public void AddLeafsLevel(List<int> depths, BSTNode node)
		{
			if (node.LeftChild != null) 
				AddLeafsLevel(depths, node.LeftChild);
			if (node.RightChild != null) 
				AddLeafsLevel(depths, node.RightChild);
			if (node.LeftChild == null || node.RightChild == null) 
				depths.Add(node.Level);
		}

		public bool IsKeyValid(BSTNode parent)
		{
			if (parent == null) 
				return true;
			if (parent.LeftChild != null && parent.LeftChild.NodeKey >= parent.NodeKey) 
				return false;
			if (parent.RightChild != null && parent.RightChild.NodeKey < parent.NodeKey) 
				return false;
			return IsKeyValid(parent.RightChild) && IsKeyValid(parent.LeftChild);
		}
	}
}
