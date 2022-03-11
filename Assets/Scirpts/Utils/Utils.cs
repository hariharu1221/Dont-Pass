using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils
{
    public static IEnumerator DelayDestroy(GameObject ob, float time)
    {
        yield return new WaitForSeconds(time);
        GameObject.Destroy(ob);
        yield break;
    }
}
