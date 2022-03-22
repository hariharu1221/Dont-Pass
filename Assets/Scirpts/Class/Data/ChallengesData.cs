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

    public int playCount;       //�÷��� Ƚ��
    public int attackedCount;   //���� óġ�� Ƚ��
    public int damagedCount;    //�������� ���� Ƚ��
    public int useSkillCount;   //��ų�� ����� Ƚ��
    public int purchaseCount;   //�������� ������ Ƚ��
    public int totalGold;       //���� ���
    public float totalScore;    //���� ����
    public string name;
    public DateTime startDate;
    public TimeSpan nowSpan;
}

public class OwnSkillData : Data
{
    public OwnSkillData()
    {
        ownNormal = true;
        ownLight = true;
        ownStorm = false;
        ownBlackHole = false;
    }

    public bool ownNormal;
    public bool ownLight;
    public bool ownStorm;
    public bool ownBlackHole;
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
