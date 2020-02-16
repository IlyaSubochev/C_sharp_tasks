using System;
using System.Collections.Generic;
namespace AlgorithmsDataStructures
{
    public class NativeDictionary<T>
    {
        public int size;
        public string[] slots;
        public T[] values;
        public NativeDictionary(int sz)
        {
            size = sz;
            slots = new string[size];
            values = new T[size];
        }
        public int HashFun(string key) // всегда возвращает корректный индекс слота
        {
            int hashcode = key.GetHashCode() & 0x7FFFFFFF;           
            return hashcode % size;
        }
        public bool IsKey(string key)// возвращает true если ключ имеется, иначе false
        {
            int index = HashFun(key);
            
            return false;
        }
        public void Put(string key, T value)  // гарантированно записываем значение value по ключу key
        {
            int index = HashFun(key);

        }
        public T Get(string key) // возвращает value для key, или null если ключ не найден
        {
            int index = HashFun(key);

            return default(T);
        }
    }
}
