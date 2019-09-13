 public static void Rotate(int k, AlgorithmsDataStructures.Queue<dynamic> Que)
        {
            dynamic temp = Que.array[Que.head];
            dynamic temp2;
            while (k != 0)
            {
                for (int i = Que.head; i <= Que.tail; i++)
                {

                    if (i == 0)
                    {

                        Que.array[i] = Que.array[Que.tail];
                    }

                    else
                    {
                        temp2 = Que.array[i];
                        Que.array[i] = temp;
                        temp = temp2;
                    }
                }
                k--;
            }

        }
        public class QueueWithStack<T>
        {
            public Stack<T> Stack1;
            public Stack<T> Stack2;
            public int size;
            public QueueWithStack()
            {
                Stack1 = new Stack<T>();
                Stack2 = new Stack<T>();
                size = 0;
            }
            

            public void Enqueue(T item)
            {
                Stack1.Push(item);
                size++;
            }

            public T Dequeue()
            {
                if (Stack2.Count == 0)
                {
                    while (Stack1.Count != 0)
                    {
                        Stack2.Push(Stack1.Pop());
                    }
                }
                T temp = default(T);
                if (Stack1.Count != 0)
                {
                    temp = Stack2.Pop();
                }
                return temp;
            }
            public int Size()
            {
                return size;
            }

        }
