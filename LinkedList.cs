using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{
    public class Node
    {
        public int value;
        public Node next;
        public Node(int _value)
            {
                value = _value;
            }
    }
    public class LinkedList
    {
        public Node head;
        public Node tail;
        public LinkedList()
        {
            head = null;
            tail = null;
        }

        public void AddInTail(Node _item)
        {
            if (head == null)
                head = _item;
            else
                tail.next = _item;
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
            while (node != null)
            {
                if (node.value == _value)
                {                   
                    if (nodePrev != null)
                    {
                        nodePrev.next = node.next;
                        if (node.next == null)
                            tail = nodePrev;
                    }
                   
                    else
                    {
                        node = node.next;
                        if (node == null)
                            tail = null;
                         if (nodePrev == null)
                           { 
                            head = node;
                            tail=node.next;
                           }
                    }
                    return true;
                }
                nodePrev = node;
                node = node.next;
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
            if ( node==null )
                AddInTail(_nodeToInsert);
            else if (node.value ==_nodeAfter.value && node.next==null)
                AddInTail(_nodeToInsert);
            else
            {
                while (node!=null)
                {
                    if (node.value ==_nodeAfter.value)
                    {
                   
                        _nodeToInsert.next=node.next;
                        node.next =_nodeToInsert;
                        break;                    
                    }
                    node=node.next;
                }    
            }                                                                                                                                                                                              
        }               
        
    }
    
}
