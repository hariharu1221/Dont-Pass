using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LineCol : MonoBehaviour
{
    private List<EnemyMono> onEnemies;

    private Line line;
    public Line Line
    {
        get { return line; }
        set { line = value; }
    }

    private BoxCollider2D col;
    public BoxCollider2D Col
    {
        get { return col; }
        set { col = value; }
    }

    public void Awake()
    {
        onEnemies = new List<EnemyMono>();
        col = GetComponent<BoxCollider2D>();
    }

    public void InEnemy(EnemyMono enemy)
    {
        onEnemies.Add(enemy);
    }

    public void OutEnemy(EnemyMono enemy)
    {
        onEnemies.Remove(enemy);
    }

    public bool SearchEnemy(EnemyMono enemy)
    {
        return onEnemies.Contains(enemy);
    }

    public void LineClear()
    {
        List<EnemyMono> copy = onEnemies.ToList();
        foreach (var enemy in copy)
        {
            enemy.Death();
        }
    }

    public void LineClear(float mult, ref float score, ref int enemyCount)
    {
        float sum = 0;
        List<EnemyMono> copy = onEnemies.ToList();
        enemyCount += copy.Count;
        foreach (var enemy in copy)
        {
            sum += enemy.enemyState.score * mult;
            enemy.Death();
        }
        score += sum;
    }
}
