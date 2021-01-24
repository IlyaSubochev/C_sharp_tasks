using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures2
{
    public class aBST
    {
        public int?[] Tree; // массив ключей
        public aBST(int depth) // правильно рассчитайте размер массива для дерева глубины depth:
        {
            depth = 1 << (depth);
            int tree_size = depth | (depth - 1);
            if (tree_size < 0) tree_size = 0;
            Tree = new int?[tree_size];
            for (int i = 0; i < tree_size; i++) 
                Tree[i] = null;
        }
        public int? FindKeyIndex(int key) // ищем в массиве индекс ключа return null; // не найден
        {
            int index = 0;
            while (index < Tree.Length)
            {
                if (Tree[index] == null) 
                    return -index;
                if (Tree[index] == key) 
                    return index;
                else if (Tree[index] > key) 
                    index = index * 2 + 1;
                else 
                    index = index * 2 + 2;
            }
            return null; 
        }
        public int AddKey(int key) // добавляем ключ в массив // return индекс добавленного/существующего ключа или -1 если не удалось
        {
            int index = 0;
            while (index < Tree.Length)
            {
                if (Tree[index] == null)
                {
                    Tree[index] = key;
                    return index;
                }
                if (Tree[index] == key)
                    return index;
                else if (Tree[index] > key)
                    index = index * 2 + 1;
                else 
                    index = index * 2 + 2;
            }
            return -1;
            
        }
    }
}
