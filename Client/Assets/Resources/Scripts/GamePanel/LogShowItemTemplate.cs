using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LogShowItemTemplate : MonoBehaviour {

    #region 引用
    public UILabel resultLabel;               //玩家输入的数据
    public UILabel roundLabel;                 //第几轮

    public GameObject lightWidget;
    public GameObject LightItemTemplate;




    #endregion

    #region 变量
    public List<GameObject> lightItemList = new List<GameObject>();
    #endregion

    public void Apply(Dictionary<LIGHT_TYPE,int> dic)
    {
        //ShowLight(LIGHT_TYPE.red, dic[LIGHT_TYPE.red]);
        //ShowLight(LIGHT_TYPE.yellow, dic[LIGHT_TYPE.yellow]);
        //ShowLight(LIGHT_TYPE.green, dic[LIGHT_TYPE.green]);
        //resultLabel.text = GameData.Instance.gameInput;
        roundLabel.text = "R" + GameData.Instance.gameRound.ToString();

        foreach (var item in dic)
        {
            for (int i = 0; i < item.Value; i++)
            {
                GameObject go = Instantiate(LightItemTemplate);
                go.SetActive(true);
                go.transform.parent = lightWidget.transform;
                go.transform.localScale = new Vector3(0.5f,0.5f,0.5f) ;
                lightItemList.Add(go);

                LightItemTemplate sc = go.GetComponent<LightItemTemplate>();
                sc.Apply(item);
                lightWidget.GetComponent<UIGrid>().repositionNow = true;
                lightWidget.GetComponent<UIGrid>().maxPerLine = GameData.Instance.resultColumn;
            }

        }
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


    public void Clear()
    {
        for (int i = 0; i < lightItemList.Count; i++)
        {
            Destroy(lightItemList[i]);
        }
    }

    #endregion
}
