using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

    public class Queue<T>
    {
        public T[] array;
        public int size;
        public int head;
        public int tail;
        public int capacity;

        public Queue()
        {
            MakeArray(16) ;
            size = 0;
            head = 0;
            tail = -1;
            capacity = 16;
        }

        public void Enqueue(T item)
        {
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

        public T Dequeue()
        {
            if (size == 0)
            {
                return default(T);
            }

            T value = array[tail];

            if (tail == 0)
            {
               
                tail = array.Length - 1;
            }
            else
            {
                
                tail--;
            }
            
            size--;
            array[size] = default(T);
            return value;

          
        }

        public int Size()
        {
            return size;
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
                Array.Copy(array, 0, NewArray, 0, size);
                array = NewArray;
            }
            else
                array = new T[capacity];

        }

    }
}

