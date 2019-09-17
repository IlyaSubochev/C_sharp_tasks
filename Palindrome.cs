        public static bool Palindrome(string s)
        {
            var Que1 = new AlgorithmsDataStructures.Deque<char>();
            var Que2 = new AlgorithmsDataStructures.Deque<char>();
            string result = "";
            int k = 0;
                foreach (char c in s)
                {
                    if (char.IsLetter(c))
                        result = result + c;               
            }
            foreach (char c in result)
            {
                if (k < result.Length/2)
                    Que1.AddTail(c);
                else if (k > result.Length/2)
                    Que2.AddTail(c);
                k++;
            }
            while (Que1.Size() > 0)
            {
                if (Que1.RemoveFront().ToString().ToLower() == Que2.RemoveTail().ToString().ToLower())
                    continue;
                else
                    break;                
            }

            if (Que1.Size() == 0)
                return true;
            else
                return false;
        }
