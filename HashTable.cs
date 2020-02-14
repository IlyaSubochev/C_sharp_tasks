using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

    public class HashTable
    {
        public int size;
        public int step;
        public string[] slots;
        public int isTotal;

        public HashTable(int sz, int stp)
        {
            size = sz;
            step = stp;
            slots = new string[size];
            for (int i = 0; i < size; i++) slots[i] = null;
            isTotal = 0;
        }

        public int HashFun(string value) // всегда возвращает корректный индекс слота
        {
            int valueValue = 0;
            for (int i = 0; i < value.Length; i++)
            {
                valueValue = +i * 2;
            }
            return valueValue % size;
        }

        public int SeekSlot(string value) // находит индекс пустого слота для значения, или -1
        {
            int total = isTotal / slots.Length;
            int index = HashFun(value);
            int stepSeek = step;
            if (slots[index] == null)
                return index;
            else
            {
                while (total<1 && slots[index] != null)
                {                        
                        index = index + stepSeek;
                    if (index >= size)
                    {
                        index = 0;
                        stepSeek = 1;
                    }
                    
                }
                if (total < 1)
                    return index;
                else
                    return -1;
            }
        }

        public int Put(string value)
        {
            // записываем значение по хэш-функции
            // возвращается индекс слота или -1
            // если из-за коллизий элемент не удаётся разместить 
            int total = isTotal / slots.Length;
            int freeSlot = SeekSlot(value);
            if (total==1 || freeSlot == -1)
                return -1;
            else
            {
                slots[freeSlot] = value;
                isTotal += 1;
                return freeSlot;
            }
                
        }

        public int Find(string value) // находит индекс слота со значением, или -1
        {
            int index = HashFun(value);
            if (slots[index] == null)
                return -1;
            else
            {
                index = 0;
                while (index < size)
                {
                    if (slots[index] == value)
                        return index;
                    else
                    {
                        index = index + 1;
                    }
                }
                return -1;
            }

        }
    }

}

