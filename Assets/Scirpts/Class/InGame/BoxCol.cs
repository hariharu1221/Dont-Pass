using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCol : MonoBehaviour
{
    private HitBox box;
    public HitBox Box
    {
        get { return box; }
        set { box = value; }
    }
    
    private BoxCollider2D col;
    public BoxCollider2D Col
    {
        get { return col; }
        set { col = value; }
    }

    public EnemyDir dir;
    public EnemyState state;
    private float attackMult;
    private float allMult;  
    private float sumScore;
    private int sumEnemyCount;
    private bool attack;

    public float AttackMult { get { return attackMult; } set { attackMult = value; } }
    public float AllMult { get { return allMult; } set { allMult = value; } }

    private void Awake()
    {
        col = GetComponent<BoxCollider2D>();
        sumScore = 0;
        sumEnemyCount = 0;
        allMult = 1;
        attackMult = 1;
        attack = false;
    }

    public void AttackEnemy(EnemyDir dir, EnemyState state)
    {
        this.dir = dir;
        this.state = state;
        attack = true;
    }

    public int PlusCount(ref int enemyCount)
    {
        int result = sumEnemyCount;
        enemyCount += sumEnemyCount;
        sumEnemyCount = 0;
        return result;
    }

    public float PlusScore(ref float score)
    {
        sumScore *= allMult;
        float result = sumScore;
        score += sumScore;
        sumScore = 0;
        return result;
    }

    public void StopAttack()
    {
        attack = false;
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if (attack && other.CompareTag("Enemy"))
        {
            EnemyMono enemy = other.GetComponent<EnemyMono>();
            if (enemy.AttackCheck(dir, state))
            {
                sumScore += enemy.enemyState.score * attackMult;
                sumEnemyCount++;
                enemy.Damaged();
            }
        }
    }
}
