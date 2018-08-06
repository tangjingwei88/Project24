﻿using UnityEngine;
using System.Collections;

public class GameOverPanel : MonoBehaviour
{
    #region 引用
    public UILabel winLabel;
    public UILabel LoseLabel;
    public UILabel goldLabel;
    public UILabel timeLabel;


    #endregion


    #region 变量

    #endregion


    #region 方法
    public void Apply()
    {

        if (GameData.Instance.win)
        {
            winLabel.gameObject.SetActive(true);
            LoseLabel.gameObject.SetActive(false);
        }
        else {
            winLabel.gameObject.SetActive(false);
            LoseLabel.gameObject.SetActive(true);
        }
    
    }


    public void OKBtnClick()
    {
        this.gameObject.SetActive(false);
        GamePanel.Instance.InitGame();
    }


    /// <summary>
    /// 下一关卡
    /// </summary>
    public void NextStage()
    {
        GameData.Instance.GameStage += 1;
        GamePanel.Instance.InitGame();
    }

    #endregion
}
