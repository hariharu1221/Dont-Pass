using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Point
{
    public float x;
    public float y;

    public Point(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public Point zero()
    {
        return new Point(0, 0);
    }
}
