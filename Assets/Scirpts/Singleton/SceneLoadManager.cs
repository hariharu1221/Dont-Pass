using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoadManager : Singleton<SceneLoadManager>
{
    private Image loadBar;
    private const string LoadBarAddress = "LoadBar";

    private void Awake()
    {
        SetInstance();
        LoadData();
    }

    protected override void LoadData()
    {
        //loadBar = AddressableManager.Instance.InstaniateGameObject(LoadBarAddress).GetComponent<Image>();
    }

    public static void LoadScene(int n)
    {
        SceneManager.LoadScene(n);
        System.GC.Collect();
    }

    public static void LoadScene(string n)
    {
        SceneManager.LoadScene(n);
        System.GC.Collect();
    }
}

public class ins : IEnumerable
{
    public IEnumerator GetEnumerator() // �������̽� ����
    {
        GetEnumerator();
        yield return GetEnumerator();
        yield break; // ���� ����. �Ϲ� return�� ����. �ٽ� �ȵ��ƿ�.
    }
}