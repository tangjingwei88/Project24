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
            Debug.LogError("###surface.GetComponentInChildren<UILabel>().text " + surface.GetComponentInChildren<UILabel>().text);
            Debug.LogError("###transform.GetComponentInChildren<UILabel>().text " + transform.GetComponentInChildren<UILabel>().text);
            string tempStr = surface.GetComponentInChildren<UILabel>().text;
            surface.GetComponentInChildren<UILabel>().text = transform.GetComponentInChildren<UILabel>().text;
            //检测输入的合法性
            if (GamePanel.Instance.CheckInputNumLegal(GamePanel.Instance.GetTempInputNumber(GameData.Instance.GameLevel)))
            {
                return;
            }
            else {
                surface.GetComponentInChildren<UILabel>().text = tempStr;
            }
        }

    }

}
