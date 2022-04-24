using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextLanguage : MonoBehaviour //Text�� �ִ� ���� ������Ʈ�� �ְ� ���
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
        //DataManager ���� ���� ��� �ް� Set
        if (true) GetComponent<Text>().text = English;
        if (true) GetComponent<Text>().text = Japanese;
        if (true) GetComponent<Text>().text = Korean;
    }
}
