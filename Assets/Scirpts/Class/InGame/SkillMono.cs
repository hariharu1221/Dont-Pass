using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class SkillMono : MonoBehaviour
{
    protected SkillInfo info;
    public SkillInfo Info { get { return info; } }

    [SerializeField] protected List<Point> coliderPos;
    public List<Point> ColiderPos { get { return coliderPos; } }

    [SerializeField] protected int hp;
    public int Hp { get { return hp; } }

    [SerializeField] protected CoolTime cool;
    public CoolTime Cool
    {
        get { return cool; }
        set { cool = value; }
    }

    public readonly BuffType Type = BuffType.Invincibility;

    private void Awake()
    {
        Set();
    }

    public abstract void Set();

    public void UseSkill() //��Ƽ�� ��ų ���
    {
        if (Cool.isCool) return;
        StartCoroutine(Cool.Cool());
        Skill();
    }

    protected virtual void Skill()
    {

    }

    public virtual void SwitchSkill()
    {

    }

    public virtual void Passive() //�׻� ���� �Ǵ� �нú�
    {

    }

    public virtual void ActivationPassive() //���� ĳ���Ͱ� �� ĳ������ ��� ����Ǵ� Ȱ��ȭ �нú�
    {

    }
}

public class SkillInfo
{
    public string name;
    public string skillText;
    public string spriteAddress;
    public int index;
    public int goldPrice;
    public int gemPrice;
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