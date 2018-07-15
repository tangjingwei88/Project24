using UnityEngine;
using System.Collections;
using System;

public class InputDragItem : UIDragDropItem {

    //该item的父亲
    private GameObject itemParent;

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

        base.OnDragDropRelease(surface);
        if (surface.tag == "DragInput")
        {
            //被拖拽item的显示内容
            string tempStr = transform.GetComponentInChildren<UILabel>().text;
            //被拖拽item的名字
            string itemName = this.gameObject.name;
            //被拖拽item的名字截去"(clone)"字符
            itemName = itemName.Substring(0, itemName.Length - 7);
            //将拖拽碰撞检测到item显示内容赋值给被拖拽item
            itemParent.transform.Find(itemName + "/Label").GetComponent<UILabel>().text = surface.GetComponentInChildren<UILabel>().text;
            //将被拖拽item的内容赋值给拖拽检测到的item
            surface.GetComponentInChildren<UILabel>().text = tempStr;
        }
    }
}
