using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ABLibrary
{
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
