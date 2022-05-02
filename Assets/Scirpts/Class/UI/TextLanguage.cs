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

public class StringLanguage
{
    private string English;
    private string Japanese;
    private string Korean;

    public string ChangeLanguage()
    {
        //DataManager 에서 현제 언어 받고 Set
        if (true) return English;
        if (true) return Japanese;
        if (true) return Korean;
    }

    public void SetString(string English, string Japanese, string Korean)
    {
        this.English = English;
        this.Japanese = Japanese;
        this.Korean = Korean;
    }

    public StringLanguage(string English, string Japanese, string Korean)
    {
        SetString(English, Japanese, Korean);
    }
}