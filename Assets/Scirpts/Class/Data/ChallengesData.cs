using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UserData : Data
{
    public UserData()
    {
        playCount = 0;
        attackedCount = 0;
        damagedCount = 0;
        useSkillCount = 0;
        purchaseCount = 0;
        totalGold = 0;
        totalScore = 0;
        name = "user";
        startDate = DateTime.Now;
    }

    public int playCount;       //플레이 횟수
    public int attackedCount;   //적을 처치한 횟수
    public int damagedCount;    //데미지를 받은 횟수
    public int useSkillCount;   //스킬을 사용한 횟수
    public int purchaseCount;   //아이템을 구매한 횟수
    public int totalGold;       //누적 골드
    public float totalScore;    //누적 점수
    public string name;
    public DateTime startDate;
    public TimeSpan nowSpan;
}

public class OwnSkillData : Data
{

}

public class OwnItemData : Data
{

}

public class OwnGoodsData : Data
{
    public OwnGoodsData()
    {
        gold = 0;
        gem = 0;
    }

    public int gold;
    public int gem;
}

public class SelectedData : Data
{

}

public class QuestData : Data
{

}

public abstract class Data
{
    public Data()
    {

    }
}
