using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticMath
{
    public static float NormalizeValue(float val, float min, float max)
    {
        return ((val - min) / (max - min));
    }
}
