using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalChar : Charater
{
    public NormalChar()
    {
        this.name = "normal";
        this.skillText = "노트를 칠 수 있는 엄청 좋은 스킬!";
        this.sprite = null;
        this.index = 0;

        this.hp = 3;
        this.coliderPos = new List<Point>();
        this.coliderPos.Add(new Point(100, 0));
        this.cool = 30f;
    }

    protected override void Skill()
    {
        //GameManager.Instance.
    }
}

public class BonusChar : Charater
{
    public BonusChar()
    {
        this.name = "bonus";
        this.skillText = "점수 보너스를 얻을 수 있는 엄청 좋은 스킬!";
        this.sprite = null;
        this.index = 1;

        this.hp = 3;
        this.coliderPos = new List<Point>();
        this.coliderPos.Add(new Point(60, -4));
        this.coliderPos.Add(new Point(60, 4));
        this.cool = 30f;
    }

    protected override void Skill()
    {
        //GameManager.Instance.
    }
}