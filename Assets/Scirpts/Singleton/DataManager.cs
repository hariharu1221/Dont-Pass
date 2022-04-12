using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : Singleton<DataManager>
{
    #region FILENAME
    private string GOODSDATA_FILENAME => "GoodsData";
    private string SKILLDATA_FILENAME => "SkillData";
    private string ITEMDATA_FILENAME => "ItemData";
    private string USERDATA_FILENAME => "UserData";

    #endregion

    #region VARIABLE
    private OwnGoodsData goodsData;
    private OwnSkillData skillData;
    private OwnItemData itemData;
    private UserData userData;

    #endregion

    #region GETSET
    public OwnGoodsData GoodsData
    {
        get { return goodsData; }
        set
        {
            goodsData = value;
            JsonUtils.Save(goodsData, GOODSDATA_FILENAME);
        }
    }

    public OwnSkillData SkillData
    {
        get { return skillData; }
        set
        {
            skillData = value;
            JsonUtils.Save(skillData, SKILLDATA_FILENAME);
        }
    }

    public OwnItemData ItemData
    {
        get { return itemData; }
        set
        {
            itemData = value;
            JsonUtils.Save(itemData, USERDATA_FILENAME);
        }
    }

    public UserData UserData
    {
        get { return userData; }
        set
        {
            UserData = value;
            JsonUtils.Save(UserData, USERDATA_FILENAME);
        }
    }

    #endregion

    private void Awake()
    {
        SetInstance();
        LoadData();
    }

    protected override void LoadData()
    {
        goodsData = JsonUtils.Load<OwnGoodsData>(GOODSDATA_FILENAME);
        skillData = JsonUtils.Load<OwnSkillData>(SKILLDATA_FILENAME);
        itemData = JsonUtils.Load<OwnItemData>(ITEMDATA_FILENAME);
        userData = JsonUtils.Load<UserData>(USERDATA_FILENAME);
    }
    
    public void AllSave()
    {
        JsonUtils.Save(goodsData, GOODSDATA_FILENAME);
        JsonUtils.Save(skillData, SKILLDATA_FILENAME);
        JsonUtils.Save(itemData, USERDATA_FILENAME);
        JsonUtils.Save(UserData, USERDATA_FILENAME);
    }

    private void OnApplicationQuit()
    {
        AllSave();
    }

    public int Gold
    {
        get { return goodsData.gold; }
        set
        {
            if (value < 0) return; //골드가 부족합니다 ui
            goodsData.gold = value;
            JsonUtils.Save(goodsData, GOODSDATA_FILENAME);
        }
    }

    public int Gem
    {
        get { return goodsData.gem; }
        set
        {
            if (value < 0) return;
            goodsData.gem = value;
            JsonUtils.Save(goodsData, GOODSDATA_FILENAME);
        }
    }
}
