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

    [SerializeField] protected CoolTime cool;
    public CoolTime Cool
    {
        get { return cool; }
        set { cool = value; }
    }

    private void Awake()
    {
        Set();
    }

    protected abstract void Set();

    public void UseSkill() //엑티브 스킬 사용
    {
        if (Cool.isCool) return;
        StartCoroutine(Cool.Cool());
        Skill();
    }

    protected virtual void Skill()
    {

    }

    public void SwitchSkill()
    {

    }

    public virtual void Passive() //항상 유지 되는 패시브
    {

    }

    public virtual void ActivationPassive() //현재 캐릭터가 이 캐릭터일 경우 실행되는 활성화 패시브
    {

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