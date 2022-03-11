using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentChar : Singleton<CurrentChar>
{
    private int selectCharIndex;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public int GetIndex()
    {
        return selectCharIndex;
    }
}

