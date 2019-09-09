        public static bool Balanced(string s)
        {
            var BalStack = new Stack<char>();
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                {
                    BalStack.Push(s[i]);
                }
                else if (s[i] == ')') 
                {
                    if (BalStack.Count() != 0 && BalStack.Peek() == '(')
                    {
                        BalStack.Pop();
                    }
                }
            }
            if ( BalStack.Count() == 0 && s.Length%2 == 0) 
                return true;
            else
                return false;
        }
        public static int PostFix(string s)
        {
            var S1 = new Stack<int>();
            var S2 = new Stack<int>();
            string[] a = s.Split(' ');
            int TempS = 0;
            foreach (var item in a)
            {
                char Temp = Convert.ToChar(item);
                
                if (Char.IsDigit(Temp))
                {
                    if (TempS == 0)
                    {
                        S1.Push((int)Convert.ToInt32(item));
                        TempS++;
                    }
                    else if (TempS == 1 && S2.Count() == 0)
                    {
                        S2.Push(Convert.ToInt32(item));
                        TempS--;
                    }
                }
                else
                {
                    switch (item)
                    {
                        case "+":
                            S2.Push(S1.Pop() + S2.Pop());
                            if (TempS==1) TempS--;
                            break;
                        case "-":
                            S2.Push(S1.Pop() - S2.Pop());
                            if (TempS == 1) TempS--;
                            break;
                        case "*":
                            S2.Push(S1.Pop() * S2.Pop());
                            if (TempS == 1) TempS--;
                            break;
                        case "/":
                            S2.Push(S1.Pop() / S2.Pop());
                            if (TempS == 1) TempS--;
                            break;
                        case "=":
                            return S2.Pop();                            
                    }
                }
            }

            return S2.Pop();
        }
