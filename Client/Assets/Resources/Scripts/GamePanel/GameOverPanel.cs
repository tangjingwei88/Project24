using UnityEngine;
using System.Collections;

public class GameOverPanel : MonoBehaviour
{
    #region 引用
    public UILabel winLabel;
    public UILabel LoseLabel;


    #endregion


    #region 变量

    #endregion


    #region 方法
    public void Apply()
    {
        if (GameData.Instance.win)
        {
            winLabel.gameObject.SetActive(true);
        }
        else {
            winLabel.gameObject.SetActive(false);
        }
    
    }


    public void OKBtnClick()
    {
        this.gameObject.SetActive(false);
        GamePanel.Instance.InitGame();
    }


    #endregion
}
