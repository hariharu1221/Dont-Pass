using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextLanguage : MonoBehaviour //Text가 있는 게임 오브젝트에 넣고 사용
{
    [SerializeField] private string English;
    [SerializeField] private string Japanese;
    [SerializeField] private string Korean;

    public void Awake()
    {
        ChangeLanguage();
    }

    public void Start()
    {
        EventManager.Instance.RegisterListener(ChangeLanguage, "LanguageEvent");
    }

    public void ChangeLanguage()
    {
        //DataManager 에서 현제 언어 받고 Set
        if (true) GetComponent<Text>().text = English;
        if (true) GetComponent<Text>().text = Japanese;
        if (true) GetComponent<Text>().text = Korean;
    }
}
