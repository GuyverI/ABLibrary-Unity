using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ABLibrary
{
    public class RandomGenerator
    {

        public static void Shuffle<T>(ref Stack<T> container)
        {
            var array = container.ToArray();
            Shuffle(ref array);
            container = new Stack<T>(array);
        }

        public static void Shuffle<T>(ref T[] array)
        {
            for (int i = 0; i < array.Length; ++i)
            {
                int randIndex = Random.Range(0, array.Length);
                Core.Swap(ref array[i], ref array[randIndex]);
            }
        }
    }

    public class ExpRandomGenerator
    {
        public static float RangeF(float inclMin, float inclMax)
        {
            float uniformMin = Mathf.Exp(-1.0f);
            float uniformVal = Random.Range(uniformMin, 1.0f);

            float expVal = -Mathf.Log(uniformVal);

            return Mathf.Lerp(inclMin, inclMax, expVal);
        }

        public static int RangeI(int inclMin, int inclMax)
        {
            int result = (int)RangeF(inclMin, inclMax+1);
            return Mathf.Clamp(result, inclMin, inclMax); 
        }
    }
}
