using UnityEngine;
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
        timeLabel.text = "耗时：" + GamePanel.Instance.timer.ToString();

        if (GameData.Instance.win)
        {
            winLabel.gameObject.SetActive(true);
            LoseLabel.gameObject.SetActive(false);
            PlayerPrefs.SetInt("GameStage",GameData.Instance.GameStage + 1);
        }
        else {
            winLabel.gameObject.SetActive(false);
            LoseLabel.gameObject.SetActive(true);
        }
    
    }

    /// <summary>
    /// 确定按钮返回选关界面
    /// </summary>
    public void OKBtnClick()
    {
        this.gameObject.SetActive(false);
        StopAllCoroutines();
        GamePanel.Instance.timer = 0;
        //GamePanel.Instance.InitGame(GameData.Instance.GameStage);

        //没加框架，没用栈管理界面显示隐藏真恶心，后面加入
        this.gameObject.SetActive(false);
        UIMain.Instance.theStagePassedPanel.gameObject.SetActive(true);
        UIMain.Instance.theStagePassedPanel.Apply(GameData.Instance.GameStage);
    }

    /// <summary>
    /// 再玩一局
    /// </summary>
    public void NextStageBtnClick()
    {
        StopAllCoroutines();
        this.gameObject.SetActive(false);
        GamePanel.Instance.timer = 0;
        //NextStage();
        this.gameObject.SetActive(false);
        GamePanel.Instance.InitGame(GameData.Instance.GameStage);
    }


    /// <summary>
    /// 下一关卡
    /// </summary>
    public void NextStage()
    {
        GameData.Instance.GameStage += 1;
        GamePanel.Instance.InitGame(GameData.Instance.GameStage);
    }

    #endregion
}
