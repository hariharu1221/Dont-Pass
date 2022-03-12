using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetChar : MonoBehaviour
{
    public static Charater getchar(int index, GameObject ob)
    {
        if (index == 0) ob.AddComponent<NormalChar>();
        else if (index == 1) ob.AddComponent<BonusChar>();
        else if (index == 2) ob.AddComponent<LineClear>();
        else if (index == 3) ob.AddComponent<AllLineClear>();
        return ob.GetComponent<Charater>();
    }
}

