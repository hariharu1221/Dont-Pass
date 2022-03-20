using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetSkillUtils
{
    public static SkillMono GetSkill(int index, GameObject ob)
    {
        if (index == 0) ob.AddComponent<NormalChar>();
        else if (index == 1) ob.AddComponent<BonusChar>();
        else if (index == 2) ob.AddComponent<LineClear>();
        else if (index == 3) ob.AddComponent<AllLineClear>();
        return ob.GetComponent<SkillMono>();
    }

    public static SkillInfo GetSkillInfo(int index)
    {
        SkillMono skill = new NormalChar();

        if (index == 0) skill = new NormalChar();
        else if (index == 1) skill = new BonusChar();
        else if (index == 2) skill = new LineClear();
        else if (index == 3) skill = new AllLineClear();

        skill.Set();
        SkillInfo skillInfo = skill.Info;
        return skillInfo;
    }

    public static int indexCount()
    {
        return 4;
    }
}

