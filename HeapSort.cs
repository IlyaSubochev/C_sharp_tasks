using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortSpace
{
    public class HeapSort
    {
        public Heap HeapObject;

        public HeapSort(int[] array)
        {
            int size = 1;
            while (size <= array.Length) 
                size <<= 1;
            HeapObject = new Heap();
            HeapObject.HeapArray = new int[--size];
            HeapObject.AddInArray(array);
        }

        public int GetNextMax()
        {
            return HeapObject.GetMax();
        }
    }

    public class Heap  // Массив-пирамида манипулирует неотрицательными числами.
    {

        public int[] HeapArray; // хранит неотрицательные числа-ключи

        public Heap() { HeapArray = null; }

        public void MakeHeap(int[] a, int depth) // создаём массив кучи HeapArray из заданного, размер массива выбираем на основе глубины depth
        {
            if (depth > -1)
            {
                HeapArray = new int[(2 << depth) - 1];
                AddInArray(a);
            }
        }

        public void AddInArray(int[] array)
        {
            if (array != null)
                for (int i = 0; i < array.Length; i++)
                    Add(array[i]);
        }

        public int GetMax() // вернуть значение корня и перестроить кучу,  return -1 если куча пуста
        {
            int index = 0;
            if (HeapArray != null && HeapArray[index] != 0)
            {
                int prevMax = HeapArray[0];
                index = LastValueIndex();
                HeapArray[0] = HeapArray[index];
                HeapArray[index] = 0;
                index = 0;

                while (index * 2 + 1 < HeapArray.Length && (HeapArray[index] < HeapArray[index * 2 + 1] || HeapArray[index] < HeapArray[index * 2 + 2]))
                {
                    if (HeapArray[index * 2 + 1] >= HeapArray[index * 2 + 2])
                    {
                        ChangeValuePosition(index, index * 2 + 1);
                        index = index * 2 + 1;
                    }
                    else if (HeapArray[index * 2 + 1] < HeapArray[index * 2 + 2])
                    {
                        ChangeValuePosition(index, index * 2 + 2);
                        index = index * 2 + 2;
                    }
                    else break;
                }
                return prevMax;
            }
            return -1;
        }

        private void ChangeValuePosition(int a, int b) //меняет местами 2 ячейки
        {
            HeapArray[a] += HeapArray[b];
            HeapArray[b] = HeapArray[a] - HeapArray[b];
            HeapArray[a] -= HeapArray[b];
        }

        private int LastValueIndex() //Находит ячейку >0 и возвращает его, в ином случае -1
        {
            int index = HeapArray.Length - 1;
            for (; index > -1 && HeapArray[index] == 0; index--) { }
            return index;
        }

        public bool Add(int key) // добавляем новый элемент key в кучу и перестраиваем её, false если куча вся заполнена
        {
            if (HeapArray == null)
                return false;
            int index = FirstEmptyIndex();
            if (index != -1)
            {
                HeapArray[index] = key;
                SwapKey(index);
                return true;
            }
            return false;
        }

        private int FirstEmptyIndex() //Находит первую ячейку =0, в ином случае -1
        {
            int index = 0;
            for (; index < HeapArray.Length && HeapArray[index] != 0; index++) { }
            if (index >= HeapArray.Length) return -1;
            return index;
        }
       
        private void SwapKey(int index)
        {
            if (index == 0) 
                return;
            if (HeapArray[(index - 1) / 2] < HeapArray[index])
            {
                HeapArray[index] += HeapArray[(index - 1) / 2];
                HeapArray[(index - 1) / 2] = HeapArray[index] - HeapArray[(index - 1) / 2];
                HeapArray[index] -= HeapArray[(index - 1) / 2];
                SwapKey((index - 1) / 2);
            }
        }
    }
}
