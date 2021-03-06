using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Enemy
{
    public int hp;
    public float score;
    public float tempo;
    public EnemyDir dir;
    public EnemyState state;
    public int index;

    public Enemy(int hp, float score, float tempo, EnemyDir dir, EnemyState state, int index)
    {
        this.hp = hp;
        this.score = score;
        this.tempo = tempo;
        this.dir = dir;
        this.state = state;
        this.index = index;
    }
}

public enum EnemyDir
{
    R,
    L,
}

public enum EnemyState
{
    Normal,
    DoubleTouch,
    BothTouch
}