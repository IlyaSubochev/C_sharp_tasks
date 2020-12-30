using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsDataStructures
{
    class NativeCache<T>
    {
        public int size;
        public String[] slots;
        public T[] values;
        public int[] hits;

        public NativeCache(int sz)
        {
            size = sz;
            slots = new string[size];
            values = new T[size];
            hits = new int[size];
        }

        public int HashFun(string key)
        {
            int hashcode = 0;
            if (key != null)
            {               
                char[] hashArray = key.ToCharArray();
                for (int i = 0; i < hashArray.Length; i++)
                    hashcode += Convert.ToInt32(hashArray[i]);               
            }
            return hashcode % size;
        }

        public bool IsKey(string key)
        {
            int index = FindSlot(key);
            if (index != -1)
                return true;
            return false;
        }

        public void Put(string key, T value)
        {
            if (key != null)
            {
                int hashcode = HashFun(key);
                for (int i = 0; i < size; i++)
                {
                    if (slots[hashcode] == null || slots[hashcode] == key)
                    {
                        slots[hashcode] = key;
                        values[hashcode] = value;
                        break;
                    }
                    hashcode++;
                    if (hashcode >= size) hashcode = 0;
                }
                int delSlot = Array.IndexOf(hits, hits.Min());
                hits[delSlot] = 0;
                slots[delSlot] = key;
                values[delSlot] = value;
            }
        }

        public T Get(string key)
        {
            int index = FindSlot(key);
            if (index != -1)
            {
                hits[index]++;
                return values[index];
            }
            return default(T);
        }

        private int FindSlot(string key)
        {
            if (key != null)
            {
                int hashcode = HashFun(key);
                for (int i = 0; i < size; i++)
                {
                    if (slots[hashcode] == key)
                        return hashcode;
                    hashcode++;
                    if (hashcode >= size) hashcode = 0;
                }
            }
            return -1;
        }
    }
}

