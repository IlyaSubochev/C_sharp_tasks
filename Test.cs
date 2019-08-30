using System;
using System.Collections.Generic;

namespace Test
{
    public class TestClass
    {
        public static void TestRemove()
        {
            var list = new AlgorithmsDataStructures.LinkedList();
            list.AddInTail(new AlgorithmsDataStructures.Node(5));
            list.Remove(5);
            if (list.head == null && list.tail == null)
                Console.WriteLine("TestRemoved part1 PASSED");
            else
                Console.WriteLine("TestRemoved part1 ERROR");
            list.AddInTail(new AlgorithmsDataStructures.Node(5));
            list.AddInTail(new AlgorithmsDataStructures.Node(15));
            list.AddInTail(new AlgorithmsDataStructures.Node(25));
            list.Remove(5);
            if (list.head.value == 15 && list.tail.value == 25)
                Console.WriteLine("TestRemoved part2 PASSED");
            else
                Console.WriteLine("TestRemoved part2 ERROR");
            list.AddInTail(new AlgorithmsDataStructures.Node(35));
            list.Remove(35);
            if (list.head.value == 15 && list.tail.value == 25)
                Console.WriteLine("TestRemoved part3 PASSED");
            else
                Console.WriteLine("TestRemoved part3 ERROR");
            list.Remove(25);
            if (list.head.value == 15 && list.tail.value == 15)
                Console.WriteLine("TestRemoved part4 PASSED");
            else
                Console.WriteLine("TestRemoved part4 ERROR");
        }
       public static void TestRemoveAll()
        {
            var list = new AlgorithmsDataStructures.LinkedList();
            list.AddInTail(new AlgorithmsDataStructures.Node(5));
            list.RemoveAll(5);
            if (list.head == null && list.tail == null)
                Console.WriteLine("TestRemovedALL part1 PASSED");
            else
                Console.WriteLine("TestRemovedALL part1 ERROR");
            list.AddInTail(new AlgorithmsDataStructures.Node(5));
            list.AddInTail(new AlgorithmsDataStructures.Node(15));
            list.AddInTail(new AlgorithmsDataStructures.Node(25));
            list.RemoveAll(5);
            if (list.head.value == 15 && list.tail.value == 25)
                Console.WriteLine("TestRemovedALL part2 PASSED");
            else
                Console.WriteLine("TestRemovedALL part2 ERROR");
            list.AddInTail(new AlgorithmsDataStructures.Node(35));
            list.RemoveAll(35);
            if (list.head.value == 15 && list.tail.value == 25)
                Console.WriteLine("TestRemovedALL part3 PASSED");
            else
                Console.WriteLine("TestRemovedALL part3 ERROR");
            list.RemoveAll(25);
            if (list.head.value == 15 && list.tail.value == 15)
                Console.WriteLine("TestRemovedALL part4 PASSED");
            else
                Console.WriteLine("TestRemovedALL part4 ERROR");
            list.AddInTail(new AlgorithmsDataStructures.Node(5));
            list.AddInTail(new AlgorithmsDataStructures.Node(15));
            list.AddInTail(new AlgorithmsDataStructures.Node(25));
            list.RemoveAll(15);
            if (list.head.value == 5 && list.tail.value == 25)
                Console.WriteLine("TestRemovedALL part5 PASSED");
            else
                Console.WriteLine("TestRemovedALL part5 ERROR");
        }
       public static void TestClear()
        {
            var list = new AlgorithmsDataStructures.LinkedList();
            list.AddInTail(new AlgorithmsDataStructures.Node(5));
            list.AddInTail(new AlgorithmsDataStructures.Node(15));
            list.AddInTail(new AlgorithmsDataStructures.Node(25));
            list.Clear();
            if (list.head == null && list.tail == null)
                Console.WriteLine("TestClear PASSED");
            else
                Console.WriteLine("TestClear ERROR");
        }
        public static void TestCount()
        {
            var list = new AlgorithmsDataStructures.LinkedList();
            for (int i = 0; i < 100; i++)
                list.AddInTail(new AlgorithmsDataStructures.Node(i));
            if (list.Count() == 100)
                Console.WriteLine("TestCount PASSED");
            else
                Console.WriteLine("TestCount ERROR");

        }
        public static void TestInsertAfter()
        {
            var list = new AlgorithmsDataStructures.LinkedList();
            list.InsertAfter(new AlgorithmsDataStructures.Node(5), new AlgorithmsDataStructures.Node(5));
            if (list.head.value == 5 && list.tail.value == 5 && list.head.next == null
                && list.tail.next == null)
                Console.WriteLine("TestInserAfter part1 PASSED");
            else
                Console.WriteLine("TestInserAfter part1 ERROR");
            list.InsertAfter(new AlgorithmsDataStructures.Node(5), new AlgorithmsDataStructures.Node(15));
            if (list.head.value == 5 && list.tail.value == 15 && list.head.next.value == 15
               && list.tail.next == null)
                Console.WriteLine("TestInserAfter part2 PASSED");
            else
                Console.WriteLine("TestInserAfter part2 ERROR");
        }
        public static void TestFindAll()
        { }
        public static List<int> AddMerge(List<int> list1, List<int> list2)
        {
            List<int> ListAddMerge = new List<int>();
            if (list1.Count == list2.Count)
            {
                int i = 0;
                foreach (var item1 in list1)
                {
                    int j = 0;
                    foreach (var item2 in list2)
                    {
                        if (i == j)
                            ListAddMerge.Add(item1 + item2);
                        j++;
                    }
                    i++;
                }
            }
            return ListAddMerge;
        }

    }
}
