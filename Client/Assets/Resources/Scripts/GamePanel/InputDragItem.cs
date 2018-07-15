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
            Debug.LogError("###surface.GetComponentInChildren<UILabel>().text " + surface.GetComponentInChildren<UILabel>().text);
            Debug.LogError("###transform.GetComponentInChildren<UILabel>().text " + transform.GetComponentInChildren<UILabel>().text);

            string tempStr = transform.GetComponentInChildren<UILabel>().text;
            Debug.LogError("tempStr " + tempStr);
            int itemNum = Convert.ToInt32(tempStr);

            Debug.LogError("itemParent " + itemParent);
            Debug.LogError("itemNum " + itemNum);

            itemParent.transform.Find("DragInputItem_" + itemNum + "/Label").GetComponent<UILabel>().text = surface.GetComponentInChildren<UILabel>().text;
            surface.GetComponentInChildren<UILabel>().text = tempStr;

        }
        

    }
}
