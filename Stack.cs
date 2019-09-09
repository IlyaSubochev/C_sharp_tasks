using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

    internal class Stack<T>
    {
        private int size;
        private List<T> data;

        public Stack()
        {
            data = new List<T>();
            size = 0;
        }

        public int Size()
        {
            return size;
        }

        public T Pop()
        {
            if (size == 0)
            {
                return default(T); // null, если стек пустой
            }
            else
            {
                var item = Peek();
                data.Remove(item);
                size--;
                return item;
            }
        }

        public void Push(T val)
        {
            data.Add(val);
            size++;
        }

        public T Peek()
        {
            if (size == 0)
            {
                return default(T); // null, если стек пустой
            }
            else
                return data[size - 1];
        }

       
    }

}

