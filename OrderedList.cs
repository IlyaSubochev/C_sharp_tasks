using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

    public class Node<T>
    {
        public T value;
        public Node<T> next, prev;

        public Node(T _value)
        {
            value = _value;
            next = null;
            prev = null;
        }
    }

    public class OrderedList<T> 
    {
        public Node<T> head, tail;
        private bool _ascending;

        public OrderedList(bool asc)
        {
            head = null;
            tail = null;
            _ascending = asc;
        }

        public int Compare(T v1, T v2)
        {
            int result=0;
            if (v1.GetType() == typeof(String))  // версия для лексикографического сравнения строк typeof(T)
            {
                string v1String = v1.ToString().Trim();                           
                string v2String = v2.ToString().Trim();
                if (v1String.CompareTo(v2String) < 0)
                    return result = -1;
                else if (v1String.CompareTo(v2String) > 0)
                    return result = 1;                           
            }
            else if (Convert.ToDouble(v1) > Convert.ToDouble(v2))
                    return result = 1;
                else if (Convert.ToDouble(v1) < Convert.ToDouble(v2))
                    return result = -1;             

            return result;

            //return result;
            // -1 если v1 < v2
            // 0 если v1 == v2
            // +1 если v1 > v2
        }

        public void Add(T value)
        {
            Node<T> _value = new Node<T>(value);
            if (head == null)
            {
                head = _value;
                head.next = null;
                head.prev = null;
                tail = _value;
            }
            else if (_ascending == true)
            {
                Node<T> node = head;
               
                while (node != null)
                {
                    int result = Compare(node.value, value);                    
                    if (node == null || (node.next == null && (result == 0 || result < 0)))
                    { 
                        AddInTail(_value); 
                        break; 
                    }
                    else if (node.next != null && node.prev != null &&
                        (result == 0 || (result<0 && Compare(node.next.value, value) > 0))) 
                    {
                        _value.next = node.next;
                        _value.prev = node;
                        node.next.prev = _value;
                        node.next = _value;
                        break;
                    }
                    else if (node.next != null && node.prev == null &&
                        (result == 0 || (result < 0 && Compare(node.next.value, value) > 0)))
                    {
                        _value.next = node.next;
                        _value.prev = node;
                        node.next.prev = _value;
                        node.next = _value;
                        break;                       
                    }
                    else if ((node.next != null && node.prev == null && result > 0) ||
                        (node.next == null && node.prev == null && result > 0))
                    {
                        head = _value;
                        head.next = node;
                        node.prev = head;
                        break;
                    }
                   
                    node = node.next;
                }
            }

            else if (_ascending == false)
            {
                Node<T> node = head;

                while (node != null)
                {
                    int result = Compare(node.value, value);
                    if (node==null || (node.next == null && (result == 0 || result > 0)))
                    {
                        AddInTail(_value);
                        break;
                    }
                    else if (node.prev == null && (result < 0 || result == 0))
                    {
                        Node<T> temp = head;
                        head = _value;
                        head.next = temp;
                        temp.prev = head;

                        break;
                    }
                    else if (node.next != null && node.prev != null &&
                        (result == 0 || (result > 0 && Compare(node.next.value, value) < 0)))
                    {
                        _value.next = node.next;
                        _value.prev = node;
                        node.next.prev = _value;                      
                        node.next = _value;
                        break;
                    }
                    else if (node.next != null && node.prev == null &&
                        (result == 0 || (result > 0 && Compare(node.next.value, value) < 0)))
                    {
                        _value.next = node.next;
                        _value.prev = node;
                        node.next.prev = _value;
                        node.next = _value;
                        break;
                    }

                    node = node.next;
                }
            }           
        }

        public Node<T> Find(T val)
        {
            Node<T> node = head;
            if (_ascending == true && (Compare(head.value, val) > 0 || Compare(tail.value, val) < 0))
                return null;
            else if (_ascending == false && (Compare(head.value, val) < 0 || Compare(tail.value, val) > 0))
                return null;
            else
            {
                while (node != null)
                {
                    if (Compare(node.value, val) == 0)
                        return node;
                    node = node.next;
                }
            }
            return null;
            
        }

        public void Delete(T val)
        {
            int tempCount = Count();
            if (tempCount > 0)
            {
                Node<T> node = Find(val);
                if (node != null)
                {

                    if (tempCount == 1)
                        Clear(_ascending);
                    else if (node.prev == null)
                    {
                        node = node.next;
                        head = node;
                        head.prev = null;
                    }
                    else if (node.next == null)
                    {
                        if (tempCount == 2)
                            tail = head;
                        else
                            tail = node.prev;
                        tail.next = null;
                    }
                    else
                    {
                        Node<T> temp = node.next;
                        node.prev.next = temp;
                        temp.prev = node.prev;

                    }

                }
            }
        }

        public void Clear(bool asc)
        {
            _ascending = asc;
            head = null;
            tail = null;
        }

        public int Count()
        {
             Node<T> node = head;
            int count = 0;
            while (node != null)
            {
                count++;
                node = node.next;
            }
            return count;
           
        }

        public List<Node<T>> GetAll() 
                             
        {
            List<Node<T>> r = new List<Node<T>>();
            Node<T> node = head;
            while (node != null)
            {
                r.Add(node);
                node = node.next;
            }
            return r;
        }
        public List<Node<T>> GetAllTail()

        {
            List<Node<T>> r = new List<Node<T>>();
            Node<T> node = tail;
            while (node != null)
            {
                r.Add(node);
                node = node.prev;
            }
            return r;
        }
        public void AddInTail(Node<T> _item)
        {
            if (head == null)
            {
                head = _item;
                head.next = null;
                head.prev = null;
            }
            else
            {
                tail.next = _item;
                _item.prev = tail;
            }
            tail = _item;
        }

       
        
    }

}
