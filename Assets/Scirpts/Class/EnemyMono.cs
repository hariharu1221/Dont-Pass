using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyMono : MonoBehaviour
{
    public Enemy enemyState;
    public Enemy EnemyState
    {
        get { return enemyState; }
        set { enemyState = value; }
    }

    bool canMove;
    bool isEscape;
    private void Awake()
    {
        canMove = true;
        isEscape = false;
    }


    private void Update()
    {
        if (isEscape) return;
        Move();
        Escape();
    }

    private void Move()
    {
        if (!canMove) return;

        float x = 0;
        if (enemyState.dir == EnemyDir.R) x = enemyState.tempo;
        else if (enemyState.dir == EnemyDir.L) x = -enemyState.tempo;
        transform.position += new Vector3(x * 4f * Time.deltaTime, 0);
    }

    private void Escape()
    {
        if((enemyState.dir == EnemyDir.R && transform.position.x > 8.64f)
            || (enemyState.dir == EnemyDir.L && transform.position.x < -8.64f))
        {
            Death();
        }
    }

    public bool AttackCheck(EnemyDir dir, EnemyState state)
    {
        if (isEscape) return false;
        if (state == global::EnemyState.BothTouch) return true;
        if (dir == enemyState.dir) return true;
        return false;
    }

    public void Damaged()
    {
        enemyState.hp--;
        if (enemyState.hp <= 0) Death();
    }

    public void Death()
    {
        if (isEscape) return;
        gameObject.GetComponentInParent<LineCol>().OutEnemy(this);
        isEscape = true;
        DOTween.To(() => transform.localScale, x => transform.localScale = x, new Vector3(0f, 0f), 0.2f);
        StartCoroutine(Utils.DelayDestroy(gameObject, 0.25f));
    }

    private void OnTriggerEnter2D(Collider2D other)
    { 

    }
}
