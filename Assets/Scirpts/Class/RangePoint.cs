using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RangePoint
{
    public float min;
    public float max;

    public int IntRange()
    {
        return Random.Range((int)min, (int)max);
    }

    public float FloatRange()
    {
        return Random.Range(min, max);
    }

    public int IntRandomRange()
    {
        int random = Random.Range(0, 100);

        if (random < 50)
        {
            return (int)min;
        }
        else if (random < 65)
        {
            return (int)(min + 1 * (DisRange() / 4));
        }
        else if (random < 80)
        {
            return (int)(min + 2 * (DisRange() / 4));
        }
        else if (random < 95)
        {
            return (int)(min + 3 * (DisRange() / 4));
        }
        else
        {
            return (int)max;
        }
    }

    public float FloatRandomRange()
    {
        int random = Random.Range(0, 100);

        if (random < 50)
        {
            return min;
        }
        else if (random < 65)
        {
            return min + 1 * (DisRange() / 4);
        }
        else if (random < 80)
        {
            return min + 2 * (DisRange() / 4);
        }
        else if (random < 95)
        {
            return min + 3 * (DisRange() / 4);
        }
        else
        {
            return max;
        }
    }

    public float DisRange()
    {
        return max - min;
    }


    public RangePoint(float min, float max)
    {
        this.min = min;
        this.max = max;
    }
}