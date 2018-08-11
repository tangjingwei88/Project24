using UnityEngine;
using System.Collections;
using System;

public class InputDragItem : UIDragDropItem {

    #region 引用
    //该item的父亲
    private GameObject itemParent;
    public AudioClip dragMusic;
    public UILabel nameLabel;
    public UISprite icon;
    public GameObject DragInputWidget;

    #endregion
    void Start()
    {
        DragInputWidget.GetComponent<UIGrid>().repositionNow = false;
    }

    #region 方法

    public void Apply(string nameIconStr)
    {
        string[] strList = nameIconStr.Split(':');
        nameLabel.text = strList[0];
        icon.spriteName = strList[1];

    }


    /// <summary>
    /// 重写父类的拖拽开始函数
    /// </summary>
    protected override void OnDragDropStart()
    {

        //得到该item的父亲
        this.itemParent = this.transform.parent.gameObject;

        base.OnDragDropStart();
    }


    /// <summary>
    /// 拖拽释放
    /// </summary>
    /// <param name="surface"></param>
    protected override void OnDragDropRelease(GameObject surface)
    {
        NGUITools.PlaySound(dragMusic,0.1f);
        base.OnDragDropRelease(surface);
        if (surface.tag == "DragInput")
        {
            //被拖拽item的显示内容
            string tempStr = transform.GetComponentInChildren<UILabel>().text;
            //将改变过的item暂存起来，log显示时改变背景色以示区分
            GameData.Instance.changedItemOne = int.Parse(tempStr);
            string tempSpriteName = transform.FindChild("icon").GetComponentInChildren<UISprite>().spriteName;
        //    string tempBgName = transform.FindChild("bg").GetComponentInChildren<UISprite>().spriteName;
            //被拖拽item的名字
            string itemName = this.gameObject.name;
            //名字裁剪（Clone）
            itemName = itemName.Substring(0,(itemName.Length - 7));

            string surfaceStr = surface.transform.FindChild("Label").GetComponentInChildren<UILabel>().text;
            
            //将改变过的item暂存起来，log显示时改变背景色以示区分
            GameData.Instance.changedItemTwo = int.Parse(surfaceStr);

            //将拖拽碰撞检测到item显示内容赋值给被拖拽item
            itemParent.transform.Find(itemName + "/Label").GetComponent<UILabel>().text = surfaceStr;
            itemParent.transform.Find(itemName + "/icon").GetComponent<UISprite>().spriteName = surface.transform.FindChild("icon").GetComponentInChildren<UISprite>().spriteName;
      //      itemParent.transform.Find(itemName + "/bg").GetComponent<UISprite>().spriteName = surface.transform.FindChild("bg").GetComponentInChildren<UISprite>().spriteName;
            
            //将被拖拽item的内容赋值给拖拽检测到的item
            surface.transform.FindChild("Label").GetComponentInChildren<UILabel>().text = tempStr;
            surface.transform.FindChild("icon").GetComponentInChildren<UISprite>().spriteName = tempSpriteName;
       //     surface.transform.FindChild("bg").GetComponentInChildren<UISprite>().spriteName = tempBgName;
        }
    }

    #endregion
}
