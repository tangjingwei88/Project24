using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LogShowItemTemplate : MonoBehaviour {

    #region 引用
    public UILabel resultLabel;               //玩家输入的数据
    public UILabel roundLabel;                 //第几轮

    public GameObject greenSprite_1;
    public GameObject greenSprite_2;
    public GameObject greenSprite_3;
    public GameObject greenSprite_4;
    public GameObject greenSprite_5;
    public GameObject greenSprite_6;
    public GameObject greenSprite_7;
    public GameObject greenSprite_8;
    public GameObject greenSprite_9;

    public GameObject yellowSprite_1;
    public GameObject yellowSprite_2;
    public GameObject yellowSprite_3;
    public GameObject yellowSprite_4;
    public GameObject yellowSprite_5;
    public GameObject yellowSprite_6;
    public GameObject yellowSprite_7;
    public GameObject yellowSprite_8;
    public GameObject yellowSprite_9;

    public GameObject redSprite_1;
    public GameObject redSprite_2;
    public GameObject redSprite_3;
    public GameObject redSprite_4;
    public GameObject redSprite_5;
    public GameObject redSprite_6;
    public GameObject redSprite_7;
    public GameObject redSprite_8;
    public GameObject redSprite_9;





    #endregion

    #region 变量

    #endregion
    
    public void Apply(Dictionary<LIGHT_TYPE,int> dic)
    {
        ShowLight(LIGHT_TYPE.red, dic[LIGHT_TYPE.red]);
        ShowLight(LIGHT_TYPE.yellow, dic[LIGHT_TYPE.yellow]);
        ShowLight(LIGHT_TYPE.green, dic[LIGHT_TYPE.green]);
        resultLabel.text = GameData.Instance.gameInput;
        roundLabel.text = "R" + GameData.Instance.gameRound.ToString();
    }


    #region 方法

    /// <summary>
    ///显示灯
    /// </summary>
    public void ShowLight(LIGHT_TYPE LType, int num)
    {
        if (LType == LIGHT_TYPE.red)
        {
            ShowSprite("redSpriteRoot/redSprite_", num);
        }
        else if (LType == LIGHT_TYPE.yellow)
        {
            ShowSprite("yellowSpriteRoot/yellowSprite_", num);
        }
        else if (LType == LIGHT_TYPE.green)
        {
            ShowSprite("greenSpriteRoot/greenSprite_", num);
        }
    }


    /// <summary>
    /// 控制sprite顯示
    /// </summary>
    /// <param name="path"></param>
    /// <param name="num"></param>
    private void ShowSprite(string path, int num)
    {
        if (num >= 1)
        {
            for (int i = 1; i <= num; i++)
            {
                transform.Find(path + i).gameObject.SetActive(true); ;
            }
        }
        if (num < 4)
        {
            for (int i = num + 1; i <= (int)GameData.Instance.GameStage; i++)
            {
                transform.Find(path + i).gameObject.SetActive(false); ;
            }
        }
    }


    #endregion
}
