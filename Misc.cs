using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ABLibrary
{
    class Core
    {
        public static void Swap<T>(ref T val1, ref T val2)
        {
            T tmp = val1;
            val1 = val2;
            val2 = tmp;
        }
    }
}
