using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{
    public class Node
    {
        public int value;
        public Node next, prev;

        public Node(int _value)
        {
            value = _value;
            next = null;
            prev = null;
        }
    }
    public class LinkedList2
    {
        public Node head;
        public Node tail;

        public LinkedList2()
        {
            head = null;
            tail = null;
        }
        public void AddInTail(Node _item)
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
        public Node Find(int _value)  
        {
            Node node = head;
            while (node != null)
            {
                if (node.value == _value)
                    return node;
                node = node.next;
            }
            return null;
        }
        public List<Node> FindAll(int _value) 
        {
            List<Node> nodes = new List<Node>();
            Node node = head;
            while (node != null)
            {
                if (node.value == _value)
                    nodes.Add(node);
                node = node.next;
            }
            return nodes;
        }
        public bool Remove(int _value) 
        {
            Node node = head;
            Node nodePrev = null;
            int CountRem = Count();
            if (CountRem != 0)
            {
                if (CountRem == 1)
                {
                    head = null;
                    tail = null;
                }
                if (CountRem > 1)
                {
                    while (node != null)
                    {
                        if (node.value == _value)
                        {
                            if (nodePrev != null)
                            {
                                if (node.next == null)  //хвост
                                {
                                    if (CountRem == 2)
                                        tail = head;
                                    else
                                        tail = node.prev;
                                    tail.next = null;
                                }
                                else //между головой и хвостом
                                {
                                    nodePrev.next = node.next;
                                    node.next.prev = nodePrev;                                 
                                }
                            }
                            else
                            {
                                node = node.next;
                                if (nodePrev == null) // голова
                                {
                                    head = node;
                                    head.prev = null;
                                }                              
                            }
                            return true;
                        }
                        nodePrev = node;
                        node = node.next;
                    }
                }              
            }           
            return false;            
        }
        public void RemoveAll(int _value)
        {
            Node node = head;
            int count = 0;
            int count2 = 0;
            while (node != null)
            {
                if (node.value == _value)
                    count++;
                node = node.next;
            }
            while (count2 < count)
            {
                Remove(_value);
                count2++;
            }
        }
        public void Clear() 
        {
            head = null;
            tail = null;            
        }
        public int Count() 
        {
            Node node = head;
            int count = 0;
            while (node != null)
            {
                count++;
                node = node.next;
            }
            return count;          
        }
        public void InsertAfter(Node _nodeAfter, Node _nodeToInsert)
        {           
            Node node = head;
            if (_nodeAfter == null && node != null)
            {
                head = _nodeToInsert;
                head.next = node;
                head.next.prev = _nodeToInsert;
            }
            else if (node == null)
                AddInTail(_nodeToInsert);
            else if (_nodeAfter != null && node.value == _nodeAfter.value && node.next == null)
                AddInTail(_nodeToInsert);
            else
            {
                while (node != null)
                {
                    
                    if (node.value == _nodeAfter.value && node.next != null)
                    {
                        _nodeToInsert.next = node.next;
                        node.next = _nodeToInsert;
                        node.next.prev = _nodeAfter;
                        break;
                    }
                    else if (node.value == _nodeAfter.value && node.next == null)
                        AddInTail(_nodeToInsert);
                    node = node.next;
                }
            }
        }       
    }
}
