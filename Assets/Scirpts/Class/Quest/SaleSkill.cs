using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaleSkill : MonoBehaviour
{
    private SkillInfo skillInfo;

    public void SetSaleSkill(int index)
    {
        skillInfo = GetSkillUtils.GetSkillInfo(index);
    }
}
