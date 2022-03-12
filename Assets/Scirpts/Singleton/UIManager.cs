using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    private Stack<Popup> popup;

    void Awake()
    {
        popup = new Stack<Popup>();
    }

    void Update()
    {
        
    }
}
