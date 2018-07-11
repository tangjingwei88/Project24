using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShowResultPart : MonoBehaviour {

    #region 引用
    public GameObject redSprite_1;
    public GameObject redSprite_2;
    public GameObject redSprite_3;

    public GameObject yellowSprite_1;
    public GameObject yellowSprite_2;
    public GameObject yellowSprite_3;

    public GameObject greenSprite_1;
    public GameObject greenSprite_2;
    public GameObject greenSprite_3;
    #endregion


    #region 变量


    #endregion



    public void Apply(Dictionary<LightType, int> dictionary)
    {
        foreach (var dic in dictionary)
        {

        }
    }



    /// <summary>
    ///显示灯
    /// </summary>
    private void ShowLight()
    {

    }
}
