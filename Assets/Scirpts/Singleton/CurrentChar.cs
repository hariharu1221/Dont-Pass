using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentChar : Singleton<CurrentChar>
{
    private int selectOneCharIndex;
    private int selectTwoCharIndex;

    private void Awake()
    {
        SetInstance();
    }

    void Update()
    {
        
    }

    public int GetOneIndex()
    {
        return selectOneCharIndex;
    }
    
    public int GetTwoIndex()
    {
        return selectTwoCharIndex;
    }
}

