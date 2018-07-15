using UnityEngine;
using System.Collections;

public class DragItem : UIDragDropItem {

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

        base.OnDragDropRelease(surface);
        if (surface.tag == "DragInput")
        {
            //获取拖拽过程中碰撞检测到的item的内容
            string tempStr = surface.GetComponentInChildren<UILabel>().text;
            //将被拖拽的item内容赋值给拖拽检测到的item
            surface.GetComponentInChildren<UILabel>().text = transform.GetComponentInChildren<UILabel>().text;
            //检测输入的合法性
            if (GamePanel.Instance.CheckInputNumLegal(GamePanel.Instance.GetTempInputNumber(GameData.Instance.GameLevel)))
            {
                return;
            }
            else 
            {
                 //检测输入的数据不合法，被修改的item显示内容不做修改
                surface.GetComponentInChildren<UILabel>().text = tempStr;
            }
        }

    }

}
