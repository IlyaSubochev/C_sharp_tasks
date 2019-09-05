using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

    public class DynArray<T>
    {
        public T[] array;
        public int count;
        public int capacity;

        public DynArray()
        {
            count = 0;
            MakeArray(16);
        }

        public void MakeArray(int new_capacity)
        {
            if (array != null)
                capacity = array.Length;
            else
                capacity = 16;
            if (new_capacity <= 16)
                capacity = 16;
            else if (capacity < new_capacity)
            {
                while (capacity < new_capacity)
                    capacity = capacity * 2;
            }
            else
                capacity = new_capacity;
            if (array != null)
            {
                T[] NewArray = new T[capacity];
                Array.Copy(array, 0, NewArray, 0, count);
                array = NewArray;
            }
            else
                array = new T[capacity];

        }

        public T GetItem(int index)
        {
            if (index < count)
                return array[index];
            else
                throw new IndexOutOfRangeException();
        }

        public void Append(T itm)
        {
            if (capacity == count)
            {
                MakeArray(capacity*2);
            }
            array[count] = itm;
            count++;
        }

        public void Insert(T itm, int index)
        {
            if (count == index )
            {
               Append(itm);
            }
            else if (index < count)
            {
                if (count == capacity)
                    MakeArray(capacity * 2);
                Array.Copy(array, index, array, index + 1, count - index);
                array[index] = itm;
                count++;
            }
            else
                throw new IndexOutOfRangeException();           
        }

        public void Remove(int index)
        {
            if (index < count)
            {
                T[] NewArray = new T[capacity];
                Array.Copy(array, 0, NewArray, 0, index);                
                Array.Copy(array, index+1, NewArray, index, count - index-1);
                array = NewArray;
                count--;
                if ((count * 100 / capacity) < 50 && capacity > 16)
                    MakeArray(capacity * 2 / 3);
            }
             else if (index >= count || count == 0)
                 throw new IndexOutOfRangeException();
                    
        }

    }
}
