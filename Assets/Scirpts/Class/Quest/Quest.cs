using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Condition
{
    public abstract bool IsClear();
}

public class ScoreCondition : Condition
{
    int currentScore;

    public override bool IsClear()
    {
        if (currentScore < DataManager.Instance.UserData.totalScore)
            return true;
        return false;
    }

    public ScoreCondition(int currentScore)
    {
        this.currentScore = currentScore;
    }
}