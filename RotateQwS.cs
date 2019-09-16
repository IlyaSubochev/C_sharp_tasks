 public static void Rotate(int k, Queue<int> Que)
        {
            if (k > Que.Count)
                k = k - Que.Count * (k / Que.Count);
                for (int i = 0; i < Que.Count - k; i++)
                {

                    Que.Enqueue(Que.Dequeue());
            
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
