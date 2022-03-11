using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineCol : MonoBehaviour
{
    private List<Enemy> onEnemies;

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
        onEnemies = new List<Enemy>();
        col = GetComponent<BoxCollider2D>();
    }

    public void InEnemy(Enemy enemy)
    {
        onEnemies.Add(enemy);
    }

    public void OutEnemy(Enemy enemy)
    {
        onEnemies.Remove(enemy);
    }

    public bool SearchEnemy(Enemy enemy)
    {
        return onEnemies.Contains(enemy);
    }
}
