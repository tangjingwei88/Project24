using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DragItem : UIDragDropItem {

    #region 引用
    public AudioClip dragMusic;
    public UILabel nameLabel;
    public UISprite icon;

    #endregion


    #region 方法

    public void Apply(string numIconStr)
    {
        string[] strList = numIconStr.Split(':');
        nameLabel.text = strList[0];
        icon.spriteName = strList[1];
    }



    /// <summary>
    /// 重写父类的拖拽开始函数
    /// </summary>
    protected override void OnDragDropStart()
    {
        base.OnDragDropStart();
        
    }


    /// <summary>
    /// 拖拽释放
    /// </summary>
    /// <param name="surface"></param>
    protected override void OnDragDropRelease(GameObject surface)
    {
        NGUITools.PlaySound(dragMusic, 0.1f);
        base.OnDragDropRelease(surface);

        if (surface.CompareTag("DragInput"))
        {
            //获取拖拽过程中碰撞检测到的item的内容
            string tempStr = surface.GetComponentInChildren<UILabel>().text;

            string tempIconStr = surface.transform.FindChild("icon").GetComponent<UISprite>().spriteName;
            string tempBgStr = surface.transform.FindChild("bg").GetComponent<UISprite>().spriteName;

            //将改变过的item暂存起来，log显示时改变背景色以示区分
            GameData.Instance.changedItemOne = int.Parse(transform.GetComponentInChildren<UILabel>().text);

            //将被拖拽的item内容赋值给拖拽检测到的item
            surface.GetComponentInChildren<UILabel>().text = transform.GetComponentInChildren<UILabel>().text;
            surface.transform.FindChild("icon").GetComponentInChildren<UISprite>().spriteName = transform.FindChild("icon").GetComponentInChildren<UISprite>().spriteName;
         //   surface.transform.FindChild("bg").GetComponentInChildren<UISprite>().spriteName = transform.FindChild("bg").GetComponentInChildren<UISprite>().spriteName;
            //检测输入的合法性
            if (GamePanel.Instance.CheckInputNumLegal(GamePanel.Instance.GetTempInputNumber(GameData.Instance.gameLv)))
            {
                return;
            }
            else 
            {
                 //检测输入的数据不合法，被修改的item显示内容不做修改
                surface.GetComponentInChildren<UILabel>().text = tempStr;
                surface.transform.FindChild("icon").GetComponent<UISprite>().spriteName = tempIconStr;
          //      surface.transform.FindChild("bg").GetComponent<UISprite>().spriteName = tempBgStr;
            }
        }

    }
    #endregion
}
