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
    public IEnumerator GetEnumerator() // 인터페이스 구현
    {
        GetEnumerator();
        yield return GetEnumerator();
        yield break; // 영구 종료. 일반 return과 같음. 다시 안돌아옴.
    }
}