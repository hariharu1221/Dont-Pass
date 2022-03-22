using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public GameObject content;
    public GameObject itemPrefab;
    private List<SaleSkill> skills;

    private void Start()
    {
        SetContent();
    }

    public void SetContent()
    {
        skills = new List<SaleSkill>();
        for (int i = 0; i < GetSkillUtils.indexCount(); i++)
        {
            var n = Instantiate(itemPrefab.gameObject, content.transform);
            SaleSkill skill = n.GetComponent<SaleSkill>();
            skill.SetSaleSkill(i);
            skills.Add(skill);
        }
    }


}
