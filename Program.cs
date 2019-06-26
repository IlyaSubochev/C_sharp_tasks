using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstApp
{
    class Program
    {
        static string RndString(int r)
        {
            string[] a ={"a","b","c","d","e","f"," ","g","j","h","i","k","l","m","n","o","p"," ","q","r",
                      "s","t","u","v","w"," ","x","y","z"," "};
            StringBuilder sb = new StringBuilder(r);
            Random New = new Random();
            int y = 0;
            for (int i = 0; i < r; i++)
            {
                y = New.Next(0, a.Length - 1);
                sb.Append(a[y]);
            }
            return sb.ToString();
        }
        static bool findS(string s1, string s2, int k = 0, bool c = true)
        {
            char[] a = s1.ToCharArray();
            char[] b = s2.ToCharArray();
            for (int i = 0; ((i + b.Length) <= a.Length); i++)
            {
                if (a[i] == b[0])
                {
                    c = true;
                    for (int j = 1; j < b.Length; j++)
                    {
                        if (a[i + j] == b[j]) continue;
                        else c = false;
                    }
                    if (c == true) k = k + 1;
                }
            }
            if (k > 0) return true;
            else return false;
        }
        static void test1()
        {
            string s1 = RndString(100);
            string s2 = s1.Substring(15, 8);
            if (findS(s1, s2) == false) Console.WriteLine("TEST 1 ERROR"); else Console.WriteLine("TEST 1 PASSED");
        }
        static void test2_1()
        {
            string s1 = "";
            string s2 = RndString(100);
            if (findS(s1, s2) == true) Console.WriteLine("TEST 2_1 ERROR"); else Console.WriteLine("TEST 2_1 PASSED");
        }
        static void test2_2()
        {
            try
            {
                string s1 = RndString(100);
                string s2 = "";
                findS(s1, s2);
                Console.WriteLine("TEST 2_2 ERROR");
            }
            catch (Exception) { Console.WriteLine("TEST 2_2 PASSED"); }
        }
        static void test2_3()
        {
            try
            {
                string s1 = "";
                string s2 = "";
                findS(s1, s2);
                Console.WriteLine("TEST 2_3 ERROR");
            }
            catch (Exception) { Console.WriteLine("TEST 2_3 PASSED"); }
        }
        static void test3()
        {
            string s1_1 = RndString(100); Thread.Sleep(100); string s1_2 = RndString(100);
            string s2_1 = RndString(10); Thread.Sleep(100); string s2_2 = RndString(100);
            string s3_1 = RndString(100); Thread.Sleep(100); string s3_2 = RndString(10);
            string s4_1 = RndString(100); string s4_2 = s4_1;
            if ((findS(s1_1, s1_2) == false) && (findS(s2_1, s2_2) == false) && (findS(s3_1, s3_2) == false) && (findS(s4_1, s4_2) == true))
                Console.WriteLine("TEST 3 PASSED");
            else Console.WriteLine("TEST 3 ERROR");
        }
        static void test4()
        {
            try
            {
                string s1 = RndString(1000000);
                Thread.Sleep(100);
                string s2 = RndString(100);
                findS(s1, s2);
                if (findS(s1,s2)==true) Console.WriteLine("TEST 4 PASSED");
                else Console.WriteLine("TEST 4 ERROR");
            }
            catch (Exception) { Console.WriteLine("TEST 4 ERROR exception"); }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Вызываем test1 ");
            test1();
            Console.WriteLine("Вызываем test2_1 ");
            try { test2_1(); }
            catch (Exception e) { Console.WriteLine("ERROR " + e); }
            Console.WriteLine("Вызываем test2_2 ");
            test2_2();
            Console.WriteLine("Вызываем test2_3 ");
            try { test2_3(); } catch (Exception e) { Console.WriteLine("ERROR " + e); }
            Console.WriteLine("Вызываем test3 ");
            test3();
            Console.WriteLine("Вызываем test4 ");
            try { test4(); } catch (Exception e) { Console.WriteLine("ERROR " + e); }
            Console.ReadKey();
        }

    }
}
    class Calculator
    {
        public static void Add(int x, int y)
        {
            int z = x + y;
            Console.WriteLine($"Сумма {x} и {y} равна {z}");
        }
    }

