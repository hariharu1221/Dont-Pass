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
        skillInfo = GetSkillUtils.GetSkillInfo(index);

        Addressables.LoadAssetAsync<Sprite>(skillInfo.spriteAddress).Completed +=
            (AsyncOperationHandle<Sprite> ob) =>
            {
                handle = ob;
                image.sprite = ob.Result;
            };
        _name.text = skillInfo.name;

        Layer.transform.Find("gem").gameObject.SetActive(true);
        price.text = skillInfo.gemPrice.ToString();
    }

    public void Release()
    {
        Addressables.Release(handle);
        image.sprite = null;
    }
}
