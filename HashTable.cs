using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

    public class HashTable
    {
        public int size;
        public int step;
        public string[] slots;

        public HashTable(int sz, int stp)
        {
            size = sz;
            step = stp;
            slots = new string[size];
            for (int i = 0; i < size; i++) slots[i] = null;
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
            int index = HashFun(value);
            if (slots[index] == null)
                return index;
            else
            {
                while (slots[index] != null)
                {
                        index = +step;
                }
                return index;
            }
        }

        public int Put(string value)
        {
            // записываем значение по хэш-функции
            // возвращается индекс слота или -1
            // если из-за коллизий элемент не удаётся разместить 
            int freeSlot = SeekSlot(value);
            if (freeSlot == -1)
                return -1;
            else
            {
                slots[freeSlot] = value;
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
                while (slots[index] != null)
                {
                    if (slots[index] == value)
                        return index;
                    else
                        index = +step;
                }
                return -1;
            }



        }
    }

}

