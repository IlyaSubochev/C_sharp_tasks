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
