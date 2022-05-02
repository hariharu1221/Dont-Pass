using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using TMPro;

public class SaleSkill : MonoBehaviour
{
    private AsyncOperationHandle handle;
    private SkillInfo skillInfo;
    public TextMeshProUGUI _name;
    public TextMeshProUGUI price;
    public Image image;
    public GameObject Layer;

    public void SetSaleSkill(int index)
    {
        //index 보유 여부 확인 및 파괴
        skillInfo = GetSkillUtils.GetSkillInfo(index);

        LoadImage();
        _name.text = skillInfo.name;
        Layer.transform.Find("gem").gameObject.SetActive(true);
        price.text = skillInfo.gemPrice.ToString();
    }


    private void LoadImage()
    {
         Addressables.LoadAssetAsync<Sprite>(skillInfo.spriteAddress).Completed +=
            (AsyncOperationHandle<Sprite> ob) =>
            {
                handle = ob;
                image.sprite = ob.Result;
            };
    }

    public void Buy()
    {

    }



    private void OnDestroy()
    {
        Release();
    }

    public void Release()
    {
        if (skillInfo == null) return;
        Addressables.Release(handle);
    }
}
