using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetChar : MonoBehaviour
{
    public static Charater getchar(int index)
    {
        if (index == 0) return new NormalChar();
        else if (index == 1) return new BonusChar();
        return new NormalChar();
    }
}

