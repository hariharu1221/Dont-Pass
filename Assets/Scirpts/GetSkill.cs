using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetSkillUtils
{
    public static SkillMono GetSkill(int index, GameObject ob)
    {
        if (index == 0) ob.AddComponent<NormalSkill>();
        else if (index == 1) ob.AddComponent<Light>();
        else if (index == 2) ob.AddComponent<Storm>();
        else if (index == 3) ob.AddComponent<BlackHole>();
        return ob.GetComponent<SkillMono>();
    }

    public static SkillInfo GetSkillInfo(int index)
    {
        SkillMono skill = new NormalSkill();

        if (index == 0) skill = new NormalSkill();
        else if (index == 1) skill = new Light();
        else if (index == 2) skill = new Storm();
        else if (index == 3) skill = new BlackHole();

        skill.Set();
        SkillInfo skillInfo = skill.Info;
        return skillInfo;
    }

    public static int indexCount()
    {
        return 4;
    }
}

