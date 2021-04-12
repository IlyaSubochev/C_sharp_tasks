using System;
using System.Collections.Generic;

namespace SortSpace
{
    public static class SortLevel
    {
        #region 1. Сортировка (базовое)
        public static void SelectionSortStep(int[] array, int i) // Сортировка выбором
        {
            if (i < array.Length - 1)
            {
                int m = MinElement(array, i + 1);
                if (array[m] < array[i])
                    SwapElements(array, i, m);
            }
        }
        
        public static int MinElement(int[] array, int i) // Находит наименьший элемент массива.
        {
            int minimum = i;
            for (; i < array.Length; i++)
                if (array[i] < array[minimum]) 
                    minimum = i;
            return minimum;
        }
       
        public static bool SwapElements(int[] array, int i, int j) // Меняет два элемента массива местами.
        {
            if (i == j) 
                return true;
            array[i] += array[j];
            array[j] = array[i] - array[j];
            array[i] = array[i] - array[j];
            return true;
        }
        public static bool BubbleSortStep(int[] array) // Сортировка пузырьком для одного шага
        {
            return BubbleSortCycle(array, 0);
        }

     
        public static bool BubbleSortCycle(int[] array, int i)   // Функция возвращает true, если по окончании пробега не было ни одного обмена элементов
        {
            if (i + 1 == array.Length) 
                return true;
            if (Compare(array[i], array[i + 1]) && SwapElements(array, i, i + 1)) 
                return BubbleSortCycle(array, i + 1) && false;
            return BubbleSortCycle(array, i + 1);
        }
   
        public static bool Compare(int a, int b) // Сравнение двух целочисленных значений.Возвращает true если первый аргумент больше второго.
        {
            return a > b;
        }
        #endregion

        #region 2. Сортировка вставками

        // вызов InsertionSortStep( [1,6,5,4,3,2,7], 3, 1 ) изменит входной массив на [1,3,5,4,6,2,7]
        public static void InsertionSortStep(int[] array, int t, int i)
        {
            if (t <= 0) return;
            InsertionSortCycle(array, t, i);
        }

        public static bool InsertionSortCycle(int[] array, int t, int i)
        {
            if (i + t >= array.Length) 
                return true;
            if (Compare(array[i], array[i + t]) && SwapElements(array, i, i + t)) 
                return InsertionSortCycle(array, t, i + t) && false;
            return InsertionSortCycle(array, t, i + t);
        }
        #endregion

        #region 3. Сортировка Шелла

        #endregion
    }
}
