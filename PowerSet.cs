using System;
using System.Collections.Generic;


namespace AlgorithmsDataStructures
{
    public class PowerSet<T>
    {

        public int size;
        public int step;
        public T[] slots;

        public PowerSet()
        {
            size = 20000;
            step = 3;
            slots = new T[size];
            for (int i = 0; i < size; i++)
                slots[i] = default(T);
        }

        public int HashFun(T value) // всегда возвращает корректный индекс слота
        {
            int nx = 0;
            if (size > 0 && value != null)
            {
                if (value.GetType() == typeof(string))
                {
                    char[] chars = Convert.ToString(value).ToCharArray();
                    for (int i = 0; i < chars.Length - 1; i++)
                        nx += Convert.ToInt32(chars[i]);
                }
                else nx = value.GetHashCode();
                nx = (nx * 12 + 4) % size;
                if (nx < 0) nx = nx * -1;
                return nx;
            }
            return 0;
        }

        public int SeekSlot(T value) // находит индекс пустого слота для значения, или -1
        {
            int nx = HashFun(value);

            for (int i = 0; i < size; i++)
            {
                if (slots[nx] == null) return nx;
                else nx += step;
                if (nx >= size) nx = nx % size;
            }

            return -1;
        }

        public int Find(T value) // находит индекс слота со значением, или -1
        {
            int slot = HashFun(value);
            for (int i = 0; i < size; i++)
            {
                if (slot >= size) slot -= size;
                if (slots[slot] != null)
                    if (slots[slot].Equals(value)) return 1;
                slot += step;
            }
            return -1;
        }

        public int Size() // количество элементов в множестве
        {
            int count = 0;
            for (int i = 0; i < size; i++)
                if (slots[i] != null && !slots[i].Equals(default(T)))
                    count++;
            if (count != 0) return count;
            return 0;
        }

        public void Put(T value) // всегда срабатывает
        {
            int slot = HashFun(value);
            int memSlot = -1;

            for (int i = 0; i < size; i++)
            {
                if (slot >= size) slot -= size;
                if ((slots[slot] == null || slots[slot].Equals(default(T))) && memSlot == -1) memSlot = slot;
                if (slots[slot] != null && slots[slot].Equals(value)) return;
                slot += step;
            }
            if (memSlot != -1) slots[memSlot] = value;
        }

        public bool Get(T value) // возвращает true если value имеется в множестве, иначе false
        {
            if (Find(value) == 1) return true;
            return false;
        }

        public bool Remove(T value) // возвращает true если value удалено  иначе false
        {
            if (value.Equals(default(T))) return false;
            int slot = HashFun(value);

            for (int i = 0; i < size; i++)
            {
                if (slot >= size) slot -= size;
                if (slots[slot] != null)
                    if (slots[slot].Equals(value))
                    {
                        slots[slot] = default(T);
                        return true;
                    }
                slot += step;
            }
            return false;
        }

        public PowerSet<T> Intersection(PowerSet<T> set2) // пересечение текущего множества и set2
        {
            PowerSet<T> setIntersection = new PowerSet<T>();
            if (set2 != null)
            {
                for (int i = 0; i < size; i++)
                {
                    if (slots[i] == null) continue;
                    else if (slots[i].Equals(default(T))) continue;
                    if (set2.Get(slots[i])) setIntersection.Put(slots[i]);
                }
                return setIntersection;
            }
            return setIntersection;
        }

        public PowerSet<T> Union(PowerSet<T> set2) // объединение текущего множества и set2
        {
            PowerSet<T> setUnion = new PowerSet<T>();
            if (set2 != null)
            {
                for (int i = 0; i < size; i++)
                {
                    if (slots[i] != null) setUnion.Put(slots[i]);
                    if (set2.slots[i] != null) setUnion.Put(set2.slots[i]);
                }
                return setUnion;
            }
            return setUnion;
        }

        public PowerSet<T> Difference(PowerSet<T> set2) // разница текущего множества и set2
        {
            PowerSet<T> setDifference = new PowerSet<T>();
            if (set2 != null)
            {
                for (int i = 0; i < size; i++)
                {
                    if (slots[i] != null)
                        if (!set2.Get(slots[i])) setDifference.Put(slots[i]);
                }
                return setDifference;
            }
            return setDifference;
        }

        public bool IsSubset(PowerSet<T> set2) // возвращает true, если set2 есть подмножество текущего множества, иначе false
        {
            if (Size() >= set2.Size())
            {
                if (set2.Size() == 0) return true;
                for (int i = 0; i < size; i++)
                {
                    if (set2.slots[i] != null && !set2.slots[i].Equals(default(T)))
                        if (!Get(set2.slots[i])) break;
                    if (i == size - 1) return true;
                }
            }
            return false;
        }     
    }
}
