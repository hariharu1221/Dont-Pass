using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Line : MonoBehaviour
{
    private RectTransform rect;
    public RectTransform Rect
    {
        get { return rect; }
    }

    private Image image;
    public Image Image
    {
        get { return image; }
    }

    private void Awake()
    {
        rect = GetComponent<RectTransform>();
        image = GetComponent<Image>();
    }

}

