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
            if (t <= 0)
                return;
            if (!InsertionSortCycle(array, t, i))
                InsertionSortStep(array, t, i);
        }

        public static bool InsertionSortCycle(int[] array, int t, int i)
        {
            if (i + t >= array.Length) 
                return true;
            if (Compare(array[i], array[i + t]) && SwapElements(array, i, i + t))
                return InsertionSortCycle(array, t, i + t) && false;
            return  InsertionSortCycle(array, t, i + t);
        }
        
        #endregion

        #region 3. Сортировка Шелла

        public static List<int> KnuthSequence(int array_size) // Создает лист числовых значений в порядке убывания последовательностью Кнута
        {
            List<int> list = new List<int>();
            int t = KnuthNextStep(1, array_size);
            for (; t >= 1; t = KnuthPrestep(t))
                list.Add(t);
            return list;
        }

        public static int KnuthNextStep(int t, int s) // Вычисляет максимальный размер шага для массива s, в соответствии с последовательностью Кнута
        {
            if (KnuthStep(t) > s) 
                return t;
            t = KnuthStep(t);
            return KnuthNextStep(t, s);
        }

        public static int KnuthStep(int t)
        {
            return 3 * t + 1;
        }

        public static int KnuthPrestep(int t)
        {
            return (t - 1) / 3;
        }
        #endregion
            
        #region 4. Алгоритм разбиения массива

        public static int ArrayChunk(int[] M)
        {
            return ArrayChunkStep1(M, 0, M.Length - 1);
        }

        public static int ArrayChunkStep1(int[] M, int i1, int i2) // Алгоритм разбиения шаг 1
        {
            while (true)
            {
                int n = ArrayChunkStep2(M, M[(i1 + i2 + 1) / 2], (i1 + i2 + 1) / 2, i1, i2);
                if (n > -1) 
                    return n;
            }
        }

        public static int ArrayChunkStep2(int[] M, int N, int n, int i1, int i2) // Алгоритм разбиения шаг 2
        {
            if (IsDiff(i1, i2) && IsBigger(M[i1], M[i2]) && SwapElements(M, i1, i2))
                return -1;

            if (IsEqual(i1, i2) || (IsDiff(i1, i2) && IsLess(M[i1], M[i2])))
                return n;

            while (M[i1] < N || M[i2] > N)
            {
                if (M[i1] < N) 
                    i1++;
                if (M[i2] > N) 
                    i2--;
            }

            if (!IsDiff(i1, i2))
            {
                SwapElements(M, i1, i2);
                n = UpdateIndex(n, i1, i2);
            }
            return ArrayChunkStep2(M, N, n, i1, i2);
        }

        public static bool IsLess(int i, int n) // true Если значение меньше другого
        {
            return i < n;
        }

        public static bool IsBigger(int i, int n) // true Если значение больше другого
        {
            return i > n;
        }

        
        public static bool IsDiff(int a, int b) // true если у значений разница в 1
        {
            return a == b - 1;
        }

        public static bool IsEqual(int a, int b) // true если значения равны
        {
            return a == b;
        }

        public static int UpdateIndex(int n, int i1, int i2)
        {
            if (i1 == n) 
                return i2;
            else if (i2 == n) 
                return i1;
            else 
                return n;
        }
        #endregion
            
        #region 5. Быстрая сортировка Хоара

        public static void QuickSort(int[] array, int left, int right) // Алгоритм быстрой сортировки массива
        {
            if (left == right) 
                return;
            int n = ArrayChunkStep1(array, left, right);
            if (!(n <= left)) 
                QuickSort(array, left, n - 1);
            if (!(n >= right)) 
                QuickSort(array, n + 1, right);
        }

        #endregion
            
        #region 6. Элиминация хвостовой рекурсии

        public static void QuickSortTailOptimization(int[] array, int left, int right) 
        {
            if (left == right) 
                return;
            
            int i1 = left; 
            int i2 = right;

            if (left < right)
            {
                int n = ArrayChunkStep1(array, i1, i2);
                if (left < i2)
                    QuickSortTailOptimization(array, i1, n-1);
                if (right > i1)
                    QuickSortTailOptimization(array, n + 1, i2);
            }           
        }

        #endregion

        #region 7. Поиск порядковых статистик

        public static List<int> KthOrderStatisticsStep(int[] array, int L, int R, int k)
        {
            int order = ArrayChunkStep1(array, L, R);
            List<int> list = new List<int>();
            if (order == k)
            {
                list.Add(order);
                list.Add(k);
            }
            else if (order < k)
            {
                list.Add(order + 1);
                list.Add(R);
            }
            else
            {
                list.Add(L);
                list.Add(order - 1);
            }
            return list;
        }

        #endregion            
        
        #region 8. Сортировка слиянием(Merge-Sort)
            
        public static List<int> MergeSort(List<int> list)
        {
            if (list.Count == 1) return list;

            List<int> listA = new List<int>();
            List<int> listB = new List<int>();
            for (int i = 0; i < (list.Count + 1) / 2; i++) 
                listA.Add(list[i]);
            for (int i = (list.Count + 1) / 2; i < list.Count; i++) 
                listB.Add(list[i]);

            List<int> list1 = MergeSort(listA);
            List<int> list2 = MergeSort(listB);
            return MergeArray(list1, list2);
        }

        public static List<int> MergeArray(List<int> list1, List<int> list2)
        {
            List<int> result = new List<int>();

            while (true)
            {
                if (list1.Count == 0 && list2.Count != 0)
                {
                    foreach (int num in list2) 
                        result.Add(num);
                    break;
                }
                else if (list1.Count != 0 && list2.Count == 0)
                {
                    foreach (int num in list1) 
                        result.Add(num);
                    break;
                }
                else if (list1.Count == 0 && list2.Count == 0) 
                    break;

                if (list1[0] >= list2[0])
                {
                    result.Add(list2[0]);
                    list2.Remove(list2[0]);
                }
                else
                {
                    result.Add(list1[0]);
                    list1.Remove(list1[0]);
                }
            }
            return result;
        }

        #endregion           
    }
}
