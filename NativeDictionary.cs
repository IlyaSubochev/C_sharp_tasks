using System;
using System.Collections.Generic;
namespace AlgorithmsDataStructures
{
    public class NativeDictionary<T>
    {
        public int size;
        public string[] slots;
        public T[] values;
        public int isTotal;
        public NativeDictionary(int sz)
        {
            size = sz;
            slots = new string[size];
            values = new T[size];
            isTotal = 0;
        }
        public int HashFun(string key) // всегда возвращает корректный индекс слота
        {
            int hashcode = key.GetHashCode() & 0x7FFFFFFF;
            var slotIndex = hashcode % size;
            int total = isTotal / size;
            if (slots[slotIndex] == null)
                return slotIndex;
            else
            {
                while (total < 1 && slots[slotIndex] != null)
                {
                    slotIndex+=1;
                    if (slotIndex >= size)
                    { 
                        slotIndex=0;
                    }
                }         
                return slotIndex;
            }
        }
        public bool IsKey(string key)// возвращает true если ключ имеется, иначе false
        {
            int index = 0;
            while (index < size)
            {
                if (slots[index] == key)
                    return true;
                else
                {
                    index += 1;
                }
            }
            return false;
        }
        public void Put(string key, T value)  // гарантированно записываем значение value по ключу key
        {
            int index = HashFun(key);
            slots[index] = key;
            values[index] = value;
            isTotal += 1;

        }
        public T Get(string key) // возвращает value для key, или null если ключ не найден
        {
            int index = 0;
            while (index < size)
            {
                if (slots[index] == key)
                    return values[index];
                else
                {
                    index += 1;
                }
            }
            return default(T);
        }
    }
}
