using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UIMain : MonoBehaviour {

    #region 引用

    public TipsPopUpPanel theTipsPopUpPanel;

    #endregion


    #region 变量

    Stack<UIState> uiStateStack = new Stack<UIState>();

    #endregion


    #region 属性
    private static UIMain _Instance;
    public static UIMain Instance
    {
        get
        {
            return _Instance;
        }
    }

    private static UIState recentUIState = UIState.MainState;
    public static UIState RecentUIState {
        get {
            return recentUIState;
        }
    }


    #endregion



    void Awake()
    {
        _Instance = this;
    }

    void Start() { }


    public enum UIState
    {
        MainState,
        TipsPopUpPanelState,

    }

    /// <summary>
    /// 获取UI的名称
    /// </summary>
    /// <param name="InputUIStateName"></param>
    /// <returns></returns>
    public string GetUIStateName(UIState InputUIStateName)
    {
        if (InputUIStateName == UIState.MainState)
        {
            return "主界面";
        }
        else if (InputUIStateName == UIState.TipsPopUpPanelState)
        {
            return "Tips";
        }

        return "";
    }



    public class UIMainPanelHelper
    {
        public UIState targetState;
        public string prefabPath;
        public string typeName;

        public UIMainPanelHelper(UIState inputTargetState, string inputPrefabPath, string inputTypeName)
        {
            targetState = inputTargetState;
            prefabPath = inputPrefabPath;
            typeName = inputTypeName;
        }

    }
}
