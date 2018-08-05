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
//        this.gameObject.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
//        this.gameObject.transform.localPosition = Camera.main.WorldToScreenPoint(transform.position);
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
        Debug.LogError("@@@" + surface.GetComponentInChildren<UILabel>().text);
        Debug.LogError("@@@surface.tag" + surface.tag);
        if (surface.CompareTag("DragInput"))
        {
            //获取拖拽过程中碰撞检测到的item的内容
            string tempStr = surface.GetComponentInChildren<UILabel>().text;
            Debug.LogError("@@@tempStr" + tempStr);
            //将被拖拽的item内容赋值给拖拽检测到的item
            surface.GetComponentInChildren<UILabel>().text = transform.GetComponentInChildren<UILabel>().text;
            //检测输入的合法性
            if (GamePanel.Instance.CheckInputNumLegal(GamePanel.Instance.GetTempInputNumber(GameData.Instance.GameStage)))
            {
                return;
            }
            else 
            {
                 //检测输入的数据不合法，被修改的item显示内容不做修改
                surface.GetComponentInChildren<UILabel>().text = tempStr;
                Debug.LogError("@@@illegal");
            }
        }

    }
    #endregion
}
