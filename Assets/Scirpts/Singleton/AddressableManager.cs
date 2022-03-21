using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class AddressableManager : Singleton<AddressableManager>
{
    List<GameObject> gameObjects = new List<GameObject>();
    private void Awake()
    {
        SetInstance();
    }
}
