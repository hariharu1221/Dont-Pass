using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalSkill : SkillMono
{
    public override void Set()
    {
        info = new SkillInfo();
        this.info.name = "손";
        this.info.skillText = "노트를 칠 수 있는 엄청 좋은 스킬!";
        this.info.spriteAddress = "SkillIcon/Hand";
        this.info.index = 0;
        this.info.goldPrice = 0;
        this.info.gemPrice = 0;

        this.hp = 3;
        this.coliderPos = new List<Point>();
        this.coliderPos.Add(new Point(100, 0));
        this.cool = new CoolTime(30f);
    }

    protected override void Skill()
    {
        //GameManager.Instance.
    }

    public override void Passive()
    {
        
    }
}

public class Light : SkillMono
{
    public override void Set()
    {
        info = new SkillInfo();
        this.info.name = "빛";
        this.info.skillText = "얻는 점수를 20% 상승시킵니다.";
        this.info.spriteAddress = "SkillIcon/Light";
        this.info.index = 1;
        this.info.goldPrice = 0;
        this.info.gemPrice = 0;

        this.hp = 3;
        this.coliderPos = new List<Point>();
        this.coliderPos.Add(new Point(60, -4));
        this.coliderPos.Add(new Point(60, 4));
        this.cool = new CoolTime(30f);
    }

    public override void Passive()
    {
        GameManager.Instance.AllMult = 1.2f;
    }
}

public class Storm : SkillMono
{
    public override void Set()
    {
        info = new SkillInfo();
        this.info.name = "폭풍";
        this.info.skillText = "랜덤한 라인 하나를 클리어 합니다. (점수 획득 가능)";
        this.info.spriteAddress = "SkillIcon/Storm";
        this.info.index = 2;
        this.info.goldPrice = 2500;
        this.info.gemPrice = 60;

        this.hp = 2;
        this.coliderPos = new List<Point>();
        this.coliderPos.Add(new Point(80, -2));
        this.coliderPos.Add(new Point(80, 6));
        this.cool = new CoolTime(15f);
    }

    protected override void Skill()
    {
        GameManager.Instance.Line[Random.Range(0, GameManager.Instance.Line.Count)].LineClear();
    }
}

public class BlackHole : SkillMono
{
    public override void Set()
    {
        info = new SkillInfo();
        this.info.name = "블랙홀";
        this.info.skillText = "모든 라인을 클리어 합니다. (점수 1.5배 획득)";
        this.info.spriteAddress = "SkillIcon/BlackHole";
        this.info.index = 3;
        this.info.goldPrice = 15000;
        this.info.gemPrice = 240;

        this.hp = 2;
        this.coliderPos = new List<Point>();
        this.coliderPos.Add(new Point(80, -2));
        this.coliderPos.Add(new Point(80, 6));
        this.cool = new CoolTime(30f);
    }

    protected override void Skill()
    {
        foreach(var line in GameManager.Instance.Line)
        {
            line.LineClear(1.5f, ref GameManager.Instance.score, ref GameManager.Instance.enemyCount);
        }
    }
}