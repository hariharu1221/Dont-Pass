using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalChar : Charater
{
    protected override void Set()
    {
        this.name = "normal";
        this.skillText = "노트를 칠 수 있는 엄청 좋은 스킬!";
        this.sprite = null;
        this.index = 0;

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

public class BonusChar : Charater
{
    protected override void Set()
    {
        this.name = "Bonus";
        this.skillText = "얻는 점수를 20% 상승시킵니다.";
        this.sprite = null;
        this.index = 1;

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

public class LineClear : Charater
{
    protected override void Set()
    {
        this.name = "Clear random line";
        this.skillText = "랜덤한 라인 하나를 클리어 합니다. (점수 획득 가능)";
        this.sprite = null;
        this.index = 2;

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

public class AllLineClear : Charater
{
    protected override void Set()
    {
        this.name = "Clear all lines";
        this.skillText = "모든 라인을 클리어 합니다. (점수 획득 가능)";
        this.sprite = null;
        this.index = 3;

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
            line.LineClear();
        }
    }
}