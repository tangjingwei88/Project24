using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShowLogPart : MonoBehaviour {

    #region 引用
    public GameObject logShowItemTemplate;
    public GameObject LogShowScrollRoot;
    public GameObject LogShowWidget;
    #endregion


    #region 变量


    void Update()
    {
        //LogShowScrollRoot.GetComponent<UIScrollView>().verticalScrollBar.value = 1f;
    }


    #endregion

    public void Apply(Dictionary<LIGHT_TYPE, int> dic)
    {
        //LogShowScrollRoot.GetComponent<UIScrollView>().verticalScrollBar.value = 1f;
        GameObject go = Instantiate(logShowItemTemplate);
        go.SetActive(true);
        go.transform.parent = LogShowWidget.transform;
        go.transform.localScale = Vector3.one;
        Debug.LogError("#" +transform.Find("LogShowScrollRoot/bar").gameObject.GetComponent<UIProgressBar>().value);
        transform.Find("LogShowScrollRoot/bar").gameObject.GetComponent<UIProgressBar>().value = 1;
        Debug.LogError("##" + transform.Find("LogShowScrollRoot/bar").gameObject.GetComponent<UIProgressBar>().value);

        LogShowItemTemplate sc = go.GetComponent<LogShowItemTemplate>();
        sc.Apply(dic);
        LogShowWidget.GetComponent<UIGrid>().repositionNow = true;
        GameData.Instance.gameRound++;
        transform.Find("LogShowScrollRoot/bar").gameObject.GetComponent<UIProgressBar>().value = 1;
    }
}
