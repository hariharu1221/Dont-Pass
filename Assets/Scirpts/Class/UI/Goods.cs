using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Goods : MonoBehaviour
{
    [HideInInspector] public RectTransform rect;
    public TextMeshProUGUI gemText;
    public TextMeshProUGUI goldText;
    private int gem;
    private int gold;

    private void Awake()
    {
        rect = GetComponent<RectTransform>();
    }

    private void Start()
    {
        SetText();
    }

    public void SetText()
    {
        gemText.text = DataManager.Instance.Gem.ToString();
        goldText.text = DataManager.Instance.Gold.ToString();
    }
}
