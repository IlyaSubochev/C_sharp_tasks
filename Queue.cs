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
            capacity = 16;
        }

        public void Enqueue(T item)
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

        public T Dequeue()
        {
            if (size == 0)
            {
                return default(T);
            }

            T value = array[head];

            if (head == array.Length - 1)
            {

                head = 0;
            }
            else
            {
                array[head] = default(T);
                head++;
                size--;
            }            
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
                    Array.Copy(array, 0, NewArray, array.Length - head, tail+1);
                }
            }
            array = NewArray;
            head = 0;
            if (size == capacity)
                tail = size-1;
            else
                tail = 0;
        }

    }
}

