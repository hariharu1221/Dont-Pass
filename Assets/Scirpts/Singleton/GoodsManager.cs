using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodsManager : Singleton<GoodsManager>
{
    private string GOODSDATA_FILENAME => "GoodsData";
    private int gold;
    private int gem;

    private void Awake()
    {
        SaveData save = JsonUtils.Load(GOODSDATA_FILENAME);

        if (save == null)
        {
            save = new SaveData();
            save.IntData.Add("gold", 0);
            save.IntData.Add("gem", 0);
            JsonUtils.Save(save, GOODSDATA_FILENAME);
        }

        gold = save.IntData["gold"];
        gem = save.IntData["gem"];
    }

    public int Gold
    {
        get { return gold; }
        set 
        {
            if (value < 0) return; //골드가 부족합니다 ui
            gold = value;
            JsonUtils.SaveintData("gold", gold, GOODSDATA_FILENAME);
        }
    }

    public int Gem
    {
        get { return gem; }
        set 
        {
            if (value < 0) return;
            gem = value;
            JsonUtils.SaveintData("gem", gem, GOODSDATA_FILENAME);
        }
    }
}