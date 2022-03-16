using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class Menu : MonoBehaviour
{
    private Dictionary<string, Button> pair = new Dictionary<string, Button>();
    public RectTransform rect;

    private void Awake()
    {
        VariableSet();
        ButtonSet();
    }

    private void VariableSet()
    {
        Button[] buttons = GetComponentsInChildren<Button>();
        foreach(Button b in buttons)
        {
            pair[b.name] = b;
        }
        rect = GetComponent<RectTransform>();
    }

    private void ButtonSet()
    {
        UIWindow[] uiWindows = FindObjectsOfType<UIWindow>();
        foreach(UIWindow win in uiWindows)
        {
            if (!pair.ContainsKey(win.name)) continue;
            pair[win.name].onClick.AddListener(() => win.ConverseWIndow());
            win.Close();
        }
        pair["Play"].onClick.AddListener(() => Play());
    }

    private void Play()
    {
        Sequence mySequence = DOTween.Sequence();
        mySequence.OnStart(() => {
            foreach (Button button in pair.Values)
                button.interactable = false;
        });
        UIManager.Instance.AllUIShutdown(mySequence);
        mySequence.AppendInterval(1f);
        mySequence.OnComplete(() => { SceneLoadManager.LoadScene(2); });
    }
}
