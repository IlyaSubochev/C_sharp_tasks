using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmsDataStructures2
{
    public static class BalancedBST
    {
        public static int[] GenerateBBSTArray(int[] a)
        {

            if (a != null)
            {
                a = a.OrderBy(i => i).ToArray();
                int depth = -1;
                for (int size = a.Length; size != 0; depth++)
                    size >>= 1;

                int[] b = new int[(2 << (depth)) - 1];
                if (a.Length == b.Length)
                {
                    GetArray(b, a, 0);
                    return b;
                }
            }
            return null;
        }

        public static void GetArray(int[] balanced, int[] sorted, int nx)
        {
            balanced[nx] = sorted[sorted.Length / 2];
            if (sorted.Length == 1) 
                return;
            int[] cut = new int[sorted.Length / 2];

            Array.Copy(sorted, 0, cut, 0, sorted.Length / 2);
            GetArray(balanced, cut, nx * 2 + 1);

            Array.Copy(sorted, sorted.Length / 2 + 1, cut, 0, sorted.Length / 2);
            GetArray(balanced, cut, nx * 2 + 2);
        }
    }
}
