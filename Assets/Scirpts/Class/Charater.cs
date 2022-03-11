using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class Charater : MonoBehaviour
{
    public string name;
    public string skillText;
    public Sprite sprite;

    [SerializeField] protected int index;
    public int Index {  get { return index; } }

    [SerializeField] protected List<Point> coliderPos;
    public List<Point> ColiderPos
    {
        get { return coliderPos; }
        set { coliderPos = value; }
    }

    [SerializeField] protected int hp;
    public int Hp
    {
        get { return hp; }
        set { hp = value; }
    }

    [SerializeField] protected float cool;
    public float Cool
    {
        get { return cool; }
        set { cool = value; }
    }

    bool canUseSkill = true;

    public void UseSkill()
    {
        if (!canUseSkill) return;
        StartCoroutine(CoolTime());
        Skill();
    }

    protected abstract void Skill();
    IEnumerator CoolTime()
    {
        canUseSkill = false;
        yield return new WaitForSeconds(cool);
    }
}

public enum BuffType
{
    RightBonus,
    LeftBonus,
    BothBonus,
    CoinBonus,
    Invincibility,
    Shield,
    TouchCoolZero
}