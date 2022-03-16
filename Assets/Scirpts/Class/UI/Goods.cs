using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goods : MonoBehaviour
{
    public RectTransform rect;

    private void Awake()
    {
        rect = GetComponent<RectTransform>();
    }
}
