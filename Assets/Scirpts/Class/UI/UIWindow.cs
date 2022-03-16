using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIWindow : MonoBehaviour
{
    [SerializeField] private Button closeButton;
    private RectTransform rect;
    private Vector2 originSize;
    private float time = 0.4f;
    private bool isOpen;
    public bool IsOpen { get { return isOpen;} }

    private void Awake()
    {
        VariableSet();
        ButtonSet();
    }

    private void VariableSet()
    {
        //if (closeButton == null) closeButton = gameObject.transform.Find("CloseButton").GetComponent<Button>();
        rect = GetComponent<RectTransform>();
        originSize = rect.sizeDelta;
    }

    private void ButtonSet()
    {
        closeButton.onClick.AddListener(() => CloseWindow());
    }

    public void Close()
    {
        isOpen = false;
        rect.sizeDelta = new Vector2(0f, 50);
        gameObject.SetActive(false);
    }

    public void CloseWindow()
    {
        isOpen = false;
        Sequence mySequence = DOTween.Sequence();
        mySequence.OnStart(() => { gameObject.SetActive(true); });
        mySequence.Append(DOTween.To(() => rect.sizeDelta, x => rect.sizeDelta = x, new Vector2(rect.sizeDelta.x, 50), time).SetEase(Ease.OutCubic));
        mySequence.Append(DOTween.To(() => rect.sizeDelta, x => rect.sizeDelta = x, new Vector2(0f, 50), time).SetEase(Ease.InCubic));
        mySequence.OnComplete(() => { StartCoroutine(OpenActive()); });
    }

    public void OpenWIndow()
    {
        isOpen = true;
        Sequence mySequence = DOTween.Sequence();
        mySequence.OnStart(() => { gameObject.SetActive(true); });
        mySequence.Append(DOTween.To(() => rect.sizeDelta, x => rect.sizeDelta = x, new Vector2(originSize.x, rect.sizeDelta.y), time).SetEase(Ease.OutCubic));
        mySequence.Append(DOTween.To(() => rect.sizeDelta, x => rect.sizeDelta = x, new Vector2(originSize.x, originSize.y), time).SetEase(Ease.InCubic));
        mySequence.OnComplete(() => { gameObject.SetActive(true); });
    }

    public Sequence CloseSequence()
    {
        return DOTween.Sequence()
            .OnStart(() => { gameObject.SetActive(true); })
            .Append(DOTween.To(() => rect.sizeDelta, x => rect.sizeDelta = x, new Vector2(rect.sizeDelta.x, 50), time).SetEase(Ease.OutCubic))
            .Append(DOTween.To(() => rect.sizeDelta, x => rect.sizeDelta = x, new Vector2(0f, 50), time).SetEase(Ease.InCubic))
            .OnComplete(() => { StartCoroutine(OpenActive()); });
    }

    public Sequence OpenSequence()
    {
        return DOTween.Sequence()
            .OnStart(() => { gameObject.SetActive(true); })
            .Append(DOTween.To(() => rect.sizeDelta, x => rect.sizeDelta = x, new Vector2(originSize.x, rect.sizeDelta.y), time).SetEase(Ease.OutCubic))
            .Append(DOTween.To(() => rect.sizeDelta, x => rect.sizeDelta = x, new Vector2(originSize.x, originSize.y), time).SetEase(Ease.InCubic))
            .OnComplete(() => { gameObject.SetActive(true); });
    }

    IEnumerator OpenActive()
    {
        float cool = 0;
        while (cool < 1f)
        {
            if (isOpen) yield break;
            cool += Time.deltaTime;
            yield return new WaitForFixedUpdate();
        }
        gameObject.SetActive(false);
    }

    public void ConverseWIndow()
    {
        if (isOpen) CloseWindow();
        else OpenWIndow();
    }
}
