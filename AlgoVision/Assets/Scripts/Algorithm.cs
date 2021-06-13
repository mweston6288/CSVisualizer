using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;
using System.Diagnostics;

public abstract class Algorithm : MonoBehaviour
{
    public Random r = new Random();
    public float time, completionPercent;
    public long stopTime, currentTime;
    public static Stopwatch timer = new System.Diagnostics.Stopwatch();
    public Color green = new Color(0.533f, 0.671f, 0.459f);
    public Color blue = new Color(0.6f, 0.686f, 0.761f);
    public Color red = new Color(1f, .2f, .361f, 1);
}
