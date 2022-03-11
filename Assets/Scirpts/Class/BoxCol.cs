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
    public float mult;
    public float sumScore;
    public int sumEnemyCount;
    public bool attack;

    public void Awake()
    {
        col = GetComponent<BoxCollider2D>();
        sumScore = 0;
        sumEnemyCount = 0;
        attack = false;
    }

    public void AttackEnemy(EnemyDir dir, EnemyState state, float mult)
    {
        this.dir = dir;
        this.state = state;
        this.mult = mult;
        attack = true;
    }

    public int PlusScoreWithCount(ref float score, ref int enemyCount)
    {
        attack = false;

        score += sumScore;
        enemyCount += sumEnemyCount;
        sumScore = 0;
        sumEnemyCount = 0;
        return sumEnemyCount;
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if (attack && other.CompareTag("Enemy"))
        {
            EnemyMono enemy = other.GetComponent<EnemyMono>();
            if (enemy.AttackCheck(dir, state))
            {
                sumScore += enemy.enemyState.score * mult;
                sumEnemyCount++;
                enemy.Damaged();
            }
        }
    }
}
