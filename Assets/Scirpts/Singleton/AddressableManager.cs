using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class AddressableManager : Singleton<AddressableManager>
{
    private Dictionary<string, AsyncOperationHandle> HandlePair = new Dictionary<string, AsyncOperationHandle>();

    private void Awake()
    {
        SetInstance();
    }

    public T LoadAsset<T>(string address) where T : MonoBehaviour
    {
        var op = Addressables.LoadAssetAsync<T>(address);
        op.Completed += (AsyncOperationHandle<T> handle) =>
        {
            HandlePair.Add(address, handle);
        };

        T asset = op.WaitForCompletion();
        return asset;
    }

    public GameObject InstaniateGameObject(string address)
    {
        var op = Addressables.InstantiateAsync(address);
        op.Completed += (AsyncOperationHandle<GameObject> handle) =>
        {
            HandlePair.Add(address, handle);
        };

        GameObject ob = op.WaitForCompletion();
        return ob;
    }

    public void Reelease(string address)
    {
        if (!HandlePair.ContainsKey(address)) return;
        Addressables.Release(HandlePair[address]);
    }
}
