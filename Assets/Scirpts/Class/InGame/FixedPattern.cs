using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FixedPattern
{
    private float lengthTime;
    public float LengthTime { get { return lengthTime; }  set { lengthTime = value; } }

    private List<SecondEnemy> enemyList;
    public List<SecondEnemy> EnemyList { get { return enemyList; } }

    public FixedPattern(List<Dictionary<string,object>> data)
    {
        enemyList = new List<SecondEnemy>();
        foreach (Dictionary<string,object> item in data)
        {
            Enemy enemy = 
                new Enemy(int.Parse(item["moveSize"].ToString()), 
                float.Parse(item["score"].ToString()),
                float.Parse(item["tempo"].ToString()), 
                (EnemyDir)Enum.Parse(typeof(EnemyDir), item["EnemyDir"].ToString()),
                (EnemyState)Enum.Parse(typeof(EnemyState), item["EnemyState"].ToString()),
                int.Parse(item["index"].ToString())
                );
            float second = float.Parse(item["second"].ToString());
            enemyList.Add(new SecondEnemy(enemy, second));
        }

        lengthTime = (float)data[data.Count - 1]["second"] + 0.5f;
    }
}

[System.Serializable]
public class SecondEnemy
{
    public Enemy enemy;
    public float second;

    public SecondEnemy(Enemy enemy, float second)
    {
        this.enemy = enemy;
        this.second = second;
    }
}