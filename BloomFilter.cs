using System.Collections.Generic;
using System;
using System.IO;
using System.Collections;

namespace AlgorithmsDataStructures
{
    public class BloomFilter
    {
        public int filter_len;
        public BitArray bitArray;
        public BloomFilter(int f_len)
        {
            filter_len = f_len;
            // создаём битовый массив длиной f_len ...
            bitArray = new BitArray(filter_len);
        }

        // хэш-функции
        public int Hash1(string str1)
        {
            // 17
            int resHash = 0;
            for(int i=0; i<str1.Length; i++)
            {
                int code = (int)str1[i];
                resHash = (code + resHash*17) % filter_len;
            }
            if (resHash < 0)
                return resHash *= -1;
            else
                return resHash;
        }
        public int Hash2(string str1)
        {
            // 223
            int resHash = 0;
            for (int i = 0; i < str1.Length; i++)
            {
                int code = (int)str1[i];
                resHash = (code + resHash * 223) % filter_len;
            }
            if (resHash < 0)
                return resHash *= -1;
            else
                return resHash;
        }
        public void Add(string str1)
        {
            // добавляем строку str1 в фильтр
            bitArray.Set(Hash1(str1), true);
            bitArray.Set(Hash2(str1), true);
        }
        public bool IsValue(string str1)
        {
            // проверка, имеется ли строка str1 в фильтре
            return bitArray[Hash1(str1)] && bitArray[Hash2(str1)];
        }
    }
}
