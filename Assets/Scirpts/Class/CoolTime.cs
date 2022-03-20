using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoolTime {
    public bool isCool;
    public float maxCool;
    public float nowCool;

    public CoolTime(float maxCool)
    {
        this.maxCool = maxCool;
        isCool = false;
        nowCool = 0;
    }

    public IEnumerator Cool()
    {
        isCool = true;
        while (maxCool >= nowCool)
        {
            nowCool += Time.deltaTime;
            yield return new WaitForFixedUpdate();
        }
        nowCool = 0;
        isCool = false;
    }
}
