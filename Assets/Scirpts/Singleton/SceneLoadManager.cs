using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadManager
{
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
