using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShowResultPart : MonoBehaviour {

    #region 引用
    public GameObject redSprite_1;
    public GameObject redSprite_2;
    public GameObject redSprite_3;
    public GameObject redSprite_4;
    public GameObject redSprite_5;
    public GameObject redSprite_6;

    public GameObject yellowSprite_1;
    public GameObject yellowSprite_2;
    public GameObject yellowSprite_3;
    public GameObject yellowSprite_4;
    public GameObject yellowSprite_5;
    public GameObject yellowSprite_6;

    public GameObject greenSprite_1;
    public GameObject greenSprite_2;
    public GameObject greenSprite_3;
    public GameObject greenSprite_4;
    public GameObject greenSprite_5;
    public GameObject greenSprite_6;
    #endregion


    #region 变量


    #endregion



    public void Apply(Dictionary<LIGHT_TYPE, int> dictionary)
    {
        ShowLight(LIGHT_TYPE.red, dictionary[LIGHT_TYPE.red]);
        ShowLight(LIGHT_TYPE.yellow, dictionary[LIGHT_TYPE.yellow]);
        ShowLight(LIGHT_TYPE.green, dictionary[LIGHT_TYPE.green]);
    }



    /// <summary>
    ///显示灯
    /// </summary>
    public  void ShowLight(LIGHT_TYPE LType,int num)
    {
        if (LType == LIGHT_TYPE.red)
        {
            ShowSprite("showIcon/redSprite_", num);
        }
        else if (LType == LIGHT_TYPE.yellow)
        {
            ShowSprite("showIcon/yellowSprite_", num);
        }
        else if (LType == LIGHT_TYPE.green)
        {
            ShowSprite("showIcon/greenSprite_",num);
        }
    }


    /// <summary>
    /// 控制sprite顯示
    /// </summary>
    /// <param name="path"></param>
    /// <param name="num"></param>
    private void ShowSprite(string path,int num)
    {
        if (num >= 1) 
        {
            for (int i = 1; i <= num; i++)
            {
                transform.Find(path + i).gameObject.SetActive(true); ;
            }
        }
        if(num < 4)
        {
            for (int i = num + 1; i < (int)GameData.Instance.GameLevel; i++)
            {
                transform.Find(path + i).gameObject.SetActive(false); ;
            }
        }
    }
}
