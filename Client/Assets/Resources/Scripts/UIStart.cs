using UnityEngine;
using System.Collections;

public class UIStart : MonoBehaviour {

    #region 引用

    public GameObject theLoginPartPanel;
    public GameObject theRegisterPanel;

    #endregion

    #region 属性
    private static UIStart _instance;
    public static UIStart Instance {
        get {
            return _instance;
        }
    }

    #endregion



    void Awake()
    {
        _instance = this;
    }



    void Start () {
        theLoginPartPanel.gameObject.SetActive(true);
	}


    #region 方法



    #endregion
}
