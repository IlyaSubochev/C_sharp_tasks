using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

    class Deque<T>
    {
        public T[] array;
        public int size;
        public int head;
        public int tail;
        public int capacity;

        public Deque()
        {
            MakeArray(16);
            size = 0;
            capacity = 16;          
        }

        public void AddFront(T item)
        {
            if (size == array.Length)
                MakeArray(2 * capacity);
            if (head > 0)
            {
                head--;
            }
            else
            {
                head = 0;
                T[] NewArray = new T[capacity];
                Array.Copy(array, head, NewArray, 1, size);
                array = NewArray;
            }           
            array[head] = item;
            tail++;
            size++;
            if (size == 1)
            {
                tail = head;
            }
        }

        public void AddTail(T item)
        {
            if (size == array.Length)
                MakeArray(2 * capacity);
            if (tail == array.Length - 1)
            {
                tail = 0;
            }
            else
            {
                tail++;
            }

            array[tail] = item;
            size++;

            if (size == 1)
            {
                head = tail;
            }
           
        }

        public T RemoveFront()
        {
            if (size == 0)
            {
                return default(T);
            }
            T value = array[head];
            array[head] = default(T);
            if (head == array.Length - 1)
            {
                head = 0;
            }
            else
            {
                head++;
            }
            size--;
            if (size == 0)
            {
                tail = 0;
                head = 0;
            }
            else if (size == 1)
                head = tail;
            return value;            
        }

        public T RemoveTail()
        {
            if (size == 0)
            {
                return default(T);
            }
            T value = array[tail];
            array[tail] = default(T);
            if (tail == 0)
            {
                tail = array.Length - 1;
            }
            else
            {
                tail--;
            }
            size--;
            if (size == 0)
            {
                tail = 0;
                head = 0;
            }
            else if (size == 1)
                tail = head;
            return value;            
        }

        public int Size()
        {
            return size;
        }

        public void MakeArray(int new_capacity)
        {
            T[] NewArray = new T[new_capacity];
            if (size > 0)
            {
                if (head < tail)
                {
                    Array.Copy(array, head, NewArray, 0, size);
                }
                else
                {
                    Array.Copy(array, head, NewArray, 0, array.Length - head);
                    Array.Copy(array, 0, NewArray, array.Length - head, tail + 1);
                }
            }
            array = NewArray;
            head = 0;
            if (size == capacity)
                tail = size - 1;
            else
                tail = 0;
            capacity = new_capacity;
        }
    }

}
