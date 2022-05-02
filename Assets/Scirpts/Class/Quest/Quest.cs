using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Condition
{
    private event Action ConditionAction;
    protected StringLanguage questContent;
    protected string checkEvent = "PlayOnce";
    public string CheckEvent => checkEvent;

    protected abstract bool IsClear();

    protected void ClearCheck()
    {
        if (IsClear())
        {
            //UIManager.Instance.QuestClearPopup(questContent);
            ConditionAction.Invoke();
        }
    }

    protected void EventRegist()
    {
        EventManager.Instance.RegisterListener(ClearCheck, checkEvent);
    }

    public void ConditionRigist(Action listener)
    {
        ConditionAction += listener;
    }
}

public class ScoreCondition : Condition
{
    private int currentScore;
    public int CurrentScore => currentScore;

    protected override bool IsClear()
    {
        if (currentScore < DataManager.Instance.UserData.totalScore)
            return true;
        return false;
    }

    public ScoreCondition(int currentScore, StringLanguage questContent)
    {
        this.currentScore = currentScore;
        this.questContent = questContent;

        checkEvent = "PlayOnce";
        EventRegist();
    }
}