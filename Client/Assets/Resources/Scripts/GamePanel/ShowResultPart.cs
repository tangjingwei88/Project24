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
    public GameObject redSprite_7;
    public GameObject redSprite_8;
    public GameObject redSprite_9;

    public GameObject yellowSprite_1;
    public GameObject yellowSprite_2;
    public GameObject yellowSprite_3;
    public GameObject yellowSprite_4;
    public GameObject yellowSprite_5;
    public GameObject yellowSprite_6;
    public GameObject yellowSprite_7;
    public GameObject yellowSprite_8;
    public GameObject yellowSprite_9;

    public GameObject greenSprite_1;
    public GameObject greenSprite_2;
    public GameObject greenSprite_3;
    public GameObject greenSprite_4;
    public GameObject greenSprite_5;
    public GameObject greenSprite_6;
    public GameObject greenSprite_7;
    public GameObject greenSprite_8;
    public GameObject greenSprite_9;

    public Transform anchorRoot;
    public GameObject numberInputRoot;
    public AudioClip showResultMusic;
    public Transform showEffectParent;
    #endregion


    #region 变量


    #endregion

    void Awake()
    {

    }



    public void Apply(Dictionary<LIGHT_TYPE, int> dictionary)
    {
        ShowLight(LIGHT_TYPE.red, dictionary[LIGHT_TYPE.red]);
        ShowLight(LIGHT_TYPE.yellow, dictionary[LIGHT_TYPE.yellow]);
        ShowLight(LIGHT_TYPE.green, dictionary[LIGHT_TYPE.green]);
        ShowResultEffect();
    }


    /// <summary>
    /// 显示结果特效
    /// </summary>
    /// <param name="name"></param>
    public void ShowResultEffect()
    {
        NGUITools.PlaySound(showResultMusic,0.1f);
        GameObject showEffectGO = ResourceManager.Instance.NewUIParticle("LevelUp_Big_Scale");
        showEffectGO.transform.parent = showEffectParent;
        showEffectGO.transform.localPosition = Vector3.zero;

        Destroy(showEffectGO,1.0f);
    }



    /// <summary>
    ///显示灯
    /// </summary>
    public  void ShowLight(LIGHT_TYPE LType,int num)
    {
        if (LType == LIGHT_TYPE.red)
        {
            ShowSprite("showIcon/redSpriteRoot/redSprite_", num);
        }
        else if (LType == LIGHT_TYPE.yellow)
        {
            ShowSprite("showIcon/yellowSpriteRoot/yellowSprite_", num);
        }
        else if (LType == LIGHT_TYPE.green)
        {
            ShowSprite("showIcon/greenSpriteRoot/greenSprite_", num);
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
            for (int i = num + 1; i <= (int)GameData.Instance.GameLevel; i++)
            {
                transform.Find(path + i).gameObject.SetActive(false); ;
            }
        }
    }

    /// <summary>
    /// 刷新显示
    /// </summary>
    public void Clear()
    {
        redSprite_1.SetActive(false);
        redSprite_2.SetActive(false);
        redSprite_3.SetActive(false);
        redSprite_4.SetActive(false);
        redSprite_5.SetActive(false);
        redSprite_6.SetActive(false);
        redSprite_7.SetActive(false);
        redSprite_8.SetActive(false);
        redSprite_9.SetActive(false);

        yellowSprite_1.SetActive(false);
        yellowSprite_2.SetActive(false);
        yellowSprite_3.SetActive(false);
        yellowSprite_4.SetActive(false);
        yellowSprite_5.SetActive(false);
        yellowSprite_6.SetActive(false);
        yellowSprite_7.SetActive(false);
        yellowSprite_8.SetActive(false);
        yellowSprite_9.SetActive(false);

        greenSprite_1.SetActive(false);
        greenSprite_2.SetActive(false);
        greenSprite_3.SetActive(false);
        greenSprite_4.SetActive(false);
        greenSprite_5.SetActive(false);
        greenSprite_6.SetActive(false);
        greenSprite_7.SetActive(false);
        greenSprite_8.SetActive(false);
        greenSprite_9.SetActive(false);
    }
}
