using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Linq;

public class UIManager : Singleton<UIManager>
{
    private Stack<Popup> popups;
    private List<UIWindow> uiWindows;
    private Menu menu;
    private Goods goods;

    private void Awake()
    {
        SetInstance();
        VariableSet();
    }

    private void VariableSet()
    {
        popups = new Stack<Popup>();
        uiWindows = FindObjectsOfType<UIWindow>().ToList();
        menu = FindObjectOfType<Menu>();
        goods = FindObjectOfType<Goods>();
    }

    public void AddPopup(Popup p)
    {
        popups.Push(p);
    }

    public void AddUIWindow(UIWindow win)
    {
        uiWindows.Add(win);
    }

    public void AllUIShutdown(Sequence sequence)
    {
        if (sequence == null) sequence = DOTween.Sequence();

        foreach(UIWindow win in uiWindows)
        {
            if (!win.IsOpen) continue;
            sequence.AppendCallback(() => win.CloseSequence());
            sequence.AppendInterval(0.2f);
            //sequence.Join(win.CloseSequence());
        }
        sequence.AppendInterval(0.4f);
        sequence.Append(DOTween.To(() => menu.rect.anchoredPosition, 
            x => menu.rect.anchoredPosition = x, new Vector2(0, -212.5f), 0.75f).SetEase(Ease.InCubic));
        sequence.Join(DOTween.To(() => goods.rect.anchoredPosition,
            x => goods.rect.anchoredPosition = x, new Vector2(267.5f, goods.rect.anchoredPosition.y), 0.76f).SetEase(Ease.InCubic));
    }
}
//ui 윈도우 모두 제거
//pop 모두 제거
//